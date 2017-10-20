using System;

namespace WitsWay.Utilities.Regexs
{
    /// <summary>
    /// 用于标示该类是解析类
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class ParseClassAttribute : Attribute
    {
        /// <summary>
        /// 正则匹配字符串
        /// </summary>
        public string RegexString { get; }

        /// <summary>
        /// 够造函数
        /// </summary>
        /// <param name="pattern">正则字符串</param>
        public ParseClassAttribute(string pattern)
        {
            RegexString = pattern;
        }

    }
}
