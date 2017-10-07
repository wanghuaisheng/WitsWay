using System.ComponentModel;
using DevExpress.XtraEditors;

namespace WitsWay.TempTests.RemainProcessTest.RemainUI
{
    partial class RemainMaterialInputDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this._btnOk = new DevExpress.XtraEditors.SimpleButton();
            this._btnClose = new DevExpress.XtraEditors.SimpleButton();
            this._groupControl = new DevExpress.XtraEditors.GroupControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this._spinWidth = new DevExpress.XtraEditors.SpinEdit();
            this._spinLength = new DevExpress.XtraEditors.SpinEdit();
            this._comboMaterial = new DevExpress.XtraEditors.ComboBoxEdit();
            this._radioInputWay = new DevExpress.XtraEditors.RadioGroup();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this._groupControl)).BeginInit();
            this._groupControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._spinWidth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._spinLength.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._comboMaterial.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._radioInputWay.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // _btnOk
            // 
            this._btnOk.Location = new System.Drawing.Point(260, 201);
            this._btnOk.Name = "_btnOk";
            this._btnOk.Size = new System.Drawing.Size(80, 34);
            this._btnOk.TabIndex = 1;
            this._btnOk.Text = "确认";
            this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
            // 
            // _btnClose
            // 
            this._btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._btnClose.Location = new System.Drawing.Point(355, 201);
            this._btnClose.Name = "_btnClose";
            this._btnClose.Size = new System.Drawing.Size(80, 34);
            this._btnClose.TabIndex = 2;
            this._btnClose.Text = "关闭";
            // 
            // _groupControl
            // 
            this._groupControl.AppearanceCaption.Font = new System.Drawing.Font("微软雅黑", 12F);
            this._groupControl.AppearanceCaption.Options.UseFont = true;
            this._groupControl.Controls.Add(this.labelControl2);
            this._groupControl.Controls.Add(this.labelControl1);
            this._groupControl.Controls.Add(this.labelControl3);
            this._groupControl.Controls.Add(this._spinWidth);
            this._groupControl.Controls.Add(this._spinLength);
            this._groupControl.Controls.Add(this._comboMaterial);
            this._groupControl.Location = new System.Drawing.Point(25, 26);
            this._groupControl.Name = "_groupControl";
            this._groupControl.Size = new System.Drawing.Size(410, 159);
            this._groupControl.TabIndex = 8;
            this._groupControl.Text = "余料信息";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(227, 106);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(38, 25);
            this.labelControl2.TabIndex = 15;
            this.labelControl2.Text = "宽度";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(16, 106);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(38, 25);
            this.labelControl1.TabIndex = 14;
            this.labelControl1.Text = "长度";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(16, 52);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(57, 25);
            this.labelControl3.TabIndex = 13;
            this.labelControl3.Text = "原材料";
            // 
            // _spinWidth
            // 
            this._spinWidth.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this._spinWidth.Location = new System.Drawing.Point(290, 102);
            this._spinWidth.Name = "_spinWidth";
            this._spinWidth.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 14F);
            this._spinWidth.Properties.Appearance.Options.UseFont = true;
            this._spinWidth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this._spinWidth.Size = new System.Drawing.Size(100, 48);
            this._spinWidth.TabIndex = 10;
            // 
            // _spinLength
            // 
            this._spinLength.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this._spinLength.Location = new System.Drawing.Point(79, 102);
            this._spinLength.Name = "_spinLength";
            this._spinLength.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 14F);
            this._spinLength.Properties.Appearance.Options.UseFont = true;
            this._spinLength.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this._spinLength.Size = new System.Drawing.Size(100, 48);
            this._spinLength.TabIndex = 9;
            // 
            // _comboMaterial
            // 
            this._comboMaterial.Location = new System.Drawing.Point(79, 48);
            this._comboMaterial.Name = "_comboMaterial";
            this._comboMaterial.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 14F);
            this._comboMaterial.Properties.Appearance.Options.UseFont = true;
            this._comboMaterial.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this._comboMaterial.Size = new System.Drawing.Size(311, 48);
            this._comboMaterial.TabIndex = 8;
            // 
            // _radioInputWay
            // 
            this._radioInputWay.EditValue = 1;
            this._radioInputWay.Location = new System.Drawing.Point(25, 201);
            this._radioInputWay.Name = "_radioInputWay";
            this._radioInputWay.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 14F);
            this._radioInputWay.Properties.Appearance.Options.UseFont = true;
            this._radioInputWay.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "扫码"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(2, "录入")});
            this._radioInputWay.Size = new System.Drawing.Size(147, 34);
            this._radioInputWay.TabIndex = 9;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(178, 201);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(80, 34);
            this.simpleButton1.TabIndex = 10;
            this.simpleButton1.Text = "确认";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // RemainMaterialInputDialog
            // 
            this.AcceptButton = this._btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._btnClose;
            this.ClientSize = new System.Drawing.Size(461, 253);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this._radioInputWay);
            this.Controls.Add(this._groupControl);
            this.Controls.Add(this._btnClose);
            this.Controls.Add(this._btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RemainMaterialInputDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "扫描或录入余料信息";
            this.Load += new System.EventHandler(this.RemainMaterialInputDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this._groupControl)).EndInit();
            this._groupControl.ResumeLayout(false);
            this._groupControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._spinWidth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._spinLength.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._comboMaterial.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._radioInputWay.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SimpleButton _btnOk;
        private SimpleButton _btnClose;
        private GroupControl _groupControl;
        private LabelControl labelControl2;
        private LabelControl labelControl1;
        private LabelControl labelControl3;
        private SpinEdit _spinWidth;
        private SpinEdit _spinLength;
        private ComboBoxEdit _comboMaterial;
        private RadioGroup _radioInputWay;
        private SimpleButton simpleButton1;
    }
}