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
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WitsWay.Utilities.Extends;
using WitsWay.Utilities.Web.Extends;
using WitsWay.Utilities.Web.Helpers;

namespace WitsWay.Utilities.Win.Helpers
{
    /// <summary>
    /// Http客户端辅助类
    /// </summary>
    public class HttpClientHelper
    {
        /// <summary>
        /// HttpClient实现Post请求String
        /// </summary>
        public static async Task<string> AsyncHttpPostRequestString(string postUrl, object contentEntity,Cookie cookie=null)
        {
            var handler = new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip
            };
            if (cookie != null)
            {
                var container = new CookieContainer();
                container.Add(cookie);
                handler.CookieContainer = container;
            }
            using (var http = new HttpClient(handler))
            {
                http.DefaultRequestHeaders.Add(@"KeepAlive", @"false");
                var param = contentEntity.PackJson();
                HttpContent contentPost = new StringContent(param, Encoding.UTF8, MimeTypeHelper.GetMimeType(MimeTypeEnum.Json));
                var response = await http.PostAsync(postUrl, contentPost);
                response.EnsureSuccessStatusCode();
                var strResult = await response.Content.ReadAsStringAsync();
                return strResult;
            }
        }

        /// <summary>
        /// HttpClient实现Post请求String
        /// </summary>
        public static string HttpPostRequestString(string postUrl, object contentEntity,Cookie cookie=null)
        {
            var handler = new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip };
            if(cookie!=null)
            {
                var container=new CookieContainer();
                container.Add(cookie);
                handler.CookieContainer = container;
            }
            using (var http = new HttpClient(handler))
            {
                http.DefaultRequestHeaders.Add(@"KeepAlive", @"false");
                var param = contentEntity.PackJson();
                HttpContent contentPost = new StringContent(param, Encoding.UTF8, MimeTypeHelper.GetMimeType(MimeTypeEnum.Json));
                return http.PostAsync(postUrl, contentPost).Result.Content.ReadAsStringAsync().Result;
            }
        }


        /// <summary>
        /// HttpClient实现Post请求Cookie
        /// </summary>
        public static async Task<List<Cookie>> AsyncHttpPostRequestCookies(string postUrl, object contentEntity,Cookie cookie=null)
        {
            var cookieContainer = new CookieContainer();
            var handler = new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip,
                CookieContainer = cookieContainer
            };
            using (var http = new HttpClient(handler))
            {
                http.DefaultRequestHeaders.Add(@"KeepAlive", @"false");
                var param = contentEntity.PackJson();
                HttpContent contentPost = new StringContent(param, Encoding.UTF8, MimeTypeHelper.GetMimeType(MimeTypeEnum.Json));
                var response = await http.PostAsync(postUrl, contentPost);
                response.EnsureSuccessStatusCode();
                return cookieContainer.GetAllCookies();
            }
        }

        /// <summary>
        /// HttpClient实现Post请求Cookie
        /// </summary>
        public static List<Cookie> HttpPostRequestCookies(string postUrl, object contentEntity)
        {
            var cookieContainer = new CookieContainer();
            var handler = new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip,
                CookieContainer = cookieContainer
            };
            using (var http = new HttpClient(handler))
            {
                http.DefaultRequestHeaders.Add(@"KeepAlive", @"false");
                var param = contentEntity.PackJson();
                HttpContent contentPost = new StringContent(param, Encoding.UTF8, MimeTypeHelper.GetMimeType(MimeTypeEnum.Json));
                var response = http.PostAsync(postUrl, contentPost).Result;
                response.EnsureSuccessStatusCode();
                return cookieContainer.GetAllCookies();
            }
        }

    }
}