namespace WitsWay.Utilities.Validate
{

    /// <summary>
    /// 验证错误码
    /// </summary>
    public static class ValidationErrorCode
    {

        /// <summary>
        /// 
        /// </summary>
        public const int StringIsEmpty = 101;

        /// <summary>
        /// 
        /// </summary>
        public const int StringIsLength = 102;

        /// <summary>
        /// 
        /// </summary>
        public const int StringIsLongerThan = 103;

        /// <summary>
        /// 
        /// </summary>
        public const int StringIsShorterThan = 104;

        /// <summary>
        /// 
        /// </summary>
        public const int StringMatchRegex = 105;

        /// <summary>
        /// 
        /// </summary>
        public const int StringIsEmail = 106;

        /// <summary>
        /// 
        /// </summary>
        public const int StringIsURL = 107;

        /// <summary>
        /// 
        /// </summary>
        public const int StringIsDate = 108;

        /// <summary>
        /// 
        /// </summary>
        public const int StringIsInteger = 109;

        /// <summary>
        /// 
        /// </summary>
        public const int StringIsDecimal = 110;

        /// <summary>
        /// 
        /// </summary>
        public const int IsLengthBetween = 111;

        /// <summary>
        /// 
        /// </summary>
        public const int StringStartsWith = 112;

        /// <summary>
        /// 
        /// </summary>
        public const int StringEndsWith = 113;

        /// <summary>
        /// 
        /// </summary>
        public const int StringContains = 114;

        /// <summary>
        /// 
        /// </summary>
        public const int StringIsLong = 115;

        /// <summary>
        /// 
        /// </summary>
        public const int StringIsNullOrEmpty = 117;

        /// <summary>
        /// 
        /// </summary>
        public const int StringIsNotNullOrEmpty = 118;

        /// <summary>
        /// 
        /// </summary>
        public const int NumericIsLessThanOrEqual = 201;

        /// <summary>
        /// 
        /// </summary>
        public const int NumericIsGreaterThanOrEqual = 202;

        /// <summary>
        /// 
        /// </summary>
        public const int NumericIsGreaterThan = 203;

        /// <summary>
        /// 
        /// </summary>
        public const int NumericIsLessThan = 204;

        /// <summary>
        /// 
        /// </summary>
        public const int NumericEquals = 205;

        /// <summary>
        /// 
        /// </summary>
        public const int NumericBetween = 206;

        /// <summary>
        /// 
        /// </summary>
        public const int NumericIsZero = 207;

        /// <summary>
        /// 
        /// </summary>
        public const int NumericNotInList = 208;

        /// <summary>
        /// 
        /// </summary>
        public const int DateIsNotMinValue = 302;

        /// <summary>
        /// 
        /// </summary>
        public const int DateIsNotMaxValue = 303;

        /// <summary>
        /// 
        /// </summary>
        public const int DateIsEarlierThan = 304;

        /// <summary>
        /// 
        /// </summary>
        public const int DateIsLaterThan = 305;

        /// <summary>
        /// 
        /// </summary>
        public const int DateBetween = 306;

        /// <summary>
        /// 有效的SQL时间
        /// </summary>
        public const int DateValidSqlServerDateTime = 307;

        /// <summary>
        /// 
        /// </summary>
        public const int BoolIsNotTrue = 401;

        /// <summary>
        /// 
        /// </summary>
        public const int BoolIsNotFalse = 402;

        /// <summary>
        /// 
        /// </summary>
        public const int CustomErrorCode = 999;

    }

}
