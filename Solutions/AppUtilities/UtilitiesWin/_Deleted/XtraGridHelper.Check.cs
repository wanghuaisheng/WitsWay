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
///////*修改日志
////// * 2012年7月21日   王怀生     添加
////// * 
////// * */
//////using System;
//////using System.Collections.Generic;
//////using System.Linq;
//////using System.Text;
//////using DevExpress.XtraEditors;
//////using DevExpress.XtraGrid.Views.Grid;
//////using System.Windows.Forms;
//////using System.Drawing;
//////using System.IO;
//////using DevExpress.XtraGrid.Columns;
//////using DevExpress.XtraEditors.Controls;
//////using DevExpress.XtraBars;
//////using DevExpress.XtraGrid.Views.Grid.ViewInfo;
//////using DevExpress.XtraGrid;

//////namespace DotNetSoft.Utilities.Win.Helpers
//////{
//////    public partial class XtraGridHelper
//////    {

//////        /// <summary>
//////        /// 初始化选择列
//////        /// </summary>
//////        public static void InitCheckColumn(XtraForm frm, BarManager bar, GridColumn column, int columnHeadImageIndex = -1)
//////        {
//////            column.ImageIndex = columnHeadImageIndex;
//////            column.FieldName = "IsSelect";
//////            column.Fixed = FixedStyle.Left;

//////            GridView view = column.View as GridView;
//////            view.MouseUp += view_MouseUp;
//////        }

//////        private static void view_MouseUp(object sender, MouseEventArgs e)
//////        {
//////            GridView view = sender as GridView;
//////            if (view != null)
//////            {
//////                GridControl grid = view.GridControl;
//////                grid.DataSource
//////                GridServerModeParameter para = view.Tag as GridServerModeParameter;
//////                if (view.State == GridState.ColumnDown && para != null)
//////                {
//////                    GridHitInfo info = view.CalcHitInfo(e.Location);
//////                    if (info != null && info.InColumn && info.Column.FieldName == "IsSelect")
//////                    {
//////                        GridColumn curColumn = info.Column;

//////                    }
//////                }
//////            }
//////        }

//////    }
//////}



//using DevExpress.XtraEditors;
//using DevExpress.XtraLayout;
//using SmartSolution.Logics.Infra.Dtos.Kernals;
//using System;
//using System.Collections.Generic;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace ABM.Plugins.LayoutManage.Core
//{
//    /// <summary>
//    /// 生成布局窗体
//    /// </summary>
//    public class LayoutFormBuilder
//    {
//        private string _title = string.Empty;
//        private int _height = 600;
//        private int _width = 800;
//        private bool _fullScreen = false;

//        /// <summary>
//        /// 宽（默认800）
//        /// </summary>
//        public LayoutFormBuilder Width(int width)
//        {
//            _width = width;
//            return this;
//        }
//        /// <summary>
//        /// 高（默认600）
//        /// </summary>
//        public LayoutFormBuilder Height(int height)
//        {
//            _height = height;
//            return this;
//        }
//        /// <summary>
//        /// 全屏显示
//        /// </summary>
//        public LayoutFormBuilder FullScreen()
//        {
//            _fullScreen = true;
//            return this;
//        }

//        public LayoutFormBuilder MinimizeBox()
//        {
//            return this;
//        }

//        public LayoutFormBuilder MaximizeBox()
//        {
//            return this;
//        }


//        /// <summary>
//        /// 标题
//        /// </summary>
//        public LayoutFormBuilder Title(string title)
//        {
//            _title = title;
//            return this;
//        }

//        public LayoutFormBuilder OkButton()
//        {
//            SimpleButton okBtn=new SimpleButton();
//            okBtn.Text = "确定";
//            okBtn.Click
//            //添加确定按钮
//            return this;
//        }

//        public LayoutFormBuilder OkCancelButton()
//        {
//            return this;
//        }
//        public LayoutFormBuilder CancelButton()
//        {
//            return this;
//        }
//        public LayoutFormBuilder Button(params SimpleButton[] simpleButtons)
//        {

//        }

//        /// <summary>
//        /// 显示窗体
//        /// </summary>
//        /// <param name="parent">父窗体</param>
//        public void Show(Form parent = null)
//        {
//            CreateForm().Show(parent);
//        }
//        /// <summary>
//        /// 显示对话框
//        /// </summary>
//        /// <param name="parent">父窗体</param>
//        public void ShowDialog(Form parent)
//        {
//            CreateForm().ShowDialog(parent);
//        }

//        private XtraForm CreateForm()
//        {
//            var form = new XtraForm();
//            if (_fullScreen) form.WindowState = FormWindowState.Maximized;
//            form.MinimizeBox = true;
//            form.MaximizeBox = true;
//            form.CloseBox = true;

//            form.Name = GetType().Name;
//            LayoutControl layoutControl = new LayoutControl();
//            new LayoutManageCore().SetFormLayout(presentItem, layoutControl);
//            form.Controls.Add(layoutControl);
//            layoutControl.Dock = DockStyle.Fill;
//            FlowLayoutPanel panel = new FlowLayoutPanel();
//            panel.Dock = DockStyle.Bottom;
//            panel.Height = 45;
//            panel.Padding = new Padding(8);
//            panel.FlowDirection = FlowDirection.RightToLeft;
//            panel.Controls.AddRange(simpleButtons);
//            form.Controls.Add(panel);
//            form.StartPosition = FormStartPosition.CenterParent;
//            if (_isDialog)
//            {
//                form.ShowDialog();
//            }
//            else
//            {
//                form.Show();
//            }
//            return form;

//            return form;
//        }

//        /// <summary>
//        /// 显示窗体
//        /// </summary>
//        public static LayoutFormBuilder NewBuilder(PresentItemDto presentItem)
//        {
//            LayoutFormBuilder.NewBuilder(parentItem, "abcv").Title().MinimizeBox().MaximizeBox().FullScreen().OkButton().ShowDialog(pForm);
//            var builder = new LayoutFormBuilder();
//            return builder;
//        }
//        /// <summary>
//        /// 显示窗体
//        /// </summary>
//        public static LayoutFormBuilder NewBuilder(PresentItemDto presentItem, string title)
//        {
//            var builder = new LayoutFormBuilder();
//            builder.Title(title);
//            return builder;
//        }
//    }
//}
