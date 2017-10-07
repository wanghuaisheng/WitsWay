using System;

namespace WitsWay.TempTests.DynamicQuery.Enums
{
    /// <summary>
    /// 支持
    /// </summary>
    [Flags]
    public enum SupportRelations
    {
        IsNull = 1,
        IsNotNull = 1 << 1,
        IsEmpty = 1 << 2,
        IsNotEmpty = 1 << 3,
        Contains = 1 << 4,
        NotContains = 1 << 5,
        EndsWith = 1 << 6,
        NotEndsWith = 1 << 7,
        StartsWith = 1 << 8,
        NotStartsWith = 1 << 9,
        Equals = 1 << 10,
        NotEquals = 1 << 11,
        LessThan = 1 << 12,
        LessThanOrEqual = 1 << 13,
        GreaterThan = 1 << 14,
        GreaterThanOrEqual = 1 << 15,
        Between = 1 << 16,
        NotBetween = 1 << 17,
        In = 1 << 18,
        NotIn = 1 << 19,

    }
}
