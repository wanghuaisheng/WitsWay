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
namespace WitsWay.Utilities.Exceptions
{
    /// <summary>
    /// 程序异常
    /// </summary>
    public class AppProgramException : AppMessageException
    {
        /// <summary>
        /// 由指定错误码和描述构造应用程序消息异常
        /// </summary>
        /// <param name="errorCode">错误码</param>
        /// <param name="errorDescription">错误描述</param>
        public AppProgramException(long errorCode, string errorDescription):base(errorCode,errorDescription)
        {
            ExceptionType = AppExceptionKinds.ProgramException;
        }

        /// <summary>
        /// 由指定错误码、描述和操作帮助构造应用程序消息异常
        /// </summary>
        /// <param name="errorCode">错误码</param>
        /// <param name="errorDescription">错误描述</param>
        /// <param name="operationHelp">操作帮助</param>
        public AppProgramException(long errorCode, string errorDescription, string operationHelp):base(errorCode,errorDescription,operationHelp)
        {
            ExceptionType = AppExceptionKinds.ProgramException;
        }

    }
}
