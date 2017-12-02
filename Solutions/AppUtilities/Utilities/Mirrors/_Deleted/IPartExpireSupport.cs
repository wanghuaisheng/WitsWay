//using System;
//using System.Collections.Generic;

//namespace SmartSolution.Utilities.Mirrors
//{
//    /// <summary>
//    /// 部分过期支持
//    /// </summary>
//    public interface IPartExpireSupport<TData>
//    {

//        /// <summary>
//        /// 取得部分过期检查参数
//        /// </summary>
//        /// <returns>Key-Timestamp过期检查参数</returns>
//        IEnumerable<Tuple<string, DateTime>> GetPartExpireCheckPara();

//        /// <summary>
//        /// 执行部分过期
//        /// </summary>
//        /// <param name="data">变更数据</param>
//        /// <param name="key">缓存数据Key</param>
//        /// <param name="changeType">数据变更类型</param>
//        void ExecutePartExpire(TData data, string key, ListDataChangeType changeType);
//    }
//}
