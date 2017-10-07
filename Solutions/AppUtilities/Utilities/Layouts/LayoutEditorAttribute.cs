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
            get { return _isShow; }
            set { _isShow = value; }
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


    }
}
