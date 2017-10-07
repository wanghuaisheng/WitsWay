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
