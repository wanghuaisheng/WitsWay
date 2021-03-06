﻿using System.Drawing;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon.ViewInfo;

namespace WitsWay.TempTests.WorkflowTest
{
    public partial class RibbonDropMenu : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public RibbonDropMenu()
        {
            InitializeComponent();

            SkinManager.EnableFormSkins();
            LookAndFeelHelper.ForceDefaultLookAndFeelChanged();
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

        private void ribbonControl1_Paint(object sender, PaintEventArgs e)
        {
            var viewInfo = ribbonControl1.ViewInfo;
            var panel = viewInfo?.Panel;
            var groups = panel?.Groups;if (groups == null) return;
            var bounds = panel.Bounds;
            var groupRight = bounds.X;
            if (groups.Count > 0)
            {
                groupRight = groups[groups.Count - 1].Bounds.Right;
            }
            var logoImage = Properties.Resources.WitswayLogo;
            if (bounds.Height < logoImage.Height) return;
            var logoTop = (bounds.Height - logoImage.Height) / 2;
            var logoLeft = logoImage.Width;
            bounds.X = bounds.Width - logoLeft - 30;
            if (bounds.X < groupRight) return;
            bounds.Width = logoLeft;
            bounds.Y += logoTop;
            bounds.Height = logoImage.Height;
            e.Graphics.DrawImage(logoImage, bounds);
        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            ////右侧
            //backstageViewControl1.Show();
        }
    }
}