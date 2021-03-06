﻿#region License(Apache Version 2.0)
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
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace WitsWay.Utilities.Errors
{
    /// <summary>
    /// 把枚举值按照指定的文本显示
    /// <example>
    /// EnumField.GetEnumText(typeof(MyEnum));
    /// EnumField.GetFieldText(MyEnum.EnumField);
    /// EnumField.GetFieldInfos(typeof(MyEnum));  
    /// </example>
    /// </summary>
    public partial class ErrorItemAttribute
    {

        private static readonly ReaderWriterLockSlim Locker = new ReaderWriterLockSlim(LockRecursionPolicy.NoRecursion);
        private static readonly ConcurrentDictionary<string, List<ErrorItemAttribute>> CachedEnum = new ConcurrentDictionary<string, List<ErrorItemAttribute>>();

        /// <summary>
        /// 得到对枚举的描述文本
        /// </summary>
        /// <param name="enumType">枚举类型</param>
        /// <returns></returns>
        public static string GetEnumText(Type enumType)
        {
            var eds = (ErrorItemAttribute[])enumType.GetCustomAttributes(typeof(ErrorItemAttribute), false);
            if (eds.Length != 1) return string.Empty;
            return eds[0].ErrorText;
        }

        /// <summary>
        /// 获得指定枚举类型中，指定值的描述文本。
        /// </summary>
        /// <param name="enumValue">枚举值，不要作任何类型转换</param>
        /// <returns>描述字符串</returns>
        public static string GetFieldText(object enumValue)
        {
            var fi = GetFieldInfo(enumValue);
            return fi == null ? string.Empty : fi.ErrorText;
        }


        /// <summary>
        /// 获得指定枚举类型中，指定值的描述文本。
        /// </summary>
        /// <param name="enumValue">枚举值，不要作任何类型转换</param>
        /// <returns>描述字符串</returns>
        public static ErrorItemAttribute GetFieldInfo(object enumValue)
        {
            var descriptions = GetFieldInfos(enumValue.GetType());
            return descriptions.FirstOrDefault(ed => ed.FieldName == enumValue.ToString());
        }

        /// <summary>
        /// 得到枚举类型定义的所有文本
        /// </summary>
        /// <exception cref="NotSupportedException"></exception>
        /// <param name="enumType">枚举类型</param>
        public static List<ErrorItemAttribute> GetFieldInfos(Type enumType)
        {
            List<ErrorItemAttribute> descriptions;
            try
            {
                if (!CachedEnum.ContainsKey(enumType.FullName))
                {
                    Locker.EnterWriteLock();
                    if (!CachedEnum.ContainsKey(enumType.FullName))
                    {
                        descriptions = new List<ErrorItemAttribute>();
                        var fields = enumType.GetFields();
                        foreach (var fi in fields)
                        {
                            var attrs = fi.GetCustomAttributes(typeof(ErrorItemAttribute), false);
                            if (attrs.Length <= 0) continue;
                            var ed = (ErrorItemAttribute)attrs[0];
                            ed.ErrorValue = (int)fi.GetValue(null);
                            ed.FieldName = fi.Name;
                            descriptions.Add(ed);
                        }
                        CachedEnum[enumType.FullName] = descriptions;
                    }
                    Locker.ExitWriteLock();
                }
            }
            finally
            {
                if (Locker.IsWriteLockHeld)
                {
                    Locker.ExitWriteLock();
                }
            }
            descriptions = CachedEnum[enumType.FullName];
            if (descriptions.Count <= 0)
            {
                throw new NotSupportedException($"枚举类型{enumType.Name}未定义属性EnumValueDescription");
            }
            return descriptions;
        }

    }
}