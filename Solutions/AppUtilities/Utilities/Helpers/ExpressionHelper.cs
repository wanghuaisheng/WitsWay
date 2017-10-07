#region License(Apache Version 2.0)
/******************************************
 * Copyright ®2017-Now WangHuaiSheng.
 * Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file
 * except in compliance with the License. You may obtain a copy of the License at
 * http://www.apache.org/licenses/LICENSE-2.0
 * Unless required by applicable law or agreed to in writing, software distributed under the
 * License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
 * either express or implied. See the License for the specific language governing permissions
 * and limitations under the License.
 * Detail: https://github.com/WangHuaiSheng/WitsWay/LICENSE
 * ***************************************/
#endregion 
#region ChangeLog
/******************************************
 * 2017-10-7 OutMan Create
 * 
 * ***************************************/
#endregion
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
