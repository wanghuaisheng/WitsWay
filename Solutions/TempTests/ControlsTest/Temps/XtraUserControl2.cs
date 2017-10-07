using System;
using System.Collections.Generic;
using System.Linq;
using WitsWay.TempTests.ControlsTest.Models;
using WitsWay.Utilities.Win.Extends;

namespace WitsWay.TempTests.ControlsTest.Temps
{
    public partial class XtraUserControl2 : DevExpress.XtraEditors.XtraUserControl
    {
        public XtraUserControl2()
        {
            InitializeComponent();//var rules = _gridView.FormatRules;
            //_gridView.FormatRules.AddIconSetRule(new GridColumn(), new FormatConditionIconSet(){});
            //_gridView.FormatRules.Add2ColorScale()

            bar2.SetStandaloneStyle();

            var modules = new List<Employee>
            {
                new Employee
                {
                   Age=10, BirthDay=DateTime.Now.AddYears(-10),EmployeeId=1,Name="张三",IsJoin = true,Remark="张三丰的后代",SortCode=11,School="儒家",Sex=Sex.Male,States=EmployeeStatus.Enable|EmployeeStatus.Confirmed
                }, 
                new Employee
                {
                   Age=20, BirthDay=DateTime.Now.AddYears(-20),EmployeeId=2,Name="孔四",IsJoin = false,Remark="孔夫子的后代",SortCode=12,School="儒家",Sex=Sex.Male,States=EmployeeStatus.Enable|EmployeeStatus.Confirmed
                },  
                new Employee
                {
                   Age=30, BirthDay=DateTime.Now.AddYears(-30),EmployeeId=3,Name="唐十三",IsJoin = true,Remark="唐太宗的后代",SortCode=13,School="道家",Sex=Sex.Male,States=EmployeeStatus.Enable|EmployeeStatus.Confirmed
                },  
                new Employee
                {
                   Age=40, BirthDay=DateTime.Now.AddYears(-40),EmployeeId=4,Name="叶不问",IsJoin = true,Remark="叶问的后代",SortCode=14,School="道家",Sex=Sex.Male,States=EmployeeStatus.Enable
                },  
                new Employee
                {
                   Age=50, BirthDay=DateTime.Now.AddYears(-50),EmployeeId=5,Name="秦大大",IsJoin = true,Remark="秦始皇的后代",SortCode=15,School="墨家",Sex=Sex.Female,States=EmployeeStatus.Enable|EmployeeStatus.Confirmed
                },
            };_gridControl.DataSource = modules;
            _gridView.SetStyle();
            _gridView.DrawRowIndicator();
            _gridControl.BindCopyToCtrlC();
            _gridView.OptionsMenu.EnableColumnMenu = true;
            _gridView.RowCheckBoxMultiSelect();

        }
        public enum Sex
        {
            Male,
            Female
        }

        public class Address
        {
            public string P1 { get; set; }
            public string P2 { get; set; }
        }

        public class User
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public Sex SexInfo { get; set; }

            private List<Address> _addressList = new List<Address>()
            {
                new Address(){P1="P1111",P2="P2222"},
                new Address(){P1="PPPP1",P2="PPPP2"}
            };

            public List<Address> AddressList
            {
                get
                {
                    return _addressList;
                }
                set { _addressList = value; }
            }
        }

        private void XtraUserControl2_Load(object sender, EventArgs e)
        {
            propertyGridControl1.SelectedObject = new User()
            {
                Name = "姓名",
                Age = 11,
                SexInfo = Sex.Female
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var user = propertyGridControl1.SelectedObject as User;

        }

        private void propertyGridControl1_CustomRecordCellEditForEditing(object sender,
            DevExpress.XtraVerticalGrid.Events.GetCustomRowCellEditEventArgs e)
        {


        }

        private void button2_Click(object sender, EventArgs e)
        {
            var rows = _gridView.GetSelectedRows();var selectEmps = rows.Where(row => row >= 0).Select(row => _gridView.GetRow(row) as Employee);
            gridControl1.DataSource = selectEmps;
            gridControl1.RefreshDataSource();
        }
    }
}
