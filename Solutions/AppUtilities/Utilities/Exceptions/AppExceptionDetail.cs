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
    /// 异常明细
    /// </summary>
    [Serializable]
    public class AppExceptionDetail
    {
        
        /// <summary>
        /// 异常类型
        /// </summary>
        private AppExceptionKinds _exceptionType;
        /// <summary>
        /// 异常类型
        /// </summary>
        public AppExceptionKinds ExceptionType
        {
            get => _exceptionType;
            set => _exceptionType = value;
        }

        /// <summary>
        /// 异常码
        /// </summary>
        private long _exceptionCode;
        /// <summary>
        /// 异常码
        /// </summary>
        public long ExceptionCode
        {
            get => _exceptionCode;
            set => _exceptionCode = value;
        }

        /// <summary>
        /// 异常信息
        /// </summary>
        private string _exceptionMessage;
        /// <summary>
        /// 异常信息
        /// </summary>
        public string ExceptionMessage
        {
            get => _exceptionMessage;
            set => _exceptionMessage = value;
        }

    }
}
