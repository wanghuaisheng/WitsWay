using System.Collections.Generic;

namespace GeneralQuery.Entities
{

    /// <summary>
    /// 实体数据源
    /// </summary>
    public class EntityDataInfo
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 实体类型
        /// </summary>
        public string EntityType { get; set; }
        /// <summary>
        /// 实体程序集
        /// </summary>
        public string EntityAssembly { get; set; }
        /// <summary>
        /// 属性字段列表
        /// </summary>
        public List<EntityFieldInfo> Fields { get; set; }



    }

}
