using System;
using System.Net;

namespace WitsWay.Utilities.Exceptions
{
    /// <summary>
    /// 异常明细
    /// </summary>
    [Serializable]
    public class ApiExceptionDetail
    {

        /// <summary>
        /// 异常类型
        /// </summary>
        public AppExceptionKinds ExceptionType { get; set; }

        /// <summary>
        /// 异常码
        /// </summary>
        public long ExceptionCode { get; set; }

        /// <summary>
        /// 异常信息
        /// </summary>
        public string ExceptionMessage { get; set; }

        /// <summary>
        /// Http状态码
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }

    }
}
