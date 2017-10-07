namespace WitsWay.TempTests.GeneralQuery.Selectors
{
    partial class SpinEditor
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
            this._tokenEdit = new DevExpress.XtraEditors.TokenEdit();
            this._spinEdit = new DevExpress.XtraEditors.SpinEdit();
            this._btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this._btnOk = new DevExpress.XtraEditors.SimpleButton();
            this._btnCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this._tokenEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._spinEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // _tokenEdit
            // 
            this._tokenEdit.Location = new System.Drawing.Point(13, 46);
            this._tokenEdit.Name = "_tokenEdit";
            this._tokenEdit.Properties.EditMode = DevExpress.XtraEditors.TokenEditMode.Manual;
            this._tokenEdit.Properties.Separators.AddRange(new string[] {
            ","});
            this._tokenEdit.Size = new System.Drawing.Size(178, 20);
            this._tokenEdit.TabIndex = 0;
            // 
            // _spinEdit
            // 
            this._spinEdit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this._spinEdit.Location = new System.Drawing.Point(13, 20);
            this._spinEdit.Name = "_spinEdit";
            this._spinEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this._spinEdit.Size = new System.Drawing.Size(135, 20);
            this._spinEdit.TabIndex = 1;
            // 
            // _btnAdd
            // 
            this._btnAdd.Location = new System.Drawing.Point(154, 17);
            this._btnAdd.Name = "_btnAdd";
            this._btnAdd.Size = new System.Drawing.Size(37, 23);
            this._btnAdd.TabIndex = 2;
            this._btnAdd.Text = "添加";
            this._btnAdd.Click += new System.EventHandler(this._btnAdd_Click);
            // 
            // _btnOk
            // 
            this._btnOk.Location = new System.Drawing.Point(81, 82);
            this._btnOk.Name = "_btnOk";
            this._btnOk.Size = new System.Drawing.Size(52, 23);
            this._btnOk.TabIndex = 3;
            this._btnOk.Text = "确定";
            this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
            // 
            // _btnCancel
            // 
            this._btnCancel.Location = new System.Drawing.Point(139, 82);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(52, 23);
            this._btnCancel.TabIndex = 4;
            this._btnCancel.Text = "取消";
            this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
            // 
            // SpinEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnOk);
            this.Controls.Add(this._btnAdd);
            this.Controls.Add(this._spinEdit);
            this.Controls.Add(this._tokenEdit);
            this.Name = "SpinEditor";
            this.Size = new System.Drawing.Size(211, 128);
            ((System.ComponentModel.ISupportInitialize)(this._tokenEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._spinEdit.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TokenEdit _tokenEdit;
        private DevExpress.XtraEditors.SpinEdit _spinEdit;
        private DevExpress.XtraEditors.SimpleButton _btnAdd;
        private DevExpress.XtraEditors.SimpleButton _btnOk;
        private DevExpress.XtraEditors.SimpleButton _btnCancel;
    }
}
