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
using System.ServiceModel.Channels;

namespace WitsWay.Utilities.Wcf.WcfComponent
{
    /// <summary>
    /// Wcf范型通用代理类
    /// </summary>
    /// <typeparam name="TServiceContract">服务契约</typeparam>
    public class WcfClient<TServiceContract> : ClientBase<TServiceContract> where TServiceContract : class
    {
        #region 继承基类的构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public WcfClient()
        {
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        public WcfClient(string endpointConfigurationName) :
            base(endpointConfigurationName)
        {
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        public WcfClient(string endpointConfigurationName, string remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
        {
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        public WcfClient(string endpointConfigurationName, EndpointAddress remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
        {
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        public WcfClient(Binding binding, EndpointAddress remoteAddress) :
            base(binding, remoteAddress)
        {
        }
        #endregion

        #region 扩展的构造函数

        /// <summary>
        /// 根据远程地址采用无安全基本配置创建WCF代理
        /// </summary>
        /// <param name="serviceUri">服务URI地址</param>
        public WcfClient(Uri serviceUri)
            : base(WcfHelper.GetBinding(serviceUri), new EndpointAddress(serviceUri.AbsoluteUri))
        {
        }
        /// <summary>
        /// 根据远程地址和DNS名称采用基本配置创建WCF代理
        /// </summary>
        /// <param name="serviceUri">服务URI地址</param>
        /// <param name="dnsName">服务DNS名称，带安全时设置后才有效</param>
        public WcfClient(Uri serviceUri, string dnsName)
            : base(WcfHelper.GetBinding(serviceUri), new EndpointAddress(serviceUri, EndpointIdentity.CreateDnsIdentity(dnsName)))
        {

        }

        #endregion

        /// <summary>
        /// 获取用于调用服务的服务契约接口
        /// </summary>
        public TServiceContract ServiceContract => Channel;
    }
}
