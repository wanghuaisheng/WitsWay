﻿#region License(Apache Version 2.0)
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
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;

namespace WitsWay.Utilities.Win.Controls
{
    /// <summary>
    /// 加载窗体
    /// </summary>
    public partial class SplashForm2 : DemoSplashScreen
    {
        private Action work;
        private bool notify;
        /// <summary>
        /// 加载窗体
        /// </summary>
        /// <param name="work">后台任务</param>
        /// <param name="acceptNotify">是否接受通知</param>
        public SplashForm2(Action work, bool acceptNotify)
        {
            InitializeComponent();
            labelControl1.Text = string.Empty;
            //this.pictureEdit1.Image = null;
            //this.pictureEdit1.Visible = false;
            this.Icon = null;
            this.work = work;
            notify = acceptNotify;
        }
        /// <summary>
        /// 初始化窗体
        /// </summary>
        /// <param name="icon">窗体图标</param>
        /// <param name="productImg">产品图片</param>
        /// <param name="corpImg">企业图片</param>
        /// <param name="copyright">版权</param>
        /// <param name="loadText">加载文字</param>
        public void InitForm(Icon icon, Bitmap productImg = null, Bitmap corpImg = null, string copyright = null, string loadText = "启动中，请稍后…")
        {
            if (icon != null)
            {
                this.Icon = icon;
            }
            if (productImg != null)
            {
                this.pictureEdit2.Image = productImg;
            }
            if (corpImg != null)
            {
                this.pictureEdit1.Image = corpImg;
            }
            labelControl1.Text = string.IsNullOrWhiteSpace(copyright) ?
                $"Copyright © 2012-{GetYear()}"
                :
                copyright;
            labelControl2.Text = loadText;
        }

        /// <summary>
        /// 获取年份
        /// </summary>
        /// <returns>年份</returns>
        private int GetYear()
        {
            var ret = DateTime.Now.Year;
            return (ret < 2013 ? 2013 : ret);
        }

        private Stopwatch watch = new Stopwatch();

        private void SplashForm_Load(object sender, EventArgs e)
        {

            if (notify)
            {
                SplashNotice.SplashNoticeMsg += msg =>
                {
                    MethodInvoker invoker = delegate {
                        labelControl2.Text = msg;
                    };
                    this.Invoke(invoker);
                };
            }
            if (work != null)
            {
                watch.Reset();
                watch.Start();
                var worker = new BackgroundWorker();
                worker.RunWorkerCompleted += (s1, e1) =>
                {
                    MethodInvoker invoker = delegate {
                        SplashNotice.OnFinishWork();
                    };
                    this.Invoke(invoker);
                };
                worker.DoWork += worker_DoWork;
                worker.RunWorkerAsync();
            }
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (work != null)
            {
                work();

            }
            watch.Stop();
            if (watch.ElapsedMilliseconds < 1000)
            {
                System.Threading.Thread.Sleep(1000);
            }
        }
    }
}
