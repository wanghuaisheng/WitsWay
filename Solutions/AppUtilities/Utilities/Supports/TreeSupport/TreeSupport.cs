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
using System.Linq;
using System.Xml.Serialization;

namespace WitsWay.Utilities.Supports.TreeSupport
{
    /// <summary>
    /// 树支持
    /// </summary>
    [Serializable]
    public abstract class TreeSupport<T> : ITreeSupport<T> where T : TreeSupport<T>
    {
        private List<T> _children;
        /// <summary>
        /// 子节点列表
        /// </summary>
        [XmlIgnore]
        public List<T> Children => _children ?? (_children = new List<T>());

        /// <summary>
        /// 父节点
        /// </summary>
        [XmlIgnore]
        public T Parent { get; private set; }

        /// <summary>
        /// 设置父节点
        /// </summary>
        /// <param name="parent">父节点</param>
        public void SetParent(T parent)
        {
            Parent = parent;
        }

        /// <summary>
        /// 父节点Id
        /// </summary>
        public abstract string NodeParentId { get; }

        /// <summary>
        /// 节点Id
        /// </summary>
        public abstract string NodeId { get; }

        /// <summary>
        /// 是否有孩子节点
        /// </summary>
        public bool HaveChild => _children != null && _children.Any();

        /// <summary>
        /// 是否有父亲节点
        /// </summary>
        public bool HaveParent => Parent != null;

        /// <summary>
        /// 子节点数量
        /// </summary>
        public int ChildNum => _children == null ? 0 : _children.Count;

        /// <summary>
        /// 节点层级
        /// </summary>
        public int NodeLevel { get; private set; }
        /// <summary>
        /// 设置节点层级
        /// </summary>
        /// <param name="nodeLevel">节点层级</param>
        public void SetNodeLevel(int nodeLevel)
        {
            NodeLevel = nodeLevel;
        }

    }
}
