using WitsWay.Utilities.Helpers;

namespace WitsWay.Utilities.Providers.ParseProviders
{
    /// <summary>
    /// Xml序列化提供者
    /// </summary>
    public class XmlParseProvider : IParseProvider
    {

        /// <summary>
        /// Xml序列化提供者
        /// </summary>
        public static string ProviderName
        {
            get { return UtilityConsts.XmlParseProviderName; }
        }

        /// <summary>
        /// 打包
        /// </summary>
        public string Pack<T>(T data)
        {
            return SerilizeHelper.SerilizeToXML(data);
        }

        /// <summary>
        /// 解析
        /// </summary>
        public T Parse<T>(string value)
        {
            return SerilizeHelper.DeserilizeXML<T>(value);
        }

        /// <summary>
        /// Xml序列化提供者
        /// </summary>
        public string Name
        {
            get { return ProviderName; }
        }
    }
}
