using System;

namespace WitsWay.Utilities.Wcf.EngineServer
{
    /// <summary>
    /// 带消息体的队列任务消息类
    /// </summary>
    [Serializable]
    public class QueueTaskMessage<T> : QueueTaskMessageBase
    {
        /// <summary>
        /// 消息体
        /// </summary>
        private T _messageContent;
        /// <summary>
        /// 消息体
        /// </summary>
        public T MessageContent
        {
            get
            {
                return _messageContent;
            }
            set
            {
                _messageContent = value;
            }
        }

    }
}
