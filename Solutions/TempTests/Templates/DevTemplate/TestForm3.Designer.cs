using WitsWay.WinTemplate.UC;

namespace WitsWay.WinTemplate
{
    partial class TestForm3
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
            this.gridFilterUc1 = new GridFilterUc();
            this.SuspendLayout();
            // 
            // gridFilterUc1
            // 
            this.gridFilterUc1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridFilterUc1.Location = new System.Drawing.Point(0, 0);
            this.gridFilterUc1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridFilterUc1.Name = "gridFilterUc1";
            this.gridFilterUc1.Size = new System.Drawing.Size(1070, 813);
            this.gridFilterUc1.TabIndex = 0;
            // 
            // TestForm3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 813);
            this.Controls.Add(this.gridFilterUc1);
            this.Name = "TestForm3";
            this.Text = "TestForm3";
            this.ResumeLayout(false);

        }

        #endregion

        private UC.GridFilterUc gridFilterUc1;
    }
}