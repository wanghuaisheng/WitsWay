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
using System.Xml.Serialization;
using WitsWay.Utilities.Attributes;

namespace WitsWay.Utilities.Enums
{

    /// <summary>
    /// 菜单类型
    /// </summary>
    [DataContract]
    [Serializable]
    [EnumFieldAttribute("菜单类型")]
    public enum MenuKinds
    {
        /// <summary>
        /// Web组集
        /// </summary>
        [XmlEnum("1")]
        [EnumFieldAttribute("Web组集")]
        [EnumMember]
        WebBlock = 1,

        /// <summary>
        /// Web组
        /// </summary>
        [XmlEnum("2")]
        [EnumFieldAttribute("Web组")]
        [EnumMember]
        WebGroup = 2,

        /// <summary>
        /// Web菜单
        /// </summary>
        [XmlEnum("3")]
        [EnumFieldAttribute("Web菜单")]
        [EnumMember]
        WebMidMenu = 3,

        /// <summary>
        /// Web弹出菜单
        /// </summary>
        [XmlEnum("4")]
        [EnumFieldAttribute("Web弹出菜单")]
        [EnumMember]
        WebPopMenu = 4,

        /// <summary>
        /// Win程序集
        /// </summary>
        [XmlEnum("10")]
        [EnumFieldAttribute("程序块")]
        [EnumMember]
        WinBlock = 10,
        /// <summary>
        /// WinForm组集
        /// </summary>
        [XmlEnum("11")]
        [EnumFieldAttribute("菜单页")]
        [EnumMember]
        WinMenuPage = 11,
        /// <summary>
        /// 菜单组
        /// </summary>
        [XmlEnum("12")]
        [EnumFieldAttribute("菜单组")]
        [EnumMember]
        WinMenuGroup = 12,
        /// <summary>
        /// WinForm菜单
        /// </summary>
        [XmlEnum("13")]
        [EnumFieldAttribute("窗体菜单")]
        [EnumMember]
        WinMenuMid = 13,
        /// <summary>
        /// WinForm弹出菜单
        /// </summary>
        [XmlEnum("14")]
        [EnumFieldAttribute("弹出菜单")]
        [EnumMember]
        WinMenuPop = 14,
        /// <summary>
        /// 执行方法菜单
        /// </summary>
        [XmlEnum("15")]
        [EnumFieldAttribute("执行菜单")]
        [EnumMember]
        WinMenuAction = 15,
        /// <summary>
        /// 泛型窗体菜单
        /// </summary>
        [XmlEnum("16")]
        [EnumFieldAttribute("泛型窗体菜单")]
        [EnumMember]
        WinMenuGenericMid=16,
        /// <summary>
        /// 泛型弹出菜单
        /// </summary>
        [XmlEnum("17")]
        [EnumFieldAttribute("泛型弹出菜单")]
        [EnumMember]
        WinMenuGenericPop=17,

        /// <summary>
        /// 组菜单
        /// </summary>
        [XmlEnum("21")]
        [EnumFieldAttribute("组菜单")]
        [EnumMember]
        WinDropGroup = 21,

        /// <summary>
        /// 子菜单
        /// </summary>
        [XmlEnum("22")]
        [EnumFieldAttribute("子菜单")]
        [EnumMember]
        WinDropMenu = 22,

        /// <summary>
        /// 报表分组
        /// </summary>
        [XmlEnum("31")]
        [EnumFieldAttribute("报表分组")]
        [EnumMember]
        ReportGroup = 21,

        /// <summary>
        /// 报表项
        /// </summary>
        [XmlEnum("32")]
        [EnumFieldAttribute("报表项")]
        [EnumMember]
        ReportItem = 22,


    }
}