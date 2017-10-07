using System;
using System.Windows.Forms;
using DevExpress.Skins;
using DevExpress.UserSkins;
using WitsWay.TempTests.ControlsTest.Desktops;

namespace WitsWay.TempTests.ControlsTest
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

            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            Application.Run(new DesktopForm());
        }
    }
}
