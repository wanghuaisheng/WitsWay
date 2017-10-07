using System.Reflection;
using WitsWay.Utilities.FastReflection.Factory;
using WitsWay.Utilities.FastReflection.Method;

namespace WitsWay.Utilities.FastReflection.Cache
{
    /// <summary>
    /// 方法Invoker缓存
    /// </summary>
    public class MethodInvokerCache : FastReflectionCache<MethodInfo, IMethodInvoker>
    {
        /// <summary>
        /// 创建IMethodInvoker接口实例
        /// </summary>
        /// <param name="key">MethodInfo</param>
        /// <returns>IMethodInvoker接口实例</returns>
        protected override IMethodInvoker Create(MethodInfo key)
        {
            return FastReflectionFactories.MethodInvokerFactory.Create(key);
        }
    }
}
