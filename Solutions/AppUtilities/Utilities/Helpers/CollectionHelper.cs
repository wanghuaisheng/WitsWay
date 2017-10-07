#region License(Apache Version 2.0)
/******************************************
 * Copyright ®2017-Now WangHuaiSheng.
 * Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file
 * except in compliance with the License. You may obtain a copy of the License at
 * http://www.apache.org/licenses/LICENSE-2.0
 * Unless required by applicable law or agreed to in writing, software distributed under the
 * License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
 * either express or implied. See the License for the specific language governing permissions
 * and limitations under the License.
 * Detail: https://github.com/WangHuaiSheng/WitsWay/LICENSE
 * ***************************************/
#endregion 
#region ChangeLog
/******************************************
 * 2017-10-7 OutMan Create
 * 
 * ***************************************/
#endregion
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
