/******************************************
 * 2012年5月3日 王怀生 添加
 * 
 * ***************************************/

using System;
using System.Web;
using System.Web.Caching;

namespace WitsWay.Utilities.Web.Helpers
{
	/// <summary>
	/// Web缓存辅助类
	/// </summary>
	public class WebCacheHelper
	{

		/// <summary>
		/// 清除系统所有缓存
		/// </summary>
		public static void ClearAllCache() 
		{
			Cache c = HttpRuntime.Cache;
			if (c != null) 
			{
				var cacheEnumerator = c.GetEnumerator();
				while ( cacheEnumerator.MoveNext() )
				{
					c.Remove(cacheEnumerator.Key.ToString());
				}
			}
		}
		
		/// <summary>
		/// 清除key对应的缓存
		/// </summary>
		/// <param name="key">Key</param>
		public static void ClearCacheItem(string key) 
		{
			if (HttpRuntime.Cache[key] != null) 
			{
				HttpRuntime.Cache.Remove(key);
#if DEBUG
				HttpContext.Current.Trace.Warn("Cache", "缓存项 " + key + " 移除");
#endif
			}
		}
		
		
		/// <summary>
		/// 移除对应类型的所有缓存
		/// </summary>
		/// <param name="typeName">对象类型</param>
		public static void ClearCacheObjectTypes(string typeName) 
		{
			Cache c = HttpRuntime.Cache;
			try 
			{
				if (c != null) 
				{
					var cacheEnumerator = c.GetEnumerator();
                    while (cacheEnumerator.MoveNext())
                    {
                        if (cacheEnumerator.Key != null 
                            && c[cacheEnumerator.Key.ToString()] != null 
                            && c[cacheEnumerator.Key.ToString()].GetType() != null 
                            && c[cacheEnumerator.Key.ToString()].GetType().ToString() == typeName)
                        {
                            c.Remove(cacheEnumerator.Key.ToString());
                        }
                    }
				}
			} 
			catch (Exception ex) 
			{
                Console.WriteLine(ex.Message);
            }
		}

        /// <summary>
        /// 清除所有前缀为prefix的缓存
        /// </summary>
        /// <param name="prefix">缓存Key的前缀</param>
        public static void ClearCacheByKeySearch(string prefix)
        {
            Cache c = HttpRuntime.Cache;
            if (c != null)
            {
                var cacheEnumerator = c.GetEnumerator();
                while (cacheEnumerator.MoveNext())
                {
                    if (cacheEnumerator.Key is string && ((string)cacheEnumerator.Key).StartsWith(prefix))
                    {
                        c.Remove((string)cacheEnumerator.Key);
                    }
                }
            }

        }
        /// <summary>
        /// 取得缓存项
        /// </summary>
        /// <param name="cacheKey">缓存key</param>
        /// <returns></returns>
        public static object GetCacheItem(string cacheKey)
        {
            return HttpRuntime.Cache[cacheKey];
        }

        /// <summary>
        /// 取得缓存项
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cacheKey">缓存主键</param>
        /// <param name="syncLock">同步锁</param>
        /// <param name="timeout">超时时间</param>
        /// <param name="func">获取缓存回调函数</param>
        /// <returns></returns>
		public static T GetCacheItem<T>(string cacheKey, object syncLock,
			TimeSpan timeout, Func<T> func)
		{
			return GetCacheItem(cacheKey, syncLock, null, timeout, func);
		}

        /// <summary>
        /// 取得缓存项
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cacheKey">缓存主键</param>
        /// <param name="syncLock">同步锁</param>
        /// <param name="timeout">超时时间</param>
        /// <param name="func">获取缓存回调函数</param>
        /// <param name="refreshAction">缓存项移除回调</param>
        /// <returns></returns>
		public static T GetCacheItem<T>(string cacheKey, object syncLock,
			CacheItemRemovedCallback refreshAction, TimeSpan timeout,
            Func<T> func)
		{
			return GetCacheItem(cacheKey, syncLock, CacheItemPriority.Normal, refreshAction, timeout, func);
		}

        /// <summary>
        /// 取得缓存项
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cacheKey">缓存主键</param>
        /// <param name="syncLock">同步锁</param>
        /// <param name="timeout">超时时间</param>
        /// <param name="func">获取缓存回调函数</param>
        /// <param name="refreshAction">缓存项移除回调</param>
        /// <param name="priority">缓存优先级</param>
        /// <returns></returns>
		public static T GetCacheItem<T>(string cacheKey, object syncLock,
			CacheItemPriority priority, CacheItemRemovedCallback refreshAction, TimeSpan timeout,
            Func<T> func)
		{
			return GetCacheItem(cacheKey, syncLock, priority, refreshAction, null, timeout, func);
		}

        /// <summary>
        /// 取得缓存项
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cacheKey">缓存主键</param>
        /// <param name="syncLock">同步锁</param>
        /// <param name="timeout">超时时间</param>
        /// <param name="func">获取缓存回调函数</param>
        /// <param name="refreshAction">缓存项移除回调</param>
        /// <param name="priority">缓存优先级</param>
        /// <param name="cacheDependency">缓存依赖项</param>
        /// <returns></returns>
		public static T GetCacheItem<T>(string cacheKey, object syncLock,
			CacheItemPriority priority, CacheItemRemovedCallback refreshAction,
            CacheDependency cacheDependency, TimeSpan timeout, Func<T> func)
		{
			object result = HttpRuntime.Cache.Get(cacheKey);
			if (result == null)
			{
				lock (syncLock)
				{
					result = HttpRuntime.Cache.Get(cacheKey);
					if (result == null)
					{
						result = func();
						HttpRuntime.Cache.Add(cacheKey, result, cacheDependency,
							DateTime.Now.Add(timeout), TimeSpan.Zero, priority, refreshAction);
					}
				}
			}
			return (T)result;
		}
	}
}
