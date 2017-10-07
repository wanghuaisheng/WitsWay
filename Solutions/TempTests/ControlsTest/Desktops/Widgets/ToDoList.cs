using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace WitsWay.TempTests.ControlsTest.Desktops.Widgets
{
    public partial class ToDoList : UserControl
    {
        private static readonly Font RegularFont = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        private static readonly Font StrikeoutFont = new Font("Segoe UI", 8.25F, FontStyle.Strikeout, GraphicsUnit.Point, 0);
        public ToDoList()
        {
            InitializeComponent();
        }
        private void OnCheckedChanged(object sender, EventArgs e)
        {
            var checkEdit = sender as CheckEdit;
            if (checkEdit == null) return;
            checkEdit.Font = checkEdit.Checked ? StrikeoutFont : RegularFont;
        }
    }
}
