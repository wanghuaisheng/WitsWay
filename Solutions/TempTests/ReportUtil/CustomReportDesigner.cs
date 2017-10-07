using System;
using System.IO;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraBars.Docking2010.Views;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.UserDesigner;
using WitsWay.TempTests.ReportUtil.Properties;

namespace WitsWay.TempTests.ReportUtil
{
    public partial class CustomReportDesigner : RibbonForm
    {

        #region [Form]

        public CustomReportDesigner()
        {
            InitializeComponent();
            ShowIcon = true;
            Icon = Resources.ReportDesignerIcon;
            reportDesigner1.DesignPanelLoaded += new DesignerLoadedEventHandler(mdiController_DesignPanelLoaded);
        }

        private void CustomReportDesigner_Load(object sender, EventArgs e)
        {

        }

        private void CustomReportDesigner_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CancelCloseForm)
            {
                CancelCloseForm = false;
                e.Cancel = true;
            }
            else
            {
                SaveAction = null;
                _srcReport = null;
            }
        }

        #endregion

        #region [OpenReport]

        public static Action<MemoryStream> SaveAction;
        private static XtraReport _srcReport;
        public static bool CancelCloseForm;

        /// <summary>
        /// 打开报表
        /// </summary>
        /// <param name="srcReport">源报表</param>
        /// <param name="saveAction">保存方法</param>
        public void OpenReport(XtraReport srcReport, Action<MemoryStream> saveAction)
        {
            SaveAction = saveAction;
            _srcReport = srcReport;
            reportDesigner1.OpenReport(srcReport);
            InitCommandButton();
        }

        /// <summary>
        /// 初始化命令按钮
        /// </summary>
        private void InitCommandButton()
        {
            ActiveXrDesignPanel.SetCommandVisibility(ReportCommand.NewReportWizard, CommandVisibility.None);
            ActiveXrDesignPanel.SetCommandVisibility(ReportCommand.VerbReportWizard, CommandVisibility.None);
            ActiveXrDesignPanel.SetCommandVisibility(ReportCommand.NewReport, CommandVisibility.None);
            ActiveXrDesignPanel.SetCommandVisibility(ReportCommand.SaveAll, CommandVisibility.None);
            ActiveXrDesignPanel.SetCommandVisibility(ReportCommand.SaveFileAs, CommandVisibility.None);
            ActiveXrDesignPanel.SetCommandVisibility(ReportCommand.OpenFile, CommandVisibility.None);
        }

        /// <summary>
        /// 当前激活报表设计容器
        /// </summary>
        public XRDesignPanel ActiveXrDesignPanel
        {
            get { return reportDesigner1.ActiveDesignPanel; }
        }

        #endregion

        #region [SaveReport]

        void mdiController_DesignPanelLoaded(object sender, DesignerLoadedEventArgs e)
        {
            var panel = (XRDesignPanel)sender;
            reportDesigner1.AddCommandHandler(new SaveCommandHandler(panel));
            reportDesigner1.XtraTabbedMdiManager.DocumentActivate += XtraTabbedMdiManager_DocumentActivate;
        }

        void XtraTabbedMdiManager_DocumentActivate(object sender, DocumentEventArgs e)
        {
            e.Document.Properties.AllowClose = DefaultBoolean.False;
            e.Document.Properties.AllowFloat = DefaultBoolean.False;
        }

        public class SaveCommandHandler : ICommandHandler
        {
            XRDesignPanel _panel;

            public SaveCommandHandler(XRDesignPanel panel)
            {
                this._panel = panel;
            }

            public void HandleCommand(ReportCommand command, object[] args)
            {
                var saveReport = true;
                var exitDesigner = false;
                if (command == ReportCommand.Closing && _panel.ReportState == ReportState.Changed)
                {
                    //询问是否保存修改
                    var dr = XtraMessageBox.Show("报表已修改是否保存？", "确认", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    saveReport = dr == DialogResult.Yes;
                    exitDesigner = dr != DialogResult.Cancel;
                    if (!exitDesigner)
                    {
                        CancelCloseForm = true;
                    }
                    else if (saveReport)
                    {
                        Save();
                    }
                    else
                    {
                        CancelCloseForm = false;
                    }
                }
                else if (command != ReportCommand.Closing)
                {
                    Save();
                }

            }

            public bool CanHandleCommand(ReportCommand command, ref bool useNextHandler)
            {
                useNextHandler =
                    !(command == ReportCommand.SaveFile ||
                    command == ReportCommand.SaveFileAs ||
                    command == ReportCommand.Closing);
                return !useNextHandler;
            }

            /// <summary>
            /// 保存
            /// </summary>
            private void Save()
            {
                //自定义报表存储
                StoreReport(_panel.Report);
                //阻止“报表已修改”对话框弹出
                _panel.ReportState = ReportState.Saved;
            }


            private void StoreReport(XtraReport report)
            {
                var stream = new MemoryStream();
                report.SaveLayout(stream);
                if (_panel.ReportState == ReportState.Changed)
                {
                    SaveAction(stream);
                }
            }

        }

        #endregion


    }
}
