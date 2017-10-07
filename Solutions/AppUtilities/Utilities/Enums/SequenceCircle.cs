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
    [EnumFieldAttribute("系统序列周期")]
    public enum SequenceCircle
    {
        /// <summary>
        /// 递增序列
        /// </summary>
        [EnumMember]
        [EnumFieldAttribute("递增序列")]
        Increase = 1,
        /// <summary>
        /// 以天为周期
        /// </summary>
        [EnumMember]
        [EnumFieldAttribute("以天为周期")]
        Day = 2

    }
}