//using SmartSolution.Utilities.Supports;

//namespace SmartSolution.Utilities.Mirrors
//{
//    /// <summary>
//    /// 缓存基类
//    /// </summary>
//    public abstract class CacheBaseMirror<TItem, TData> : CacheBase<TItem>
//        where TItem : ICacheItem, new()
//        where TData : IKey
//    {

//        /// <summary>
//        /// 内部缓存(与ShareCache交互）
//        /// <para>包含GetList、GetOne、Add、Edit等方法</para>
//        /// </summary>
//        public IInternalCacheWrapper<TData> ShareCache
//        {
//            get
//            {
//                return new InternalCacheWrapper<TData>(CacheKey);

//            }
//        }

//    }
//}
