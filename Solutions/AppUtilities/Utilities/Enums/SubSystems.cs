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
    [Serializable, DataContract, EnumField("子系统枚举")]
    public enum SubSystems
    {
        /// <summary>
        /// 内部服务
        /// </summary>
        [EnumMember, EnumField("内部服务")]
        InternalServer = 10,
        /// <summary>
        /// 共享缓存
        /// </summary>
        [EnumMember, EnumField("共享缓存")]
        ShareCache = 11,
        /// <summary>
        /// 任务调度
        /// </summary>
        [EnumMember, EnumField("任务调度")]
        ShareTask = 12,
        /// <summary>
        /// 报表中心
        /// </summary>
        [EnumMember, EnumField("报表中心")]
        ShareReport = 13,
        /// <summary>
        /// 应用中心
        /// </summary>
        [EnumMember, EnumField("应用中心")]
        AppCenter = 14,
        /// <summary>
        /// 基础管理平台（Application Basic Manage）
        /// </summary>
        [EnumMember, EnumField("基础管理平台")]
        ABM = 21,
        /// <summary>
        /// 产品数据管理（Product Data Manage）
        /// </summary>
        [EnumMember, EnumField("产品数据管理")]
        PDM = 22,
        /// <summary>
        /// 产品价格管理（Product Price Manage）
        /// </summary>
        [EnumMember, EnumField("产品价格管理")]
        PPM = 23,
        /// <summary>
        /// 订单管理平台
        /// </summary>
        [EnumMember, EnumField("订单管理平台")]
        OrderPlatform = 24,
        /// <summary>
        /// 制造执行系统（Manufacturing Execution Systems）
        /// </summary>
        [EnumMember, EnumField("制造执行系统")]
        MES = 25,
        /// <summary>
        /// 供应链管理系统
        /// </summary>
        [EnumMember, EnumField("供应链管理系统")]
        SCM = 26,
        /// <summary>
        /// 库房管理系统
        /// </summary>
        [EnumMember, EnumField("供应链管理系统")]
        WMS = 27

    }
}