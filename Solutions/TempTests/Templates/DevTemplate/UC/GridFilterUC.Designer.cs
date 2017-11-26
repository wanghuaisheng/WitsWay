namespace WitsWay.WinTemplate.UC
{
    partial class GridFilterUc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GridFilterUc));
            this._gridNavPane = new DevExpress.XtraBars.Navigation.NavigationPane();
            this._navPageSearch = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.searchControlUC1 = new SearchUc();
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this._btnSearchReset = new DevExpress.XtraEditors.SimpleButton();
            this._btnSearchConfirm = new DevExpress.XtraEditors.SimpleButton();
            this._navPageConfig = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.listBoxControl1 = new DevExpress.XtraEditors.ListBoxControl();
            this.controlNavigator1 = new DevExpress.XtraEditors.ControlNavigator();
            this.buttonEdit1 = new DevExpress.XtraEditors.ButtonEdit();
            this._navPageDetail = new DevExpress.XtraBars.Navigation.NavigationPage();
            this._panelGrid = new DevExpress.XtraEditors.PanelControl();
            this._gridControl = new DevExpress.XtraGrid.GridControl();
            this._gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this._panelBar = new DevExpress.XtraEditors.PanelControl();
            this.standaloneBarDockControl1 = new DevExpress.XtraBars.StandaloneBarDockControl();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.barEditItem1 = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemSearchControl1 = new DevExpress.XtraEditors.Repository.RepositoryItemSearchControl();
            this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem2 = new DevExpress.XtraBars.BarSubItem();
            this.barButtonItem9 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem10 = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.pagerUC1 = new WitsWay.Utilities.Win.Controls.PagerUC();
            ((System.ComponentModel.ISupportInitialize)(this._gridNavPane)).BeginInit();
            this._gridNavPane.SuspendLayout();
            this._navPageSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this._navPageConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._panelGrid)).BeginInit();
            this._panelGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._panelBar)).BeginInit();
            this._panelBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            this.SuspendLayout();
            // 
            // _gridNavPane
            // 
            this._gridNavPane.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Italic);
            this._gridNavPane.Appearance.FontStyleDelta = System.Drawing.FontStyle.Italic;
            this._gridNavPane.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this._gridNavPane.Appearance.Options.UseFont = true;
            this._gridNavPane.Appearance.Options.UseTextOptions = true;
            this._gridNavPane.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this._gridNavPane.Controls.Add(this._navPageSearch);
            this._gridNavPane.Controls.Add(this._navPageConfig);
            this._gridNavPane.Controls.Add(this._navPageDetail);
            this._gridNavPane.Dock = System.Windows.Forms.DockStyle.Right;
            this._gridNavPane.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._gridNavPane.Location = new System.Drawing.Point(720, 0);
            this._gridNavPane.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._gridNavPane.Name = "_gridNavPane";
            this._gridNavPane.PageProperties.AllowHtmlDraw = false;
            this._gridNavPane.PageProperties.ShowExpandButton = false;
            this._gridNavPane.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this._navPageDetail,
            this._navPageSearch,
            this._navPageConfig});
            this._gridNavPane.RegularSize = new System.Drawing.Size(343, 841);
            this._gridNavPane.SelectedPage = this._navPageDetail;
            this._gridNavPane.Size = new System.Drawing.Size(343, 841);
            this._gridNavPane.TabIndex = 1;
            this._gridNavPane.Text = "功能区";
            this._gridNavPane.TransitionType = DevExpress.Utils.Animation.Transitions.Cover;
            // 
            // _navPageSearch
            // 
            this._navPageSearch.Caption = "搜索";
            this._navPageSearch.Controls.Add(this.searchControlUC1);
            this._navPageSearch.Controls.Add(this.splitterControl1);
            this._navPageSearch.Controls.Add(this.panelControl2);
            this._navPageSearch.Image = global::WitsWay.WinTemplate.Properties.Resources.zoom100_32x32;
            this._navPageSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._navPageSearch.Name = "_navPageSearch";
            this._navPageSearch.PageText = "搜索";
            this._navPageSearch.Properties.AppearanceCaption.Image = ((System.Drawing.Image)(resources.GetObject("_navPageSearch.Properties.AppearanceCaption.Image")));
            this._navPageSearch.Properties.AppearanceCaption.Options.UseImage = true;
            this._navPageSearch.Properties.ShowCollapseButton = DevExpress.Utils.DefaultBoolean.True;
            this._navPageSearch.Properties.ShowExpandButton = DevExpress.Utils.DefaultBoolean.False;
            this._navPageSearch.Properties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.Image;
            this._navPageSearch.Size = new System.Drawing.Size(269, 771);
            // 
            // searchControlUC1
            // 
            this.searchControlUC1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchControlUC1.Location = new System.Drawing.Point(0, 0);
            this.searchControlUC1.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.searchControlUC1.Name = "searchControlUC1";
            this.searchControlUC1.Size = new System.Drawing.Size(269, 702);
            this.searchControlUC1.TabIndex = 8;
            // 
            // splitterControl1
            // 
            this.splitterControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitterControl1.Location = new System.Drawing.Point(0, 702);
            this.splitterControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(269, 6);
            this.splitterControl1.TabIndex = 7;
            this.splitterControl1.TabStop = false;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this._btnSearchReset);
            this.panelControl2.Controls.Add(this._btnSearchConfirm);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(0, 708);
            this.panelControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(269, 63);
            this.panelControl2.TabIndex = 6;
            // 
            // _btnSearchReset
            // 
            this._btnSearchReset.Location = new System.Drawing.Point(176, 15);
            this._btnSearchReset.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._btnSearchReset.Name = "_btnSearchReset";
            this._btnSearchReset.Size = new System.Drawing.Size(86, 30);
            this._btnSearchReset.TabIndex = 6;
            this._btnSearchReset.Text = "重置";
            this._btnSearchReset.Click += new System.EventHandler(this._btnSearchReset_Click);
            // 
            // _btnSearchConfirm
            // 
            this._btnSearchConfirm.Location = new System.Drawing.Point(86, 15);
            this._btnSearchConfirm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._btnSearchConfirm.Name = "_btnSearchConfirm";
            this._btnSearchConfirm.Size = new System.Drawing.Size(86, 30);
            this._btnSearchConfirm.TabIndex = 5;
            this._btnSearchConfirm.Text = "确定";
            this._btnSearchConfirm.Click += new System.EventHandler(this._btnSearchConfirm_Click);
            // 
            // _navPageConfig
            // 
            this._navPageConfig.Caption = "设置";
            this._navPageConfig.Controls.Add(this.listBoxControl1);
            this._navPageConfig.Controls.Add(this.controlNavigator1);
            this._navPageConfig.Controls.Add(this.buttonEdit1);
            this._navPageConfig.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._navPageConfig.Image = global::WitsWay.WinTemplate.Properties.Resources.pagesetup_32x32;
            this._navPageConfig.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._navPageConfig.Name = "_navPageConfig";
            this._navPageConfig.PageText = "设置";
            this._navPageConfig.Properties.ShowCollapseButton = DevExpress.Utils.DefaultBoolean.False;
            this._navPageConfig.Properties.ShowExpandButton = DevExpress.Utils.DefaultBoolean.False;
            this._navPageConfig.Properties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.Image;
            this._navPageConfig.Size = new System.Drawing.Size(269, 782);
            // 
            // listBoxControl1
            // 
            this.listBoxControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.listBoxControl1.Items.AddRange(new object[] {
            "列1",
            "列2",
            "列3",
            "列4"});
            this.listBoxControl1.Location = new System.Drawing.Point(58, 237);
            this.listBoxControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listBoxControl1.Name = "listBoxControl1";
            this.listBoxControl1.Size = new System.Drawing.Size(137, 122);
            this.listBoxControl1.TabIndex = 0;
            // 
            // controlNavigator1
            // 
            this.controlNavigator1.Location = new System.Drawing.Point(39, 426);
            this.controlNavigator1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.controlNavigator1.Name = "controlNavigator1";
            this.controlNavigator1.Size = new System.Drawing.Size(191, 31);
            this.controlNavigator1.TabIndex = 1;
            this.controlNavigator1.Text = "controlNavigator1";
            // 
            // buttonEdit1
            // 
            this.buttonEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEdit1.EditValue = "筛选条件：用户名=“张三”";
            this.buttonEdit1.Location = new System.Drawing.Point(36, 381);
            this.buttonEdit1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonEdit1.Name = "buttonEdit1";
            this.buttonEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.buttonEdit1.Size = new System.Drawing.Size(183, 24);
            this.buttonEdit1.TabIndex = 2;
            // 
            // _navPageDetail
            // 
            this._navPageDetail.Appearance.FontStyleDelta = System.Drawing.FontStyle.Underline;
            this._navPageDetail.Appearance.Options.UseFont = true;
            this._navPageDetail.Caption = "详情";
            this._navPageDetail.CustomHeaderButtons.AddRange(new DevExpress.XtraBars.Docking2010.IButton[] {
            new DevExpress.XtraBars.Docking.CustomHeaderButton()});
            this._navPageDetail.Image = global::WitsWay.WinTemplate.Properties.Resources.textbox_32x32;
            this._navPageDetail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._navPageDetail.Name = "_navPageDetail";
            this._navPageDetail.PageText = "详情";
            this._navPageDetail.Properties.AppearanceCaption.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this._navPageDetail.Properties.AppearanceCaption.ForeColor = System.Drawing.Color.Red;
            this._navPageDetail.Properties.AppearanceCaption.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this._navPageDetail.Properties.AppearanceCaption.Options.UseFont = true;
            this._navPageDetail.Properties.AppearanceCaption.Options.UseForeColor = true;
            this._navPageDetail.Properties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.Image;
            this._navPageDetail.Size = new System.Drawing.Size(269, 771);
            // 
            // _panelGrid
            // 
            this._panelGrid.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this._panelGrid.Controls.Add(this._gridControl);
            this._panelGrid.Controls.Add(this._panelBar);
            this._panelGrid.Controls.Add(this.panelControl3);
            this._panelGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this._panelGrid.Location = new System.Drawing.Point(0, 0);
            this._panelGrid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._panelGrid.Name = "_panelGrid";
            this._panelGrid.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._panelGrid.Size = new System.Drawing.Size(720, 841);
            this._panelGrid.TabIndex = 2;
            // 
            // _gridControl
            // 
            this._gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._gridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._gridControl.Location = new System.Drawing.Point(3, 47);
            this._gridControl.MainView = this._gridView;
            this._gridControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._gridControl.Name = "_gridControl";
            this._gridControl.Size = new System.Drawing.Size(714, 751);
            this._gridControl.TabIndex = 6;
            this._gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this._gridView});
            // 
            // _gridView
            // 
            this._gridView.GridControl = this._gridControl;
            this._gridView.Name = "_gridView";
            this._gridView.OptionsView.ShowGroupPanel = false;
            // 
            // _panelBar
            // 
            this._panelBar.AutoSize = true;
            this._panelBar.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this._panelBar.Controls.Add(this.standaloneBarDockControl1);
            this._panelBar.Dock = System.Windows.Forms.DockStyle.Top;
            this._panelBar.Location = new System.Drawing.Point(3, 4);
            this._panelBar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._panelBar.Name = "_panelBar";
            this._panelBar.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this._panelBar.Size = new System.Drawing.Size(714, 43);
            this._panelBar.TabIndex = 7;
            // 
            // standaloneBarDockControl1
            // 
            this.standaloneBarDockControl1.AutoSize = true;
            this.standaloneBarDockControl1.CausesValidation = false;
            this.standaloneBarDockControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.standaloneBarDockControl1.Location = new System.Drawing.Point(0, 0);
            this.standaloneBarDockControl1.Manager = this.barManager1;
            this.standaloneBarDockControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.standaloneBarDockControl1.Name = "standaloneBarDockControl1";
            this.standaloneBarDockControl1.Size = new System.Drawing.Size(714, 39);
            this.standaloneBarDockControl1.Text = "standaloneBarDockControl1";
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.DockControls.Add(this.standaloneBarDockControl1);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem1,
            this.barButtonItem2,
            this.barEditItem1,
            this.barSubItem1,
            this.barButtonItem4,
            this.barButtonItem5,
            this.barStaticItem1,
            this.barSubItem2,
            this.barButtonItem6,
            this.barButtonItem9,
            this.barButtonItem10});
            this.barManager1.MaxItemId = 23;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemSearchControl1});
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem2),
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem1),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Width, this.barEditItem1, "", false, true, true, 155),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem6),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem2),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem1)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.StandaloneBarDockControl = this.standaloneBarDockControl1;
            this.bar1.Text = "Tools";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barButtonItem1.Caption = "添加";
            this.barButtonItem1.Id = 0;
            this.barButtonItem1.ImageOptions.Image = global::WitsWay.WinTemplate.Properties.Resources.add1;
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barButtonItem2.Caption = "修改";
            this.barButtonItem2.Id = 1;
            this.barButtonItem2.ImageOptions.Image = global::WitsWay.WinTemplate.Properties.Resources.application_edit;
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Caption = "用户列表";
            this.barStaticItem1.Id = 9;
            this.barStaticItem1.Name = "barStaticItem1";
            // 
            // barEditItem1
            // 
            this.barEditItem1.Caption = "barEditItem1";
            this.barEditItem1.Edit = this.repositoryItemSearchControl1;
            this.barEditItem1.Id = 2;
            this.barEditItem1.Name = "barEditItem1";
            // 
            // repositoryItemSearchControl1
            // 
            this.repositoryItemSearchControl1.AutoHeight = false;
            this.repositoryItemSearchControl1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this.repositoryItemSearchControl1.Name = "repositoryItemSearchControl1";
            // 
            // barButtonItem6
            // 
            this.barButtonItem6.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barButtonItem6.Caption = "删除";
            this.barButtonItem6.Id = 11;
            this.barButtonItem6.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem6.ImageOptions.Image")));
            this.barButtonItem6.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem6.ImageOptions.LargeImage")));
            this.barButtonItem6.Name = "barButtonItem6";
            this.barButtonItem6.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barSubItem2
            // 
            this.barSubItem2.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barSubItem2.Caption = "操作";
            this.barSubItem2.Id = 10;
            this.barSubItem2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barSubItem2.ImageOptions.Image")));
            this.barSubItem2.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barSubItem2.ImageOptions.LargeImage")));
            this.barSubItem2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem9),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem10)});
            this.barSubItem2.Name = "barSubItem2";
            this.barSubItem2.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barButtonItem9
            // 
            this.barButtonItem9.Caption = "刷新";
            this.barButtonItem9.Id = 14;
            this.barButtonItem9.Name = "barButtonItem9";
            // 
            // barButtonItem10
            // 
            this.barButtonItem10.Caption = "全屏";
            this.barButtonItem10.Id = 15;
            this.barButtonItem10.Name = "barButtonItem10";
            // 
            // barSubItem1
            // 
            this.barSubItem1.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barSubItem1.Caption = "查看";
            this.barSubItem1.Id = 6;
            this.barSubItem1.ImageOptions.Image = global::WitsWay.WinTemplate.Properties.Resources.application_view_tile;
            this.barSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem4),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem5)});
            this.barSubItem1.Name = "barSubItem1";
            this.barSubItem1.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "最优列宽";
            this.barButtonItem4.Id = 7;
            this.barButtonItem4.Name = "barButtonItem4";
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "自动列宽";
            this.barButtonItem5.Id = 8;
            this.barButtonItem5.Name = "barButtonItem5";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlTop.Size = new System.Drawing.Size(1063, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 841);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlBottom.Size = new System.Drawing.Size(1063, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 841);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1063, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 841);
            // 
            // panelControl3
            // 
            this.panelControl3.AutoSize = true;
            this.panelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl3.Controls.Add(this.pagerUC1);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl3.Location = new System.Drawing.Point(3, 798);
            this.panelControl3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(714, 39);
            this.panelControl3.TabIndex = 5;
            // 
            // pagerUC1
            // 
            this.pagerUC1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pagerUC1.Location = new System.Drawing.Point(0, 0);
            this.pagerUC1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.pagerUC1.Name = "pagerUC1";
            this.pagerUC1.PageSizeAllow = ((System.Collections.Generic.List<int>)(resources.GetObject("pagerUC1.PageSizeAllow")));
            this.pagerUC1.Size = new System.Drawing.Size(714, 39);
            this.pagerUC1.TabIndex = 3;
            // 
            // GridFilterUc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._panelGrid);
            this.Controls.Add(this._gridNavPane);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "GridFilterUc";
            this.Size = new System.Drawing.Size(1063, 841);
            ((System.ComponentModel.ISupportInitialize)(this._gridNavPane)).EndInit();
            this._gridNavPane.ResumeLayout(false);
            this._navPageSearch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this._navPageConfig.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._panelGrid)).EndInit();
            this._panelGrid.ResumeLayout(false);
            this._panelGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._panelBar)).EndInit();
            this._panelBar.ResumeLayout(false);
            this._panelBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Navigation.NavigationPane _gridNavPane;
        private DevExpress.XtraBars.Navigation.NavigationPage _navPageSearch;
        private DevExpress.XtraEditors.PanelControl _panelGrid;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton _btnSearchReset;
        private DevExpress.XtraEditors.SimpleButton _btnSearchConfirm;
        private DevExpress.XtraEditors.SplitterControl splitterControl1;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraGrid.GridControl _gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView _gridView;
        private DevExpress.XtraEditors.ControlNavigator controlNavigator1;
        private DevExpress.XtraBars.Navigation.NavigationPage _navPageConfig;
        private DevExpress.XtraEditors.ListBoxControl listBoxControl1;
        private DevExpress.XtraEditors.ButtonEdit buttonEdit1;
        private DevExpress.XtraEditors.PanelControl _panelBar;
        private DevExpress.XtraBars.StandaloneBarDockControl standaloneBarDockControl1;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarEditItem barEditItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchControl repositoryItemSearchControl1;
        private DevExpress.XtraBars.Navigation.NavigationPage _navPageDetail;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem6;
        private DevExpress.XtraBars.BarSubItem barSubItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem9;
        private DevExpress.XtraBars.BarButtonItem barButtonItem10;
        private WitsWay.Utilities.Win.Controls.PagerUC pagerUC1;
        private SearchUc searchControlUC1;
    }
}