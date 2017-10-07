using System;
using System.Collections.Generic;

namespace WitsWay.TempTests.ControlsTest.EditorTests
{
    public partial class TreeListLookupEditorTest : DevExpress.XtraEditors.XtraForm
    {
        public TreeListLookupEditorTest()
        {
            InitializeComponent();
            treeListLookUpEdit1.Properties.DisplayMember = "Name";
            treeListLookUpEdit1.Properties.ValueMember = "Id";
        }

        private List<Product> _products = new List<Product>()
        {
            new Product{Id=1,ParentId = 0,Model="A",Name="总公司"},
           new Product{Id=2,ParentId = 1,Model="A",Name="子公司1"},
           new Product{Id=3,ParentId = 1,Model="A",Name="子公司2"}
        };


        public class Product
        {
            public int Id { get; set; }

            public int ParentId { get; set; }
            public string Model { get; set; }
            public string Name { get; set; }
        }

        private void TreeListLookupEditorTest_Load(object sender, EventArgs e)
        {
            List<Product> list = _products;
            treeListLookUpEdit1.Properties.DataSource = list;
        }

    }
}