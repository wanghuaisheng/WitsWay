#region License(Apache Version 2.0)
/******************************************
 * Copyright ®2017-Now WangHuaiSheng.
 * Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file
 * except in compliance with the License. You may obtain a copy of the License at
 * http://www.apache.org/licenses/LICENSE-2.0
 * Unless required by applicable law or agreed to in writing, software distributed under the
 * License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
 * either express or implied. See the License for the specific language governing permissions
 * and limitations under the License.
 * Detail: https://github.com/WangHuaiSheng/WitsWay/LICENSE
 * ***************************************/
#endregion 
#region ChangeLog
/******************************************
 * 2017-10-7 OutMan Create
 * 
 * ***************************************/
#endregion
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace WitsWay.Utilities.Win.Controls
{
    /// <summary>
    /// 加载窗体
    /// </summary>
    public partial class SplashForm : XtraForm
    {
        private readonly Action _work;
        /// <summary>
        /// 加载窗体
        /// </summary>
        /// <param name="work"></param>
        /// <param name="icon">窗体图标</param>
        public SplashForm(Action work,Icon icon=null)
        {
            InitializeComponent();
            _work = work;
            Icon = icon;
            InitControl();
        }

        private void InitControl()
        {
            //ControlStyleHelper.SetLoadingCircle(_loadingCircle);
            //_loadingCircle.Parent = _picBG;
            _lblMsg.Parent = _picBG;
        }

        private void SplashForm_Load(object sender, EventArgs e)
        {
            SplashNotice.SplashNoticeMsg += msg => {
                MethodInvoker invoker = delegate {
                    _lblMsg.Text = msg;
                };
                Invoke(invoker);
            };
            var worker = new BackgroundWorker();
            worker.RunWorkerCompleted += (s1, e1) => {
                MethodInvoker invoker = SplashNotice.OnFinishWork;
                Invoke(invoker);
            };
            worker.DoWork += worker_DoWork;
            worker.RunWorkerAsync();
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            _work?.Invoke();
        }
    }
}
