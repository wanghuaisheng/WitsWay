using System;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.ColorWheel;
using DevExpress.XtraNavBar;

namespace WitsWay.WinTemplate
{
    public partial class MainForm : XtraForm
    {
        public MainForm()
        {
            InitializeComponent();
            flyoutPanel1.Options.CloseOnOuterClick = true;
            NavBarGroup group = nbgEmployees;
            CreateNavBarItems(group);
            flyoutPanel1.OwnerControl = panelControl2;
        }
        void CreateNavBarItems(NavBarGroup group)
        {
            group.NavBar.LinkSelectionMode = LinkSelectionModeType.OneInControl;
            //NavBarItemLink link = AddNavBarItem(group, Properties.Resources.OwnerName, global::WitsWay.WinTemplate.Properties.Resources.Owner, GetTasksData(null), null);
            //link.Item.Appearance.Font = new Font(AppearanceObject.DefaultFont, FontStyle.Underline);
            //foreach (Contact contact in TaskGenerator.Customers)
            //    AddNavBarItem(group, contact.Name, contact.Icon, GetTasksData(contact), contact);
            //NavBarItemLink allTasks = AddNavBarItem(group, "All tasks", null, DataHelper.Tasks, null);
            //allTasks.Item.Appearance.Font = new Font(AppearanceObject.DefaultFont, FontStyle.Bold);
            group.SelectedLink = group.ItemLinks[0];
            //ShowData(group.SelectedLink.Item);
        }

        private void nbiGrid_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            flyoutPanel1.OptionsBeakPanel.BeakLocation = DevExpress.Utils.BeakPanelBeakLocation.Left;
            panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            panelControl2.Show();
            flyoutPanel1.Height = panelControl1.Height;
            flyoutPanel1.ShowPopup(true);
        }

        private void nbiGridCardView_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var frm = new TestForm1();
            frm.MdiParent = this;
            frm.Show();
        }

        private void flyoutPanel1_VisibleChanged(object sender, EventArgs e)
        {
            panelControl2.Visible = flyoutPanel1.Visible;
        }

        private void _bbiStatusSkinColor_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var form = new ColorWheelForm
            {
                StartPosition = FormStartPosition.CenterParent,
                SkinMaskColor = UserLookAndFeel.Default.SkinMaskColor,
                SkinMaskColor2 = UserLookAndFeel.Default.SkinMaskColor2
            };
            form.ShowDialog(this);
        }

        private void nbiSpreadsheet_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            var frm = new TestForm2();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}