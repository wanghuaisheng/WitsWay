using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WitsWay.Utilities.Helpers;

namespace WitsWay.Utlities.Tests.Utilities.Helpers
{

    /// <summary>
    /// 使用SharpZipLib来完成打包解包
    /// </summary>
    [TestClass]
    public class ZipHelperTests
    {

        /// <summary>
        /// 打包压缩文件夹测试
        /// </summary>
        [TestMethod]
        public void PackTest()
        {
            var targetPath = "d:\\解压文件\\压缩测试.zip";
            var sourceFolder = "d:\\临时文件\\";

            var isOk = ZipHelper.Pack(targetPath, sourceFolder);
            Assert.IsTrue(File.Exists(targetPath));
        }

        /// <summary>
        /// 解压缩文件测试
        /// </summary>
        [TestMethod]
        public void UnpackTest()
        {
            //指定一个文件给解压
            var sourcePath = "d:\\解压文件\\压缩测试.zip";
            var targetFolder = "d:\\解压文件\\";
            var isOk = ZipHelper.Unpack(sourcePath, targetFolder);
            Assert.IsTrue(isOk);
        }

        /// <summary>
        /// 压缩文件带密码
        /// </summary>
        [TestMethod]
        public void ZipFileWithPasswordTest()
        {
            var sourcePath = "d:\\解压文件\\压缩测试.zip";
            var targetPath = "d:\\解压文件\\压缩测试加密.zip";

            var isOk = ZipHelper.ZipFileWithPassword(sourcePath, targetPath, "111111");
            Assert.IsTrue(File.Exists(targetPath));
        }

        /// <summary>
        /// 解压文件带密码
        /// </summary>
        [TestMethod]
        public void UnZipFileWithPasswordTest()
        {
            var sourcePath = "d:\\解压文件\\压缩测试已加密.zip";
            var targetPath = "d:\\解压文件\\压缩测试已解密.zip";

            var isOk = ZipHelper.UnZipFileWithPassword(sourcePath, targetPath, "111111");
            Assert.IsTrue(File.Exists(targetPath));
        }
       
    }
}
