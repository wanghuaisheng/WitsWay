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
    /// 用于属性对应的控件呈现
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Enum | AttributeTargets.Struct)]
    public class LayoutEditorAttribute : Attribute
    {
        /// <summary>
        /// 是否显示子对象的属性来布局窗体
        /// </summary>
        public bool IsShowChildProperty { get; set; }

        private bool _isShow = true;

        /// <summary>
        /// 用于属性对应的控件呈现
        /// </summary>
        public LayoutEditorAttribute()
        {
            IsShowChildProperty = false;
        }

        /// <summary>
        /// 是否在界面上显示(默认是显示)
        /// </summary>
        public bool IsShow
        {
            get => _isShow;
            set => _isShow = value;
        }
        /// <summary>
        /// 控件的Type
        /// </summary>
        public EditorKinds EditorKind { get; set; }

        /// <summary>
        /// 用户控件的名称，表示要用哪一个用户控件， UserControl的时候才设置，非UserControl的时候不用设置
        /// </summary>
        public string CustomerControlName { get; set; }

        /// <summary>
        /// 用户控件的顺序值，默认是0，当一个用户控件在窗体上多次显示的时候才需要使用，UserControl的时候才设置，非UserControl的时候不用设置
        /// </summary>
        public int CustomerControlIndex { get; set; }
        /// <summary>
        /// 数据来源
        /// </summary>
        public string DataSource { get; set; }

    }
}
