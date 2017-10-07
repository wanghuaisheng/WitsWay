/*******************************************
修改记录:
自动生成(2017-06-27):创建UserInfoData
********************************************/

using System;
using WitsWay.TempTests.DynamicQuery.DataRights;

namespace WitsWay.TempTests.ConsoleTest.Entities
{
	/// <summary>
	/// 用户信息
	/// </summary>
	[Serializable]
	public class UserInfoData : IKey
	{
		///<sumary>
		/// 用户Id
		///</sumary>
		public int UserId { get; set; }
		///<sumary>
		/// 类型
		///</sumary>
		public int UserKind { get; set; }
		///<sumary>
		/// 用户名
		///</sumary>
		public string UserName { get; set; }
		///<sumary>
		/// 昵称
		///</sumary>
		public string NickName { get; set; }
		///<sumary>
		/// 头像
		///</sumary>
		public string UserAvatar { get; set; }
		///<sumary>
		/// 手机号
		///</sumary>
		public string Phone { get; set; }
		///<sumary>
		/// 电子邮件
		///</sumary>
		public string Email { get; set; }
		///<sumary>
		/// 原始密码
		///</sumary>
		public string PasswordOriginal { get; set; }
		///<sumary>
		/// 加密后密码
		///</sumary>
		public string PasswordEncrypted { get; set; }
		///<sumary>
		/// 加密盐渍
		///</sumary>
		public string PasswordSalt { get; set; }
		///<sumary>
		/// 是否超级管理员
		///</sumary>
		public bool IsSuper { get; set; }
		///<sumary>
		/// 员工Id
		///</sumary>
		public int EmployeeId { get; set; }
		///<sumary>
		/// Session令牌
		///</sumary>
		public string SessionToken { get; set; }
		///<sumary>
		/// 最后登录时间
		///</sumary>
		public DateTime LastLoginTime { get; set; }
		///<sumary>
		/// 最后登录Ip
		///</sumary>
		public string LastLoginIp { get; set; }
		///<sumary>
		/// 最后登录终端
		///</sumary>
		public string LastLoginTerminal { get; set; }
		///<sumary>
		/// 最后登录令牌
		///</sumary>
		public string LastLoginToken { get; set; }
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
		/// 状态
		///</sumary>
		public int States { get; set; }
        
        /// <summary>
        /// 键【IKey实现】
        /// </summary>
        public string Key
        {
            get { return UserId.ToString(); }
        }

	}
}
