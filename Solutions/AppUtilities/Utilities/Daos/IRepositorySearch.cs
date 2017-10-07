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
using WitsWay.Utilities.Entitys;

namespace WitsWay.Utilities.Daos
{
    /// <summary>
    /// 数据存储通用接口（搜索数据，兼容历史调用方式）
    /// <para>多个TFilter通过实现多个接口实现</para>
    /// </summary>
    /// <typeparam name="TData">实体类型</typeparam>
    /// <typeparam name="TFilter">筛选对象类型</typeparam>
    public interface IRepositorySearch<TData, TFilter>
        where TData : class
        where TFilter : class
    {

        /// <summary>
        /// 获取分页结果集
        /// </summary>
        /// <param name="filter">筛选条件载体</param>
        /// <returns>分页结果集</returns>
        PageResult<TData> Search(PagerFilterPara<TFilter> filter);

    }
}
