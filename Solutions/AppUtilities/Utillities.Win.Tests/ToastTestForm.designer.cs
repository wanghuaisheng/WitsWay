namespace WitsWay.Utilities.Win.Tests
{
    partial class ToastTestForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ToastTestForm));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
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
            this._pictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._popupViewRow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(10, 50);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1211, 449);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // _btnBindDoubleClick
            // 
            this._btnBindDoubleClick.Location = new System.Drawing.Point(10, 21);
            this._btnBindDoubleClick.Name = "_btnBindDoubleClick";
            this._btnBindDoubleClick.Size = new System.Drawing.Size(75, 23);
            this._btnBindDoubleClick.TabIndex = 1;
            this._btnBindDoubleClick.Text = "绑定双击";
            this._btnBindDoubleClick.Click += new System.EventHandler(this._btnBindDoubleClick_Click);
            // 
            // _btnUnbindDoubleClick
            // 
            this._btnUnbindDoubleClick.Location = new System.Drawing.Point(91, 21);
            this._btnUnbindDoubleClick.Name = "_btnUnbindDoubleClick";
            this._btnUnbindDoubleClick.Size = new System.Drawing.Size(75, 23);
            this._btnUnbindDoubleClick.TabIndex = 2;
            this._btnUnbindDoubleClick.Text = "解绑双击";
            this._btnUnbindDoubleClick.Click += new System.EventHandler(this._btnUnbindDoubleClick_Click);
            // 
            // _btnBindPopupMenu
            // 
            this._btnBindPopupMenu.Location = new System.Drawing.Point(235, 21);
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
            this._bbiTwo});
            this._barManager.MaxItemId = 2;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(10, 50);
            this.barDockControlTop.Manager = this._barManager;
            this.barDockControlTop.Size = new System.Drawing.Size(1211, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(10, 499);
            this.barDockControlBottom.Manager = this._barManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(1211, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(10, 50);
            this.barDockControlLeft.Manager = this._barManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 449);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1221, 50);
            this.barDockControlRight.Manager = this._barManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 449);
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
            this._btnUnbindPopupMenu.Location = new System.Drawing.Point(337, 21);
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
            // _pictureBox
            // 
            this._pictureBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_pictureBox.BackgroundImage")));
            this._pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("_pictureBox.Image")));
            this._pictureBox.Location = new System.Drawing.Point(955, 21);
            this._pictureBox.Name = "_pictureBox";
            this._pictureBox.Size = new System.Drawing.Size(208, 100);
            this._pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this._pictureBox.TabIndex = 23;
            this._pictureBox.TabStop = false;
            // 
            // ToastTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1231, 509);
            this.Controls.Add(this._pictureBox);
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
            this.Name = "ToastTestForm";
            this.Padding = new System.Windows.Forms.Padding(10, 50, 10, 10);
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._popupViewRow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._pictureBox)).EndInit();
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
        private System.Windows.Forms.PictureBox _pictureBox;
    }
}

