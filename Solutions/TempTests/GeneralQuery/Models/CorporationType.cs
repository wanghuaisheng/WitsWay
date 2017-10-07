using System.Runtime.Serialization;
using System.Xml.Serialization;
using WitsWay.Utilities.Attributes;

namespace WitsWay.TempTests.GeneralQuery.Models
{
    /// <summary>
    /// 公司类型
    /// </summary>
    [DataContract]
    public enum CorporationType
    {
        /// <summary>
        /// 总公司
        /// </summary>
        [XmlEnum("0")]
        [EnumField("总公司")]
        [EnumMember]
        LocalCorporation = 0,
        /// <summary>
        /// 经销商
        /// </summary>
        [XmlEnum("1")]
        [EnumField("经销商")]
        [EnumMember]
        JoinCorporation = 1,
        /// <summary>
        /// 直营店
        /// </summary>
        [XmlEnum("2")]
        [EnumField("直营店")]
        [EnumMember]
        SelfShop = 2,


    }
}
