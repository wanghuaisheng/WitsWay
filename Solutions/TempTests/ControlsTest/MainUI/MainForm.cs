using System;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using DevExpress.XtraEditors.ColorWheel;
using DevExpress.XtraNavBar;

namespace WitsWay.TempTests.ControlsTest.MainUI
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        public MainForm()
        {
            InitializeComponent();
            flyoutPanel1.Options.CloseOnOuterClick = true;
            //flyoutPanel1.MouseCaptureChanged += FlyoutPanel1_LostFocus;//.LostFocus
            NavBarGroup group = nbgEmployees;
            CreateNavBarItems(group);
            flyoutPanel1.OwnerControl = panelControl2;//////tooltip = new ContactToolTipController(group.NavBar);
            //////group.NavBar.MouseMove += new MouseEventHandler(NavBar_MouseMove);
        }
        //////void NavBar_MouseMove(object sender, MouseEventArgs e)
        //////{
        //////    NavBarControl navBar = sender as NavBarControl;
        //////    NavBarHitInfo info = navBar.CalcHitInfo(e.Location);
        //////    if (info.InLink)
        //////        tooltip.ShowHint(((NavBarData)info.Link.Item.Tag).Contact, e.Location);
        //////    else
        //////        tooltip.HideHint(true);
        //////}
        void CreateNavBarItems(NavBarGroup group)
        {
            group.NavBar.LinkSelectionMode = LinkSelectionModeType.OneInControl;
            //NavBarItemLink link = AddNavBarItem(group, Properties.Resources.OwnerName, global::WitsWay.TempTests.ControlsTest.Properties.Resources.Owner, GetTasksData(null), null);
            //link.Item.Appearance.Font = new Font(AppearanceObject.DefaultFont, FontStyle.Underline);
            //foreach (Contact contact in TaskGenerator.Customers)
            //    AddNavBarItem(group, contact.Name, contact.Icon, GetTasksData(contact), contact);
            //NavBarItemLink allTasks = AddNavBarItem(group, "All tasks", null, DataHelper.Tasks, null);
            //allTasks.Item.Appearance.Font = new Font(AppearanceObject.DefaultFont, FontStyle.Bold);
            group.SelectedLink = group.ItemLinks[0];
            //ShowData(group.SelectedLink.Item);
        }

        //private void FlyoutPanel1_LostFocus(object sender, EventArgs e)
        //{
        //    panelControl1.Hide();
        //    flyoutPanel1.HidePopup();
        //}

        //void panel_MouseCaptureChanged(object sender, EventArgs e)
        //{
        //    if (flyoutPanel1.Capture == false)
        //    {
        //        panelControl1.Hide();
        //        flyoutPanel1.HidePopup();
        //    }
        //}

        private void nbiGrid_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            //panelControl1.BringToFront();flyoutPanel1.Height = pcMain.Height;
            flyoutPanel1.OptionsBeakPanel.BeakLocation = DevExpress.Utils.BeakPanelBeakLocation.Left;
            //flyoutPanel1.Top = navBarControl1.Top;
            //flyoutPanel1.Left = navBarControl1.Right;
            //flyoutPanel1.Padding = new Padding(navBarControl1.Right, navBarControl1.Top, 0, 0);
            NavBarItem item = nbiGrid;
            //panelControl1.Top = ribbonControl1.Bottom;
            panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            panelControl2.Show();
            flyoutPanel1.Height = panelControl1.Height;// navBarControl1.Height;
            //flyoutPanel1.Capture = true;
            flyoutPanel1.ShowPopup(true);//new Point(0, 0), true, navBarControl1
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

        private void nbiWord_LinkClicked(object sender, NavBarLinkEventArgs e)
        {

            var frm = new TestForm3();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}