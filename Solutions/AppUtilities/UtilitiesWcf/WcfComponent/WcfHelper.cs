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
