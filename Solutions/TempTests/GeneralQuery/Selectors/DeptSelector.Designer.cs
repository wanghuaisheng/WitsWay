namespace WitsWay.TempTests.GeneralQuery.Selectors
{
    partial class DeptSelector
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
            this._btnOk = new DevExpress.XtraEditors.SimpleButton();
            this._btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this._txtUsers = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this._txtUsers.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // _btnOk
            // 
            this._btnOk.Location = new System.Drawing.Point(229, 97);
            this._btnOk.Name = "_btnOk";
            this._btnOk.Size = new System.Drawing.Size(75, 23);
            this._btnOk.TabIndex = 8;
            this._btnOk.Text = "确定";
            this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
            // 
            // _btnCancel
            // 
            this._btnCancel.Location = new System.Drawing.Point(345, 97);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(75, 23);
            this._btnCancel.TabIndex = 9;
            this._btnCancel.Text = "取消";
            this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
            // 
            // _txtUsers
            // 
            this._txtUsers.Location = new System.Drawing.Point(96, 43);
            this._txtUsers.Name = "_txtUsers";
            this._txtUsers.Size = new System.Drawing.Size(324, 20);
            this._txtUsers.TabIndex = 10;
            // 
            // DeptSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._txtUsers);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnOk);
            this.Name = "DeptSelector";
            this.Size = new System.Drawing.Size(553, 158);
            ((System.ComponentModel.ISupportInitialize)(this._txtUsers.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton _btnOk;
        private DevExpress.XtraEditors.SimpleButton _btnCancel;
        private DevExpress.XtraEditors.TextEdit _txtUsers;
    }
}
