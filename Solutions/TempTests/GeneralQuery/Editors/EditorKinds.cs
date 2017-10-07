using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralQuery.Editors
{
    /// <summary>
    /// 输入控件类型
    /// </summary>
    public enum EditorKinds
    {
        /// <summary>
        /// 文本输入框
        /// </summary>
        TextEdit,
        /// <summary>
        /// 数字输入框
        /// </summary>
        SpinEdit,
        /// <summary>
        /// 日期输入框
        /// </summary>
        DateEdit,
        /// <summary>
        /// 下拉选择框
        /// </summary>
        DropEdit,
        /// <summary>
        /// 自定义输入框
        /// </summary>
        Customer,

    }
}
