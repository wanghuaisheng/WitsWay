#region License(Apache Version 2.0)
/******************************************
 * Copyright ®2017-Now WangHuaiSheng.
 * Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file
 * except in compliance with the License. You may obtain a copy of the License at
 * http://www.apache.org/licenses/LICENSE-2.0
 * Unless required by applicable law or agreed to in writing, software distributed under the
 * License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
 * either express or implied. See the License for the specific language governing permissions
 * and limitations under the License.
 * Detail: https://github.com/WangHuaiSheng/WitsWay/LICENSE
 * ***************************************/
#endregion 
#region ChangeLog
/******************************************
 * 2017-10-7 OutMan Create
 * 
 * ***************************************/
#endregion
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

