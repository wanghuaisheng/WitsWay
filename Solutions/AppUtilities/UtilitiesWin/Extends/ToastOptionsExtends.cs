using System.Windows.Forms;
using WitsWay.Utilities.Win.Entities;
using WitsWay.Utilities.Win.Helpers;

namespace WitsWay.Utilities.Win.Extends
{
    /// <summary>
    /// <see cref="ToastOptions"/>实例扩展
    /// </summary>
    public static class ToastOptionsExtends
    {
        /// <summary>
        /// 显示Toast消息
        /// </summary>
        /// <param name="option">选项</param>
        /// <param name="msg">消息</param>
        /// <param name="parentForm">父窗体</param>
        public static void ShowToastMessage(this ToastOptions option, string msg, Form parentForm)
        {
            UtilityHelper.InvokeExecute(parentForm, () => ToastMessageHelper.ShowToastMessage(option, parentForm, msg));
        }
        /// <summary>
        /// 显示Toast消息
        /// </summary>
        /// <param name="option">选项</param>
        /// <param name="ctr">控件</param>
        /// <param name="parentForm">父窗体</param>
        public static void ShowToastControl(this ToastOptions option, Control ctr, Form parentForm)
        {
            UtilityHelper.InvokeExecute(parentForm, () => ToastMessageHelper.ShowControlToast(option, parentForm, ctr));
        }
    }
}
