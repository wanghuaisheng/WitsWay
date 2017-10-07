/*******************************************
修改记录:
自动生成(2017-06-27):创建ModuleItemData
********************************************/

using System;
using WitsWay.TempTests.DynamicQuery.DataRights;

namespace WitsWay.TempTests.ConsoleTest.Entities
{
	/// <summary>
	/// 模块页面项
	/// </summary>
	[Serializable]
	public class ModuleItemData : IKey
	{
		///<sumary>
		/// 模块Id
		///</sumary>
		public int ModuleId { get; set; }
		///<sumary>
		/// 模块类型
		///</sumary>
		public int ModuleKind { get; set; }
		///<sumary>
		/// 模块名称
		///</sumary>
		public string ModuleName { get; set; }
		///<sumary>
		/// 模块编码
		///</sumary>
		public string ModuleCode { get; set; }
		///<sumary>
		/// 菜单路径
		///</sumary>
		public string ModulePath { get; set; }
		///<sumary>
		/// 菜单图标
		///</sumary>
		public string ModuleIcon { get; set; }
		///<sumary>
		/// 是否是菜单
		///</sumary>
		public bool IsMenu { get; set; }
		///<sumary>
		/// 上级Id
		///</sumary>
		public int ParentId { get; set; }
		///<sumary>
		/// 页面所有操作权限
		///</sumary>
		public string Rights { get; set; }
		///<sumary>
		/// 页面所有数据权限
		///</sumary>
		public string Datas { get; set; }
		///<sumary>
		/// 页面所有权限标记
		///</sumary>
		public string Marks { get; set; }
		///<sumary>
		/// 标签
		///</sumary>
		public string Tags { get; set; }
		///<sumary>
		/// 所属子系统
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
            get { return ModuleId.ToString(); }
        }

	}
}
