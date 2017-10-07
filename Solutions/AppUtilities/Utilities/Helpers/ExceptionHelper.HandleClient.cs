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
using System.ServiceModel;
using WitsWay.Utilities.Errors;
using WitsWay.Utilities.Exceptions;
using WitsWay.Utilities.Guards;

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
        /// <param name="action">Action委托</param>
        /// <param name="serviceName">服务名</param>
        public static void HandleExceptionClient(Action action, string serviceName = null)
        {
            HandleExceptionClient(() =>
            {
                action();
                return true;
            }, serviceName);
        }

        /// <summary>
        /// 处理异常
        /// </summary>
        /// <param name="action">Action委托</param>
        /// <param name="serviceName">服务名</param>
        /// <param name="successAction">成功回调</param>
        /// <param name="failAction">失败回调</param>
        public static void HandleExceptionClient(Action action, string serviceName, Action successAction, Action failAction)
        {
            HandleExceptionClient(() =>
            {
                action();
                return true;
            }, serviceName, successAction, failAction);
        }
        /// <summary>
        /// 处理异常
        /// </summary>
        /// <param name="fun">Func委托</param>
        /// <param name="serviceName">服务名</param>
        public static T HandleExceptionClient<T>(Func<T> fun, string serviceName = null)
        {
            return HandleExceptionClient(fun, serviceName, null, null);
        }


        /// <summary>
        /// 处理异常
        /// </summary>
        /// <param name="fun">Func委托</param>
        /// <param name="serviceName">服务名</param>
        /// <param name="successAction">成功回调</param>
        /// <param name="failAction">失败回调</param>
        public static T HandleExceptionClient<T>(Func<T> fun, string serviceName, Action successAction, Action failAction)
        {
            ArgumentGuard.ArgumentNotNull("fun", fun);
            try
            {
                var result = fun();
                successAction?.Invoke();
                return result;
            }
            catch (FaultException<AppExceptionDetail> dsEx)
            {
                throw new AppBusinessException(dsEx.Detail.ExceptionCode, dsEx.Detail.ExceptionMessage);
            }
            catch (FaultException fEx) 
            {
                //FaultException继承自CommunicationException
                var msg = fEx.Message;
                ThrowProgramException(msg, UtilityErrors.InternalProgramError, fEx);
            }
            catch (CommunicationException cEx)
            {
                var msg = string.IsNullOrWhiteSpace(serviceName) ? null : $"“{serviceName}”访问错误。";
                ThrowProgramException(msg, UtilityErrors.ServiceAccessError, cEx);
            }
            catch (AppMessageException)
            {
                throw;
            }
            catch (Exception ex)
            {
                ThrowProgramException(UtilityErrors.UnHandleProgramError, ex);
            }
            finally
            {
                failAction?.Invoke();
            }
            return default(T);
        }
        
    }
}
