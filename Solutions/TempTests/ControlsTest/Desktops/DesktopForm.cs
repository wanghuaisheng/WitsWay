using System;

namespace WitsWay.TempTests.ControlsTest.Desktops
{
    public partial class DesktopForm : DevExpress.XtraEditors.XtraForm
    {
        public DesktopForm()
        {
            InitializeComponent();
        }

        private void _btnSaveLayout_Click(object sender, EventArgs e)
        {
            desktopUc1.SaveDesktopLayout();
        }

        private void _btnRestoreLayout_Click(object sender, EventArgs e)
        {
            desktopUc1.RestoreDesktopLayout();
        }

        private void _btnAddControl_Click(object sender, EventArgs e)
        {
            desktopUc1.AddTimeWidget();
        }
    }
}