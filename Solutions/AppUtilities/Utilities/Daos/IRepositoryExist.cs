using System.Collections.Generic;

namespace WitsWay.Utilities.Daos
{
    /// <summary>
    /// 数据存储通用接口（存在判断）
    /// <para>
    /// 包含ExistKey、ExistKeys、ExistByClause
    /// </para>
    /// </summary>
    /// <typeparam name="TKey">主键类型</typeparam>
    public interface IRepositoryExist<TKey>
    {

        /// <summary>
        /// 是否存在对应主键的数据
        /// </summary>
        /// <param name="key">主键</param>
        /// <returns>存在true，不存在false</returns>
        bool ExistKey(TKey key);
        /// <summary>
        /// 是否存在页面项
        /// </summary>
        /// <param name="keys">id</param>
        /// <returns>存在数据条数</returns>
        int ExistKeys(IList<TKey> keys);
        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="filterClause">筛选语句</param>
        /// <returns>存在true，不存在false</returns>
        bool ExistByClause(string filterClause);
    }
}
