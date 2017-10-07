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
using System.Collections.Generic;
using System.ServiceModel;

namespace WitsWay.Utilities.Wcf.EngineServer
{
    /// <summary>
    /// 引擎内核
    /// </summary>
    public abstract class EngineExecuteCore
    {
        /// <summary>
        /// 任务列表
        /// </summary>
        protected IList<IAutoTask> autoTaskList;
        /// <summary>
        /// 
        /// </summary>
        protected IList<ServiceHost> hostList;

        /// <summary>
        /// 构造函数
        /// </summary>
        protected EngineExecuteCore()
        {
            if (autoTaskList != null || hostList != null) return;
            autoTaskList = new List<IAutoTask>();
            hostList = new List<ServiceHost>();
            OnInitialization();
        }

        /// <summary>
        /// 开始执行内核
        /// </summary>
        public void Start()
        {
            OnStarting();

            #region 启动任务

            //启动自动任务
            foreach (var queueTask in autoTaskList)
            {
                queueTask.Start();
            }
            //启动托管服务
            foreach (var host in hostList)
            {
                if (host.State != CommunicationState.Opening || host.State != CommunicationState.Opened)
                {
                    OnHostStarting(host);
                    host.Open();
                }
            }

            #endregion

            OnStarted();
        }

        /// <summary>
        /// 停止执行内核
        /// </summary>
        public void Stop()
        {
            OnStopping();

            #region 停止任务

            //停止自动任务
            foreach (var autoTask in autoTaskList)
            {
                autoTask.Stop();
            }
            autoTaskList.Clear();
            //停止托管服务
            foreach (var host in hostList)
            {
                if (host.State == CommunicationState.Opening || host.State == CommunicationState.Opened)
                {
                    OnHostStoping(host);
                    host.Close();
                }
            }
            hostList.Clear();

            #endregion

            OnStopped();
        }

        /// <summary>
        /// 启动以前执行事件
        /// </summary>
        protected abstract void OnStarting();

        /// <summary>
        /// 启动后执行事件
        /// </summary>
        protected abstract void OnStarted();

        /// <summary>
        /// 停止前执行事件
        /// </summary>
        protected abstract void OnStopping();

        /// <summary>
        /// 停止后执行事件
        /// </summary>
        protected abstract void OnStopped();
        /// <summary>
        /// 宿主启动中
        /// </summary>
        protected virtual void OnHostStarting(ServiceHost host) { }
        /// <summary>
        /// 宿主停止中
        /// </summary>
        protected virtual void OnHostStoping(ServiceHost host) { }
        /// <summary>
        /// 初始化事件
        /// </summary>
        protected abstract void OnInitialization();

    }
}
