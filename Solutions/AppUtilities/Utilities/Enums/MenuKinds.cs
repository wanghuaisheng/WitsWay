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
    [EnumField("菜单类型")]
    public enum MenuKinds
    {
        /// <summary>
        /// Web组集
        /// </summary>
        [XmlEnum("1")] [EnumField("Web组集")] [EnumMember] WebBlock = 1,

        /// <summary>
        /// Web组
        /// </summary>
        [XmlEnum("2")] [EnumField("Web组")] [EnumMember] WebGroup = 2,

        /// <summary>
        /// Web菜单
        /// </summary>
        [XmlEnum("3")] [EnumField("Web菜单")] [EnumMember] WebMidMenu = 3,

        /// <summary>
        /// Web弹出菜单
        /// </summary>
        [XmlEnum("4")] [EnumField("Web弹出菜单")] [EnumMember] WebPopMenu = 4,

        /// <summary>
        /// Win程序集
        /// </summary>
        [XmlEnum("10")] [EnumField("程序块")] [EnumMember] WinBlock = 10,
        /// <summary>
        /// WinForm组集
        /// </summary>
        [XmlEnum("11")] [EnumField("菜单页")] [EnumMember] WinMenuPage = 11,
        /// <summary>
        /// 菜单组
        /// </summary>
        [XmlEnum("12")] [EnumField("菜单组")] [EnumMember] WinMenuGroup = 12,
        /// <summary>
        /// WinForm菜单
        /// </summary>
        [XmlEnum("13")] [EnumField("窗体菜单")] [EnumMember] WinMenuMid = 13,
        /// <summary>
        /// WinForm弹出菜单
        /// </summary>
        [XmlEnum("14")] [EnumField("弹出菜单")] [EnumMember] WinMenuPop = 14,
        /// <summary>
        /// 执行方法菜单
        /// </summary>
        [XmlEnum("15")] [EnumField("执行菜单")] [EnumMember] WinMenuAction = 15,
        /// <summary>
        /// 泛型窗体菜单
        /// </summary>
        [XmlEnum("16")] [EnumField("泛型窗体菜单")] [EnumMember] WinMenuGenericMid=16,
        /// <summary>
        /// 泛型弹出菜单
        /// </summary>
        [XmlEnum("17")] [EnumField("泛型弹出菜单")] [EnumMember] WinMenuGenericPop=17,

        /// <summary>
        /// 组菜单
        /// </summary>
        [XmlEnum("21")] [EnumField("组菜单")] [EnumMember] WinDropGroup = 21,

        /// <summary>
        /// 子菜单
        /// </summary>
        [XmlEnum("22")] [EnumField("子菜单")] [EnumMember] WinDropMenu = 22,

        /// <summary>
        /// 报表分组
        /// </summary>
        [XmlEnum("31")] [EnumField("报表分组")] [EnumMember] ReportGroup = 21,

        /// <summary>
        /// 报表项
        /// </summary>
        [XmlEnum("32")] [EnumField("报表项")] [EnumMember] ReportItem = 22,


    }
}