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
using System.Collections.Generic;
using System.Reflection;

namespace WitsWay.Utilities.Regexs
{
    /// <summary>
    /// 生成正则类的工厂
    /// <remarks>
    /// 通过传入的Type生成正则类
    /// </remarks>
    /// </summary>
    public static class RegexClassFactory
    {
        /// <summary>
        /// 用于存放已经匹配过的正则类
        /// </summary>
        private static readonly Dictionary<Type, RegexClassInfo> TypeDic = new Dictionary<Type, RegexClassInfo>();
        /// <summary>
        /// 取得正则类
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static RegexClassInfo GetRegexClass(object obj)
        {
            return obj == null ? null : GetRegexClass(obj.GetType());
        }

        /// <summary>
        /// 取得正则类
        /// </summary>
        /// <param name="type">类型Type</param>
        /// <returns></returns>
        public static RegexClassInfo GetRegexClass(Type type)
        {
            RegexClassInfo info;
            if (TypeDic.TryGetValue(type, out info) == false)
            {
                //取得自定义特性ParseClassAttribute
                var attribs = type.GetCustomAttributes(typeof(ParseClassAttribute), true);
                if (attribs.Length <= 0) return null;
                info = CreateRegexClassInfo(type, attribs[0] as ParseClassAttribute);
                if (info != null)
                {
                    TypeDic[type] = info;
                }
            }
            else
            {
                info = TypeDic[type];
            }
            return info;
        }

        /// <summary>
        /// 创建RegexClassInfo类
        /// </summary>
        /// <param name="type">要创建正则类信息的Type</param>
        /// <param name="customAttribute">自定义特性ParseClassAttribute</param>
        /// <returns>正则类信息</returns>
        private static RegexClassInfo CreateRegexClassInfo(Type type, ParseClassAttribute customAttribute)
        {
            var result = new RegexClassInfo
            {
                CustomClassInfo = customAttribute
            };
            result.CreateRegex(customAttribute.RegexString);

            var properties = type.GetProperties(BindingFlags.Instance | BindingFlags.SetProperty | BindingFlags.Public);
            foreach (var property in properties)
            {
                var objs = property.GetCustomAttributes(typeof(ParsePropertyAttribute), true);
                if (objs.Length > 0)
                {
                    var atrrib = objs[0] as ParsePropertyAttribute;
                    if (atrrib != null)
                    {
                        atrrib.PropertyInfo = property;
                        result.PropertyMap[atrrib.RegexGroupName] = atrrib;
                    }
                }
            }
            return result.Available() ? result : null;
        }

    }
}
