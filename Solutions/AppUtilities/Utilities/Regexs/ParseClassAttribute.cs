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

namespace WitsWay.Utilities.Regexs
{
    /// <summary>
    /// 用于标示该类是解析类
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class ParseClassAttribute : Attribute
    {
        /// <summary>
        /// 正则匹配字符串
        /// </summary>
        public string RegexString { get; }

        /// <summary>
        /// 够造函数
        /// </summary>
        /// <param name="pattern">正则字符串</param>
        public ParseClassAttribute(string pattern)
        {
            RegexString = pattern;
        }

    }
}
