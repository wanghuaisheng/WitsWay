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
using System.Threading;

namespace WitsWay.Utilities.Wcf.EngineServer
{
    /// <summary>
    /// 队列处理器抽象类
    /// </summary>
    public abstract class QueueHandler : IAutoTask
    {
        private Semaphore _bizSemaphore = new Semaphore(1, 1);
        private System.Threading.Thread monitorThread;
        private string queuePath;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="QueuePath">队列路径</param>
        public QueueHandler(string QueuePath)
        {
            queuePath = QueuePath;
        }

        /// <summary>
        /// 监控队列
        /// </summary>
        private void Run()
        {
            while (true)
            {
                //接收消息队列
                var message =
                    new DsMessageQueue<QueueTaskMessageBase>(queuePath).ReceiveMessage();
                if (message != null)
                {
                    _bizSemaphore.WaitOne();
                    //把任务交给线程池处理
                    ThreadPool.QueueUserWorkItem(ProcessQueueMessage, message);
                }
            }
        }

        /// <summary>
        /// 自定义处理队列消息
        /// </summary>
        /// <param name="message">队列消息</param>
        protected abstract void CustomProcessQueueMessage(object message);

        /// <summary>
        /// 处理队列消息
        /// </summary>
        /// <param name="message">队列消息</param>
        private void ProcessQueueMessage(object message)
        {
            //已处理次数加1
            var taskMessage = (QueueTaskMessageBase)message;
            taskMessage.ProcessedTimes += 1;
            //自定义处理方法
            CustomProcessQueueMessage(message);
            //释放信号量
            if (!_bizSemaphore.SafeWaitHandle.IsClosed)
                _bizSemaphore.Release();



        }



        #region IAutoTask Members

        /// <summary>
        /// 开始任务
        /// </summary>
        public void Start()
        {
            monitorThread = new System.Threading.Thread(Run);
            monitorThread.IsBackground = true;
            monitorThread.Start();
        }
        /// <summary>
        /// 停止任务
        /// </summary>
        public void Stop()
        {
            if (monitorThread != null && monitorThread.IsAlive)
                monitorThread.Abort();
            if (_bizSemaphore != null)
                _bizSemaphore.Close();
        }

        #endregion
    }
}
