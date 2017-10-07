using System;
using System.Collections.Generic;
using System.Data;
using DevExpress.XtraEditors.Controls;

namespace WitsWay.TempTests.ControlsTest.EditorTests
{
    public partial class SearchLookupEditorTest : DevExpress.XtraEditors.XtraForm
    {
        public SearchLookupEditorTest()
        {
            InitializeComponent();
            //双击显示下拉列表
            searchLookUpEdit1.Properties.ShowDropDown = ShowDropDown.DoubleClick;
            searchLookUpEdit1.Properties.ImmediatePopup = true;//显示下拉列表
            searchLookUpEdit1.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;//此控件不允许输入
            searchLookUpEdit1.Properties.NullText = "";//清空默认值
            searchLookUpEdit1.Properties.DisplayMember = "Name";
            searchLookUpEdit1.Properties.ValueMember = "Id";
        }

        private void SearchLookupEditorTest_Load(object sender, EventArgs e)
        {
            List<Product> list = Entility.GetProductList();
            searchLookUpEdit1.Properties.DataSource = list;
        }


        public class Product
        {
            public int Id { get; set; }
            public string Model { get; set; }
            public string Name { get; set; }
        }
        public class Entility
        {
            private static string GetChar(int number)
            {
                string[] array = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I" };
                string result = array[number % 9];
                return result;
            }
            private static string GetName(int number)
            {
                string[] array = 
           {
               "Unitch数据采集器","MS扫描枪","105SL","TSC","PH880","MS320便携式打印机","PA700","DSX800电脑","HP打印机"
           };
                string result = array[number % 9];
                return result;
            }

            public static List<Product> GetProductList()
            {
                List<Product> list = new List<Product>();
                for (int i = 0; i < 200; i++)
                {
                    Product product = new Product()
                    {
                        Id = 100 + i,
                        Model = GetChar(i) + i.ToString() + "DLJ",
                        Name = GetName(i) + i.ToString()
                    };
                    list.Add(product);
                }
                return list;
            }
            public static DataTable GetDataTable()
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Id", typeof(System.Int32));
                dt.Columns.Add("Model", typeof(System.String));
                dt.Columns.Add("Name", typeof(System.String));
                for (int i = 0; i < 200; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr["Id"] = 100 + i;
                    dr["Model"] = GetChar(i) + i.ToString() + "DLJ";
                    dr["Name"] = GetName(i) + i.ToString();
                    dt.Rows.Add(dr);
                }
                return dt;
            }
        }

        private void searchLookUpEdit1View_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0 && e.Info.IsRowIndicator)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

    }
}