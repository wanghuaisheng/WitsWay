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
