//namespace SmartSolution.Utilities.Mirrors
//{

//    /// <summary>
//    /// 缓存管理器
//    /// </summary>
//    public partial class CacheManager
//    {

//        /// <summary>
//        /// 外部缓存(与ShareCache交互）
//        /// </summary>
//        public IExternalCacheWrapper ShareCache
//        {
//            get
//            {
//                return
//                    new ExternalCacheWrapper();
//            }

//        }

//        /// <summary>
//        /// 外部缓存
//        /// </summary>
//        private class ExternalCacheWrapper : IExternalCacheWrapper
//        {

//            #region [InternalCacheMethodWrapper]

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

//            #endregion

//            /// <summary>
//            /// 移除外部缓存
//            /// </summary>
//            /// <param name="url">缓存URL</param>
//            public void Remove(string url)
//            {
//                CacheServiceAdapter.Instance.Remove(url);
//            }

//            /// <summary>
//            /// 移除外部缓存
//            /// </summary>
//            /// <param name="domain">缓存域</param>
//            /// <param name="key">缓存键</param>
//            public void Remove(string domain, string key)
//            {
//                Remove(GetUrl(domain, key));
//            }

//            /// <summary>
//            /// 获取缓存数据
//            /// </summary>
//            /// <param name="url">缓存URL</param>
//            /// <returns>缓存数据</returns>
//            public TData GetData<TData>(string url)
//            {
//                return CacheServiceAdapter.Instance.GetData<TData>(url);
//            }

//            /// <summary>
//            /// 获取缓存数据
//            /// </summary>
//            /// <param name="domain">缓存域</param>
//            /// <param name="key">缓存键</param>
//            /// <returns>缓存数据</returns>
//            public TData GetData<TData>(string domain, string key)
//            {
//                return GetData<TData>(GetUrl(domain,key));
//            }

//            /// <summary>
//            /// 设置缓存数据
//            /// </summary>
//            /// <param name="info">缓存键</param>
//            /// <param name="data">缓存数据</param>
//            /// <param name="expireStrategys">缓存过期策略</param>
//            public void SetData<TData>(CacheInfo info, TData data, params IExpireStrategy[] expireStrategys)
//            {
//                CacheServiceAdapter.Instance.SetData(info, data, expireStrategys);
//            }

//            /// <summary>
//            /// 获取缓存数据
//            /// </summary>
//            /// <param name="domain">缓存域</param>
//            /// <param name="key">缓存键</param>
//            /// <returns>缓存数据</returns>
//            public string GetString(string domain, string key)
//            {
//                return GetString(GetUrl(domain,key));
//            }

//            /// <summary>
//            /// 获取缓存数据
//            /// </summary>
//            /// <param name="url">缓存URL</param>
//            /// <returns>缓存数据</returns>
//            public string GetString(string url)
//            {
//                return CacheServiceAdapter.Instance.GetString(url);
//            }

//            /// <summary>
//            /// 设置缓存数据
//            /// </summary>
//            /// <param name="data">缓存数据</param>
//            /// <param name="info">缓存基础信息</param>
//            /// <param name="expireStrategys">过期策略</param>
//            public void SetString(CacheInfo info, string data, params IExpireStrategy[] expireStrategys)
//            {
//                CacheServiceAdapter.Instance.SetString(info, data, expireStrategys);
//            }

//            /// <summary>
//            /// 获取URL
//            /// </summary>
//            private static string GetUrl(string domain, string key)
//            {
//                return $"{domain}/{key}";
//            }


//        }
//    }


//}