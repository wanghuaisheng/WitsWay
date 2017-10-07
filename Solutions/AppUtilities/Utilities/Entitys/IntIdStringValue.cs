using System;

namespace WitsWay.Utilities.Entitys
{
    /// <summary>
    /// ID↔值
    /// </summary>
    [Serializable]
    public class IntIdStringValue
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public IntIdStringValue() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="val"></param>
        public IntIdStringValue(int id, string val) { Id = id; Value = val; }
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        public string Value { get; set; }
    }
}
