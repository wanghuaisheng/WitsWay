namespace WitsWay.Utilities.Validate.Validators
{
    /// <summary>
    /// 系统目前支持的最大额度
    /// </summary>
    public class ValidatorMaxPrice
    {
        /// <summary>
        /// 最大额度
        /// </summary>
        public const decimal MaxPrice = 1000000000;

        /// <summary>
        /// 账户维护支持的最大金额
        /// </summary>
        public const decimal Fin_MaxPrice = 99999999;

        /// <summary>
        /// 验证金额是否超过1000000000
        /// </summary>
        /// <param name="price">总金额</param>
        public static bool ValidatorPrice(decimal price)
        {
            if (price > MaxPrice)
                return false;
            return true;
        }
    }
}
