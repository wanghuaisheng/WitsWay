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
using System.Drawing.Imaging;
using System.Web;
using System.Web.SessionState;

namespace WitsWay.Utilities.Web.Captcha
{

    /// <summary>
    /// 从Session或Cache获取验证码图片，然后写入输出流
    /// 需要在Web中添加
    /// 需要在web.config中配置：
    /// [configuration]
    ///   [system.web]
    ///     [httpHandlers]
    ///       [add verb="GET" path="CaptchaImage.aspx" type="DotNetSoft.Utilities.Web.Captcha.CaptchaImageHandler, DotNetSoft.Utilities"/]
    ///     [/httpHandlers]
    ///   [/system.web]
    /// [/configuration]
    /// </summary>
    public class CaptchaImageHandler : IHttpHandler, IRequiresSessionState
    {
        /// <summary>
        /// 是否可重用
        /// </summary>
        public bool IsReusable
        {
            get { return true; }
        }

        /// <summary>
        /// 处理请求
        /// </summary>
        /// <param name="context">Http请求上下文</param>
        public void ProcessRequest(HttpContext context)
        {
            HttpApplication application = context.ApplicationInstance;
            string guid = application.Request.QueryString["guid"];
            var useSession = !string.IsNullOrEmpty(application.Request.QueryString["useSession"]);

            if (string.IsNullOrEmpty(guid) == false)
            {
                CaptchaImage captchaImage;

                if (useSession)
                {
                    captchaImage = (CaptchaImage)HttpContext.Current.Session[guid];
                }
                else
                {
                    captchaImage = (CaptchaImage)HttpRuntime.Cache.Get(guid);
                }
                if (captchaImage == null)
                {
                    captchaImage = CaptchaImage.GetCaptchaImage(true);
                }
                var bitmap = captchaImage.GenerateImage();
                bitmap.Save(application.Context.Response.OutputStream, ImageFormat.Jpeg);
                bitmap.Dispose();
                application.Response.ContentType = "image/jpeg";
                application.Response.StatusCode = 200;
            }
            else
            {
                application.Response.StatusCode = 404;
            }
            context.ApplicationInstance.CompleteRequest();
        }
    }
}