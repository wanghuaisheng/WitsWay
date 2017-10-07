using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;

namespace WitsWay.TempTests.ReportUtil
{

    /// <summary>
    /// 报表设计器辅助类
    /// </summary>
    public class ReportDesignerHelper
    {
        /// <summary>
        /// 显示设计器
        /// </summary>
        /// <param name="reportStream">报表文件内存流</param>
        /// <param name="ds">DataSet数据集，包含结构定义，和测试数据，结构定义用于报表设计，测试数据用于报表预览。</param>
        /// <param name="saveAction">保存行为</param>
        /// <param name="reportDisplayName">报表显示名称</param>
        /// <param name="parentForm">父窗体</param>
        public static void ShowDesigner(MemoryStream reportStream, DataSet ds, Action<MemoryStream> saveAction, string reportDisplayName = null, Form parentForm = null)
        {
            var report = new XtraReport();
            report.DisplayName = string.IsNullOrWhiteSpace(reportDisplayName) ? "报表" : reportDisplayName;
            if (reportStream != null)
            {
                try
                {
                    report.LoadLayout(reportStream);
                }
                catch
                {
                    XtraMessageBox.Show("报表模板不正确，请重新设置报表模板");
                    return;
                }
            }
            report.DataSource = ds;
            // report.DataMember = "Report";
            var frm = new CustomReportDesigner();
            frm.OpenReport(report, saveAction);
            frm.ShowDialog(parentForm);
        }

        /// <summary>
        /// 显示报表预览
        /// </summary>
        /// <param name="reportStream">报表流</param>
        /// <param name="ds">数据集</param>
        public static void ShowPreview(MemoryStream reportStream, DataSet ds)
        {
            if (reportStream == null)
            {
                XtraMessageBox.Show("报表模板未设置。");
                return;
            }
            var report = new XtraReport();
            report.DisplayName = "Report";

            try
            {
                report.LoadLayout(reportStream);
            }
            catch
            {
                XtraMessageBox.Show("报表模板不正确，请重新设置报表模板");
                return;
            }
            report.DataSource = ds;
            report.ShowPreviewDialog();
        }

        /// <summary>
        /// 打印报表
        /// </summary>
        /// <param name="reportStream">报表流</param>
        /// <param name="ds">数据集</param>
        /// <param name="printerName">打印机名称</param>
        public static void Print(MemoryStream reportStream, DataSet ds, string printerName)
        {
            if (reportStream == null)
            {
                XtraMessageBox.Show("报表模板未设置。");
                return;
            }
            var report = new XtraReport();
            report.DisplayName = "Report";
            try
            {
                report.LoadLayout(reportStream);
            }
            catch
            {
                XtraMessageBox.Show("报表模板不正确，请重新设置报表模板");
                return;
            }
            report.DataSource = ds;
            try
            {
                report.Print(printerName);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }


    }
}
