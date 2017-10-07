/******************************************
 * 2012��5��3�� ������ ���
 * 
 * ***************************************/

using System;
using System.Web;
using System.Web.Caching;

namespace WitsWay.Utilities.Web.Helpers
{
	/// <summary>
	/// Web���渨����
	/// </summary>
	public class WebCacheHelper
	{

		/// <summary>
		/// ���ϵͳ���л���
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
		/// ���key��Ӧ�Ļ���
		/// </summary>
		/// <param name="key">Key</param>
		public static void ClearCacheItem(string key) 
		{
			if (HttpRuntime.Cache[key] != null) 
			{
				HttpRuntime.Cache.Remove(key);
#if DEBUG
				HttpContext.Current.Trace.Warn("Cache", "������ " + key + " �Ƴ�");
#endif
			}
		}
		
		
		/// <summary>
		/// �Ƴ���Ӧ���͵����л���
		/// </summary>
		/// <param name="typeName">��������</param>
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
        /// �������ǰ׺Ϊprefix�Ļ���
        /// </summary>
        /// <param name="prefix">����Key��ǰ׺</param>
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
        /// ȡ�û�����
        /// </summary>
        /// <param name="cacheKey">����key</param>
        /// <returns></returns>
        public static object GetCacheItem(string cacheKey)
        {
            return HttpRuntime.Cache[cacheKey];
        }

        /// <summary>
        /// ȡ�û�����
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cacheKey">��������</param>
        /// <param name="syncLock">ͬ����</param>
        /// <param name="timeout">��ʱʱ��</param>
        /// <param name="func">��ȡ����ص�����</param>
        /// <returns></returns>
		public static T GetCacheItem<T>(string cacheKey, object syncLock,
			TimeSpan timeout, Func<T> func)
		{
			return GetCacheItem(cacheKey, syncLock, null, timeout, func);
		}

        /// <summary>
        /// ȡ�û�����
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cacheKey">��������</param>
        /// <param name="syncLock">ͬ����</param>
        /// <param name="timeout">��ʱʱ��</param>
        /// <param name="func">��ȡ����ص�����</param>
        /// <param name="refreshAction">�������Ƴ��ص�</param>
        /// <returns></returns>
		public static T GetCacheItem<T>(string cacheKey, object syncLock,
			CacheItemRemovedCallback refreshAction, TimeSpan timeout,
            Func<T> func)
		{
			return GetCacheItem(cacheKey, syncLock, CacheItemPriority.Normal, refreshAction, timeout, func);
		}

        /// <summary>
        /// ȡ�û�����
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cacheKey">��������</param>
        /// <param name="syncLock">ͬ����</param>
        /// <param name="timeout">��ʱʱ��</param>
        /// <param name="func">��ȡ����ص�����</param>
        /// <param name="refreshAction">�������Ƴ��ص�</param>
        /// <param name="priority">�������ȼ�</param>
        /// <returns></returns>
		public static T GetCacheItem<T>(string cacheKey, object syncLock,
			CacheItemPriority priority, CacheItemRemovedCallback refreshAction, TimeSpan timeout,
            Func<T> func)
		{
			return GetCacheItem(cacheKey, syncLock, priority, refreshAction, null, timeout, func);
		}

        /// <summary>
        /// ȡ�û�����
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cacheKey">��������</param>
        /// <param name="syncLock">ͬ����</param>
        /// <param name="timeout">��ʱʱ��</param>
        /// <param name="func">��ȡ����ص�����</param>
        /// <param name="refreshAction">�������Ƴ��ص�</param>
        /// <param name="priority">�������ȼ�</param>
        /// <param name="cacheDependency">����������</param>
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
