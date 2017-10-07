using System;

namespace WitsWay.Utilities.Entitys
{
    /// <summary>
    /// ID↔值
    /// </summary>
    [Serializable]
    public class IntIdIntValue
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public IntIdIntValue() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="val"></param>
        public IntIdIntValue(int id, int val) { Id = id; Value = val; }
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        public int Value { get; set; }
    }
}
