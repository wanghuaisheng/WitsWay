using System;
using DevExpress.Utils;
using DevExpress.Utils.Win;
using DevExpress.XtraEditors;

namespace WitsWay.TempTests.ControlsTest.ToastUC
{
    /// <summary>
    /// 提醒消息框
    /// </summary>
    public partial class ToastMessagePanel : XtraUserControl
    {
        /// <summary>
        /// 提醒消息选项
        /// </summary>
        public ToastMessageOptions Options { get; } = new ToastMessageOptions();

        private void ToastMessagePanel_Load(object sender, EventArgs e)
        {
            InitControls();
            UpdateControls();
            Text = @"提醒消息窗体";
        }

        public ToastMessagePanel()
        {
            InitializeComponent();
        }
        void InitControls()
        {
            foreach (PopupToolWindowAnchor anchorType in Enum.GetValues(typeof(PopupToolWindowAnchor)))
            {
                cbAnchorTypes.Properties.Items.Add(anchorType);
            }
            cbAnchorTypes.EditValue = Options.Anchor;
            foreach (PopupToolWindowAnimation animationType in Enum.GetValues(typeof(PopupToolWindowAnimation)))
            {
                cbAnimationTypes.Properties.Items.Add(animationType);
            }
            cbAnimationTypes.EditValue = Options.AnimationKind;
            ceCloseOnOuterClick.Checked = Options.CloseOnOuterClick;
            _spinXPosition.Value = Options.PositionX;
            _spinYPosition.Value = Options.PositionY;
        }

        void OnAnchorTypeSelectedValueChanged(object sender, EventArgs e)
        {
            ComboBoxEdit edit = (ComboBoxEdit)sender;
            Options.Anchor = (PopupToolWindowAnchor)edit.EditValue;
            if (Options.Anchor == PopupToolWindowAnchor.Center || Options.Anchor == PopupToolWindowAnchor.Manual)
                cbAnimationTypes.EditValue = PopupToolWindowAnimation.Fade;
            UpdateControls();
        }

        void OnAnimationTypesSelectedValueChanged(object sender, EventArgs e)
        {
            ComboBoxEdit edit = (ComboBoxEdit)sender;
            Options.AnimationKind = (PopupToolWindowAnimation)edit.EditValue;
        }

        void OnCloseOnOuterClickCheckedChanged(object sender, EventArgs e)
        {
            CheckEdit edit = (CheckEdit)sender;
            Options.CloseOnOuterClick = edit.Checked;
            if (_fPanel != null) _fPanel.Options.CloseOnOuterClick = Options.CloseOnOuterClick;
        }

        void OnCoordEditValueChanged(object sender, EventArgs e)
        {
            SpinEdit edit = (SpinEdit)sender;
            Options.PositionX = (int)edit.Value;
        }

        void OnYCoordEditValueChanged(object sender, EventArgs e)
        {
            SpinEdit edit = (SpinEdit)sender;
            Options.PositionY = (int)edit.Value;
        }

        void OnFlyoutPanelHidden(object sender, FlyoutPanelEventArgs e)
        {
            FlyoutPanel panel = (FlyoutPanel)sender;
            if (_fPanel == null || !ReferenceEquals(panel, _fPanel)) return;
            _fPanel = null;
            UpdateControls();
        }

        void OnShowToolWindowClick(object sender, EventArgs e)
        {
            ShowToolWindowCore();
        }

        void OnHideToolWindowClick(object sender, EventArgs e)
        {
            HideToolWindowCore();
        }

        private FlyoutPanel _fPanel;
        void ShowToolWindowCore()
        {
            FlyoutPanel panel = SelectPanel();
            panel.OwnerControl = this;
            panel.Options.AnchorType = Options.Anchor;
            panel.Options.AnimationType = Options.AnimationKind;
            panel.Options.CloseOnOuterClick = Options.CloseOnOuterClick;
            panel.Options.Location = Options.CustomPosition;
            panel.ShowPopup();
            _fPanel = panel;
            UpdateControls();
        }

        void HideToolWindowCore()
        {
            if (_fPanel == null) return;
            _fPanel.HidePopup();
            _fPanel = null;
            UpdateControls();
        }
        FlyoutPanel SelectPanel()
        {
            return Options.Anchor == PopupToolWindowAnchor.Left || Options.Anchor == PopupToolWindowAnchor.Right ? _flyoutPanelV : _flyoutPanelH;
        }
        void UpdateControls()
        {
            btnShowToolWindow.Enabled = _fPanel == null;
            btnHideToolWindow.Enabled = !btnShowToolWindow.Enabled;
            var isManual = Options.Anchor == PopupToolWindowAnchor.Manual;
            _spinXPosition.Enabled = _spinYPosition.Enabled = lblXCoord.Enabled = lblYCoord.Enabled = isManual;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            ToastMessageHelper.InitToast(new ToastMessageOptions {Anchor=PopupToolWindowAnchor.Top,AnimationKind=PopupToolWindowAnimation.Slide,CloseOnOuterClick=true},FindForm(),DateTime.Now.ToLongTimeString());
        }
    }


}
