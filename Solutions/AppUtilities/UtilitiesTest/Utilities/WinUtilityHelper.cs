using System;
using System.Diagnostics;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using WitsWay.Utilities.Errors;
using WitsWay.Utilities.Exceptions;

namespace WitsWay.Utlities.Tests.Utilities
{
    /// <summary>
    /// WinForm通用辅助类
    /// </summary>
    public static class WinUtilityHelper
    {
        /// <summary>
        /// 处理异常
        /// </summary>
        /// <param name="action">Action执行体</param>
        /// <param name="final">try,catch,finally块中执行的Action方法</param>
        public static void HandleException(Action action, Action final = null)
        {
            try
            {
                action();
            }
            catch (AppBusinessException bex)
            {
                ShowInfoMessage(bex.ErrorDescription);
            }
            catch (AppProgramException pex)
            {
                ShowErrorMessage(pex.ErrorDescription);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                ShowErrorMessage(UtilityErrors.UnHandleProgramError.GetErrorText());
            }
            finally
            {
                final?.Invoke();
            }
        }

        /// <summary>
        /// 处理异常
        /// </summary>
        /// <param name="func">带返回数据的方法执行体</param>
        /// <param name="final">try,catch,finally块中执行的Action方法</param>
        /// <typeparam name="TResult">返回结果类型</typeparam>
        /// <returns>func调用的返回数据</returns>
        public static TResult HandleException<TResult>(Func<TResult> func, Action final = null)
        {
            try
            {
                return func();
            }
            catch (AppBusinessException bex)
            {
                ShowInfoMessage(bex.ErrorDescription);
            }
            catch (AppProgramException pex)
            {
                ShowErrorMessage(pex.ErrorDescription);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                ShowErrorMessage(UtilityErrors.UnHandleProgramError.GetErrorText());
            }
            finally
            {
                final?.Invoke();
            }
            return default(TResult);
        }

        public static void ShowInfoMessage(string msg)
        {
            Debug.Write($"Info:{msg}");
        }
        public static void ShowErrorMessage(string msg)
        {
            Debug.Write($"Error:{msg}");
        }
    }

}