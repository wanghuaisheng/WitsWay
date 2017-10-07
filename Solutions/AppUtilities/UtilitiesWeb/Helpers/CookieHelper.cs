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
using System.Collections.Specialized;
using System.Web;

namespace WitsWay.Utilities.Web.Helpers
{
	/// <summary>
	/// Cookies辅助类
	/// </summary>
	public static class CookieHelper
    {

        #region [Exists]

        /// <summary>
		/// 检查是否存在Cookie
		/// </summary>
		/// <param name="httpContext">Http请求上下文</param>
		/// <param name="cookieName">CooKie名称</param>
		/// <returns>存在true，不存在false</returns>
		public static bool Exists(HttpContext httpContext, string cookieName)
		{
            if (httpContext == null) throw new ArgumentException("httpContext");
			if (string.IsNullOrEmpty(cookieName)) throw new ArgumentException("name");
            return (httpContext.Request.Cookies[cookieName] != null);
		}

        #endregion

        #region [Create]

        /// <summary>
        /// 创建Cookie，未保存到Response响应流
		/// </summary>
		/// <param name="cookieName"></param>
		/// <returns></returns>
		public static HttpCookie Create(string cookieName)
		{
            if (string.IsNullOrEmpty(cookieName)) throw new ArgumentException("cookieName");

			var cookie = new HttpCookie(cookieName);
			return cookie;
		}


		/// <summary>
        /// 创建Cookie，未保存到Response响应流
		/// </summary>
		/// <param name="cookieName"></param>
		/// <param name="cookieValue"></param>
		/// <returns></returns>
		public static HttpCookie Create(string cookieName, string cookieValue)
		{
			var cookie = Create(cookieName);
			cookie.Value = cookieValue;
			return cookie;
		}


		/// <summary>
        /// 创建Cookie，未保存到Response响应流
		/// </summary>
		/// <param name="cookieName"></param>
		/// <param name="cookieValues"></param>
		/// <returns></returns>
		public static HttpCookie Create(string cookieName, NameValueCollection cookieValues)
		{
			var cookie = Create(cookieName);
			foreach (string name in cookieValues)
			{
				cookie[name] = cookieValues[name];
			}
			return cookie;
		}

		#endregion

		#region [Save]

		/// <summary>
		/// 保存Cookie到Response响应流
		/// </summary>
		/// <param name="httpContext"></param>
		/// <param name="cookieToSave"></param>
		public static void Save(HttpContext httpContext, HttpCookie cookieToSave)
		{
            if (httpContext == null) { throw new ArgumentException("httpContext"); }
            if (cookieToSave == null) { throw new ArgumentException("cookieToSave"); }
            httpContext.Response.Cookies.Add(cookieToSave);
		}


		/// <summary>
        /// 保存Cookie到Response响应流
		/// </summary>
		/// <param name="httpContext"></param>
		/// <param name="cookieToSave"></param>
		/// <param name="expires"></param>
		public static void Save(HttpContext httpContext, HttpCookie cookieToSave, DateTime expires)
		{
            if (httpContext == null) { throw new ArgumentException("httpContext"); }
            if (cookieToSave == null) { throw new ArgumentException("cookieToSave"); }
			cookieToSave.Expires = expires;
			httpContext.Response.Cookies.Add(cookieToSave);
		}

		#endregion

		#region [CreateAndSave]

		/// <summary>
		/// 创建并保存Cookie到响应流
		/// </summary>
		/// <param name="httpContext"></param>
		/// <param name="cookieName"></param>
		/// <returns></returns>
		public static HttpCookie CreateAndSave(HttpContext httpContext, string cookieName)
		{
			var cookie = Create(cookieName);
			Save(httpContext, cookie);
			return cookie;
		}


		/// <summary>
        ///创建并保存Cookie到响应流，100年过期
		/// </summary>
		/// <param name="httpContext"></param>
		/// <param name="cookieName"></param>
		/// <param name="cookieValue"></param>
		/// <returns></returns>
		public static HttpCookie CreateAndSave(HttpContext httpContext, string cookieName, string cookieValue)
		{
			var cookie = Create(cookieName, cookieValue);
			Save(httpContext, cookie);
			return cookie;
		}


		/// <summary>
        /// 创建并保存Cookie到响应流
		/// </summary>
		/// <param name="httpContext"></param>
		/// <param name="cookieName"></param>
		/// <param name="cookieValue"></param>
		/// <param name="expires"></param>
		/// <returns></returns>
		public static HttpCookie CreateAndSave(HttpContext httpContext, string cookieName, string cookieValue, DateTime expires)
		{
			var cookie = Create(cookieName, cookieValue);
			Save(httpContext, cookie, expires);
			return cookie;
		}

		/// <summary>
        ///创建并保存Cookie到响应流，100年过期
		/// </summary>
		/// <param name="httpContext"></param>
		/// <param name="cookieName"></param>
		/// <param name="cookieValues"></param>
		/// <returns></returns>
		public static HttpCookie CreateAndSave(HttpContext httpContext, string cookieName, NameValueCollection cookieValues)
		{
			var cookie = Create(cookieName, cookieValues);
			Save(httpContext, cookie);
			return cookie;
		}

		/// <summary>
        /// 创建并保存Cookie到响应流
		/// </summary>
		/// <param name="httpContext"></param>
		/// <param name="cookieName"></param>
		/// <param name="cookieValues"></param>
		/// <param name="expires"></param>
		/// <returns></returns>
		public static HttpCookie CreateAndSave(HttpContext httpContext, string cookieName, NameValueCollection cookieValues, DateTime expires)
		{
			var cookie = Create(cookieName, cookieValues);
			Save(httpContext, cookie, expires);
			return cookie;
		}

		#endregion

		#region [Expire]

		/// <summary>
		/// 过期Cookie，并写入当前响应流
		/// </summary>
		/// <param name="httpContext"></param>
		/// <param name="cookieToExpire"></param>
        public static void Expire(HttpContext httpContext, HttpCookie cookieToExpire)
        {
            if (httpContext == null)
            {
                throw new ArgumentException("httpContext");
            }
            if (cookieToExpire == null)
            {
                throw new ArgumentException("cookieToExpire");
            }
            Save(httpContext, cookieToExpire, DateTime.Now.AddDays(-1));
        }


		/// <summary>
        /// 过期Cookie，并写入当前响应流
		/// </summary>
        /// <param name="httpContext"></param>
		/// <param name="cookieName"></param>
		public static void Expire(HttpContext httpContext, string cookieName)
		{
            if (httpContext == null) throw new ArgumentException("httpContext");
            if (string.IsNullOrEmpty(cookieName)) throw new ArgumentException("cookieName");
            if (Exists(httpContext, cookieName))
			{
                Expire(httpContext, httpContext.Request.Cookies[cookieName]);
			}
		}

		#endregion

		#region [SetValue]

		/// <summary>
		/// 设置Cookie值
		/// </summary>
		/// <param name="httpContext"></param>
		/// <param name="cookieName"></param>
		/// <param name="cookieValue"></param>
		public static void SetValue(HttpContext httpContext, string cookieName, string cookieValue)
		{
            if (httpContext == null) throw new ArgumentException("httpContext");
            if (string.IsNullOrEmpty(cookieName)) throw new ArgumentException("cookieName");
            if (string.IsNullOrEmpty(cookieValue)) throw new ArgumentException("cookieValue");

			if (Exists(httpContext, cookieName))
			{
				httpContext.Request.Cookies[cookieName].Value = cookieValue;
			}
		}

		/// <summary>
        /// 设置Cookie值
		/// </summary>
		/// <param name="cookie"></param>
		/// <param name="cookieValue"></param>
		public static void SetValue(HttpCookie cookie, string cookieValue)
		{
            if (cookie == null)
            {
                throw new ArgumentException("cookie");
            }
            if (string.IsNullOrEmpty(cookieValue))
            {
                throw new ArgumentException("cookieValue");
            }
			cookie.Value = cookieValue;
		}

		/// <summary>
        /// 设置Cookie值
		/// </summary>
		/// <param name="httpContext"></param>
		/// <param name="name"></param>
		/// <param name="key"></param>
		/// <param name="value"></param>
		public static void SetKeyValue(HttpContext httpContext, String name, String key, String value)
		{
			if (httpContext == null) throw new ArgumentException("currentContext");
			if (string.IsNullOrEmpty(name)) throw new ArgumentException("name");
			if (string.IsNullOrEmpty(key)) throw new ArgumentException("key");
			if (string.IsNullOrEmpty(value)) throw new ArgumentException("value");

			if (Exists(httpContext, name))
			{
				httpContext.Request.Cookies[name].Values.Set(key, value);
			}
		}

		/// <summary>
        /// 设置Cookie值
		/// </summary>
		/// <param name="cookie"></param>
		/// <param name="key"></param>
		/// <param name="value"></param>
		public static void SetKeyValue(HttpCookie cookie, string key, string value)
		{
            if (cookie == null) { throw new ArgumentException("cookie"); }
            if (string.IsNullOrEmpty(key)) { throw new ArgumentException("key"); }
            if (string.IsNullOrEmpty(value)) { throw new ArgumentException("value"); }
			cookie.Values.Set(key, value);
		}

        #endregion

        #region [GetValue]

        /// <summary>
		/// 获取Cookie值
		/// </summary>
		/// <param name="httpContext"></param>
		/// <param name="cookieName"></param>
		/// <returns></returns>
		public static string GetValue(HttpContext httpContext, string cookieName)
		{
            if (httpContext == null)
            {
                throw new ArgumentException("httpContext"); 
            }
            if (string.IsNullOrEmpty(cookieName))
            {
                throw new ArgumentException("cookieName");
            }
			var value = string.Empty;
			if (Exists(httpContext, cookieName))
			{
				value = httpContext.Request.Cookies[cookieName].Value;
			}
			return value;
		}

		/// <summary>
        /// 获取Cookie值
		/// </summary>
		/// <param name="cookie"></param>
		/// <returns></returns>
		public static string GetValue(HttpCookie cookie)
		{
            if (cookie == null)
            {
                throw new ArgumentException("cookie");
            }
			return cookie.Value;
		}

		/// <summary>
		/// 获取Cookie值集合
		/// </summary>
		/// <param name="httpContext"></param>
		/// <param name="cookieName"></param>
		/// <returns></returns>
		public static NameValueCollection GetValues(HttpContext httpContext, string cookieName)
		{
            if (httpContext == null)
            {
                throw new ArgumentException("httpContext");
            }
            if (string.IsNullOrEmpty(cookieName))
            {
                throw new ArgumentException("cookieName");
            }
			var values = new NameValueCollection();
			if (Exists(httpContext, cookieName))
			{
				values = httpContext.Request.Cookies[cookieName].Values;
			}
			return values;
		}

		/// <summary>
        /// 获取Cookie值集合
		/// </summary>
		/// <param name="cookie"></param>
		/// <returns></returns>
		public static NameValueCollection GetValues(HttpCookie cookie)
		{
            if (cookie == null)
            {
                throw new ArgumentException("cookie");
            }
			return cookie.Values;
		}

		/// <summary>
        /// 获取Cookie值
		/// </summary>
		/// <param name="httpContext"></param>
		/// <param name="cookieName"></param>
		/// <param name="cookieKey"></param>
		/// <returns></returns>
		public static string GetKeyValue(HttpContext httpContext, string cookieName, string cookieKey)
		{
            if (httpContext == null)
            {
                throw new ArgumentException("httpContext");
            }
            if (string.IsNullOrEmpty(cookieName))
            {
                throw new ArgumentException("cookieName");
            }
            if (string.IsNullOrEmpty(cookieKey))
            {
                throw new ArgumentException("cookieKey");
            }

			var value = string.Empty; ;
			if (Exists(httpContext, cookieName))
			{
                if (httpContext.Request.Cookies[cookieName].Values[cookieKey] != null)
                {
                    value = httpContext.Request.Cookies[cookieName].Values[cookieKey];
                }
			}
			return value;
		}

		/// <summary>
        /// 获取Cookie值
		/// </summary>
		/// <param name="cookie"></param>
		/// <param name="key"></param>
		/// <returns></returns>
		public static string GetKeyValue(HttpCookie cookie, string key)
		{
            if (cookie == null)
            {
                throw new ArgumentException("cookie");
            }
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException("key");
            }
			var value = string.Empty; ;
            if (cookie.Values[key] != null)
            {
                value = cookie.Values[key];
            }
			return value;
		}

		#endregion

	}
}
