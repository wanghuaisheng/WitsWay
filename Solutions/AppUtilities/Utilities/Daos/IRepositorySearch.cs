using WitsWay.Utilities.Entitys;

namespace WitsWay.Utilities.Daos
{
    /// <summary>
    /// 数据存储通用接口（搜索数据，兼容历史调用方式）
    /// <para>多个TFilter通过实现多个接口实现</para>
    /// </summary>
    /// <typeparam name="TData">实体类型</typeparam>
    /// <typeparam name="TFilter">筛选对象类型</typeparam>
    public interface IRepositorySearch<TData, TFilter>
        where TData : class
        where TFilter : class
    {

        /// <summary>
        /// 获取分页结果集
        /// </summary>
        /// <param name="filter">筛选条件载体</param>
        /// <returns>分页结果集</returns>
        PageResult<TData> Search(PagerFilterPara<TFilter> filter);

    }
}
