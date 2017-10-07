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
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;
using WitsWay.Utilities.Supports.TreeSupport;
using WitsWay.Utilities.Win.Helpers;

namespace WitsWay.Utilities.Win.Extends
{
    /// <summary>
    /// XtraTree扩展类
    /// </summary>
    public static class TreeListExtends
    {

        /// <summary>
        /// 初始化TreeList筛选器
        /// </summary>
        public static T GetFocusData<T>(this TreeList tree) where T : TreeSupport<T>
        {
            var data = tree?.FocusedNode?.GetTag<T>(WinUtilityConsts.TreeListNodeBindDataTagKey);
            return data;
        }

        /// <summary>
        /// 初始化TreeList筛选器
        /// </summary>
        public static List<T> GetTreeDatas<T>(this TreeList tree) where T : TreeSupport<T>
        {
            return tree?.GetTag<List<T>>(WinUtilityConsts.TreeListBindDatasTagKey);
        }
        /// <summary>
        /// 初始化TreeList筛选器
        /// </summary>
        public static void FilterInit(this TreeList tree, TextEdit editor, bool immediate = true)
        {
            var filter = tree.GetTag<TreeFilterHelper>(WinUtilityConsts.TreeListFilterTagKey);
            if (filter != null) return;
            filter = new TreeFilterHelper(tree, editor, immediate);
            tree.SetTag(WinUtilityConsts.TreeListFilterTagKey, filter);
        }

        /// <summary>
        /// TreeList筛选文字
        /// </summary>
        public static void FilterText(this TreeList tree, string text)
        {
            var filter = tree.GetTag<TreeFilterHelper>(WinUtilityConsts.TreeListFilterTagKey);
            filter?.FilterText(text);
        }

        /// <summary>
        /// 清除TreeList筛选
        /// </summary>
        public static void FilterClear(this TreeList tree)
        {
            var filter = tree.GetTag<TreeFilterHelper>(WinUtilityConsts.TreeListFilterTagKey);
            filter?.ClearFilter();
        }

        /// <summary>
        /// 为TreeList绑定PopupMenu
        /// </summary>
        public static void BindPopup<T>(this TreeList tree, PopupMenu popup, Predicate<T> func = null) where T : TreeSupport<T>
        {
            var helper = tree.GetTag<TreeListPopupHelper<T>>(WinUtilityConsts.TreeListPopupMenuHelperTagKey);
            if (helper == null)
            {
                helper = new TreeListPopupHelper<T>();
                tree.SetTag(WinUtilityConsts.TreeListPopupMenuHelperTagKey, helper);
            }
            helper.BindPopupMenu(tree, popup, func);
        }

    }
}
