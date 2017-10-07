using System;
using System.Linq.Expressions;
using WitsWay.TempTests.DynamicQuery.Entities;
using WitsWay.TempTests.DynamicQuery.Enums;
using WitsWay.TempTests.DynamicQuery.Factorys;

namespace WitsWay.TempTests.DynamicQuery.Helpers
{

    /// <summary>
    /// 过滤规则辅助类
    /// </summary>
    public static class FilterRuleHelper
    {

        /// <summary>
        /// 获取关系表达式
        /// </summary>
        /// <param name="rule">过滤规则</param>
        /// <param name="type">规则数据类型</param>
        /// <param name="propertyExp">属性表达式</param>
        /// <returns>过滤规则关系表达式</returns>
        public static Expression GetRelationExpression(FilterRule rule, Type type, Expression propertyExp)
        {
            Expression expression;

            switch (rule.Operator.ToLower())
            {
                case "in":
                    expression = ExpressionFactory.GetExpression(SupportRelations.In, propertyExp, type, rule.Value);
                    break;
                case "not_in":
                    expression = ExpressionFactory.GetExpression(SupportRelations.NotIn, propertyExp, type, rule.Value);
                    break;
                case "equals":
                    expression = ExpressionFactory.GetExpression(SupportRelations.Equals, propertyExp, type, rule.Value);
                    break;
                case "not_equals":
                    expression = ExpressionFactory.GetExpression(SupportRelations.NotEquals, propertyExp, type, rule.Value);
                    break;
                case "between":
                    expression = ExpressionFactory.GetExpression(SupportRelations.Between, propertyExp, type, rule.Value);
                    break;
                case "not_between":
                    expression = ExpressionFactory.GetExpression(SupportRelations.NotBetween, propertyExp, type, rule.Value);
                    break;
                case "less_than":
                    expression = ExpressionFactory.GetExpression(SupportRelations.LessThan, propertyExp, type, rule.Value);
                    break;
                case "less_than_or_equal":
                    expression = ExpressionFactory.GetExpression(SupportRelations.LessThanOrEqual, propertyExp, type, rule.Value);
                    break;
                case "greater_than":
                    expression = ExpressionFactory.GetExpression(SupportRelations.GreaterThan, propertyExp, type, rule.Value);
                    break;
                case "greater_than_or_equal":
                    expression = ExpressionFactory.GetExpression(SupportRelations.GreaterThanOrEqual, propertyExp, type, rule.Value);
                    break;
                case "starts_with":
                    expression = ExpressionFactory.GetExpression(SupportRelations.StartsWith, propertyExp, type, rule.Value);
                    break;
                case "not_starts_with":
                    expression = ExpressionFactory.GetExpression(SupportRelations.NotStartsWith, propertyExp, type, rule.Value);
                    break;
                case "contains":
                    expression = ExpressionFactory.GetExpression(SupportRelations.Contains, propertyExp, type, rule.Value);
                    break;
                case "not_contains":
                    expression = ExpressionFactory.GetExpression(SupportRelations.NotContains, propertyExp, type, rule.Value);
                    break;
                case "ends_with":
                    expression = ExpressionFactory.GetExpression(SupportRelations.EndsWith, propertyExp, type, rule.Value);
                    break;
                case "not_ends_with":
                    expression = ExpressionFactory.GetExpression(SupportRelations.NotEndsWith, propertyExp, type, rule.Value);
                    break;
                case "is_empty":
                    expression = ExpressionFactory.GetExpression(SupportRelations.IsEmpty, propertyExp);
                    break;
                case "is_not_empty":
                    expression = ExpressionFactory.GetExpression(SupportRelations.IsNotEmpty, propertyExp);
                    break;
                case "is_null":
                    expression = ExpressionFactory.GetExpression(SupportRelations.IsNull, propertyExp);
                    break;
                case "is_not_null":
                    expression = ExpressionFactory.GetExpression(SupportRelations.IsNotNull, propertyExp);
                    break;
                default:
                    throw new Exception(string.Format("当前不支持操作: {0} ", rule.Operator));
            }
            return expression;
        }

        /// <summary>
        /// 获取规则数据类型
        /// </summary>
        /// <param name="rule">过滤规则</param>
        /// <returns>规则数据类型</returns>
        public static Type GetRuleDataType(FilterRule rule)
        {
            Type type;
            switch (rule.Type)
            {
                case "int":
                    type = typeof(int);
                    break;
                case "double":
                    type = typeof(double);
                    break;
                case "string":
                    type = typeof(string);
                    break;
                case "date":
                case "datetime":
                    type = typeof(DateTime);
                    break;
                case "bool":
                    type = typeof(bool);
                    break;
                default:
                    throw new Exception(string.Format("未知数据类型 {0} ，当前支持int、double、string、date、datetime、bool", rule.Type));
            }
            return type;
        }

    }
}
