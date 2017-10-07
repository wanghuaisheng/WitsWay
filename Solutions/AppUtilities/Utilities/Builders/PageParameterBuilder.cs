using System.Collections.Generic;
using WitsWay.Utilities.Entitys;

namespace WitsWay.Utilities.Builders
{
    /// <summary>
    /// 分页参数构建器
    /// </summary>
    public class PageParameterBuilder
    {
        /// <summary>
        /// 取得Builder实例
        /// </summary>
        /// <returns>新的Builder实例</returns>
        public static PageParameterBuilder NewBuilder()
        {
            return new PageParameterBuilder();
        }
        private readonly PageParameter _para = new PageParameter { SortColumns = new List<SortColumn>() };
        /// <summary>
        /// 构建结果
        /// </summary>
        public PageParameter Result => _para;

        /// <summary>
        /// 第几页
        /// </summary>
        /// <returns>分页参数构建器</returns>
        public PageParameterBuilder PageIndex(int pageIndex)
        {
            _para.PageIndex = pageIndex;
            return this;
        }
        /// <summary>
        /// 每页条数
        /// </summary>
        /// <returns>分页参数构建器</returns>
        public PageParameterBuilder PageSize(int pageSize)
        {
            _para.PageSize = pageSize;
            return this;
        }
        /// <summary>
        /// 排序列
        /// </summary>
        /// <param name="field">字段</param>
        /// <param name="assend">是否升序</param>
        /// <returns>分页参数构建器</returns>
        public PageParameterBuilder SortColumn(string field, bool assend)
        {
            _para.SortColumns.Add(new SortColumn { SortField = field, Ascend = assend });
            return this;
        }
    }
}
