namespace WitsWay.Utilities.Apis
{
    /// <summary>
    /// WebApi上下文
    /// </summary>
    public class WebApiContext
    {
        /// <summary>
        /// 授权Cookie名称
        /// </summary>
        public static string AuthenticationCookieName { get; set; }

        /// <summary>
        /// 登录系统
        /// </summary>
        public static int LoginSystem { get; set; }
    }
}
