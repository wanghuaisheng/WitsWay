﻿#region License(Apache Version 2.0)
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
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Tile;
using WitsWay.Utilities.Errors;
using WitsWay.Utilities.Helpers;
using WitsWay.Utilities.Supports;
using WitsWay.Utilities.Win.Extends;

namespace WitsWay.Utilities.Win.Helpers
{

    /// <summary>
    /// ColumnView右键菜单辅助类
    /// </summary>
    public class ColumnViewPopupHelper<T> where T : class, IKey
    {

        private readonly Dictionary<PopupMenu, string> _popupDic = new Dictionary<PopupMenu, string>();

        private readonly Dictionary<string, BaseHitInfoModelPredicate<T>> _funcDic = new Dictionary<string, BaseHitInfoModelPredicate<T>>();

        #region [BindPopup]

        /// <summary>
        /// 绑定弹出右键菜单到树，此方法只支持一个树上注册一个PopupMenu
        /// </summary>
        /// <param name="view"></param>
        /// <param name="popup"></param>
        /// <param name="showPredicate">谓词委托，返回true显示右键，false不显示</param>
        public void BindPopupMenu(ColumnView view, PopupMenu popup, BaseHitInfoModelPredicate<T> showPredicate = null)
        {
            if (view == null || popup == null)
                throw ExceptionHelper.GetProgramException("BindPopupMenu时传入的veiw或popup为空", UtilityErrors.ArgumentNullException);
            var key = $"_key_{view.Name}_{popup.Name}";
            if (_funcDic.ContainsKey(key)) return;
            _popupDic[popup] = key;
            _funcDic[key] = showPredicate;
            view.MouseUp += GridViewMouseUp;
        }

        /// <summary>
        /// 解绑右键弹出菜单
        /// </summary>
        /// <param name="view">GridView控件</param>
        /// <param name="popup">右键弹出菜单</param>
        public void UnbindPopupMenu(ColumnView view, PopupMenu popup)
        {
            if (view == null || popup == null)
                throw ExceptionHelper.GetProgramException("BindPopupMenu时传入的veiw或popup为空", UtilityErrors.ArgumentNullException);
            var key = $"_key_{view.Name}_{popup.Name}";
            if (_popupDic.ContainsKey(popup)) _popupDic.Remove(popup);
            if (_funcDic.ContainsKey(key)) _funcDic.Remove(key);
            view.MouseUp -= GridViewMouseUp;
        }

        private void GridViewMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            var columnView = sender as ColumnView;
            //TileView特殊处理
            var tileHi = (sender as TileView)?.CalcHitInfo(e.Location);
            var hi = tileHi ?? columnView?.CalcHitInfo(e.Location);
            if (hi == null) return;
            var data = columnView.GetFocusData<T>();
            if (data == null) return;
            //处理Predicate
            var helper = columnView.GetTag<ColumnViewPopupHelper<T>>(WinUtilityConsts.ColumnViewPopupMenuHelperTagKey);
            if (helper == null) return;
            using (var eor = _popupDic.GetEnumerator())
            {
                while (eor.MoveNext())
                {
                    var popup = eor.Current.Key;
                    var funcKey = eor.Current.Value;
                    if (!_funcDic.ContainsKey(funcKey) || _funcDic[funcKey] == null)
                    {
                        popup.ShowPopup(Control.MousePosition);
                        return;
                    }
                    if (_funcDic[funcKey] != null && _funcDic[funcKey](columnView, hi, data))
                    {
                        popup.ShowPopup(Control.MousePosition);
                        return;
                    }
                }
            }
        }

        #endregion
    }
}