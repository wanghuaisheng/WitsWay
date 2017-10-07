using System;

namespace WitsWay.Utilities.Entitys
{
    /// <summary>
    /// ID↔值
    /// </summary>
    [Serializable]
    public class StringIdIntValue
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public StringIdIntValue(){}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="val"></param>
        public StringIdIntValue(string id, int val) { Id = id; Value = val; }
        /// <summary>
        /// 主键
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        public int Value { get; set; }
    }
}
