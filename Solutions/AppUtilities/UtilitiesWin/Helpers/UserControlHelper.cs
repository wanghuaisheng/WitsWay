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
