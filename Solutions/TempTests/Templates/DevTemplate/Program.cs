using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Skins;
using DevExpress.XtraEditors;

namespace WitsWay.WinTemplate
{
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] arguments) {
            WindowsFormsSettings.ApplyDemoSettings();

            System.Globalization.CultureInfo hans = new System.Globalization.CultureInfo("zh-Hans");
            System.Threading.Thread.CurrentThread.CurrentCulture = hans;
            System.Threading.Thread.CurrentThread.CurrentUICulture = hans;
            //System.Globalization.CultureInfo zhHans = new System.Globalization.CultureInfo("zh-Hans");
            //System.Threading.Thread.CurrentThread.CurrentCulture = zhHans;
            //System.Threading.Thread.CurrentThread.CurrentUICulture = zhHans;
            DevExpress.Utils.AppearanceObject.DefaultFont = new Font("Segoe UI", 8);
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
            SkinManager.EnableFormSkins();
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());

            //BarAndDockingController.PropertiesBar.ScaleIcons or BarAndDockingController.PropertiesRibbon.ScaleIcons

        }
    }
}
