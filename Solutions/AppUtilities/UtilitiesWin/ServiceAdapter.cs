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
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using WitsWay.Utilities.Extends;
using WitsWay.Utilities.Helpers;
using WitsWay.Utilities.Services;
using WitsWay.Utilities.Wcf;

#if RELEASE
using SmartSolution.Utilities.Wcf.WCFComponent;
#endif

namespace WitsWay.Utilities.Win
{

    /// <summary>
    /// 服务适配者
    /// </summary>
    public class ServiceAdapter<TService> where TService : class, IService
    {

        /// <summary> 调用服务方法
        /// </summary>
        /// <typeparam name="TResult">方法返回对象</typeparam>
        /// <param name="method">调用方法名</param>
        /// <returns>通过服务获取的数据</returns>
        public TResult Call<TResult>(Func<TService, TResult> method)
        {
            return ExceptionHelper.HandleExceptionClient(() =>
            {

#if RELEASE
                var address = GetServiceAddress<TService>();
                using (var client = new WcfClientForAnonymity<TService>(address))
                {
                    var service = client.ServiceContract;
                    return method(service);
                }

#else
                var serviceInfo = AllServices.FirstOrDefault(s => s.ServiceContract == typeof(TService));
                if (serviceInfo == null) return default(TResult);
                var service = (TService)serviceInfo.ServiceImplement.GetInstance();
                return method(service);
#endif
            });
        }

        /// <summary>
        /// 调用服务方法
        /// </summary>
        public void Call(Action<TService> method)
        {
            ExceptionHelper.HandleExceptionClient(() =>
            {
#if RELEASE
                var address = GetServiceAddress<TService>();
                using (var client = new WcfClientForAnonymity<TService>(address))
                {
                    var service = client.ServiceContract;
                    method(service);
                }

#else
                var serviceInfo = AllServices.FirstOrDefault(s => s.ServiceContract == typeof(TService));
                if (serviceInfo == null) return;
                var service = (TService)serviceInfo.ServiceImplement.GetInstance();
                method(service);
#endif
            });
        }

        /// <summary>
        /// 调用服务方法
        /// </summary>
        /// <typeparam name="TResult">方法返回对象</typeparam>
        /// <param name="method">调用方法名</param>
        /// <param name="title">等待窗体标题</param>
        /// <returns>通过服务获取的数据</returns>
        public TResult AsyncCall<TResult>(Func<TService, TResult> method, string title = "请稍后…")
        {
            var result = default(TResult);
            ExceptionHelper.HandleExceptionClient(() =>
            {
#if RELEASE
                var address = GetServiceAddress<TService>();
                using (var client = new WcfClientForAnonymity<TService>(address))
                {
                    var service = client.ServiceContract;
                    UtilityHelper.ShowWait(() => { result = method(service); }, title);
                }

#else
                var serviceInfo = AllServices.FirstOrDefault(s => s.ServiceContract == typeof(TService));
                if (serviceInfo == null) return default(TResult);
                var service = (TService)serviceInfo.ServiceImplement.GetInstance();
                UtilityHelper.ShowWait(() => { result = method(service); }, title);
               
#endif
                return result;
            });
            return result;
        }

        /// <summary>
        /// 调用服务方法
        /// </summary>
        /// <param name="method">调用方法名</param>
        /// <param name="title">等待窗体标题</param>
        /// <returns>通过服务获取的数据</returns>
        public void AsyncCall(Action<TService> method, string title = "请稍后…")
        {
            ExceptionHelper.HandleExceptionClient(() =>
            {
#if RELEASE
                var address = GetServiceAddress<TService>();
                using (var client = new WcfClientForAnonymity<TService>(address))
                {
                    var service = client.ServiceContract;
                    UtilityHelper.ShowWait(() => method(service), title);
                }

#else
                var serviceInfo = AllServices.FirstOrDefault(s => s.ServiceContract == typeof(TService));
                if (serviceInfo == null) return;
                var service = (TService)serviceInfo.ServiceImplement.GetInstance();
                UtilityHelper.ShowWait(() => method(service), title);
#endif
            });
        }

        private const string ErpDnsIdentity = "ERPPrivateServer";

        private static AddressWithDnsIdentity GetServiceAddress<T>()
        {
            var address = new AddressWithDnsIdentity
            {
                DnsIdentity = ErpDnsIdentity,
                ServiceEndPointUri = ""
            };
            var serverAddress = AppSettingHelper.GetValue("serverHost"); // ConfigHelper.GetServerIP();
            serverAddress = string.IsNullOrWhiteSpace(serverAddress) ? ComputerHelper.GetLocalAddress() : serverAddress;
            var serverPort = AppSettingHelper.GetValue("serverPort").CastTo<int>(); // ConfigHelper.GetServerPort();
            var serviceName = typeof(T).Name.Substring(1);
            ////switch (serviceName)
            ////{
            //////默认服务名为服务接口去掉字符“I”，如有特殊情况，请在此处添加
            ////case "AuthorizeService":
            ////    serviceName = "AuthorizeService";
            ////    break;
            ////}
            address.ServiceEndPointUri =
                $@"net.tcp://{serverAddress}{(serverPort > 0 ? ":" + serverPort : serverPort.ToString())}/{serviceName}";
            return address;
        }

        /// <summary>
        /// 服务配置项
        /// </summary>
        [Serializable]
        public class ServiceItemInfo
        {
            /// <summary>
            /// 服务名
            /// </summary>
            public string ServiceName { get; set; }
            /// <summary>
            /// 服务契约
            /// </summary>
            public Type ServiceContract { get; set; }
            /// <summary>
            /// 服务实现
            /// </summary>
            public Type ServiceImplement { get; set; }
            /// <summary>
            /// 服务是否可用
            /// </summary>
            public bool Enable { get; set; }
        }


        private List<ServiceItemInfo> _allServices;
        /// <summary>
        /// 所有服务
        /// </summary>
        public List<ServiceItemInfo> AllServices
        {
            get
            {
                if (_allServices != null) return _allServices;
                var services = new List<ServiceItemInfo>();
                var dlls = AppSettingHelper.GetValue(WinUtilityConsts.ServicesDllNamesKey)?.SplitToList<string>();
                dlls.SafeForEach(dll =>
                {
                    try
                    {
                        var assy = Assembly.Load(dll);
                        var types = assy.GetTypes();
                        services.AddRange(types.Select(GetServiceItem).Where(serviceItem => serviceItem != null));
                    }
                    catch (Exception ex)
                    {
                        Logger.Write(ex);
                    }

                });
                _allServices = services;
                return _allServices;
            }
        }

        private static ServiceItemInfo GetServiceItem(Type type)
        {
            var faces = type.GetInterfaces();
            foreach (var face in faces)
            {
                var attr = face.GetCustomAttribute<ServiceContractAttribute>(false);
                if (attr == null) continue;
                var service = new ServiceItemInfo()
                {
                    ServiceName = type.Name,
                    ServiceContract = face,
                    ServiceImplement = type,
                    Enable = true
                };
                return service;
            }
            return null;
        }
    }
}