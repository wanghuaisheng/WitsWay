using System.Windows.Forms;
using DevExpress.XtraBars.Docking;
using DevExpress.XtraBars.Docking2010.Views.Widget;
using DevExpress.XtraEditors;
using WitsWay.TempTests.ControlsTest.Desktops.Widgets;
using WitsWay.TempTests.ControlsTest.Properties;
using WitsWay.Utilities.Win;

namespace WitsWay.TempTests.ControlsTest.Desktops
{
    public partial class DesktopUc : XtraUserControl
    {
        public DesktopUc()
        {
            InitializeComponent();
            // Handling the QueryControl event that will populate all automatically generated Documents
            _widgetView.QueryControl += widgetView1_QueryControl;
        }

        // Assigning a required content for each auto generated Document
        void widgetView1_QueryControl(object sender, DevExpress.XtraBars.Docking2010.Views.QueryControlEventArgs e)
        {
            if (e.Document == _widgetToDoList)
                e.Control = new ToDoList();
            if (e.Document == _widgetCalendar)
                e.Control = new Calendar();
            if (e.Document.ControlTypeName == "ControlsTest.Widgets.Clock" && e.Document.ControlName == "Clock")
                e.Control = new Clock();
            if (e.Control == null)
                e.Control = new Control();
        }

        public void SaveDesktopLayout()
        {
            _documentManager.View.SaveLayoutToXml(@"d:\\123.xml");
        }

        public void RestoreDesktopLayout()
        {
            _documentManager.View.RestoreLayoutFromXml(@"d:\\123.xml");
        }

        public void AddTimeWidget()
        {
            var timeWidgetContainer = new WidgetDockingContainer();
            var widgetClock = new Document
            {
                Caption = @"时钟",
                ControlName = "Clock",
                ControlTypeName = "ControlsTest.Widgets.Clock",
                MaximizedControl = new Calendar()
            };

            var serializableAppearanceObject = new DevExpress.Utils.SerializableAppearanceObject();
            var customHeaderButtonImageOptions = new CustomHeaderButtonImageOptions
            {
                SvgImage = Resources.settings,
                SvgImageSize = new System.Drawing.Size(12, 12)
            };
            widgetClock.CustomHeaderButtons.AddRange(new DevExpress.XtraBars.Docking2010.IButton[] {
            new CustomHeaderButton("设置", false, customHeaderButtonImageOptions, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, serializableAppearanceObject, 1, -1)});
            widgetClock.CustomButtonClick += _widgetCalendar_CustomButtonClick;
            
            _widgetView.Documents.Add(widgetClock);
            _widgetView.FreeLayoutProperties.FreeLayoutItems.Add(widgetClock);
            timeWidgetContainer.Element = widgetClock;
            _widgetView.RootContainer.Nodes.Add(timeWidgetContainer);
        }

        private void _widgetCalendar_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            var cBtn = e.Button as CustomHeaderButton;
            if (cBtn.Tag != null && ((int)(cBtn.Tag) == 1))
                UtilityHelper.ShowInfoMessage("设置");
        }
    }
}