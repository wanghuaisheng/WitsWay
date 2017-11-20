namespace WitsWay.TempTests.GeneralQuery
{
    partial class NavControlTest
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
            this.navPanelTestForm1 = new WitsWay.TempTests.GeneralQuery.NavPanelTestForm();
            this.SuspendLayout();
            // 
            // navPanelTestForm1
            // 
            this.navPanelTestForm1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navPanelTestForm1.Location = new System.Drawing.Point(0, 0);
            this.navPanelTestForm1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.navPanelTestForm1.Name = "navPanelTestForm1";
            this.navPanelTestForm1.Size = new System.Drawing.Size(1203, 810);
            this.navPanelTestForm1.TabIndex = 0;
            // 
            // NavControlTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1203, 810);
            this.Controls.Add(this.navPanelTestForm1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "NavControlTest";
            this.Text = "GridListConfig";
            this.Load += new System.EventHandler(this.NavControlTest_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private NavPanelTestForm navPanelTestForm1;
    }
}