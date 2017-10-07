using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.UserSkins;

namespace WitsWay.TempTests.WorkflowTest
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Thread.CurrentThread.CurrentCulture = new CultureInfo("zh-CN");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("zh-CN");
            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
            //Application.Run(new LayOutTest());
            //Application.Run(new RibbonDropMenu());
            //Application.Run(new ReportShowForm());
            Application.Run(new RibbonPaintForm());
            Application.Run(new SystemManageForm());
        }
    }
}
