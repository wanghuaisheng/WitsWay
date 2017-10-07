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
using System.Security.Cryptography;
using WitsWay.Utilities.Enums;

namespace WitsWay.Utilities.Helpers
{

    /// <summary>
    /// HashAlgorithm扩展
    /// </summary>
    public static class HashAlgorithmExtends
    {
        /// <summary>
        /// 获取HashAlgorithm实例
        /// </summary>
        /// <param name="hashKind"></param>
        /// <returns></returns>
        public static HashAlgorithm GetHashAlgorithm(this HashAlgorithmKinds hashKind)
        {
            var algorithm = HashAlgorithm.Create(hashKind.ToString());
            if (algorithm == null) throw new NotImplementedException($"未实现{hashKind}对应哈希算法");
            return algorithm;
        }

    }

}
