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
using WitsWay.Utilities.Errors;
using WitsWay.Utilities.Helpers;

namespace WitsWay.Utilities.Providers.ParseProviders
{
    /// <summary>
    /// 序列化提供者工厂
    /// </summary>
    public class ParserFactory
    {

        private static Dictionary<string, IParseProvider> _providers;
        //当前支持的所有提供者
        private static Dictionary<string, IParseProvider> Providers
        {
            get
            {
                if (_providers != null) return _providers;
                lock (typeof(ParserFactory))
                {
                    _providers = new Dictionary<string, IParseProvider>();
                    //Json
                    IParseProvider jsonProvider = new JsonParseProvider();
                    _providers[jsonProvider.Name] = jsonProvider;
                    //XML
                    IParseProvider xmlProvider = new XmlParseProvider();
                    _providers[xmlProvider.Name] = xmlProvider;
                }
                return _providers;
            }
        }

        /// <summary>
        /// 获取对应providerName的IParseProvider接口实例对象
        /// </summary>
        /// <param name="providerName">提供者名称</param>
        /// <param name="noParserThrow">不存在对应名称的解析器，true则抛出异常，false则返回null</param>
        /// <returns>对应providerName的IParseProvider接口实例对象</returns>
        public static IParseProvider GetParser(string providerName, bool noParserThrow = false)
        {
            if (noParserThrow && !Providers.ContainsKey(providerName))
                ExceptionHelper.ThrowProgramException(UtilityErrors.NotSupportParseProvider, providerName);
            return Providers.ContainsKey(providerName) ? Providers[providerName] : null;
        }
        /// <summary>
        /// Json解析器
        /// </summary>
        public static IParseProvider JsonParser
        {
            get
            {
                return Providers[JsonParseProvider.ProviderName];
            }
        }
        /// <summary>
        /// Xml解析器
        /// </summary>
        public static IParseProvider XmlParser
        {
            get
            {
                return Providers[XmlParseProvider.ProviderName];
            }
        }

    }
}
