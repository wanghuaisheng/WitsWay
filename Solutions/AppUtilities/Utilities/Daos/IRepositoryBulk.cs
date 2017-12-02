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
using System.Data.SqlClient;
using WitsWay.Utilities.Entitys;

namespace WitsWay.Utilities.Daos
{
    /// <summary>
    /// 数据存储通用接口（批量操作）
    /// <para>
    /// 包含BulkDelete、BulkInsert、BulkUpdate、BulkSync
    /// </para>
    /// </summary>
    /// <typeparam name="TData">要存取的实例对象</typeparam>
    /// <typeparam name="TKey">键类型</typeparam>
    public interface IRepositoryBulk<TKey, TData>
    {
        /// <summary>
        /// 通过主键列表删除数据
        /// </summary>
        /// <param name="keys">主键列表</param>
        /// <returns>删除条数</returns>
        int BulkDelete(IList<TKey> keys);
        /// <summary>
        /// 批量获取
        /// </summary>
        /// <param name="keys">键列表</param>
        /// <returns>数据列表</returns>
        List<TData> BulkGetByKeys(IList<TKey> keys);
        /// <summary>
        /// 批量插入
        /// </summary>
        /// <param name="datas">实体列表</param>
        /// <returns>批量插入结果</returns>
        List<BulkInsertResult> BulkInsert(IList<TData> datas, SqlTransaction tran);
        /// <summary>
        /// 批量更新
        /// </summary>
        /// <param name="datas">实体列表</param>
        List<BulkInsertResult> BulkUpdate(IList<TData> datas, SqlTransaction tran);
        /// <summary>
        /// 批量同步（插入、更新、删除）
        /// </summary>
        /// <param name="datas">实体列表</param>
        List<BulkInsertResult> BulkSync(IList<TData> datas, SqlTransaction tran);

    }
}