/*******************************************
修改记录:
自动生成(2017-06-19):创建ModuleItemData
********************************************/

using System;
using WitsWay.TempTests.ConsoleTest.Enums;
using WitsWay.TempTests.DynamicQuery.DataRights;

namespace WitsWay.TempTests.ConsoleTest
{
    /// <summary>
    /// 模块页面项
    /// </summary>
    [Serializable]
    //[RightContext(RightContextKinds.My | RightContextKinds.MyDept)]
    public class Employee : IKey //, IOwnCompany, IOwnDepartment, IOwnUser
    {
        ///<sumary>
        /// 模块Id
        ///</sumary>
        public int EmployeeId { get; set; }
        ///<sumary>
        /// 模块类型
        ///</sumary>
        public Sex Sex { get; set; }

        ///<sumary>
        /// 模块名称
        ///</sumary>
        public string Name { get; set; }
        ///<sumary>
        /// 是否加入
        ///</sumary>
        public bool IsJoin { get; set; }
        ///<sumary>
        /// 上级Id
        ///</sumary>
        public int Age { get; set; }

        /// <summary>
        /// 学校
        /// </summary>
        public string School { get; set; }

        ///<sumary>
        /// 创建日期
        ///</sumary>
        public DateTime BirthDay { get; set; }

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
        public EmployeeStatus States { get; set; }
    
        /// <summary>
        /// 创建用户Id
        /// </summary>
        public int CreateUserId { get; set; }
        /// <summary>
        /// 键【IKey实现】
        /// </summary>
        public string Key
        {
            get { return EmployeeId.ToString(); }
        }

        ///// <summary>
        ///// 拥有公司Id
        ///// </summary>
        ////[FillTarget]
        //public int OwnCompanyId
        //{
        //    get { return 1; }
        //}
        ///// <summary>
        ///// 拥有部门Id
        ///// </summary>
        ////[FillTarget]
        //public int OwnDepartentId
        //{
        //    get { return 11; }
        //}
        ///// <summary>
        ///// 拥有用户Id
        ///// </summary>
        ////[FillSource]
        //public int OwnUserId
        //{
        //    get { return 2; }
        //}
    }
}
