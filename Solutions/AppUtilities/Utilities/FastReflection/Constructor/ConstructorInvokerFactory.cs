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

namespace WitsWay.Utilities.FastReflection.Constructor
{
    /// <summary>
    /// 构造函数Invoker工厂
    /// </summary>
    public class ConstructorInvokerFactory : IFastReflectionFactory<ConstructorInfo, IConstructorInvoker>
    {
        /// <summary>
        /// 创建IConstructorInvoker实例
        /// </summary>
        /// <param name="key">构造函数信息</param>
        /// <returns>IConstructorInvoker实例</returns>
        public IConstructorInvoker Create(ConstructorInfo key)
        {
            return new ConstructorInvoker(key);
        }

        /// <summary>
        /// 创建IConstructorInvoker实例
        /// </summary>
        /// <param name="key">构造函数信息</param>
        /// <returns>IConstructorInvoker实例</returns>
        IConstructorInvoker IFastReflectionFactory<ConstructorInfo, IConstructorInvoker>.Create(ConstructorInfo key)
        {
            return Create(key);
        }

    }
}
