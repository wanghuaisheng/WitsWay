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
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace WitsWay.Utilities.FastReflection.Constructor
{
    /// <summary>
    /// 构造函数Invoker接口
    /// </summary>
    public interface IConstructorInvoker
    {
        /// <summary>
        /// Invoke方法
        /// </summary>
        /// <param name="parameters">方法参数列表</param>
        /// <returns>方法执行结果</returns>
        object Invoke(params object[] parameters);
    }

    /// <summary>
    /// 构造函数Invoker
    /// </summary>
    public class ConstructorInvoker : IConstructorInvoker
    {
        private Func<object[], object> invoker;

        /// <summary>
        /// 构造函数信息
        /// </summary>
        public ConstructorInfo ConstructorInfo { get; private set; }
    /// <summary>
    /// 构造函数Invoker
    /// </summary>
    /// <param name="constructorInfo">构造函数信息</param>
        public ConstructorInvoker(ConstructorInfo constructorInfo)
        {
            ConstructorInfo = constructorInfo;
            invoker = InitializeInvoker(constructorInfo);
        }

        /// <summary>
        /// 动态委托创建
        /// <remarks>
        /// <![CDATA[
        /// 签名：(object)new T((T0)parameters[0], (T1)parameters[1], ...)
        /// ]]>
        /// </remarks>
        /// </summary>
        /// <param name="constructorInfo">构造函数信息</param>
        /// <returns>委托实例</returns>
        private Func<object[], object> InitializeInvoker(ConstructorInfo constructorInfo)
        {
            var parametersParameter = Expression.Parameter(typeof(object[]), "parameters");
            var parameterExpressions = new List<Expression>();
            var paramInfos = constructorInfo.GetParameters();
            for (var i = 0; i < paramInfos.Length; i++)
            {
                var valueObj = Expression.ArrayIndex(parametersParameter, Expression.Constant(i));
                var valueCast = Expression.Convert(valueObj, paramInfos[i].ParameterType);
                parameterExpressions.Add(valueCast);
            }
            var instanceCreate = Expression.New(constructorInfo, parameterExpressions);
            var instanceCreateCast = Expression.Convert(instanceCreate, typeof(object));
            var lambda = Expression.Lambda<Func<object[], object>>(instanceCreateCast, parametersParameter);
            return lambda.Compile();
        }

        /// <summary>
        /// 通过构造函数信息 反射创建对象
        /// </summary>
        /// <param name="parameters">参数列表</param>
        /// <returns>对象实例</returns>
        public object Invoke(params object[] parameters)
        {
            return invoker(parameters);
        }

        /// <summary>
        /// 通过构造函数信息 反射创建对象
        /// </summary>
        /// <param name="parameters">参数列表</param>
        /// <returns>对象实例</returns>
        object IConstructorInvoker.Invoke(params object[] parameters)
        {
            return Invoke(parameters);
        }
    }
}
