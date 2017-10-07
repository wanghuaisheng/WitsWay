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
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace WitsWay.Utilities.Win.Helpers
{
    /// <summary>
    /// 表格拖动Helper
    /// </summary>
    public class GridDragHelper
    {
        private GridHitInfo _hitInfo;
        private readonly GridControl _gridControl;
        private readonly GridView _gridView;

        /// <summary>
        /// 注册对指定GridControl的拖动事件
        /// </summary>
        /// <param name="gridControl"></param>
        /// <returns></returns>
        public static GridDragHelper Register(GridControl gridControl)
        {
            return new GridDragHelper(gridControl);
        }

        /// <summary>
        /// 取消对Grid拖动的注册
        /// </summary>
        public void UnRegister()
        {
            _gridControl.MouseDown -= gridControl_MouseDown;
            _gridControl.MouseMove -= gridControl_MouseMove;
        }

        private GridDragHelper(GridControl gridControl)
        {
            _gridControl = gridControl;
            _gridView = gridControl.MainView as GridView;

            _gridControl.MouseDown += gridControl_MouseDown;
            _gridControl.MouseMove += gridControl_MouseMove;
        }

        private void gridControl_MouseDown(object sender, MouseEventArgs e)
        {
            _hitInfo = _gridView.CalcHitInfo(new Point(e.X, e.Y));
        }

        private void gridControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (_hitInfo == null) return;
            if (e.Button != MouseButtons.Left) return;
            var dragRect = new Rectangle(new Point(
                _hitInfo.HitPoint.X - SystemInformation.DragSize.Width / 2,
                _hitInfo.HitPoint.Y - SystemInformation.DragSize.Height / 2), SystemInformation.DragSize);
            if (!dragRect.Contains(new Point(e.X, e.Y)) && (_hitInfo.InRowCell || _hitInfo.InRow))
            {
                var selectedRows = _gridView.GetSelectedRows();
                if (selectedRows.Length > 1)
                    _gridControl.DoDragDrop(selectedRows.Select(_gridView.GetRow).Where(x => x != null).ToList(), DragDropEffects.Copy);
                else
                {
                    var data = _gridView.GetRow(_hitInfo.RowHandle);
                    if (data != null)
                        _gridControl.DoDragDrop(data, DragDropEffects.Copy);
                }
            }
        }

    }
}
