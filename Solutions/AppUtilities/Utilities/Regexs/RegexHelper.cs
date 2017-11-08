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
using System.Collections.Generic;
using MSRegex = System.Text.RegularExpressions;

namespace WitsWay.Utilities.Regexs
{
    /// <summary>
    /// 为协议解析提供正则匹配的入口
    /// 完成匹配字符串并生成对象
    /// </summary>
    public class RegexHelper
    {
        /// <summary>
        /// 泛型匹配
        /// </summary>
        public static T Match<T>(ref string processStr, bool delMatchStr) where T : new() 
        {
            var matchObject = new T();
            return Match(matchObject, ref processStr, delMatchStr) ? matchObject : default(T);
        }

        /// <summary>
        /// 匹配指定的类
        /// </summary>
        /// <param name="matchObject">匹配后生成的结果对象</param>
        /// <param name="processStr"></param>
        /// <param name="delMatchStr"></param>
        /// <returns></returns>
        public static bool Match(object matchObject,ref string processStr,bool delMatchStr)
        {
            var  info = RegexClassFactory.GetRegexClass(matchObject);
            return info != null && info.SetPropertyValue(ref processStr,matchObject,delMatchStr);
        }

        /// <summary>
        /// 匹配多个对象
        /// </summary>
        /// <typeparam name="T">匹配类型</typeparam>
        /// <param name="processStr">处理字符串</param>
        /// <param name="delMatchStr">是否删除已经匹配的字符串</param>
        /// <returns>返回匹配的对象列表</returns>
        public static IList<T> MatchList<T>(ref string processStr, bool delMatchStr) where T : new()
        {
            var temValue = processStr;
            IList<T> resultList = new List<T>();
            T v;
            do
            {
                v = Match<T>(ref temValue, true);
                if (v != null)
                {
                    resultList.Add(v);
                }
            }
            while (v != null);
            if (delMatchStr)
            {
                processStr = temValue;
            }
            return resultList;
        }

        /// <summary>
        /// 获取正则表达式
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static MSRegex.Regex GetClassRegex<T>() where T : new()
        {
            var matchObject = new T();
            var info = RegexClassFactory.GetRegexClass(matchObject);
            return info?.RegexInfo;
        }

    }
}
