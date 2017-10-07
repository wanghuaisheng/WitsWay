/******************************************
 * 2012年5月3日 王怀生 添加
 * 
 * ***************************************/

using System;
using System.Collections.Generic;

namespace WitsWay.Utilities.Helpers
{
    /// <summary>
    /// 枚举辅助类
    /// </summary>
    public class EnumHelper
    {
        /// <summary>
        /// 取得枚举值列表
        /// </summary>
        public static List<int> GetEnumValueList<T>()
        {
            var arr = Enum.GetValues(typeof(T));
            var values = new List<int>();
            var eor = arr.GetEnumerator();
            while (eor.MoveNext())
            {
                values.Add((int)eor.Current);
            }
            return values;
        }

        /// <summary>
        /// 转换为枚举
        /// </summary>
        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }

        /// <summary>
        /// 转换为枚举
        /// </summary>
        public static T ParseEnum<T>(int value)
        {
            return ParseEnum<T>(value.ToString());
        }

    }
}
