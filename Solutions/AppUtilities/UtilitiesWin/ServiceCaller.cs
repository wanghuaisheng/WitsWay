using WitsWay.Utilities.Patterns;
using WitsWay.Utilities.Services;

namespace WitsWay.Utilities.Win
{
    /// <summary>
    /// 服务调用者
    /// <para>
    /// 调用方式<![CDATA[ var pages = ServiceCaller.GetService<IPageItemService>().Call(s => s.GetAll());]]>
    /// </para>
    /// </summary>
    public class ServiceCaller : MsDispose
    {
        /// <summary>
        /// 获取服务
        /// </summary>
        /// <typeparam name="TService">服务类型</typeparam>
        /// <returns>服务接口实例</returns>
        public static ServiceAdapter<TService> GetService<TService>() where TService : class, IService
        {
            var caller = new ServiceAdapter<TService>();
            return caller;
        }
    }

}