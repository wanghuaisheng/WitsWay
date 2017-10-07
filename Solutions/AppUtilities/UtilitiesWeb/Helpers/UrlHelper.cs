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
using System.Net;
using System.Web;

namespace WitsWay.Utilities.Web.Helpers
{
    /// <summary>
    /// 页面URL转换辅助类
    /// </summary>
    public class UrlHelper
    {
        /// <summary>
        /// 相对路径转绝对路径
        /// </summary>
        public static string RelativeToAbsolute(string relativeURL)
        {
            if (relativeURL[0] == '~')
            {
                return VirtualPathUtility.ToAbsolute(relativeURL);
            }
            return relativeURL;
        }

        /// <summary>
        /// 相对路径转换为物理文件路径
        /// </summary>
        /// <param name="relativeURL">~/开头的相对路径</param>
        /// <returns></returns>
        public static string RelativeToFilePath(string relativeURL)
        {
            if (relativeURL[0] == '~')
            {
                return HttpContext.Current.Server.MapPath(relativeURL);
            }
            return relativeURL;
        }

        private static Uri _AbsoluteWebRoot;

        /// <summary>
        /// 取得网站绝对路径
        /// </summary>
        /// <value>以 '/'结尾的字符串</value>
        public static Uri AbsoluteWebRoot(string webRelativeRoot)
        {
            if (_AbsoluteWebRoot == null)
            {
                HttpContext context = HttpContext.Current;
                if (context == null)
                {
                    throw new WebException("HttpContext为空");
                }
                _AbsoluteWebRoot = new Uri(context.Request.Url.Scheme + "://" + context.Request.Url.Authority + RelativeToAbsolute(webRelativeRoot));
            }
            return _AbsoluteWebRoot;
        }
    }
}
