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

namespace WitsWay.Utilities.Builders
{
    /// <summary>
    /// 分页参数构建器
    /// </summary>
    public class PageParameterBuilder
    {
        /// <summary>
        /// 取得Builder实例
        /// </summary>
        /// <returns>新的Builder实例</returns>
        public static PageParameterBuilder NewBuilder()
        {
            return new PageParameterBuilder();
        }
        private readonly PageParameter _para = new PageParameter { SortColumns = new List<SortColumn>() };
        /// <summary>
        /// 构建结果
        /// </summary>
        public PageParameter Result => _para;

        /// <summary>
        /// 第几页
        /// </summary>
        /// <returns>分页参数构建器</returns>
        public PageParameterBuilder PageIndex(int pageIndex)
        {
            _para.PageIndex = pageIndex;
            return this;
        }
        /// <summary>
        /// 每页条数
        /// </summary>
        /// <returns>分页参数构建器</returns>
        public PageParameterBuilder PageSize(int pageSize)
        {
            _para.PageSize = pageSize;
            return this;
        }
        /// <summary>
        /// 排序列
        /// </summary>
        /// <param name="field">字段</param>
        /// <param name="assend">是否升序</param>
        /// <returns>分页参数构建器</returns>
        public PageParameterBuilder SortColumn(string field, bool assend)
        {
            _para.SortColumns.Add(new SortColumn { SortField = field, Ascend = assend });
            return this;
        }
    }
}
