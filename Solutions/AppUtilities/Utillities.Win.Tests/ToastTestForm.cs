using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WitsWay.Utilities.Models;
using WitsWay.Utilities.Win.Entities;
using WitsWay.Utilities.Win.Enums;
using WitsWay.Utilities.Win.Extends;

namespace WitsWay.Utilities.Win.Tests
{
    public partial class ToastTestForm : DevExpress.XtraEditors.XtraForm
    {
        public ToastTestForm()
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
            GridViewExtends.SetStyle(gridView1, false);
        }

        private void _btnBindDoubleClick_Click(object sender, EventArgs e)
        {
            GridViewExtends.BindRowDoubleClick<LoginResult>(gridView1, result => UtilityHelper.ShowInfoMessage(result.CorpName));
        }

        private void _btnUnbindDoubleClick_Click(object sender, EventArgs e)
        {
            GridViewExtends.UnbindRowDoubleClick<LoginResult>(gridView1);
        }

        private void _btnBindPopupMenu_Click(object sender, EventArgs e)
        {
            GridViewExtends.BindPopup(gridView1, _popupViewRow, (LoginResult r) => r.CorpId % 2 == 0);
        }

        private void _btnUnbindPopupMenu_Click(object sender, EventArgs e)
        {
            GridViewExtends.UnbindPopup<LoginResult>(gridView1, _popupViewRow);
        }

        private void _bbiOne_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UtilityHelper.ShowInfoMessage(GridViewExtends.GetFocusData<LoginResult>(gridView1).CorpName);
        }

        private void _btnShowMsgSuccess_Click(object sender, EventArgs e)
        {
            ToastOptions.NewInstance(ToastKinds.Success).ShowToastMessage("成功",this);
        }

        private void _btnShowMsgError_Click(object sender, EventArgs e)
        {

            ToastOptions.NewInstance(ToastKinds.Error).ShowToastMessage("错误", this);
        }

        private void _btnShowMsgInfo_Click(object sender, EventArgs e)
        {

            ToastOptions.NewInstance(ToastKinds.Info).ShowToastMessage("信息", this);
        }

        private void _btnShowMsgWarning_Click(object sender, EventArgs e)
        {

            ToastOptions.NewInstance(ToastKinds.Warning).ShowToastMessage("警告", this);
        }

        private void _btnShowMsgControl_Click(object sender, EventArgs e)
        {
            ToastOptions.NewInstance().ShowToastControl(_pictureBox, this);
        }
    }
}
