using System;
using System.Reflection;
using System.Security.Permissions;

namespace WitsWay.Utilities.Patterns
{
    /// <summary>
    /// 沙箱
    /// </summary>
    public class Sandbox : MarshalByRefObject
    {
        private static AppDomain _domain;
        /// <summary>
        /// 创建沙箱
        /// </summary>
        /// <param name="domainName">应用程序域名称</param>
        /// <returns>应用程序域沙箱包装</returns>
        public static Sandbox Create(string domainName = null)
        {
            //方法一： 权限集和配置从创建的AppDomain继承
            domainName = domainName ?? "Sandbox" + new Random().Next(1000);
            _domain = AppDomain.CreateDomain(domainName, null, null);
            var box = _domain.CreateInstanceAndUnwrap(Assembly.GetAssembly(typeof(Sandbox)).FullName, typeof(Sandbox).ToString()) as Sandbox;
            return box;

            //方法二：自定义权限集和配置
            //domainName = domainName ?? "Sandbox" + new Random().Next(1000);

            //var setup = new AppDomainSetup()
            //{
            //    ApplicationBase = AppDomain.CurrentDomain.BaseDirectory,
            //    ApplicationName = domainName,
            //    DisallowBindingRedirects = true,
            //    DisallowCodeDownload = true,
            //    DisallowPublisherPolicy = true
            //};

            //var permissions = new PermissionSet(PermissionState.None);
            //permissions.AddPermission(new ReflectionPermission(ReflectionPermissionFlag.RestrictedMemberAccess));
            //permissions.AddPermission(new SecurityPermission(SecurityPermissionFlag.Execution));

            ////var fullTrustAssembly = typeof(Sandbox).Assembly.Evidence.GetHostEvidence<StrongName>();
            ////_domain = AppDomain.CreateDomain(domainName, null, setup, permissions, fullTrustAssembly);
            //_domain = AppDomain.CreateDomain(domainName, null, setup, permissions);

            //Sandbox box =
            //    (Sandbox)
            //        Activator.CreateInstanceFrom(_domain, typeof(Sandbox).Assembly.ManifestModule.FullyQualifiedName,
            //            typeof(Sandbox).FullName).Unwrap();
            //return box;
        }
        /// <summary>
        /// 执行方法
        /// </summary>
        /// <param name="assemblyName">程序集名称</param>
        /// <param name="typeName">类型名称</param>
        /// <param name="methodName">方法名称</param>
        /// <param name="parameters">参数</param>
        public void Execute(string assemblyName, string typeName, string methodName, params object[] parameters)
        {
            var assembly = Assembly.Load(assemblyName);
            var type = assembly.GetType(typeName);
            if (type == null) return;
            var instance = Activator.CreateInstance(type);
            var method = type.GetMethod(methodName);
            method.Invoke(instance, parameters);
        }

        /// <summary>
        /// 释放应用程序域
        /// </summary>
        public void Dispose()
        {
            if (_domain == null) return;
            AppDomain.Unload(_domain);
            _domain = null;
        }

        /// <summary>
        /// 自定义对象租用周期
        /// </summary>
        [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.Infrastructure)]
        public override object InitializeLifetimeService()
        {
            //将对象的租用周期改变为无限
            return null;
            //ILease lease = (ILease)base.InitializeLifetimeService();
            //if (lease.CurrentState == LeaseState.Initial)
            //{
            //    lease.InitialLeaseTime = TimeSpan.FromMinutes(1);
            //    lease.SponsorshipTimeout = TimeSpan.FromMinutes(2);
            //    lease.RenewOnCallTime = TimeSpan.FromSeconds(2);
            //}
            //return lease;
        }
    }
}
