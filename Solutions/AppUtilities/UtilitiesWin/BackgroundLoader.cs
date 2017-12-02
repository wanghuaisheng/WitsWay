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

namespace WitsWay.Utilities.Win
{
    /// <summary>
    /// 后台加载
    /// </summary>
    public class BackgroundLoader
    {
        private readonly Action _action;
        private readonly Action _completedWork;
        private readonly BackgroundWorker _worker = new BackgroundWorker();
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="doWork">加载动作内容</param>
        /// <param name="completedWork">完成后内容</param>
        public BackgroundLoader(Action doWork, Action completedWork)
        {
            _action = doWork;
            _completedWork = completedWork;
            _worker.DoWork += bw_DoWork;
            _worker.RunWorkerCompleted += bw_RunWorkerCompleted;
            _worker.RunWorkerAsync();
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _completedWork?.Invoke();
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            _action?.Invoke();
        }
    }
}
