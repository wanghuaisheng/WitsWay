using System.Collections.Generic;

namespace WitsWay.TempTests.DynamicQuery.Entities
{

    /// <summary>
    /// 实体数据源
    /// </summary>
    public class EntityDataSource
    {
        /// <summary>
        /// 主键
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 实体类型
        /// </summary>
        public string EntityType { get; set; }
        /// <summary>
        /// 属性字段列表
        /// </summary>
        public List<PropertyField> PropertyFields { get; set; }

        /// <summary>
        /// 是否支持客户端筛选
        /// </summary>
        public bool SupportClientFilter { get; set; }

        /// <summary>
        /// 是否支持权限筛选
        /// </summary>
        public bool SupportRightFilter { get; set; }


    }

}
