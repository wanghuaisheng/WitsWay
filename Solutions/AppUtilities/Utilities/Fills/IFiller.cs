namespace WitsWay.Utilities.Fills
{

    /// <summary>
    /// 填充器
    /// </summary>
    public interface IFiller
    {

        /// <summary>
        /// 填充数据类型
        /// </summary>
        FillKind Kind { get; }

        /// <summary>
        /// 获取填充值
        /// </summary>
        /// <param name="key">数据键</param>
        /// <param name="paras">附加参数</param>
        /// <returns>填充值</returns>
        object GetFillValue(object key, params object[] paras);

    }

}
