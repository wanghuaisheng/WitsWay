using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WitsWay.Utilities.Attributes;
using WitsWay.Utilities.Helpers;

namespace WitsWay.Utlities.Tests.Utilities.Helpers
{
    /// <summary>
    /// 枚举辅助类
    /// </summary>
    [TestClass]
    public class EnumHelperTests
    {
        /// <summary>
        /// 取得枚举值测试
        /// </summary>
        [TestMethod]
        public void GetEnumValueListTest()
        {
            var result = EnumHelper.GetEnumValueList<TestEnumSupports>();
            Assert.AreEqual(result[2], 4);
        }

        /// <summary>
        /// 数字转换为枚举测试
        /// </summary>
        [TestMethod]
        public void ParseEnum1Test()
        {
            var result = EnumHelper.ParseEnum<TestEnumSupports>(1);
            Assert.AreEqual(result, TestEnumSupports.Login);
        }

        /// <summary>
        /// 字符串转换为枚举测试
        /// </summary>
        [TestMethod]
        public void ParseEnum2Test()
        {
            var result = EnumHelper.ParseEnum<TestEnumSupports>("Login");
            Assert.AreEqual(result, TestEnumSupports.Login);
        }
        


    }

    [EnumFieldAttribute("支持功能")]
    [Flags]
    public enum TestEnumSupports
    {

        [EnumFieldAttribute("登录")]
        Login = 1,
        [EnumFieldAttribute("登出")]
        Logout = 2,
        [EnumFieldAttribute("修改")]
        Modify = 4
    }

}
