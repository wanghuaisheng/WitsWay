namespace WitsWay.Utilities.Supports
{
    /// <summary>
    /// 拼音支持
    /// </summary>
    public interface IPinYinSupport
    {
        /// <summary>
        /// 拼音目标
        /// </summary>
        string PinYinTarget { get; }
        /// <summary>
        /// 全拼
        /// </summary>
        string FullSpell { get; set; }
        /// <summary>
        /// 所有字首字母
        /// </summary>
        string FullCapital { get; set; }
        /// <summary>
        /// 第一个首字母
        /// </summary>
        string FirstCapital { get; set; }

    }

}
