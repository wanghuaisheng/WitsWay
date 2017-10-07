﻿#region License(Apache Version 2.0)
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
using DevExpress.XtraEditors;
using WitsWay.Utilities.Win.Helpers;

namespace WitsWay.Utilities.Win.Controls
{
    public partial class WaitUC : XtraUserControl
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        public WaitUC(string msg="请稍后…")
        {
            InitializeComponent();
            ControlStyleHelper.SetLoadingCircle(_loadingCircle);
            _lblMsg.Text = msg;
        }

        private void WaitUC_SizeChanged(object sender, EventArgs e)
        {
            UtilityHelper.CenterControl(_panelContent,this);
        }

        private void WaitUC_Load(object sender, EventArgs e)
        {

        }
    }
}
