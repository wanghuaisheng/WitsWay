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
using System.Timers;

namespace WitsWay.Utilities.Wcf.EngineServer
{
    /// <summary>
    /// 定时任务
    /// </summary>
    public class TimingTask : IAutoTask
    {
        private readonly Timer _timer;
        /// <summary>
        /// 
        /// </summary>
        public double Interval
        {
            get
            {
                return _timer != null ? _timer.Interval : 0;
            }
            set
            {
                if (_timer != null)
                    _timer.Interval = value;

            }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool AutoReset
        {
            get
            {
                return _timer != null && _timer.AutoReset;
            }
            set
            {
                if (_timer != null)
                    _timer.AutoReset = value;
            }

        }
        /// <summary>
        /// 构造函数
        /// </summary>
        public TimingTask(double Interval, ElapsedEventHandler handler)
        {
            _timer = new Timer
            {
                AutoReset = true,
                Interval = Interval
            };
            //默认间隔执行
            _timer.Elapsed += handler;
        }

        #region IAutoTask Members

        /// <summary>
        /// 开始任务
        /// </summary>
        public void Start()
        {
            _timer.Start();
        }
        /// <summary>
        /// 停止任务
        /// </summary>
        public void Stop()
        {
            if (_timer == null)
                return;
            
            _timer.Stop();

        }

        #endregion
    }
}
