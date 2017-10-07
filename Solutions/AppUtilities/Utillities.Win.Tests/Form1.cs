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
using System.Collections.Generic;
using WitsWay.Utilities.Models;
using WitsWay.Utilities.Win.Extends;

namespace WitsWay.Utilities.Win.Tests
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var logins = new List<LoginResult>();
            for (int i = 0; i < 100; i++)
            {
                logins.Add(new LoginResult
                {
                    CorpCode = "CorpCode" + i,
                    CorpId = i,
                    CorpKind = 1,
                    CorpName = "CorpName" + i,
                    CorpShortName = "CorpShortName" + i,
                    EmployeeId = i,
                    EmployeeName = "EmployeeName" + i,
                    EmployeeWorkNumber = "EmployeeWorkNumber" + i,
                    LoginTime = DateTime.Now,
                    Nickname = "Nickname" + i,
                    RenewalInterval = -1,
                    RenewalTime = DateTime.Now,
                    SessionKey = "SessionKey" + i,
                    SignPublicKey = "SignPublicKey" + i,
                    Username = "Username" + i
                });
            }
            gridControl1.DataSource = logins;
            gridView1.SetStyle(false);
        }

        private void _btnBindDoubleClick_Click(object sender, EventArgs e)
        {
            gridView1.BindRowDoubleClick<LoginResult>(result => UtilityHelper.ShowInfoMessage(result.CorpName));
        }

        private void _btnUnbindDoubleClick_Click(object sender, EventArgs e)
        {
            gridView1.UnbindRowDoubleClick<LoginResult>();
        }

        private void _btnBindPopupMenu_Click(object sender, EventArgs e)
        {
            gridView1.BindPopup(_popupViewRow, (LoginResult r) => r.CorpId % 2 == 0);
        }

        private void _btnUnbindPopupMenu_Click(object sender, EventArgs e)
        {
            gridView1.UnbindPopup<LoginResult>(_popupViewRow);
        }

        private void _bbiOne_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UtilityHelper.ShowInfoMessage(gridView1.GetFocusData<LoginResult>().CorpName);
        }
    }
}
