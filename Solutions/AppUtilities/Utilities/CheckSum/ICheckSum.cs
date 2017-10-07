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
namespace WitsWay.Utilities.CheckSum
{
	/// <summary>
	/// 校验接口
	/// </summary>
	public interface ICheckSum
	{
		/// <summary>
		/// 校验值
		/// </summary>
		long Value{get;}

		/// <summary>
		/// 重置
		/// </summary>
		void Reset();

		/// <summary>
		/// 添加校验值
		/// </summary>
		/// <param name = "value">
		/// 要添加的校验值，高位忽略
		/// </param>
		void Update(int value);

		/// <summary>
		/// 更新校验值
		/// </summary>
		/// <param name="buffer">
		/// 字节数组
		/// </param>
		void Update(byte[] buffer);

		/// <summary>
		/// 添加校验字节数组
		/// </summary>
		/// <param name = "buffer">
		/// 字节数组
		/// </param>
		/// <param name = "offset">
		/// 左偏移量
		/// </param>
		/// <param name = "count">
		/// 用于计算的字节长度
		/// </param>
		void Update(byte[] buffer, int offset, int count);
	}
}
