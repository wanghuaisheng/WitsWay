using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using WitsWay.Utilities.Apis.Controller;
using WitsWay.Utilities.Extends;
using WitsWay.Utilities.Models;

namespace WitsWay.Utilities.Apis.Attributes
{

    /// <summary>
    /// 审计特性，拥有该标记的Action会被记录访问日志
    /// </summary>
    public class AuditAttribute : ActionFilterAttribute
    {
        private OperationLog _log;

        /// <summary>
        /// Occurs before the action method is invoked.
        /// </summary>
        /// <param name="actionContext">The action context.</param>
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            _log = new OperationLog
            {
                BrowserInfo = GetBrowserInfo(HttpContext.Current),
                ExecutionTime = DateTime.Now,
                ClientIpAddress = GetClientIpAddress(HttpContext.Current),
                ClientName = GetComputerName(HttpContext.Current),

                Parameters = ConvertArgumentsToJson(actionContext.ActionArguments)
            };
            var currentMethodInfo = ActionDescriptorHelper.GetMethodInfo(actionContext.ActionDescriptor);
            if (currentMethodInfo != null)
            {
                if (currentMethodInfo.DeclaringType != null)
                    _log.ServiceName = currentMethodInfo.DeclaringType.Name;
                _log.MethodName = currentMethodInfo.Name;
            }

            var controller = actionContext.ControllerContext.Controller as IAuthoritableController;
            if (controller != null && controller.UserLoginTicket != null)
            {
                _log.CorpID = controller.UserLoginTicket.CorpId;
                _log.EmployeeID = controller.UserLoginTicket.EmployeeId;
            }

            base.OnActionExecuting(actionContext);
        }

        /// <summary>
        /// Occurs after the action method is invoked.
        /// </summary>
        /// <param name="actionExecutedContext">The action executed context.</param>
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);
            _log.ExecutionDuration = (DateTime.Now - _log.ExecutionTime).Milliseconds;
            _log.ExceptionInfo = actionExecutedContext.Exception == null ?
                                    string.Empty :
                                    actionExecutedContext.Exception.ToString();

            var controller = actionExecutedContext.ActionContext.ControllerContext.Controller as IAuditableController;
            controller.Log(_log);
        }

        private static string GetBrowserInfo(HttpContext httpContext)
        {
            return httpContext.Request.Browser.Browser + " / " +
                   httpContext.Request.Browser.Version + " / " +
                   httpContext.Request.Browser.Platform;
        }

        private static string GetClientIpAddress(HttpContext httpContext)
        {
            var clientIp = httpContext.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] ??
                           httpContext.Request.ServerVariables["REMOTE_ADDR"];

            foreach (var hostAddress in Dns.GetHostAddresses(clientIp))
            {
                if (hostAddress.AddressFamily == AddressFamily.InterNetwork)
                {
                    return hostAddress.ToString();
                }
            }

            foreach (var hostAddress in Dns.GetHostAddresses(Dns.GetHostName()))
            {
                if (hostAddress.AddressFamily == AddressFamily.InterNetwork)
                {
                    return hostAddress.ToString();
                }
            }

            return null;
        }

        private static string GetComputerName(HttpContext httpContext)
        {
            if (!httpContext.Request.IsLocal)
            {
                return string.Empty;
            }

            try
            {
                var clientIp = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] ??
                               HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                return Dns.GetHostEntry(IPAddress.Parse(clientIp)).HostName;
            }
            catch
            {
                return string.Empty;
            }
        }

        private string ConvertArgumentsToJson(IDictionary<string, object> arguments)
        {
            try
            {
                if (arguments.IsNullOrEmpty())
                {
                    return "{}";
                }

                var dictionary = new Dictionary<string, object>();

                foreach (var argument in arguments)
                {
                    dictionary[argument.Key] = argument.Value;
                }

                return JsonConvert.SerializeObject(
                    dictionary,
                    new JsonSerializerSettings
                    {
                        ContractResolver = new CamelCasePropertyNamesContractResolver()
                    });
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                //Logger.Warn("Could not serialize arguments for method: " + _auditInfo.ServiceName + "." + _auditInfo.MethodName);
                //Logger.Warn(ex.ToString(), ex);
                return "{erorr:true}";
            }
        }

        internal static class ActionDescriptorHelper
        {
            public static MethodInfo GetMethodInfo(HttpActionDescriptor actionDescriptor)
            {
                if (actionDescriptor is ReflectedHttpActionDescriptor)
                {
                    return ((ReflectedHttpActionDescriptor)actionDescriptor).MethodInfo;
                }
                return null;
                //if (actionDescriptor is ReflectedAsyncActionDescriptor)
                //{
                //    return ((ReflectedAsyncActionDescriptor)actionDescriptor).MethodInfo;
                //}

                //if (actionDescriptor is TaskHttpAsyncActionDescriptor)
                //{
                //    return ((TaskAsyncActionDescriptor)actionDescriptor).MethodInfo;
                //}

                //throw new AbpException("Could not get MethodInfo for the action '" + actionDescriptor.ActionName + "' of controller '" + actionDescriptor.ControllerDescriptor.ControllerName + "'.");
            }
        }
    }
}
