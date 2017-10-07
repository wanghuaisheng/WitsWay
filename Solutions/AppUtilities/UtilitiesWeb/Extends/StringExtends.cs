using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace WitsWay.Utilities.Web.Extends
{
    /// <summary>
    /// 字符串扩展
    /// </summary>
    public static class StringExtends
    {

        #region [RemoveIllegalCharacters]
        /// <summary>
        /// 移除非法字符
        /// </summary>
        /// <param name="str">要处理的字符串</param>
        /// <returns>处理后的字符串</returns>
        public static string RemoveIllegalCharacters(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;
            ////str = str.ToLower();
            ////str = str.Replace(":", string.Empty);
            ////str = str.Replace("/", string.Empty);
            ////str = str.Replace("?", string.Empty);
            ////str = str.Replace("#", string.Empty);
            ////str = str.Replace("[", string.Empty);
            ////str = str.Replace("]", string.Empty);
            ////str = str.Replace("@", string.Empty);
            ////str = str.Replace(".", string.Empty);
            ////str = str.Replace("\"", string.Empty);
            ////str = str.Replace("&", string.Empty);
            ////str = str.Replace("'", string.Empty);
            ////str = str.Replace(",", string.Empty);
            ////str = str.Replace("select", string.Empty);
            ////str = str.Replace("select", string.Empty);
            ////str = str.Replace("drop", string.Empty);
            ////str = str.Replace("delete", string.Empty);
            ////str = str.Replace("update", string.Empty);
            ////str = str.Replace("script", string.Empty);
            ////str = RemoveDiacritics(str);

            return str;
        }
        #endregion

        #region [RemoveIllegalCharactersUrlEncode]
        /// <summary>
        /// 移除非法字符串并进行Url编码
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string RemoveIllegalCharactersUrlEncode(string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            text = text.Replace(":", string.Empty);
            text = text.Replace("/", string.Empty);
            text = text.Replace("?", string.Empty);
            text = text.Replace("#", string.Empty);
            text = text.Replace("[", string.Empty);
            text = text.Replace("]", string.Empty);
            text = text.Replace("@", string.Empty);
            text = text.Replace(".", string.Empty);
            text = text.Replace("\"", string.Empty);
            text = text.Replace("&", string.Empty);
            text = text.Replace("'", string.Empty);
            text = text.Replace(" ", "-");
            text = RemoveDiacritics(text);

            return HttpUtility.UrlEncode(text).Replace("%", string.Empty);
        }

        private static String RemoveDiacritics(string text)
        {
            var normalized = text.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();

            for (var i = 0; i < normalized.Length; i++)
            {
                var c = normalized[i];
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    sb.Append(c);
            }

            return sb.ToString();
        }
        #endregion

        #region [ClearHtmlLabel]
        /// <summary>
        /// 清除Html字符
        /// </summary>
        public static string ClearHtmlLabel(this string str)
        {
            str = Regex.Replace(str, @"\<(img)[^>]*>|<\/(img)>", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"\<(table|tbody|tr|td|th|)[^>]*>|<\/(table|tbody|tr|td|th|)>", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"\<(div|blockquote|fieldset|legend)[^>]*>|<\/(div|blockquote|fieldset|legend)>", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"\<(font|i|u|h[1-9]|s)[^>]*>|<\/(font|i|u|h[1-9]|s)>", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"\<(style|strong)[^>]*>|<\/(style|strong)>", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"\<a[^>]*>|<\/a>", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"\<(meta|iframe|frame|span|tbody|layer)[^>]*>|<\/(iframe|frame|meta|span|tbody|layer)>", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"\<br[^>]*", "", RegexOptions.IgnoreCase);
            return str;
        }
        #endregion

    }

}
