using System;

namespace WitsWay.Utilities.Errors
{
    /// <summary>
    /// 错误域 特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Enum)]
    public class ErrorDomainAttribute : Attribute
    {

        /// <summary>
        /// 描述枚举值
        /// </summary>
        public ErrorDomainAttribute(ErrorDomains domain)
        {
            Domain = domain;
        }

        /// <summary>
        /// 错误域
        /// </summary>
        public ErrorDomains Domain { get; }
        /// <summary>
        /// 错误域名称
        /// </summary>
        public string DomainText => Domain.GetErrorText();

        /// <summary>
        ///  重写ToString
        /// </summary>
        /// <returns>EnumDisplayText</returns>
        public override string ToString()
        {
            return DomainText;
        }

    }
}