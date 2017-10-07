/*******************************************
修改记录:
自动生成(2017-06-27):创建RightItemData
********************************************/

using System;
using WitsWay.TempTests.DynamicQuery.DataRights;

namespace WitsWay.TempTests.ConsoleTest.Entities
{
	/// <summary>
	/// 权限项
	/// </summary>
	[Serializable]
	public class RightItemData : IKey
	{
		///<sumary>
		/// 权限Id
		///</sumary>
		public int RightId { get; set; }
		///<sumary>
		/// 权限类型
		///</sumary>
		public int RightKind { get; set; }
		///<sumary>
		/// 权限码
		///</sumary>
		public string RightCode { get; set; }
		///<sumary>
		/// 权限名
		///</sumary>
		public string RightName { get; set; }
		///<sumary>
		/// 图标
		///</sumary>
		public string RightIcon { get; set; }
		///<sumary>
		/// 系统标识
		///</sumary>
		public int SystemId { get; set; }
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
            get { return RightId.ToString(); }
        }

	}
}
