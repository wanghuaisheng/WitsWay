﻿using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon.ViewInfo;
using DevExpress.XtraEditors;

namespace WitsWay.TempTests.WorkflowTest
{
    public partial class SystemManageForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public SystemManageForm()
        {
            InitializeComponent();
            //////SkinManager.EnableFormSkins();
            //////LookAndFeelHelper.ForceDefaultLookAndFeelChanged();
            //this.navBarControl1.MenuManager = this.ribbonControl1;
            //this.SetFormParam();
            //this.filter = new NavBarFilter(this.navBarControl1);
            //this.pnlFilter.Visible = (this.bciFilter.Checked = this.AllowNavBarFilter);
            //if (!this.AllowNavBarFilter)
            //{
            //    this.bciFilter.Visibility = BarItemVisibility.Never;
            //}
            //MainFormHelper.SetCommandLineArgs(Environment.GetCommandLineArgs(), out this.startModule, out this.fullWindow);
            //UserLookAndFeel.Default.StyleChanged += new EventHandler(this.Default_StyleChanged);
            //((UserLookAndFeelDefault)UserLookAndFeel.Default).StyleChangeProgress += new LookAndFeelProgressEventHandler(this.Default_StyleChangeProgress);
        }

        private void Ribbon_Paint(object sender, PaintEventArgs e)
        {
            RibbonViewInfo viewInfo = Ribbon.ViewInfo;
            if (viewInfo == null)
            {
                return;
            }
            RibbonPanelViewInfo panel = viewInfo.Panel;
            if (panel == null)
            {
                return;
            }
            Rectangle bounds = panel.Bounds;
            int num = bounds.X;
            RibbonPageGroupViewInfoCollection groups = panel.Groups;
            if (groups == null)
            {
                return;
            }
            if (groups.Count > 0)
            {
                num = groups[groups.Count - 1].Bounds.Right;
            }
            Image imageLogoEx = Properties.Resources.yitusoft_LOGO;// Helper.GetImageLogo(base.LookAndFeel);
            if (bounds.Height < imageLogoEx.Height)
            {
                return;
            }
            int num2 = (bounds.Height - imageLogoEx.Height) / 2;
            int num3 = imageLogoEx.Width + 15;
            bounds.X = bounds.Width - num3;
            if (bounds.X < num)
            {
                return;
            }
            bounds.Width = num3;
            bounds.Y += num2;
            bounds.Height = imageLogoEx.Height;
            e.Graphics.DrawImage(imageLogoEx, bounds.Location);
        }

        private void barButtonItem10_ItemClick(object sender, ItemClickEventArgs e)
        {
            //var visible = backstageViewControl1.Visible;
            //if (visible) backstageViewControl1.Hide();
            //else backstageViewControl1.Show();
        }

        private void barButtonItem11_ItemClick(object sender, ItemClickEventArgs e)
        {
            ribbon.Minimized = !ribbon.Minimized;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            popupMenu1.ShowPopup(barManager1, simpleButton1.Parent.PointToScreen
                (new Point(simpleButton1.Left, simpleButton1.Bottom)));
        }

        private void barButtonItem12_ItemClick(object sender, ItemClickEventArgs e)
        {
            Process.Start("iexplore", @"http://yitusoft.com");
        }

        private void barButtonItem13_ItemClick(object sender, ItemClickEventArgs e)
        {

            XtraMessageBox.Show("关于我们");
        }

        private void barButtonItem15_ItemClick(object sender, ItemClickEventArgs e)
        {

            XtraMessageBox.Show("版本信息");
        }

        private void barButtonItem14_ItemClick(object sender, ItemClickEventArgs e)
        {

            XtraMessageBox.Show("服务配置");
        }

        private void _bbiGroupDataManage_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void RibbonForm1_Load(object sender, EventArgs e)
        {

        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frm = new LayOutTest();
            frm.MdiParent = this;
            frm.Show();
        }

        private void ribbon_ApplicationButtonClick(object sender, EventArgs e)
        {
            //backstageViewControl1.Visible = !backstageViewControl1.Visible;
        }
    }
}