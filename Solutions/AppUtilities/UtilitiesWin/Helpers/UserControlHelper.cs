/*修改日志
 * 2012年7月17日   王怀生     添加
 * 
 * */

using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace WitsWay.Utilities.Win.Helpers
{

    /// <summary>
    /// 用户控件辅助类
    /// </summary>
    public class UserControlHelper
    {
        /// <summary>
        /// 用户控件显示为对话框
        /// </summary>
        /// <param name="owner">父窗体</param>
        /// <param name="title">窗体标题</param>
        /// <param name="uc">用户控件</param>
        /// <returns>对话框结果</returns>
        [Obsolete("已作废，请使用UtilityHelper下的同名方法")]
        public static DialogResult ShowDialog(UserControl uc, string title, Form owner)
        {
            var form = new XtraForm();
            form.Text = title;
            form.ClientSize = new Size(uc.Width, uc.Height);
            ControlStyleHelper.SetPopupStyle(form);
            uc.Dock = DockStyle.Fill;
            form.Controls.Add(uc);
            return form.ShowDialog(owner);
        }
    }

}
