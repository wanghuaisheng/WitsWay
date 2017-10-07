using Microsoft.VisualStudio.TestTools.UnitTesting;
using WitsWay.Utilities.Helpers;

namespace WitsWay.Utlities.Tests.Utilities.Helpers
{

	/// <summary>
	/// �ӽ��ܸ�����
    /// </summary>
    [TestClass]
    public class EncryptDecryptHelperTests
    {

        /// <summary>
        /// DES�ӽ��ܲ���
        /// </summary>
        [TestMethod]
        public void EncryptDESTest()
        {
            var key = "123456";
            //�ȼ���
            var result = EncryptDecryptHelper.EncryptDES("���Ǳ���������", key);
            //�ٽ���
            result = EncryptDecryptHelper.DecryptDES(result, key);

            Assert.AreEqual(result, "���Ǳ���������");
        }


        /// <summary>
        /// MD5���ܲ���
        /// </summary>
        [TestMethod]
        public void EncryptMD5Test()
        {
            var result = EncryptDecryptHelper.EncryptMD5("���Ǳ���������");

            //������Դ��������MD5���� 32��д
            Assert.AreEqual(result, "6C21D82CDC9AAEF96FB034123C25707B");
        }
       
	}
}
