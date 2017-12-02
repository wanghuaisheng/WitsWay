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
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using WitsWay.Utilities.Errors;
using WitsWay.Utilities.Helpers;
using WitsWay.Utilities.Web.Helpers;

namespace WitsWay.Utilities.Web.Extends
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

        /// <summary>
        /// 把图片Url转化成Image对象
        /// </summary>
        /// <param name="uri">图片Url</param>
        /// <param name="throwException">是否抛出异常
        /// <para>false则不抛出异常，异常发生时记录异常并返回null</para>
        /// <para>true则记录日志，并抛出异常</para>
        /// </param>
        /// <returns><see cref="Image"/>对象</returns>
        public static Image UriToImage(this Uri uri, bool throwException = false)
        {
            try
            {
                if (uri == null || string.IsNullOrEmpty(uri.AbsoluteUri)) return null;
                var webreq = WebRequest.Create(uri);
                var webres = webreq.GetResponse();
                var stream = webres.GetResponseStream();
                var image = Image.FromStream(stream);
                stream.Close();
                return image;
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
            if (throwException)
                ExceptionHelper.ThrowBusinessException(UtilityErrors.ResourceRequestFail, uri.AbsoluteUri);
            return null;
        }

        /// <summary>
        /// Http 异步 Post 执行
        /// </summary>
        /// <param name="uri">地址</param>
        /// <param name="cookie">附带Cookie数据</param>
        /// <returns>请求结果</returns>
        public static Task AsyncHttpExecute(this Uri uri, Cookie cookie = null)
        {
            return HttpClientHelper.AsyncHttpPostRequestString(uri.AbsoluteUri, null, cookie);
        }

    }

}
