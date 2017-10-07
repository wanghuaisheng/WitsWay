using System;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using WitsWay.Utilities.Errors;

namespace WitsWay.Utilities.Helpers
{

    /// <summary>
    /// 异常助手
    /// <para>封装了一些异常抛出辅助方法</para>
    /// </summary>
    public partial class ExceptionHelper
    {

        /// <summary>
        /// 记录/抛出业务异常
        /// </summary>
        /// <param name="err">错误枚举</param>
        /// <param name="ex">原始异常,异常信息会写入日志</param>
        /// <param name="paras">格式化参数</param>
        public static void ThrowBusinessException(Enum err, Exception ex, params string[] paras)
        {
            if (ex != null) Logger.Write(ex);
            ThrowBusinessException(err, paras);
        }

        /// <summary>
        /// 抛出业务异常
        /// </summary>
        /// <param name="err">错误枚举</param>
        /// <param name="paras">格式化参数</param>
        public static void ThrowBusinessException(Enum err, params string[] paras)
        {
            var sys = GetErrorDomain();
            ThrowBusinessException(sys, err, paras);
        }

        /// <summary>
        /// 抛出业务异常
        /// </summary>
        /// <param name="sys">系统</param>
        /// <param name="err">错误枚举</param>
        /// <param name="paras">格式化参数</param>
        private static void ThrowBusinessException(ErrorSystems sys, Enum err, params string[] paras)
        {
            var errText = GetErrorTextWithParas(err, paras);
            var exThrow = GetBusinessException(errText, sys, err);
            throw exThrow;
        }

        /// <summary>
        /// 记录/抛出业务异常
        /// </summary>
        /// <param name="msg">自定义错误消息</param>
        /// <param name="err">错误枚举</param>
        /// <param name="ex">原始异常,异常信息会写入日志</param>
        public static void ThrowBusinessException(string msg, Enum err, Exception ex)
        {
            if (ex != null) Logger.Write(ex);
            ThrowBusinessException(msg, err);
        }

        /// <summary>
        /// 抛出业务异常
        /// </summary>
        /// <param name="msg">自定义错误消息</param>
        /// <param name="err">错误枚举</param>
        public static void ThrowBusinessException(string msg, Enum err)
        {
            var sys = GetErrorDomain();
            ThrowBusinessException(msg, sys, err);
        }

        /// <summary>
        /// 抛出业务异常
        /// </summary>
        /// <param name="msg">自定义错误消息</param>
        /// <param name="sys">系统</param>
        /// <param name="err">错误枚举</param>
        private static void ThrowBusinessException(string msg, ErrorSystems sys, Enum err)
        {
            var exThrow = GetBusinessException(msg, sys, err);
            throw exThrow;
        }

    }

}
