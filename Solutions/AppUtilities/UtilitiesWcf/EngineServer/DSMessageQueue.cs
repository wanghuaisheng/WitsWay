using System;
using System.Messaging;
using System.Threading;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using WitsWay.Utilities.Errors;
using WitsWay.Utilities.Helpers;

namespace WitsWay.Utilities.Wcf.EngineServer
{
    /// <summary>
    /// 消息队列
    /// </summary>
    /// <typeparam name="T">泛型类</typeparam>
    public class DsMessageQueue<T>
    {
        private readonly string _queuePath;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="queuePath">队列路径</param>
        public DsMessageQueue(string queuePath)
        {
            _queuePath = queuePath;
        }

        /// <summary>
        /// 创建队列
        /// </summary>
        public void CreateQueue()
        {
            try
            {
                if (!MessageQueue.Exists(_queuePath)) MessageQueue.Create(_queuePath);
            }
            catch (MessageQueueException mexp)
            {
                ExceptionHelper.ThrowProgramException(UtilityErrors.MsmqQueueAccessError, mexp);
            }
            catch (Exception exp)
            {
                ExceptionHelper.ThrowProgramException(UtilityErrors.InternalProgramError, exp);
            }
        }

        /// <summary>
        /// 发送消息到队列
        /// </summary>
        /// <param name="obj">消息体</param>
        public void SendMessage(T obj)
        {
            try
            {
                //连接到队列
                var myQueue = new MessageQueue(_queuePath);
                var myMessage = new Message
                {
                    Body = obj,
                    Formatter = new BinaryMessageFormatter()
                };
                //发送消息到队列中
                myQueue.Send(myMessage);
            }
            catch (MessageQueueException mexp)
            {
                ExceptionHelper.ThrowProgramException(UtilityErrors.MsmqQueueAccessError, mexp);
            }
            catch (Exception exp)
            {
                ExceptionHelper.ThrowProgramException(UtilityErrors.InternalProgramError, exp);
            }
        }

        /// <summary>
        /// 从队列接收消息
        /// </summary>
        /// <returns></returns>
        public T ReceiveMessage()
        {
            //连接到队列
            var myQueue = new MessageQueue(_queuePath) { Formatter = new BinaryMessageFormatter() };
            try
            {
                //从队列中接收消息
                var myMessage = myQueue.Receive();
                //获取消息的内容
                return (myMessage != null) ? (T)myMessage.Body : default(T);
            }
            catch (MessageQueueException mexp)
            {
                var errText = UtilityErrors.MsmqQueueAccessError.GetErrorText();
                var msg =
                    $"消息队列路径:{_queuePath}\r\n异常类型:{errText}\r\n异常内容:{mexp}\r\n线程执行状况:{System.Threading.Thread.CurrentThread.ThreadState}";
                Logger.Write(msg);
                ExceptionHelper.ThrowProgramException(UtilityErrors.MsmqQueueAccessError, mexp);
            }
            catch (ThreadAbortException)
            {
                System.Threading.Thread.CurrentThread.Join();
                throw;
            }
            catch (Exception exp)
            {
                var errText = UtilityErrors.InternalProgramError.GetErrorText();
                var msg =
                    $"消息队列路径:{_queuePath}\r\n异常类型:{errText}\r\n异常内容:{exp}\r\n线程执行状况:{System.Threading.Thread.CurrentThread.ThreadState}";
                Logger.Write(msg);
                ExceptionHelper.ThrowProgramException(UtilityErrors.InternalProgramError, exp);
            }
            return default(T);
        }
    }
}
