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
