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
//using System;
//using System.Collections;
//using System.Drawing;
//using System.Linq;
//using System.Windows.Forms;
//using DevExpress.Utils.Drawing;
//using DevExpress.XtraEditors.Drawing;
//using DevExpress.XtraEditors.Repository;
//using DevExpress.XtraEditors.ViewInfo;
//using DevExpress.XtraGrid.Columns;
//using DevExpress.XtraGrid.Views.Grid;
//using DevExpress.XtraGrid.Views.Grid.ViewInfo;

//namespace SmartSolution.Utilities.Win.Helpers
//{
//    /// <summary>
//    /// 列头选择帮助类
//    /// </summary>
//    public class GridColumnHeaderCheckHelper
//    {
//        private GridView _view;
//        private GridColumn _column;
//        private RepositoryItemCheckEdit _edit;

//        /// <summary>
//        /// 构造一个列头选择帮助类
//        /// </summary>
//        /// <param name="column"></param>
//        /// <param name="edit"></param>
//        public GridColumnHeaderCheckHelper(GridColumn column, RepositoryItemCheckEdit edit = null)
//        {
//            if (column == null) return;
//            if (!(column.View is GridView)) return;

//            _view = column.View as GridView;
//            _column = column;

//            _edit = edit ?? CreateCheckEdit(column);
//            column.ColumnEdit = edit;

//            column.OptionsColumn.ShowCaption = false;

//            edit.EditValueChanged -= edit_EditValueChanged;
//            edit.EditValueChanged += edit_EditValueChanged;
//            _view.CustomDrawColumnHeader -= View_CustomDrawColumnHeader;
//            _view.CustomDrawColumnHeader += View_CustomDrawColumnHeader;
//            _view.MouseDown -= view_MouseDown;
//            _view.MouseDown += view_MouseDown;
//        }

//        /// <summary>
//        /// 添加一个CheckBox
//        /// </summary>
//        /// <param name="column"></param>
//        /// <returns></returns>
//        private RepositoryItemCheckEdit CreateCheckEdit(GridColumn column)
//        {
//            var edit = _view.GridControl.RepositoryItems.Add("CheckEdit") as RepositoryItemCheckEdit;
//            column.ColumnEdit = edit;
//            return edit;
//        }

//        /// <summary>
//        /// 处理列头点击事件
//        /// </summary>
//        /// <param name="sender"></param>
//        /// <param name="e"></param>
//        private void view_MouseDown(object sender, MouseEventArgs e)
//        {
//            if (e.Clicks == 1 && e.Button == MouseButtons.Left)
//            {
//                GridHitInfo info;
//                Point pt = _view.GridControl.PointToClient(Control.MousePosition);

//                var currView = GetCurrentPositionGrid();
//                if (currView == null) return;

//                info = currView.CalcHitInfo(pt);

//                if (info.InColumn && info.Column.Name == _column.Name)
//                {
//                    var checkAll = IsAllChecked(currView);
//                    SetAllCheckState(currView, !checkAll);
//                    Invalidate(currView);
//                }
//            }
//        }

//        /// <summary>
//        /// 处理CheckBox值改变事件
//        /// </summary>
//        /// <param name="sender"></param>
//        /// <param name="e"></param>
//        private void edit_EditValueChanged(object sender, EventArgs e)
//        {
//            var currView = GetCurrentPositionGrid();
//            if (currView == null) return;

//            currView.PostEditor();
//            Invalidate(currView);
//        }

//        /// <summary>
//        /// 自定义列头绘制
//        /// </summary>
//        /// <param name="sender"></param>
//        /// <param name="e"></param>
//        private void View_CustomDrawColumnHeader(object sender, ColumnHeaderCustomDrawEventArgs e)
//        {
//            if (e.Column != null && e.Column.Name == _column.Name)
//            {
//                e.Info.InnerElements.Clear();
//                e.Painter.DrawObject(e.Info);

//                DrawCheckBox(e.Graphics, e.Bounds, IsAllChecked(e.Column.View as GridView));
//                e.Handled = true;
//            }
//        }

//        /// <summary>
//        /// 绘制CheckBox
//        /// </summary>
//        /// <param name="g"></param>
//        /// <param name="r"></param>
//        /// <param name="Checked"></param>
//        protected void DrawCheckBox(Graphics g, Rectangle r, bool Checked)
//        {
//            CheckEditViewInfo info;
//            CheckEditPainter painter;
//            ControlGraphicsInfoArgs args;
//            info = _edit.CreateViewInfo() as CheckEditViewInfo;
//            painter = _edit.CreatePainter() as CheckEditPainter;
//            info.EditValue = Checked;
//            info.Bounds = r;
//            info.CalcViewInfo(g);
//            args = new ControlGraphicsInfoArgs(info, new GraphicsCache(g), r);
//            painter.Draw(args);
//            args.Cache.Dispose();
//        }

//        /// <summary>
//        /// 获取当前位置的Grid
//        /// </summary>
//        /// <returns></returns>
//        private GridView GetCurrentPositionGrid()
//        {
//            Point pt = _view.GridControl.PointToClient(Control.MousePosition);
//            return _view.GridControl.GetViewAt(pt) as GridView;
//        }

//        /// <summary>
//        /// 设置表格中所有项的选中状态
//        /// </summary>
//        /// <param name="theView"></param>
//        /// <param name="isChecked"></param>
//        private void SetAllCheckState(GridView theView, bool isChecked)
//        {
//            if (theView == null 
//                || theView.DataSource==null)
//                return;

//            var dataSource = (theView.DataSource as IEnumerable).OfType<ICheckable>();

//            foreach (var item in dataSource)
//            {
//                item.IsChecked = isChecked;
//            }
//        }

//        /// <summary>
//        /// 判断是否表格中所有项都被选中
//        /// </summary>
//        /// <param name="view">表格</param>
//        /// <returns></returns>
//        private bool IsAllChecked(GridView view)
//        {
//            if (view == null 
//                || view.DataSource==null)
//                return false;

//            var dataSource = (view.DataSource as IEnumerable).OfType<ICheckable>();
//            return dataSource.All(i => i.IsChecked);
//        }

//        /// <summary>
//        /// 刷新Grid
//        /// </summary>
//        private void Invalidate(GridView view)
//        {
//            if (view == null) return;

//            view.CloseEditor();
//            view.BeginUpdate();
//            view.EndUpdate();
//        }
//    }
//}
