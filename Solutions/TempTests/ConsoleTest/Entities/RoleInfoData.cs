/*******************************************
修改记录:
自动生成(2017-06-27):创建RoleInfoData
********************************************/

using System;
using WitsWay.TempTests.DynamicQuery.DataRights;

namespace WitsWay.TempTests.ConsoleTest.Entities
{
	/// <summary>
	/// 角色信息
	/// </summary>
	[Serializable]
	public class RoleInfoData : IKey
	{
		///<sumary>
		/// 角色Id
		///</sumary>
		public int RoleId { get; set; }
		///<sumary>
		/// 角色类型
		///</sumary>
		public int RoleKind { get; set; }
		///<sumary>
		/// 角色名称
		///</sumary>
		public string RoleName { get; set; }
		///<sumary>
		/// 系统标识
		///</sumary>
		public int SystemId { get; set; }
		///<sumary>
		/// 企业Id
		///</sumary>
		public int CorporationId { get; set; }
		///<sumary>
		/// 是否全局
		///</sumary>
		public bool IsGlobal { get; set; }
		///<sumary>
		/// 是否管理员
		///</sumary>
		public bool IsSuper { get; set; }
		///<sumary>
		/// 父级角色Id
		///</sumary>
		public int ParentId { get; set; }
		///<sumary>
		/// 允许行为
		///</sumary>
		public int Allows { get; set; }
		///<sumary>
		/// 标签
		///</sumary>
		public string Tags { get; set; }
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
		/// 修改用户
		///</sumary>
		public int ModifyUserId { get; set; }
		///<sumary>
		/// 修改日期
		///</sumary>
		public DateTime ModifyTime { get; set; }
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
            get { return RoleId.ToString(); }
        }

	}
}
