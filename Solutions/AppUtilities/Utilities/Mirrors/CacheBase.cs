using System;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using SmartSolution.Utilities.Patterns;
using SmartSolution.Utilities.Thread;

namespace SmartSolution.Utilities.Mirrors
{
    /// <summary>
    /// 缓存基类
    /// </summary>
    public abstract class CacheBase<TItem> : MsDispose where TItem : ICacheItem, new()
    {

        private readonly LockObject _lock = new LockObject();

        /// <summary>
        /// 锁定方式获取数据
        /// </summary>
        /// <param name="action"></param>
        protected void LockGetData(Action action)
        {
            _lock.LockExecute(action);
        }

        /// <summary>
        /// 缓存项
        /// </summary>
        protected ICacheItem CacheItem
        {
            get
            {
                // ReSharper disable once SuspiciousTypeConversion.Global
                var item = (ICacheItem) this;
                return item;
            }
        }

        /// <summary>
        /// 缓存键
        /// </summary>
        public abstract string CacheKey { get; }

        /// <summary>
        /// 确保数据最新
        /// ①检查缓存是否有效
        /// ②如果无效会调用GetDataFromRepository方法
        /// </summary>
        /// <returns></returns>
        public abstract void KeepCacheLastest();
        //{
        //    lock (typeof(TItem))
        //    {
        //        var lastModifyTime = CacheServiceAdapter.Instance.GetLastModifyTime(CacheItem.CacheKey);
        //        if (LastModifyTime >= lastModifyTime) return;
        //        var msg = $"缓存镜像{CacheItem.CacheKey}过期重建,时间{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}。";
        //        Logger.Write(msg);
        //        CacheItem.CacheExpire();
        //        CacheItem.GetCacheData();
        //        LastModifyTime = lastModifyTime;
        //    }
        //}

        /// <summary>
        /// 确保数据最新
        /// ①检查缓存是否有效
        /// ②如果无效会调用GetDataFromRepository方法
        /// </summary>
        /// <returns></returns>
        public abstract bool IsLastest();
        //{
        //    lock (typeof(TItem))
        //    {
        //        var lastModifyTime = CacheServiceAdapter.Instance.GetLastModifyTime(CacheItem.CacheKey);
        //        return LastModifyTime >= lastModifyTime;
        //    }
        //}

        /// <summary>
        /// 最后访问时间
        /// </summary>
        public DateTime LastModifyTime
        {
            get;
            set;
        }

        /// <summary>
        /// 释放非托管资源
        /// </summary>
        public override void ReleaseUnManagedResource()
        {
            CacheItem.CacheExpire();
        }

    }
}
