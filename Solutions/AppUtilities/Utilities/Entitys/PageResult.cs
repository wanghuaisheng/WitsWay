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
using System.Linq;

namespace WitsWay.Utilities.Entitys
{
    /// <summary>
    /// 分页结果集
    /// </summary>
    /// <typeparam name="T">分页实体</typeparam>
    public class PageResult<T>
    {
        private List<T> _rows;

        /// <summary>
        /// 当前页码
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// 每页显示条数
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Get总页数
        /// </summary>
        public int PageCount
        {
            get
            {
                return CalculateTotalPages(TotalRecordNum, PageSize);
            }
        }


        /// <summary>
        /// 总数据条数
        /// </summary>
        public int TotalRecordNum { get; set; }

        /// <summary>
        /// Get当前页数据
        /// </summary>
        public List<T> Rows
        {
            get { return _rows ?? (_rows = new List<T>()); }
        }

        /// <summary>
        /// 计算总页数
        /// </summary>
        /// <param name="totalRecords">总记录数</param>
        /// <param name="pageSize">每页条数</param>
        /// <returns>页数</returns>
        private static int CalculateTotalPages(int totalRecords, int pageSize)
        {
            if (totalRecords < 1 || pageSize < 1)
            {
                return 0;
            }
            var retval = totalRecords / pageSize;
            if ((totalRecords % pageSize) > 0)
            {
                retval++;
            }
            return retval;
        }

        /// <summary>
        /// 将一种类型的PageResult转为另外一种类型的PageResult
        /// </summary>
        /// <typeparam name="TAnother">要转成的类型</typeparam>
        /// <param name="converter">转换器</param>
        /// <returns></returns>
        public PageResult<TAnother> ConvertTo<TAnother>(Func<T, TAnother> converter) where TAnother : class ,new()
        {

            var newPageLst = new PageResult<TAnother>
            {
                PageIndex = PageIndex,
                PageSize = PageSize,
                TotalRecordNum = TotalRecordNum
            };

            newPageLst.Rows.AddRange(Rows.Select(converter));

            return newPageLst;
        }
    }

    /// <summary>
    /// 分页结果集扩展
    /// </summary>
    public static class PageResultExtends
    {
        /// <summary>
        /// 映射分页结果集
        /// </summary>
        /// <typeparam name="T1">源结果集类型</typeparam>
        /// <typeparam name="T2">目标结果集类型</typeparam>
        /// <param name="page">源分页结果集</param>
        /// <param name="expression">行转换方法</param>
        /// <returns>目标分页结果集</returns>
        public static PageResult<T2> MapPageResult<T1, T2>(this PageResult<T1> page, Func<T1, T2> expression)
        {
            var result = new PageResult<T2>
            {
                PageIndex = page.PageIndex,
                PageSize = page.PageSize,
                TotalRecordNum = page.TotalRecordNum
            };
            result.Rows.AddRange(page.Rows.Select(expression).ToList());
            return result;
        }

    }
}