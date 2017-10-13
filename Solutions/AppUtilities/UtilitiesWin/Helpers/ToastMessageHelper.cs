#region License(Apache Version 2.0)
/******************************************
 * Copyright ®2017-Now WangHuaiSheng.
 * Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file
 * except in compliance with the License. You may obtain a copy of the License at
 * http://www.apache.org/licenses/LICENSE-2.0
 * Unless required by applicable law or agreed to in writing, software distributed under the
 * License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
 * either express or implied. See the License for the specific language governing permissions
 * and limitations under the License.
 * Detail: https://github.com/WangHuaiSheng/WitsWay/LICENSE
 * ***************************************/
#endregion 
#region ChangeLog
/******************************************
 * 2017-10-7 OutMan Create
 * 
 * ***************************************/
#endregion
using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using WitsWay.Utilities.Win.Entities;
using WitsWay.Utilities.Win.Extends;
using WitsWay.Utilities.Win.Properties;

namespace WitsWay.Utilities.Win.Helpers
{
    /// <summary>
    /// 提示消息帮助类
    /// </summary>
    public class ToastMessageHelper
    {
        /// <summary>
        /// 显示Toast
        /// </summary>
        /// <param name="option">消息选项</param>
        /// <param name="parentForm">父窗体</param>
        /// <param name="msg">显示消息</param>
        public static void ShowToastMessage(ToastOptions option, Form parentForm, string msg)
        {
            if (parentForm.GetTag("aaaaaa") == null)
            {
                var ticks = DateTime.Now.Ticks;
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
                labelControl.Name = $"_labelControl{ticks}";
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
                panelControl.Name = $"_panelControl{ticks}";
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
                flyoutPanel.Name = $"_flyoutPanel{ticks}";
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

                parentForm.SetTag(WinUtilityConsts.FormToastFlyoutPanelTagKey, flyoutPanel);
                parentForm.SetTag(WinUtilityConsts.FormToastFlyoutPanelLabelTagKey, labelControl);
            }

            var fPanel = parentForm.GetTag<FlyoutPanel>(WinUtilityConsts.FormToastFlyoutPanelTagKey);
            var lbl = parentForm.GetTag<LabelControl>(WinUtilityConsts.FormToastFlyoutPanelLabelTagKey);
            lbl.Text = msg;
            fPanel.ShowPopup();

        }

        /// <summary>
        /// 显示Toast
        /// </summary>
        /// <param name="option">消息选项</param>
        /// <param name="parentForm">父窗体</param>
        /// <param name="ctr">显示控件</param>
        public static void ShowControlToast(ToastOptions option, Form parentForm, Control ctr)
        {
            var fPanel = parentForm.GetTag<FlyoutPanel>(WinUtilityConsts.FormToastFlyoutPanelControlTagKey);
            if (fPanel != null)
            {
                fPanel.ShowPopup();
                return;
            }
            var ticks = DateTime.Now.Ticks;
            ctr.Dock = DockStyle.Fill;
            //_panelControl
            var panelControl = new PanelControl();
            panelControl.SuspendLayout();
            panelControl.Appearance.BackColor = Color.Transparent;
            panelControl.Appearance.Options.UseBackColor = true;
            panelControl.AutoSize = false;
            panelControl.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelControl.BorderStyle = BorderStyles.NoBorder;
            panelControl.Controls.Add(ctr);
            panelControl.Dock = DockStyle.Fill;
            panelControl.Name = $"_panelControl{ticks}";
            panelControl.Padding = new Padding(20, 0, 30, 0);
            panelControl.ResumeLayout(false);
            //flyoutPanel
            var flyoutPanel = new FlyoutPanel();
            flyoutPanel.SuspendLayout();
            flyoutPanel.Appearance.BackColor = Color.PaleGreen;
            flyoutPanel.Appearance.BackColor2 = Color.PaleGreen;
            flyoutPanel.Appearance.BorderColor = Color.DarkGreen;
            flyoutPanel.Appearance.Options.UseBackColor = true;
            flyoutPanel.Appearance.Options.UseBorderColor = true;
            flyoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flyoutPanel.Controls.Add(panelControl);
            flyoutPanel.LookAndFeel.UseDefaultLookAndFeel = false;
            flyoutPanel.Name = $"_flyoutPanel1{ticks}";
            flyoutPanel.OptionsBeakPanel.BackColor = Color.PaleGreen;
            flyoutPanel.OptionsBeakPanel.BorderColor = Color.Transparent;
            flyoutPanel.Padding = new Padding(20, 0, 20, 0);
            parentForm.Controls.Add(flyoutPanel);
            flyoutPanel.ResumeLayout(false);
            flyoutPanel.Height = 60;
            flyoutPanel.OwnerControl = flyoutPanel.FindForm();
            flyoutPanel.Options.AnchorType = option.Anchor;
            flyoutPanel.Options.AnimationType = option.AnimationKind;
            flyoutPanel.Options.CloseOnOuterClick = option.CloseOnOuterClick;
            flyoutPanel.Options.Location = option.CustomPosition;
            flyoutPanel.PerformLayout();
            //SetTag
            parentForm.SetTag(WinUtilityConsts.FormToastFlyoutPanelControlTagKey, flyoutPanel);
            flyoutPanel.ShowPopup();

        }

    }
}
