using DevExpress.Utils;

namespace WitsWay.TempTests.WorkflowTest
{
    partial class RibbonPaintForm
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
            this._ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.applicationMenu1 = new DevExpress.XtraBars.Ribbon.ApplicationMenu(this.components);
            this.ribbonMiniToolbar1 = new DevExpress.XtraBars.Ribbon.RibbonMiniToolbar(this.components);
            ((System.ComponentModel.ISupportInitialize)(this._ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationMenu1)).BeginInit();
            this.SuspendLayout();
            // 
            // _ribbonControl
            // 
            this._ribbonControl.AllowMinimizeRibbon = false;
            this._ribbonControl.ApplicationButtonDropDownControl = this.applicationMenu1;
            this._ribbonControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this._ribbonControl.ExpandCollapseItem.Id = 0;
            this._ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this._ribbonControl.ExpandCollapseItem});
            this._ribbonControl.Location = new System.Drawing.Point(0, 0);
            this._ribbonControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._ribbonControl.MaxItemId = 1;
            this._ribbonControl.MiniToolbars.Add(this.ribbonMiniToolbar1);
            this._ribbonControl.Name = "_ribbonControl";
            this._ribbonControl.OptionsTouch.TouchUI = DevExpress.Utils.DefaultBoolean.True;
            this._ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this._ribbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.MacOffice;
            this._ribbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this._ribbonControl.ShowDisplayOptionsMenuButton = DevExpress.Utils.DefaultBoolean.True;
            this._ribbonControl.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.True;
            this._ribbonControl.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this._ribbonControl.ShowToolbarCustomizeItem = false;
            this._ribbonControl.Size = new System.Drawing.Size(1283, 168);
            this._ribbonControl.Toolbar.ShowCustomizeItem = false;
            this._ribbonControl.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            this._ribbonControl.TransparentEditorsMode = DevExpress.Utils.DefaultBoolean.True;
            this._ribbonControl.Paint += new System.Windows.Forms.PaintEventHandler(this._ribbonControl_Paint);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "ribbonPage1";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "ribbonPageGroup1";
            // 
            // applicationMenu1
            // 
            this.applicationMenu1.Name = "applicationMenu1";
            this.applicationMenu1.Ribbon = this._ribbonControl;
            // 
            // RibbonPaintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1283, 797);
            this.Controls.Add(this._ribbonControl);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "RibbonPaintForm";
            this.Ribbon = this._ribbonControl;
            this.Text = "XtraForm1";
            ((System.ComponentModel.ISupportInitialize)(this._ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationMenu1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl _ribbonControl;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.ApplicationMenu applicationMenu1;
        private DevExpress.XtraBars.Ribbon.RibbonMiniToolbar ribbonMiniToolbar1;
    }
}