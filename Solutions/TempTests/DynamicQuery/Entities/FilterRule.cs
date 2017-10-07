using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace WitsWay.TempTests.DynamicQuery.Entities
{

    /// <summary>
    /// 定义针对一个集合的分级的过滤器
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class FilterRule
    {
        /// <summary>
        /// 标识
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 条件（支持"and"、"or）
        /// </summary>
        public string Condition { get; set; }
        /// <summary>
        /// 字段（过滤器将应用到的属性名称）
        /// </summary>
        public string Field { get; set; }
        /// <summary>
        /// 输入控件（比如TextBox、ComboBox）
        /// </summary>
        public string Input { get; set; }  
        /// <summary>
        /// 字段类型（ "integer", "double", "string", "date", "datetime", "boolean"）
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// 操作符
        /// </summary>
        public string Operator { get; set; }
        /// <summary>
        /// 嵌套规则
        /// </summary>
        public List<FilterRule> Rules { get; set; }

    }
}
