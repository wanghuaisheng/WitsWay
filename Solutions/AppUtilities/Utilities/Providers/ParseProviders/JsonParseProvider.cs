using WitsWay.Utilities.Helpers;

namespace WitsWay.Utilities.Providers.ParseProviders
{
    /// <summary>
    /// Json序列化提供者
    /// </summary>
    public class JsonParseProvider : IParseProvider
    {

        /// <summary>
        /// Json序列化提供者
        /// </summary>
        public static string ProviderName
        {
            get { return UtilityConsts.JsonParseProviderName; }
        }

        /// <summary>
        /// 打包
        /// </summary>
        public string Pack<T>(T data)
        {
            return SerilizeHelper.SerilizeToJson(data);
        }

        /// <summary>
        /// 解析
        /// </summary>
        public T Parse<T>(string value)
        {
            return SerilizeHelper.DeserilizeJson<T>(value); ;
        }

        /// <summary>
        /// Json序列化提供者
        /// </summary>
        public string Name
        {
            get { return ProviderName; }
        }

    }
}
