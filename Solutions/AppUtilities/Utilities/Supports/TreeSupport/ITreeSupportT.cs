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

namespace WitsWay.Utilities.Supports.TreeSupport
{
    /// <summary>
    /// 树状支持
    /// </summary>
    public interface ITreeSupport<T> : ITreeSupport
    {

        /// <summary>
        /// 子节点
        /// </summary>
        List<T> Children { get; }
        /// <summary>
        /// 父节点
        /// </summary>
        T Parent { get; }
        /// <summary>
        /// 设置父节点
        /// </summary>
        /// <param name="parent">父节点</param>
        void SetParent(T parent);
    }
}
