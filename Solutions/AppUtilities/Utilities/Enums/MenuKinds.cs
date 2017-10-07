using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using WitsWay.Utilities.Attributes;

namespace WitsWay.Utilities.Enums
{

    /// <summary>
    /// 菜单类型
    /// </summary>
    [DataContract]
    [Serializable]
    [EnumDescription("菜单类型")]
    public enum MenuKinds
    {
        /// <summary>
        /// Web组集
        /// </summary>
        [XmlEnum("1")]
        [EnumDescription("Web组集")]
        [EnumMember]
        WebBlock = 1,

        /// <summary>
        /// Web组
        /// </summary>
        [XmlEnum("2")]
        [EnumDescription("Web组")]
        [EnumMember]
        WebGroup = 2,

        /// <summary>
        /// Web菜单
        /// </summary>
        [XmlEnum("3")]
        [EnumDescription("Web菜单")]
        [EnumMember]
        WebMidMenu = 3,

        /// <summary>
        /// Web弹出菜单
        /// </summary>
        [XmlEnum("4")]
        [EnumDescription("Web弹出菜单")]
        [EnumMember]
        WebPopMenu = 4,

        /// <summary>
        /// Win程序集
        /// </summary>
        [XmlEnum("10")]
        [EnumDescription("程序块")]
        [EnumMember]
        WinBlock = 10,
        /// <summary>
        /// WinForm组集
        /// </summary>
        [XmlEnum("11")]
        [EnumDescription("菜单页")]
        [EnumMember]
        WinMenuPage = 11,
        /// <summary>
        /// 菜单组
        /// </summary>
        [XmlEnum("12")]
        [EnumDescription("菜单组")]
        [EnumMember]
        WinMenuGroup = 12,
        /// <summary>
        /// WinForm菜单
        /// </summary>
        [XmlEnum("13")]
        [EnumDescription("窗体菜单")]
        [EnumMember]
        WinMenuMid = 13,
        /// <summary>
        /// WinForm弹出菜单
        /// </summary>
        [XmlEnum("14")]
        [EnumDescription("弹出菜单")]
        [EnumMember]
        WinMenuPop = 14,
        /// <summary>
        /// 执行方法菜单
        /// </summary>
        [XmlEnum("15")]
        [EnumDescription("执行菜单")]
        [EnumMember]
        WinMenuAction = 15,
        /// <summary>
        /// 泛型窗体菜单
        /// </summary>
        [XmlEnum("16")]
        [EnumDescription("泛型窗体菜单")]
        [EnumMember]
        WinMenuGenericMid=16,
        /// <summary>
        /// 泛型弹出菜单
        /// </summary>
        [XmlEnum("17")]
        [EnumDescription("泛型弹出菜单")]
        [EnumMember]
        WinMenuGenericPop=17,

        /// <summary>
        /// 组菜单
        /// </summary>
        [XmlEnum("21")]
        [EnumDescription("组菜单")]
        [EnumMember]
        WinDropGroup = 21,

        /// <summary>
        /// 子菜单
        /// </summary>
        [XmlEnum("22")]
        [EnumDescription("子菜单")]
        [EnumMember]
        WinDropMenu = 22,

        /// <summary>
        /// 报表分组
        /// </summary>
        [XmlEnum("31")]
        [EnumDescription("报表分组")]
        [EnumMember]
        ReportGroup = 21,

        /// <summary>
        /// 报表项
        /// </summary>
        [XmlEnum("32")]
        [EnumDescription("报表项")]
        [EnumMember]
        ReportItem = 22,


    }
}