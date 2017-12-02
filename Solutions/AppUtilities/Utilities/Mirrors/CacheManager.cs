using System;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using SmartSolution.Utilities.Errors;
using SmartSolution.Utilities.Extends;
using SmartSolution.Utilities.Helpers;
using SmartSolution.Utilities.Patterns;
using SmartSolution.Utilities.Thread;

namespace SmartSolution.Utilities.Mirrors
{
    /// <summary>
    /// 缓存管理器
    /// </summary>
    public class CacheManager
    {

        /// <summary>
        /// 取得CacheManager单键实例
        /// </summary>
        public static CacheManager Instance => Singleton<CacheManager>.Instance;

        /// <summary>
        /// 锁
        /// </summary>
        private readonly LockObject _locker = new LockObject();

        /// <summary>
        /// 缓存项
        /// </summary>
        private static readonly Dictionary<Type, ICacheItem> CacheItems = new Dictionary<Type, ICacheItem>();

        /// <summary>
        /// 取得缓存
        /// </summary>
        /// <typeparam name="T">缓存项类型</typeparam>
        /// <returns>缓存项实例</returns>
        public T GetCache<T>(bool keepLastest = true) where T : CacheBase<T>, ICacheItem, new()
        {
            var t = typeof(T);
            if (CacheItems.ContainsKey(t))
            {
                var existItem = CacheItems[t] as T;
                if (!keepLastest) return existItem;
                if (existItem.IsLastest()) return existItem;
            }
            _locker.LockExecute(() =>
            {
                CreateCacheItem<T>(t);
            });
            return CacheItems[t] as T;
        }

        private void CreateCacheItem<T>(Type t) where T : CacheBase<T>, ICacheItem, new()
        {
            try
            {
                var obj = t.GetInstance();
                var tempItem = obj as T;
                var key = tempItem.CacheKey;
                if (string.IsNullOrEmpty(key))
                {
                    ExceptionHelper.ThrowProgramException(@"缓存键为空", UtilityErrors.ArgumentErrorException);
                }
                tempItem.KeepCacheLastest();
                CacheItems[t] = tempItem;
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                var msg = @"无法创建缓存项:" + t.Name;
                ExceptionHelper.ThrowProgramException(msg, UtilityErrors.InternalProgramError);
            }
        }
    }
}