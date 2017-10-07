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
