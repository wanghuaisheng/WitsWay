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

namespace WitsWay.Utilities.Fills
{
    /// <summary>
    /// 填充主键
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class FillKeyAttribute : Attribute
    {
        /// <summary>
        /// 填充类型
        /// </summary>
        public FillKind Kind { get; private set; }
        /// <summary>
        /// 填充组，当出现相同类型多个填充属性时需要设置组
        /// </summary>
        public int Group { get; private set; }
        /// <summary>
        /// 附加参数列表
        /// </summary>
        public object[] Paras { get; private set; }

        /// <summary>
        /// 填充主键
        /// </summary>
        /// <param name="kind">填充类型</param>
        public FillKeyAttribute(FillKind kind) : this(kind, 0) { }

        /// <summary>
        /// 填充主键
        /// </summary>
        /// <param name="kind">填充类型</param>
        /// <param name="group">填充组，当出现相同类型多个填充属性时需要设置组</param>
        /// <param name="paras">附加参数</param>
        public FillKeyAttribute(FillKind kind, int group,params object[] paras)
        {
            Kind = kind;
            Group = group;
            Paras = paras;
        }
    }
}
