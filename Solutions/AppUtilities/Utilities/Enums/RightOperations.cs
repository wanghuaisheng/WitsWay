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
    /// 权限操作
    /// </summary>
    [Flags]
    [DataContract]
    [Serializable]
    [EnumField("权限操作")]
    public enum RightOperations
    {
        /// <summary>
        /// 查看
        /// </summary>
        [EnumField("查看")] [EnumMember] View = 1,
        /// <summary>
        /// 添加
        /// </summary>
        [EnumField("添加")] [EnumMember] Add = 1 << 1,
        /// <summary>
        /// 修改
        /// </summary>
        [EnumField("修改")] [EnumMember] Edit = 1 << 2,
        /// <summary>
        /// 删除
        /// </summary>
        [EnumField("删除")] [EnumMember] Delete = 1 << 3,
        /// <summary>
        /// 移除
        /// </summary>
        [EnumField("移除")] [EnumMember] Remove = 1 << 4,
        /// <summary>
        /// 上移
        /// </summary>
        [EnumField("上移")] [EnumMember] Up = 1 << 5,
        /// <summary>
        /// 下移
        /// </summary>
        [EnumField("下移")] [EnumMember] Down = 1 << 6,
        /// <summary>
        /// 添加
        /// </summary>
        [EnumField("添加组")] [EnumMember] AddGroup = 1 << 7,
        /// <summary>
        /// 修改
        /// </summary>
        [EnumField("修改组")] [EnumMember] EditGroup = 1 << 8,
        /// <summary>
        /// 删除
        /// </summary>
        [EnumField("删除组")] [EnumMember] DeleteGroup = 1 << 9,
        /// <summary>
        /// 移除
        /// </summary>
        [EnumField("移除组")] [EnumMember] RemoveGroup = 1 << 10,
        /// <summary>
        /// 上移
        /// </summary>
        [EnumField("上移组")] [EnumMember] UpGroup = 1 << 11,
        /// <summary>
        /// 下移
        /// </summary>
        [EnumField("下移组")] [EnumMember] DownGroup = 1 << 12,
    }
}
