using System;

namespace WitsWay.TempTests.DynamicQuery.DataRights
{
    /// <summary>
    /// 权限上下文类型
    /// </summary>
    [Flags]
    public enum RightContextKinds
    {
        /// <summary>
        /// 我的
        /// </summary>
        My=1,
        /// <summary>
        /// 我的部门
        /// </summary>
        MyDept=2,
        /// <summary>
        /// 我的公司
        /// </summary>
        MyCorp=4,
        /// <summary>
        /// 我的职级（高级、中级、初级…）
        /// </summary>
        MyJobLevel,
        /// <summary>
        /// 我的职位（设计师、技工、软件开发工程师…）
        /// </summary>
        JobPostion,
        /// <summary>
        /// 我的工作（生产、包装、设计、安装…）
        /// </summary>
        MyJobWorks,
        /// <summary>
        /// 我的员工类型（试用、正式、实习、外聘…）
        /// </summary>
        MyEmployeeKind
    }
}
