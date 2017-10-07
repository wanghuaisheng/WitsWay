/******************************************
 * 2012年5月8日 王怀生 添加
 * ***************************************/

using System;
using System.ServiceModel;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using WitsWay.Utilities.Errors;
using WitsWay.Utilities.Exceptions;

namespace WitsWay.Utilities.Helpers
{
    /// <summary>
    /// 系统错误辅助类
    /// </summary>
    public partial class ExceptionHelper
    {

        /// <summary>
        /// 处理服务异常
        /// </summary>
        /// <param name="action">Action委托</param>
        /// <param name="serviceName">服务名称</param>
        public static void HandleExceptionService(Action action, string serviceName = null)
        {
            HandleExceptionService(() =>
            {
                action();
                return true;
            }, serviceName);
        }

        /// <summary>
        /// 处理服务异常
        /// </summary>
        /// <param name="fun">One输出No输入Func委托</param>
        /// <param name="serviceName">服务名称</param>
        /// <returns>执行结果</returns>
        public static T HandleExceptionService<T>(Func<T> fun, string serviceName = null)
        {
            try
            {
                return fun();
            }
            catch (AppMessageException appEx)
            {
                throw new FaultException<AppExceptionDetail>(new AppExceptionDetail
                {
                    ExceptionCode = appEx.ErrorCode,
                    ExceptionMessage = appEx.ErrorDescription,
                    ExceptionType = appEx.ExceptionType
                });
            }
            catch (CommunicationObjectFaultedException coEx)
            {
                Logger.Write(coEx); var ds = string.IsNullOrWhiteSpace(serviceName)
                    ? GetProgramException(UtilityErrors.ServiceAccessError)
                    : GetProgramException($"“{serviceName}”访问错误。", UtilityErrors.ServiceAccessError);
                throw new FaultException(ds.ErrorDescription, new FaultCode(ds.ErrorCode.ToString()));
            }
            catch (Exception ex)
            {
                if (ex is FaultException) throw;
                Logger.Write(ex);
                var ds = string.IsNullOrWhiteSpace(serviceName)
                    ? GetProgramException(UtilityErrors.ServiceProgramError)
                    : GetProgramException($"“{serviceName}”内部程序错误。", UtilityErrors.ServiceProgramError);
                throw new FaultException(ds.ErrorDescription, new FaultCode(ds.ErrorCode.ToString()));
            }
        }

    }
}
