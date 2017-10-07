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
using System.IO;
using System.Security.Cryptography;
using WitsWay.Utilities.Enums;

namespace WitsWay.Utilities.Helpers
{
    /// <summary>
    /// HashAlgorithm帮助类
    /// </summary>
    public class HashAlgorithmHelper
    {
        /// <summary>
        /// 计算哈希值
        /// </summary>
        /// <param name="stream">要计算哈希值的 Stream</param>
        /// <param name="hashKind">Hash算法类型</param>
        /// <returns>哈希值字节数组</returns>
        /// <exception cref="NotImplementedException">未实现“Hash算法类型”对应哈希算法</exception>
        public static string HashData(Stream stream, HashAlgorithmKinds hashKind)
        {
            var algorithm = HashAlgorithm.Create(hashKind.ToString());
            if (algorithm == null) throw new NotImplementedException($"未实现{hashKind}对应哈希算法");
            var hashBytes = algorithm.ComputeHash(stream);
            return ByteArrayToHexString(hashBytes);
        }

        /// <summary> 
        /// 字节数组转换为16进制表示的字符串
        /// </summary>
        private static string ByteArrayToHexString(byte[] buf)
        {
            return BitConverter.ToString(buf).Replace("-", "");
        }
    }


}
