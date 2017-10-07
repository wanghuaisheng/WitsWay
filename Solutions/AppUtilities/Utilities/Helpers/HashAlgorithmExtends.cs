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
