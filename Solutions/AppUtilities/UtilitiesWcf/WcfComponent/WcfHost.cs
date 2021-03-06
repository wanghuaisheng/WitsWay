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
using System;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace WitsWay.Utilities.Wcf.WcfComponent
{
    /// <summary>
    /// WCF HOST通用范型类
    /// </summary>
    /// <typeparam name="TService">服务</typeparam>
    /// <typeparam name="TServiceContract">服务契约</typeparam>
    public class WCFHost<TService, TServiceContract> : ServiceHost
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="serviceAddresses">服务地址</param>
        public WCFHost(params Uri[] serviceAddresses)
            : base(typeof(TService), serviceAddresses)
        {
            for (var i = 0; i < serviceAddresses.Length; i++)
            {
                AddServiceEndpoint(typeof(TServiceContract), WcfHelper.GetBinding(serviceAddresses[i]), string.Empty);
            }
            //属性设置
            SetAttribute();
        }
        /// <summary>
        /// 构造单例模式的服务主机
        /// </summary>
        /// <param name="singletonInstance"></param>
        /// <param name="serviceAddresses"></param>
        public WCFHost(TService singletonInstance, params Uri[] serviceAddresses)
            : base(singletonInstance)
        {
            for (var i = 0; i < serviceAddresses.Length; i++)
            {
                AddServiceEndpoint(typeof(TServiceContract), WcfHelper.GetBinding(serviceAddresses[i]), serviceAddresses[i]);
            }
            //属性设置
            SetAttribute();
        }

        /// <summary>
        /// 设置属性
        /// </summary>
        private void SetAttribute()
        {
            //并发设置
            var sba = Description.Behaviors.Find<ServiceBehaviorAttribute>();
            if (sba == null)
            {
                sba = new ServiceBehaviorAttribute();
                
                Description.Behaviors.Add(sba);
            }
            sba.UseSynchronizationContext = false;

            //吞吐量设置
            var stb = Description.Behaviors.Find<ServiceThrottlingBehavior>();
            if (stb == null)
            {
                stb = new ServiceThrottlingBehavior();
                //var i = stb.MaxConcurrentSessions;
                Description.Behaviors.Add(stb);
            }
            stb.MaxConcurrentCalls = 1024;
            stb.MaxConcurrentInstances = 1024;
            stb.MaxConcurrentSessions = 1024;
        }

    }
}
