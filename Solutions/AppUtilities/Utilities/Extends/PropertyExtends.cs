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

namespace WitsWay.Utilities.Extends
{
    /// <summary>
    /// 属性扩展
    /// </summary>
    public static class PropertyExtends
    {
        /// <summary>
        /// 取得对应属性的T自定义标签实例
        /// </summary>
        /// <typeparam name="T">自定义标签类型</typeparam>
        /// <param name="property">属性信息</param>
        /// <returns>自定义标签实例</returns>
        public static T GetAttribute<T>(this PropertyInfo property)
        {
            var attributes = property.GetCustomAttributes(true);
            foreach (var att in attributes)
            {
                if (att is T)
                    return (T)att;
            }
            return default(T);
        }

    }
}
