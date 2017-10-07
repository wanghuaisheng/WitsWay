namespace WitsWay.TempTests.ControlsTest.Desktops.Widgets {
    partial class Calendar {
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
            this.dateNavigator1 = new DevExpress.XtraScheduler.DateNavigator();
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator1)).BeginInit();
            this.SuspendLayout();
            // 
            // dateNavigator1
            // 
            this.dateNavigator1.CalendarAppearance.DayCell.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateNavigator1.CalendarAppearance.DayCell.Options.UseFont = true;
            this.dateNavigator1.CalendarAppearance.Header.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateNavigator1.CalendarAppearance.Header.Options.UseFont = true;
            this.dateNavigator1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.dateNavigator1.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.dateNavigator1.DateTime = new System.DateTime(2013, 11, 22, 0, 0, 0, 0);
            this.dateNavigator1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateNavigator1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateNavigator1.Location = new System.Drawing.Point(0, 0);
            this.dateNavigator1.SelectionMode = DevExpress.XtraEditors.Repository.CalendarSelectionMode.Single;
            this.dateNavigator1.Name = "dateNavigator1";
            this.dateNavigator1.ShowTodayButton = false;
            this.dateNavigator1.ShowWeekNumbers = false;
            this.dateNavigator1.Size = new System.Drawing.Size(241, 190);
            this.dateNavigator1.TabIndex = 0;
            // 
            // Calendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dateNavigator1);
            this.Name = "Calendar";
            this.Size = new System.Drawing.Size(241, 190);
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraScheduler.DateNavigator dateNavigator1;

    }
}
