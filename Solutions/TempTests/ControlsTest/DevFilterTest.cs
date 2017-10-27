using System;
using System.Windows.Forms;

namespace WitsWay.TempTests.ControlsTest
{
    public partial class Form1 : Form
    {
        public Form1()
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
        }

    }
}
