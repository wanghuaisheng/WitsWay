using System;
using System.Collections.Generic;
using System.Linq;
using WitsWay.Utilities.Entitys;

namespace WitsWay.Utilities.Helpers
{
    /// <summary>
    /// 显示转换辅助类
    /// </summary>
    public class ShowCastHelper
    {

        /// <summary>
        /// 转换列表
        /// </summary>
        /// <typeparam name="T1">要转换的类型</typeparam>
        /// <typeparam name="T2">转换后的类型</typeparam>
        /// <param name="datas">要转换的对象列表</param>
        /// <param name="aToB">转换方法委托</param>
        /// <returns>转换后的对象列表</returns>
        public static List<T2> CastList<T1, T2>(List<T1> datas, Func<T1, T2> aToB)
            where T1 : class,new()
            where T2 : class,new()
        {
            return (datas ?? new List<T1>()).Select(t1 => { return aToB(t1); }).ToList();
        }

        /// <summary>
        /// 转换分页结果集
        /// </summary>
        /// <typeparam name="T1">要转换的类型</typeparam>
        /// <typeparam name="T2">转换后的类型</typeparam>
        /// <param name="page">要转换的结果集</param>
        /// <param name="aToB">转换方法委托</param>
        /// <returns>转换后的结果集</returns>
        public static PageResult<T2> CastPageResult<T1, T2>(PageResult<T1> page, Func<T1, T2> aToB)
            where T1 : class,new()
            where T2 : class,new()
        {
            if (page != null)
            {
                var result = new PageResult<T2>();
                result.PageIndex = page.PageIndex;
                result.PageSize = page.PageSize;
                result.TotalRecordNum = page.TotalRecordNum;
                if (page.Rows != null && page.Rows.Count > 0)
                {
                    result.Rows.AddRange(page.Rows.Select(info =>
                    {
                        return aToB(info);
                    }));
                }
                return result;
            }
            return null;
        }
    }
}