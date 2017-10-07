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
