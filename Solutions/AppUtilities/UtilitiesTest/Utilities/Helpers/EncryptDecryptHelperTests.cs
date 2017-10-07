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
