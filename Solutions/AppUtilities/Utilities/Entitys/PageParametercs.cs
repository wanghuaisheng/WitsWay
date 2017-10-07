using System.Collections.Generic;

namespace WitsWay.Utilities.Entitys
{
    /// <summary>
    /// 分页参数
    /// </summary>
    public class PageParameter
    {
        /// <summary>
        /// 当前页码
        /// </summary>
        public int PageIndex { get; set; }
        /// <summary>
        /// 每页显示条数
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 排序列集合
        /// </summary>
        public List<SortColumn> SortColumns { get; set; }

    }

}
