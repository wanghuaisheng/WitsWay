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

namespace WitsWay.Utilities.Extends
{
    /// <summary>
    /// Type扩展
    /// </summary>
    public static class TypeExtends
    {
        /// <summary>
        /// 取得type的T特性实例
        /// </summary>
        /// <typeparam name="T">特性类型</typeparam>
        /// <param name="type">Type实例</param>
        /// <returns>T实例</returns>
        public static T GetAttribute<T>(this Type type)
        {
            var attributes = type.GetCustomAttributes(true);
            foreach (var att in attributes)
            {
                if (att is T)
                {
                    return (T)att;
                }
            }
            return default(T);
        }

        /// <summary>
        /// 取得Type实例对象
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object GetInstance(this Type type)
        {
            return type.Assembly.CreateInstance(type.FullName);
        }


        #region [Numeric]

        /// <summary>
        /// 判断是否为数值类型。
        /// </summary>
        /// <param name="t">要判断的类型</param>
        /// <returns>是否为数值类型</returns>
        public static bool IsNumericType(this Type t)
        {
            var tc = Type.GetTypeCode(t);
            return (t.IsPrimitive && t.IsValueType && !t.IsEnum && tc != TypeCode.Char && tc != TypeCode.Boolean) || tc == TypeCode.Decimal;
        }

        /// <summary>
        /// 判断是否为可空数值类型。
        /// </summary>
        /// <param name="t">要判断的类型</param>
        /// <returns>是否为可空数值类型</returns>
        public static bool IsNumericOrNullableNumericType(this Type t)
        {
            return t.IsNumericType() || (t.IsNullableType() && Nullable.GetUnderlyingType(t).IsNumericType());
        }

        /// <summary>
        /// 判断是否为可空类型。
        /// 注意，直接调用可空对象的.GetType()方法返回的会是其泛型值的实际类型，用其进行此判断肯定返回false。
        /// </summary>
        /// <param name="t">要判断的类型</param>
        /// <returns>是否为可空类型</returns>
        public static bool IsNullableType(this Type t)
        {
            return t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>);
        }

        #endregion

    }
}
