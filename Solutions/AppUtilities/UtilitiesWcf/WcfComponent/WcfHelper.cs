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
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace WitsWay.Utilities.Wcf.WcfComponent
{
    /// <summary>
    /// WCF公共工具类方法
    /// </summary>
    public static class WcfHelper
    {
        /// <summary>
        /// 根据serviceUri地址生成相应的Binding对象
        /// </summary>
        /// <param name="serviceUri"></param>
        /// <returns>返回包含绑定元素，这些元素指定客户端和服务之间的通信所用的协议、传输和消息编码器。</returns>
        public static Binding GetBinding(Uri serviceUri)
        {
            Binding binding;
            switch (serviceUri.Scheme)
            {
                case "net.tcp":
                    binding = new NetTcpBinding(SecurityMode.None);
                                      
                    break;
                case "http":
                    binding = new WSHttpBinding(SecurityMode.None);
                    break;
                default:
                    throw new Exception("远程地址错误，不能创建代理。");
            }
            return binding;
        }
        /// <summary>
        /// 根据serviceUri地址生成相应的Binding对象
        /// </summary>
        /// <param name="serviceUri"></param>
        /// <returns></returns>
        public static Binding GetBinding(string serviceUri)
        {
            return GetBinding(new Uri(serviceUri));
        }
    }
}
