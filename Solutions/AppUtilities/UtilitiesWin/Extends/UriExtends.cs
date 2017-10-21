using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using WitsWay.Utilities.Win.Helpers;

namespace WitsWay.Utilities.Win.Extends
{
    /// <summary>
    /// Uri扩展
    /// </summary>
    public static class UriExtends
    {
        /// <summary>
        /// Http Post Request String
        /// </summary>
        /// <param name="uri">地址</param>
        /// <param name="contentEntity">post实体</param>
        /// <param name="cookie">附带Cookie数据</param>
        /// <returns>请求结果</returns>
        public static string HttpPostRequestString(this Uri uri, object contentEntity, Cookie cookie = null)
        {
            return HttpClientHelper.HttpPostRequestString(uri.AbsoluteUri, contentEntity, cookie);
        }
        /// <summary>
        /// Http 异步 Post 请求 String
        /// </summary>
        /// <param name="uri">地址</param>
        /// <param name="contentEntity">post实体</param>
        /// <param name="cookie">附带Cookie数据</param>
        /// <returns>请求结果</returns>
        public static Task<string> AsyncHttpPostRequestString(this Uri uri, object contentEntity, Cookie cookie = null)
        {
            return HttpClientHelper.AsyncHttpPostRequestString(uri.AbsoluteUri, contentEntity, cookie);
        }
        /// <summary>
        /// Http Post Request Cookies
        /// </summary>
        /// <param name="uri">地址</param>
        /// <param name="contentEntity">post实体</param>
        /// <returns>请求结果</returns>
        public static List<Cookie> HttpPostRequestCookies(this Uri uri, object contentEntity)
        {
            return HttpClientHelper.HttpPostRequestCookies(uri.AbsoluteUri, contentEntity);
        }

        /// <summary>
        /// Http 异步 Post 请求 Cookies
        /// </summary>
        /// <param name="uri">地址</param>
        /// <param name="contentEntity">post实体</param>
        /// <returns><see cref="Cookie"/>列表</returns>
        public static Task<List<Cookie>> AsyncHttpPostRequestCookies(this Uri uri, object contentEntity)
        {
            return HttpClientHelper.AsyncHttpPostRequestCookies(uri.AbsoluteUri, contentEntity);
        }

    }
}
