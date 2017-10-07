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
using System.Reflection;
using WitsWay.Utilities.Extends;
using WitsWay.Utilities.FastReflection;
using WitsWay.Utilities.Guards;

namespace WitsWay.Utilities.EntityCast
{

    /// <summary>
    /// 属性映射信息
    /// </summary>
    /// <typeparam name="A">原类型</typeparam>
    public abstract class PropertyMapping<A>
    {
        /// <summary>
        /// 属性映射信息
        /// </summary>
        /// <param name="property">B对应属性信息</param>
        protected PropertyMapping(PropertyInfo property)
        {
            Property = property;
        }

        /// <summary>
        /// Get要映射的B对应属性信息
        /// </summary>
        public PropertyInfo Property { get; private set; }

        /// <summary>
        /// 获取A的对应属性值
        /// </summary>
        /// <param name="a">原实体</param>
        /// <returns>属性值</returns>
        public abstract object GetPropertyValue(A a);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="a"></param>
        public void Map(object instance, A a)
        {
            var convertedValue = GetPropertyValue(a);

            SetValue(instance, convertedValue);
        }

        /// <summary>
        /// 设置属性值
        /// </summary>
        /// <param name="instance">B实例</param>
        /// <param name="value">属性值</param>
        protected void SetValue(object instance, object value)
        {
            Property.SetValue(instance, value, new object[0]);
        }

    }

    /// <summary>
    /// 属性名映射信息
    /// </summary>
    public class PropertyNameMapping<A> : PropertyMapping<A>
    {

        /// <summary>
        /// 属性名映射信息
        /// </summary>
        /// <param name="property">B的属性信息</param>
        /// <param name="propertyName">A的属性名</param>
        public PropertyNameMapping(PropertyInfo property, string propertyName)
            : base(property)
        {
            PropertyName = propertyName;
        }

        /// <summary>
        /// A的属性名
        /// </summary>
        public string PropertyName { get; private set; }

        /// <summary>
        /// 取得属性值
        /// </summary>
        /// <param name="a">A实体</param>
        /// <returns>A的对应名称属性值</returns>
        public override object GetPropertyValue(A a)
        {
            ArgumentGuard.ArgumentNotNull("a", a);
            object value;

            try
            {
                value = typeof(A).GetProperty(PropertyName).FastGetValue(a);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            object convertedValue;
            try
            {
                convertedValue = value.CastTo(Property.PropertyType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return convertedValue;
        }
    }

    /// <summary>
    /// Func映射信息
    /// </summary>
    public class FuncMapping<A> : PropertyMapping<A>
    {
        /// <summary>
        /// Func映射信息
        /// </summary>
        /// <param name="property">B的属性信息</param>
        /// <param name="func">从A获取对应值的Func</param>
        public FuncMapping(PropertyInfo property, Func<A, object> func)
            : base(property)
        {
            ArgumentGuard.ArgumentNotNull("func", func);
            Func = func;
        }

        /// <summary>
        /// 从A获取属性值Func
        /// </summary>
        public Func<A, object> Func { get; private set; }

        /// <summary>
        /// 获取属性值
        /// </summary>
        /// <param name="a">A实体</param>
        /// <returns>值</returns>
        public override object GetPropertyValue(A a)
        {
            return Func(a);
        }
    }
}
