/******************************************
 * 2012年5月3日 王怀生 添加
 * 
 * ***************************************/

using System;
using System.Collections.Generic;

namespace WitsWay.Utilities.Helpers
{

    /// <summary>
    /// 集合辅助类
    /// </summary>
    public class CollectionHelper
    {

        /// <summary>
        /// 转换列表为字典
        /// </summary>
        /// <typeparam name="TKey">键类型</typeparam>
        /// <typeparam name="TValue">值类型</typeparam>
        /// <param name="datas">数据列表</param>
        /// <param name="idFunc">返回对应数据的键</param>
        /// <returns>转换后的字典</returns>
        public static Dictionary<TKey, TValue> CastListToDictionary<TKey, TValue>(IList<TValue> datas, Func<TValue, TKey> idFunc)
        {
            var dic = new Dictionary<TKey, TValue>();
            if (datas != null && datas.Count > 0)
            {
                foreach (var data in datas)
                {
                    var id = idFunc(data);
                    dic[id] = data;
                }
            }
            return dic;
        }

    }
}
