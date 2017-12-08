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
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;

namespace WitsWay.Utilities.Helpers
{

    /// <summary>
    /// Http请求类
    /// </summary>
    public class HttpRequestHelper
    {
        private static readonly CookieContainer MCookie = new CookieContainer();

        /// <summary>
        /// Http请求提交(提交数据使用UTF-8传送)
        /// </summary>
        /// <param name="url"></param>
        /// <param name="value"></param>
        /// <param name="isCatch">是否捕获到异常；true:捕获到异常</param>
        /// <param name="saveCookie">是否用一个容器来保存cookies默认不保存</param>
        /// <param name="requestType"></param>
        /// <param name="encodingName"></param>
        /// <param name="timeout">超时时间，以毫秒为单位</param>
        /// <param name="contentType"></param>
        /// <param name="referer"></param>
        /// <returns></returns>
        public static string HttpRequest(string url, string value, out bool isCatch, bool saveCookie = false, bool requestType = true, string encodingName = "Utf-8", int timeout = 120000, string contentType = "application/x-www-form-urlencoded", string referer = null)
        {
            string returnString = null;
            isCatch = false;
            try
            {
                //if (value == null) { value = string.Empty; }
                if (!requestType && !string.IsNullOrWhiteSpace(value))
                {
                    Uri currentUrl = new Uri(url);

                    if (currentUrl.Query != "")
                    {
                        url += "&" + value;
                    }
                    else
                    {
                        url += "?" + value;
                    }
                }
                #region 请求
                ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, chainsslPolicyErrors) => true;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Timeout = 120000;
                string method = requestType ? "POST" : "GET";
                request.Method = method;
                request.ContentType = contentType;
                request.Proxy = WebRequest.DefaultWebProxy;
                if (saveCookie)
                {
                    //创建一个容器来保存cookie
                    request.CookieContainer = MCookie;
                }

                request.Proxy.Credentials = CredentialCache.DefaultCredentials;
                if (referer != null)
                    request.Referer = referer;
                if (requestType)
                {
                    UTF8Encoding encoding = new UTF8Encoding();
                    byte[] data = encoding.GetBytes(value ?? string.Empty);
                    request.ContentLength = data.Length;
                    request.ServicePoint.Expect100Continue = false;
                    var sw = request.GetRequestStream();
                    sw.Write(data, 0, data.Length);
                    sw.Close();
                }

                #endregion

                #region 获取响应消息
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        Stream resStream = response.GetResponseStream();
                        if (resStream != null)
                        {
                            var streamReader = new StreamReader(resStream, Encoding.GetEncoding(encodingName));
                            returnString = streamReader.ReadToEnd();
                            streamReader.Close();
                        }
                        resStream?.Close();
                        //TODO Info

                        return returnString;
                    }
                    else
                    {
                        return response.StatusCode + "--" + response.StatusDescription;
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                var msg = $"网络请求异常：{ex.Message}";
                //TODO Error

                isCatch = true;
                return msg;
            }
        }

        /// <summary>
        /// 将实体转换成Post格式字符串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="kbm"></param>
        /// <param name="keyNameJoinStr">属性名与属性值连接字符串</param>
        /// <param name="splitStr">每组值的分割符</param>
        /// <returns></returns>
        public static string ConvertEntityToKvString<T>(T kbm, string keyNameJoinStr = "=", string splitStr = "&")
        {
            StringBuilder sb = new StringBuilder();
            Type t = typeof(T);
            PropertyInfo[] pros = t.GetProperties();
            for (int i = 0; i < pros.Length; i++)
            {
                if (i != 0)
                {
                    sb.Append(splitStr);
                }
                PropertyInfo pro = pros[i];
                sb.Append(pro.Name + keyNameJoinStr + pro.GetValue(kbm, null));
            }
            return sb.ToString();
        }
    }
}
