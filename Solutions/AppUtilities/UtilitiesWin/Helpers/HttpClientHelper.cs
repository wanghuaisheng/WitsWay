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