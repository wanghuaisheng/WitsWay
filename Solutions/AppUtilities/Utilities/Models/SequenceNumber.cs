/*******************************************
修改记录:
自动生成(2012-05-24):创建Sequence
********************************************/

using System;
using WitsWay.Utilities.Enums;

namespace WitsWay.Utilities.Models
{
	/// <summary>
	/// 系统序列号管理表
	/// </summary>
	[Serializable]
	public class SequenceNumber
	{
		///<sumary>
		/// 序列唯一标识
		///</sumary>
        public string SequenceId { get; set; }
		///<sumary>
		/// 序列当前值
		///</sumary>
        public long? SequenceValue { get; set; }
		///<sumary>
		/// 序列步长
		///</sumary>
        public int SequenceStep { get; set; }
		///<sumary>
		/// 序列初始值
		///</sumary>
        public long SequenceInit { get; set; }
		///<sumary>
		/// 序列周期
		///</sumary>
        public SequenceCircle SequenceCircle { get; set; }
		///<sumary>
		/// 序列最后更新时间
		///</sumary>
		public DateTime UpdateTime { get; set; }
	}
}

