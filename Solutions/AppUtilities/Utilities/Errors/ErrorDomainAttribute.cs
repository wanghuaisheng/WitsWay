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

namespace WitsWay.Utilities.Errors
{
    /// <summary>
    /// 错误域 特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Enum)]
    public class ErrorDomainAttribute : Attribute
    {

        /// <summary>
        /// 描述枚举值
        /// </summary>
        public ErrorDomainAttribute(ErrorDomains domain)
        {
            Domain = domain;
        }

        /// <summary>
        /// 错误域
        /// </summary>
        public ErrorDomains Domain { get; }
        /// <summary>
        /// 错误域名称
        /// </summary>
        public string DomainText => Domain.GetErrorText();

        /// <summary>
        ///  重写ToString
        /// </summary>
        /// <returns>EnumDisplayText</returns>
        public override string ToString()
        {
            return DomainText;
        }

    }
}