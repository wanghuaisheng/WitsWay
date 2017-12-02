//using DotNetSoft.CommonLibrary.ShareCache.Adapter;
//using DotNetSoft.ERP.Util;
//using DotNetSoft.Utilities.Extends;
//using DotNetSoft.Utilities.Helpers;
//using DotNetSoft.Utilities.Patterns;
//using DotNetSoft.Utilities.Thread;
//using System;
//using System.Collections.Generic;
//using DotNetSoft.CommonLibrary.ShareCache;
//using DotNetSoft.CommonLibrary.ShareCache.IService;
//using DotNetSoft.Utilities.Guards;
//using DotNetSoft.Utilities.Supports;
//
//namespace DotNetSoft.ERP.BusinessLogicLayer.Caches
//{
//
//    /// <summary>
//    /// 缓存管理器
//    /// </summary>
//    public partial class CacheManager
//    {
//
//        /// <summary>
//        /// 内部缓存(与ShareCache交互）
//        /// <para>包含ExecuteMethod、ExecuteAction</para>
//        /// </summary>
//        public IInternalCacheMethodWrapper InternalCache()
//        {
//            return new InternalCacheMethodWrapper();
//        }
//
//        /// <summary>
//        /// 内部缓存(与ShareCache交互）
//        /// <para>包含PartyExpire、Expire、Rebuild、Delete、Exist、GetLastModifyTime</para>
//        /// </summary>
//        /// <typeparam name="TCacheItem">缓存项类型</typeparam>
//        public IInternalCacheWrapper InternalCache<TCacheItem>()
//            where TCacheItem : CacheBase<TCacheItem>, ICacheItem, new()
//        {
//            var t = typeof(TCacheItem);
//            var cacheItem = GetCacheOnly<TCacheItem>();
//            var key = cacheItem.CacheKey;
//            return new InternalCacheWrapper(key);
//        }
//
//
//        /// <summary>
//        /// 内部缓存(与ShareCache交互）
//        /// <para>包含GetList、GetOne、Add、Edit</para>
//        /// </summary>
//        /// <typeparam name="TCacheItem">缓存项类型</typeparam>
//        /// <typeparam name="TEntity">缓存实体类型</typeparam>
//        public IInternalCacheWrapper<TEntity> InternalCache<TCacheItem, TEntity>()
//            where TCacheItem : CacheBase<TCacheItem>, ICacheItem, new()
//            where TEntity : IKey
//        {
//            var t = typeof(TCacheItem);
//            var cacheItem = GetCacheOnly<TCacheItem>();
//            var key = cacheItem.CacheKey;
//            return new InternalCacheWrapper<TEntity>(key);
//        }
//
//        /// <summary>
//        /// 内部缓存包装
//        /// </summary>
//        private class InternalCacheWrapper<TEntity> : IInternalCacheWrapper<TEntity> where TEntity : IKey
//        {
//
//            /// <summary>
//            /// 缓存键
//            /// </summary>
//            string CacheKey { get; set; }
//
//            /// <summary>
//            /// 内部缓存包装
//            /// </summary>
//            /// <param name="key"></param>
//            public InternalCacheWrapper(string key)
//            {
//                this.CacheKey = key;
//            }
//
//            /// <summary>
//            /// 获取数据泛型列表
//            /// </summary>
//            /// <returns>数据泛型列表</returns>
//            public List<TEntity> GetList()
//            {
//                return CacheServiceAdapter.Instance.GetData<List<TEntity>>(CacheKey);
//            }
//
//            /// <summary>
//            /// 获取一个数据
//            /// </summary>
//            /// <returns>数据</returns>
//            public TEntity GetOne(string id)
//            {
//                return CacheServiceAdapter.Instance.GetOne<TEntity, string>(CacheKey, id);
//            }
//
//            /// <summary>
//            /// 添加数据
//            /// </summary>
//            /// <param name="data">要添加的数据</param>
//            public void Add(TEntity data)
//            {
//                CacheServiceAdapter.Instance.Add(CacheKey, data);
//            }
//
//            /// <summary>
//            /// 修改数据
//            /// </summary>
//            /// <param name="data">要修改的数据</param>
//            public void Edit(TEntity data)
//            {
//                CacheServiceAdapter.Instance.Edit(CacheKey, data);
//            }
//
//        }
//
//        /// <summary>
//        /// 内部缓存包装
//        /// </summary>
//        private class InternalCacheWrapper : IInternalCacheWrapper
//        {
//
//            /// <summary>
//            /// 缓存键
//            /// </summary>
//            string CacheKey { get; set; }
//
//            /// <summary>
//            /// 内部缓存包装
//            /// </summary>
//            /// <param name="key"></param>
//            public InternalCacheWrapper(string key)
//            {
//                this.CacheKey = key;
//            }
//
//            /// <summary>
//            /// 过期缓存
//            /// <para>过期后不一定重建缓存，取决于缓存项自身设置</para>
//            /// </summary>
//            public void Expire()
//            {
//                CacheServiceAdapter.Instance.Expire(CacheKey);
//            }
//            /// <summary>
//            /// 部分过期
//            /// </summary>
//            /// <param name="id">要过期的数据Id</param>
//            public void PartyExpire(string id)
//            {
//                CacheServiceAdapter.Instance.PartyExpire(CacheKey, id);
//            }
//
//            /// <summary>
//            /// 重建缓存项
//            /// </summary>
//            public void Rebuild()
//            {
//                CacheServiceAdapter.Instance.Rebuild(CacheKey);
//            }
//
//            /// <summary>
//            /// 删除数据
//            /// </summary>
//            /// <param name="id">编号</param>
//            public void Delete(string id)
//            {
//                CacheServiceAdapter.Instance.Delete(CacheKey, id);
//            }
//            /// <summary>
//            /// 是否存在数据
//            /// </summary>
//            /// <param name="id">键</param>
//            public bool Exist(string id)
//            {
//                return CacheServiceAdapter.Instance.Exist(CacheKey, id);
//            }
//            /// <summary>
//            /// 获取缓存项最后修改时间
//            /// </summary>
//            /// <returns>缓存项最后修改时间</returns>
//            public DateTime GetLastModifyTime()
//            {
//                return CacheServiceAdapter.Instance.GetLastModifyTime(CacheKey);
//            }
//
//        }
//
//        /// <summary>
//        /// 内部缓存包装
//        /// </summary>
//        private class InternalCacheMethodWrapper : IInternalCacheMethodWrapper
//        {
//
//            /// <summary>
//            /// 执行服务端方法，有返回值
//            /// </summary>
//            /// <typeparam name="TResult">返回类型</typeparam>
//            /// <param name="url">方法URL</param>
//            /// <param name="parameters">参数列表</param>
//            /// <returns>方法返回对象</returns>
//            public TResult ExecuteMethod<TResult>(string url, params object[] parameters)
//            {
//                return CacheServiceAdapter.Instance.ExecuteMethod<TResult>(url, parameters);
//            }
//            /// <summary>
//            /// 执行服务端方法，无返回值
//            /// </summary>
//            /// <param name="url">方法URL</param>
//            /// <param name="parameters"></param>
//            public void ExecuteAction(string url, params object[] parameters)
//            {
//                CacheServiceAdapter.Instance.ExecuteAction(url, parameters);
//            }
//
//        }
//    }
//
//
//}
