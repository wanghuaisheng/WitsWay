/******************************************
 * 2012年5月3日 王怀生 添加
 * 
 * ***************************************/

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
