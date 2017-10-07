using System;
using System.Windows.Forms;
using DevExpress.XtraBars.Docking2010;

namespace WitsWay.TempTests.GeneralQuery
{
    public partial class WindowsUiButtonForm : DevExpress.XtraEditors.XtraForm
    {
        public WindowsUiButtonForm()
        {
            InitializeComponent();
        }

        private void XtraForm1_Load(object sender, EventArgs e)
        {
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            radialMenu1.ShowPopup(MousePosition);
        }

        private void windowsUIButtonPanel1_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            var btn = e.Button as WindowsUIButton;
            if (btn.Caption == "最小化") WindowState = FormWindowState.Minimized;
            else this.Close();
        }

        private void windowsUIButtonPanel1_ButtonChecked(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            var btn = e.Button as WindowsUIButton;
            if (btn.Caption == "最小化") WindowState = FormWindowState.Minimized;
            else Close();
        }

        private void XtraForm1_Shown(object sender, EventArgs e)
        {

            var frm = new GridTestForm { MdiParent = this };
            frm.Show();
        }
    }
}