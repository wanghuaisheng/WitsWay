using WitsWay.TempTests.RemainProcessTest.PlanUI.DrawObjects;

namespace WitsWay.TempTests.RemainProcessTest.PlanUI
{
    partial class PlanControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this._popupUnitOperate = new DevExpress.XtraBars.PopupMenu(this.components);
            this._bbiPrintBarcode = new DevExpress.XtraBars.BarButtonItem();
            this._bbiUndoProcess = new DevExpress.XtraBars.BarButtonItem();
            this._barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.drawArea1 = new DrawArea();
            ((System.ComponentModel.ISupportInitialize)(this._popupUnitOperate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._barManager)).BeginInit();
            this.SuspendLayout();
            // 
            // _popupUnitOperate
            // 
            this._popupUnitOperate.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this._bbiPrintBarcode),
            new DevExpress.XtraBars.LinkPersistInfo(this._bbiUndoProcess)});
            this._popupUnitOperate.Manager = this._barManager;
            this._popupUnitOperate.Name = "_popupUnitOperate";
            // 
            // _bbiPrintBarcode
            // 
            this._bbiPrintBarcode.Caption = "打印条码";
            this._bbiPrintBarcode.Id = 2;
            this._bbiPrintBarcode.Name = "_bbiPrintBarcode";
            // 
            // _bbiUndoProcess
            // 
            this._bbiUndoProcess.Caption = "撤销加工";
            this._bbiUndoProcess.Id = 3;
            this._bbiUndoProcess.Name = "_bbiUndoProcess";
            // 
            // _barManager
            // 
            this._barManager.DockControls.Add(this.barDockControlTop);
            this._barManager.DockControls.Add(this.barDockControlBottom);
            this._barManager.DockControls.Add(this.barDockControlLeft);
            this._barManager.DockControls.Add(this.barDockControlRight);
            this._barManager.Form = this;
            this._barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem1,
            this.barButtonItem2,
            this._bbiPrintBarcode,
            this._bbiUndoProcess});
            this._barManager.MaxItemId = 4;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(20, 20);
            this.barDockControlTop.Size = new System.Drawing.Size(824, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(20, 613);
            this.barDockControlBottom.Size = new System.Drawing.Size(824, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(20, 20);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 593);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(844, 20);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 593);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "加工";
            this.barButtonItem1.Id = 0;
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "删除";
            this.barButtonItem2.Id = 1;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // drawArea1
            // 
            this.drawArea1.ActiveTool = DrawArea.DrawToolType.Pointer;
            this.drawArea1.BackColor = System.Drawing.Color.White;
            this.drawArea1.CurrentBrush = null;
            this.drawArea1.CurrentPen = null;
            this.drawArea1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drawArea1.DrawFilled = false;
            this.drawArea1.DrawNetRectangle = true;
            this.drawArea1.FillColor = System.Drawing.Color.Transparent;
            this.drawArea1.LineColor = System.Drawing.Color.Black;
            this.drawArea1.LineWidth = -1;
            this.drawArea1.Location = new System.Drawing.Point(20, 20);
            this.drawArea1.MyParent = null;
            this.drawArea1.Name = "drawArea1";
            this.drawArea1.NetRectangle = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.drawArea1.OriginalPanY = 0;
            this.drawArea1.Owner = null;
            this.drawArea1.Panning = false;
            this.drawArea1.PanX = 0;
            this.drawArea1.PanY = 0;
            this.drawArea1.PenType = DrawingPens.PenType.Generic;
            this.drawArea1.Rotation = 0F;
            this.drawArea1.Size = new System.Drawing.Size(824, 593);
            this.drawArea1.TabIndex = 4;
            this.drawArea1.Zoom = 1F;
            // 
            // PlanControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.drawArea1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "PlanControl";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.Size = new System.Drawing.Size(864, 633);
            ((System.ComponentModel.ISupportInitialize)(this._popupUnitOperate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._barManager)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.PopupMenu _popupUnitOperate;
        private DevExpress.XtraBars.BarManager _barManager;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DrawArea drawArea1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem _bbiPrintBarcode;
        private DevExpress.XtraBars.BarButtonItem _bbiUndoProcess;
    }
}
