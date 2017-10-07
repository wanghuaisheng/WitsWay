using System;
using System.Linq;
using System.Linq.Expressions;
using WitsWay.TempTests.DynamicQuery.Entities;
using WitsWay.TempTests.DynamicQuery.Helpers;

namespace WitsWay.TempTests.DynamicQuery.Builders
{

    /// <summary>
    /// Where语句构建器
    /// </summary>
    public static class ClauseBuilder
    {

        /// <summary>
        /// 构建Where语句
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="filterRule">筛选规则</param>
        /// <param name="useIndexedProperty">是否使用索引属性</param>
        /// <param name="indexedPropertyName">索引属性名</param>
        /// <returns>查询字符串表达</returns>
        public static string BuildClause<T>(FilterRule filterRule, bool useIndexedProperty = false, string indexedPropertyName = null)
        {
            if (filterRule == null) return string.Empty;
            var pe = Expression.Parameter(typeof(T), "item");
            var expressionTree = BuildExpressionTree(pe, filterRule, useIndexedProperty, indexedPropertyName);
            if (expressionTree == null) return string.Empty;
            var clause = expressionTree.ToString();
            return clause;
        }

        /// <summary>
        /// 创建表达式树
        /// </summary>
        /// <param name="pe">参数表达式</param>
        /// <param name="rule">过滤规则</param>
        /// <param name="useIndexedProperty">是否使用属性索引</param>
        /// <param name="indexedPropertyName">索引属性名</param>
        /// <returns>表达式树</returns>
        private static Expression BuildExpressionTree(ParameterExpression pe, FilterRule rule, bool useIndexedProperty = false, string indexedPropertyName = null)
        {
            if (useIndexedProperty && string.IsNullOrWhiteSpace(indexedPropertyName))
                throw new ArgumentNullException("indexedPropertyName", "useIndexedProperty为true时，indexedPropertyName必须提供。");
            //递归
            if (rule.Rules != null && rule.Rules.Any())
            {
                var expressions = rule.Rules.Select(childRule => BuildExpressionTree(pe, childRule, useIndexedProperty, indexedPropertyName)).Where(exp => exp != null).ToList();
                var expressionTree = expressions.First();
                var counter = 1;
                while (counter < expressions.Count)
                {
                    expressionTree = rule.Condition.ToLower() == "or" ? Expression.Or(expressionTree, expressions[counter]) : Expression.And(expressionTree, expressions[counter]);
                    counter++;
                }
                return expressionTree;
            }
            //检查当前Rule
            if (string.IsNullOrWhiteSpace(rule.Field)) return null;
            //处理当前Rule
            var propertyExp = useIndexedProperty
                ? (Expression) Expression.Property(pe, indexedPropertyName, Expression.Constant(rule.Field))
                : Expression.Property(pe, rule.Field);
            var type = FilterRuleHelper.GetRuleDataType(rule);
            var expression = FilterRuleHelper.GetRelationExpression(rule, type, propertyExp);
            return expression;
        }

    }
}
