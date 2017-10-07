/*******************************************
修改记录:
自动生成(2017-06-27):创建DataItemData
********************************************/

using System;
using WitsWay.TempTests.DynamicQuery.DataRights;

namespace WitsWay.TempTests.ConsoleTest.Entities
{
	/// <summary>
	/// 数据项
	/// </summary>
	[Serializable]
	public class DataItemData : IKey
	{
		///<sumary>
		/// 数据Id
		///</sumary>
		public int DataId { get; set; }
		///<sumary>
		/// 数据类型
		///</sumary>
		public int DataKind { get; set; }
		///<sumary>
		/// 验证类型
		///</sumary>
		public int ValidKind { get; set; }
		///<sumary>
		/// 名称
		///</sumary>
		public string DataName { get; set; }
		///<sumary>
		/// 目标实体
		///</sumary>
		public string TargetEntity { get; set; }
		///<sumary>
		/// 权限过滤器
		///</sumary>
		public string DataFilters { get; set; }
		///<sumary>
		/// 数据操作权限
		///</sumary>
		public string Rights { get; set; }
		///<sumary>
		/// 权限公式
		///</sumary>
		public string FilterFormula { get; set; }
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
		///<sumary>
		/// 权限类型
		///</sumary>
		public string RightKind { get; set; }
        
        /// <summary>
        /// 键【IKey实现】
        /// </summary>
        public string Key
        {
            get { return DataId.ToString(); }
        }

	}
}
