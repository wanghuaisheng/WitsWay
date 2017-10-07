using DevExpress.XtraEditors;

namespace WitsWay.TempTests.GeneralQuery.QueryForms
{

    public partial class GridWithFilterUc2 :XtraUserControl
    {
        public GridWithFilterUc2()
        {
            InitializeComponent();
            ////var btn1=_gridNavPane.ButtonsPanel.Buttons[0] as NavigationButton;
            //////btn1.UseCaption
            ////_gridNavPane.ButtonsPanel.Buttons.SafeForEach(btn=>
            ////{
            ////    var nBtn=((NavigationButton)btn);
            ////    nBtn.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
            ////    nBtn.
            ////});
            //////btn.Image.RotateFlip(RotateFlipType.Rotate90FlipX);
            //////btn.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            //////btn.Appearance.Image.
        }

        private void navigationPage1_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            ShowMessage(e.Button.Properties.Caption);
        }

        private void ShowMessage(string msg)
        {
            XtraMessageBox.Show(msg);
        }

        private void _btnSearchConfirm_Click(object sender, System.EventArgs e)
        {
            var filter=searchControlUC1.GetFilter();

        }

        private void _btnSearchReset_Click(object sender, System.EventArgs e)
        {

        }
    }
}