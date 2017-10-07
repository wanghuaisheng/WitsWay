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
using System.Reflection;
using System.Text;

namespace WitsWay.Utilities.Extends
{
    /// <summary>
    /// 方法扩展
    /// </summary>
    public static class MethodExtends
    {
        /// <summary>
        /// 取得自定义特性
        /// </summary>
        /// <typeparam name="T">自定义Attribute类型</typeparam>
        /// <param name="method">方法信息</param>
        /// <returns>T实例</returns>
        public static T GetAttribute<T>(this MethodInfo method)
        {
            var attributes = method.GetCustomAttributes(true);
            foreach (var att in attributes)
            {
                if (att is T)
                    return (T)att;
            }
            return default(T);
        }
        /// <summary>
        /// 枚举类型根据名称字典获取中文名称串的扩展方法
        /// </summary>
        /// <param name="en"></param>
        /// <param name="dict">该枚举类型的中文名称字典</param>
        /// <returns>转换后的中文名称串，如果缺少中文定义将抛异常</returns>
        public static string GetCnNames(this Enum en, Dictionary<Enum, string> dict)
        {
            var namestring = en.ToString();
            var enNames = namestring.Split(',');
            var sb = new StringBuilder();
            for (var i = 0; i < enNames.Length; i++)
            {
                var cnName = dict[(Enum)Enum.Parse(en.GetType(), enNames[i])];
                if (string.IsNullOrEmpty(cnName))
                {
                    throw new Exception($"缺少枚举{enNames[i]}的中文名称定义");
                }
                sb.Append(cnName);
                if (i < enNames.Length - 1)
                    sb.Append(",");
            }
            return sb.ToString();
        }
    }
}
