﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.Practices.Unity.Utility;
using WitsWay.Utilities.Entitys;
using WitsWay.Utilities.Guards;
using WitsWay.Utilities.Helpers;

namespace WitsWay.Utilities.EntityCast
{

    /// <summary>
    /// <see cref="IEntityCaster{A,B}"/>的实现,通过反射转换A为B
    /// 通过 <see cref="CasterBuilder{A,B}"/> API创建实例.
    /// </summary>
    /// <typeparam name="A">原类型</typeparam>
    /// <typeparam name="B">新类型</typeparam>
    /// <seealso cref="CasterBuilder{A,B}"/>
    public class ReflectionCaster<A, B> : IEntityCaster<A, B>
        where A : new()
        where B : new()
    {

        private readonly Func<A, B> _mapping;

        /// <summary>
        /// 创建<see cref="ReflectionCaster{A,B}"/>实例
        /// </summary>
        /// <param name="propertyMappings">字典</param>
        public ReflectionCaster(IDictionary<PropertyInfo, PropertyMapping<A>> propertyMappings)
        {
            ArgumentGuard.ArgumentNotNull("propertyMappings", propertyMappings);
            try
            {
                var parameter = Expression.Parameter(typeof(A), "a");
                var convertMethodInfo =
                    StaticReflection.GetMethodInfo<PropertyMapping<A>>(pm => pm.GetPropertyValue(default(A)));
                var bindings =
                    propertyMappings.Select(kvp => (MemberBinding)
                        Expression.Bind(kvp.Key,
                            Expression.Convert(
                                Expression.Call(Expression.Constant(kvp.Value), convertMethodInfo, parameter),
                                kvp.Key.PropertyType)));
                var creationExpression = Expression.New(typeof(B));
                var expr = Expression.Lambda<Func<A, B>>(
                        Expression.MemberInit(creationExpression, bindings), parameter);

                _mapping = expr.Compile();
            }
            catch (Exception e)
            {
                throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture,"创键PropertyMapping失败。"),e);
            }
        }


        /// <summary>
        /// 映射A为B
        /// </summary>
        /// <param name="a">原对象</param>
        /// <returns>新队形</returns>
        public B CastEntity(A a)
        {
            return ExceptionHelper.HandleException(() => _mapping(a), "实体转换错误，请检查属性映射。");
        }

        /// <summary>
        /// 映射A列表 为 B列表
        /// </summary>
        /// <param name="aList">A列表</param>
        /// <returns>B列表</returns>
        public List<B> CastList(IList<A> aList)
        {
            if (aList == null) { return null; }
            if (aList.Count == 0) { return new List<B>(); }
            return aList.Select(CastEntity).ToList();
        }

        /// <summary>
        /// 映射分页结果集
        /// </summary>
        /// <param name="aPage">A分页结果集</param>
        /// <returns>B分页结果集</returns>
        public PageResult<B> CastPage(PageResult<A> aPage)
        {
            var result = new PageResult<B>
            {
                PageIndex = aPage.PageIndex,
                PageSize = aPage.PageSize,
                TotalRecordNum = aPage.TotalRecordNum
            };
            result.Rows.AddRange(CastList(aPage.Rows));
            return result;
        }

    }

}
