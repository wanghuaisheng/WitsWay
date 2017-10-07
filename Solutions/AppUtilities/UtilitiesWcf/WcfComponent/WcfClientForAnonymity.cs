using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Security;

namespace WitsWay.Utilities.Wcf.WcfComponent
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TServiceContract"></typeparam>
    public class WcfClientForAnonymity<TServiceContract> : WcfClient<TServiceContract> where TServiceContract : class
    {
        #region 继承基类的构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public WcfClientForAnonymity()
        {
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        public WcfClientForAnonymity(string endpointConfigurationName) :
            base(endpointConfigurationName)
        {
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        public WcfClientForAnonymity(string endpointConfigurationName, string remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
        {
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        public WcfClientForAnonymity(string endpointConfigurationName, EndpointAddress remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
        {
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        public WcfClientForAnonymity(Binding binding, EndpointAddress remoteAddress) :
            base(binding, remoteAddress)
        {
        }

        /// <summary>
        /// 根据远程地址采用无安全基本配置创建WCF代理
        /// </summary>
        /// <param name="serviceUri">服务URI地址</param>
        public WcfClientForAnonymity(Uri serviceUri)
            : base(serviceUri)
        {
        }
        #endregion


        /// <summary>
        /// 根据远程地址采用匿名安全模式创建WCF代理
        /// </summary>
        /// <param name="serviceEndPointUri">服务器地址</param>
        /// <param name="dnsIdentity">dns标识</param>
        public WcfClientForAnonymity(Uri serviceEndPointUri, string dnsIdentity)
            : base(serviceEndPointUri)
        {
            dnsIdentity = string.IsNullOrWhiteSpace(dnsIdentity) ? "MyServer" : dnsIdentity;
            switch (serviceEndPointUri.Scheme)
            {
                case "http":
                    var httpBinding = (WSHttpBinding)Endpoint.Binding;
                    httpBinding.Security.Mode = SecurityMode.Transport;
                    httpBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;
                    //设置允许的最大数组长度
                    httpBinding.ReaderQuotas.MaxArrayLength = 4 * 1024 * 1024;//4M
                    break;
                case "net.tcp":
                    var tcpBinding = (NetTcpBinding)Endpoint.Binding;
                    tcpBinding.Security.Mode = SecurityMode.Transport;
                    tcpBinding.Security.Transport.ClientCredentialType = TcpClientCredentialType.None;
                    //设置允许的最大数组长度
                    tcpBinding.ReaderQuotas.MaxArrayLength = 40 * 1024 * 1024;//4M
                    tcpBinding.ReaderQuotas.MaxBytesPerRead = 40 * 1024 * 1024;
                    tcpBinding.ReaderQuotas.MaxNameTableCharCount = 40 * 1024 * 1024;
                    tcpBinding.ReaderQuotas.MaxStringContentLength = 40 * 1024 * 1024;

                    tcpBinding.MaxBufferPoolSize = 40 * 1024 * 1024;
                    tcpBinding.MaxBufferSize = 40 * 1024 * 1024;
                    tcpBinding.MaxReceivedMessageSize = 40 * 1024 * 1024;


                    tcpBinding.TransactionFlow = true;//启用事务
                    break;
                default:
                    throw new Exception($"服务终结点地址类型错误({serviceEndPointUri})");
            }
            var endpointIdentity = EndpointIdentity.CreateDnsIdentity(dnsIdentity);
            Endpoint.Address = new EndpointAddress(serviceEndPointUri, endpointIdentity);

            if (ClientCredentials != null)
                ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode
                    = X509CertificateValidationMode.None;
        }

        /// <summary>
        /// 根据远程地址采用证书安全模式创建WCF代理
        /// </summary>
        /// <param name="addressWithDnsIdentity">带服务器证书的地址信息</param>        
        public WcfClientForAnonymity(AddressWithDnsIdentity addressWithDnsIdentity)
            : base(new Uri(addressWithDnsIdentity.ServiceEndPointUri))
        {
            switch (new Uri(addressWithDnsIdentity.ServiceEndPointUri).Scheme)
            {
                case "http":
                    var httpBinding = (WSHttpBinding)Endpoint.Binding;
                    httpBinding.Security.Mode = SecurityMode.Transport;
                    httpBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;
                    //设置允许的最大数组长度
                    httpBinding.ReaderQuotas.MaxArrayLength = 4 * 1024 * 1024;//4M
                    break;
                case "net.tcp":
                    var tcpBinding = (NetTcpBinding)Endpoint.Binding;
                    tcpBinding.Security.Mode = SecurityMode.None;
                    //tcpBinding.Security.Transport.ClientCredentialType = TcpClientCredentialType.None;
                    //设置允许的最大数组长度
                    tcpBinding.ReaderQuotas.MaxArrayLength = 40 * 1024 * 1024;
                    tcpBinding.ReaderQuotas.MaxBytesPerRead = 40 * 1024 * 1024;
                    tcpBinding.ReaderQuotas.MaxNameTableCharCount = 40 * 1024 * 1024;
                    tcpBinding.ReaderQuotas.MaxStringContentLength = 40 * 1024 * 1024;

                    tcpBinding.MaxBufferPoolSize = 40 * 1024 * 1024;
                    tcpBinding.MaxBufferSize = 40 * 1024 * 1024;
                    tcpBinding.MaxReceivedMessageSize = 40 * 1024 * 1024;



                    tcpBinding.TransactionFlow = true;//启用事务
                    tcpBinding.TransactionProtocol = TransactionProtocol.Default;
                    break;
                default:
                    throw new Exception($"服务终结点地址类型错误({addressWithDnsIdentity.ServiceEndPointUri})");
            }

            var endpointIdentity = EndpointIdentity.CreateDnsIdentity(addressWithDnsIdentity.DnsIdentity);
            //序列化配置修改 2013-12-30 Start
            foreach (var operationDescription in Endpoint.Contract.Operations)
            {
                var dcsob =
                    operationDescription.Behaviors.Find<DataContractSerializerOperationBehavior>();
                if (dcsob != null)
                {
                    dcsob.MaxItemsInObjectGraph = int.MaxValue;
                }
            }

            //序列化配置修改 2013-12-30 End
            Endpoint.Address = new EndpointAddress(new Uri(addressWithDnsIdentity.ServiceEndPointUri), endpointIdentity);


            //DataContractSerializerOperationBehavior bAttribute = new DataContractSerializerOperationBehavior();
            //bAttribute.MaxItemsInObjectGraph = int.MaxValue;



            //this.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode
            //    = System.ServiceModel.Security.X509CertificateValidationMode.None;
        }
    }
}

