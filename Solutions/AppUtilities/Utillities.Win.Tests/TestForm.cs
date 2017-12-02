using System;
using System.Collections.Generic;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.BandedGrid.ViewInfo;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Base.ViewInfo;
using DevExpress.XtraGrid.Views.Card.ViewInfo;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Layout.ViewInfo;
using DevExpress.XtraGrid.Views.Tile.ViewInfo;
using DevExpress.XtraGrid.Views.WinExplorer.ViewInfo;
using WitsWay.Utilities.Extends;
using WitsWay.Utilities.Models;
using WitsWay.Utilities.Win.Entities;
using WitsWay.Utilities.Win.Enums;
using WitsWay.Utilities.Win.Extends;

namespace WitsWay.Utilities.Win.Tests
{
    public partial class TestForm : XtraForm
    {

        #region [Form]

        public TestForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitControls();
            BindGrid();
        }

        private void BindGrid()
        {
            var logins = new List<LoginResult>();
            for (int i = 0; i < 100; i++)
            {
                logins.Add(new LoginResult
                {
                    CorpCode = "CorpCode" + i,
                    CorpId = i,
                    CorpKind = 1,
                    CorpName = "CorpName" + i,
                    CorpShortName = "CorpShortName" + i,
                    EmployeeId = i,
                    EmployeeName = "EmployeeName" + i,
                    EmployeeWorkNumber = "EmployeeWorkNumber" + i,
                    LoginTime = DateTime.Now,
                    Nickname = "Nickname" + i,
                    RenewalInterval = -1,
                    RenewalTime = DateTime.Now,
                    SessionKey = "SessionKey" + i,
                    SignPublicKey = "SignPublicKey" + i,
                    Username = "Username" + i
                });
            }
            gridControl1.DataSource = logins;
        }

        private void InitControls()
        {
            _comboBeakLocation.Properties.Items.AddEnum(typeof(BeakPanelBeakLocation));
            _comboBeakLocation.EditValue = BeakPanelBeakLocation.Top;
            _comboBeakLocation.EditValueChanged += OnBeakLocationChanged;

            gridView1.SetStyle(false);
        }

        #endregion

        private void _btnBindDoubleClick_Click(object sender, EventArgs e)
        {
            gridView1.BindRowDoubleClick<LoginResult>(result => UtilityHelper.ShowInfoMessage(result.CorpName));
        }

        private void _btnUnbindDoubleClick_Click(object sender, EventArgs e)
        {
            gridView1.UnbindRowDoubleClick<LoginResult>();
        }

        private void _btnBindPopupMenu_Click(object sender, EventArgs e)
        {
            var colView = gridControl1.MainView as ColumnView;
            colView.BindPopup(_popupMenu2, (ColumnView columnView, BaseHitInfo hitInfo, LoginResult r) =>
            {
                var inRow = false;
                var viewKind = columnView.GetViewKind();
                if (viewKind == ColumnViewKinds.GridView) inRow = ((GridHitInfo)hitInfo).InRow;
                if (viewKind == ColumnViewKinds.BandedGridView) inRow = ((BandedGridHitInfo)hitInfo).InRow;
                if (viewKind == ColumnViewKinds.AdvBandedGridView) inRow = ((BandedGridHitInfo)hitInfo).InRow;
                if (viewKind == ColumnViewKinds.CardView) inRow = ((CardHitInfo)hitInfo).InCard;
                if (viewKind == ColumnViewKinds.LayoutView) inRow = ((LayoutViewHitInfo)hitInfo).InCard;
                if (viewKind == ColumnViewKinds.TileView) inRow = ((TileViewHitInfo)hitInfo).InItem;
                if (viewKind == ColumnViewKinds.WinExplorerView) inRow = ((WinExplorerViewHitInfo)hitInfo).InItem;
                return inRow && r.CorpId % 2 == 1;
            });
            colView.BindPopup(_popupViewRow, (ColumnView columnView, BaseHitInfo hitInfo, LoginResult r) =>
            {
                var inRow = false;
                var viewKind = colView.GetViewKind();
                if (viewKind == ColumnViewKinds.GridView) inRow = ((GridHitInfo)hitInfo).InRow;
                if (viewKind == ColumnViewKinds.BandedGridView) inRow = ((BandedGridHitInfo)hitInfo).InRow;
                if (viewKind == ColumnViewKinds.AdvBandedGridView) inRow = ((BandedGridHitInfo)hitInfo).InRow;
                if (viewKind == ColumnViewKinds.CardView) inRow = ((CardHitInfo)hitInfo).InCard;
                if (viewKind == ColumnViewKinds.LayoutView) inRow = ((LayoutViewHitInfo)hitInfo).InCard;
                if (viewKind == ColumnViewKinds.TileView) inRow = ((TileViewHitInfo)hitInfo).InItem;
                if (viewKind == ColumnViewKinds.WinExplorerView) inRow = ((WinExplorerViewHitInfo)hitInfo).InItem;
                return inRow && r.CorpId % 2 == 0;
            });
        }

        private void _btnUnbindPopupMenu_Click(object sender, EventArgs e)
        {
            (gridControl1.MainView as ColumnView).UnbindPopup<LoginResult>(_popupViewRow);
        }

        private void _bbiOne_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UtilityHelper.ShowInfoMessage((gridControl1.MainView as ColumnView).GetFocusData<LoginResult>().CorpName);
        }

        private void _btnImage2ByteTest_Click(object sender, EventArgs e)
        {
            var image = pictureEdit1.Image;
            var bytes = image.ToBytes();
            XtraMessageBox.Show(bytes?.Length.ToString());
        }

        #region [ToastMessage]

        private void _btnShowMsgSuccess_Click(object sender, EventArgs e)
        {
            ToastOptions.NewInstance(ToastKinds.Success).ShowToastMessage("成功", this);
        }

        private void _btnShowMsgError_Click(object sender, EventArgs e)
        {

            ToastOptions.NewInstance(ToastKinds.Error).ShowToastMessage("错误", this);
        }

        private void _btnShowMsgInfo_Click(object sender, EventArgs e)
        {

            ToastOptions.NewInstance(ToastKinds.Info).ShowToastMessage("信息", this);
        }

        private void _btnShowMsgWarning_Click(object sender, EventArgs e)
        {

            ToastOptions.NewInstance(ToastKinds.Warning).ShowToastMessage("警告", this);
        }

        private void _btnShowMsgControl_Click(object sender, EventArgs e)
        {
            ToastOptions.NewInstance().ShowToastControl(pictureEdit1, this);
        }

        #endregion

        #region [Beaktip]

        private void _btnBindBeaktip_Click(object sender, EventArgs e)
        {
            var options = new BeaktipOptions
            {
                TipPosition = PositionEnum.Top
            };
            _comboBeakLocation.EditValue = BeakPanelBeakLocation.Bottom;
            options.BindBeak(_btnBeakHover, new BeakContentUC());
        }

        private void _btnUnbindBeaktip_Click(object sender, EventArgs e)
        {
            _btnBeakHover.UnbindBeak();
        }

        void OnBeakLocationChanged(object sender, EventArgs e)
        {
            var option = _btnBeakHover.GetTag<BeaktipOptions>(WinUtilityConsts.BeakTooltipBeakPanelOptionsTagKey);
            if (option == null) return;
            option.BeakLocation = (BeakPanelBeakLocation)_comboBeakLocation.EditValue;
        }

        #endregion

        #region [View]

        private void _btnSetGridView_Click(object sender, EventArgs e)
        {
            gridControl1.MainView = gridView1;
        }

        private void _btnSetTileView_Click(object sender, EventArgs e)
        {
            gridControl1.MainView = tileView1;
        }

        private void _btnSetCardView_Click(object sender, EventArgs e)
        {

            gridControl1.MainView = cardView1;
        }

        private void _btnSetLayoutView_Click(object sender, EventArgs e)
        {
            gridControl1.MainView = layoutView1;
        }

        private void _btnSetWinExplorerView_Click(object sender, EventArgs e)
        {
            gridControl1.MainView = winExplorerView1;
        }

        private void _btnSetBandedGridView_Click(object sender, EventArgs e)
        {
            gridControl1.MainView = bandedGridView1;
        }

        private void _btnSetAdvBandedGridView_Click(object sender, EventArgs e)
        {
            gridControl1.MainView = advBandedGridView1;
        }

        #endregion

    }
}
