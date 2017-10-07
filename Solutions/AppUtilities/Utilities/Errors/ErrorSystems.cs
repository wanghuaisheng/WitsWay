using System;
using System.Runtime.Serialization;

namespace WitsWay.Utilities.Errors
{
    /// <summary>
    /// 错误域枚举
    /// </summary>
    [Serializable]
    [DataContract]
    [ErrorItem("错误域")]
    public enum ErrorSystems
    {
        /// <summary>
        /// 公共组件
        /// </summary>
        [EnumMember]
        [ErrorItem("公共组件")]
        AppComponent = 1,
        /// <summary>
        /// 业务逻辑层
        /// </summary>
        [EnumMember]
        [ErrorItem("业务逻辑")]
        BusinessLogic = 10,
        /// <summary>
        /// 门店平台
        /// </summary>
        [EnumMember]
        [ErrorItem("门店平台")]
        ShopPlatform = 11,
        /// <summary>
        /// 案例展示平台
        /// </summary>
        [EnumMember]
        [ErrorItem("案例展示平台")]
        CasePlatform,
        /// <summary>
        /// 网站管理平台
        /// </summary>
        [EnumMember]
        [ErrorItem("网站管理平台")]
        WebManagePlatform,
        /// <summary>
        /// 基础管理平台（Win）
        /// </summary>
        [EnumMember]
        [ErrorItem("基础管理平台")]
        ABM,
        /// <summary>
        /// 客户关系管理
        /// </summary>
        [EnumMember]
        [ErrorItem("客户关系管理")]
        CRM,
        /// <summary>
        /// 料单解析
        /// </summary>
        [EnumMember]
        [ErrorItem("料单解析")]
        BOM,
        /// <summary>
        /// 订单管理平台
        /// </summary>
        [EnumMember]
        [ErrorItem("订单管理平台")]
        OrderPlatform,
        /// <summary>
        /// 制造执行系统
        /// </summary>
        [EnumMember]
        [ErrorItem("制造执行系统")]
        MES,
        /// <summary>
        /// 价格体系
        /// </summary>
        [EnumMember]
        [ErrorItem("价格体系")]
        PriceSystem,
        /// <summary>
        /// 产品体系
        /// </summary>
        [EnumMember]
        [ErrorItem("产品体系")]
        ProductSystem,
        /// <summary>
        /// 供应链管理
        /// </summary>
        [EnumMember]
        [ErrorItem("供应链管理")]
        SCM,



        /// <summary>
        /// 共享缓存
        /// </summary>
        [EnumMember]
        [ErrorItem("共享缓存")]
        ShareCache = 41,
        /// <summary>
        /// 自动更新
        /// </summary>
        [EnumMember]
        [ErrorItem("自动更新")]
        ShareUpdate = 42,
        /// <summary>
        /// 任务管理系统
        /// </summary>
        [EnumMember]
        [ErrorItem("任务管理系统")]
        ShareTask = 43,
        /// <summary>
        /// 报表系统
        /// </summary>
        [EnumMember]
        [ErrorItem("报表系统")]
        ShareReport=44,

        /// <summary>
        /// 业务总线服务器
        /// </summary>
        [EnumMember]
        [ErrorItem("业务总线服务器")]
        BusServer = 51,
        /// <summary>
        /// 通讯服务器
        /// </summary>
        [EnumMember]
        [ErrorItem("通讯服务器")]
        LoadServer=52,


        /// <summary>
        /// 包装系统
        /// </summary>
        [EnumMember]
        [ErrorItem("包装系统")]
        PackageSystem=61,
        /// <summary>
        /// 加工工位系统
        /// </summary>
        [EnumMember]
        [ErrorItem("加工工位系统")]
        ProcessSystem = 62,
        /// <summary>
        /// 库房管理系统（Warehouse Management System）
        /// </summary>
        [EnumMember]
        [ErrorItem("库房管理系统")]
        WMS = 63,

    }
}