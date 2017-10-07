using System;
using System.ComponentModel;

namespace WitsWay.Utilities.Win
{
    /// <summary>
    /// 后台加载
    /// </summary>
    public class BackgroundLoader
    {
        private Action _work;
        private Action _completedWork;
        private BackgroundWorker bw = new BackgroundWorker();
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="doWork">加载动作内容</param>
        /// <param name="completedWork">完成后内容</param>
        public BackgroundLoader(Action doWork,Action completedWork)
        {
            _work = doWork;
            _completedWork = completedWork;
            bw.DoWork += bw_DoWork;
            bw.RunWorkerCompleted += bw_RunWorkerCompleted;
           
            bw.RunWorkerAsync();
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (_completedWork == null)
                return;

            _completedWork();
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            if (_work == null)
                return;

            _work();
        }
    }
}
