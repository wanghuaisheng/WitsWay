//using System;
//using System.Collections.Generic;
//using SmartSolution.Utilities.Supports;

//namespace SmartSolution.Utilities.Mirrors
//{

//    /// <summary>
//    /// 内部缓存包装
//    /// </summary>
//    public class InternalCacheWrapper<TEntity> : IInternalCacheWrapper<TEntity> where TEntity : IKey
//    {

//        #region [InternalCacheWrapper<TEntity>]
//        /// <summary>
//        /// 缓存键
//        /// </summary>
//        string CacheKey { get; set; }

//        /// <summary>
//        /// 内部缓存包装
//        /// </summary>
//        /// <param name="key"></param>
//        public InternalCacheWrapper(string key)
//        {
//            CacheKey = key;
//        }

//        /// <summary>
//        /// 获取数据泛型列表
//        /// </summary>
//        /// <returns>数据泛型列表</returns>
//        public List<TEntity> GetList()
//        {
//            return CacheServiceAdapter.Instance.GetData<List<TEntity>>(CacheKey);
//        }

//        /// <summary>
//        /// 获取一个数据
//        /// </summary>
//        /// <returns>数据</returns>
//        public TEntity GetOne(string id)
//        {
//            return CacheServiceAdapter.Instance.GetOne<TEntity, string>(CacheKey, id);
//        }

//        /// <summary>
//        /// 添加数据
//        /// </summary>
//        /// <param name="data">要添加的数据</param>
//        public void Add(TEntity data)
//        {
//            CacheServiceAdapter.Instance.Add(CacheKey, data);
//        }

//        /// <summary>
//        /// 修改数据
//        /// </summary>
//        /// <param name="data">要修改的数据</param>
//        public void Edit(TEntity data)
//        {
//            CacheServiceAdapter.Instance.Edit(CacheKey, data);
//        }

//        #endregion


//        #region [InternalCacheWrapper]


//        /// <summary>
//        /// 过期缓存
//        /// <para>过期后不一定重建缓存，取决于缓存项自身设置</para>
//        /// </summary>
//        public void Expire()
//        {
//            CacheServiceAdapter.Instance.Expire(CacheKey);
//        }
//        /// <summary>
//        /// 部分过期
//        /// </summary>
//        /// <param name="id">要过期的数据Id</param>
//        public void PartyExpire(string id)
//        {
//            CacheServiceAdapter.Instance.PartyExpire(CacheKey, id);
//        }

//        /// <summary>
//        /// 重建缓存项
//        /// </summary>
//        public void Rebuild()
//        {
//            CacheServiceAdapter.Instance.Rebuild(CacheKey);
//        }

//        /// <summary>
//        /// 删除数据
//        /// </summary>
//        /// <param name="id">编号</param>
//        public void Delete(string id)
//        {
//            CacheServiceAdapter.Instance.Delete(CacheKey, id);
//        }
//        /// <summary>
//        /// 是否存在数据
//        /// </summary>
//        /// <param name="id">键</param>
//        public bool Exist(string id)
//        {
//            return CacheServiceAdapter.Instance.Exist(CacheKey, id);
//        }
//        /// <summary>
//        /// 获取缓存项最后修改时间
//        /// </summary>
//        /// <returns>缓存项最后修改时间</returns>
//        public DateTime GetLastModifyTime()
//        {
//            return CacheServiceAdapter.Instance.GetLastModifyTime(CacheKey);
//        }

//        #endregion


//    }

//}

