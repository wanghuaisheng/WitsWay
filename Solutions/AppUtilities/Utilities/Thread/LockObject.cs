using System;

namespace WitsWay.Utilities.Thread
{
    /// <summary>
    /// 锁对象
    /// </summary>
    public class LockObject
    {
        private volatile bool _initing;

        private readonly object _executeLock = new object();
        /// <summary>
        /// 锁定执行
        /// </summary>
        /// <param name="action">执行方法</param>
        public void LockExecute(Action action)
        {
            if (!_initing)
            {
                lock (_executeLock)
                {
                    if (_initing != true)
                    {
                        action();
                    }
                    _initing = true;
                }
            }
            _initing = false;
        }
    }

}
