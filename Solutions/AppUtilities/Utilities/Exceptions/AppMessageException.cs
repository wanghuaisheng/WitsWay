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
            get
            {
                return _exceptionType;
            }
            set
            {
                _exceptionType = value;
            }
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
            get { return Convert.ToInt32(ErrorCode / 100000000); }
            set { ErrorCode = ErrorCode % 100000000 + value * 100000000; }
        }
        /// <summary>
        /// 由错误码和错误描述、操作帮助组成的提示消息串
        /// </summary>
        public override string Message
        {
            get { return $"{ErrorDescription} {OperationHelp}"; }
        }

    }
}
