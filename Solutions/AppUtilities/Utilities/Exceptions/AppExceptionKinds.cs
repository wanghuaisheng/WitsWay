
using System.Runtime.Serialization;

namespace WitsWay.Utilities.Exceptions
{
    /// <summary>
    /// 异常类型
    /// </summary>
    [DataContract]
    public enum AppExceptionKinds
    {
        /// <summary>
        /// 业务异常
        /// </summary>
        [EnumMember]
        BusinessException = 1,
        /// <summary>
        /// 程序异常
        /// </summary>
        [EnumMember]
        ProgramException = 2
    }
}
