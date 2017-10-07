using System.Collections.Generic;

namespace WitsWay.Utilities.Daos
{
    /// <summary>
    /// 数据存储通用接口（状态变更）
    /// <para>
    /// 包含StatesByKey、StatesByKeys、StatesByClause
    /// </para>
    /// </summary>
    /// <typeparam name="TKey">主键类型</typeparam>
    /// <typeparam name="TData">数据类型</typeparam>
    public interface IRepositoryStates<TKey,TData>
    {
        /// <summary>
        /// 设置状态（多个状态Flags）
        /// </summary>
        /// <param name="key">主键</param>
        /// <param name="states">状态</param>
        void StatesByKey(TKey key, int states);
        /// <summary>
        /// 更新状态集
        /// </summary>
        /// <param name="keys">菜单Id</param>
        /// <param name="states">状态集</param>
        void StatesByKeys(IList<TKey> keys, int states);
        /// <summary>
        /// 设置状态集
        /// </summary>
        /// <param name="filterClause">过滤语句</param>
        /// <param name="states">状态集</param>
        void StatesByClause(string filterClause, int states);
        /// <summary>
        /// 获取所有数据（状态相等）
        /// </summary>
        /// <param name="states">状态集</param>
        /// <returns>返回所有实体列表</returns>
        List<TData> GetAllByStates(int states);

        /// <summary>
        /// 获取所有数据（包含状态集中的一个或多个状态）
        /// </summary>
        /// <param name="states">状态集</param>
        /// <returns>返回所有实体列表</returns>
        List<TData> GetAllStatesIn(IList<int> states);
    }

}
