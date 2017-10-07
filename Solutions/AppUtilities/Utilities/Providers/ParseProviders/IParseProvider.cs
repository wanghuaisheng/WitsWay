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
namespace WitsWay.Utilities.Providers.ParseProviders
{
    /// <summary>
    /// 解析提供者接口
    /// </summary>
    public interface IParseProvider
    {
        /// <summary>
        /// 提供者名称
        /// </summary>
        string Name { get;}
        /// <summary>
        /// 封包对象
        /// </summary>
        /// <typeparam name="T">要封包的对象类型</typeparam>
        /// <param name="data">要封包的对象</param>
        /// <returns>封包后的string字符串</returns>
        string Pack<T>(T data);
        /// <summary>
        /// 解包对象
        /// </summary>
        /// <typeparam name="T">解包后的对象类型</typeparam>
        /// <param name="value">要解包的字符串</param>
        /// <returns>解包后的对象</returns>
        T Parse<T>(string value);
    }
}
