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
using System.Text;

namespace WitsWay.Utilities.Extends
{
    /// <summary>
    /// 字符串扩展
    /// </summary>
    public static class ByteExtends
    {

        /// <summary>
        /// byte数组转16进制字符串
        /// </summary>
        /// <param name="bytes">byte数组</param>
        /// <returns>16进制字符串</returns>
        public static string ToHexString(this byte[] bytes)
        {
            if (bytes == null || bytes.Length <= 0) return string.Empty;
            var sb = new StringBuilder();
            foreach (var b in bytes)
            {
                sb.Append(b.ToString("X2"));
            }
            return sb.ToString();
        }

        /// <summary>
        /// byte数组转16进制字符串
        /// </summary>
        /// <param name="bytes">byte数组</param>
        /// <returns>16进制字符串</returns>
        public static string ToHexString2(this byte[] bytes)
        {
            if (bytes == null || bytes.Length <= 0) return string.Empty;
            //utf8转 GBK十六进制码
            var utf8Str = Encoding.UTF8.GetString(bytes);
            var bytes2 = Encoding.GetEncoding("GBK").GetBytes(utf8Str);
            var sb = new StringBuilder();
            foreach (var b in bytes2)
            {
                sb.Append(b.ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
