using System;
using System.Windows.Forms;
using WitsWay.TempTests.GeneralQuery.QueryForms;
using WitsWay.TempTests.GeneralQuery.Selectors;

namespace WitsWay.TempTests.GeneralQuery
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            //var infos = EntityDataSourceFactory.GetSupportEntities();


            DevExpress.Skins.SkinManager.EnableFormSkins();
            //UserLookAndFeel.Default.SetSkinStyle("DevExpress Dark Style");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TabMainForm());}
    }
}
