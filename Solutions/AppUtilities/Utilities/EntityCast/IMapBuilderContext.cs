using System;
using System.Linq.Expressions;
using System.Reflection;

namespace WitsWay.Utilities.EntityCast
{
    /// <summary>
    /// 映射构建上下文接口
    /// </summary>
    /// <typeparam name="A">原类型</typeparam>
    /// <typeparam name="B">新类型</typeparam>
    public interface IMapBuilderContext<A, B>
        where A : new()
        where B : new()
    {
        /// <summary>
        /// 设置B对应属性 With A对应属性
        /// </summary>
        /// <param name="property">属性信息</param>
        /// <returns>映射上下文对象</returns>
        IMapBuilderContext<A, B> Set(PropertyInfo property);

        /// <summary>
        /// 设置B对应属性 With A对应属性
        /// </summary>
        /// <typeparam name="P">属性类型</typeparam>
        /// <param name="propertySelector">属性选择器</param>
        /// <returns>映射上下文对象</returns>
        IMapBuilderContext<A, B> Set<P>(Expression<Func<B, P>> propertySelector);

        /// <summary>
        /// 不设置B对应属性 With A对应属性
        /// </summary>
        /// <param name="property">属性信息</param>
        /// <returns>映射上下文对象</returns>
        IMapBuilderContext<A, B> NotSet(PropertyInfo property);

        /// <summary>
        /// 不设置B对应属性 With A对应属性
        /// </summary>
        /// <typeparam name="P">属性类型</typeparam>
        /// <param name="propertySelector">属性选择器</param>
        /// <returns>映射上下文对象</returns>
        IMapBuilderContext<A, B> NotSet<P>(Expression<Func<B, P>> propertySelector);

        /// <summary>
        /// 设置B对应属性
        /// </summary>
        /// <param name="property">B对应属性</param>
        /// <returns>映射上下文对象2</returns>
        IMapBuilderContextMap<A, B, object> SetIt(PropertyInfo property);

        /// <summary>
        /// 设置B对应属性
        /// </summary>
        /// <typeparam name="P">属性类型</typeparam>
        /// <param name="propertySelector">属性选择器</param>
        /// <returns>映射上下文对象2</returns>
        IMapBuilderContextMap<A, B, P> SetIt<P>(Expression<Func<B, P>> propertySelector);


        /// <summary>
        /// 构建<see cref="IEntityCaster&lt;A,B&gt;"/> 对象实例
        /// </summary>
        /// <returns> <see cref="IEntityCaster&lt;A,B&gt;"/>接口实例</returns>
        IEntityCaster<A, B> Build();
    }
}
