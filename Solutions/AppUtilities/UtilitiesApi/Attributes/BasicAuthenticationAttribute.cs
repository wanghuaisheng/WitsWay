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
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using WitsWay.Utilities.Helpers;
using WitsWay.Utilities.Models;
using WitsWay.Utilities.Web.Helpers;

namespace WitsWay.Utilities.Apis.Attributes
{
    /// <summary>  
    /// 基本验证Attribtue，用以Action的权限处理  
    /// </summary>  
    public class BasicAuthenticationAttribute : ActionFilterAttribute
    {
        /// <summary>  
        /// 检查用户是否有该Action执行的操作权限  
        /// </summary>  
        /// <param name="actionContext"></param>  
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            //检验用户ticket信息，用户ticket信息来自调用发起方  
            if (actionContext.Request.Headers.Authorization != null)
            {
                //解密用户ticket,并校验用户名密码是否匹配  
                var encryptTicket = actionContext.Request.Headers.Authorization.Parameter;
                if (ValidateUserTicket(encryptTicket))
                    base.OnActionExecuting(actionContext);
                else
                    actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            }
            else
            {
                //检查web.config配置是否要求权限校验  
                var isRquired = (WebConfigurationManager.AppSettings["WebApiAuthenticatedFlag"] == "true");
                if (isRquired)
                {
                    //如果请求Header不包含ticket，则判断是否是匿名调用  
                    var attr = actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>();
                    var isAnonymous = attr.Any();

                    //是匿名用户，则继续执行；非匿名用户，抛出“未授权访问”信息  
                    if (isAnonymous)
                        base.OnActionExecuting(actionContext);
                    else
                        actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                }
                else
                {
                    base.OnActionExecuting(actionContext);
                }
            }
        }

        /// <summary>  
        /// 校验用户ticket信息  
        /// </summary>  
        /// <param name="encryptTicket"></param>  
        /// <returns></returns>  
        private bool ValidateUserTicket(string encryptTicket)
        {
            HttpContext context = HttpContext.Current;
            var cookieValue = CookieHelper.GetValue(context, WebApiConsts.LoginResultCookieName);
            if (!string.IsNullOrEmpty(cookieValue))
            {
                var valueJson = EncryptDecryptHelper.DecryptDES(cookieValue, WebApiConsts.EncryptDecryptKey);
                var loginResult = SerilizeHelper.DeserilizeJson<LoginResult>(valueJson);
                return loginResult != null;
            }
            return false;
            //var userTicket = FormsAuthentication.Decrypt(encryptTicket);
            //var userTicketData = userTicket.UserData;

            //string userName = userTicketData.Substring(0, userTicketData.IndexOf(":"));
            //string password = userTicketData.Substring(userTicketData.IndexOf(":") + 1);

            //检查用户名、密码是否正确，验证是合法用户  
            //var isQuilified = CheckUser(userName, password);  
        }
    }
}