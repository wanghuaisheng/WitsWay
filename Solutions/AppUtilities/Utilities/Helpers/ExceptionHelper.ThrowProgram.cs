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
        /// 记录/抛出程序异常
        /// <para>会记录“原始异常”和“程序异常”两条异常日志</para>
        /// </summary>
        /// <param name="err">错误枚举</param>
        /// <param name="ex">原始异常,异常信息会写入日志</param>
        /// <param name="paras">格式化参数</param>
        public static void ThrowProgramException(Enum err, Exception ex, params string[] paras)
        {
            if (ex != null) Logger.Write(ex);
            ThrowProgramException(err, paras);
        }

        /// <summary>
        /// 记录/抛出程序异常
        /// <para>会记录“程序异常”异常日志</para>
        /// </summary>
        /// <param name="err">错误枚举</param>
        /// <param name="paras">格式化参数</param>
        public static void ThrowProgramException(Enum err, params string[] paras)
        {
            var sys = GetErrorDomain();
            ThrowProgramException(sys, err, paras);
        }

        /// <summary>
        /// 记录/抛出程序异常
        /// <para>会记录“程序异常”异常日志</para>
        /// </summary>
        /// <param name="sys">系统</param>
        /// <param name="err">错误枚举</param>
        /// <param name="paras">格式化参数</param>
        private static void ThrowProgramException(ErrorSystems sys, Enum err, params string[] paras)
        {
            var errText = GetErrorTextWithParas(err, paras);
            var exThrow = GetProgramException(errText,sys, err);
            Logger.Write(exThrow);
            throw exThrow;
        }

        /// <summary>
        /// 记录/抛出程序异常
        /// <para>会记录“原始异常”和“程序异常”两条异常日志</para>
        /// </summary>
        /// <param name="msg">自定义错误消息</param>
        /// <param name="err">错误枚举</param>
        /// <param name="ex">原始异常,异常信息会写入日志</param>
        public static void ThrowProgramException(string msg,Enum err, Exception ex)
        {
            if (ex != null) Logger.Write(ex);
            ThrowProgramException(msg,err);
        }

        /// <summary>
        /// 记录/抛出程序异常
        /// <para>会记录“程序异常”异常日志</para>
        /// </summary>
        /// <param name="err">错误枚举</param>
        /// <param name="msg">自定义错误消息</param>
        public static void ThrowProgramException(string msg,Enum err)
        {
            var sys = GetErrorDomain();
            ThrowProgramException(msg,sys, err);
        }

        /// <summary>
        /// 记录/抛出程序异常
        /// <para>会记录“程序异常”异常日志</para>
        /// </summary>
        /// <param name="sys">系统</param>
        /// <param name="err">错误枚举</param>
        /// <param name="msg">自定义错误消息</param>
        private static void ThrowProgramException(string msg,ErrorSystems sys, Enum err)
        {
            var exThrow = GetProgramException(msg,sys, err);
            Logger.Write(exThrow);
            throw exThrow;
        }
        
    }
}
