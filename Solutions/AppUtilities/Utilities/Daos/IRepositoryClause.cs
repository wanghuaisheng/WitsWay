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
using WitsWay.Utilities.Entitys;

namespace WitsWay.Utilities.Daos
{
    /// <summary>
    /// 数据存储通用接口（筛选语句）
    /// <para>
    /// 包含DeleteByClause、GetOneByClause、GetListByClause、GetPageByClause
    /// </para>
    /// </summary>
    /// <typeparam name="TData">要存取的实例对象</typeparam>
    public interface IRepositoryClause<TData>
    {
        /// <summary>
        /// 物理删除
        /// </summary>
        /// <param name="filterClause">过滤语句</param>
        void DeleteByClause(string filterClause);

        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="filterClause">筛选语句</param>
        /// <param name="sortColumns">排序列</param>
        /// <returns>分页结果集</returns>
        TData GetOneByClause(string filterClause, List<SortColumn> sortColumns = null);
        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="filterClause">筛选语句</param>
        /// <returns>分页结果集</returns>
        List<TData> GetListByClause(string filterClause);
        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="pageParameter">分页参数</param>
        /// <param name="filterClause">筛选语句</param>
        /// <returns>分页结果集</returns>
        PageResult<TData> GetPageByClause(PageParameter pageParameter, string filterClause);

    }
}
