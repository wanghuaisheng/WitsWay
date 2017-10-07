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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace WitsWay.Utilities.Helpers
{
    /// <summary>
    /// 路径码辅助类
    /// </summary>
    public class PathCodeHelper
    {

        /// <summary>
        /// 取得路径码
        /// </summary>
        /// <param name="compareCodes"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">compareCodes参数为空或Count为0时抛出</exception>
        /// <exception cref="ArgumentOutOfRangeException">路径码超出最大值ZZ</exception>
        /// <exception cref="ArgumentException">路径码只能由A到Z大写字母组成</exception>
        public static string GetPathCode(IEnumerable<string> compareCodes)
        {
            if (compareCodes != null&&compareCodes.Count()>0)
            {
                var code = compareCodes.Max();
                return PathCodeAddOne(code);
            }
            throw new ArgumentNullException("获取路径码时传入路径码为空");
        }

        /// <summary>
        /// 路径码加1，加1后到超过全Z则返回全A
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string PathCodeAddOne(string code)
        {
            //非空先验
            if(string.IsNullOrEmpty(code)){
                throw new ArgumentNullException("递增路径码时传入路径码为空");
            }
            var reg = new Regex("[A-Z]+", RegexOptions.Singleline);
            if (reg.Match(code).Success)
            {
                var chars = code.ToCharArray().Select(c=>(byte)c).ToArray();
                var handled = false;
                var charNum = chars.Length;
                for(var i=charNum-1;i>=0;i--)
                {
                    if (chars[i]<(byte)'Z')
                    {
                        chars[i]=(byte)(chars[i]+1);
                        if (i < charNum - 1)
                        {
                            for (var j = charNum - 1; j > i; j--)
                            {
                                chars[j] = (byte)'A';
                            }
                        }
                        handled = true;
                        break;
                    }
                }
                if (handled)
                {
                    return Encoding.ASCII.GetString(chars.ToArray());
                }
                throw new ArgumentOutOfRangeException("路径码超出最大值ZZ");
                //return code.Replace('Z', 'A');
            }
            throw new ArgumentException("路径码只能由A到Z大写字母组成");
        }

    }
}
