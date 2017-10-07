using System;
using WitsWay.TempTests.RemainProcessTest.RemainUI;

namespace WitsWay.TempTests.RemainProcessTest
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void _btnRemainProcess_Click(object sender, EventArgs e)
        {
            RemainMaterialInputDialog dia=new RemainMaterialInputDialog();
            dia.ShowDialog(this);}
    }
}
