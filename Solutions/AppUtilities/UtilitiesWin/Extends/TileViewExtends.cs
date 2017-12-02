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
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils;
 using DevExpress.XtraBars;
 using DevExpress.XtraGrid.Views.Tile;
using WitsWay.Utilities.Supports;
using WitsWay.Utilities.Win.Entities;

namespace WitsWay.Utilities.Win.Extends
{
    /// <summary>
    /// XtraGrid TileView辅助类
    /// </summary>
    public static class TileViewExtends
    {
        /// <summary>
        /// 取Grid选中数据
        /// </summary>
        public static T GetFocusData<T>(this TileView view) where T : class
        {
            return view.FocusedRowHandle >= 0 ? view.GetRow(view.FocusedRowHandle) as T : default(T);
        }
        /// <summary>
        /// 绑定行右键弹出菜单
        /// </summary>
        /// <param name="view">表格</param>
        /// <param name="popup">弹出菜单</param>
        /// <param name="beforeShow">显示前处理</param>
        public static void BindPopup<T>(this TileView view, PopupMenu popup, Predicate<T> beforeShow = null) where T : class, IKey
        {
            var helper = view.GetTag<TileViewPopupHelper<T>>(WinUtilityConsts.TileViewPopupMenuHelperTagKey);
            if (helper == null)
            {
                helper = new TileViewPopupHelper<T>();
                view.SetTag(WinUtilityConsts.TileViewPopupMenuHelperTagKey, helper);
            }
            helper.BindPopupMenu(view, popup, beforeShow);
        }

        /// <summary>
        /// 解绑右键菜单
        /// </summary>
        /// <param name="view">表格</param>
        /// <param name="popup">弹出菜单</param>
        public static void UnbindPopup<T>(this TileView view, PopupMenu popup) where T : class, IKey
        {
            var helper = view?.GetTag<TileViewPopupHelper<T>>(WinUtilityConsts.TileViewPopupMenuHelperTagKey);
            helper?.UnbindPopupMenu(view, popup);
        }

    }
}
