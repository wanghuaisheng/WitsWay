/*******************************************
修改记录:
自动生成(2017-06-27):创建DataFilterItemData
********************************************/

using System;
using WitsWay.TempTests.DynamicQuery.DataRights;

namespace WitsWay.TempTests.ConsoleTest.Entities
{
	/// <summary>
	/// 数据筛选项
	/// </summary>
	[Serializable]
	public class DataFilterItemData : IKey
	{
		///<sumary>
		/// Id
		///</sumary>
		public int FilterId { get; set; }
		///<sumary>
		/// 类型
		///</sumary>
		public int FilterKind { get; set; }
		///<sumary>
		/// 名称
		///</sumary>
		public string FilterName { get; set; }
		///<sumary>
		/// 目标字段数据类型
		///</sumary>
		public int TargetFieldDataType { get; set; }
		///<sumary>
		/// 目标字段值提供者
		///</sumary>
		public string TargetFieldValueProvider { get; set; }
		///<sumary>
		/// 目标字段值1
		///</sumary>
		public string TargetFieldValue1 { get; set; }
		///<sumary>
		/// 目标字段值2
		///</sumary>
		public string TargetFieldValue2 { get; set; }
		///<sumary>
		/// 租户Id
		///</sumary>
		public int TenantId { get; set; }
		///<sumary>
		/// 创建日期
		///</sumary>
		public DateTime CreateTime { get; set; }
		///<sumary>
		/// 创建用户
		///</sumary>
		public int CreateUserId { get; set; }
		///<sumary>
		/// 修改日期
		///</sumary>
		public DateTime ModifyTime { get; set; }
		///<sumary>
		/// 修改用户
		///</sumary>
		public int ModifyUserId { get; set; }
		///<sumary>
		/// 排序码
		///</sumary>
		public int SortCode { get; set; }
		///<sumary>
		/// 备注
		///</sumary>
		public string Remark { get; set; }
		///<sumary>
		/// 状态
		///</sumary>
		public int States { get; set; }
        
        /// <summary>
        /// 键【IKey实现】
        /// </summary>
        public string Key
        {
            get { return FilterId.ToString(); }
        }

	}
}
