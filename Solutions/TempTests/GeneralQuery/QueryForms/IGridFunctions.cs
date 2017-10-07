using WitsWay.Utilities.Entitys;

namespace WitsWay.TempTests.GeneralQuery.QueryForms
{
    /// <summary>
    /// 分页控件支持功能
    /// </summary>
    public interface IGridFunctions<TData, TFilter>
    {
        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <returns>配置信息</returns>
        PageResult<TData> GetPage(PageParameter para, TFilter filter);
        /// <summary>
        /// 获取筛选控件
        /// </summary>
        /// <returns>筛选控件接口实例</returns>
        ISearchFilterUc<TFilter> GetFilterUc();
        /// <summary>
        /// 获取布局数据（Grid布局/Detail布局）
        /// </summary>
        void GetLayouts();
        /// <summary>
        /// 获取过滤控件初始化数据
        /// </summary>
        void GetFilterInitDatas();
        /// <summary>
        /// 获取权限数据
        /// </summary>
        void GetRightDatas();
        }
}
