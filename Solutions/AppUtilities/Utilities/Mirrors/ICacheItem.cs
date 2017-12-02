using System;

namespace SmartSolution.Utilities.Mirrors
{
    /// <summary>
    /// 缓存项接口
    /// </summary>
    public interface ICacheItem : IDisposable
    {

        /// <summary>
        /// 缓存键
        /// </summary>
        string CacheKey { get; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        DateTime LastModifyTime { get; }

        /// <summary>
        /// 缓存过期
        /// </summary>
        void CacheExpire();

        /// <summary>
        /// 从存储器获取数据
        /// </summary>
        void GetCacheData();


    }
}
