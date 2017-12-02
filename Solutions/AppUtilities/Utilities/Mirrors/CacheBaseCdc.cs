using System;
using System.ComponentModel;
using System.Linq;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using SmartSolution.Utilities.Helpers;
using SmartSolution.Utilities.Supports;

namespace SmartSolution.Utilities.Mirrors
{
    /// <summary>
    /// 缓存基类
    /// </summary>
    public abstract class CacheBasePart<TItem, TData> : CacheBase<TItem>
        where TItem : ICacheItem, new()//, IPartExpireSupport<TData>
        where TData : IKey
    {

        ///// <summary>
        ///// 内部缓存(与ShareCache交互）
        ///// <para>包含GetList、GetOne、Add、Edit等方法</para>
        ///// </summary>
        //public IInternalCacheWrapper<TData> ShareCache
        //{
        //    get
        //    {
        //        return new InternalCacheWrapper<TData>(CacheKey);

        //    }
        //}

        /// <summary>
        /// 确保数据最新
        /// ①检查缓存是否有效
        /// ②如果无效会调用GetDataFromRepository方法
        /// </summary>
        /// <returns></returns>
        public override void KeepCacheLastest()
        {
            lock (typeof(TItem))
            {
                //var lastModifyTime = CacheServiceAdapter.Instance.GetLastModifyTime(CacheItem.CacheKey);
                //if (LastModifyTime < lastModifyTime)
                //{
                //    if (!DataLoaded)
                //    {
                //        CacheItem.CacheExpire();
                //        CacheItem.GetCacheData();
                //        DataLoaded = true;
                //    }
                //    else
                //    {
                //        CheckPartExpire();
                //    }
                //    LastModifyTime = lastModifyTime;
                //}
            }
        }

        /// <summary>
        /// 数据是否已经加载
        /// </summary>
        [DefaultValue(false)]
        public bool DataLoaded { get; private set; }

        /// <summary>
        /// 检查部分过期
        /// </summary>
        public void CheckPartExpire()
        {
            ////var partItem = this as IPartExpireSupport<TData>;
            ////var typeD = typeof(TData);
            ////var interfaces = typeD.GetInterfaces();
            ////var isIKey = interfaces != null && interfaces.Any(t => t == typeof(IKey));
            ////var isITimestamp = interfaces != null && interfaces.Any(t => t == typeof(ITimestamp));
            ////if (isIKey && isITimestamp)
            ////{
            ////    var keyTimestamp = partItem.GetPartExpireCheckPara();
            ////    var changedDatas = CacheServiceAdapter.Instance.GetChangedData<TData>(CacheItem.CacheKey, keyTimestamp);
            ////    if (changedDatas == null) { return; }
            ////    changedDatas.ChangedDatas.SafeForEach(newData =>
            ////    {
            ////        var msg = $"缓存镜像{CacheItem.CacheKey}部分过期，有变更数据,时间{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}。";
            ////        Logger.Write(msg);
            ////        var keyData = newData as IKey;
            ////        partItem.ExecutePartExpire(newData, keyData.Key, ListDataChangeType.Edit);
            ////    });
            ////    changedDatas.AppendDatas.SafeForEach(newData =>
            ////    {
            ////        var msg = $"缓存镜像{CacheItem.CacheKey}部分过期，有新增数据,时间{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}。";
            ////        Logger.Write(msg);
            ////        var keyData = newData as IKey;
            ////        partItem.ExecutePartExpire(newData, keyData.Key, ListDataChangeType.Add);
            ////    });
            ////    changedDatas.DeletedKeys.SafeForEach(key =>
            ////    {
            ////        var msg = $"缓存镜像{CacheItem.CacheKey}部分过期，有删除数据,时间{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}。";
            ////        Logger.Write(msg);
            ////        partItem.ExecutePartExpire(default(TData), key, ListDataChangeType.Remove);
            ////    });
            ////}
            ////else
            ////{
            ////    ExceptionHelper.ThrowBusinessException(ShareCacheErrors.PartExpireDataNeedImplementIKeyAndITimestamp);
            ////}
        }

    }
}
