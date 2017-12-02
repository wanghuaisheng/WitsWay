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
using WitsWay.Utilities.Supports;

namespace WitsWay.Utilities.Models
{
    /// <summary>
    /// 登录返回实体
    /// </summary>
    [Serializable]
    public class LoginResult : IKey
    {
        /// <summary>
        /// 会话键
        /// </summary>
        public string SessionKey { get; set; }
        /// <summary>
        /// 企业Id
        /// </summary>
        public int CorpId { get; set; }
        /// <summary>
        /// 公司类型
        /// </summary>
        public int CorpKind { get; set; }
        /// <summary>
        /// 企业编码
        /// </summary>
        public string CorpCode { get; set; }
        /// <summary>
        /// 企业名称
        /// </summary>
        public string CorpName { get; set; }
        /// <summary>
        /// 企业简称
        /// </summary>
        public string CorpShortName { get; set; }
        /// <summary>
        /// 员工Id
        /// </summary>
        public int EmployeeId { get; set; }
        /// <summary>
        /// 员工名称
        /// </summary>
        public string EmployeeName { get; set; }
        /// <summary>
        /// 员工工号
        /// </summary>
        public string EmployeeWorkNumber { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// 用户昵称
        /// </summary>
        public string Nickname { get; set; }
        /// <summary>
        /// 登录时间
        /// </summary>
        public DateTime LoginTime { get; set; }
        /// <summary>
        /// 续约间隔
        /// </summary>
        public int RenewalInterval { get; set; }
        /// <summary>
        /// 签名公钥
        /// </summary>
        public string SignPublicKey { get; set; }
        /// <summary>
        /// 续约时间
        /// </summary>
        public DateTime RenewalTime { get; set; }

        #region [IKey]

        /// <summary>
        /// 键
        /// </summary>
        public string Key => SessionKey;

        #endregion

    }
}