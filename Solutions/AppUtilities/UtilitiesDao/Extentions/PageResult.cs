using System.Collections.Generic;

namespace WitsWay.Utilities.Dap.Extentions
{
    /// <summary>
    /// 分页结果集
    /// </summary>
    public class PageResult<T> where T : class
    {
        /// <summary>
        /// 分页结果集
        /// </summary>
        /// <param name="resultList"></param>
        /// <param name="resultCount"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        public PageResult(IEnumerable<T> resultList, int resultCount,int pageSize,int pageNumber)
        {
            Results = resultList;
            Count = resultCount;
            PageSize = pageSize;
            PageNumber = pageNumber;
        }

        public IEnumerable<T> Results { get; set; }

        public int Count { get; set; }

        public int PageSize { get; set; }

        public int PageNumber { get; set; }
    }
}
