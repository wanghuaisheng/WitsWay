namespace WitsWay.TempTests.ControlsTest.EditorTests
{
    partial class PopupContainerEditTest
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
            this._textEdit = new DevExpress.XtraEditors.TextEdit();
            this._popupContainerEdit = new DevExpress.XtraEditors.PopupContainerEdit();
            this._popupContainer = new DevExpress.XtraEditors.PopupContainerControl();
            this._btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.searchControl1 = new DevExpress.XtraEditors.SearchControl();
            this.buttonEdit1 = new DevExpress.XtraEditors.ButtonEdit();
            this.lookUpEdit1 = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this._textEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._popupContainerEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._popupContainer)).BeginInit();
            this._popupContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchControl1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // _textEdit
            // 
            this._textEdit.Location = new System.Drawing.Point(416, 151);
            this._textEdit.Name = "_textEdit";
            this._textEdit.Size = new System.Drawing.Size(100, 20);
            this._textEdit.TabIndex = 8;
            // 
            // _popupContainerEdit
            // 
            this._popupContainerEdit.Location = new System.Drawing.Point(178, 151);
            this._popupContainerEdit.Name = "_popupContainerEdit";
            this._popupContainerEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this._popupContainerEdit.Properties.PopupControl = this._popupContainer;
            this._popupContainerEdit.Size = new System.Drawing.Size(222, 20);
            this._popupContainerEdit.TabIndex = 7;
            this._popupContainerEdit.QueryResultValue += new DevExpress.XtraEditors.Controls.QueryResultValueEventHandler(this._popupContainerEdit_QueryResultValue);
            this._popupContainerEdit.QueryPopUp += new System.ComponentModel.CancelEventHandler(this._popupContainerEdit_QueryPopUp);
            // 
            // _popupContainer
            // 
            this._popupContainer.Controls.Add(this._btnOk);
            this._popupContainer.Controls.Add(this.searchControl1);
            this._popupContainer.Controls.Add(this.buttonEdit1);
            this._popupContainer.Controls.Add(this.lookUpEdit1);
            this._popupContainer.Location = new System.Drawing.Point(178, 177);
            this._popupContainer.Name = "_popupContainer";
            this._popupContainer.Size = new System.Drawing.Size(338, 177);
            this._popupContainer.TabIndex = 6;
            // 
            // _btnOk
            // 
            this._btnOk.Location = new System.Drawing.Point(21, 134);
            this._btnOk.Name = "_btnOk";
            this._btnOk.Size = new System.Drawing.Size(75, 23);
            this._btnOk.TabIndex = 4;
            this._btnOk.Text = "确定";
            this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
            // 
            // searchControl1
            // 
            this.searchControl1.Location = new System.Drawing.Point(21, 20);
            this.searchControl1.Name = "searchControl1";
            this.searchControl1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this.searchControl1.Size = new System.Drawing.Size(294, 20);
            this.searchControl1.TabIndex = 0;
            // 
            // buttonEdit1
            // 
            this.buttonEdit1.EditValue = "显示值";
            this.buttonEdit1.Location = new System.Drawing.Point(21, 94);
            this.buttonEdit1.Name = "buttonEdit1";
            this.buttonEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.buttonEdit1.Size = new System.Drawing.Size(294, 20);
            this.buttonEdit1.TabIndex = 3;
            // 
            // lookUpEdit1
            // 
            this.lookUpEdit1.Location = new System.Drawing.Point(21, 57);
            this.lookUpEdit1.Name = "lookUpEdit1";
            this.lookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit1.Size = new System.Drawing.Size(294, 20);
            this.lookUpEdit1.TabIndex = 1;
            // 
            // PopupContainerEditTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 504);
            this.Controls.Add(this._textEdit);
            this.Controls.Add(this._popupContainerEdit);
            this.Controls.Add(this._popupContainer);
            this.Name = "PopupContainerEditTest";
            this.Text = "PopupContainerEditTest";
            this.Load += new System.EventHandler(this.PopupContainerEditTest_Load);
            ((System.ComponentModel.ISupportInitialize)(this._textEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._popupContainerEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._popupContainer)).EndInit();
            this._popupContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.searchControl1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit _textEdit;
        private DevExpress.XtraEditors.PopupContainerEdit _popupContainerEdit;
        private DevExpress.XtraEditors.PopupContainerControl _popupContainer;
        private DevExpress.XtraEditors.SimpleButton _btnOk;
        private DevExpress.XtraEditors.SearchControl searchControl1;
        private DevExpress.XtraEditors.ButtonEdit buttonEdit1;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit1;
    }
}