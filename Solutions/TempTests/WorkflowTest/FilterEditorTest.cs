using System;
using System.Windows.Forms;

namespace WitsWay.TempTests.WorkflowTest
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void SetNewDataSource(DevExpress.Xpo.XPCollection newDataSource)
        {
            // set new datasource
            filterEditorControl1.SourceControl = newDataSource;

            // set default filter string
            filterEditorControl1.FilterString = "[Country.Name] = 'Test'";

            // call event to set labels
            filterEditorControl1_FilterTextChanged(null, null);
        }

        private void SetNewDataSourceFilter(string filterString)
        {
            // check datasource
            if (filterEditorControl1.SourceControl as DevExpress.Xpo.XPCollection == null)
                return;

            // try to set criteriastring
            try { (filterEditorControl1.SourceControl as DevExpress.Xpo.XPCollection).CriteriaString = filterString; }
            catch { }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            // set datasource
            SetNewDataSource(new DevExpress.Xpo.XPCollection(new DevExpress.Xpo.Session(), typeof(Address)));
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            // set datasource
            SetNewDataSource(new DevExpress.Xpo.XPCollection(new DevExpress.Xpo.Session(), typeof(AddressHalfXpo)));
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            // set datasource
            SetNewDataSource(new DevExpress.Xpo.XPCollection(new DevExpress.Xpo.Session(), typeof(AddressFullXpo)));
        }


        private void filterEditorControl1_FilterTextChanged(object sender, DevExpress.XtraEditors.FilterTextChangedEventArgs e)
        {
            // set new filter
            SetNewDataSourceFilter(filterEditorControl1.FilterString);

            // set text in labels
            label2.Text = string.Format("Filter in editor: {0}", filterEditorControl1.IsFilterCriteriaValid);
            label1.Text = string.Format("Filter in datasource: {0}", filterEditorControl1.SourceControl != null && (filterEditorControl1.SourceControl as DevExpress.Xpo.XPCollection).CriteriaString == filterEditorControl1.FilterString);
           
            //设置Grid的Filter字符串方式
//            grid.FilterCriteria = (
//new BinaryOperator("OrderDate", new DateTime(1995, 1, 1), BinaryOperatorType.Less) &
//new BinaryOperator("UnitPrice", 10, BinaryOperatorType.Less)) |
//(new BinaryOperator("OrderDate", new DateTime(1996, 1, 1), BinaryOperatorType.GreaterOrEqual) &
//new BinaryOperator("UnitPrice", 100, BinaryOperatorType.GreaterOrEqual));
//            grid.FilterCriteria =
//        CriteriaOperator.Parse("([OrderDate] < #1/1/1995# AND [UnitPrice] < 10)" +
//        " OR ([OrderDate] >= #1/1/1996# AND [UnitPrice] >= 100)");

//            grid.FilterString = "([OrderDate] < #1/1/1995# AND [UnitPrice] < 10)" +
//                " OR ([OrderDate] >= #1/1/1996# AND [UnitPrice] >= 100)";
        }




    }
}
