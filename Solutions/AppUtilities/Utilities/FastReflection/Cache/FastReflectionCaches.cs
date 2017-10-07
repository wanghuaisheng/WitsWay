using System.Reflection;
using WitsWay.Utilities.FastReflection.Constructor;
using WitsWay.Utilities.FastReflection.Field;
using WitsWay.Utilities.FastReflection.Method;
using WitsWay.Utilities.FastReflection.Property;

namespace WitsWay.Utilities.FastReflection.Cache
{

    /// <summary>
    /// 快速反射 缓存集合
    /// </summary>
    public static class FastReflectionCaches
    {

        static FastReflectionCaches()
        {
            MethodInvokerCache = new MethodInvokerCache();
            PropertyAccessorCache = new PropertyAccessorCache();
            FieldAccessorCache = new FieldAccessorCache();
            ConstructorInvokerCache = new ConstructorInvokerCache();
        }

        /// <summary>
        /// MethodInvoker缓存
        /// </summary>
        public static IFastReflectionCache<MethodInfo, IMethodInvoker> MethodInvokerCache { get; set; }

        /// <summary>
        /// PropertyAccessor缓存
        /// </summary>
        public static IFastReflectionCache<PropertyInfo, IPropertyAccessor> PropertyAccessorCache { get; set; }

        /// <summary>
        /// FieldAccessor缓存
        /// </summary>
        public static IFastReflectionCache<FieldInfo, IFieldAccessor> FieldAccessorCache { get; set; }

        /// <summary>
        /// ConstructorInvoker缓存
        /// </summary>
        public static IFastReflectionCache<ConstructorInfo, IConstructorInvoker> ConstructorInvokerCache { get; set; }
    }
}
