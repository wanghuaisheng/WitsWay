using System;
using System.Diagnostics;
using System.Windows.Forms;
using WitsWay.Utilities.Win;

namespace WitsWay.TempTests.WorkflowTest
{
    public partial class AppCenterForm : DevExpress.XtraEditors.XtraForm
    {
        public AppCenterForm()
        {
            InitializeComponent();
        }

        private void _notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            var mPosition = MousePosition;

            this.Top = Screen.PrimaryScreen.WorkingArea.Bottom - this.Height;
            if (this.Top < 0)
            {
                this.Height = Screen.PrimaryScreen.WorkingArea.Bottom;
                this.Top = 0;
            }
            this.Left = (Screen.PrimaryScreen.WorkingArea.Width - MousePosition.X < this.Width)
                ? Screen.PrimaryScreen.WorkingArea.Width - this.Width : MousePosition.X;
            this.TopMost = true;
            this.Show();
        }

        private void XtraForm4_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.ApplicationExitCall || e.CloseReason == CloseReason.TaskManagerClosing || e.CloseReason == CloseReason.WindowsShutDown)
            {
                //Logger.Write("程序关闭，关闭原因" + e.CloseReason);
                //CommandStopSystem();
                e.Cancel = false;
                UtilityHelper.InvokeExecute(this, Close);
            }
            else
            {
                e.Cancel = true;// !AppContext.Instance.UserExist;
                if (e.Cancel)
                {
                    UtilityHelper.InvokeExecute(this, Hide);
                }
            }
        }

        private void _bbiEmp_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Process.Start("iexplore", @"http://deberp.com");
        }

        private void MemoEdit2_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void SimpleButton1_Click(object sender, EventArgs e)
        {

        }

        private void NavBarControl1_ActiveGroupChanged(object sender, DevExpress.XtraNavBar.NavBarGroupEventArgs e)
        {
            if (e.Group == navBarGroup3) this.Width = 600;
            else this.Width = 300;
        }
    }
}