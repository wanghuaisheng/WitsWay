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
