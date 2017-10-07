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
using WitsWay.Utilities.Enums;

namespace WitsWay.Utilities.Models
{

    /// <summary>
    /// 登录操作人员
    /// </summary>
    [Serializable]
    public class LoginOperator
    {

        /// <summary>
        /// 企业ID
        /// </summary>
        public int CorpId { get; set; }

        /// <summary>
        /// 企业编码
        /// </summary>
        public string CorpCode { get; set; }

        /// <summary>
        /// 企业简称
        /// </summary>
        public string CorpShortName { get; set; }

        /// <summary>
        /// 企业名称
        /// </summary>
        public string CorpName { get; set; }

        /// <summary>
        /// 操作员ID
        /// </summary>
        public int OperatorId { get; set; }

        /// <summary>
        /// 操作员编码
        /// </summary>
        public string OperatorCode { get; set; }

        /// <summary>
        /// 操作员名称
        /// </summary>
        public string OperatorName { get; set; }

        /// <summary>
        /// 系统标识
        /// </summary>
        public SubSystems SystemIdentify { get; set; }

        /// <summary>
        /// 登陆IP
        /// </summary>
        public string LoginIP { get; set; }

        /// <summary>
        /// 工位机ID(工位机程序使用)
        /// </summary>
        public int ComputerId { get; set; }

        /// <summary>
        /// 机器物理地址(工位机程序使用)
        /// </summary>
        public string PhysicalAddress { get; set; }

        /// <summary>
        /// 授权令牌
        /// </summary>
        public string Tocken { get; set; }

    }
}