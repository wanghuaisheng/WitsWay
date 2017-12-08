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
using System.Runtime.Serialization;

namespace WitsWay.Utilities.Errors
{
    /// <summary>
    /// 错误域
    /// <para>包含错误范围、子模块、领域模型定义</para>
    /// <para>相当于错误信息的最后一层分组</para>
    /// </summary>
    [DataContract]
    [ErrorItem("错误域")]
    public enum ErrorDomains
    {
        /// <summary>
        /// 通用错误
        /// </summary>
        [EnumMember] [ErrorItem("通用错误")] Utility,
        /// <summary>
        /// 共享缓存
        /// </summary>
        [EnumMember] [ErrorItem("共享缓存")] ShareCache,
        /// <summary>
        /// 服务
        /// </summary>
        [EnumMember] [ErrorItem("服务")] Services,
        /// <summary>
        /// 缓存镜像
        /// </summary>
        [EnumMember] [ErrorItem("缓存镜像")] CacheMirror,
        /// <summary>
        /// 地区信息
        /// </summary>
        [EnumMember] [ErrorItem("地区信息")] BaseRegion,
        /// <summary>
        /// 基础组
        /// </summary>
        [EnumMember] [ErrorItem("基础组")] LibBaseGroup,
        /// <summary>
        /// 库存件领料单
        /// </summary>
        [EnumMember] [ErrorItem("库存件领料单")] LibStorageUnitBill,
        /// <summary>
        /// 客户信息
        /// </summary>
        [EnumMember] [ErrorItem("客户信息")] Customer,
        /// <summary>
        /// 订单信息
        /// </summary>
        [EnumMember] [ErrorItem("订单信息")] PreOrder,
        /// <summary>
        /// 签到信息
        /// </summary>
        [EnumMember] [ErrorItem("签到信息")] SignOrder,
        /// <summary>
        /// 配置项
        /// </summary>
        [EnumMember] [ErrorItem("配置项")] ConfigItem,
        /// <summary>
        /// 分组信息
        /// </summary>
        [EnumMember] [ErrorItem("分组信息")] GroupInfo,
        /// <summary>
        /// 磁盘信息
        /// </summary>
        [EnumMember] [ErrorItem("磁盘信息")] DiskManage,
        /// <summary>
        /// 菜单
        /// </summary>
        [EnumMember] [ErrorItem("菜单")] ModulePage,
        /// <summary>
        /// 组件桌面
        /// </summary>
        [EnumMember] [ErrorItem("组件桌面")] WidgetDesktop,
        /// <summary>
        /// 呈现项
        /// </summary>
        [EnumMember] [ErrorItem("呈现项")] PresentItem,     
        /// <summary>
        /// 系统项
        /// </summary>
        [EnumMember]
        [ErrorItem("系统项")]
        SystemItem,
        /// <summary>
        /// 租户信息
        /// </summary>
        [EnumMember]
        [ErrorItem("租户信息")]
        TenantInfo,   
        /// <summary>
        /// 权限项
        /// </summary>
        [EnumMember]
        [ErrorItem("权限项")]
        RightItem,        
        /// <summary>
        /// 雇员
        /// </summary>
        [EnumMember]
        [ErrorItem("雇员")]
        EmpInfo,
        /// <summary>
        /// 组织机构
        /// </summary>
        [EnumMember]
        [ErrorItem("组织机构")]
        OrgInfo,
        /// <summary>
        /// 用户信息
        /// </summary>
        [EnumMember]
        [ErrorItem("用户信息")]
        UserInfo,
    }
}
