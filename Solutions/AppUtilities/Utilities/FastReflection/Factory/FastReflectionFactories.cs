using System.Reflection;
using WitsWay.Utilities.FastReflection.Constructor;
using WitsWay.Utilities.FastReflection.Field;
using WitsWay.Utilities.FastReflection.Method;
using WitsWay.Utilities.FastReflection.Property;

namespace WitsWay.Utilities.FastReflection.Factory
{
    /// <summary>
    /// 快速反射工厂 集合
    /// </summary>
    public static class FastReflectionFactories
    {
        static FastReflectionFactories()
        {
            MethodInvokerFactory = new MethodInvokerFactory();
            ConstructorInvokerFactory = new ConstructorInvokerFactory();
            PropertyAccessorFactory = new PropertyAccessorFactory();
            FieldAccessorFactory = new FieldAccessorFactory();
        }

        /// <summary>
        /// MethodInvoker工厂接口实例
        /// </summary>
        public static IFastReflectionFactory<MethodInfo, IMethodInvoker> MethodInvokerFactory { get; set; }

        /// <summary>
        /// ConstructorInvoker工厂接口实例
        /// </summary>
        public static IFastReflectionFactory<ConstructorInfo, IConstructorInvoker> ConstructorInvokerFactory { get; set; }
        
        /// <summary>
        /// PropertyAccessor工厂接口实例
        /// </summary>
        public static IFastReflectionFactory<PropertyInfo, IPropertyAccessor> PropertyAccessorFactory { get; set; }
       
        /// <summary>
        /// FieldAccessor工厂接口实例
        /// </summary>
        public static IFastReflectionFactory<FieldInfo, IFieldAccessor> FieldAccessorFactory { get; set; }

    }
}
