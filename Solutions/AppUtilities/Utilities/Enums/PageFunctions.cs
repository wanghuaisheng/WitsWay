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
    /// 页面功能
    /// </summary>
    [Serializable]
    [DataContract]
    [EnumField("页面功能")]
    public enum PageFunctions
    {
        /// <summary>
        /// 查看
        /// </summary>
        [EnumMember] [EnumField("查看")] View = 1,
        /// <summary>
        /// 添加
        /// </summary>
        [EnumMember] [EnumField("添加")] Add = 2,
        /// <summary>
        /// 拷贝添加
        /// </summary>
        [EnumMember] [EnumField("添加")] CopyAdd = 4,
        /// <summary>
        /// 修改
        /// </summary>
        [EnumMember] [EnumField("修改")] Edit = 8,
        /// <summary>
        /// 审核
        /// </summary>
        [EnumMember] [EnumField("审核")] Audit = 16
    }
}
