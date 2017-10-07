using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraTreeList;
using WitsWay.TempTests.DynamicQuery.Entities;
using WitsWay.Utilities.Supports.TreeSupport;
using WitsWay.Utilities.Win;
using WitsWay.Utilities.Win.Helpers;

namespace WitsWay.TempTests.GeneralQuery.Selectors
{
    public partial class SelectorTest : DevExpress.XtraEditors.XtraForm
    {
        public SelectorTest()
        {
            InitializeComponent();
            InitDatas();
            InitControls();
            //_colNameSwitch.
        }

        private void InitControls()
        {
            _colValuesPopup.PopupControl = this._popupContainer;

            //var fields = EnumField.GetFieldInfos(typeof (EditorKinds));
            _colNameCombo.Items.AddRange(_templates);
            _colNameCombo.SelectedIndexChanged += _colNameCombo_SelectedIndexChanged;
            //4.解决IConvertible问题
            _colNameCombo.ParseEditValue += _colNameCombo_ParseEditValue;
            _colNameSwitch.ParseEditValue += _colNameSwitch_ParseEditValue;

        }

        void _colNameSwitch_ParseEditValue(object sender, DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs e)
        {

        }

        void _colNameCombo_ParseEditValue(object sender, DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs e)
        {
            e.Value = e.Value.ToString();
            e.Handled = true;
        }

        void _colNameCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            var val = (sender as ComboBoxEdit).EditValue as ColumnField;
            var selectData = _treeList.FocusedNode.Tag as ColumnDefinitionRow;
            selectData.Label = val.FieldTitle;
            selectData.Field = val.FieldName;
            selectData.Input = val.Input;
            selectData.ValueType = val.ValueType;
            selectData.Values = val.Values;
            selectData.SelectedOperate = val.SelectedOperate;
            selectData.SupportOperates = val.SupportOperates;
            TreeListHelper.UpdateNode(_treeList, selectData, true);
        }


        private void _colNameSwitch_EditValueChanged(object sender, EventArgs e)
        {
            var selectData = _treeList.FocusedNode.Tag as ColumnDefinitionRow;
            //selectData.Label = _colNameSwitch.OwnerEdit.EditValue.ToString();
            var editor = sender as ToggleSwitch;
            selectData.Label = editor.IsOn ? "或" : "且";
            selectData.Values = editor.IsOn ? "or" : "and";

            TreeListHelper.UpdateNode(_treeList, selectData, true);
        }

        private void SelectorTest_Load(object sender, EventArgs e)
        {
            TreeListHelper.BindTree(_treeList, _rows, null, 1);
            TreeStyleHelper.SetXtraTreeStyle(_treeList, _colValues, _colName, _colRelation);
            //treeList1.DataSource = _rows;
            //treeList1.ParentFieldName = "ParentId";
            //treeList1.KeyFieldName = "Id";
        }

        private List<ColumnField> _templates = new List<ColumnField>();

        private List<ColumnDefinitionRow> _rows = new List<ColumnDefinitionRow>()
        {
            new ColumnDefinitionRow{AllowEmpty=false,AllowNull=false,Field="",Id="AndOr1",Input="DropEdit",Label="且",Mask="",MultiRow=false,NullText="",SupportOperates= {},SelectedOperate = "",ParentId="",RowKind=ColumnRowKinds.AndOr,SortCode=1,Template="",ValueType="",Values="AND"}
        };

        private void _btnAddRelations_Click(object sender, EventArgs e)
        {
            var selectData = _treeList.FocusedNode.Tag as ColumnDefinitionRow;
            if (selectData.RowKind != ColumnRowKinds.AndOr) return;
            var col = new ColumnDefinitionRow
            {
                AllowEmpty = false,
                AllowNull = false,
                Field = "",
                Id = selectData.Id + DateTime.Now.Ticks,
                Input = "DropEdit",
                Label = "且",
                Mask = "",
                MultiRow = false,
                NullText = "",
                SupportOperates = null,
                SelectedOperate = "",
                ParentId = selectData.Id,
                RowKind = ColumnRowKinds.AndOr,
                SortCode = 1,
                Template = "",
                ValueType = "",
                Values = "AND"
            };
            _rows.Add(col);

            TreeListHelper.InsertNode(_treeList, col, "", true);
        }

        private void _btnAddDefinitions_Click(object sender, EventArgs e)
        {
            var selectData = _treeList.FocusedNode.Tag as ColumnDefinitionRow;
            if (selectData.RowKind != ColumnRowKinds.AndOr) return;
            var col = new ColumnDefinitionRow
            {
                AllowEmpty = false,
                AllowNull = false,
                Field = "Name",
                Id = Guid.NewGuid().ToString(),
                Input = "EmployeeSelector",
                Label = "姓名",
                Mask = "",
                MultiRow = false,
                NullText = "",
                SupportOperates = new List<string> { "等于", "不等于", "包含", "不包含" },
                SelectedOperate = "等于",
                ParentId = selectData.Id,
                RowKind = ColumnRowKinds.Column,
                SortCode = 1,
                Template = "",
                ValueType = "string",
                Values = "3"
            };
            _rows.Add(col);

            TreeListHelper.InsertNode(_treeList, col, "", true);
        }

        private void _colValuesButtonEditor_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            ShowSelector();
        }

        private void ShowSelector()
        {
            var selectData = _treeList.FocusedNode.Tag as ColumnDefinitionRow;
            if (selectData.RowKind == ColumnRowKinds.AndOr) return;
            var selector = SelectorCreater.GetSelector(selectData, data =>
            {
                TreeListHelper.UpdateNode(_treeList, data, true);
                _popupContainer.Hide();
            },
            () =>
            {
                _popupContainer.Hide();
            });
            selector.BindValues(selectData.Values);
            var uc = selector.GetControl();
            if (_popupContainer.Controls.Count > 0 && ReferenceEquals(uc, _popupContainer.Controls[0])) return;
            _popupContainer.SuspendLayout();
            _popupContainer.Controls.Clear();
            _popupContainer.Controls.Add(uc);
            //_popupContainer.Width = uc.Width;
            //_popupContainer.Height = uc.Height;
            uc.Dock = DockStyle.Fill;
            _popupContainer.ResumeLayout(false);
        }

        /// <summary>
        /// 右键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _treeList_MouseClick(object sender, MouseEventArgs e)
        {
            TreeListHitInfo hi = _treeList.CalcHitInfo(e.Location);
            if (hi == null || hi.Node == null) return;
            hi.Node.Selected = true;
            var data = hi.Node.Tag as ColumnDefinitionRow;
            if (data == null) return;
            if (e.Button == MouseButtons.Right) _popupDefinitions.ShowPopup(MousePosition);
            if (hi.Column == null) return;
            if (hi.Column == _colValues && data.RowKind == ColumnRowKinds.Column)
            {
                hi.Column.OptionsColumn.AllowEdit = true;
                //    hi.Column.ColumnEdit = _colValuesPopup;
            }
            else if (hi.Column == _colName)
            {
                hi.Column.OptionsColumn.AllowEdit = true;
                //    hi.Column.ColumnEdit = _colNameSwitch;
            }
            else
            {
                hi.Column.OptionsColumn.AllowEdit = false;
            }
        }

        private void _colValuesPopupEdit_QueryPopUp(object sender, CancelEventArgs e)
        {
            var selectData = _treeList.FocusedNode.Tag as ColumnDefinitionRow;
            if (selectData.RowKind == ColumnRowKinds.AndOr) e.Cancel = true;
        }


        Dictionary<string, RepositoryItem> _operatesEditorDic = new Dictionary<string, RepositoryItem>();

        private void _treeList_CustomNodeCellEdit(object sender, GetCustomNodeCellEditEventArgs e)
        {



            //_colValuesText.Enabled = false;
            var data = e.Node.Tag as ColumnDefinitionRow;
            var col = e.Column;
            var edit = e.RepositoryItem;
            if (col == _colValues && data.RowKind == ColumnRowKinds.Column) e.RepositoryItem = _colValuesPopup;
            else if (col == _colName && data.RowKind == ColumnRowKinds.AndOr) e.RepositoryItem = _colNameSwitch;
            else if (col == _colName && data.RowKind == ColumnRowKinds.Column) e.RepositoryItem = _colNameCombo;
            else if (col == _colRelation && data.RowKind == ColumnRowKinds.Column)
            {
                if (_operatesEditorDic.ContainsKey(data.Field))
                {
                    e.RepositoryItem = _operatesEditorDic[data.Field];
                }
                else
                {
                    var combo = new RepositoryItemImageComboBox();
                    //_colRelationImageCombo.Items.Clear();
                    combo.Items.AddRange(data.SupportOperates.Select(o => new ImageComboBoxItem() { Description = "●" + o, ImageIndex = new Random().Next(10), Value = o }).ToArray());
                    e.RepositoryItem = combo;
                    _operatesEditorDic[data.Field] = combo;
                }
            }
            else e.RepositoryItem = null;
            //if (_treeList.FocusedColumn == _colValues) { }
            //if (_treeList.FocusedColumn == _colName && selectData.RowKind == ColumnRowKinds.AndOr) e.RepositoryItem = _colNameSwitch;
            //if (_treeList.FocusedColumn == _colName && selectData.RowKind == ColumnRowKinds.Column) e.RepositoryItem = _colNameCombo;



        }

        //private void _treeList_ShowingEditor(object sender, CancelEventArgs e)
        //{
        //    if (_treeList.FocusedColumn == _colValues) e.Cancel = true;
        //}


        private void InitDatas()
        {
            var item1 = new ColumnField
            {
                FieldName = "Name",
                Input = "text",
                FieldTitle = "姓名",
                SupportOperates = new List<string> { "Equal", "NotEqual", "In", "NotIn", "Contains", "StartWith" },
                SelectedOperate = "Contains",
                SortCode = 1,
                ValueType = "string",
                Values = "王"
            };
            var item2 = new ColumnField
            {
                FieldName = "Department",
                Input = "DepartmentSelector",
                FieldTitle = "部门",
                SupportOperates = new List<string>() { "Equal", "NotEqual", "In", "NotIn" },
                SelectedOperate = "In",
                SortCode = 2,
                ValueType = "string",
                Values = "销售,后勤，@MyDepart"
            };
            var item3 = new ColumnField
            {
                FieldName = "Sex",
                Input = "check",
                FieldTitle = "性别",
                SupportOperates = new List<string>() { "Equal" },
                SelectedOperate = "Equal",
                SortCode = 3,
                ValueType = "bool",
                Values = "false"
            };
            var item4 = new ColumnField
            {
                FieldName = "Age",
                Input = "spin",
                FieldTitle = "年龄",
                SupportOperates = new List<string>() { "Equal", "NotEqual", "Between", "In", "NotIn" },
                SelectedOperate = "Between",
                SortCode = 4,
                ValueType = "int",
                Values = "10,20"
            };
            var item5 = new ColumnField
            {
                FieldName = "Birthday",
                Input = "date",
                FieldTitle = "生日",
                SupportOperates = new List<string>() { "Equal", "NotEqual", "Between", "In", "NotIn" },
                SelectedOperate = "In",
                SortCode = 5,
                ValueType = "date",
                Values = "2000-1-1,2017-7-7,@CurrentDay,@CurrentWeek,@CurrentMonth"
            };
            _templates.Add(item1);
            _templates.Add(item2);
            _templates.Add(item3);
            _templates.Add(item4);
            _templates.Add(item5);
        }

        private void _treeList_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            var selectData = _treeList.FocusedNode.Tag as ColumnDefinitionRow;
            if (selectData == null) return;
            _btnAddDefinitions.Enabled = selectData.RowKind == ColumnRowKinds.AndOr;
            _btnAddRelations.Enabled = selectData.RowKind == ColumnRowKinds.AndOr;
        }

        private void _btnTestIt_Click(object sender, EventArgs e)
        {
            var roots =_rows.GetRoots();
            var rules = GetRules(roots).ToList();
            if (rules.Count != 1) throw new Exception("根表达式只能有一个");
            var rule = rules[0];
            if (rule.Value != "or" && rule.Value != "and") throw new Exception("必须以关系表达式开始");
            StringBuilder sb = new StringBuilder();
            var result = GetWhereClause(rule, rule.Rules);
            UtilityHelper.ShowInfoMessage(result);
        }

        private string GetWhereClause(FilterRule pRule, List<FilterRule> cRules)
        {
            var cRuleClauses = cRules.Select(cRule => (cRule.Value == "or" || cRule.Value == "and") ?
                GetWhereClause(cRule, cRule.Rules)
                : string.Format("( {0} {1} {2} )", cRule.Field, cRule.Operator, cRule.Value));
            return "(" + string.Join(pRule.Value, cRuleClauses) + ")";
        }

        private IEnumerable<FilterRule> GetRules(List<ColumnDefinitionRow> rows)
        {
            if (rows == null || rows.Count == 0) return new List<FilterRule>();
            return rows.Select(row => new FilterRule { Condition = row.SelectedOperate, Field = row.Field, Id = row.Id, Input = row.Input, Operator = row.SelectedOperate, Type = row.ValueType, Value = row.Values, Rules = GetRules(row.Children).ToList() });
        }

        private void _btnSaveIt_Click(object sender, EventArgs e)
        {

        }


    }
}