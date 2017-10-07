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
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.XtraGrid.Views.Grid;

namespace WitsWay.Utilities.Win.Helpers
{

    /// <summary>
    /// XtraGrid辅助类
    /// </summary>
    public class GridServerMode
    {

        /// <summary>
        /// 注册服务端分页GridView
        /// </summary>
        public static void RegisterGridView(GridView view,GridServerModeParameter para)
        {
            view.OptionsCustomization.AllowSort = false;
            foreach (var col in para.AllowSortColumns)
            {
                col.ImageIndex = para.CanSortImage;
                col.ImageAlignment = StringAlignment.Far;
            }
            para.SortColumn.ImageAlignment = StringAlignment.Far;
            para.SortColumn.ImageIndex = para.SortOrder == ColumnSortOrder.Ascending ? para.AsscendImage : para.DescendImage;
            view.Tag = para;
            view.MouseUp += view_MouseUp;
        }

        private static void view_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left || e.Clicks > 1) { return; }
            var view = sender as GridView;
            if (view != null)
            {
                var para = view.Tag as GridServerModeParameter;
                if (view.State == GridState.ColumnDown && para != null)
                {
                    var info = view.CalcHitInfo(e.Location);
                    if (info != null && info.InColumn)
                    {
                        var curColumn = info.Column;
                        if (para.AllowSortColumns.Contains(curColumn))
                        {
                            var curOrder = para.SortOrder == ColumnSortOrder.Ascending ? ColumnSortOrder.Descending : ColumnSortOrder.Ascending;
                            para.SortColumn = curColumn;
                            para.SortOrder = curOrder;
                            para.OnSortColumnChanged();
                            foreach (var column in para.AllowSortColumns)
                            {
                                if (!ReferenceEquals(column, curColumn))
                                {
                                    column.ImageIndex = para.CanSortImage;
                                }
                                else
                                {
                                    column.ImageIndex =
                                        curOrder == ColumnSortOrder.Ascending ? para.AsscendImage : para.DescendImage;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}