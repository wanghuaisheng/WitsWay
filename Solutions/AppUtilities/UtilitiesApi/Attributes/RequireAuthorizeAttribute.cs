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
    public class RequireAuthorizeAttribute : ActionFilterAttribute
    {
        private readonly int _requiredPermission;

        /// <summary>
        /// 构造一个特性实例
        /// </summary>
        /// <param name="requiredPermission"></param>
        public RequireAuthorizeAttribute(int requiredPermission)
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
                if (!controller.HasPermission(_requiredPermission))
                {
                    //虽然是登录用户，但没有该Action的权限，跳转到“未授权访问”页面
                    actionContext.Response = new HttpResponseMessage(HttpStatusCode.Forbidden);
                }
            }
        }
    }
}
