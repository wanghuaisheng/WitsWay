﻿using System.Reflection;
using WitsWay.Utilities.FastReflection.Property;

namespace WitsWay.Utilities.FastReflection.Cache
{
    /// <summary>
    /// 属性存取器缓存
    /// </summary>
    public class PropertyAccessorCache : FastReflectionCache<PropertyInfo, IPropertyAccessor>
    {

        /// <summary>
        /// 创建IPropertyAccessor接口实例
        /// </summary>
        /// <param name="key">PropertyInfo</param>
        /// <returns>IPropertyAccessor接口实例</returns>
        protected override IPropertyAccessor Create(PropertyInfo key)
        {
            return new PropertyAccessor(key);
        }
    }
}
