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
    /// 正则匹配类信息
    /// <remarks>
    /// 用于存储使用了ParseClassAttribute的类的信息
    /// </remarks>
    /// </summary>
    public class RegexClassInfo
    {

        #region [Property]

        /// <summary>
        /// 协议解析特性
        /// </summary>
        public ParseClassAttribute CustomClassInfo { get; set; }

        private IDictionary<string, ParsePropertyAttribute> _parsePropertyMap;
        /// <summary>
        /// 要解析的所有属性字典
        /// key:属性的名称
        /// value:属性的自定义特性ParsePropertyAttribute
        /// </summary>
        public IDictionary<string, ParsePropertyAttribute> PropertyMap => 
            _parsePropertyMap ?? (_parsePropertyMap = new Dictionary<string, ParsePropertyAttribute>());

        /// <summary>
        /// 给System.Text.RegularExpressions.Regex取别名
        /// </summary>
        public MSRegex.Regex RegexInfo { get; private set; }

        /// <summary>
        /// 正则匹配字符串
        /// </summary>
        public string RegexPattern { get; set; }

        #endregion

        #region [Public Method]
        /// <summary>
        /// 判断是否时协议解析类
        /// [是否有特性头][需要解析的属性大于零]
        /// </summary>
        /// <returns></returns>
        public bool Available()
        {
            if (CustomClassInfo == null || PropertyMap == null) return false;
            return PropertyMap.Count > 0;
        }

        /// <summary>
        /// 创建MS正则Regex类
        /// </summary>
        /// <param name="pattern">正则匹配字符串</param>
        public void CreateRegex(string pattern)
        {
            var option =
                MSRegex.RegexOptions.IgnoreCase |
                MSRegex.RegexOptions.Multiline |
                MSRegex.RegexOptions.IgnorePatternWhitespace |
                MSRegex.RegexOptions.Compiled;
            RegexInfo = new MSRegex.Regex(pattern, option);
            RegexPattern = pattern;
        }
        #endregion

        #region [Internal Method]


        /// <summary>
        /// 设置匹配值
        /// </summary>
        /// <param name="processStr">要处理的字符串</param>
        /// <param name="setObject">要设置值的对象</param>
        /// <param name="deleteMatchString">是否删除匹配的字符</param>
        /// <returns></returns>
        internal bool SetPropertyValue(ref string processStr, object setObject, bool deleteMatchString)
        {
            var match = Match(processStr);
            if (!match.Success) return false;
            for (var i = 0; i < match.Groups.Count; i++)
            {
                var name = RegexInfo.GroupNameFromNumber(i);
                if (SetValue(setObject, name, match.Groups[i]) == false)
                {
                    return false;
                }
            }
            if (deleteMatchString)
            {
                processStr = processStr.Remove(match.Index, match.Length);
            }
            return true;
        }

        /// <summary>
        /// 匹配
        /// </summary>
        /// <param name="processStr">要匹配的字符串</param>
        /// <returns></returns>
        internal MSRegex.Match Match(string processStr)
        {
            return RegexInfo.Match(processStr);
        }
        /// <summary>
        /// 匹配并设置值
        /// </summary>
        /// <param name="matchObject">要匹配的对象</param>
        /// <param name="name">属性名称</param>
        /// <param name="group"></param>
        /// <returns></returns>
        internal bool SetValue(object matchObject, string name, MSRegex.Group group)
        {
            ParsePropertyAttribute propertyAttribute;
            if (PropertyMap.TryGetValue(name, out propertyAttribute) != true) return true;
            return propertyAttribute.SetPropertyValue(matchObject, @group);
        }
        #endregion
    }
}
