using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using WitsWay.Utilities.Guards;
using WitsWay.Utilities.Thread;

namespace WitsWay.Utilities.EntityCast
{

    /// <summary>
    /// 转换器构建者
    /// </summary>
    /// <typeparam name="A">原类型</typeparam>
    /// <typeparam name="B">新类型</typeparam>
    public static class CasterBuilder<A, B>
        where A : new()
        where B : new()
    {

        /// <summary>
        /// 构建转换器
        /// </summary>
        /// <returns>属性自动映射的转换器</returns>
        public static IEntityCaster<A, B> BuildAll()
        {
            return SetAll().Build();
        }

        /// <summary>
        /// 设置所有属性
        /// </summary>
        /// <returns>映射上下文文接口实例</returns>
        public static IMapBuilderContext<A, B> SetAll()
        {
            IMapBuilderContext<A, B> context = new MapBuilderContext();
            var properties =
                from property in typeof(B).GetProperties(BindingFlags.Instance | BindingFlags.Public)
                where IsAutoSetProperty(property)
                select property;

            foreach (var property in properties)
            {
                context = context.Set(property);
            }
            return context;
        }

        /// <summary>
        /// 不设置任何属性映射
        /// </summary>
        /// <returns>映射上下文</returns>
        public static IMapBuilderContext<A, B> NotSetAny()
        {
            return new MapBuilderContext();
        }

        /// <summary>
        /// 是否是自动映射属性
        /// </summary>
        /// <param name="property">属性信息元数据</param>
        /// <returns>是自动映射true，不是自动映射false</returns>
        private static bool IsAutoSetProperty(PropertyInfo property)
        {
            return property.CanWrite
              && property.GetIndexParameters().Length == 0
              && !IsCollectionType(property.PropertyType);
        }

        /// <summary>
        /// 判断类型是否是集合
        /// </summary>
        /// <param name="type">类型</param>
        /// <returns>是集合true，不是集合false</returns>
        private static bool IsCollectionType(Type type)
        {
            //字符串实现了IEnumerable接口，但我们需要映射字符串
            if (type == typeof(string)) return false;
            var interfaces = from inf in type.GetInterfaces()
                             where inf == typeof(IEnumerable) ||
                                 (inf.IsGenericType && inf.GetGenericTypeDefinition() == typeof(IEnumerable<>))
                             select inf;
            return interfaces.Count() != 0;
        }

        /// <summary>
        /// 映射上下文实现
        /// </summary>
        private class MapBuilderContext : IMapBuilderContext<A, B>
        {

            private static ConcurrentDictionary<string, IEntityCaster<A, B>> cachedCaster = new ConcurrentDictionary<string, IEntityCaster<A, B>>();

            private Dictionary<PropertyInfo, PropertyMapping<A>> mappings;

            /// <summary>
            /// 映射上下文实现
            /// </summary>
            public MapBuilderContext()
            {
                mappings = new Dictionary<PropertyInfo, PropertyMapping<A>>();
            }

            /// <summary>
            /// 设置B对应属性 With A对应属性
            /// </summary>
            /// <param name="property">属性信息</param>
            /// <returns>映射上下文对象</returns>
            public IMapBuilderContext<A, B> Set(PropertyInfo property)
            {
                var normalizedPropertyInfo = NormalizePropertyInfo(property);

                return SetIt(normalizedPropertyInfo).With(normalizedPropertyInfo.Name);
            }
            /// <summary>
            /// 设置B对应属性 With A对应属性
            /// </summary>
            /// <typeparam name="P">属性类型</typeparam>
            /// <param name="propertySelector">属性选择器</param>
            /// <returns>映射上下文对象</returns>
            public IMapBuilderContext<A, B> Set<P>(Expression<Func<B, P>> propertySelector)
            {
                var property = ExtractPropertyInfo(propertySelector);

                return Set(property);
            }

            /// <summary>
            /// 不设置B对应属性 With A对应属性
            /// </summary>
            /// <param name="property">属性信息</param>
            /// <returns>映射上下文对象</returns>
            public IMapBuilderContext<A, B> NotSet(PropertyInfo property)
            {
                var normalizedPropertyInfo = NormalizePropertyInfo(property);

                mappings.Remove(normalizedPropertyInfo);

                return this;
            }

            /// <summary>
            /// 不设置B对应属性 With A对应属性
            /// </summary>
            /// <typeparam name="P">属性类型</typeparam>
            /// <param name="propertySelector">属性选择器</param>
            /// <returns>映射上下文对象</returns>
            public IMapBuilderContext<A, B> NotSet<P>(Expression<Func<B, P>> propertySelector)
            {
                var property = ExtractPropertyInfo(propertySelector);

                return NotSet(property);
            }

            /// <summary>
            /// 设置B对应属性
            /// </summary>
            /// <param name="property">B对应属性</param>
            /// <returns>映射上下文对象2</returns>
            public IMapBuilderContextMap<A, B, object> SetIt(PropertyInfo property)
            {
                var normalizedPropertyInfo = NormalizePropertyInfo(property);

                return new MapBuilderContextMap<object>(this, normalizedPropertyInfo);
            }

            /// <summary>
            /// 设置B对应属性
            /// </summary>
            /// <typeparam name="P">属性类型</typeparam>
            /// <param name="propertySelector">属性选择器</param>
            /// <returns>映射上下文对象2</returns>
            public IMapBuilderContextMap<A, B, P> SetIt<P>(Expression<Func<B, P>> propertySelector)
            {
                var property = ExtractPropertyInfo(propertySelector);

                return new MapBuilderContextMap<P>(this, property);
            }

            private LockObject _locker = new LockObject();

            /// <summary>
            /// 构建<see cref="IEntityCaster&lt;A,B&gt;"/> 对象实例
            /// </summary>
            /// <returns> <see cref="IEntityCaster&lt;A,B&gt;"/>接口实例</returns>
            public IEntityCaster<A, B> Build()
            {
                IEntityCaster<A, B> caster = null;

                var cacheKey = GetMappingKey();
                if (!cachedCaster.TryGetValue(cacheKey, out caster))
                {
                    caster = new ReflectionCaster<A, B>(mappings);
                    cachedCaster[cacheKey] = caster;
                }

                return caster;
            }

            /// <summary>
            /// 根据mapping构建一个键用于缓存
            /// </summary>
            /// <returns></returns>
            private string GetMappingKey()
            {
                var sb = new StringBuilder();

                foreach (var item in mappings.OrderBy(kvp => kvp.Key.Name))
                    sb.AppendFormat("{0}|{1},", item.Key.Name, item.Value == null || item.Value.Property == null ? string.Empty : item.Value.Property.Name);

                if (sb.Length > 0)
                    sb.Remove(sb.Length - 1, 1);

                return sb.ToString();
            }

            /// <summary>
            /// 通过Expression获取属性信息
            /// </summary>
            /// <typeparam name="P">属性类型</typeparam>
            /// <param name="propertySelector">属性选择器</param>
            /// <returns>属性信息</returns>
            private static PropertyInfo ExtractPropertyInfo<P>(Expression<Func<B, P>> propertySelector)
            {
                var memberExpression = propertySelector.Body as MemberExpression;
                if (memberExpression == null)
                {
                    throw new ArgumentException("参数必须是属性选择表达式。", nameof(propertySelector));
                }
                var property = memberExpression.Member as PropertyInfo;
                if (property == null)
                {
                    throw new ArgumentException("参数必须是属性选择表达式。", nameof(propertySelector));
                }
                return NormalizePropertyInfo(property);
            }

            /// <summary>
            /// 获取B的对应属性信息
            /// </summary>
            /// <param name="property">属性信息</param>
            /// <returns>属性信息</returns>
            private static PropertyInfo NormalizePropertyInfo(PropertyInfo property)
            {
                if (property == null)
                {
                    throw new ArgumentNullException(nameof(property));
                }
                return typeof(B).GetProperty(property.Name);
            }

            /// <summary>
            /// 映射上下文2
            /// </summary>
            /// <typeparam name="P">属性类型</typeparam>
            private class MapBuilderContextMap<P> : IMapBuilderContextMap<A, B, P>
            {
                private PropertyInfo property;
                private MapBuilderContext builderContext;

                public MapBuilderContextMap(MapBuilderContext builderContext, PropertyInfo property)
                {
                    this.property = property;
                    this.builderContext = builderContext;
                }

                public IMapBuilderContext<A, B> With(Func<A, P> f)
                {
                    ArgumentGuard.ArgumentNotNull("f", f);
                    builderContext.mappings[property] = new FuncMapping<A>(property, row => f(row));

                    return builderContext;
                }


                public IMapBuilderContext<A, B> With(string propertyName)
                {
                    builderContext.mappings[property] = new PropertyNameMapping<A>(property, propertyName);
                    return builderContext;
                }

                public IMapBuilderContext<A, B> With(PropertyInfo propertyA)
                {
                    builderContext.mappings[property] = new PropertyNameMapping<A>(property, propertyA.Name);
                    return builderContext;
                }
            }


        }
    }
}