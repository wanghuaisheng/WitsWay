/******************************************
 * 2012年7月18日 王怀生 添加
 * 
 * ***************************************/

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
    [EnumFieldAttribute("权限操作")]
    public enum RightOperations
    {
        /// <summary>
        /// 查看
        /// </summary>
        [EnumFieldAttribute("查看")]
        [EnumMember]
        View = 1,
        /// <summary>
        /// 添加
        /// </summary>
        [EnumFieldAttribute("添加")]
        [EnumMember]
        Add = 1 << 1,
        /// <summary>
        /// 修改
        /// </summary>
        [EnumFieldAttribute("修改")]
        [EnumMember]
        Edit = 1 << 2,
        /// <summary>
        /// 删除
        /// </summary>
        [EnumFieldAttribute("删除")]
        [EnumMember]
        Delete = 1 << 3,
        /// <summary>
        /// 移除
        /// </summary>
        [EnumFieldAttribute("移除")]
        [EnumMember]
        Remove = 1 << 4,
        /// <summary>
        /// 上移
        /// </summary>
        [EnumFieldAttribute("上移")]
        [EnumMember]
        Up = 1 << 5,
        /// <summary>
        /// 下移
        /// </summary>
        [EnumFieldAttribute("下移")]
        [EnumMember]
        Down = 1 << 6,
        /// <summary>
        /// 添加
        /// </summary>
        [EnumFieldAttribute("添加组")]
        [EnumMember]
        AddGroup = 1 << 7,
        /// <summary>
        /// 修改
        /// </summary>
        [EnumFieldAttribute("修改组")]
        [EnumMember]
        EditGroup = 1 << 8,
        /// <summary>
        /// 删除
        /// </summary>
        [EnumFieldAttribute("删除组")]
        [EnumMember]
        DeleteGroup = 1 << 9,
        /// <summary>
        /// 移除
        /// </summary>
        [EnumFieldAttribute("移除组")]
        [EnumMember]
        RemoveGroup = 1 << 10,
        /// <summary>
        /// 上移
        /// </summary>
        [EnumFieldAttribute("上移组")]
        [EnumMember]
        UpGroup = 1 << 11,
        /// <summary>
        /// 下移
        /// </summary>
        [EnumFieldAttribute("下移组")]
        [EnumMember]
        DownGroup = 1 << 12,
    }
}
