namespace WitsWay.TempTests.ControlsTest.Desktops
{
    partial class DesktopForm
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
            this.desktopUc1 = new ControlsTest.Desktops.DesktopUc();
            this._btnSaveLayout = new DevExpress.XtraEditors.SimpleButton();
            this._btnRestoreLayout = new DevExpress.XtraEditors.SimpleButton();
            this._btnAddControl = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // desktopUc1
            // 
            this.desktopUc1.Location = new System.Drawing.Point(45, 110);
            this.desktopUc1.Name = "desktopUc1";
            this.desktopUc1.Size = new System.Drawing.Size(808, 542);
            this.desktopUc1.TabIndex = 0;
            // 
            // _btnSaveLayout
            // 
            this._btnSaveLayout.Location = new System.Drawing.Point(162, 41);
            this._btnSaveLayout.Name = "_btnSaveLayout";
            this._btnSaveLayout.Size = new System.Drawing.Size(75, 23);
            this._btnSaveLayout.TabIndex = 1;
            this._btnSaveLayout.Text = "保存布局";
            this._btnSaveLayout.Click += new System.EventHandler(this._btnSaveLayout_Click);
            // 
            // _btnRestoreLayout
            // 
            this._btnRestoreLayout.Location = new System.Drawing.Point(283, 41);
            this._btnRestoreLayout.Name = "_btnRestoreLayout";
            this._btnRestoreLayout.Size = new System.Drawing.Size(75, 23);
            this._btnRestoreLayout.TabIndex = 2;
            this._btnRestoreLayout.Text = "恢复布局";
            this._btnRestoreLayout.Click += new System.EventHandler(this._btnRestoreLayout_Click);
            // 
            // _btnAddControl
            // 
            this._btnAddControl.Location = new System.Drawing.Point(385, 40);
            this._btnAddControl.Name = "_btnAddControl";
            this._btnAddControl.Size = new System.Drawing.Size(75, 23);
            this._btnAddControl.TabIndex = 3;
            this._btnAddControl.Text = "添加控件";
            this._btnAddControl.Click += new System.EventHandler(this._btnAddControl_Click);
            // 
            // DesktopForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 687);
            this.Controls.Add(this._btnAddControl);
            this.Controls.Add(this._btnRestoreLayout);
            this.Controls.Add(this._btnSaveLayout);
            this.Controls.Add(this.desktopUc1);
            this.Name = "DesktopForm";
            this.Text = "DesktopForm";
            this.ResumeLayout(false);

        }

        #endregion

        private DesktopUc desktopUc1;
        private DevExpress.XtraEditors.SimpleButton _btnSaveLayout;
        private DevExpress.XtraEditors.SimpleButton _btnRestoreLayout;
        private DevExpress.XtraEditors.SimpleButton _btnAddControl;
    }
}