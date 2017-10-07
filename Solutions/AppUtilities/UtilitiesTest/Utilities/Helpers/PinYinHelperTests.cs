using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WitsWay.Utilities.Helpers;

namespace WitsWay.Utlities.Tests.Utilities.Helpers
{
    [TestClass]
    public class PinYinHelperTests
    {
        /// <summary>
        /// 获取拼音测试(全中文)
        /// </summary>
        [TestMethod]
        public void TestSimpleMode()
        {
            Assert.AreEqual("Ni Hao", PinYinHelper.GetPinYin("你好"));
        }

        /// <summary>
        /// 获取拼音测试(带英文字母)
        /// </summary>
        [TestMethod]
        public void TestWithSingleNonChineseChar()
        {
            Assert.AreEqual("Ni A Hao", PinYinHelper.GetPinYin("你a好"));
        }

        /// <summary>
        /// 获取拼音测试(带数字)
        /// </summary>
        [TestMethod]
        public void TestWithSingleNumber()
        {
            Assert.AreEqual("Ni 2 Hao", PinYinHelper.GetPinYin("你2好"));
        }

        [TestMethod]
        public void TestOtherMode()
        {
            Assert.AreEqual("Ni3 Hao3", PinYinHelper.GetPinYin("你好", PinYinMode.WithTone));
            Assert.AreEqual("Ni3 Hao3,Hao4", PinYinHelper.GetPinYin("你好", PinYinMode.WithToneAndMultiplePronunciations));
            Assert.AreEqual("Ni Hao", PinYinHelper.GetPinYin("你好", PinYinMode.WithMultiplePronunciations));
            Assert.AreEqual("Cheng,Sheng Fa", PinYinHelper.GetPinYin("乘法", PinYinMode.WithMultiplePronunciations));
        }


        [TestMethod]
        public void TestCombinate()
        {
            Assert.AreEqual(string.Join(",", new List<string>
            {
                "13","23"
            }), string.Join(",", PinYinHelper.Combinate(new List<List<string>>
            {
                new List<string> { "1", "2" }, 
                new List<string> { "3" }
            })));

            Assert.AreEqual(string.Join(",", new List<string>
            {
                "133","134","233","234"
            }), string.Join(",", PinYinHelper.Combinate(new List<List<string>>
            {
                new List<string> { "1", "2" }, 
                new List<string> { "3" },
                new List<string> { "3","4" }
            })));
            Assert.AreEqual(string.Join(",", new List<string>
            {
                "133","134","153","154","233","234","253","254"
            }), string.Join(",", PinYinHelper.Combinate(new List<List<string>>
            {
                new List<string> { "1", "2" }, 
                new List<string> { "3","5" },
                new List<string> { "3","4" }
            })));
            Assert.AreEqual(string.Join(",", new List<string>
            {
                "13","14","23","24","63","64"
            }), string.Join(",", PinYinHelper.Combinate(new List<List<string>>
            {
                new List<string> { "1", "2","6" }, 
                new List<string> { "3","4" }
            })));
        }
    }
}
