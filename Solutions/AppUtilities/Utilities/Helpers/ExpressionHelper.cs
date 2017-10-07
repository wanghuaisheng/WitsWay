using System;
using System.Linq.Expressions;

namespace WitsWay.Utilities.Helpers
{
    /// <summary>
    /// 表达式辅助类
    /// </summary>
    public class ExpressionHelper
    {
        /// <summary>
        /// 获取属性名称
        /// </summary>
        public static string GetPropertyName<T>(Expression<Func<T, object>> expr)
        {
            var memberExpression = expr.Body as MemberExpression;
            if (memberExpression != null)
            {
                return memberExpression.Member.Name;
            }
            var expression = expr.Body as UnaryExpression;
            if (expression != null)
            {
                return ((MemberExpression)expression.Operand).Member.Name;
            }
            var parameterExpression = expr.Body as ParameterExpression;
            if (parameterExpression != null)
            {
                return parameterExpression.Type.Name;
            }
            return string.Empty;
        }
    }
}
