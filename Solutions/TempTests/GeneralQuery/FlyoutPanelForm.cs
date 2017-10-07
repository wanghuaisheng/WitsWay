using System;

namespace WitsWay.TempTests.GeneralQuery
{
    public partial class FlyoutPanelForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FlyoutPanelForm()
        {
            InitializeComponent();}

        private void XtraForm5_Load(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            flyoutPanel1.ShowBeakForm();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            flyoutPanel2.ShowBeakForm();
        }
    }
}