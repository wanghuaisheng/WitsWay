using WitsWay.Utilities.Attributes;

namespace WitsWay.TempTests.DynamicQuery.Enums
{
    /// <summary>
    /// 输入控件类型
    /// </summary>
    [EnumField("输入控件类型")]
    public enum EditorKinds
    {
        /// <summary>
        /// 文本输入框
        /// </summary>
        [EnumField("文本输入框")]
        TextEdit,
        /// <summary>
        /// 数字输入框
        /// </summary>
        [EnumField("数字输入框")]
        SpinEdit,
        /// <summary>
        /// 日期输入框
        /// </summary>
        [EnumField("日期输入框")]
        DateEdit,
        /// <summary>
        /// 下拉选择框
        /// </summary>
        [EnumField("下拉选择框")]
        DropEdit,
        /// <summary>
        /// 自定义输入框
        /// </summary>
        [EnumField("自定义输入框")]
        Customer,

    }
}
