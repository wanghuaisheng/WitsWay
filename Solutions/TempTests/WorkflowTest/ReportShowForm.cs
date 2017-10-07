using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using WitsWay.TempTests.ReportUtil;
using WitsWay.TempTests.WorkflowTest.Properties;
using WitsWay.Utilities.Attributes;

namespace WitsWay.TempTests.WorkflowTest
{
    public partial class ReportShowForm : DevExpress.XtraEditors.XtraForm
    {
        public ReportShowForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            TestForm tst = new TestForm();
            tst.ShowDialog(this);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            ImportConfig config = new ImportConfig();
            config.Key = Guid.NewGuid().ToString();
            config.ColumnConfig = new List<DataColumnConfig>()
            {
                new DataColumnConfig(){ColumnKey=1,ColumnName = "门店录入1",ColumnTag=ColumnTag.BarCode,Passed=true},
                new DataColumnConfig(){ColumnKey=2,ColumnName = "门店录入2",ColumnTag=ColumnTag.BarCode,Passed=true},
                new DataColumnConfig(){ColumnKey=3,ColumnName = "门店录入3",ColumnTag=ColumnTag.BarCode,Passed=true},
            };
            config.Name = "工作流表单";
            config.ReportContent = null;

            var ds = new DisplayDataSet("数据源");
            var dt = ds.Tables.Add();
            dt.TableName = "数据列";

            foreach (var column in config.ColumnConfig)
            {
                dt.Columns.Add(column.ColumnName, GetColumnType(column));
            }

            var row = dt.Rows.Add();
            foreach (DataColumn dataColumn in dt.Columns)
            {
                if (dataColumn.DataType == typeof(int))
                    row[dataColumn] = 100;
                else
                    row[dataColumn] = "字符串" + dataColumn.ColumnName;
            }

            var reportStream = config.ReportContent == null ? null : new MemoryStream(config.ReportContent);
            var reportName = string.IsNullOrWhiteSpace(config.Name) ? "标签模板" : config.Name;
            ReportDesignerHelper.ShowDesigner(reportStream, ds, ms => config.ReportContent = ms.ToArray(), reportName, FindForm());

            if (config.ReportContent == null)
            {
                XtraMessageBox.Show("报表模板未设置。");
                return;
            }
            var report = new XtraReport();
            report.DisplayName = "Report";

            try
            {
                report.LoadLayout(new MemoryStream(config.ReportContent));
            }
            catch
            {
                XtraMessageBox.Show("报表模板不正确，请重新设置报表模板");
                return;
            }
            report.DataSource = ds;

            SetReportWatermark(report);
            documentViewer1.DocumentSource = report;
            report.CreateDocument();
        }

        /// <summary>
        /// 设置报表水印
        /// </summary>
        /// <param name="report">报表</param>
        private static void SetReportWatermark(XtraReport report)
        {
            report.Watermark.Image = Resources.sheep;
            report.Watermark.ImageAlign = ContentAlignment.MiddleCenter;
            report.Watermark.ImageTiling = true;
            report.Watermark.ImageTransparency = 222;
            report.Watermark.ImageViewMode = DevExpress.XtraPrinting.Drawing.ImageViewMode.Clip;
        }

        private Type GetColumnType(DataColumnConfig column)
        {
            if (column.ColumnTag.HasFlag(ColumnTag.Length) || column.ColumnTag.HasFlag(ColumnTag.Width) || column.ColumnTag.HasFlag(ColumnTag.BarCode))
                return typeof(int);
            return typeof(string);
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            ImportConfig config = new ImportConfig();
            config.Key = Guid.NewGuid().ToString();
            config.ColumnConfig = new List<DataColumnConfig>()
            {
                new DataColumnConfig(){ColumnKey=1,ColumnName = "门店录入1",ColumnTag=ColumnTag.Material,Passed=true},
                new DataColumnConfig(){ColumnKey=2,ColumnName = "门店录入2",ColumnTag=ColumnTag.Material,Passed=true},
                new DataColumnConfig(){ColumnKey=3,ColumnName = "门店录入3",ColumnTag=ColumnTag.Material,Passed=true},
            };
            config.Name = "工作流表单";
            config.ReportContent = null;

            var ds = new DisplayDataSet("数据源");
            var dt = ds.Tables.Add();
            dt.TableName = "数据列";

            foreach (var column in config.ColumnConfig)
            {
                dt.Columns.Add(column.ColumnName, GetColumnType(column));
            }

            var row = dt.Rows.Add();

            row[config.ColumnConfig[0].ColumnName] = textEdit1.Text;
            row[config.ColumnConfig[1].ColumnName] = textEdit2.Text;
            row[config.ColumnConfig[2].ColumnName] = textEdit3.Text;
            var report = (XtraReport)documentViewer1.DocumentSource;
            report.DataSource = ds;
            report.CreateDocument();
            //report.Report.re
        }

    }

    /// <summary>
    /// 导入配置
    /// </summary>
    [Serializable]
    public class ImportConfig
    {
        /// <summary>
        /// 数据源键
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// 数据源名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 数据列配置
        /// </summary>
        public List<DataColumnConfig> ColumnConfig { get; set; }
        /// <summary>
        /// 报表
        /// </summary>
        public byte[] ReportContent { get; set; }

    }

    /// <summary>
    /// 数据列配置
    /// </summary>
    [Serializable]
    public class DataColumnConfig
    {
        /// <summary>
        /// 列标
        /// </summary>
        public int ColumnKey { get; set; }
        /// <summary>
        /// 列名
        /// </summary>
        public string ColumnName { get; set; }
        /// <summary>
        /// 列是否显示
        /// </summary>
        public bool Passed { get; set; }
        /// <summary>
        /// 列标签
        /// </summary>
        public ColumnTag ColumnTag { get; set; }

    }

    /// <summary>
    /// 列标签
    /// </summary>
    [Flags]
    [EnumField("列标签")]
    public enum ColumnTag
    {
        /// <summary>
        /// 条码
        /// </summary>
        [EnumField("条码")]
        BarCode = 1,
        /// <summary>
        /// 长度
        /// </summary>
        [EnumField("长度")]
        Length = 2,
        /// <summary>
        /// 宽度
        /// </summary>
        [EnumField("宽度")]
        Width = 4,
        /// <summary>
        /// 尺寸扣减
        /// </summary>
        [EnumField("尺寸扣减")]
        Deduce = 8,
        /// <summary>
        /// 原材料
        /// </summary>
        [EnumField("原材料")]
        Material = 16,

    }
}
