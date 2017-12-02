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
            get => _processedTimes;
            set => _processedTimes = value;
        }
        private DateTime _firstOperationFailTime = DateTime.Now;

        /// <summary>
        /// 第一次操作失败时间
        /// </summary>
        public DateTime FirstOperationFailTime
        {
            get => _firstOperationFailTime;
            set => _firstOperationFailTime = value;
        }
        private Guid _taskId;
        /// <summary>
        /// 获取或设置队列任务的全局唯一标识
        /// </summary>
        public Guid TaskId
        {
            get => _taskId;
            set => _taskId = value;
        }
        private int _queueType;

        /// <summary>
        /// 队列类型
        /// </summary>
        public int QueueType
        {
            get => _queueType;
            set => _queueType = value;
        }
    }
}
