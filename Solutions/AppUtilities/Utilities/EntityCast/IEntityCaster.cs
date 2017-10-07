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
using System.Collections.Generic;
using WitsWay.Utilities.Entitys;

namespace WitsWay.Utilities.EntityCast
{
    /// <summary>
    /// 实体转换器
    /// </summary>
    /// <typeparam name="A">原类型</typeparam>
    /// <typeparam name="B">新类型</typeparam>
    public interface IEntityCaster<A, B>
        where A : new()
        where B : new()
    {

        /// <summary>
        /// 转换实体
        /// </summary>
        /// <param name="a">原实体</param>
        /// <returns>新实体</returns>
        B CastEntity(A a);

        /// <summary>
        /// 转换列表
        /// </summary>
        /// <param name="aList">A对象列表</param>
        /// <returns>B对象列表</returns>
        List<B> CastList(IList<A> aList);

        /// <summary>
        /// 转换页
        /// </summary>
        /// <param name="aPage">A分页信息</param>
        /// <returns>B分页信息</returns>
        PageResult<B> CastPage(PageResult<A> aPage);

    }
}
