//namespace SmartSolution.Utilities.Mirrors
//{

//    /// <summary>
//    /// 外部缓存接口
//    /// </summary>
//    public interface IExternalCacheWrapper : IInternalCacheMethodWrapper
//    {
//        /// <summary>
//        /// 移除外部缓存
//        /// </summary>
//        /// <param name="url">缓存URL</param>
//        void Remove(string url);
//        /// <summary>
//        /// 移除外部缓存
//        /// </summary>
//        /// <param name="domain">缓存域</param>
//        /// <param name="key">缓存键</param>
//        void Remove(string domain, string key);

//        /// <summary>
//        /// 获取缓存数据
//        /// </summary>
//        /// <param name="url">缓存URL</param>
//        /// <returns>缓存数据</returns>
//        TData GetData<TData>(string url);
//        /// <summary>
//        /// 获取缓存数据
//        /// </summary>
//        /// <param name="domain">缓存域</param>
//        /// <param name="key">缓存键</param>
//        /// <returns>缓存数据</returns>
//        TData GetData<TData>(string domain, string key);
//        /// <summary>
//        /// 设置缓存数据
//        /// </summary>
//        /// <param name="info">缓存键</param>
//        /// <param name="data">缓存数据</param>
//        /// <param name="expireStrategys">缓存过期策略</param>
//        void SetData<TData>(CacheInfo info, TData data, params IExpireStrategy[] expireStrategys);

//        /// <summary>
//        /// 获取缓存数据
//        /// </summary>
//        /// <param name="url">缓存URL</param>
//        /// <returns>缓存数据</returns>
//        string GetString(string url);

//        /// <summary>
//        /// 获取缓存数据
//        /// </summary>
//        /// <param name="domain">缓存域</param>
//        /// <param name="key">缓存键</param>
//        /// <returns>缓存数据</returns>
//        string GetString(string domain, string key);

//        /// <summary>
//        /// 设置缓存数据
//        /// </summary>
//        /// <param name="data">缓存数据</param>
//        /// <param name="info">缓存基础信息</param>
//        /// <param name="expireStrategys">过期策略</param>
//        void SetString(CacheInfo info, string data, params IExpireStrategy[] expireStrategys);

//    }
//}
