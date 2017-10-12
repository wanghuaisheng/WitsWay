using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using WitsWay.TempTests.ControlsTest.Properties;
using WitsWay.Utilities.Win.Extends;

namespace WitsWay.TempTests.ControlsTest.ToastUC
{
    /// <summary>
    /// 提示消息帮助类
    /// </summary>
    public class ToastMessageHelper
    {
        public static void InitToast(ToastMessageOptions option, Form parentForm, string msg)
        {
            if (parentForm.GetTag("aaaaaa") == null)
            {
                var labelControl = new LabelControl();
                // 
                // _labelControl
                // 
                labelControl.Appearance.Font = new Font("Tahoma", 16F);
                labelControl.Appearance.ForeColor = Color.SeaGreen;
                labelControl.Appearance.Image = Resources.LightGreen;
                labelControl.Appearance.Options.UseFont = true;
                labelControl.Appearance.Options.UseForeColor = true;
                labelControl.Appearance.Options.UseImage = true;
                labelControl.Appearance.Options.UseTextOptions = true;
                labelControl.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
                labelControl.AutoSizeMode = LabelAutoSizeMode.None;
                labelControl.Dock = DockStyle.Fill;
                labelControl.ImageAlignToText = ImageAlignToText.LeftCenter;
                labelControl.Name = "_labelControl1";
                // 
                // _panelControl
                // 
                var panelControl = new PanelControl();
                panelControl.SuspendLayout();

                panelControl.Appearance.BackColor = Color.Transparent;
                panelControl.Appearance.Options.UseBackColor = true;
                panelControl.AutoSize = false;
                panelControl.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                panelControl.BorderStyle = BorderStyles.NoBorder;
                panelControl.Controls.Add(labelControl);
                panelControl.Dock = DockStyle.Fill;
                panelControl.Name = "_panelControl1";
                panelControl.Padding = new Padding(20, 0, 30, 0);

                panelControl.ResumeLayout(false);


                //flyoutPanel
                var flyoutPanel = new FlyoutPanel();
                flyoutPanel.SuspendLayout();
                //样式设置
                flyoutPanel.Appearance.BackColor = Color.PaleGreen;
                flyoutPanel.Appearance.BackColor2 = Color.PaleGreen;
                flyoutPanel.Appearance.BorderColor = Color.DarkGreen;
                flyoutPanel.Appearance.Options.UseBackColor = true;
                flyoutPanel.Appearance.Options.UseBorderColor = true;
                flyoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                flyoutPanel.Controls.Add(panelControl);
                flyoutPanel.LookAndFeel.UseDefaultLookAndFeel = false;
                flyoutPanel.Name = "_flyoutPanel1";
                flyoutPanel.OptionsBeakPanel.BackColor = Color.PaleGreen;
                flyoutPanel.OptionsBeakPanel.BorderColor = Color.Transparent;
                flyoutPanel.Padding = new Padding(20, 0, 20, 0);

                parentForm.Controls.Add(flyoutPanel);
                flyoutPanel.ResumeLayout(false);
                flyoutPanel.Height = 60;
                flyoutPanel.PerformLayout();

                flyoutPanel.OwnerControl = flyoutPanel.FindForm();
                flyoutPanel.Options.AnchorType = option.Anchor;
                flyoutPanel.Options.AnimationType = option.AnimationKind;
                flyoutPanel.Options.CloseOnOuterClick = option.CloseOnOuterClick;
                flyoutPanel.Options.Location = option.CustomPosition;

                parentForm.SetTag("aaaaaa", flyoutPanel);
                parentForm.SetTag("labelControldddd",labelControl);
            }

            var fPanel = parentForm.GetTag<FlyoutPanel>("aaaaaa");
            var lbl = parentForm.GetTag<LabelControl>("labelControldddd");
            lbl.Text = msg;
            fPanel.ShowPopup();

        }

    }
}
