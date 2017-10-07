namespace WitsWay.TempTests.ControlsTest.Temps
{
    partial class XtraForm1
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
            this.xtraUserControl21 = new XtraUserControl2();
            this.SuspendLayout();
            // 
            // xtraUserControl21
            // 
            this.xtraUserControl21.Location = new System.Drawing.Point(75, 29);
            this.xtraUserControl21.Name = "xtraUserControl21";
            this.xtraUserControl21.Size = new System.Drawing.Size(998, 736);
            this.xtraUserControl21.TabIndex = 0;
            // 
            // XtraForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1221, 777);
            this.Controls.Add(this.xtraUserControl21);
            this.Name = "XtraForm1";
            this.Text = "XtraForm1";
            this.ResumeLayout(false);

        }

        #endregion

        private XtraUserControl2 xtraUserControl21;
    }
}