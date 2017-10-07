using System;
using System.Data;
using System.IO;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;

namespace WitsWay.TempTests.ReportUtil
{
    public partial class TestForm : XtraForm
    {
        public TestForm()
        {
            InitializeComponent();
        }

        MemoryStream _ms;

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var ds = new DisplayDataSet("数据源", GetFieldDisplayName);
            ds.Tables.Add(GetTestData("tableName"));
            ds.Tables.Add(GetTestData("tableName2"));

            if (_ms == null)
            {
                var ms = new MemoryStream();
                var rep = new XtraReport();
                rep.DataSource = ds;
                rep.SaveLayout(ms);
                _ms = ms;
            }
            ReportDesignerHelper.ShowDesigner(_ms, ds, ms => _ms = ms);
        }

        /// <summary>
        /// 获取字段显示名称
        /// </summary>
        /// <param name="fieldAccessors">字段访问器</param>
        /// <returns></returns>
        public string GetFieldDisplayName(string[] fieldAccessors)
        {
            var fieldName = fieldAccessors[fieldAccessors.Length - 1];
            if (fieldName == "FirstName") { return "姓"; }
            else if (fieldName == "LastName") { return "名"; }
            else { return fieldName; }
        }

        private static DataTable GetTestData(string tableName)
        {
            var dtPerson = new DataTable(tableName);

            dtPerson.Columns.Add("PersonID");
            dtPerson.Columns.Add("LastName");
            dtPerson.Columns.Add("FirstName");

            dtPerson.Columns["PersonID"].AutoIncrement = true;
            dtPerson.Columns["PersonID"].AutoIncrementSeed = 1;
            dtPerson.Columns["PersonID"].AutoIncrementStep = 1;

            var dcKeys = new DataColumn[1];
            dcKeys[0] = dtPerson.Columns["PersonID"];
            dtPerson.PrimaryKey = dcKeys;

            dtPerson.Rows.Add(null, "Davolio", "Nancy");
            dtPerson.Rows.Add(null, "Fuller", "Andrew");
            dtPerson.Rows.Add(null, "Leverling", "Janet");
            dtPerson.Rows.Add(null, "Dodsworth", "Anne");
            dtPerson.Rows.Add(null, "Buchanan", "Steven");
            dtPerson.Rows.Add(null, "Suyama", "Michael");
            dtPerson.Rows.Add(null, "Callahan", "Laura");

            var dtJob = new DataTable(tableName + "Job");


            return dtPerson;

        }

        private static DataSet GetTestData2()
        {
            //先来建立ds数据库
            var ds = new DataSet("ds");
            //再来建立tbClass和tbBoard两个数据表
            var tbClass = new DataTable("tbClass");
            var tbBoard = new DataTable("tbBoard");
            //把两个数据表tbClass和tbBoard加入数据库
            ds.Tables.Add(tbClass);
            ds.Tables.Add(tbBoard);
            //建立tbClass两列
            var classId = new DataColumn("ClassID", typeof(String));
            var className = new DataColumn("ClassName", typeof(String));
            //设定ClassID列不允许为空
            classId.AllowDBNull = false;
            //把列加入tbClass表
            tbClass.Columns.Add(classId);
            tbClass.Columns.Add(className);
            //设定tdClass表的主键
            tbClass.PrimaryKey = new DataColumn[] { classId };
            //建立tbBoard的三列
            var boardId = new DataColumn("BoardID", typeof(String));
            var boardName = new DataColumn("BoardName", typeof(String));
            var boardClassId = new DataColumn("BoardClassID", typeof(String));
            //设定BoardID列不允许为空
            boardId.AllowDBNull = false;
            //把列加入tbBoard表
            tbBoard.Columns.Add(boardId);
            tbBoard.Columns.Add(boardName);
            tbBoard.Columns.Add(boardClassId);
            //设定tbBoard表的主键
            tbBoard.PrimaryKey = new DataColumn[] { boardId };
            // 为两个表各加入5条记录
            for (var i = 1; i <= 5; i++)
            {
                //实例化tbClass表的行
                var tbClassRow = tbClass.NewRow();
                //为行中每一列赋值
                tbClassRow["ClassID"] = Guid.NewGuid();
                tbClassRow["ClassName"] = string.Format("分类{0}", i);
                //把行加入tbClass表
                tbClass.Rows.Add(tbClassRow);
                //实例化tbBoard表的行
                var tbBoardRow = tbBoard.NewRow();
                //为行中每一列赋值
                tbBoardRow["BoardID"] = Guid.NewGuid();
                tbBoardRow["BoardName"] = string.Format("版块{0}", i);
                tbBoardRow["BoardclassID"] = tbClassRow["ClassID"];
                //把行加入tbBoard表
                tbBoard.Rows.Add(tbBoardRow);
            }

            //构建父子关系
            ds.Relations.Add("板块分类", classId, boardClassId);
            return ds;
        }

    }
}
