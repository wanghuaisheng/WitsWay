using Microsoft.VisualStudio.TestTools.UnitTesting;
using WitsWay.Utilities.Helpers;

namespace WitsWay.Utlities.Tests.Utilities.Helpers
{

	/// <summary>
	/// 加解密辅助类
    /// </summary>
    [TestClass]
    public class EncryptDecryptHelperTests
    {

        /// <summary>
        /// DES加解密测试
        /// </summary>
        [TestMethod]
        public void EncryptDESTest()
        {
            var key = "123456";
            //先加密
            var result = EncryptDecryptHelper.EncryptDES("我是被加密数据", key);
            //再解密
            result = EncryptDecryptHelper.DecryptDES(result, key);

            Assert.AreEqual(result, "我是被加密数据");
        }


        /// <summary>
        /// MD5加密测试
        /// </summary>
        [TestMethod]
        public void EncryptMD5Test()
        {
            var result = EncryptDecryptHelper.EncryptMD5("我是被加密数据");

            //数据来源网络在线MD5加密 32大写
            Assert.AreEqual(result, "6C21D82CDC9AAEF96FB034123C25707B");
        }
       
	}
}
