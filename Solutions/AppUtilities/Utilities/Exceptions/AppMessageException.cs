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

namespace WitsWay.Utilities.Exceptions
{
    /// <summary>
    /// 应用程序消息异常类，封装了错误码和错误描述，是应用程序将异常通知最高层的统一类.
    /// </summary>
    [Serializable]
    public class AppMessageException : ApplicationException
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public AppMessageException() { }

        /// <summary>
        /// 由指定错误码和描述构造应用程序消息异常
        /// </summary>
        /// <param name="errorCode">错误码</param>
        /// <param name="errorDescription">错误描述</param>
        public AppMessageException(long errorCode, string errorDescription)
        {
            ErrorCode = errorCode;
            ErrorDescription = errorDescription;
        }

        /// <summary>
        /// 由指定错误码、描述和操作帮助构造应用程序消息异常
        /// </summary>
        /// <param name="errorCode">错误码</param>
        /// <param name="errorDescription">错误描述</param>
        /// <param name="operationHelp">操作帮助</param>
        public AppMessageException(long errorCode, string errorDescription, string operationHelp)
        {
            ErrorCode = errorCode;
            ErrorDescription = errorDescription;
            OperationHelp = operationHelp;
        }


        /// <summary>
        /// 获取错误码
        /// </summary>
        public long ErrorCode { get; private set; }

        /// <summary>
        /// 异常类型
        /// </summary>
        private AppExceptionKinds _exceptionType = AppExceptionKinds.ProgramException;
        /// <summary>
        /// 获取或者设置异常类型
        /// </summary>
        public AppExceptionKinds ExceptionType
        {
            get => _exceptionType;
            set => _exceptionType = value;
        }

        /// <summary>
        /// 获取错误描述
        /// </summary>
        public string ErrorDescription { get; private set; }

        /// <summary>
        /// 操作帮助
        /// </summary>
        public string OperationHelp { get; private set; }

        /////// <summary>
        /////// 系统码
        /////// </summary>
        ////private int _systemCode;
        /// <summary>
        /// 获取或者设置系统码
        /// </summary>
        public int SystemCode
        {
            get => Convert.ToInt32(ErrorCode / 100000000);
            set => ErrorCode = ErrorCode % 100000000 + value * 100000000;
        }
        /// <summary>
        /// 由错误码和错误描述、操作帮助组成的提示消息串
        /// </summary>
        public override string Message => $"{ErrorDescription} {OperationHelp}";
    }
}
