using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace WitsWay.TempTests.GeneralQuery.Selectors
{
    public partial class SpinEditor : XtraUserControl, IValueSelector
    {
        public SpinEditor()
        {
            InitializeComponent();
        }

        public string SelectorKey => "spin";

        public string SelectorName => "数字控件";

        public SelectWays SelectWay { get; set; }

        public void BindValues(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return;
            var vals = value.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            if (!vals.Any()) return;
            int parseVal;
            if (vals.Any(val => !int.TryParse(val, out parseVal))) return;
            _values.Clear();
            _values.AddRange(vals);
            _tokenEdit.Properties.Tokens.Clear(); _tokenEdit.Properties.Tokens.AddRange(vals.Select(val => new TokenEditToken
             {
                 Value = val,
                 Description = val
             }));

            _tokenEdit.EditValue = value;
        }

        public UserControl GetControl()
        {
            return this;
        }


        private ColumnDefinitionRow _data;
        private Action<ColumnDefinitionRow> _successAction;
        private Action _cancelAction;

        public void InitSelector(ColumnDefinitionRow data, Action<ColumnDefinitionRow> successAction, Action cancelAction)
        {
            _data = data;
            _successAction = successAction;
            _cancelAction = cancelAction;
        }

        private readonly List<string> _values = new List<string>();
        private void _btnAdd_Click(object sender, EventArgs e)
        {
            var val = _spinEdit.EditValue.ToString();
            if (_values.Contains(val)) return;
            var token = new TokenEditToken()
            {
                Value = val,
                Description = val
            };
            _tokenEdit.Properties.Tokens.Add(token);
            _values.Add(val);
            _tokenEdit.EditValue = string.Join(",", _values);
        }

        private void _btnOk_Click(object sender, EventArgs e)
        {
            _data.Values = _tokenEdit.EditText;
            _successAction(_data);
        }

        private void _btnCancel_Click(object sender, EventArgs e)
        {
            _cancelAction();}

    }
}
