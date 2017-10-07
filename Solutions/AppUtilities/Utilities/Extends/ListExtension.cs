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
using WitsWay.Utilities.Guards;

namespace WitsWay.Utilities.Extends
{
    /// <summary>
    /// <see cref="System.Collections.Generic.List{T}"/> 扩展方法
    /// </summary>
    public static class ListExtensions
    {
        /// <summary>
        /// Moves the item matching the <paramref name="itemSelector"/> to the end of the <paramref name="list"/>.
        /// </summary>
        public static void MoveToEnd<T>(this List<T> list, Predicate<T> itemSelector)
        {
            ArgumentGuard.ArgumentNotNull("list", list);
            if (list.Count > 1)
                list.Move(itemSelector, list.Count - 1);
        }

        /// <summary>
        /// Moves the item matching the <paramref name="itemSelector"/> to the beginning of the <paramref name="list"/>.
        /// </summary>
        public static void MoveToBeginning<T>(this List<T> list, Predicate<T> itemSelector)
        {
            ArgumentGuard.ArgumentNotNull("list", list);
            list.Move(itemSelector, 0);
        }

        /// <summary>
        /// 上移
        /// </summary>
        public static void MoveUp<T>(this List<T> list, T item)
        {
            if (list.IsNullOrEmpty() || item == null)
                return;

            var currIndex = list.IndexOf(item);

            if (currIndex <= 0)
                return;

            // 交换当前元素与上一元素
            list[currIndex] = list[currIndex - 1];
            list[currIndex - 1] = item;
        }

        /// <summary>
        /// 下移
        /// </summary>
        public static void MoveDown<T>(this List<T> list, T item)
        {
            if (list.IsNullOrEmpty() || item == null)
                return;

            var currIndex = list.IndexOf(item);

            if (currIndex < 0 || currIndex == list.Count - 1)
                return;

            // 交换当前元素与下一元素
            list[currIndex] = list[currIndex + 1];
            list[currIndex + 1] = item;
        }

        /// <summary>
        /// Moves the item matching the <paramref name="itemSelector"/> to the <paramref name="newIndex"/> in the <paramref name="list"/>.
        /// </summary>
        public static void Move<T>(this List<T> list, Predicate<T> itemSelector, int newIndex)
        {
            ArgumentGuard.ArgumentNotNull("list", list);
            ArgumentGuard.ArgumentNotNull("itemSelector", itemSelector);

            if (newIndex < 0)
                return;

            var currentIndex = list.FindIndex(itemSelector);
            if (currentIndex < 0)
                return;

            if (currentIndex == newIndex)
                return;

            // Copy the item
            var item = list[currentIndex];

            // Remove the item from the list
            list.RemoveAt(currentIndex);

            // Finally insert the item at the new index
            list.Insert(newIndex, item);
        }
    }
}
