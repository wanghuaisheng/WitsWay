using Microsoft.VisualStudio.TestTools.UnitTesting;
using WitsWay.Utilities.Helpers;

namespace WitsWay.Utlities.Tests.Utilities.Helpers
{
    /// <summary>
    /// 计算机等设备帮助类
    /// </summary>
    [TestClass]
    public class ComputerHelperTests
    {

        /// <summary>
        /// 取得计算机物理地址测试
        /// </summary>
        [TestMethod]
        public void GetMacAddressTest()
        {
            var info = ComputerHelper.GetMacAddress();
            //此处为192.168.7.77的物理地址
            Assert.AreEqual(info[0], "FC-AA-14-5F-F6-E9");
        }
    }
}
