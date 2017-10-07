using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WitsWay.TempTests.DynamicQuery.Entities;
using WitsWay.TempTests.DynamicQuery.Helpers;

namespace WitsWay.TempTests.DynamicQuery.Builders
{

    /// <summary>
    /// 通用<see cref="IQueryable"/> 查询构建器，基于FilterRules实现数据源筛选，应用于高级过滤场景
    /// </summary>
    public static class QueryBuilder
    {
        /// <summary>
        /// 日期Parse是否转换为UTC
        /// </summary>
        public static bool ParseDatesAsUtc { get; set; }

        /// <summary>
        /// 获取应用过滤规则后的<see cref="IQueryable"/>集合
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="queryable"><see cref="IEnumerable{T}"/>数据集合</param>
        /// <param name="filterRule">筛选规则</param>
        /// <param name="useIndexedProperty">是否使用索引属性</param>
        /// <param name="indexedPropertyName">索引属性名</param>
        /// <returns>过滤后的<see cref="IQueryable"/> 集合</returns>
        public static IQueryable<T> BuildQuery<T>(this IEnumerable<T> queryable, FilterRule filterRule, bool useIndexedProperty = false, string indexedPropertyName = null)
        {
            string parsedQuery;
            return BuildQuery(queryable.AsQueryable(), filterRule, out parsedQuery, useIndexedProperty, indexedPropertyName);
        }

        /// <summary>
        /// 获取应用过滤规则后的<see cref="IQueryable"/>集合
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="queryable"><see cref="IList{T}"/>数据集合</param>
        /// <param name="filterRule">筛选规则</param>
        /// <param name="useIndexedProperty">是否使用索引属性</param>
        /// <param name="indexedPropertyName">索引属性名</param>
        /// <returns>过滤后的<see cref="IQueryable"/> 集合</returns>
        public static IQueryable<T> BuildQuery<T>(this IList<T> queryable, FilterRule filterRule, bool useIndexedProperty = false, string indexedPropertyName = null)
        {
            string parsedQuery;
            return BuildQuery(queryable.AsQueryable(), filterRule, out parsedQuery, useIndexedProperty, indexedPropertyName);
        }

        /// <summary>
        /// 获取应用过滤规则后的<see cref="IQueryable"/>集合
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="queryable"><see cref="IQueryable"/>数据集合</param>
        /// <param name="filterRule">筛选规则</param>
        /// <param name="useIndexedProperty">是否使用索引属性</param>
        /// <param name="indexedPropertyName">索引属性名</param>
        /// <returns>过滤后的<see cref="IQueryable"/> 集合</returns>
        public static IQueryable<T> BuildQuery<T>(this IQueryable<T> queryable, FilterRule filterRule, bool useIndexedProperty = false, string indexedPropertyName = null)
        {
            string parsedQuery;
            return BuildQuery(queryable, filterRule, out parsedQuery, useIndexedProperty, indexedPropertyName);
        }

        /// <summary>
        /// 获取应用过滤规则后的<see cref="IQueryable"/>集合
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="queryable"><see cref="IQueryable"/>数据集合</param>
        /// <param name="filterRule">筛选规则</param>
        /// <param name="parsedQuery">查询字符串表达</param>
        /// <param name="useIndexedProperty">是否使用索引属性</param>
        /// <param name="indexedPropertyName">索引属性名</param>
        /// <returns>过滤后的<see cref="IQueryable"/> 集合</returns>
        public static IQueryable<T> BuildQuery<T>(this IQueryable<T> queryable, FilterRule filterRule, out string parsedQuery, bool useIndexedProperty = false, string indexedPropertyName = null)
        {
            if (filterRule == null)
            {
                parsedQuery = "";
                return queryable;
            }

            var pe = Expression.Parameter(typeof(T), "item");

            var expressionTree = BuildExpressionTree(pe, filterRule, useIndexedProperty, indexedPropertyName);
            if (expressionTree == null)
            {
                parsedQuery = "";
                return queryable;
            }

            parsedQuery = expressionTree.ToString();
            //内存筛选
            var whereCallExpression = Expression.Call(
                typeof(Queryable),
                "Where",
                new[] { queryable.ElementType },
                queryable.Expression,
                Expression.Lambda<Func<T, bool>>(expressionTree, pe));

            var filteredResults = queryable.Provider.CreateQuery<T>(whereCallExpression);

            return filteredResults;

        }

        /// <summary>
        /// 创建表达式树
        /// </summary>
        /// <param name="pe">参数表达式</param>
        /// <param name="rule">过滤规则</param>
        /// <param name="useIndexedProperty"></param>
        /// <param name="indexedPropertyName"></param>
        /// <returns>表达式树</returns>
        private static Expression BuildExpressionTree(ParameterExpression pe, FilterRule rule, bool useIndexedProperty = false, string indexedPropertyName = null)
        {
            if (useIndexedProperty && string.IsNullOrWhiteSpace(indexedPropertyName))
            {
                throw new ArgumentNullException("indexedPropertyName", "useIndexedProperty为true时，indexedPropertyName必须提供。");
            }
            //递归
            if (rule.Rules != null && rule.Rules.Any())
            {
                var expressions = rule.Rules.Select(childRule => BuildExpressionTree(pe, childRule, useIndexedProperty, indexedPropertyName)).Where(exp => exp != null).ToList();
                var expressionTree = expressions.First();
                var counter = 1;
                while (counter < expressions.Count)
                {
                    expressionTree = rule.Condition.ToLower() == "or"
                        ? Expression.Or(expressionTree, expressions[counter])
                        : Expression.And(expressionTree, expressions[counter]);
                    counter++;
                }
                return expressionTree;
            }
            //检查当前Rule
            if (string.IsNullOrWhiteSpace(rule.Field)) return null;
            //处理当前Rule
            Expression propertyExp;
            if (useIndexedProperty)
            {
                //创建索引访问表达式
                propertyExp = Expression.Property(pe, indexedPropertyName, Expression.Constant(rule.Field));
            }
            else
            {
                //创建属性访问表达式
                propertyExp = Expression.Property(pe, rule.Field);
            }
            var type = FilterRuleHelper.GetRuleDataType(rule);
            var expression = FilterRuleHelper.GetRelationExpression(rule, type, propertyExp);
            return expression;
        }

    }
}
