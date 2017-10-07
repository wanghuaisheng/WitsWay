using WitsWay.Utilities.Attributes;

namespace WitsWay.Utilities.Fills
{
    /// <summary>
    /// 填充数据类型
    /// </summary>
    [EnumFieldAttribute("填充数据类型")]
    public enum FillKind
    {
        /// <summary>
        /// 人员名称
        /// </summary>
        [EnumFieldAttribute("人员名称")]
        EmployeeName,
        /// <summary>
        /// 人员名称组，逗号分隔
        /// </summary>
        [EnumFieldAttribute("人员名称组")]
        EmployeeNames,
        /// <summary>
        /// 组名
        /// </summary>
        [EnumFieldAttribute("组名")]
        GroupName,
        /// <summary>
        /// 组编码
        /// </summary>
        [EnumFieldAttribute("组编码")]
        GroupCode,
        /// <summary>
        /// 省名称
        /// </summary>
        [EnumFieldAttribute("省名称")]
        ProvenceName,
        /// <summary>
        /// 城市名称
        /// </summary>
        [EnumFieldAttribute("城市名称")]
        CityName,
        /// <summary>
        /// 地区名称
        /// </summary>
        [EnumFieldAttribute("地区名称")]
        RegionName,
        /// <summary>
        /// 菜单模块名称
        /// </summary>
        [EnumFieldAttribute("菜单模块名称")]
        MenuModuleName
    }
}
