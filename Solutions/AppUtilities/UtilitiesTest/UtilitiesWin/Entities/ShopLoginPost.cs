namespace WitsWay.Utlities.Tests.UtilitiesWin.Entities
{
    /// <summary>
    /// EShop登录Post对象
    /// </summary>
    public class ShopLoginPost
    {
        /// <summary>
        /// 门店编号
        /// </summary>
        public string CorpCode { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 是否记住登录状态
        /// </summary>
        public bool Remember { get; set; }
        /// <summary>
        /// 登录类型
        /// </summary>
        public LoginTypeEnum LoginTypeEnum { get; set; }
    }
}
