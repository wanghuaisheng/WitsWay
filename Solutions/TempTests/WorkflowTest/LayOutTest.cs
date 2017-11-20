using System;
using System.Drawing;
using System.IO;
using System.Linq;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using WitsWay.TempTests.WorkflowTest.StripBoard;

namespace WitsWay.TempTests.WorkflowTest
{
    public partial class LayOutTest : DevExpress.XtraEditors.XtraForm
    {
        public LayOutTest(){
            InitializeComponent();
        }

        private void XtraForm2_Load(object sender, EventArgs e)
        {
            layoutControl1.OptionsCustomizationForm.ShowPropertyGrid = true;
        }

        public string layout;

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var ms = new MemoryStream();
            layoutControl1.SaveLayoutToXml(@"d:\abc.xml");
            //layoutControl1.SaveLayoutToStream(ms);
            //layout = Encoding.UTF8.GetString(ms.ToArray());
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            LayoutControlItem item2 = new LayoutControlItem();
            // Add the item to the root group by setting its parent.
            item2.Parent = layoutControl1.Root;
            item2.Name = "用户名";
            TextEdit textBox2 = new TextEdit();
            textBox2.Name = "_txtUserName"; item2.Control = textBox2;
            item2.Text = "用户名:";

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            //var bytes=Encoding.UTF8.GetBytes(layout);
            //var ms=new MemoryStream(bytes);
            //layoutControl1.RestoreLayoutFromStream(ms);
            layoutControl1.RestoreLayoutFromXml(@"d:\abc.xml");
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            LayoutControlItem item2 = new LayoutControlItem();
            // Add the item to the root group by setting its parent.
            item2.Parent = layoutControl1.Root;
            item2.Name = "密码";
            TextEdit textBox2 = new TextEdit();
            textBox2.Name = "_txtPassword";
            item2.Control = textBox2;
            item2.Text = "密码:";
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            LayoutControlItem item2 = new LayoutControlItem();
            // Add the item to the root group by setting its parent.
            item2.Parent = layoutControl1.Root;
            item2.Name = "年龄";
            var textBox2 = new SpinEdit();
            textBox2.Name = "_txtAge";
            item2.Control = textBox2;
            item2.Text = "年龄:";
        }
        private void simpleButton7_Click(object sender, EventArgs e)
        {
            var txtPwd = layoutControl1.Controls.Find("_txtPassword", true);
            if (txtPwd.Any())
            {
                layoutControl1.Controls.Remove(txtPwd[0]);
            }

            var txtPwdItem = layoutControl1.Items.FindByName("密码");
            if (txtPwdItem != null)
            {
                txtPwdItem.Parent = null;
            }
        }

        private void simpleButton8_Click(object sender, EventArgs e){
            LayoutControlItem item2 = new LayoutControlItem();
            // Add the item to the root group by setting its parent.
            item2.Parent = layoutControl1.Root;
            item2.Name = "年龄";
            var textBox2 = new LibItemListUc();
            textBox2.Width = 100;
            textBox2.Height = 100;
            textBox2.MinimumSize = new Size(100,100);
            textBox2.Name = "_ucLibItemList";
            item2.Control = textBox2;
            item2.Text = "年龄:";
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            popupMenu1.ShowPopup(simpleButton9.Parent.PointToScreen(new Point(simpleButton9.Left, simpleButton9.Bottom)));
        }
    }
}