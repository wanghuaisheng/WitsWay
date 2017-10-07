/******************************************
 * 2012年7月21日 王怀生 添加
 * 
 * ***************************************/

using System.Drawing;
using DevExpress.XtraEditors;
using WitsWay.Utilities.Attributes;

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
        public static void StyleButton(SimpleButton btn, ButtonStyles style, int? width = null, string text = null, bool isShowText = true, int? height = null)
        {
            if (width <= 0) { width = null; }

            btn.Image = GetButtonIcon(style);

            if (isShowText)
            {
                btn.Font = new Font("宋体", 9);
                btn.Text = string.IsNullOrEmpty(text) ? EnumFieldAttribute.GetFieldText(style) : text;
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

        /// <summary>
        /// 取得图标
        /// </summary>
        private static Image GetButtonIcon(ButtonStyles style)
        {
            return IconManager.GetIcon(style + "16");
        }

    }
}
