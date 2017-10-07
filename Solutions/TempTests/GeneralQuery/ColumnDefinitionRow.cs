using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using WitsWay.Utilities.Supports.TreeSupport;

namespace WitsWay.TempTests.GeneralQuery
{

    /// <summary>
    /// 定义jQuery Query Builder需要的列定义
    /// </summary>
    [ExcludeFromCodeCoverage]
    [DataContract]
    public class ColumnDefinitionRow:TreeSupport<ColumnDefinitionRow>
    {
        /// <summary>
        /// 唯一标识
        /// </summary>
        [DataMember]
        public string Id { get; set; }
        /// <summary>
        /// 父级Id
        /// </summary>
        public string ParentId { get; set; }
        /// <summary>
        /// 行类型
        /// </summary>
        public ColumnRowKinds RowKind { get; set; }
        /// <summary>
        /// 排序码
        /// </summary>
        public int SortCode { get; set; }
        /// <summary>
        /// 标签
        /// </summary>
        [DataMember]
        public string Label { get; set; }

        /// <summary>
        /// 字段名（对应属性名）
        /// </summary>
        [DataMember]
        public string Field { get; set; }

        /// <summary>
        /// 数据类型（double、string、interger、date等）
        /// </summary>
        [DataMember]
        public string ValueType { get; set; }

        /// <summary>
        /// 输入控件，支持自定义控件
        /// </summary>
        [DataMember]
        public string Input { get; set; }

        /// <summary>
        /// 是否支持录入多行
        /// </summary>
        [DataMember]
        public bool MultiRow { get; set; }

        /// <summary>
        /// 输入掩码
        /// </summary>
        public string Mask { get; set; }

        public string NullText { get; set; }


        /// <summary>
        /// 是否允许空值
        /// </summary>
        public bool AllowNull { get; set; }

        /// <summary>
        /// 是否允许为空
        /// </summary>
        public bool AllowEmpty { get; set; }
        
        /// <summary>
        /// 值，多个值用逗号分隔
        /// </summary>
        [DataMember]
        public string Values { get; set; }
        /// <summary>
        /// 操作符（不同类型字段支持不同操作符，比如数字支持between，但是字符串不支持）
        /// </summary>
        [DataMember]
        public List<string> SupportOperates { get; set; }

        public string SelectedOperate { get; set; }

        /// <summary>
        /// 格式化模板
        /// </summary>
        [DataMember]
        public string Template { get; set; }


        #region [TreeSupport]

        /// <summary>
        /// 节点Id
        /// </summary>
        public override string NodeId => Id;

        /// <summary>
        /// 父节点Id
        /// </summary>
        public override string NodeParentId => ParentId;

        #endregion

    }
}
