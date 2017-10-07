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

namespace WitsWay.Utlities.Tests.UtilitiesWin.Entities
{
    /// <summary>
    /// 客户订单筛选条件
    /// 
    /// </summary>
    public class CustomerPreorderFilter
    {
        /// <summary>
        /// 门店合同号、客户姓名、联系电话
        /// 
        /// </summary>
        public string ContractNoAndCustomerNameAndMobile { get; set; }
        /// <summary>
        /// 订单开始日期
        /// 
        /// </summary>
        public DateTime? OrderTimeBeginDate { get; set; }
        /// <summary>
        /// 订单结束日期
        /// 
        /// </summary>
        public DateTime? OrderTimeEndDate { get; set; }
        /// <summary>
        /// 作废状态
        /// 
        /// </summary>
        public int IsCancel { get; set; }
        /// <summary>
        /// 签单状态
        /// 
        /// </summary>
        public int IsSignOrder { get; set; }
        /// <summary>
        /// 预计量尺开始日期
        /// 
        /// </summary>
        public DateTime? ExpectedScaleTimeStart { get; set; }
        /// <summary>
        /// 预计量尺结束日期
        /// 
        /// </summary>
        public DateTime? ExpectedScaleTimeEnd { get; set; }
        /// <summary>
        /// 签单开始日期
        /// 
        /// </summary>
        public DateTime? SignContractTimeStart { get; set; }
        /// <summary>
        /// 签单结束日期
        /// 
        /// </summary>
        public DateTime? SignContractTimeEnd { get; set; }
        /// <summary>
        /// 地址状态
        /// 
        /// </summary>
        public int IsConfirmAddress { get; set; }
        /// <summary>
        /// 是否分配设计师
        /// 
        /// </summary>
        public int IsAllotDesigner { get; set; }
        /// <summary>
        /// 是否需要加载数据
        /// 
        /// </summary>
        public bool IsLoad { get; set; }
    }
}
