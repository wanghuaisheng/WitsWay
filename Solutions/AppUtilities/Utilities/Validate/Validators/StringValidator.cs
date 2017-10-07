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
using System.Text.RegularExpressions;

namespace WitsWay.Utilities.Validate.Validators
{
    /// <summary>
    /// String验证器
    /// </summary>
    public class StringValidator : ValidatorBase<StringValidator, string>
    {

        /// <summary>
        /// 初始化验证器
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="fieldName">字段名</param>
        /// <param name="validatorObj">验证对象</param>
        public StringValidator(string value, string fieldName, Validator validatorObj) : base(value, fieldName, validatorObj) { }

        /// <summary>
        /// 不为空
        /// </summary>
        /// <param name="errorMessage">错误消息</param>
        /// <returns>验证器</returns>
        public StringValidator NotEmpty(string errorMessage)
        {
            SetResult((Value ?? string.Empty).Length != 0, errorMessage, ValidationErrorCode.StringIsEmpty);
            return this;
        }

        /// <summary>
        /// 为空
        /// </summary>
        /// <param name="errorMessage">错误消息</param>
        /// <returns>验证器</returns>
        public StringValidator IsEmpty(string errorMessage = "不能为空")
        {
            SetResult((Value ?? string.Empty).Length == 0, errorMessage, ValidationErrorCode.StringIsEmpty);
            return this;
        }

        /// <summary>
        /// 长度为
        /// </summary>
        /// <param name="compareLength">比较值</param>
        /// <param name="errorMessage">错误消息</param>
        /// <returns>验证器</returns>
        public StringValidator IsLength(int compareLength, string errorMessage)
        {
            if (string.IsNullOrEmpty(Value)) return this;
            SetResult(Value.Length == compareLength, errorMessage, ValidationErrorCode.StringIsLength);
            return this;
        }

        /// <summary>
        /// 长度不为
        /// </summary>
        /// <param name="compareLength">比较值</param>
        /// <param name="errorMessage">错误消息</param>
        /// <returns>验证器</returns>
        public StringValidator NotLength(int compareLength, string errorMessage)
        {
            if (string.IsNullOrEmpty(Value)) return this;
            SetResult(Value.Length != compareLength, errorMessage, ValidationErrorCode.StringIsLength);
            return this;
        }

        /// <summary>
        /// 长度大于minLength
        /// </summary>
        /// <param name="minLength">最小长度</param>
        /// <param name="errorMessage">错误消息</param>
        /// <returns>验证器</returns>
        public StringValidator IsLongerThan(int minLength, string errorMessage)
        {
            if (string.IsNullOrEmpty(Value)) return this;
            SetResult(Value.Length > minLength, errorMessage, ValidationErrorCode.StringIsLongerThan);
            return this;
        }

        /// <summary>
        /// 长度短于
        /// </summary>
        /// <param name="maxLength">最大长度</param>
        /// <param name="errorMessage">错误消息</param>
        /// <returns>验证器</returns>
        public StringValidator IsShorterThan(int maxLength, string errorMessage)
        {
            if (string.IsNullOrEmpty(Value)) return this;
            SetResult(Value.Length < maxLength, errorMessage, ValidationErrorCode.StringIsShorterThan);
            return this;
        }

        /// <summary>
        /// 正则匹配
        /// </summary>
        /// <param name="regularExpression">正则表达式</param>
        /// <param name="errorMessage">错误消息</param>
        /// <returns>验证器</returns>
        public StringValidator MatchRegex(string regularExpression, string errorMessage)
        {
            return MatchRegex(regularExpression, RegexOptions.None, errorMessage);
        }

        /// <summary>
        /// 正则匹配
        /// </summary>
        /// <param name="regularExpression">正则表达式</param>
        /// <param name="regexOptions">匹配选项</param>
        /// <param name="errorMessage">错误消息</param>
        /// <returns>验证器</returns>
        public StringValidator MatchRegex(string regularExpression, RegexOptions regexOptions, string errorMessage)
        {
            if (string.IsNullOrEmpty(Value)) return this;
            var reg = regexOptions == RegexOptions.None ? new Regex(regularExpression) : new Regex(regularExpression, regexOptions);
            SetResult(!reg.IsMatch(Value), errorMessage, ValidationErrorCode.StringMatchRegex);
            return this;
        }

        /// <summary>
        /// 正则不匹配
        /// </summary>
        /// <param name="regularExpression">正则表达式</param>
        /// <param name="errorMessage">错误消息</param>
        /// <returns>验证器</returns>
        public StringValidator NotMatchRegex(string regularExpression, string errorMessage)
        {
            return NotMatchRegex(regularExpression, RegexOptions.None, errorMessage);
        }

        /// <summary>
        /// 正则不匹配
        /// </summary>
        /// <param name="regularExpression">正则表达式</param>
        /// <param name="regexOptions">匹配选项</param>
        /// <param name="errorMessage">错误消息</param>
        /// <returns>验证器</returns>
        public StringValidator NotMatchRegex(string regularExpression, RegexOptions regexOptions, string errorMessage)
        {
            if (string.IsNullOrEmpty(Value)) return this;
            var reg = regexOptions == RegexOptions.None ? new Regex(regularExpression) : new Regex(regularExpression, regexOptions);
            SetResult(reg.IsMatch(Value), errorMessage, ValidationErrorCode.StringMatchRegex);
            return this;
        }


        /// <summary>
        /// 检查是否是Email
        /// </summary>
        /// <param name="errorMessage">错误消息</param>
        /// <returns>验证器</returns>
        public StringValidator IsEmail(string errorMessage)
        {
            if (string.IsNullOrEmpty(Value)) return this;
            var reg = new Regex(RegexStrings.EmailRegex, RegexOptions.IgnoreCase);
            SetResult(reg.IsMatch(Value), errorMessage, ValidationErrorCode.StringIsEmail);
            return this;
        }

        /// <summary>
        /// 检查字符串是否是URL
        /// </summary>
        /// <param name="errorMsg">错误消息</param>
        /// <returns>验证器</returns>
        public StringValidator IsURL(string errorMsg)
        {
            if (string.IsNullOrEmpty(Value)) return this;
            var reg = new Regex(RegexStrings.UrlRegex, RegexOptions.IgnoreCase);
            SetResult(reg.IsMatch(Value), errorMsg, ValidationErrorCode.StringIsURL);
            return this;
        }

        /// <summary>
        /// 检查字符串是否是日期
        /// </summary>
        /// <param name="errorMsg">错误消息</param>
        /// <returns>验证器</returns>
        public StringValidator IsDate(string errorMsg)
        {
            if (string.IsNullOrEmpty(Value)) return this;
            DateTime date;
            SetResult(DateTime.TryParse(Value, out date), errorMsg, ValidationErrorCode.StringIsDate);
            return this;
        }

        /// <summary>
        /// 检查字符串是否是整形
        /// </summary>
        /// <param name="errorMsg">错误消息</param>
        /// <returns>验证器</returns>
        public StringValidator IsInteger(string errorMsg)
        {
            if (string.IsNullOrEmpty(Value)) return this;
            int tmp;
            SetResult(int.TryParse(Value, out tmp), errorMsg, ValidationErrorCode.StringIsInteger);
            return this;
        }


        /// <summary>
        /// 检查字符串是否是Long
        /// </summary>
        /// <param name="errorMsg">错误消息</param>
        /// <returns>验证器</returns>
        public StringValidator IsLong(string errorMsg)
        {
            if (string.IsNullOrEmpty(Value)) return this;
            long tmp;
            SetResult(long.TryParse(Value, out tmp), errorMsg, ValidationErrorCode.StringIsLong);
            return this;
        }



        /// <summary>
        /// 检查字符串是否是Decimal
        /// </summary>
        /// <param name="errorMsg">错误消息</param>
        /// <returns>验证器</returns>
        public StringValidator IsDecimal(string errorMsg)
        {
            if (string.IsNullOrEmpty(Value)) return this;
            decimal tmp;
            SetResult(decimal.TryParse(Value, out tmp), errorMsg, ValidationErrorCode.StringIsDecimal);
            return this;
        }

        /// <summary>
        /// 检查字符串是否长度在minLength和maxLength之间
        /// </summary>
        /// <param name="minLength">最小长度</param>
        /// <param name="maxLength">最大长度</param>
        /// <param name="errorMsg">错误消息</param>
        /// <returns>验证器</returns>
        public StringValidator IsLengthBetween(int minLength, int maxLength, string errorMsg)
        {
            if (string.IsNullOrEmpty(Value)) return this;
            SetResult(Value.Length >= minLength && Value.Length <= maxLength, errorMsg, ValidationErrorCode.IsLengthBetween);
            return this;
        }

        /// <summary>
        /// 检查字符串是否包含特定字符才
        /// </summary>
        /// <param name="containValue">包含的值</param>
        /// <param name="errorMsg">错误消息</param>
        /// <returns>验证器</returns>
        public StringValidator Contains(string containValue, string errorMsg)
        {
            if (string.IsNullOrEmpty(Value)) return this;
            SetResult(Value.Contains(containValue), errorMsg, ValidationErrorCode.StringContains);
            return this;
        }

    }
}
