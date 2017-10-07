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
    /// 页面功能
    /// </summary>
    [Serializable]
    [DataContract]
    [EnumDescription("页面功能")]
    public enum PageFunctions
    {
        /// <summary>
        /// 查看
        /// </summary>
        [EnumMember]
        [EnumDescription("查看")]
        View = 1,
        /// <summary>
        /// 添加
        /// </summary>
        [EnumMember]
        [EnumDescription("添加")]
        Add = 2,
        /// <summary>
        /// 拷贝添加
        /// </summary>
        [EnumMember]
        [EnumDescription("添加")]
        CopyAdd = 4,
        /// <summary>
        /// 修改
        /// </summary>
        [EnumMember]
        [EnumDescription("修改")]
        Edit = 8,
        /// <summary>
        /// 审核
        /// </summary>
        [EnumMember]
        [EnumDescription("审核")]
        Audit = 16
    }
}
