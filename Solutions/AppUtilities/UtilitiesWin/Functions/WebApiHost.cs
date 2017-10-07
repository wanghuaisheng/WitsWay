using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.SelfHost;
using WitsWay.Utilities.Errors;
using WitsWay.Utilities.Helpers;
using WitsWay.Utilities.Patterns;

namespace WitsWay.Utilities.Win.Functions
{
    /// <summary>
    /// WebApi辅助类
    /// </summary>
    public class WebApiHost : MsDispose
    {
        /// <summary>
        /// 托管Server
        /// </summary>
        public HttpSelfHostServer HostServer { get; private set; }
        /// <summary>
        /// 启动自托管
        /// </summary>
        /// <param name="uri">服务地址</param>
        /// <param name="configRouteAction">配置路由Action
        /// <example>
        /// <![CDATA[
        /// config.Routes.MapHttpRoute("ApiDefault", "api/{controller}/{id}", new { id = RouteParameter.Optional });
        /// config.Routes.MapHttpRoute("report", "{controller}/{action}/{para}", new { controller = "ReportController", para = RouteParameter.Optional });
        /// ]]>
        /// </example>
        /// </param>
        public void SelfHostConfig(Uri uri, Action<HttpSelfHostConfiguration> configRouteAction)
        {
            var config = new HttpSelfHostConfiguration(uri);
            config.Properties["maxUrlLength"] = 9999;
            config.MaxBufferSize = 9999;
            config.MaxReceivedMessageSize = 9999;
            config.MessageHandlers.Add(new CrossDomainHandler());
            configRouteAction(config);
            var server = new HttpSelfHostServer(config);
            HostServer = server;
        }

        /// <summary>
        /// 启动自托管
        /// </summary>
        public void SelfHostStart()
        {
            if (HostServer == null)
            {
                throw ExceptionHelper.GetProgramException("请先配置自托管服务", UtilityErrors.ArgumentNullException);
            }
            HostServer.OpenAsync().Wait();
        }

        /// <summary>
        /// 停止自托管服务
        /// </summary>
        public void SelfHostStop()
        {
            if (HostServer == null)
            {
                throw ExceptionHelper.GetProgramException("请先配置自托管服务", UtilityErrors.ArgumentNullException);
            }
            HostServer.CloseAsync();
        }

        /// <summary>
        /// 释放非托管资源
        /// </summary>
        public override void ReleaseUnManagedResource()
        {
            HostServer.Dispose();
        }
    }

    /// <summary>
    /// 跨域Handler
    /// </summary>
    public class CrossDomainHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = base.SendAsync(request, cancellationToken);
            response.Result.Headers.Add("Access-Control-Allow-Origin", "*");
            return response;
        }
    }

}
