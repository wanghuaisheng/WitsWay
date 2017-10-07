/*******************************************
修改记录:
自动生成(2017-06-27):创建EmployeeInfoData
********************************************/

using System;
using WitsWay.TempTests.DynamicQuery.DataRights;

namespace WitsWay.TempTests.ConsoleTest.Entities
{
	/// <summary>
	/// 雇员信息
	/// </summary>
	[Serializable]
	public class EmployeeInfoData : IKey
	{
		///<sumary>
		/// 机构Id
		///</sumary>
		public int EmployeeId { get; set; }
		///<sumary>
		/// 机构类型
		///</sumary>
		public int EmployeeKind { get; set; }
		///<sumary>
		/// 所属机构Id
		///</sumary>
		public int OrgId { get; set; }
		///<sumary>
		/// 入职时间
		///</sumary>
		public DateTime JoinTime { get; set; }
		///<sumary>
		/// 职级
		///</sumary>
		public int JobLevel { get; set; }
		///<sumary>
		/// 职位
		///</sumary>
		public int JobPosition { get; set; }
		///<sumary>
		/// 工作
		///</sumary>
		public string JobWork { get; set; }
		///<sumary>
		/// 租户Id
		///</sumary>
		public int TenantId { get; set; }
		///<sumary>
		/// 标签
		///</sumary>
		public string Tags { get; set; }
		///<sumary>
		/// 状态
		///</sumary>
		public int States { get; set; }
        
        /// <summary>
        /// 键【IKey实现】
        /// </summary>
        public string Key
        {
            get { return EmployeeId.ToString(); }
        }

	}
}
