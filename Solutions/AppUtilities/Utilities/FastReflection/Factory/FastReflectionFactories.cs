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
