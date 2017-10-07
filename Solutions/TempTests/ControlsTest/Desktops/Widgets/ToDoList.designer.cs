namespace WitsWay.TempTests.ControlsTest.Desktops.Widgets {
    partial class ToDoList {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.radioGroup1 = new DevExpress.XtraEditors.CheckEdit();
            this.checkEdit3 = new DevExpress.XtraEditors.CheckEdit();
            this.checkEdit4 = new DevExpress.XtraEditors.CheckEdit();
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // radioGroup1
            // 
            this.radioGroup1.EditValue = true;
            this.radioGroup1.Location = new System.Drawing.Point(13, 13);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioGroup1.Properties.Appearance.Options.UseFont = true;
            this.radioGroup1.Properties.AutoHeight = false;
            this.radioGroup1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.radioGroup1.Properties.Caption = "Install DevExpress Components";
            this.radioGroup1.Size = new System.Drawing.Size(234, 20);
            this.radioGroup1.TabIndex = 0;
            this.radioGroup1.CheckedChanged += new System.EventHandler(this.OnCheckedChanged);
            // 
            // checkEdit3
            // 
            this.checkEdit3.Location = new System.Drawing.Point(13, 65);
            this.checkEdit3.Name = "checkEdit3";
            this.checkEdit3.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkEdit3.Properties.Appearance.Options.UseFont = true;
            this.checkEdit3.Properties.AutoHeight = false;
            this.checkEdit3.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.checkEdit3.Properties.Caption = "View all new components";
            this.checkEdit3.Size = new System.Drawing.Size(160, 20);
            this.checkEdit3.TabIndex = 3;
            this.checkEdit3.CheckedChanged += new System.EventHandler(this.OnCheckedChanged);
            // 
            // checkEdit4
            // 
            this.checkEdit4.EditValue = true;
            this.checkEdit4.Location = new System.Drawing.Point(13, 39);
            this.checkEdit4.Name = "checkEdit4";
            this.checkEdit4.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkEdit4.Properties.Appearance.Options.UseFont = true;
            this.checkEdit4.Properties.AutoHeight = false;
            this.checkEdit4.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.checkEdit4.Properties.Caption = "Test WinForms Demos";
            this.checkEdit4.Size = new System.Drawing.Size(160, 20);
            this.checkEdit4.TabIndex = 4;
            this.checkEdit4.CheckedChanged += new System.EventHandler(this.OnCheckedChanged);
            // 
            // checkEdit1
            // 
            this.checkEdit1.Location = new System.Drawing.Point(13, 91);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkEdit1.Properties.Appearance.Options.UseFont = true;
            this.checkEdit1.Properties.AutoHeight = false;
            this.checkEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.checkEdit1.Properties.Caption = "Create a simple application";
            this.checkEdit1.Size = new System.Drawing.Size(160, 20);
            this.checkEdit1.TabIndex = 5;
            this.checkEdit1.CheckedChanged += new System.EventHandler(this.OnCheckedChanged);
            // 
            // ToDoList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkEdit1);
            this.Controls.Add(this.checkEdit4);
            this.Controls.Add(this.checkEdit3);
            this.Controls.Add(this.radioGroup1);
            this.Name = "ToDoList";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(361, 213);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.CheckEdit radioGroup1;
        private DevExpress.XtraEditors.CheckEdit checkEdit3;
        private DevExpress.XtraEditors.CheckEdit checkEdit4;
        private DevExpress.XtraEditors.CheckEdit checkEdit1;



    }
}
