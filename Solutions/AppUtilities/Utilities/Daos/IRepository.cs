using System.Collections.Generic;

namespace WitsWay.Utilities.Daos
{
    /// <summary>
    /// 数据存储通用接口
    /// <para>
    /// 包含Insert、Update、DeleteByKey、GetAll、GetByKey
    /// </para>
    /// </summary>
    /// <typeparam name="TKey">主键类型</typeparam>
    /// <typeparam name="TData">要存取的实例对象</typeparam>
    public interface IRepository<TKey, TData>
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="data">添加的数据实例</param>
        /// <returns>添加实例的自增主键</returns>
        TKey Insert(TData data);
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="data">修改的数据实例</param>
        void Update(TData data);
        /// <summary>
        /// 物理删除
        /// </summary>
        /// <param name="key">主键</param>
        void DeleteByKey(TKey key);
        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <returns>返回所有实体列表</returns>
        List<TData> GetAll();
        /// <summary>
        /// 通过主键获取数据
        /// </summary>
        /// <param name="id">主键id</param>
        /// <returns>返回实体</returns>
        TData GetByKey(TKey id);


    }
}
