using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraEditors;
using WitsWay.TempTests.GeneralQuery.Models;
using WitsWay.TempTests.GeneralQuery.Properties;
using WitsWay.Utilities.Extends;
using WitsWay.Utilities.Win;
using WitsWay.Utilities.Win.Extends;

namespace WitsWay.TempTests.GeneralQuery.QueryForms
{

    public partial class GridWithFilterUc : XtraUserControl
    {
        public GridWithFilterUc()
        {
            InitializeComponent();
            InitConfig(new GridPresentConfig { Commands = new List<OperationRights> { OperationRights.Add, OperationRights.Audit, OperationRights.Delete }, Functions = new List<GridFunctions> { GridFunctions.ConfigBand, GridFunctions.DetailBand, GridFunctions.RowContextMenu, GridFunctions.SearchBand } });
        }
        /// <summary>
        /// 初始化配置
        /// </summary>
        /// <param name="config">呈现配置</param>
        public void InitConfig(GridPresentConfig config)
        {
            //有哪些操作
            CreateCommands(config.Commands);
            //支持哪些功能

            //Grid布局

            //详情布局

            //搜索控件

        }

        private void CreateCommands(IEnumerable<OperationRights> commands)
        {
            var operates = commands as OperationRights[] ?? commands.ToArray();
            if (!operates.Any()) return;
            foreach (var cmd in operates)
            {
                //添加操作按钮
                var cmdBtn = new DevExpress.XtraBars.BarButtonItem
                {
                    Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right,
                    Caption = cmd.GetDescription(),
                    Glyph = Resources.add,
                    Id = 0,
                    Name = "_cmd" + cmd + "It",
                    PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
                };
                cmdBtn.ItemClick += _cmdAddIt_ItemClick;
                _barManager.Items.Add(cmdBtn);
                _barCommands.AddItem(cmdBtn);

                //添加右键菜单
                var bbi = new DevExpress.XtraBars.BarButtonItem
                {
                    Caption = cmd.GetDescription(),
                    Id = 23,
                    Name = "_bbi"+cmd+"It"
                };
                bbi.ItemClick += _bbiAddIt_ItemClick;
                _barManager.Items.Add(bbi);
                _popupMenu.LinksPersistInfo.Add(new DevExpress.XtraBars.LinkPersistInfo(bbi, true));
            }
        }

        public void BindData()
        {
            //绑定Grid
            //绑定搜索控件初始化数据
        }

        ////var btn1=_gridNavPane.ButtonsPanel.Buttons[0] as NavigationButton;
        //////btn1.UseCaption
        ////_gridNavPane.ButtonsPanel.Buttons.SafeForEach(btn=>
        ////{
        ////    var nBtn=((NavigationButton)btn);
        ////    nBtn.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
        ////    nBtn.
        ////});
        //////btn.Image.RotateFlip(RotateFlipType.Rotate90FlipX);
        //////btn.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
        //////btn.Appearance.Image.


        ////private void navigationPage1_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        ////{
        ////    ShowMessage(e.Button.Properties.Caption);
        ////}

        ////private void ShowMessage(string msg)
        ////{
        ////    XtraMessageBox.Show(msg);
        ////}

        #region [Commands]

        private void _cmdAddIt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CommandAddIt();
        }

        private void _cmdEditIt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CommandEditIt();
        }

        private void _cmdDeleteIt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CommandDeleteIt();
        }



        private void _cmdRefreshGrid_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CommandRefreshGrid();
        }


        private void _cmdFullscreenGrid_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CommandFullGrid();
        }


        private void _cmdColumnWidthBest_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CommandBestWidth();
        }
        private void _cmdColumnWidthAuto_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CommandAutoWidth();
        }

        private void _bbiTableRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CommandRefreshGrid();
        }

        private void _bbiTableFullscreen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CommandFullGrid();
        }

        private void _bbiTableColumnWidthBest_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CommandBestWidth();
        }

        private void _bbiTableColumnWidthAuto_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CommandAutoWidth();
        }

        private void _bbiAddIt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CommandAddIt();
        }

        private void _bbiEditIt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CommandEditIt();
        }

        private void _bbiDeleteIt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CommandDeleteIt();
        }


        private static void CommandAddIt()
        {
            UtilityHelper.ShowInfoMessage("添加");
        }

        private static void CommandEditIt()
        {
            UtilityHelper.ShowInfoMessage("修改");
        }
        private static void CommandDeleteIt()
        {
            UtilityHelper.ShowInfoMessage("删除");
        }
        private static void CommandRefreshGrid()
        {
            UtilityHelper.ShowInfoMessage("刷新Grid");
        }
        private static void CommandFullGrid()
        {
            UtilityHelper.ShowInfoMessage("全屏Grid");
        }

        private static void CommandBestWidth()
        {
            UtilityHelper.ShowInfoMessage("最优列宽Grid");
        }

        private static void CommandAutoWidth()
        {
            UtilityHelper.ShowInfoMessage("自动列宽Grid");
        }

        #endregion

        private void GridWithFilterUC_Load(object sender, EventArgs e)
        {
            BindGridData();
        }

        private void BindGridData()
        {
            _gridControl.DataSource = new List<Employee>
            {
                new Employee
                {
                    EmployeeName = "EmployeeName",
                    Address = "",
                    Age = 1,
                    AllowLogin = true,
                    Birthday = DateTime.Now,
                    ContractEndDate = DateTime.Now,
                    ContractEndDateString = "",
                    ContractStartDate = DateTime.Now,
                    ContractStartDateString = "",
                    ContractTypeId = 1,
                    CorpId = 1,
                    CorpType = CorporationType.JoinCorporation
                }, new Employee
                {
                    EmployeeName = "EmployeeName2",
                    Address = "",
                    Age = 1,
                    AllowLogin = true,
                    Birthday = DateTime.Now,
                    ContractEndDate = DateTime.Now,
                    ContractEndDateString = "",
                    ContractStartDate = DateTime.Now,
                    ContractStartDateString = "",
                    ContractTypeId = 1,
                    CorpId = 1,
                    CorpType = CorporationType.JoinCorporation
                }
            };
            _gridView.BestFitColumns();
            _gridView.SetStyle(false);
            _gridView.DrawRowIndicator();
            _gridView.BindRowDoubleClick<Employee>(emp =>
            {
                UtilityHelper.ShowInfoMessage(emp.EmployeeName);
            });
            _gridView.BindPopup<Employee>(_popupMenu);
        }
    }
}