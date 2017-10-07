namespace WitsWay.Utilities.Supports
{
    /// <summary>
    /// 实体选中接口
    /// </summary>
    public interface ISelected:IKey
    {
        /// <summary>
        /// 是否选中
        /// </summary>
        bool IsSelected { get; set; }
        /// <summary>
        /// 显示名称
        /// </summary>
        string ItemName { get; }
    }
}
