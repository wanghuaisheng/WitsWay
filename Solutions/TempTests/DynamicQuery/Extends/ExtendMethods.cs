using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace WitsWay.TempTests.DynamicQuery.Extends
{
    /// <summary>
    /// 扩展
    /// </summary>
    public static class ExtendMethods
    {

        /// <summary>
        /// 判断类型是否泛型列表
        /// </summary>
        /// <param name="oType">对象类型</param>
        /// <returns>是true，不是false</returns>
        public static bool IsGenericList(this Type oType)
        {
            return oType.IsGenericType && oType.GetGenericTypeDefinition() == typeof(List<>);
        }

        /// <summary>
        /// 获取默认值
        /// </summary>
        /// <param name="type">类型</param>
        /// <returns>类型默认值</returns>
        public static object GetDefaultValue(this Type type)
        {
            return type.IsValueType ? Activator.CreateInstance(type) : null;
        }

        /// <summary>
        /// 单个实体转换为List
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="entity">实体</param>
        /// <returns>实体列表</returns>
        public static List<T> ListWrapper<T>(this T entity)
        {
            return new List<T> { entity };
        }

        /// <summary>
        /// 转换为骆驼拼写法
        /// </summary>
        /// <param name="input">要转换的字符串</param>
        /// <returns>转换后的字符串</returns>
        public static string ToCamelCase(this string input)
        {
            var s = input;
            if (!char.IsUpper(s[0])) return s;

            var cArr = s.ToCharArray();
            for (var i = 0; i < cArr.Length; i++)
            {
                if (i > 0 && i + 1 < cArr.Length && !char.IsUpper(cArr[i + 1])) break;
                cArr[i] = char.ToLowerInvariant(cArr[i]);
            }
            return new string(cArr);
        }

        /// <summary>
        /// 属性名分隔
        /// </summary>
        /// <param name="input">要转换的字符串</param>
        /// <returns>分隔后的字符串</returns>
        public static string ToSpacedString(this string input)
        {
            var r = new Regex(@"
                (?<=[A-Z])(?=[A-Z][a-z]) |
                 (?<=[^A-Z])(?=[A-Z]) |
                 (?<=[A-Za-z])(?=[^A-Za-z])", RegexOptions.IgnorePatternWhitespace);
            var res = r.Replace(input, " ");
            return res;
        }
    }
}
