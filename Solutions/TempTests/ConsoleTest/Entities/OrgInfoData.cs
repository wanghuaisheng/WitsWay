/*******************************************
修改记录:
自动生成(2017-06-27):创建OrgInfoData
********************************************/

using System;
using WitsWay.TempTests.DynamicQuery.DataRights;

namespace WitsWay.TempTests.ConsoleTest.Entities
{
	/// <summary>
	/// 组织机构
	/// </summary>
	[Serializable]
	public class OrgInfoData : IKey
	{
		///<sumary>
		/// 机构Id
		///</sumary>
		public int OrgId { get; set; }
		///<sumary>
		/// 机构类型
		///</sumary>
		public int OrgType { get; set; }
		///<sumary>
		/// 机构名称
		///</sumary>
		public string OrgName { get; set; }
		///<sumary>
		/// 机构编码
		///</sumary>
		public string OrgCode { get; set; }
		///<sumary>
		/// 父级机构
		///</sumary>
		public int ParentId { get; set; }
		///<sumary>
		/// 所有父级Id
		///</sumary>
		public string ParentIds { get; set; }
		///<sumary>
		/// 直属公司Id
		///</sumary>
		public int DirectCorpId { get; set; }
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
		/// 标签
		///</sumary>
		public string Tags { get; set; }
		///<sumary>
		/// 额外信息
		///</sumary>
		public string Extras { get; set; }
		///<sumary>
		/// 额外信息解析器
		///</sumary>
		public string ExtrasParser { get; set; }
		///<sumary>
		/// 状态
		///</sumary>
		public int States { get; set; }
        
        /// <summary>
        /// 键【IKey实现】
        /// </summary>
        public string Key
        {
            get { return OrgId.ToString(); }
        }

	}
}
