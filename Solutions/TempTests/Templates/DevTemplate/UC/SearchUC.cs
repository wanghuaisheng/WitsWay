using System;
using DevExpress.XtraEditors;

namespace WitsWay.WinTemplate.UC
{
    public partial class SearchUc : XtraUserControl
    {
        public SearchUc()
        {
            InitializeComponent();
        }

        private void SearchControlUC_Load(object sender, EventArgs e)
        {

        }
        
        /// <summary>
        /// 配置键
        /// </summary>
        public string ConfigKey { get; }
        
    }
}
