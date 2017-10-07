using System;
using WitsWay.TempTests.DynamicQuery.Enums;

namespace WitsWay.TempTests.DynamicQuery.Editors
{
    /// <summary>
    /// 输入控件
    /// </summary>
    public class InputEditorAttribute : Attribute
    {
        /// <summary>
        /// 输入控件类型
        /// </summary>
        public EditorKinds EditorKind { get; set; }
    }
}
