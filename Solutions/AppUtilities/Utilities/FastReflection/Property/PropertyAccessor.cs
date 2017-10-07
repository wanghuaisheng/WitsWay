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
using System.Linq.Expressions;
using System.Reflection;
using WitsWay.Utilities.FastReflection.Method;

namespace WitsWay.Utilities.FastReflection.Property
{
    /// <summary>
    /// 属性存取器接口
    /// </summary>
    public interface IPropertyAccessor
    {
        /// <summary>
        /// 获取属性值
        /// </summary>
        /// <param name="instance">对象实例</param>
        /// <returns>对应属性的值</returns>
        object GetValue(object instance);
        /// <summary>
        /// 设置属性值
        /// </summary>
        /// <param name="instance">对象实例</param>
        /// <param name="value">要给对应属性赋予的值</param>
        void SetValue(object instance, object value);
    }

    /// <summary>
    /// 属性存取器
    /// </summary>
    public class PropertyAccessor : IPropertyAccessor
    {

        private Func<object, object> getter;

        private MethodInvoker setMethodInvoker;

        /// <summary>
        /// 反射属性信息
        /// </summary>
        public PropertyInfo PropertyInfo { get; private set; }

        /// <summary>
        /// 属性存取器
        /// </summary>
        /// <param name="propertyInfo">属性信息</param>
        public PropertyAccessor(PropertyInfo propertyInfo)
        {
            PropertyInfo = propertyInfo;
            InitializeGet(propertyInfo);
            InitializeSet(propertyInfo);
        }

        /// <summary>
        /// 构件Get委托方法
        /// <remarks>
        /// <![CDATA[
        /// 签名：(object)(((TInstance)instance).Property)
        /// ]]>
        /// </remarks>
        /// </summary>
        /// <param name="propertyInfo">属性信息</param>
        private void InitializeGet(PropertyInfo propertyInfo)
        {
            if (!propertyInfo.CanRead) { return; }
            var instance = Expression.Parameter(typeof(object), "instance");
            var instanceCast = propertyInfo.GetGetMethod(true).IsStatic ? null :Expression.Convert(instance, propertyInfo.ReflectedType);
            var propertyAccess = Expression.Property(instanceCast, propertyInfo);
            var castPropertyValue = Expression.Convert(propertyAccess, typeof(object));
            var lambda = Expression.Lambda<Func<object, object>>(castPropertyValue, instance);
            getter = lambda.Compile();
        }
        /// <summary>
        /// 构件Set委托方法
        /// </summary>
        /// <param name="propertyInfo">属性信息</param>
        private void InitializeSet(PropertyInfo propertyInfo)
        {
            if (!propertyInfo.CanWrite) return;
            setMethodInvoker = new MethodInvoker(propertyInfo.GetSetMethod(true));
        }

        /// <summary>
        /// 获取属性值
        /// </summary>
        /// <param name="o">对象实例</param>
        /// <returns>属性值</returns>
        public object GetValue(object o)
        {
            if (getter == null)
            {
                throw new NotSupportedException("对应属性不支持Get");
            }

            return getter(o);
        }

        /// <summary>
        /// 设置属性值
        /// </summary>
        /// <param name="o">对象实例</param>
        /// <param name="value">属性值</param>
        public void SetValue(object o, object value)
        {
            if (setMethodInvoker == null)
            {
                throw new NotSupportedException("对应属性不支持Set");
            }
            setMethodInvoker.Invoke(o, value);
        }

        /// <summary>
        /// 获取属性值
        /// </summary>
        /// <param name="instance"></param>
        /// <returns>属性值</returns>
        object IPropertyAccessor.GetValue(object instance)
        {
            return GetValue(instance);
        }

        /// <summary>
        /// 设置属性值
        /// </summary>
        /// <param name="instance">对象实例</param>
        /// <param name="value">属性值</param>
        void IPropertyAccessor.SetValue(object instance, object value)
        {
            SetValue(instance, value);
        }

    }
}
