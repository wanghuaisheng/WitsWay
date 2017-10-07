using System;

namespace WitsWay.Utilities.Wcf
{
    /// <summary>
    /// 基于服务器证书DNS的地址信息
    /// </summary>
    [Serializable]
    public class AddressWithDnsIdentity
    {
        private string _serviceEndPointUri;

        /// <summary>
        /// 服务终节点地址
        /// </summary>
        public string ServiceEndPointUri
        {
            get { return _serviceEndPointUri; }
            set { _serviceEndPointUri = value; }
        }
        private string _dnsIdentity;

        /// <summary>
        /// Dns标识
        /// </summary>
        public string DnsIdentity
        {
            get { return _dnsIdentity; }
            set { _dnsIdentity = value; }
        }
    }
}
