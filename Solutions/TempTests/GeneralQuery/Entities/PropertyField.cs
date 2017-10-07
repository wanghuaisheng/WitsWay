namespace GeneralQuery.Entities
{
    public class PropertyField
    {
        public string Name { get; set; }

        public string Title { get; set; }
        /// <summary>
        /// 编辑器
        /// </summary>
        public string Editor { get; set; }

        /// <summary>
        /// 数据类型
        /// </summary>
        public string DataKind { get; set; }
        /// <summary>
        /// 数据范围
        /// </summary>
        public string DataScope { get; set; }


    }
}
