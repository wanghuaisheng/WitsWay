namespace WitsWay.TempTests.GeneralQuery
{
    partial class GridTestForm
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
            this.gridWithFilterUC1 = new GeneralQuery.QueryForms.GridWithFilterUc2();
            this.SuspendLayout();
            // 
            // gridWithFilterUC1
            // 
            this.gridWithFilterUC1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridWithFilterUC1.Location = new System.Drawing.Point(0, 0);
            this.gridWithFilterUC1.Name = "gridWithFilterUC1";
            this.gridWithFilterUC1.Size = new System.Drawing.Size(900, 640);
            this.gridWithFilterUC1.TabIndex = 0;
            // 
            // GridTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 640);
            this.Controls.Add(this.gridWithFilterUC1);
            this.Name = "GridTestForm";
            this.Text = "GridTestForm";
            this.Load += new System.EventHandler(this.GridTestForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private QueryForms.GridWithFilterUc2 gridWithFilterUC1;
    }
}