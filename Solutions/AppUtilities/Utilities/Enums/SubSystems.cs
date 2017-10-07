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
    [EnumDescription("子系统枚举")]
    public enum SubSystems
    {
        /// <summary>
        /// 内部服务
        /// </summary>
        [EnumMember]
        [EnumDescription("内部服务")]
        InternalServer = 10,
        /// <summary>
        /// 共享缓存
        /// </summary>
        [EnumMember]
        [EnumDescription("共享缓存")]
        ShareCache = 11,
        /// <summary>
        /// 任务调度
        /// </summary>
        [EnumMember]
        [EnumDescription("任务调度")]
        ShareTask = 12,
        /// <summary>
        /// 报表中心
        /// </summary>
        [EnumMember]
        [EnumDescription("报表中心")]
        ShareReport = 13,

        /// <summary>
        /// 基础管理平台（Application Basic Manage）
        /// </summary>
        [EnumMember]
        [EnumDescription("基础管理平台")]
        ABM = 21,
        /// <summary>
        /// 产品数据管理（Product Data Manage）
        /// </summary>
        [EnumMember]
        [EnumDescription("产品数据管理")]
        PDM = 22,
        /// <summary>
        /// 产品价格管理（Product Price Manage）
        /// </summary>
        [EnumMember]
        [EnumDescription("产品价格管理")]
        PPM = 23,
        /// <summary>
        /// 订单管理平台
        /// </summary>
        [EnumMember]
        [EnumDescription("订单管理平台")]
        OrderPlatform = 24,
        /// <summary>
        /// 制造执行系统（Manufacturing Execution Systems）
        /// </summary>
        [EnumMember]
        [EnumDescription("制造执行系统")]
        MES = 25,
        /// <summary>
        /// 供应链管理系统
        /// </summary>
        [EnumMember]
        [EnumDescription("供应链管理系统")]
        SCM=26,

    }
}

        ///// <summary>
        ///// 数据转换服务器
        ///// </summary>
        //[EnumDescription("数据转换服务器")]
        //DataConvertServer = 21,
        ///// <summary>
        ///// ERP内部服务器
        ///// </summary>
        //[EnumDescription("ERP内部服务器")]
        //ErpPrivateServer = 22,
        ///// <summary>
        ///// 通讯服务器
        ///// </summary>
        //[EnumDescription("通讯服务器")]
        //CommunicationServer = 23,
        ///// <summary>
        ///// 合同解析服务器
        ///// </summary>
        //[EnumDescription("合同解析服务器")]
        //AnalyzeServer = 24,
        ///// <summary>
        ///// 包装系统
        ///// </summary>
        //[EnumDescription("包装系统")]
        //PackageSystem = 31,
        ///// <summary>
        ///// 普通工位系统
        ///// </summary>
        //[EnumDescription("普通工位系统")]
        //WorkStationSystem = 32,
        ///// <summary>
        ///// 半成品库房工位系统
        ///// </summary>
        //[EnumDescription("半成品库房工位系统")]
        //SemiFinishedStoreHouse = 33,
        ///// <summary>
        ///// 成品库房工位系统
        ///// </summary>
        //[EnumDescription("成品库房工位系统")]
        //FinishedStoreHouse = 34,
        ///// <summary>
        ///// 自动更新
        ///// </summary>
        //[EnumDescription("自动更新")]
        //AutoUpdate = 35,
            
        ///// <summary>
        ///// 报表中心
        ///// </summary>
        //[EnumDescription("报表中心")]
        //ReportCenter = 36,

        ///// <summary>
        ///// 客户案例展示平台
        ///// </summary>
        //[EnumDescription("客户案例展示平台")]
        //CustomerCasePlatform = 37,

        ///// <summary>
        ///// 微信应用
        ///// </summary>
        //[EnumDescription("微信应用")]
        //WeChat = 38