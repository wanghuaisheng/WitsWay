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
namespace WitsWay.Utilities.Validate
{
    /// <summary>
    /// 正则字符串
    /// </summary>
    public class RegexStrings
    {
        /// <summary>
        /// 匹配HTML标记的正则表达式
        /// </summary>
        public const string HtmlLabelRegex = @"<(.*)>.*<\/\1>|<(.*) \/>";//例如：<title></title>

        /// <summary>
        /// 正整数
        /// </summary>
        public const string PositiveIntegerRegex = @"^[0-9]*[1-9][0-9]*$";
        /// <summary>
        /// 负整数
        /// </summary>
        public const string NegativeIntegerRegex = @"^-[0-9]*[1-9][0-9]*$";
        /// <summary>
        /// 整数
        /// </summary>
        public const string IntegerRegex = @"-?\d+$";
        /// <summary>
        /// 正浮点数
        /// </summary>
        public const string PositiveFloatRegex = @"^(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*))$";
        /// <summary>
        /// 负浮点数
        /// </summary>
        public const string NegativeFloatRegex = @"^(-(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*)))$";
        /// <summary>
        /// 浮点数
        /// </summary>
        public const string FloatRegex = @"^(-?\d+)(\.\d+)?$";
        /// <summary>
        /// 26个英文字(不区分大小写)
        /// </summary>
        public const string LetterRegex = "^[A-Za-z]+$";
        /// <summary>
        /// 26个大写英文字母
        /// </summary>
        public const string CapitalLetterRegex = "^[A-Z]+$";

        /// <summary>
        /// 26个小写英文字母:
        /// </summary>
        public const string LowercaseRegex = "^[a-z]+$";
        /// <summary>
        /// 数字和26个英文字母混合
        /// </summary>
        public const string NumberAndLetterRegex = "^[A-Za-z0-9]+$";
        /// <summary>
        /// 数字和26个英文字母和下划线混合
        /// </summary>
        public const string NumberLetterUnderlineRegex = @"^\w+$";

        /// <summary>
        /// Email地址正则表达式
        /// </summary>
        public const string EmailRegex = @"^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,3})$";
        /// <summary>
        ///Url正则表达式
        /// </summary>
        public const string UrlRegex = @"^((((http|https):\/\/)|^)[\w-_]+(\.[\w-_]+)+([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?)$";
        /// <summary>
        /// 中国电话: 例如：021-8888888 或者0515-88888888 或者 021-88888888-8888
        /// </summary>
        public const string ChinaPhoneRegex = @"((\d{3,4})|(\d{3,4}-))?\d{7,8}(-\d{4})*";
        /// <summary>
        ///中国邮政编码 
        /// </summary>
        public const string ChinaPostCodeRegex = @"[1-9]\d{5}(?!\d)";
        /// <summary>
        /// 中国手机
        /// </summary>
        public const string ChinaMobileRegex = @"(86)*0*13\d{9}";
        /// <summary>
        /// 中国电话包括手机
        /// </summary>
        public const string ChinaPhoneAndMobileRegex = @"(\(\d{3,4}\)|\d{3,4}-|\s)?\d{7,14}";
        /// <summary>
        /// QQ号
        /// </summary>
        public const string QQRegex = "^[1-9]*[1-9][0-9]*$";
        /// <summary>
        /// IP地址
        /// </summary>
        public const string IPRegex = @"^(\d{1,2}|1\d\d|2[0-4]\d|25[0-5]).(\d{1,2}|1\d\d|2[0-4]\d|25[0-5]).(\d{1,2}|1\d\d|2[0-4]\d|25[0-5]).(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])$";
        /// <summary>
        /// 中国身份证号
        /// </summary>
        public const string IdentityNo = @"(^\d{6}\d{2}[01]\d[0123]\d{4}$)|(^\d{6}(18|19|20)\d{2}[01]\d[0123]\d{4}(\d|X|x){1}$)";
    }
}
