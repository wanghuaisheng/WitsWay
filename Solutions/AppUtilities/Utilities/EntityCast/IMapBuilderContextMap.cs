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

namespace WitsWay.Utilities.EntityCast
{

    /// <summary>
    /// 映射上下文 成员映射对象
    /// </summary>
    /// <typeparam name="A">A类型</typeparam>
    /// <typeparam name="B">B类型</typeparam>
    /// <typeparam name="P">属性类型</typeparam>
    public interface IMapBuilderContextMap<A, B, P>
        where A : new()
        where B : new()
    {

        /// <summary>
        /// 映射A.当前属性，用B的对应属性名
        /// </summary>
        /// <param name="propertyName">B的属性名</param>
        /// <returns>映射上下文对象</returns>
        IMapBuilderContext<A, B> With(string propertyName);

        /// <summary>
        /// 映射A.当前属性 ，用B对应属性
        /// </summary>
        /// <param name="property">B.属性信息</param>
        /// <returns>映射上下文对象</returns>
        IMapBuilderContext<A, B> With(PropertyInfo property);

        /// <summary>
        /// 自定义映射
        /// </summary>
        /// <param name="f">传入A类型对象，返回P类型值</param>
        /// <returns>映射上下文对象</returns>
        IMapBuilderContext<A, B> With(Func<A, P> f);

    }
}