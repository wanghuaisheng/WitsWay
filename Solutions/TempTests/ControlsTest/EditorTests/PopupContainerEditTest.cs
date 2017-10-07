using System;
using System.ComponentModel;
using DevExpress.XtraEditors.Controls;

namespace WitsWay.TempTests.ControlsTest.EditorTests
{
    public partial class PopupContainerEditTest : DevExpress.XtraEditors.XtraForm
    {
        public PopupContainerEditTest()
        {
            InitializeComponent();
            _popupContainerEdit.Properties.CloseOnOuterMouseClick = true;
            _popupContainerEdit.Properties.ShowDropDown = ShowDropDown.DoubleClick;
            _popupContainerEdit.Properties.PopupSizeable = true;
            _popupContainerEdit.Properties.ShowPopupCloseButton = true;
            _popupContainerEdit.Properties.ShowPopupShadow = false;
        }

        private void PopupContainerEditTest_Load(object sender, EventArgs e)
        {

        }
        private void _btnOk_Click(object sender, EventArgs e)
        {
            //_popupContainerEdit.EditValue = _textEdit.Text;
            ClosePopup();
        }

        /// <summary>
        /// 关闭弹出框
        /// </summary>
        private void ClosePopup()
        {
            if (_popupContainer.OwnerEdit == null) return;
            _popupContainer.OwnerEdit.ClosePopup();
        }

        private void _popupContainerEdit_QueryPopUp(object sender, CancelEventArgs e)
        {
            if (_textEdit.Text == "1") e.Cancel = true;
            //ilbFont.SelectedValue = CurrentFont.Name;
            //seSize.Value = Convert.ToDecimal(CurrentFont.Size);
            //foreach (CheckedListBoxItem item in clbStyle.Items)
            //    item.CheckState = (CurrentFontStyle.IndexOf(item.Value.ToString()) > -1) ? CheckState.Checked : CheckState.Unchecked;
        }

        private void _popupContainerEdit_QueryResultValue(object sender, QueryResultValueEventArgs e)
        {
            //QueryResultValue用于，关闭Popup时更新Editor值
            e.Value = _textEdit.Text;
            //_popupContainerEdit.EditValue = _textEdit.Text;
        }
    }
}