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
    /// 子系统枚举
    /// </summary>
    [Serializable]
    [DataContract]
    [EnumFieldAttribute("子系统枚举")]
    public enum SubSystems
    {
        /// <summary>
        /// 内部服务
        /// </summary>
        [EnumMember]
        [EnumFieldAttribute("内部服务")]
        InternalServer = 10,
        /// <summary>
        /// 共享缓存
        /// </summary>
        [EnumMember]
        [EnumFieldAttribute("共享缓存")]
        ShareCache = 11,
        /// <summary>
        /// 任务调度
        /// </summary>
        [EnumMember]
        [EnumFieldAttribute("任务调度")]
        ShareTask = 12,
        /// <summary>
        /// 报表中心
        /// </summary>
        [EnumMember]
        [EnumFieldAttribute("报表中心")]
        ShareReport = 13,

        /// <summary>
        /// 基础管理平台（Application Basic Manage）
        /// </summary>
        [EnumMember]
        [EnumFieldAttribute("基础管理平台")]
        ABM = 21,
        /// <summary>
        /// 产品数据管理（Product Data Manage）
        /// </summary>
        [EnumMember]
        [EnumFieldAttribute("产品数据管理")]
        PDM = 22,
        /// <summary>
        /// 产品价格管理（Product Price Manage）
        /// </summary>
        [EnumMember]
        [EnumFieldAttribute("产品价格管理")]
        PPM = 23,
        /// <summary>
        /// 订单管理平台
        /// </summary>
        [EnumMember]
        [EnumFieldAttribute("订单管理平台")]
        OrderPlatform = 24,
        /// <summary>
        /// 制造执行系统（Manufacturing Execution Systems）
        /// </summary>
        [EnumMember]
        [EnumFieldAttribute("制造执行系统")]
        MES = 25,
        /// <summary>
        /// 供应链管理系统
        /// </summary>
        [EnumMember]
        [EnumFieldAttribute("供应链管理系统")]
        SCM=26,

    }
}

        ///// <summary>
        ///// 数据转换服务器
        ///// </summary>
        //[EnumField("数据转换服务器")]
        //DataConvertServer = 21,
        ///// <summary>
        ///// ERP内部服务器
        ///// </summary>
        //[EnumField("ERP内部服务器")]
        //ErpPrivateServer = 22,
        ///// <summary>
        ///// 通讯服务器
        ///// </summary>
        //[EnumField("通讯服务器")]
        //CommunicationServer = 23,
        ///// <summary>
        ///// 合同解析服务器
        ///// </summary>
        //[EnumField("合同解析服务器")]
        //AnalyzeServer = 24,
        ///// <summary>
        ///// 包装系统
        ///// </summary>
        //[EnumField("包装系统")]
        //PackageSystem = 31,
        ///// <summary>
        ///// 普通工位系统
        ///// </summary>
        //[EnumField("普通工位系统")]
        //WorkStationSystem = 32,
        ///// <summary>
        ///// 半成品库房工位系统
        ///// </summary>
        //[EnumField("半成品库房工位系统")]
        //SemiFinishedStoreHouse = 33,
        ///// <summary>
        ///// 成品库房工位系统
        ///// </summary>
        //[EnumField("成品库房工位系统")]
        //FinishedStoreHouse = 34,
        ///// <summary>
        ///// 自动更新
        ///// </summary>
        //[EnumField("自动更新")]
        //AutoUpdate = 35,
            
        ///// <summary>
        ///// 报表中心
        ///// </summary>
        //[EnumField("报表中心")]
        //ReportCenter = 36,

        ///// <summary>
        ///// 客户案例展示平台
        ///// </summary>
        //[EnumField("客户案例展示平台")]
        //CustomerCasePlatform = 37,

        ///// <summary>
        ///// 微信应用
        ///// </summary>
        //[EnumField("微信应用")]
        //WeChat = 38