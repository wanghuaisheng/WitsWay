using System;
using System.Reflection;
using WitsWay.Utilities.Extends;
using WitsWay.Utilities.FastReflection;
using WitsWay.Utilities.Guards;

namespace WitsWay.Utilities.EntityCast
{

    /// <summary>
    /// 属性映射信息
    /// </summary>
    /// <typeparam name="A">原类型</typeparam>
    public abstract class PropertyMapping<A>
    {
        /// <summary>
        /// 属性映射信息
        /// </summary>
        /// <param name="property">B对应属性信息</param>
        protected PropertyMapping(PropertyInfo property)
        {
            Property = property;
        }

        /// <summary>
        /// Get要映射的B对应属性信息
        /// </summary>
        public PropertyInfo Property { get; }

        /// <summary>
        /// 获取A的对应属性值
        /// </summary>
        /// <param name="a">原实体</param>
        /// <returns>属性值</returns>
        public abstract object GetPropertyValue(A a);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="a"></param>
        public void Map(object instance, A a)
        {
            var convertedValue = GetPropertyValue(a);

            SetValue(instance, convertedValue);
        }

        /// <summary>
        /// 设置属性值
        /// </summary>
        /// <param name="instance">B实例</param>
        /// <param name="value">属性值</param>
        protected void SetValue(object instance, object value)
        {
            Property.SetValue(instance, value, new object[0]);
        }

    }

    /// <summary>
    /// 属性名映射信息
    /// </summary>
    public class PropertyNameMapping<A> : PropertyMapping<A>
    {

        /// <summary>
        /// 属性名映射信息
        /// </summary>
        /// <param name="property">B的属性信息</param>
        /// <param name="propertyName">A的属性名</param>
        public PropertyNameMapping(PropertyInfo property, string propertyName) : base(property)
        {
            PropertyName = propertyName;
        }

        /// <summary>
        /// A的属性名
        /// </summary>
        public string PropertyName { get; }

        /// <summary>
        /// 取得属性值
        /// </summary>
        /// <param name="a">A实体</param>
        /// <returns>A的对应名称属性值</returns>
        public override object GetPropertyValue(A a)
        {
            ArgumentGuard.ArgumentNotNull("a", a);
            var value = typeof(A).GetProperty(PropertyName)?.FastGetValue(a);
            var convertedValue = value.CastTo(Property.PropertyType);
            return convertedValue;
        }
    }

    /// <summary>
    /// Func映射信息
    /// </summary>
    public class FuncMapping<A> : PropertyMapping<A>
    {
        /// <summary>
        /// Func映射信息
        /// </summary>
        /// <param name="property">B的属性信息</param>
        /// <param name="func">从A获取对应值的Func</param>
        public FuncMapping(PropertyInfo property, Func<A, object> func) : base(property)
        {
            ArgumentGuard.ArgumentNotNull("func", func);
            Func = func;
        }

        /// <summary>
        /// 从A获取属性值Func
        /// </summary>
        public Func<A, object> Func { get; }

        /// <summary>
        /// 获取属性值
        /// </summary>
        /// <param name="a">A实体</param>
        /// <returns>值</returns>
        public override object GetPropertyValue(A a)
        {
            return Func(a);
        }
    }
}
