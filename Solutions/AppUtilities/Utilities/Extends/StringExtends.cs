using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using WitsWay.Utilities.Enums;
using WitsWay.Utilities.Errors;
using WitsWay.Utilities.Helpers;
using WitsWay.Utilities.Providers.ParseProviders;

namespace WitsWay.Utilities.Extends
{
    /// <summary>
    /// 字符串扩展
    /// </summary>
    public static class StringExtends
    {

        #region [CutStringLength]

        /// <summary>
        /// 截取标题字数
        /// </summary>
        /// <param name="str">准备截取的字符串</param>
        /// <param name="len">截取长度</param>
        /// <param name="suffix">超过长度显示字符串</param>
        /// <returns></returns>
        public static string CutStringLength(this string str, int len, string suffix)
        {
            var intLen = str.Length;
            var start = 0;
            var end = intLen;
            var single = 0;
            var chars = str.ToCharArray();
            for (var i = 0; i < chars.Length; i++)
            {
                if (Convert.ToInt32(chars[i]) > 255)//针对汉字
                {
                    start += 2;
                }
                else//针对字母
                {
                    start += 1;
                    single++;
                }
                if (start >= len)
                {

                    if (end % 2 == 0)
                    {
                        if (single % 2 == 0)
                        {
                            end = i + 1;
                        }
                        else
                        {
                            end = i;
                        }
                    }
                    else
                    {
                        end = i + 1;
                    }
                    break;
                }
            }
            var temp = str.Substring(0, end);
            if (str.Length > end)
            {
                return temp + suffix;
            }
            return temp + suffix;
        }
        #endregion

        #region [GetChineseInitial]
        /// <summary>
        /// 取得拼音首字母
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static string GetChineseInitial(this string str)
        {
            var len = str.Length;
            var myStr = "";
            for (var i = 0; i < len; i++)
            {
                myStr += GetOneCharacterSpell(str.Substring(i, 1));
            }
            return myStr;
        }

        private static string GetOneCharacterSpell(string cnChar)
        {
            var arrCN = Encoding.Default.GetBytes(cnChar);
            if (arrCN.Length > 1)
            {
                int area = arrCN[0];
                int pos = arrCN[1];
                var code = (area << 8) + pos;
                int[] areacode = { 45217, 45253, 45761, 46318, 46826, 47010, 47297, 47614, 48119, 48119, 49062, 49324, 49896, 50371, 50614, 50622, 50906, 51387, 51446, 52218, 52698, 52698, 52698, 52980, 53689, 54481 };
                for (var i = 0; i < 26; i++)
                {
                    var max = 55290;
                    if (i != 25) max = areacode[i + 1];
                    if (areacode[i] <= code && code < max)
                    {
                        return Encoding.Default.GetString(new[] { (byte)(65 + i) });
                    }
                }
                return "*";
            }
            return cnChar;
        }
        #endregion

        #region [ToHash]

        /// <summary>
        /// Hash加密
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="hashAlgorithm">哈希类型</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException">未实现对应的哈希Algorithm</exception>
        public static string ToHash(this string str, HashAlgorithmKinds hashAlgorithm)
        {
            var retval = string.Empty;
            if (!string.IsNullOrEmpty(str))
            {
                var data = Encoding.Default.GetBytes(str);
                switch (hashAlgorithm)
                {
                    case HashAlgorithmKinds.Md5:
                        {
                            #region md5
                            MD5 md5 = new MD5CryptoServiceProvider();
                            md5.TransformFinalBlock(data, 0, data.Length);
                            foreach (var b in md5.Hash)
                            {
                                retval += Convert.ToString(b, 16).ToUpper(CultureInfo.InvariantCulture).PadLeft(2, '0');
                            }
                            md5.Clear();
                            #endregion
                            break;
                        }
                    case HashAlgorithmKinds.Sha160:
                        {
                            #region sha160
                            SHA1 sha1 = new SHA1Managed();
                            sha1.TransformFinalBlock(data, 0, data.Length);
                            foreach (var b in sha1.Hash)
                            {
                                retval += Convert.ToString(b, 16).ToUpper(CultureInfo.InvariantCulture).PadLeft(2, '0');
                            }
                            sha1.Clear();
                            #endregion
                            break;
                        }
                    case HashAlgorithmKinds.Sha256:
                        {
                            #region sha256
                            SHA256 sha2 = new SHA256Managed();
                            sha2.TransformFinalBlock(data, 0, data.Length);
                            foreach (var b in sha2.Hash)
                            {
                                retval += Convert.ToString(b, 16).ToUpper(CultureInfo.InvariantCulture).PadLeft(2, '0');
                            }
                            sha2.Clear();
                            #endregion
                            break;
                        }
                    case HashAlgorithmKinds.Sha384:
                        {
                            #region sha384
                            SHA384 sha3 = new SHA384Managed();
                            sha3.TransformFinalBlock(data, 0, data.Length);
                            foreach (var b in sha3.Hash)
                            {
                                retval += Convert.ToString(b, 16).ToUpper(CultureInfo.InvariantCulture).PadLeft(2, '0');
                            }
                            sha3.Clear();
                            #endregion
                            break;
                        }
                    case HashAlgorithmKinds.Sha512:
                        {
                            #region sha512
                            SHA512 sha5 = new SHA512Managed();
                            sha5.TransformFinalBlock(data, 0, data.Length);
                            foreach (var b in sha5.Hash)
                            {
                                retval += Convert.ToString(b, 16).ToUpper(CultureInfo.InvariantCulture).PadLeft(2, '0');
                            }
                            sha5.Clear();
                            #endregion
                            break;
                        }
                    default:
                        {
                            throw new NotImplementedException($"未实现{hashAlgorithm}对应的哈希Algorithm");
                        }
                }
            }
            return retval;
        }
        #endregion

        #region [Left]

        /// <summary>
        /// 取左
        /// </summary>
        public static string Left(this string str, int length)
        {
            if (string.IsNullOrEmpty(str))
            {
                return string.Empty;
            }
            if (str.Length > length)
            {
                str = str.Substring(0, length);
            }
            return str;
        }

        #endregion

        #region [Right]

        /// <summary>
        /// 取右
        /// </summary>
        public static string Right(this string str, int length)
        {
            if (string.IsNullOrEmpty(str))
            {
                return string.Empty;
            }
            if (str.Length > length)
            {
                str = str.Substring(str.Length - length, length);
            }
            return str;
        }

        #endregion

        #region [Middle]

        /// <summary>
        /// 取中
        /// </summary>
        public static string Middle(this string value, int startIndex, int length)
        {
            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }
            value = value.Substring(startIndex, length);
            return value;
        }

        #endregion

        #region [Is Type]

        /// <summary>
        /// 是否是日期
        /// </summary>
        public static bool IsDate(this string value)
        {
            DateTime date;
            return DateTime.TryParse(value, out date);
        }
        /// <summary>
        /// 是否Int型
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsInt(this string value)
        {
            int info;
            return int.TryParse(value, out info);
        }
        /// <summary>
        /// 是否Bool型
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsBool(this string value)
        {
            bool info;
            return bool.TryParse(value, out info);
        }
        /// <summary>
        /// 是否Decimal型
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool Isdecimal(this string value)
        {
            decimal info;
            return decimal.TryParse(value, out info);
        }
        /// <summary>
        /// 是否Tinyint型
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsTinyint(this string value)
        {
            byte info;
            return byte.TryParse(value, out info);
        }
        #endregion

        #region ToDateTime

        /// <summary>
        /// 将string转为DateTime，如果字符串不是正确的日期值，将返回DateTime.MinValue
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this string source)
        {
            return ToDateTimeNullable(source) ?? DateTime.MinValue;
        }

        /// <summary>
        /// 将string转为DateTime，如果字符串不是正确的日期值，将返回null
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static DateTime? ToDateTimeNullable(this string source)
        {
            DateTime dateTime;
            if (DateTime.TryParse(source, out dateTime))
                return dateTime;
            return null;
        }

        #endregion

        #region ToInt32

        /// <summary>
        /// 将字符串转为数字,如果转换失败则返回默认值
        /// </summary>
        /// <param name="source">字符串</param>
        /// <param name="defaultValue">转换失败时返回的默认值</param>
        /// <returns></returns>
        public static int ToInt(this string source, int defaultValue = 0)
        {
            int i;
            return int.TryParse(source, out i) ? i : defaultValue;
        }

        #endregion

        #region  [Split/Join]

        /// <summary>
        /// 将字符串转为数字,如果转换失败则返回默认值
        /// </summary>
        /// <param name="source">字符串</param>
        /// <returns>添加了逗号分隔的字符串</returns>
        public static string AddCommaSplit(this string source)
        {
            return "," + source;
        }

        /// <summary>
        /// 解析实体
        /// </summary>
        /// <typeparam name="T">转换类型</typeparam>
        /// <param name="val">值</param>
        /// <returns>实体实例</returns>
        public static List<T> SplitToList<T>(this string val)
        {
            var result = new List<T>();
            if (string.IsNullOrWhiteSpace(val)) return result;
            var stringArray = val.Split(UtilityStatics.StringSplitCharsArray, StringSplitOptions.RemoveEmptyEntries);
            if (!stringArray.Any()) return result;
            try
            {
                result = stringArray.Select(one => one.CastTo<T>()).ToList();
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                throw new InvalidCastException($"{val}无法转换为{typeof(T)}列表");
            }
            return result;
        }

        #endregion

        #region [Parse]

        /// <summary>
        /// 解析Json实体
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="val">值</param>
        /// <returns>实体实例</returns>
        public static T ParseJson<T>(this string val) where T : class, new()
        {
            var provider = ParserFactory.JsonParser;
            return provider.Parse<T>(val);
        }

        /// <summary>
        /// 解析Xml实体
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="val">值</param>
        /// <returns>实体实例</returns>
        public static T ParseXml<T>(this string val) where T : class, new()
        {
            var provider = ParserFactory.XmlParser;
            return provider.Parse<T>(val);
        }
        /// <summary>
        /// 解析实体
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="val">值</param>
        /// <param name="providerName"> </param>
        /// <returns>实体实例</returns>
        public static T ParseEntity<T>(this string val, string providerName) where T : class, new()
        {
            var provider = ParserFactory.GetParser(providerName);
            if (provider == null) throw ExceptionHelper.GetProgramException(UtilityErrors.NotSupportParseProvider, providerName);
            return provider.Parse<T>(val);
        }

        #endregion
        
    }
}
