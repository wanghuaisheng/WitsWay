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
using System.Drawing;
using DevExpress.XtraEditors;

namespace WitsWay.Utilities.Win.Helpers
{
    /// <summary>
    /// Button样式辅助类
    /// </summary>
    public class ButtonStyleHelper
    {
        /// <summary>
        /// 设置Button样式
        /// </summary>
        public static void StyleButton(SimpleButton btn, Image img, int? width = null, string text = null, bool isShowText = true, int? height = null)
        {
            if (width <= 0) { width = null; }

            btn.Image = img;

            if (isShowText)
            {
                btn.Font = new Font("宋体", 9);
                btn.Text = string.IsNullOrEmpty(text) ? btn.Text : text;
                btn.Width = width ?? (btn.Text.Length * 12 + 32);
            }
            else
            {
                btn.Text = "";
                btn.Width = 24;
                btn.ImageLocation = ImageLocation.MiddleCenter;
            }
            if (btn is DropDownButton)
            {
                btn.Width += 16;
            }

            btn.Height = height ?? 24;
        }

    }
}
