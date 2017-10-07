namespace WitsWay.TempTests.GeneralQuery.QueryForms
{
    /// <summary>
    /// 搜索过滤控件
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ISearchFilterUc<T>
    {
        /// <summary>
        /// 过滤规则配置键
        /// </summary>
        string ConfigKey { get; }
        /// <summary>
        /// 获取配置
        /// </summary>
        /// <returns>配置信息</returns>
        T GetFilter();
        /// <summary>
        /// 绑定配置
        /// </summary>
        /// <param name="data">配置信息</param>
        void BindFilter(T data);
    }
}
