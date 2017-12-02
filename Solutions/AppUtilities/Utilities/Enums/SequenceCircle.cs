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
using WitsWay.Utilities.Attributes;

namespace WitsWay.Utilities.Enums
{
    /// <summary>
    /// 系统序列类型
    /// </summary>
    [Serializable]
    [DataContract]
    [EnumField("系统序列周期")]
    public enum SequenceCircle
    {
        /// <summary>
        /// 递增序列
        /// </summary>
        [EnumMember] [EnumField("递增序列")] Increase = 1,
        /// <summary>
        /// 以天为周期
        /// </summary>
        [EnumMember] [EnumField("以天为周期")] Day = 2

    }
}