using WitsWay.Utilities.Attributes;

namespace WitsWay.TempTests.GeneralQuery.Models
{
    /// <summary>
    /// 性别枚举
    /// </summary>
    [EnumField("性别")]
    public enum GenderType
    {
        /// <summary>
        /// 男
        /// </summary>
        [EnumField("男")]
        Male = 0,
        /// <summary>
        /// 女
        /// </summary>
        [EnumField("女")]
        Female = 1,
    }
}
