namespace WitsWay.Utilities.Entitys
{
    /// <summary>
    /// 批量插入结果
    /// </summary>
    public struct BulkInsertResult
    {
        /// <summary>
        /// 最大自增Id
        /// </summary>
        public int MaxIdentity { get; set; }
        /// <summary>
        /// 行数
        /// </summary>
        public int RowCount { get; set; }
        /// <summary>
        /// 取得对应索引的Id，从0开始
        /// </summary>
        /// <param name="idx">索引序号</param>
        /// <returns>对应索引的Id，从0开始，不存在则返回-1</returns>
        public int this[int idx]
        {
            //实现索引器的get方法
            get
            {
                return idx < RowCount ? MaxIdentity - RowCount + 1 + idx : -1;
            }
        }
    }
}