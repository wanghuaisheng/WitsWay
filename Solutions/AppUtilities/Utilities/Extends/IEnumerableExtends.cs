﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using WitsWay.Utilities.Guards;

namespace WitsWay.Utilities.Extends
{
    /// <summary>
    /// IEnumerable扩展信息
    /// </summary>
    public static class EnumerableExtensions
    {

        /// <summary>
        /// 是否为空
        /// </summary>
        public static bool IsNullOrEmpty(this IEnumerable lst)
        {
            if (lst == null) return true;
            return !lst.GetEnumerator().MoveNext();
        }

        /// <summary>
        /// 是否为空
        /// </summary>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> lst)
        {
            if (lst == null) return true;
            return !lst.Any();
        }


        /// <summary>
        /// 安全ForEach,当lst不为空，且lst中满足predicate条件的项存在时才执行循环操作
        /// </summary>
        /// <param name="lst">数据</param>
        /// <param name="action">循环执行方法体</param>
        /// <param name="predicate">循环筛选谓词，true执行，false不执行</param>
        /// <param name="changeList">循环执行方法体 是否变更了数据</param>
        public static void SafeForEach<T>(this IEnumerable<T> lst, Action<T> action, Func<T, bool> predicate = null, bool changeList = false)
        {
            ArgumentGuard.ArgumentNotNull("action", action);
            if (lst == null) { return; }
            var trueList = lst.Where(one => predicate == null || predicate(one));
            if (changeList) { trueList = trueList.ToArray(); }
            if (!trueList.IsNullOrEmpty())
            {
                foreach (var t in trueList)
                {
                    action(t);
                }
            }
        }

        /// <summary>
        /// 串联字符串集合的成员，其中在每个成员之间使用指定的分隔符（默认使用;）。
        /// </summary>
        /// <param name="source"></param>
        /// <param name="spliter"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string Join<T>(this IEnumerable<T> source, string spliter = ";")
        {
            return string.Join(spliter, source);
        }

    }
}