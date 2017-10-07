using System;
using System.Text.RegularExpressions;

namespace WitsWay.Utilities.Validate.Validators
{
    /// <summary>
    /// String��֤��
    /// </summary>
    public class StringValidator : ValidatorBase<StringValidator, string>
    {

        /// <summary>
        /// ��ʼ����֤��
        /// </summary>
        /// <param name="value">ֵ</param>
        /// <param name="fieldName">�ֶ���</param>
        /// <param name="validatorObj">��֤����</param>
        public StringValidator(string value, string fieldName, Validator validatorObj) : base(value, fieldName, validatorObj) { }

        /// <summary>
        /// ��Ϊ��
        /// </summary>
        /// <param name="errorMessage">������Ϣ</param>
        /// <returns>��֤��</returns>
        public StringValidator NotEmpty(string errorMessage)
        {
            SetResult((Value ?? string.Empty).Length != 0, errorMessage, ValidationErrorCode.StringIsEmpty);
            return this;
        }

        /// <summary>
        /// Ϊ��
        /// </summary>
        /// <param name="errorMessage">������Ϣ</param>
        /// <returns>��֤��</returns>
        public StringValidator IsEmpty(string errorMessage = "����Ϊ��")
        {
            SetResult((Value ?? string.Empty).Length == 0, errorMessage, ValidationErrorCode.StringIsEmpty);
            return this;
        }

        /// <summary>
        /// ����Ϊ
        /// </summary>
        /// <param name="compareLength">�Ƚ�ֵ</param>
        /// <param name="errorMessage">������Ϣ</param>
        /// <returns>��֤��</returns>
        public StringValidator IsLength(int compareLength, string errorMessage)
        {
            if (string.IsNullOrEmpty(Value)) return this;
            SetResult(Value.Length == compareLength, errorMessage, ValidationErrorCode.StringIsLength);
            return this;
        }

        /// <summary>
        /// ���Ȳ�Ϊ
        /// </summary>
        /// <param name="compareLength">�Ƚ�ֵ</param>
        /// <param name="errorMessage">������Ϣ</param>
        /// <returns>��֤��</returns>
        public StringValidator NotLength(int compareLength, string errorMessage)
        {
            if (string.IsNullOrEmpty(Value)) return this;
            SetResult(Value.Length != compareLength, errorMessage, ValidationErrorCode.StringIsLength);
            return this;
        }

        /// <summary>
        /// ���ȴ���minLength
        /// </summary>
        /// <param name="minLength">��С����</param>
        /// <param name="errorMessage">������Ϣ</param>
        /// <returns>��֤��</returns>
        public StringValidator IsLongerThan(int minLength, string errorMessage)
        {
            if (string.IsNullOrEmpty(Value)) return this;
            SetResult(Value.Length > minLength, errorMessage, ValidationErrorCode.StringIsLongerThan);
            return this;
        }

        /// <summary>
        /// ���ȶ���
        /// </summary>
        /// <param name="maxLength">��󳤶�</param>
        /// <param name="errorMessage">������Ϣ</param>
        /// <returns>��֤��</returns>
        public StringValidator IsShorterThan(int maxLength, string errorMessage)
        {
            if (string.IsNullOrEmpty(Value)) return this;
            SetResult(Value.Length < maxLength, errorMessage, ValidationErrorCode.StringIsShorterThan);
            return this;
        }

        /// <summary>
        /// ����ƥ��
        /// </summary>
        /// <param name="regularExpression">������ʽ</param>
        /// <param name="errorMessage">������Ϣ</param>
        /// <returns>��֤��</returns>
        public StringValidator MatchRegex(string regularExpression, string errorMessage)
        {
            return MatchRegex(regularExpression, RegexOptions.None, errorMessage);
        }

        /// <summary>
        /// ����ƥ��
        /// </summary>
        /// <param name="regularExpression">������ʽ</param>
        /// <param name="regexOptions">ƥ��ѡ��</param>
        /// <param name="errorMessage">������Ϣ</param>
        /// <returns>��֤��</returns>
        public StringValidator MatchRegex(string regularExpression, RegexOptions regexOptions, string errorMessage)
        {
            if (string.IsNullOrEmpty(Value)) return this;
            var reg = regexOptions == RegexOptions.None ? new Regex(regularExpression) : new Regex(regularExpression, regexOptions);
            SetResult(!reg.IsMatch(Value), errorMessage, ValidationErrorCode.StringMatchRegex);
            return this;
        }

        /// <summary>
        /// ����ƥ��
        /// </summary>
        /// <param name="regularExpression">������ʽ</param>
        /// <param name="errorMessage">������Ϣ</param>
        /// <returns>��֤��</returns>
        public StringValidator NotMatchRegex(string regularExpression, string errorMessage)
        {
            return NotMatchRegex(regularExpression, RegexOptions.None, errorMessage);
        }

        /// <summary>
        /// ����ƥ��
        /// </summary>
        /// <param name="regularExpression">������ʽ</param>
        /// <param name="regexOptions">ƥ��ѡ��</param>
        /// <param name="errorMessage">������Ϣ</param>
        /// <returns>��֤��</returns>
        public StringValidator NotMatchRegex(string regularExpression, RegexOptions regexOptions, string errorMessage)
        {
            if (string.IsNullOrEmpty(Value)) return this;
            var reg = regexOptions == RegexOptions.None ? new Regex(regularExpression) : new Regex(regularExpression, regexOptions);
            SetResult(reg.IsMatch(Value), errorMessage, ValidationErrorCode.StringMatchRegex);
            return this;
        }


        /// <summary>
        /// ����Ƿ���Email
        /// </summary>
        /// <param name="errorMessage">������Ϣ</param>
        /// <returns>��֤��</returns>
        public StringValidator IsEmail(string errorMessage)
        {
            if (string.IsNullOrEmpty(Value)) return this;
            var reg = new Regex(RegexStrings.EmailRegex, RegexOptions.IgnoreCase);
            SetResult(reg.IsMatch(Value), errorMessage, ValidationErrorCode.StringIsEmail);
            return this;
        }

        /// <summary>
        /// ����ַ����Ƿ���URL
        /// </summary>
        /// <param name="errorMsg">������Ϣ</param>
        /// <returns>��֤��</returns>
        public StringValidator IsURL(string errorMsg)
        {
            if (string.IsNullOrEmpty(Value)) return this;
            var reg = new Regex(RegexStrings.UrlRegex, RegexOptions.IgnoreCase);
            SetResult(reg.IsMatch(Value), errorMsg, ValidationErrorCode.StringIsURL);
            return this;
        }

        /// <summary>
        /// ����ַ����Ƿ�������
        /// </summary>
        /// <param name="errorMsg">������Ϣ</param>
        /// <returns>��֤��</returns>
        public StringValidator IsDate(string errorMsg)
        {
            if (string.IsNullOrEmpty(Value)) return this;
            DateTime date;
            SetResult(DateTime.TryParse(Value, out date), errorMsg, ValidationErrorCode.StringIsDate);
            return this;
        }

        /// <summary>
        /// ����ַ����Ƿ�������
        /// </summary>
        /// <param name="errorMsg">������Ϣ</param>
        /// <returns>��֤��</returns>
        public StringValidator IsInteger(string errorMsg)
        {
            if (string.IsNullOrEmpty(Value)) return this;
            int tmp;
            SetResult(int.TryParse(Value, out tmp), errorMsg, ValidationErrorCode.StringIsInteger);
            return this;
        }


        /// <summary>
        /// ����ַ����Ƿ���Long
        /// </summary>
        /// <param name="errorMsg">������Ϣ</param>
        /// <returns>��֤��</returns>
        public StringValidator IsLong(string errorMsg)
        {
            if (string.IsNullOrEmpty(Value)) return this;
            long tmp;
            SetResult(long.TryParse(Value, out tmp), errorMsg, ValidationErrorCode.StringIsLong);
            return this;
        }



        /// <summary>
        /// ����ַ����Ƿ���Decimal
        /// </summary>
        /// <param name="errorMsg">������Ϣ</param>
        /// <returns>��֤��</returns>
        public StringValidator IsDecimal(string errorMsg)
        {
            if (string.IsNullOrEmpty(Value)) return this;
            decimal tmp;
            SetResult(decimal.TryParse(Value, out tmp), errorMsg, ValidationErrorCode.StringIsDecimal);
            return this;
        }

        /// <summary>
        /// ����ַ����Ƿ񳤶���minLength��maxLength֮��
        /// </summary>
        /// <param name="minLength">��С����</param>
        /// <param name="maxLength">��󳤶�</param>
        /// <param name="errorMsg">������Ϣ</param>
        /// <returns>��֤��</returns>
        public StringValidator IsLengthBetween(int minLength, int maxLength, string errorMsg)
        {
            if (string.IsNullOrEmpty(Value)) return this;
            SetResult(Value.Length >= minLength && Value.Length <= maxLength, errorMsg, ValidationErrorCode.IsLengthBetween);
            return this;
        }

        /// <summary>
        /// ����ַ����Ƿ�����ض��ַ���
        /// </summary>
        /// <param name="containValue">������ֵ</param>
        /// <param name="errorMsg">������Ϣ</param>
        /// <returns>��֤��</returns>
        public StringValidator Contains(string containValue, string errorMsg)
        {
            if (string.IsNullOrEmpty(Value)) return this;
            SetResult(Value.Contains(containValue), errorMsg, ValidationErrorCode.StringContains);
            return this;
        }

    }
}
