using WitsWay.TempTests.ControlsTest.ToastUC;

namespace WitsWay.TempTests.ControlsTest
{
    partial class ToastMessageTest
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
            this.moduleFlyoutPanel1 = new WitsWay.TempTests.ControlsTest.ToastUC.ToastMessagePanel();
            this.SuspendLayout();
            // 
            // moduleFlyoutPanel1
            // 
            this.moduleFlyoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.moduleFlyoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.moduleFlyoutPanel1.Name = "moduleFlyoutPanel1";
            this.moduleFlyoutPanel1.Size = new System.Drawing.Size(893, 466);
            this.moduleFlyoutPanel1.TabIndex = 0;
            // 
            // UserControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 697);
            this.Controls.Add(this.moduleFlyoutPanel1);
            this.Name = "UserControlForm";
            this.Text = "UserControlForm";
            this.ResumeLayout(false);

        }

        #endregion

        private ToastMessagePanel moduleFlyoutPanel1;
    }
}