using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace WitsWay.TempTests.GeneralQuery.Selectors
{

    public partial class DeptSelector : XtraUserControl, IValueSelector
    {
        public string SelectorKey => "UserSelector";

        /// <summary>
        /// 选择器名称
        /// </summary>
        public string SelectorName => "用户选择器";

        public SelectWays SelectWay { get; set; }

        public void BindValues(string value)
        {
            _txtUsers.Text = value;
        }

        public string GetValues()
        {
            return _txtUsers.Text.Trim();
        }

        public DialogResult Result { get; set; }

        private ColumnDefinitionRow _data;
        private Action<ColumnDefinitionRow> _successAction;
        private Action _cancelAction;

        public void InitSelector(ColumnDefinitionRow data, Action<ColumnDefinitionRow> successAction, Action cancelAction)
        {
            _data = data;
            _successAction = successAction;
            _cancelAction = cancelAction;
        }
        public DeptSelector()
        {
            InitializeComponent();
        }

        private void _btnOk_Click(object sender, EventArgs e)
        {
            _data.Values = GetValues();
            _successAction(_data);
        }

        private void _btnCancel_Click(object sender, EventArgs e)
        {
            _cancelAction();
        }


        public UserControl GetControl()
        {
            Result=DialogResult.Cancel;
            return this;
        }

    }
}
