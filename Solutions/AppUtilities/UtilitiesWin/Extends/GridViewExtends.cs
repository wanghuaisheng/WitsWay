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
using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using WitsWay.Utilities.Supports;
using WitsWay.Utilities.Win.Helpers;

namespace WitsWay.Utilities.Win.Extends
{
    /// <summary>
    /// XtraGrid辅助类
    /// </summary>
    public static partial class GridViewExtends
    {

        /// <summary>
        /// 自动行高度
        /// </summary>
        /// <param name="view">表格</param>
        /// <param name="autoHeight">是否自动行高度，默认true</param>
        public static void AutoRowHeight(this GridView view, bool autoHeight = true)
        {
            view.OptionsView.RowAutoHeight = autoHeight;
        }

        /// <summary>
        /// 行号
        /// </summary>
        public static void DrawRowIndicator(this GridView view)
        {
            view.IndicatorWidth = 40;
            view.CustomDrawRowIndicator += (sender, e) =>
            {
                if (!e.Info.IsRowIndicator || e.RowHandle < 0) return;
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            };
        }


        /// <summary>
        /// 选中GridView对应Key的行,如果不存在则选中第一行
        /// </summary>
        /// <param name="gv">GridView控件</param>
        /// <param name="key">要选中的Key</param>
        public static void SelectXtraGridRow(this GridView gv, IKey key)
        {
            SelectXtraGridRow(gv, key?.Key);
        }

        /// <summary>
        /// 选中GridView对应Key的行,如果不存在则选中第一行
        /// </summary>
        /// <param name="gv">GridView控件</param>
        /// <param name="keyToSelect">要选中的Key</param>
        public static void SelectXtraGridRow(this GridView gv, string keyToSelect)
        {
            if (gv == null) return;
            if (!string.IsNullOrEmpty(keyToSelect))
            {
                for (var i = 0; i < gv.RowCount; i++)
                {
                    var rowInfo = gv.GetRow(i) as IKey;
                    if (rowInfo != null && rowInfo.Key.Equals(keyToSelect))
                    {
                        gv.ClearSelection();
                        gv.FocusedRowHandle = i;
                        gv.SelectRow(i);
                        return;
                    }
                }
            }
            if (gv.RowCount > 0)
            {
                gv.ClearSelection();
                gv.FocusedRowHandle = 0;
                gv.SelectRow(0);
            }
        }

        /// <summary>
        /// 设置Grid的列排序是否启用，默认禁用
        /// </summary>
        /// <param name="gridView">表格</param>
        /// <param name="columns">设置为启用排序的列</param>
        public static void SetColumnSortable(this GridView gridView, params GridColumn[] columns)
        {
            foreach (GridColumn column in gridView.Columns)
            {
                column.OptionsColumn.AllowSort = columns.Contains(column) ? DefaultBoolean.True : DefaultBoolean.False;
            }
        }

        /// <summary>
        /// 设置Grid的列排序是否启用，默认禁用
        /// </summary>
        /// <param name="gridView">表格</param>
        public static void ShowGroupColumn(this GridView gridView)
        {
            gridView.OptionsView.ShowGroupedColumns = true;
        }
        /// <summary>
        /// 设置GridView为Office样式
        /// </summary>
        /// <param name="gridView">表格</param>
        public static void OfficeStyle(this GridView gridView)
        {
            gridView.OptionsView.GroupDrawMode = GroupDrawMode.Office;
            gridView.OptionsView.ShowGroupedColumns = true;
            gridView.OptionsView.ShowGroupPanel = false;
            gridView.OptionsView.ShowVerticalLines = DefaultBoolean.False;
        }


        /// <summary>
        /// 在主从视图展开/折叠所有主视图的行
        /// </summary>
        /// <param name="gridView">表格</param>
        public static void ExpandMasterRow(this GridView gridView)
        {
            SetMasterRowExpanded(gridView, true);
        }
        /// <summary>
        /// 在主从视图展开/折叠所有主视图的行
        /// </summary>
        /// <param name="gridView">表格</param>
        public static void CollapseMasterRow(this GridView gridView)
        {
            SetMasterRowExpanded(gridView, false);
        }
        /// <summary>
        /// 在主从视图展开/折叠所有主视图的行
        /// </summary>
        /// <param name="gridView">表格</param>
        /// <param name="expand">是否展开</param>
        private static void SetMasterRowExpanded(GridView gridView, bool expand)
        {
            gridView.BeginUpdate();
            try
            {
                var dataRowCount = gridView.DataRowCount;
                for (var rowHandle = 0; rowHandle < dataRowCount; rowHandle++)
                    gridView.SetMasterRowExpanded(rowHandle, expand);
            }
            finally
            {
                gridView.EndUpdate();
            }
        }

        /// <summary>
        /// CheckBox多选支持
        /// </summary>
        /// <param name="gridView">表格</param>
        public static void RowCheckBoxMultiSelect(this GridView gridView)
        {
            RowCheckBoxSelect(gridView, true, true, true);
        }
        /// <summary>
        /// 获取选中的数据
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="gridView">表格</param>
        /// <returns>选中数据列表</returns>
        public static IList<T> GetSelectDatas<T>(this GridView gridView) where T : class
        {
            var rows = gridView.GetSelectedRows();
            var datas = rows.Where(row => row >= 0).Select(row => gridView.GetRow(row) as T);
            return datas.ToList();
        }
        /// <summary>
        /// CheckBox多选支持
        /// </summary>
        /// <param name="gridView">表格</param>
        /// <param name="multiSelect"></param>
        /// <param name="showCheckInColumn"></param>
        /// <param name="showCheckInGroup"></param>
        private static void RowCheckBoxSelect(GridView gridView, bool multiSelect, bool showCheckInColumn, bool showCheckInGroup)
        {
            gridView.OptionsSelection.MultiSelect = multiSelect;
            gridView.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
            gridView.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = showCheckInColumn ? DefaultBoolean.True : DefaultBoolean.False;
            gridView.OptionsSelection.ShowCheckBoxSelectorInGroupRow = showCheckInGroup ? DefaultBoolean.True : DefaultBoolean.False;
        }

        #region [SetGridViewStyle]

        /// <summary>
        /// 设置gridview格式
        /// </summary>
        public static void SetStyle(this GridView gridView, bool autoWidth, bool showBorder, params GridColumn[] allowEditColumns)
        {
            SetStyle(gridView, autoWidth, showBorder);
            if (allowEditColumns == null || allowEditColumns.Length <= 0) return;
            foreach (var item in allowEditColumns)
            {
                if (gridView.Columns.Contains(item))
                {
                    item.OptionsColumn.AllowEdit = true;
                }
            }
        }
        /// <summary>
        /// 设置gridview格式
        /// </summary>
        public static void SetStyle(this GridView gridView, bool autoWidth, bool showBorder)
        {
            SetStyle(gridView);
            gridView.OptionsView.ColumnAutoWidth = autoWidth;
            gridView.BorderStyle = showBorder ? BorderStyles.Default : BorderStyles.NoBorder;
        }
        /// <summary>
        /// 设置gridview格式
        /// </summary>
        public static void SetStyle(this GridView gridView, params GridColumn[] allowEditColumns)
        {
            SetStyle(gridView);
            foreach (var column in allowEditColumns)
            {
                column.OptionsColumn.AllowEdit = true;
            }
        }
        /// <summary>
        /// 设置gridview格式
        /// </summary>
        public static void SetStyle(this GridView gridView, bool allowEdit)
        {
            SetStyle(gridView);
            foreach (GridColumn column in gridView.Columns)
            {
                column.OptionsColumn.AllowEdit = allowEdit;
                column.OptionsColumn.AllowShowHide = allowEdit;
            }
        }
        /// <summary>
        /// 设置gridview格式
        /// </summary>
        public static void SetStyle(this GridView gridView)
        {
            gridView.OptionsMenu.EnableColumnMenu = false;
            gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
            gridView.OptionsView.ShowGroupPanel = false;
            gridView.Appearance.HeaderPanel.TextOptions.HAlignment = HorzAlignment.Near;
            gridView.BorderStyle = BorderStyles.Default;
            gridView.OptionsCustomization.AllowFilter = false;
            gridView.OptionsMenu.EnableColumnMenu = false;
            gridView.OptionsDetail.EnableMasterViewMode = false;
            gridView.OptionsView.EnableAppearanceEvenRow = true;
            gridView.OptionsView.EnableAppearanceOddRow = true;
            foreach (GridColumn item in gridView.Columns)
            {
                item.OptionsColumn.AllowEdit = false;
                item.OptionsColumn.AllowShowHide = false;
            }
        }

        #endregion

        /// <summary>
        /// 行双击
        /// </summary>
        /// <param name="gridView">表格</param>
        /// <param name="action">事件处理器</param>
        public static void BindRowDoubleClick<T>(this GridView gridView, Action<T> action) where T : class, IKey
        {
            if (gridView == null || action == null) return;
            var helper = gridView.GetTag<GridControlDoubleClickHelper<T>>(WinUtilityConsts.GridViewDoubleClickHelperTagKey);
            if (helper == null)
            {
                helper = new GridControlDoubleClickHelper<T>();
                gridView.SetTag(WinUtilityConsts.GridViewDoubleClickHelperTagKey, helper);
            }
            helper.BindDoubleClick(gridView, action);
        }
        /// <summary>
        /// 解绑行双击
        /// </summary>
        /// <param name="gridView">表格</param>
        public static void UnbindRowDoubleClick<T>(this GridView gridView) where T : class, IKey
        {
            var helper = gridView?.GetTag<GridControlDoubleClickHelper<T>>(WinUtilityConsts.GridViewDoubleClickHelperTagKey);
            helper?.UnbindDoubleClick(gridView);
        }

        /// <summary>
        /// 绑定行右键弹出菜单
        /// </summary>
        /// <param name="gridView">表格</param>
        /// <param name="popup">弹出菜单</param>
        /// <param name="beforeShow">显示前处理</param>
        public static void BindPopupMenu<T>(this GridView gridView, PopupMenu popup, Predicate<T> beforeShow = null) where T : class, IKey
        {
            var helper = gridView.GetTag<GridViewPopupHelper<T>>(WinUtilityConsts.GridViewPopupMenuHelperTagKey);
            if (helper == null)
            {
                helper = new GridViewPopupHelper<T>();
                gridView.SetTag(WinUtilityConsts.GridViewPopupMenuHelperTagKey, helper);
            }
            helper.BindPopupMenu(gridView, popup, beforeShow);
        }

        /// <summary>
        /// 解绑右键菜单
        /// </summary>
        /// <param name="gridView">表格</param>
        /// <param name="popup">弹出菜单</param>
        public static void UnbindPopupMenu<T>(this GridView gridView, PopupMenu popup) where T : class, IKey
        {
            var helper = gridView?.GetTag<GridViewPopupHelper<T>>(WinUtilityConsts.GridViewPopupMenuHelperTagKey);
            helper?.UnbindPopupMenu(gridView, popup);
        }

    }
}
