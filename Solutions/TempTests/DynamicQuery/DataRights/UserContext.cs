namespace WitsWay.TempTests.DynamicQuery.DataRights
{
    /// <summary>
    /// 用户上下文
    /// </summary>
    public class UserContext
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 租户Id
        /// </summary>
        public int TenantId { get; set; }
        /// <summary>
        /// 企业Id
        /// </summary>
        public int CorpId { get; set; }
        /// <summary>
        /// 部门Id
        /// </summary>
        public int DeptId { get; set; }
        /// <summary>
        /// 职级（比如 “高级”软件工程师）
        /// </summary>
        public int JobLevel { get; set; }
        /// <summary>
        /// 职位（比如 高级“软件工程师”）
        /// </summary>
        public int JobPostion { get; set; }
        /// <summary>
        /// 职称（职称=职位+职级）
        /// </summary>
        public int JobTitle { get; set; }
        /// <summary>
        /// 工作（比如 “软件开发”）
        /// </summary>
        public int JobWorks { get; set; }
        /// <summary>
        /// 员工类型
        /// </summary>
        public int EmployeeKind { get; set; }


    }
}
