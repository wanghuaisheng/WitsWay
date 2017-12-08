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
using WitsWay.Utilities.Attributes;

namespace WitsWay.Utilities.Fills
{
    /// <summary>
    /// 填充数据类型
    /// </summary>
    [EnumField("填充数据类型")]
    public enum FillKind
    {
        /// <summary>
        /// 人员名称
        /// </summary>
        [EnumField("人员名称")] EmployeeName,
        /// <summary>
        /// 人员名称组，逗号分隔
        /// </summary>
        [EnumField("人员名称组")] EmployeeNames,
        /// <summary>
        /// 组名
        /// </summary>
        [EnumField("组名")] GroupName,
        /// <summary>
        /// 组编码
        /// </summary>
        [EnumField("组编码")] GroupCode,
        /// <summary>
        /// 省名称
        /// </summary>
        [EnumField("省名称")] ProvenceName,
        /// <summary>
        /// 城市名称
        /// </summary>
        [EnumField("城市名称")] CityName,
        /// <summary>
        /// 地区名称
        /// </summary>
        [EnumField("地区名称")] RegionName,
        /// <summary>
        /// 菜单模块名称
        /// </summary>
        [EnumField("菜单模块名称")] MenuModuleName,
        /// <summary>
        /// 租户名称
        /// </summary>
        [EnumField("租户名称")]
        TenantName,
        /// <summary>
        /// 组织机构
        /// </summary>
        [EnumField("组织机构")]
        OrgName,
        /// <summary>
        /// 数据字典
        /// </summary>
        [EnumField("数据字典")]
        DataGroupName,
        /// <summary>
        /// 系统项
        /// </summary>
        [EnumField("系统项")]
        SystemItemName
    }
}
