namespace WitsWay.Utilities.Win.Tests
{
    partial class TestForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestForm));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.advBandedGridView1 = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.tileView1 = new DevExpress.XtraGrid.Views.Tile.TileView();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cardView1 = new DevExpress.XtraGrid.Views.Card.CardView();
            this.layoutView1 = new DevExpress.XtraGrid.Views.Layout.LayoutView();
            this.layoutViewCard1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewCard();
            this.winExplorerView1 = new DevExpress.XtraGrid.Views.WinExplorer.WinExplorerView();
            this.bandedGridView1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this._btnBindDoubleClick = new DevExpress.XtraEditors.SimpleButton();
            this._btnUnbindDoubleClick = new DevExpress.XtraEditors.SimpleButton();
            this._btnBindPopupMenu = new DevExpress.XtraEditors.SimpleButton();
            this._barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this._bbiOne = new DevExpress.XtraBars.BarButtonItem();
            this._bbiTwo = new DevExpress.XtraBars.BarButtonItem();
            this._popupViewRow = new DevExpress.XtraBars.PopupMenu(this.components);
            this._btnUnbindPopupMenu = new DevExpress.XtraEditors.SimpleButton();
            this._btnShowMsgSuccess = new DevExpress.XtraEditors.SimpleButton();
            this._btnShowMsgError = new DevExpress.XtraEditors.SimpleButton();
            this._btnShowMsgInfo = new DevExpress.XtraEditors.SimpleButton();
            this._btnShowMsgWarning = new DevExpress.XtraEditors.SimpleButton();
            this._btnShowMsgControl = new DevExpress.XtraEditors.SimpleButton();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this._btnBeakHover = new System.Windows.Forms.Button();
            this._btnUnbindBeaktip = new DevExpress.XtraEditors.SimpleButton();
            this._btnBindBeaktip = new DevExpress.XtraEditors.SimpleButton();
            this._comboBeakLocation = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this._btnImage2ByteTest = new DevExpress.XtraEditors.SimpleButton();
            this._btnSetGridView = new DevExpress.XtraEditors.SimpleButton();
            this._btnSetTileView = new DevExpress.XtraEditors.SimpleButton();
            this._btnSetCardView = new DevExpress.XtraEditors.SimpleButton();
            this._btnSetLayoutView = new DevExpress.XtraEditors.SimpleButton();
            this._btnSetWinExplorerView = new DevExpress.XtraEditors.SimpleButton();
            this._btnSetBandedGridView = new DevExpress.XtraEditors.SimpleButton();
            this._btnSetAdvBandedGridView = new DevExpress.XtraEditors.SimpleButton();
            this._popupMenu2 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.advBandedGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.winExplorerView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._popupViewRow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._comboBeakLocation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._popupMenu2)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.gridControl1.Location = new System.Drawing.Point(10, 50);
            this.gridControl1.MainView = this.advBandedGridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(800, 533);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.advBandedGridView1,
            this.tileView1,
            this.gridView1,
            this.cardView1,
            this.layoutView1,
            this.winExplorerView1,
            this.bandedGridView1});
            // 
            // advBandedGridView1
            // 
            this.advBandedGridView1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand2});
            this.advBandedGridView1.GridControl = this.gridControl1;
            this.advBandedGridView1.Name = "advBandedGridView1";
            // 
            // gridBand2
            // 
            this.gridBand2.Caption = "gridBand1";
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.VisibleIndex = 0;
            // 
            // tileView1
            // 
            this.tileView1.GridControl = this.gridControl1;
            this.tileView1.Name = "tileView1";
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // cardView1
            // 
            this.cardView1.FocusedCardTopFieldIndex = 0;
            this.cardView1.GridControl = this.gridControl1;
            this.cardView1.Name = "cardView1";
            // 
            // layoutView1
            // 
            this.layoutView1.GridControl = this.gridControl1;
            this.layoutView1.Name = "layoutView1";
            this.layoutView1.TemplateCard = this.layoutViewCard1;
            // 
            // layoutViewCard1
            // 
            this.layoutViewCard1.HeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.layoutViewCard1.Name = "layoutViewTemplateCard";
            // 
            // winExplorerView1
            // 
            this.winExplorerView1.GridControl = this.gridControl1;
            this.winExplorerView1.Name = "winExplorerView1";
            // 
            // bandedGridView1
            // 
            this.bandedGridView1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1});
            this.bandedGridView1.GridControl = this.gridControl1;
            this.bandedGridView1.Name = "bandedGridView1";
            // 
            // gridBand1
            // 
            this.gridBand1.Caption = "gridBand1";
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.VisibleIndex = 0;
            // 
            // _btnBindDoubleClick
            // 
            this._btnBindDoubleClick.Location = new System.Drawing.Point(146, 21);
            this._btnBindDoubleClick.Name = "_btnBindDoubleClick";
            this._btnBindDoubleClick.Size = new System.Drawing.Size(75, 23);
            this._btnBindDoubleClick.TabIndex = 1;
            this._btnBindDoubleClick.Text = "绑定双击";
            this._btnBindDoubleClick.Click += new System.EventHandler(this._btnBindDoubleClick_Click);
            // 
            // _btnUnbindDoubleClick
            // 
            this._btnUnbindDoubleClick.Location = new System.Drawing.Point(227, 21);
            this._btnUnbindDoubleClick.Name = "_btnUnbindDoubleClick";
            this._btnUnbindDoubleClick.Size = new System.Drawing.Size(75, 23);
            this._btnUnbindDoubleClick.TabIndex = 2;
            this._btnUnbindDoubleClick.Text = "解绑双击";
            this._btnUnbindDoubleClick.Click += new System.EventHandler(this._btnUnbindDoubleClick_Click);
            // 
            // _btnBindPopupMenu
            // 
            this._btnBindPopupMenu.Location = new System.Drawing.Point(309, 21);
            this._btnBindPopupMenu.Name = "_btnBindPopupMenu";
            this._btnBindPopupMenu.Size = new System.Drawing.Size(96, 23);
            this._btnBindPopupMenu.TabIndex = 3;
            this._btnBindPopupMenu.Text = "绑定右键菜单";
            this._btnBindPopupMenu.Click += new System.EventHandler(this._btnBindPopupMenu_Click);
            // 
            // _barManager
            // 
            this._barManager.DockControls.Add(this.barDockControlTop);
            this._barManager.DockControls.Add(this.barDockControlBottom);
            this._barManager.DockControls.Add(this.barDockControlLeft);
            this._barManager.DockControls.Add(this.barDockControlRight);
            this._barManager.Form = this;
            this._barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this._bbiOne,
            this._bbiTwo,
            this.barButtonItem1,
            this.barButtonItem2});
            this._barManager.MaxItemId = 4;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(10, 50);
            this.barDockControlTop.Manager = this._barManager;
            this.barDockControlTop.Size = new System.Drawing.Size(1133, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(10, 583);
            this.barDockControlBottom.Manager = this._barManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(1133, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(10, 50);
            this.barDockControlLeft.Manager = this._barManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 533);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1143, 50);
            this.barDockControlRight.Manager = this._barManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 533);
            // 
            // _bbiOne
            // 
            this._bbiOne.Caption = "菜单一";
            this._bbiOne.Id = 0;
            this._bbiOne.Name = "_bbiOne";
            this._bbiOne.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this._bbiOne_ItemClick);
            // 
            // _bbiTwo
            // 
            this._bbiTwo.Caption = "菜单二";
            this._bbiTwo.Id = 1;
            this._bbiTwo.Name = "_bbiTwo";
            // 
            // _popupViewRow
            // 
            this._popupViewRow.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this._bbiOne),
            new DevExpress.XtraBars.LinkPersistInfo(this._bbiTwo)});
            this._popupViewRow.Manager = this._barManager;
            this._popupViewRow.Name = "_popupViewRow";
            // 
            // _btnUnbindPopupMenu
            // 
            this._btnUnbindPopupMenu.Location = new System.Drawing.Point(411, 21);
            this._btnUnbindPopupMenu.Name = "_btnUnbindPopupMenu";
            this._btnUnbindPopupMenu.Size = new System.Drawing.Size(97, 23);
            this._btnUnbindPopupMenu.TabIndex = 4;
            this._btnUnbindPopupMenu.Text = "解绑右键菜单";
            this._btnUnbindPopupMenu.Click += new System.EventHandler(this._btnUnbindPopupMenu_Click);
            // 
            // _btnShowMsgSuccess
            // 
            this._btnShowMsgSuccess.Location = new System.Drawing.Point(517, 21);
            this._btnShowMsgSuccess.Name = "_btnShowMsgSuccess";
            this._btnShowMsgSuccess.Size = new System.Drawing.Size(75, 23);
            this._btnShowMsgSuccess.TabIndex = 9;
            this._btnShowMsgSuccess.Text = "显示Success";
            this._btnShowMsgSuccess.Click += new System.EventHandler(this._btnShowMsgSuccess_Click);
            // 
            // _btnShowMsgError
            // 
            this._btnShowMsgError.Location = new System.Drawing.Point(598, 21);
            this._btnShowMsgError.Name = "_btnShowMsgError";
            this._btnShowMsgError.Size = new System.Drawing.Size(75, 23);
            this._btnShowMsgError.TabIndex = 10;
            this._btnShowMsgError.Text = "显示Error";
            this._btnShowMsgError.Click += new System.EventHandler(this._btnShowMsgError_Click);
            // 
            // _btnShowMsgInfo
            // 
            this._btnShowMsgInfo.Location = new System.Drawing.Point(679, 21);
            this._btnShowMsgInfo.Name = "_btnShowMsgInfo";
            this._btnShowMsgInfo.Size = new System.Drawing.Size(75, 23);
            this._btnShowMsgInfo.TabIndex = 11;
            this._btnShowMsgInfo.Text = "显示Info";
            this._btnShowMsgInfo.Click += new System.EventHandler(this._btnShowMsgInfo_Click);
            // 
            // _btnShowMsgWarning
            // 
            this._btnShowMsgWarning.Location = new System.Drawing.Point(760, 21);
            this._btnShowMsgWarning.Name = "_btnShowMsgWarning";
            this._btnShowMsgWarning.Size = new System.Drawing.Size(75, 23);
            this._btnShowMsgWarning.TabIndex = 12;
            this._btnShowMsgWarning.Text = "显示Warning";
            this._btnShowMsgWarning.Click += new System.EventHandler(this._btnShowMsgWarning_Click);
            // 
            // _btnShowMsgControl
            // 
            this._btnShowMsgControl.Location = new System.Drawing.Point(850, 21);
            this._btnShowMsgControl.Name = "_btnShowMsgControl";
            this._btnShowMsgControl.Size = new System.Drawing.Size(75, 23);
            this._btnShowMsgControl.TabIndex = 17;
            this._btnShowMsgControl.Text = "显示Control";
            this._btnShowMsgControl.Click += new System.EventHandler(this._btnShowMsgControl_Click);
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureEdit1.EditValue = ((object)(resources.GetObject("pictureEdit1.EditValue")));
            this.pictureEdit1.Location = new System.Drawing.Point(1008, 21);
            this.pictureEdit1.MenuManager = this._barManager;
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Size = new System.Drawing.Size(100, 96);
            this.pictureEdit1.TabIndex = 18;
            // 
            // _btnBeakHover
            // 
            this._btnBeakHover.Location = new System.Drawing.Point(895, 270);
            this._btnBeakHover.Name = "_btnBeakHover";
            this._btnBeakHover.Size = new System.Drawing.Size(96, 93);
            this._btnBeakHover.TabIndex = 23;
            this._btnBeakHover.Text = "鼠标移入显示Beaktip";
            this._btnBeakHover.UseVisualStyleBackColor = true;
            // 
            // _btnUnbindBeaktip
            // 
            this._btnUnbindBeaktip.Location = new System.Drawing.Point(1008, 300);
            this._btnUnbindBeaktip.Name = "_btnUnbindBeaktip";
            this._btnUnbindBeaktip.Size = new System.Drawing.Size(100, 23);
            this._btnUnbindBeaktip.TabIndex = 24;
            this._btnUnbindBeaktip.Text = "移除Beaktip绑定";
            this._btnUnbindBeaktip.Click += new System.EventHandler(this._btnUnbindBeaktip_Click);
            // 
            // _btnBindBeaktip
            // 
            this._btnBindBeaktip.Location = new System.Drawing.Point(1008, 270);
            this._btnBindBeaktip.Name = "_btnBindBeaktip";
            this._btnBindBeaktip.Size = new System.Drawing.Size(100, 23);
            this._btnBindBeaktip.TabIndex = 25;
            this._btnBindBeaktip.Text = "绑定Beaktip";
            this._btnBindBeaktip.Click += new System.EventHandler(this._btnBindBeaktip_Click);
            // 
            // _comboBeakLocation
            // 
            this._comboBeakLocation.Location = new System.Drawing.Point(1008, 343);
            this._comboBeakLocation.Name = "_comboBeakLocation";
            this._comboBeakLocation.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this._comboBeakLocation.Size = new System.Drawing.Size(100, 20);
            this._comboBeakLocation.TabIndex = 26;
            // 
            // _btnImage2ByteTest
            // 
            this._btnImage2ByteTest.Location = new System.Drawing.Point(850, 54);
            this._btnImage2ByteTest.Name = "_btnImage2ByteTest";
            this._btnImage2ByteTest.Size = new System.Drawing.Size(75, 23);
            this._btnImage2ByteTest.TabIndex = 31;
            this._btnImage2ByteTest.Text = "Image2Byte";
            this._btnImage2ByteTest.Click += new System.EventHandler(this._btnImage2ByteTest_Click);
            // 
            // _btnSetGridView
            // 
            this._btnSetGridView.Location = new System.Drawing.Point(871, 136);
            this._btnSetGridView.Name = "_btnSetGridView";
            this._btnSetGridView.Size = new System.Drawing.Size(75, 23);
            this._btnSetGridView.TabIndex = 36;
            this._btnSetGridView.Text = "GridView";
            this._btnSetGridView.Click += new System.EventHandler(this._btnSetGridView_Click);
            // 
            // _btnSetTileView
            // 
            this._btnSetTileView.Location = new System.Drawing.Point(952, 136);
            this._btnSetTileView.Name = "_btnSetTileView";
            this._btnSetTileView.Size = new System.Drawing.Size(75, 23);
            this._btnSetTileView.TabIndex = 37;
            this._btnSetTileView.Text = "TileView";
            this._btnSetTileView.Click += new System.EventHandler(this._btnSetTileView_Click);
            // 
            // _btnSetCardView
            // 
            this._btnSetCardView.Location = new System.Drawing.Point(1033, 136);
            this._btnSetCardView.Name = "_btnSetCardView";
            this._btnSetCardView.Size = new System.Drawing.Size(75, 23);
            this._btnSetCardView.TabIndex = 38;
            this._btnSetCardView.Text = "CardView";
            this._btnSetCardView.Click += new System.EventHandler(this._btnSetCardView_Click);
            // 
            // _btnSetLayoutView
            // 
            this._btnSetLayoutView.Location = new System.Drawing.Point(871, 165);
            this._btnSetLayoutView.Name = "_btnSetLayoutView";
            this._btnSetLayoutView.Size = new System.Drawing.Size(75, 23);
            this._btnSetLayoutView.TabIndex = 39;
            this._btnSetLayoutView.Text = "LayoutView";
            this._btnSetLayoutView.Click += new System.EventHandler(this._btnSetLayoutView_Click);
            // 
            // _btnSetWinExplorerView
            // 
            this._btnSetWinExplorerView.Location = new System.Drawing.Point(952, 165);
            this._btnSetWinExplorerView.Name = "_btnSetWinExplorerView";
            this._btnSetWinExplorerView.Size = new System.Drawing.Size(156, 23);
            this._btnSetWinExplorerView.TabIndex = 40;
            this._btnSetWinExplorerView.Text = "WinExplorerView";
            this._btnSetWinExplorerView.Click += new System.EventHandler(this._btnSetWinExplorerView_Click);
            // 
            // _btnSetBandedGridView
            // 
            this._btnSetBandedGridView.Location = new System.Drawing.Point(871, 194);
            this._btnSetBandedGridView.Name = "_btnSetBandedGridView";
            this._btnSetBandedGridView.Size = new System.Drawing.Size(112, 23);
            this._btnSetBandedGridView.TabIndex = 41;
            this._btnSetBandedGridView.Text = "BandedGridView";
            this._btnSetBandedGridView.Click += new System.EventHandler(this._btnSetBandedGridView_Click);
            // 
            // _btnSetAdvBandedGridView
            // 
            this._btnSetAdvBandedGridView.Location = new System.Drawing.Point(989, 194);
            this._btnSetAdvBandedGridView.Name = "_btnSetAdvBandedGridView";
            this._btnSetAdvBandedGridView.Size = new System.Drawing.Size(119, 23);
            this._btnSetAdvBandedGridView.TabIndex = 42;
            this._btnSetAdvBandedGridView.Text = "AdvBandedGridView";
            this._btnSetAdvBandedGridView.Click += new System.EventHandler(this._btnSetAdvBandedGridView_Click);
            // 
            // _popupMenu2
            // 
            this._popupMenu2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem2)});
            this._popupMenu2.Manager = this._barManager;
            this._popupMenu2.Name = "_popupMenu2";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.Id = 2;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "barButtonItem2";
            this.barButtonItem2.Id = 3;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1153, 593);
            this.Controls.Add(this._btnSetAdvBandedGridView);
            this.Controls.Add(this._btnSetBandedGridView);
            this.Controls.Add(this._btnSetWinExplorerView);
            this.Controls.Add(this._btnSetLayoutView);
            this.Controls.Add(this._btnSetCardView);
            this.Controls.Add(this._btnSetTileView);
            this.Controls.Add(this._btnSetGridView);
            this.Controls.Add(this._btnImage2ByteTest);
            this.Controls.Add(this._comboBeakLocation);
            this.Controls.Add(this._btnBindBeaktip);
            this.Controls.Add(this._btnUnbindBeaktip);
            this.Controls.Add(this._btnBeakHover);
            this.Controls.Add(this.pictureEdit1);
            this.Controls.Add(this._btnShowMsgControl);
            this.Controls.Add(this._btnShowMsgWarning);
            this.Controls.Add(this._btnShowMsgInfo);
            this.Controls.Add(this._btnShowMsgError);
            this.Controls.Add(this._btnShowMsgSuccess);
            this.Controls.Add(this._btnUnbindPopupMenu);
            this.Controls.Add(this._btnBindPopupMenu);
            this.Controls.Add(this._btnUnbindDoubleClick);
            this.Controls.Add(this._btnBindDoubleClick);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "TestForm";
            this.Padding = new System.Windows.Forms.Padding(10, 50, 10, 10);
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.advBandedGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.winExplorerView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._popupViewRow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._comboBeakLocation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._popupMenu2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton _btnBindDoubleClick;
        private DevExpress.XtraEditors.SimpleButton _btnUnbindDoubleClick;
        private DevExpress.XtraEditors.SimpleButton _btnBindPopupMenu;
        private DevExpress.XtraBars.BarManager _barManager;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem _bbiOne;
        private DevExpress.XtraBars.BarButtonItem _bbiTwo;
        private DevExpress.XtraBars.PopupMenu _popupViewRow;
        private DevExpress.XtraEditors.SimpleButton _btnUnbindPopupMenu;
        private DevExpress.XtraEditors.SimpleButton _btnShowMsgWarning;
        private DevExpress.XtraEditors.SimpleButton _btnShowMsgInfo;
        private DevExpress.XtraEditors.SimpleButton _btnShowMsgError;
        private DevExpress.XtraEditors.SimpleButton _btnShowMsgSuccess;
        private DevExpress.XtraEditors.SimpleButton _btnShowMsgControl;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private System.Windows.Forms.Button _btnBeakHover;
        private DevExpress.XtraEditors.SimpleButton _btnBindBeaktip;
        private DevExpress.XtraEditors.SimpleButton _btnUnbindBeaktip;
        private DevExpress.XtraEditors.ImageComboBoxEdit _comboBeakLocation;
        private DevExpress.XtraEditors.SimpleButton _btnImage2ByteTest;
        private DevExpress.XtraGrid.Views.Tile.TileView tileView1;
        private DevExpress.XtraEditors.SimpleButton _btnSetAdvBandedGridView;
        private DevExpress.XtraEditors.SimpleButton _btnSetBandedGridView;
        private DevExpress.XtraEditors.SimpleButton _btnSetWinExplorerView;
        private DevExpress.XtraEditors.SimpleButton _btnSetLayoutView;
        private DevExpress.XtraEditors.SimpleButton _btnSetCardView;
        private DevExpress.XtraEditors.SimpleButton _btnSetTileView;
        private DevExpress.XtraEditors.SimpleButton _btnSetGridView;
        private DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView advBandedGridView1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.Card.CardView cardView1;
        private DevExpress.XtraGrid.Views.Layout.LayoutView layoutView1;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewCard layoutViewCard1;
        private DevExpress.XtraGrid.Views.WinExplorer.WinExplorerView winExplorerView1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView bandedGridView1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.PopupMenu _popupMenu2;
    }
}

