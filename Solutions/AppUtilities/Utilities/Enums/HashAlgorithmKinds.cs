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
using System.Runtime.Serialization;

namespace WitsWay.Utilities.Enums
{
    /// <summary>
    /// Hash算法类型
    /// </summary>
    [Serializable]
    [DataContract]
    public enum HashAlgorithmKinds
    {
        ///// <summary>
        ///// KeyedHashAlgorithm
        ///// </summary>
        //KeyedHashAlgorithm,
        /// <summary>
        /// MD5
        /// </summary>
        [EnumMember] Md5,
        /// <summary>
        /// RIPEMD160
        /// </summary>
        [EnumMember] Ripemd160,
        /// <summary>
        /// SHA1
        /// </summary>
        [EnumMember] Sha160,
        /// <summary>
        /// SHA256
        /// </summary>
        [EnumMember] Sha256,
        /// <summary>
        /// SHA384
        /// </summary>
        [EnumMember] Sha384,
        /// <summary>
        /// SHA512
        /// </summary>
        [EnumMember] Sha512
    }
}