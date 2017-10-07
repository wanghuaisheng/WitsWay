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
    /// 填充目标特性
    /// </summary>

    [AttributeUsage(AttributeTargets.Property)]
    public class FillTargetAttribute : Attribute
    {

        /// <summary>
        /// 填充类型
        /// </summary>
        public FillKind Kind { get; private set; }
        /// <summary>
        /// 填充组
        /// </summary>
        public int Group { get; private set; }
        /// <summary>
        /// 填充目标特性
        /// </summary>
        public FillTargetAttribute(FillKind kind) : this(kind, 0) { }

        /// <summary>
        /// 填充目标特性
        /// </summary>
        /// <param name="kind">填充类型</param>
        /// <param name="group">填充组，当出现相同类型多个填充属性时需要设置组</param>
        public FillTargetAttribute(FillKind kind, int group)
        {
            Kind = kind;
            Group = group;
        }

    }

}

