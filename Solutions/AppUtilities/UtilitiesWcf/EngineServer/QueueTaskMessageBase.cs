using System;

namespace WitsWay.Utilities.Wcf.EngineServer
{
    /// <summary>
    /// 队列任务消息基类
    /// </summary>
    [Serializable]
    public class QueueTaskMessageBase
    {
        private int _processedTimes;

        /// <summary>
        /// 已处理次数
        /// </summary>
        public int ProcessedTimes
        {
            get { return _processedTimes; }
            set { _processedTimes = value; }
        }
        private DateTime _firstOperationFailTime = DateTime.Now;

        /// <summary>
        /// 第一次操作失败时间
        /// </summary>
        public DateTime FirstOperationFailTime
        {
            get { return _firstOperationFailTime; }
            set { _firstOperationFailTime = value; }
        }
        private Guid _taskId;
        /// <summary>
        /// 获取或设置队列任务的全局唯一标识
        /// </summary>
        public Guid TaskId
        {
            get { return _taskId; }
            set { _taskId = value; }
        }
        private int _queueType;

        /// <summary>
        /// 队列类型
        /// </summary>
        public int QueueType
        {
            get { return _queueType; }
            set { _queueType = value; }
        }
    }
}
