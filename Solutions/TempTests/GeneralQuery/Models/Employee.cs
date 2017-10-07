using System;
using WitsWay.TempTests.DynamicQuery.Attributes;
using WitsWay.Utilities.Supports;

namespace WitsWay.TempTests.GeneralQuery.Models
{
    /// <summary>
    /// 职员信息
    /// </summary>
    [EntityData("职员信息")]
    [Serializable]
    public class Employee:IKey
    {

        #region [Property]

        ///<sumary>
        /// 职员ID
        ///</sumary>
        [EntityField("职员ID")]
        public int EmployeeId { get; set; }

        ///<sumary>
        /// 组织机构ID
        ///</sumary>
        [EntityField("组织机构ID")]
        public int OrgId { get; set; }
        ///<sumary>
        /// 企业ID
        ///</sumary>
        [EntityField("企业ID")]
        public int CorpId { get; set; }
        ///<sumary>
        /// 企业类型
        ///</sumary>
        [EntityField("企业类型")]
        public CorporationType CorpType { get; set; }
        ///<sumary>
        /// 工号
        ///</sumary>
        [EntityField("工号")]
        public string JobCode { get; set; }
        ///<sumary>
        /// 操作员编码(必选)
        ///</sumary>
        [EntityField("操作员编码")]
        public string OperatorCode { get; set; }
        ///<sumary>
        /// 用户密码
        ///</sumary>
        [EntityField("用户密码")]
        public string UserPassword { get; set; }
        ///<sumary>
        /// 职员姓名
        ///</sumary>
        [EntityField("职员姓名")]
        public string EmployeeName { get; set; }

        /// <summary>
        /// 全拼
        /// </summary>
        public string FullSpell { get; set; }

        /// <summary>
        /// 简拼
        /// </summary>
        public string ShortSpell { get; set; }

        ///<sumary>
        /// 性别
        ///</sumary>
        public GenderType Gender { get; set; }
        ///<sumary>
        /// 身份证号
        ///</sumary>
        public string IdCard { get; set; }
        ///<sumary>
        /// 出生日期
        ///</sumary>
        [EntityField("生日")]
        public DateTime? Birthday { get; set; }
        ///<sumary>
        /// 籍贯
        ///</sumary>
        public string NativePlace { get; set; }
        ///<sumary>
        /// 民族ID
        ///</sumary>
        public int? NationalityId { get; set; }
        ///<sumary>
        /// 政治面貌ID
        ///</sumary>
        [EntityField("政治面貌ID")]
        public int? PartyId { get; set; }
        ///<sumary>
        /// 家庭住址
        ///</sumary>
        public string HomeAddress { get; set; }
        ///<sumary>
        /// 电话
        ///</sumary>
        public string Telephone { get; set; }
        ///<sumary>
        /// 手机
        ///</sumary>
        public string Mobile { get; set; }
        ///<sumary>
        /// 短号
        ///</sumary>
        public string ShortNumber { get; set; }
        ///<sumary>
        /// 电子邮件
        ///</sumary>
        public string Email { get; set; }
        ///<sumary>
        /// 紧急联系人
        ///</sumary>
        public string FirstContactPerson { get; set; }
        ///<sumary>
        /// 紧急联系人电话
        ///</sumary>
        public string FirstContactPersonPhone { get; set; }
        ///<sumary>
        /// 是否允许登录
        ///</sumary>
        public bool AllowLogin { get; set; }
        ///<sumary>
        /// 是否是操作员
        ///</sumary>
        public bool IsOperator { get; set; }
        ///<sumary>
        /// 排序码
        ///</sumary>
        public int SortCode { get; set; }
        ///<sumary>
        /// 照片路径
        ///</sumary>
        public string PhotoPath { get; set; }
        ///<sumary>
        /// 备注
        ///</sumary>
        public string Description { get; set; }
        ///<sumary>
        /// 学历ID
        ///</sumary>
        public int? QualificationId { get; set; }

        ///<sumary>
        /// 毕业院校
        ///</sumary>
        public string GraduateSchool { get; set; }

        ///<sumary>
        /// 专业
        ///</sumary>
        public string Professional { get; set; }

        ///<sumary>
        /// 技能证书
        ///</sumary>
        public string SkillsCertificate { get; set; }

        ///<sumary>
        /// 档案号
        ///</sumary>
        public string FileNumber { get; set; }

        ///<sumary>
        /// 合同类型ID
        ///</sumary>
        public int? ContractTypeId { get; set; }

        ///<sumary>
        /// 合同起始日期
        ///</sumary>
        public DateTime? ContractStartDate { get; set; }

        ///<sumary>
        /// 合同结束日期
        ///</sumary>
        public DateTime? ContractEndDate { get; set; }

        ///<sumary>
        /// 合同数
        ///</sumary>
        public int? SignContractNumber { get; set; }

        ///<sumary>
        /// 入职日期
        ///</sumary>
        public DateTime? EntryDate { get; set; }

        ///<sumary>
        /// 转正日期
        ///</sumary>
        public DateTime? PositiveDate { get; set; }

        ///<sumary>
        /// 离职日期
        ///</sumary>
        public DateTime? QuitDate { get; set; }

        ///<sumary>
        /// 在职状态
        ///</sumary>
        public int? JobState { get; set; }

        ///<sumary>
        /// 现住地址
        ///</sumary>
        public string Address { get; set; }

        ///<sumary>
        /// 婚姻状态ID
        ///</sumary>
        public int? MaritalStatusId { get; set; }

        ///<sumary>
        /// 最后一次登录时间
        ///</sumary>
        public DateTime? LastLoginDateTime { get; set; }

        ///<sumary>
        /// 最后一次登录IP
        ///</sumary>
        public string LastLoginIp { get; set; }
        ///<sumary>
        /// 是否删除
        ///</sumary>
        [EntityField("是否删除")]
        public bool IsDeleted { get; set; }
        ///<sumary>
        /// 创建日期
        ///</sumary>
        [EntityField("创建日期")]
        public DateTime CreateTime { get; set; }
        ///<sumary>
        /// 创建用户主键
        ///</sumary>
        public int CreateUserId { get; set; }
        ///<sumary>
        /// 创建用户
        ///</sumary>
        public string CreateUserName { get; set; }
        ///<sumary>
        /// 修改日期
        ///</sumary>
        public DateTime ModifyTime { get; set; }
        ///<sumary>
        /// 修改用户主键
        ///</sumary>
        public int ModifyUserId { get; set; }
        ///<sumary>
        /// 修改用户
        ///</sumary>
        public string ModifyUserName { get; set; }

        #endregion

        #region  Custom

        /// <summary>
        /// 岗位列表
        /// </summary>
        public string PositionListString { get; set; }

        /// <summary>
        /// 学历
        /// </summary>
        public string QualificationName { get; set; }
        /// <summary>
        /// 入职日期字符串
        /// </summary>
        public string EntryDateString { get; set; }

        ///<sumary>
        /// 合同起始日期
        ///</sumary>
        public string ContractStartDateString { get; set; }

        ///<sumary>
        /// 合同结束日期
        ///</sumary>
        public string ContractEndDateString { get; set; }

        ///<sumary>
        /// 转正日期
        ///</sumary>
        public string PositiveDateString { get; set; }

        ///<sumary>
        /// 离职日期
        ///</sumary>
        public string QuitDateString { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }

        #endregion


        public string Key => EmployeeId.ToString();
    }
}
