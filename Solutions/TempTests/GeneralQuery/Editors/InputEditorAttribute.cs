using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralQuery.Editors
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
