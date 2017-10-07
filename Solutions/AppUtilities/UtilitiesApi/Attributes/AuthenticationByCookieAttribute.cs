using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
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
    public class AuthenticationByCookieAttribute : ActionFilterAttribute
    {
        /// <summary>  
        /// 检查用户是否有该Action执行的操作权限  
        /// </summary>  
        /// <param name="actionContext"></param>  
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            //检验用户ticket信息，用户ticket信息来自调用发起方  
            //解密用户ticket,并校验用户名密码是否匹配  
            var cookieValue = string.Empty;
            if (!string.IsNullOrEmpty(WebApiContext.AuthenticationCookieName))
            {
                cookieValue = CookieHelper.GetValue(HttpContext.Current, WebApiContext.AuthenticationCookieName);
            }
            if (!string.IsNullOrEmpty(cookieValue))
            {
                var valueJson = EncryptDecryptHelper.DecryptDES(cookieValue, WebApiConsts.EncryptDecryptKey);
                var loginResult = SerilizeHelper.DeserilizeJson<LoginResult>(valueJson);
                if (loginResult != null)
                {
                    base.OnActionExecuting(actionContext);
                }
            }
            else
            {
                //判断是否是匿名调用  
                var attr = actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>();
                var isAnonymous = attr.Any();

                //是匿名用户，则继续执行；非匿名用户，抛出“未授权访问”信息  
                if (isAnonymous)
                    base.OnActionExecuting(actionContext);
                else
                    actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            }
        }
    }
}