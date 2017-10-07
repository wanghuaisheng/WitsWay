using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WitsWay.Utilities.Enums;
using WitsWay.Utilities.Helpers;

namespace WitsWay.Utlities.Tests.Utilities.Helpers
{
    /// <summary>
    /// 文件帮助类
    /// </summary>
    [TestClass]
    public class FileHelperTests
    {
        /// <summary>
        /// 获取文件MD5值测试
        /// </summary>
        [TestMethod]
        public void MD5ValueTest()
        {
            var result = FileHelper.MD5Value(@"d:\临时文件\123.txt");
            Assert.IsTrue(result.Length > 0);
        }


        /// <summary>
        /// 获取文件哈希值测试
        /// </summary>
        [TestMethod]
        public void SHA1ValueTest()
        {
            var result = FileHelper.SHA1Value(@"d:\临时文件\123.txt");
            Assert.IsTrue(result.Length > 0);
        }
                
        /// <summary>
        /// 获取文件哈希值测试
        /// </summary>
        [TestMethod]
        public void HashFileTest()
        {
            var resultMD5 = FileHelper.HashFile(@"d:\临时文件\123.txt",HashAlgorithmKinds.Md5);
            var resultRipemd160 = FileHelper.HashFile(@"d:\临时文件\123.txt", HashAlgorithmKinds.Ripemd160);
            var resultSha1 = FileHelper.HashFile(@"d:\临时文件\123.txt", HashAlgorithmKinds.Sha160);
            var resultSha256 = FileHelper.HashFile(@"d:\临时文件\123.txt", HashAlgorithmKinds.Sha256);
            var resultSha384 = FileHelper.HashFile(@"d:\临时文件\123.txt", HashAlgorithmKinds.Sha384);
            var resultSha512 = FileHelper.HashFile(@"d:\临时文件\123.txt", HashAlgorithmKinds.Sha512);

            Assert.IsTrue(resultMD5.Length > 0);
            Assert.IsTrue(resultRipemd160.Length > 0);
            Assert.IsTrue(resultSha1.Length > 0);
            Assert.IsTrue(resultSha256.Length > 0);
            Assert.IsTrue(resultSha384.Length > 0);
            Assert.IsTrue(resultSha512.Length > 0);
        }
        /// <summary>
        /// 保存文件测试
        /// </summary>
        [TestMethod]
        public void SaveFileTest()
        {
            var path = $@"d:\临时文件\test{DateTime.Now.ToString("MMddHHmmssffff")}.txt";
            FileHelper.SaveFile(path, new byte[30], 0, 20);
            Assert.IsTrue(File.Exists(path));
        }

        

    }
}
