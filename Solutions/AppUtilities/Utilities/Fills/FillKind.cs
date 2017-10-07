using WitsWay.Utilities.Attributes;

namespace WitsWay.Utilities.Fills
{
    /// <summary>
    /// 填充数据类型
    /// </summary>
    [EnumDescription("填充数据类型")]
    public enum FillKind
    {
        /// <summary>
        /// 人员名称
        /// </summary>
        [EnumDescription("人员名称")]
        EmployeeName,
        /// <summary>
        /// 人员名称组，逗号分隔
        /// </summary>
        [EnumDescription("人员名称组")]
        EmployeeNames,
        /// <summary>
        /// 组名
        /// </summary>
        [EnumDescription("组名")]
        GroupName,
        /// <summary>
        /// 组编码
        /// </summary>
        [EnumDescription("组编码")]
        GroupCode,
        /// <summary>
        /// 省名称
        /// </summary>
        [EnumDescription("省名称")]
        ProvenceName,
        /// <summary>
        /// 城市名称
        /// </summary>
        [EnumDescription("城市名称")]
        CityName,
        /// <summary>
        /// 地区名称
        /// </summary>
        [EnumDescription("地区名称")]
        RegionName,
        /// <summary>
        /// 菜单模块名称
        /// </summary>
        [EnumDescription("菜单模块名称")]
        MenuModuleName
    }
}
