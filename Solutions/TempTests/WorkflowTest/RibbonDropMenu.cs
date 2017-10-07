using System.Drawing;
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
            RibbonViewInfo viewInfo = this.ribbonControl1.ViewInfo;
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

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            ////右侧
            //backstageViewControl1.Show();
        }
    }
}