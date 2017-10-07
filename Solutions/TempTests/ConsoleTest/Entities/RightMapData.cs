/*******************************************
修改记录:
自动生成(2017-06-27):创建RightMapData
********************************************/

using System;
using WitsWay.TempTests.DynamicQuery.DataRights;

namespace WitsWay.TempTests.ConsoleTest.Entities
{
	/// <summary>
	/// 权限图
	/// </summary>
	[Serializable]
	public class RightMapData : IKey
	{
		///<sumary>
		/// Id
		///</sumary>
		public int MapId { get; set; }
		///<sumary>
		/// 映射拥有者
		///</sumary>
		public int MapOwner { get; set; }
		///<sumary>
		/// 名称
		///</sumary>
		public string MapName { get; set; }
		///<sumary>
		/// 源类型
		///</sumary>
		public int SourceKind { get; set; }
		///<sumary>
		/// 源Id
		///</sumary>
		public int SourceId { get; set; }
		///<sumary>
		/// 目标类型
		///</sumary>
		public int TargetKind { get; set; }
		///<sumary>
		/// 目标Id
		///</sumary>
		public int TargetId { get; set; }
		///<sumary>
		/// 包含操作权限
		///</sumary>
		public string TargetRights { get; set; }
		///<sumary>
		/// 包含数据权限
		///</sumary>
		public string TargetDatas { get; set; }
		///<sumary>
		/// 包含资源标记
		///</sumary>
		public string TargetMarks { get; set; }
		///<sumary>
		/// 标签分组
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
            get { return MapId.ToString(); }
        }

	}
}
