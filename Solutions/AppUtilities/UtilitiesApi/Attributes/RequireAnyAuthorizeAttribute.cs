using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using WitsWay.Utilities.Apis.Controller;

namespace WitsWay.Utilities.Apis.Attributes
{
    /// <summary>
    /// 需要所有指定权限的一个或多个特性
    /// </summary>
    public class RequireAnyAuthorizeAttribute : ActionFilterAttribute
    {
        private readonly int[] _requiredPermission;

        /// <summary>
        /// 构造一个特性实例
        /// </summary>
        /// <param name="requiredPermission"></param>
        public RequireAnyAuthorizeAttribute(params int[] requiredPermission)
        {
            _requiredPermission = requiredPermission;
        }

        /// <summary>
        /// Occurs before the action method is invoked.
        /// </summary>
        /// <param name="actionContext">The action context.</param>
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            base.OnActionExecuting(actionContext);

            var controller = actionContext.ControllerContext.Controller as IAuthoritableController;

            if (controller == null)
                return;

            //验证是否是登录用户
            if (controller.UserLoginTicket == null)
            {
                //用户的Cookie过期，需要重新登录
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            }
            else
            {
                //验证用户操作是否在权限列表中，不在权限列表中，跳转未授权页面
                if (!controller.HasAnyPermission(_requiredPermission))
                {
                    //虽然是登录用户，但没有该Action的权限，跳转到“未授权访问”页面
                    actionContext.Response = new HttpResponseMessage(HttpStatusCode.Forbidden);
                }
            }
        }
    }
}
