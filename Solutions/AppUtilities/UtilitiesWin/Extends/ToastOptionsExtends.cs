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
