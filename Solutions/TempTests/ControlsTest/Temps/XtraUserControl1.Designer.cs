namespace WitsWay.TempTests.ControlsTest.Temps
{
    partial class XtraUserControl1
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraPrinting.BarCode.Code128Generator code128Generator1 = new DevExpress.XtraPrinting.BarCode.Code128Generator();
            this.tabPane1 = new DevExpress.XtraBars.Navigation.TabPane();
            this.tabNavigationPage1 = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.barCodeControl1 = new DevExpress.XtraEditors.BarCodeControl();
            this.tabNavigationPage2 = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.textEdit2 = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPane1)).BeginInit();
            this.tabPane1.SuspendLayout();
            this.tabNavigationPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            this.tabNavigationPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tabPane1
            // 
            this.tabPane1.Controls.Add(this.tabNavigationPage1);
            this.tabPane1.Controls.Add(this.tabNavigationPage2);
            this.tabPane1.Location = new System.Drawing.Point(105, 89);
            this.tabPane1.Name = "tabPane1";
            this.tabPane1.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.tabNavigationPage1,
            this.tabNavigationPage2});
            this.tabPane1.RegularSize = new System.Drawing.Size(464, 324);
            this.tabPane1.SelectedPage = this.tabNavigationPage2;
            this.tabPane1.Size = new System.Drawing.Size(464, 324);
            this.tabPane1.TabIndex = 0;
            this.tabPane1.Text = "tabPane1";
            // 
            // tabNavigationPage1
            // 
            this.tabNavigationPage1.Caption = "tabNavigationPage1";
            this.tabNavigationPage1.Controls.Add(this.textEdit1);
            this.tabNavigationPage1.Controls.Add(this.barCodeControl1);
            this.tabNavigationPage1.Name = "tabNavigationPage1";
            this.tabNavigationPage1.Size = new System.Drawing.Size(595, 434);
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(324, 122);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(100, 20);
            this.textEdit1.TabIndex = 2;
            // 
            // barCodeControl1
            // 
            this.barCodeControl1.Location = new System.Drawing.Point(51, 71);
            this.barCodeControl1.Name = "barCodeControl1";
            this.barCodeControl1.Padding = new System.Windows.Forms.Padding(10, 2, 10, 0);
            this.barCodeControl1.Size = new System.Drawing.Size(211, 82);
            this.barCodeControl1.Symbology = code128Generator1;
            this.barCodeControl1.TabIndex = 2;
            // 
            // tabNavigationPage2
            // 
            this.tabNavigationPage2.Caption = "tabNavigationPage2";
            this.tabNavigationPage2.Controls.Add(this.textEdit2);
            this.tabNavigationPage2.Name = "tabNavigationPage2";
            this.tabNavigationPage2.Size = new System.Drawing.Size(446, 278);
            // 
            // textEdit2
            // 
            this.textEdit2.Location = new System.Drawing.Point(167, 129);
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Size = new System.Drawing.Size(100, 20);
            this.textEdit2.TabIndex = 0;
            // 
            // XtraUserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabPane1);
            this.Name = "XtraUserControl1";
            this.Size = new System.Drawing.Size(613, 480);
            ((System.ComponentModel.ISupportInitialize)(this.tabPane1)).EndInit();
            this.tabPane1.ResumeLayout(false);
            this.tabNavigationPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            this.tabNavigationPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Navigation.TabPane tabPane1;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNavigationPage1;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNavigationPage2;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.BarCodeControl barCodeControl1;
        private DevExpress.XtraEditors.TextEdit textEdit2;
    }
}
