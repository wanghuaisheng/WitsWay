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

namespace WitsWay.Utilities.Layouts
{
    /// <summary>
    /// 布局描述信息
    /// </summary>
    public class LayoutDescription
    {
        /// <summary>
        /// 布局编码
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 布局名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 目标模型
        /// </summary>
        public Type TargetModel { get; set; }
        /// <summary>
        /// 布局备注
        /// </summary>
        public string Remark { get; set; }
    }
}
