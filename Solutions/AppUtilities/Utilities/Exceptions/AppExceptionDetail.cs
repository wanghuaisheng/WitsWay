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
        /// 异常码
        /// </summary>
        private long _exceptionCode;
        /// <summary>
        /// 异常码
        /// </summary>
        public long ExceptionCode
        {
            get
            {
                return _exceptionCode;
            }
            set
            {
                _exceptionCode = value;
            }
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
            get
            {
                return _exceptionMessage;
            }
            set
            {
                _exceptionMessage = value;
            }
        }

    }
}
