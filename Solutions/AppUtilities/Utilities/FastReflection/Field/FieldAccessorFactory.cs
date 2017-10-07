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
using WitsWay.Utilities.FastReflection.Factory;

namespace WitsWay.Utilities.FastReflection.Field
{
    /// <summary>
    /// 字段存取器工厂
    /// </summary>
    public class FieldAccessorFactory : IFastReflectionFactory<FieldInfo, IFieldAccessor>
    {

        /// <summary>
        /// 创建字段访问器 接口实现
        /// </summary>
        /// <param name="key">字段信息</param>
        /// <returns>字段访问器实例</returns>
        public IFieldAccessor Create(FieldInfo key)
        {
            return new FieldAccessor(key);
        }

        /// <summary>
        /// 创建字段访问器 接口显示实现
        /// </summary>
        /// <param name="key">字段信息</param>
        /// <returns>字段访问器实例</returns>
        IFieldAccessor IFastReflectionFactory<FieldInfo, IFieldAccessor>.Create(FieldInfo key)
        {
            return Create(key);
        }

    }
}
