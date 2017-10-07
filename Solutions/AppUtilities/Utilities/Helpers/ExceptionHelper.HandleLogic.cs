#region License(Apache Version 2.0)
/******************************************
 * Copyright ®2017-Now WangHuaiSheng.
 * Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file
 * except in compliance with the License. You may obtain a copy of the License at
 * http://www.apache.org/licenses/LICENSE-2.0
 * Unless required by applicable law or agreed to in writing, software distributed under the
 * License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
 * either express or implied. See the License for the specific language governing permissions
 * and limitations under the License.
 * Detail: https://github.com/WangHuaiSheng/WitsWay/LICENSE
 * ***************************************/
#endregion 
#region ChangeLog
/******************************************
 * 2017-10-7 OutMan Create
 * 
 * ***************************************/
#endregion
using System;
using System.Data.Common;
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
        /// 处理异常
        /// </summary>
        /// <param name="action">Action执行体</param>
        /// <param name="customMessage">自定义错误信息</param>
        public static void HandleException(Action action, string customMessage = null)
        {
            try
            {
                action();
            }
            catch (AppMessageException)
            {
                throw;
            }
            catch (DbException dbEx)
            {
                ThrowProgramException(customMessage, UtilityErrors.DatabaseAccessError, dbEx);
            }
            catch (Exception ex)
            {
                ThrowProgramException(customMessage, UtilityErrors.UnHandleProgramError, ex);
            }
        }

        /// <summary>
        /// 处理异常
        /// </summary>
        /// <param name="action">Action执行体</param>
        /// <param name="msgFunc">错误消息组织函数</param>
        /// <param name="msgPara">错误消息参数</param>
        /// <param name="final">try,catch,finally块中执行的Action方法</param>
        public static void HandleException<TPara>(Action action, Action final, Func<TPara, Exception, string> msgFunc, TPara msgPara) where TPara : class, new()
        {
            try
            {
                action();
            }
            catch (AppMessageException)
            {
                throw;
            }
            catch (DbException dbEx)
            {
                var msg = (msgFunc != null && msgPara != null) ? msgFunc(msgPara, dbEx) : string.Empty;
                ThrowProgramException(msg, UtilityErrors.DatabaseAccessError, dbEx);
            }
            catch (Exception ex)
            {
                var msg = (msgFunc != null && msgPara != null) ? msgFunc(msgPara, ex) : string.Empty;
                ThrowProgramException(msg, UtilityErrors.UnHandleProgramError, ex);
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
        /// <param name="customMessage">自定义错误信息</param>
        /// <returns>func调用的返回数据</returns>
        public static T HandleException<T>(Func<T> func, string customMessage = null)
        {
            try
            {
                return func();
            }
            catch (AppMessageException)
            {
                throw;
            }
            catch (DbException dbEx)
            {
                ThrowProgramException(customMessage, UtilityErrors.DatabaseAccessError, dbEx);
            }
            catch (Exception ex)
            {
                ThrowProgramException(customMessage, UtilityErrors.DatabaseAccessError, ex);
            }
            return default(T);
        }

        /// <summary>
        /// 处理异常
        /// </summary>
        /// <param name="func">带返回数据的方法执行体</param>
        /// <param name="final">try,catch,finally块中执行的Action方法</param>
        /// <param name="msgFunc">错误消息组织函数</param>
        /// <param name="msgPara">错误消息参数</param>
        /// <typeparam name="TResult">返回结果类型</typeparam>
        /// <typeparam name="TPara">错误消息组织参数类型</typeparam>
        /// <returns>func调用的返回数据</returns>
        public static TResult HandleException<TResult, TPara>(Func<TResult> func, Action final, Func<TPara, Exception, string> msgFunc, TPara msgPara)
            where TResult : class, new()
            where TPara : class,new()
        {
            try
            {
                return func();
            }
            catch (AppMessageException)
            {
                throw;
            }
            catch (DbException dbEx)
            {
                var msg = (msgFunc != null && msgPara != null) ? msgFunc(msgPara, dbEx) : string.Empty;
                ThrowProgramException(msg, UtilityErrors.DatabaseAccessError, dbEx);
            }
            catch (Exception ex)
            {
                var msg = (msgFunc != null && msgPara != null) ? msgFunc(msgPara, ex) : string.Empty;
                ThrowProgramException(msg, UtilityErrors.DatabaseAccessError, ex);
            }
            finally
            {
                final?.Invoke();
            }
            return default(TResult);
        }
        
    }
}
