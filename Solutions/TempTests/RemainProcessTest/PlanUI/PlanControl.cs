using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraBars;
using WitsWay.TempTests.RemainProcessTest.PlanUI.DrawObjects;
using WitsWay.Utilities.Win;

namespace WitsWay.TempTests.RemainProcessTest.PlanUI
{
    public partial class PlanControl : UserControl
    {
        public PlanControl()
        {
            InitializeComponent();
            drawArea1.Initialize(this);
            drawArea1.DrawLayers[0].Graphics.Add(new DrawRectangle(0, 0, 100, 200, Color.Transparent, Color.Aqua, true, 5));
            drawArea1.DrawLayers[0].Graphics.Add(new DrawRectangle(300, 300, 100, 200, Color.Black, Color.Aqua, true, 5));
        }

        public PopupMenu ContextPopup => _popupUnitOperate;

        public BarManager BarManager => _barManager;

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            UtilityHelper.ShowInfoMessage("加工");
        }
    }
}
