/******************************************
 * 2012年5月8日 王怀生 添加
 * ***************************************/

using System;
using System.Configuration;
using System.Linq;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using WitsWay.Utilities.Errors;
using WitsWay.Utilities.Exceptions;
using WitsWay.Utilities.Extends;

namespace WitsWay.Utilities.Helpers
{
    /// <summary>
    /// 系统错误辅助类
    /// </summary>
    public partial class ExceptionHelper
    {

        #region [GetBusinessException]

        /// <summary>
        /// 获取业务异常
        /// </summary>
        /// <param name="err">错误枚举</param>
        /// <param name="paras">格式化参数</param>
        public static AppMessageException GetBusinessException(Enum err, params string[] paras)
        {
            var sys = GetErrorDomain();
            var msg = GetErrorTextWithParas(err, paras);
            return GetBusinessException(msg, sys, err);
        }

        /// <summary>
        /// 获取业务异常
        /// </summary>
        /// <param name="msg">自定义消息</param>
        /// <param name="err">错误枚举</param>
        public static AppMessageException GetBusinessException(string msg, Enum err)
        {
            var sys = GetErrorDomain();
            return GetBusinessException(msg,sys, err);
        }

        /// <summary>
        /// 获取业务异常
        /// </summary>
        /// <param name="msg">自定义消息</param>
        /// <param name="sys">系统</param>
        /// <param name="err">错误枚举</param>
        private static AppMessageException GetBusinessException(string msg, ErrorSystems sys, Enum err)
        {
            var errCode = err.GetErrorCode(sys);
            return GetException(AppExceptionKinds.BusinessException, errCode, msg);
        }

        #endregion

        #region [GetProgramException]

        /// <summary>
        /// 获取业务异常
        /// </summary>
        /// <param name="err">错误枚举</param>
        /// <param name="paras">格式化参数</param>
        public static AppMessageException GetProgramException(Enum err, params string[] paras)
        {
            var sys = GetErrorDomain();
            var msg = GetErrorTextWithParas(err, paras);
            return GetProgramException(msg, sys, err);
        }

        /// <summary>
        /// 获取业务异常
        /// </summary>
        /// <param name="msg">自定义消息</param>
        /// <param name="err">错误枚举</param>
        public static AppMessageException GetProgramException(string msg, Enum err)
        {
            var sys = GetErrorDomain();
            return GetProgramException(msg, sys, err);
        }

        /// <summary>
        /// 获取业务异常
        /// </summary>       
        /// <param name="sys">系统</param>
        /// <param name="err">错误枚举</param>
        /// <param name="msg">自定义消息</param>
        private static AppMessageException GetProgramException(string msg, ErrorSystems sys, Enum err)
        {
            var errCode = err.GetErrorCode(sys);
            return GetException(AppExceptionKinds.ProgramException, errCode, msg);
        }

        #endregion

        #region [Other]

        /// <summary>
        /// 取得错误记录信息
        /// </summary>
        /// <param name="ex">错误实例</param>
        /// <param name="errorCode">错误码</param>
        /// <param name="errorText">错误描述</param>
        /// <returns>错误消息</returns>
        public static string GetExceptionMessage(Exception ex, long errorCode, string errorText)
        {
            var msg = string.Empty;
            if (ex == null) { return msg; }
            ex = GetInnerException(ex);
            return $"错误码：{errorCode}\r\n错误描述：{errorText}\r\n{ex}";
        }

        /// <summary>
        /// 取得内部错误
        /// </summary>
        public static Exception GetInnerException(Exception ex)
        {
            if (ex == null) return null;
            if (ex.InnerException == null)
            {
                Logger.Write(ex);
                return ex;
            }
            ex = ex.InnerException;
            return GetInnerException(ex);
        }

        #endregion

        #region [Supports]

        /// <summary>
        /// 获取异常
        /// </summary>
        /// <param name="exType">异常类型</param>
        /// <param name="errCode">错误码</param>
        /// <param name="errText">自定义错误描述信息</param>
        private static AppMessageException GetException(AppExceptionKinds exType, long errCode, string errText)
        {
            return exType == AppExceptionKinds.ProgramException ? (AppMessageException)new AppProgramException(errCode, errText) : new AppBusinessException(errCode, errText);
        }

        /// <summary>
        /// 获取错误域
        /// </summary>
        /// <returns>AppSetting中的错误域</returns>
        private static ErrorSystems GetErrorDomain()
        {
            var configValue = AppSettingHelper.GetValue(UtilityConsts.ErrorDomainAppSettingKey);
            if (string.IsNullOrWhiteSpace(configValue) || configValue.ToInt() == 0)
            {
                throw new ConfigurationErrorsException("配置文件未配置错误域");
            }
            var sys = configValue.CastTo<ErrorSystems>();
            return sys;
        }
        /// <summary>
        /// 获取错误描述信息
        /// </summary>
        /// <param name="err">错误</param>
        /// <param name="paras">格式化参数</param>
        /// <returns>错误描述信息</returns>
        private static string GetErrorTextWithParas(Enum err, string[] paras)
        {
            var errText = err.GetErrorText();
            var strParas = paras?.Select(para => (object)para).ToArray();
            errText = (paras == null || paras.Length == 0) ? errText : string.Format(errText, strParas);
            return errText;
        }

        #endregion

    }
}
