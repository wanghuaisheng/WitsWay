using System;

namespace WitsWay.Utilities.Errors
{
    /// <summary>
    /// 错误信息工厂
    /// </summary>
    public static class ErrorItemExtends
    {
        /// <summary>
        /// 取错误码
        /// </summary>
        public static long GetErrorCode(this Enum err, ErrorSystems sys)
        {
            return ErrorItemFactory.GetErrorCode(sys, err);
        }
        /// <summary>
        /// 取错误描述
        /// </summary>
        public static string GetErrorText(this Enum err)
        {
            return ErrorItemAttribute.GetFieldText(err);
        }
    }
}
