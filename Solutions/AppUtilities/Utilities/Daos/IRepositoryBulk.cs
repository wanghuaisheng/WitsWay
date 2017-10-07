using System.Collections.Generic;
using WitsWay.Utilities.Entitys;

namespace WitsWay.Utilities.Daos
{
    /// <summary>
    /// 数据存储通用接口（批量操作）
    /// <para>
    /// 包含BulkDelete、BulkInsert、BulkUpdate、BulkSync
    /// </para>
    /// </summary>
    /// <typeparam name="TData">要存取的实例对象</typeparam>
    /// <typeparam name="TKey">键类型</typeparam>
    public interface IRepositoryBulk<TKey,TData>
    {
        /// <summary>
        /// 通过主键列表删除数据
        /// </summary>
        /// <param name="keys">主键列表</param>
        /// <returns>删除条数</returns>
        int BulkDelete(IList<TKey> keys);
        /// <summary>
        /// 批量获取
        /// </summary>
        /// <param name="keys">键列表</param>
        /// <returns>数据列表</returns>
        List<TData> BulkGetByKeys(IList<TKey> keys);
        /// <summary>
        /// 批量插入
        /// </summary>
        /// <param name="datas">实体列表</param>
        /// <returns>批量插入结果</returns>
        BulkInsertResult BulkInsert(IList<TData> datas);
        /// <summary>
        /// 批量更新
        /// </summary>
        /// <param name="datas">实体列表</param>
        void BulkUpdate(IList<TData> datas);
        /// <summary>
        /// 批量同步（插入、更新、删除）
        /// </summary>
        /// <param name="datas">实体列表</param>
        void BulkSync(IList<TData> datas);

    }

}
