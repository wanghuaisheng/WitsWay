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
