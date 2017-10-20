using System;

namespace WitsWay.Utilities.Regexs
{
    /// <summary>
    /// ���ڱ�ʾ�����ǽ�����
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class ParseClassAttribute : Attribute
    {
        /// <summary>
        /// ����ƥ���ַ���
        /// </summary>
        public string RegexString { get; }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="pattern">�����ַ���</param>
        public ParseClassAttribute(string pattern)
        {
            RegexString = pattern;
        }

    }
}
