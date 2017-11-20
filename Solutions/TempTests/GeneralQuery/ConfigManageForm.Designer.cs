namespace WitsWay.TempTests.GeneralQuery
{
    partial class ConfigManageForm
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
            this._panelControl = new DevExpress.XtraEditors.PanelControl();
            this._viewControl = new DevExpress.XtraBars.Ribbon.BackstageViewControl();
            this._viewClient = new DevExpress.XtraBars.Ribbon.BackstageViewClientControl();
            this._panelConfigUc = new DevExpress.XtraEditors.PanelControl();
            this._panelCommands = new DevExpress.XtraEditors.PanelControl();
            this._barDockControl = new DevExpress.XtraBars.StandaloneBarDockControl();
            this._barManager = new DevExpress.XtraBars.BarManager();
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this._viewTabItem = new DevExpress.XtraBars.Ribbon.BackstageViewTabItem();
            ((System.ComponentModel.ISupportInitialize)(this._panelControl)).BeginInit();
            this._panelControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._viewControl)).BeginInit();
            this._viewControl.SuspendLayout();
            this._viewClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._panelConfigUc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._panelCommands)).BeginInit();
            this._panelCommands.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._barManager)).BeginInit();
            this.SuspendLayout();
            // 
            // _panelControl
            // 
            this._panelControl.Controls.Add(this._viewControl);
            this._panelControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._panelControl.Location = new System.Drawing.Point(6, 6);
            this._panelControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._panelControl.Name = "_panelControl";
            this._panelControl.Size = new System.Drawing.Size(1116, 820);
            this._panelControl.TabIndex = 1;
            // 
            // _viewControl
            // 
            this._viewControl.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.Yellow;
            this._viewControl.Controls.Add(this._viewClient);
            this._viewControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._viewControl.Items.Add(this._viewTabItem);
            this._viewControl.Location = new System.Drawing.Point(2, 2);
            this._viewControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._viewControl.Name = "_viewControl";
            this._viewControl.SelectedTab = this._viewTabItem;
            this._viewControl.SelectedTabIndex = 0;
            this._viewControl.Size = new System.Drawing.Size(1112, 816);
            this._viewControl.TabIndex = 0;
            this._viewControl.Text = "backstageViewControl1";
            // 
            // _viewClient
            // 
            this._viewClient.Controls.Add(this._panelConfigUc);
            this._viewClient.Controls.Add(this._panelCommands);
            this._viewClient.Location = new System.Drawing.Point(165, 0);
            this._viewClient.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._viewClient.Name = "_viewClient";
            this._viewClient.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this._viewClient.Size = new System.Drawing.Size(947, 816);
            this._viewClient.TabIndex = 1;
            // 
            // _panelConfigUc
            // 
            this._panelConfigUc.Dock = System.Windows.Forms.DockStyle.Fill;
            this._panelConfigUc.Location = new System.Drawing.Point(6, 50);
            this._panelConfigUc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._panelConfigUc.Name = "_panelConfigUc";
            this._panelConfigUc.Size = new System.Drawing.Size(935, 760);
            this._panelConfigUc.TabIndex = 6;
            // 
            // _panelCommands
            // 
            this._panelCommands.AutoSize = true;
            this._panelCommands.Controls.Add(this._barDockControl);
            this._panelCommands.Dock = System.Windows.Forms.DockStyle.Top;
            this._panelCommands.Location = new System.Drawing.Point(6, 6);
            this._panelCommands.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._panelCommands.Name = "_panelCommands";
            this._panelCommands.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this._panelCommands.Size = new System.Drawing.Size(935, 44);
            this._panelCommands.TabIndex = 2;
            // 
            // _barDockControl
            // 
            this._barDockControl.AutoSize = true;
            this._barDockControl.CausesValidation = false;
            this._barDockControl.Dock = System.Windows.Forms.DockStyle.Top;
            this._barDockControl.Location = new System.Drawing.Point(2, 5);
            this._barDockControl.Manager = this._barManager;
            this._barDockControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._barDockControl.Name = "_barDockControl";
            this._barDockControl.Size = new System.Drawing.Size(931, 34);
            this._barDockControl.Text = "standaloneBarDockControl1";
            // 
            // _barManager
            // 
            this._barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this._barManager.DockControls.Add(this.barDockControlTop);
            this._barManager.DockControls.Add(this.barDockControlBottom);
            this._barManager.DockControls.Add(this.barDockControlLeft);
            this._barManager.DockControls.Add(this.barDockControlRight);
            this._barManager.DockControls.Add(this._barDockControl);
            this._barManager.Form = this;
            this._barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem1});
            this._barManager.MaxItemId = 1;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone;
            this.bar1.FloatLocation = new System.Drawing.Point(392, 226);
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.DrawBorder = false;
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.StandaloneBarDockControl = this._barDockControl;
            this.bar1.Text = "Tools";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barButtonItem1.Caption = "保存";
            this.barButtonItem1.Id = 0;
            this.barButtonItem1.ImageOptions.Image = global::WitsWay.TempTests.GeneralQuery.Properties.Resources.CommandSave16;
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(6, 6);
            this.barDockControlTop.Manager = this._barManager;
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlTop.Size = new System.Drawing.Size(1116, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(6, 826);
            this.barDockControlBottom.Manager = this._barManager;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlBottom.Size = new System.Drawing.Size(1116, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(6, 6);
            this.barDockControlLeft.Manager = this._barManager;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 820);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1122, 6);
            this.barDockControlRight.Manager = this._barManager;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 820);
            // 
            // _viewTabItem
            // 
            this._viewTabItem.Caption = "基础管理平台";
            this._viewTabItem.ContentControl = this._viewClient;
            this._viewTabItem.Name = "_viewTabItem";
            this._viewTabItem.Selected = true;
            // 
            // ConfigManageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1128, 832);
            this.Controls.Add(this._panelControl);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ConfigManageForm";
            this.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Text = "配置管理";
            ((System.ComponentModel.ISupportInitialize)(this._panelControl)).EndInit();
            this._panelControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._viewControl)).EndInit();
            this._viewControl.ResumeLayout(false);
            this._viewClient.ResumeLayout(false);
            this._viewClient.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._panelConfigUc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._panelCommands)).EndInit();
            this._panelCommands.ResumeLayout(false);
            this._panelCommands.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._barManager)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl _panelControl;
        private DevExpress.XtraEditors.PanelControl _panelCommands;
        private DevExpress.XtraBars.StandaloneBarDockControl _barDockControl;
        private DevExpress.XtraBars.Ribbon.BackstageViewControl _viewControl;
        private DevExpress.XtraBars.Ribbon.BackstageViewClientControl _viewClient;
        private DevExpress.XtraBars.Ribbon.BackstageViewTabItem _viewTabItem;
        private DevExpress.XtraEditors.PanelControl _panelConfigUc;
        private DevExpress.XtraBars.BarManager _barManager;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;


    }
}