namespace WitsWay.Utilities.Entitys
{
    /// <summary>
    ///  表格搜索对象
    /// </summary>
    /// <typeparam name="TFilter">过滤条件实体类</typeparam>
    public class PagerFilterPara<TFilter> where TFilter : class
    {
        /// <summary>
        /// 过滤条件对象
        /// </summary>
        public TFilter Filter { get; set; }

        /// <summary>
        /// 分页参数
        /// </summary>
        public PageParameter Pager { get; set; }
    }
}
