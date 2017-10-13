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
 * 2017-10-13 OutMan Create
 * 
 * ***************************************/
#endregion
using System;
using System.Windows.Forms;
using WitsWay.Utilities.Win.Entities;
using WitsWay.Utilities.Win.Enums;
using WitsWay.Utilities.Win.Helpers;

namespace WitsWay.Utilities.Win
{
    /// <summary>
    /// WinForm通用辅助类
    /// </summary>
    public static partial class UtilityHelper
    {

        /// <summary>
        /// 提示
        /// </summary>
        public static void ShowToast(ToastKinds kind, ToastOptions options, string msg, Form frm)
        {
            var frm2 = frm ?? (Application.OpenForms.Count > 0 ? Application.OpenForms[0] : null);
            if (frm2 == null) throw new ArgumentException($"ShowToast参数{nameof(frm)}为空");
            ToastMessageHelper.ShowToastMessage(options, frm2, msg);
        }

        /// <summary>
        /// 显示提示（内容为用户控件）
        /// </summary>
        /// <param name="options">选项</param>
        /// <param name="ctr">控件</param>
        /// <param name="frm">窗体</param>
        /// <returns></returns>
        public static void ShowToast(ToastOptions options, Control ctr, Form frm = null)
        {
            var frm2 = frm ?? ctr.FindForm();
            if (frm2 == null) throw new ArgumentException($"ShowToast参数{nameof(frm)}为空");
            if (ctr == null) throw new ArgumentException($"ShowToast参数{nameof(ctr)}为空");
            ToastMessageHelper.ShowControlToast(options, frm2, ctr);
        }

    }

}