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
using System.Collections.Generic;

namespace WitsWay.Utilities.Daos
{
    /// <summary>
    /// 数据存储通用接口（存在判断）
    /// <para>
    /// 包含ExistKey、ExistKeys、ExistByClause
    /// </para>
    /// </summary>
    /// <typeparam name="TKey">主键类型</typeparam>
    public interface IRepositoryExist<TKey>
    {

        /// <summary>
        /// 是否存在对应主键的数据
        /// </summary>
        /// <param name="key">主键</param>
        /// <returns>存在true，不存在false</returns>
        bool ExistKey(TKey key);
        /// <summary>
        /// 是否存在页面项
        /// </summary>
        /// <param name="keys">id</param>
        /// <returns>存在数据条数</returns>
        int ExistKeys(IList<TKey> keys);
        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="filterClause">筛选语句</param>
        /// <returns>存在true，不存在false</returns>
        bool ExistByClause(string filterClause);
    }
}
