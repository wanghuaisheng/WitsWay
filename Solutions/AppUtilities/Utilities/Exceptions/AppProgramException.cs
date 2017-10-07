
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
