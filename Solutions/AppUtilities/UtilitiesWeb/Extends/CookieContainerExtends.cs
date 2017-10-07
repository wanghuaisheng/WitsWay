using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Reflection;

namespace WitsWay.Utilities.Web.Extends
{
    /// <summary>
    /// 字符串扩展
    /// </summary>
    public static class CookieContainerExtends
    {
        /// <summary>
        /// 遍历Cookie容器
        /// </summary>
        /// <param name="cookieContainer">Cookie容器</param>
        /// <returns></returns>
        public static List<Cookie> GetAllCookies(this CookieContainer cookieContainer)
        {
            var cookies = new List<Cookie>();
            var table = (Hashtable)cookieContainer.GetType().InvokeMember("m_domainTable", BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.Instance, null, cookieContainer, new object[] { });
            foreach (var pathList in table.Values)
            {
                var cookieList = (SortedList)pathList.GetType().InvokeMember("m_list", BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.Instance, null, pathList, new object[] { });
                foreach (CookieCollection colCookies in cookieList.Values)
                {
                    foreach (Cookie cookie in colCookies) { cookies.Add(cookie); }
                }
            }
            return cookies;
        }
    }

}
