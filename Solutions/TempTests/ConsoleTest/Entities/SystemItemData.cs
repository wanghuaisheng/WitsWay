/*******************************************
修改记录:
自动生成(2017-06-27):创建SystemItemData
********************************************/

using System;
using WitsWay.TempTests.DynamicQuery.DataRights;

namespace WitsWay.TempTests.ConsoleTest.Entities
{
	/// <summary>
	/// 子系统项
	/// </summary>
	[Serializable]
	public class SystemItemData : IKey
	{
		///<sumary>
		/// 系统Id
		///</sumary>
		public int SystemId { get; set; }
		///<sumary>
		/// 类型
		///</sumary>
		public int SystemKind { get; set; }
		///<sumary>
		/// 名称
		///</sumary>
		public string SystemName { get; set; }
		///<sumary>
		/// 是否终端用户系统
		///</sumary>
		public bool IsEndUser { get; set; }
		///<sumary>
		/// 是否需要登录
		///</sumary>
		public bool NeedLogin { get; set; }
		///<sumary>
		/// 是否允许登录
		///</sumary>
		public bool AllowLogin { get; set; }
		///<sumary>
		/// 拒绝登录原因
		///</sumary>
		public string RefuseLoginReason { get; set; }
		///<sumary>
		/// 系统令牌名称
		///</sumary>
		public string SystemToken { get; set; }
		///<sumary>
		/// 系统图标
		///</sumary>
		public string SystemIcon { get; set; }
		///<sumary>
		/// 显示范围
		///</sumary>
		public int Displays { get; set; }
		///<sumary>
		/// 支持终端
		///</sumary>
		public int Terminals { get; set; }
		///<sumary>
		/// 支持功能
		///</sumary>
		public int Functions { get; set; }
		///<sumary>
		/// 标签
		///</sumary>
		public string Tags { get; set; }
		///<sumary>
		/// 额外信息
		///</sumary>
		public string Extras { get; set; }
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
            get { return SystemId.ToString(); }
        }

	}
}
