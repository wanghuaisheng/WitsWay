using System;

namespace Touch.Enums.Posts
{

    /// <summary>
    /// 大屏订单查询提交对象
    /// </summary>
    public class ScreenOrderQueryResult
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderNo { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 错误消息
        /// </summary>
        public string ErrorMessage { get; set; }
        /// <summary>
        /// 时间戳
        /// </summary>
        public DateTime TimeStamp { get; set; }
    }


}
