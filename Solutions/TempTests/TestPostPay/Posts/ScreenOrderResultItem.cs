namespace Touch.Enums.Posts
{

    /// <summary>
    /// 大屏下单项返回结果
    /// </summary>
    public class ScreenOrderResultItem
    {
        /// <summary>
        /// 产品唯一标识
        /// </summary>
        public string ProductIC { get; set; }
        /// <summary>
        /// 下单数量
        /// </summary>
        public int OrderNum { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        public decimal UnitPrice { get; set; }
    }

}
