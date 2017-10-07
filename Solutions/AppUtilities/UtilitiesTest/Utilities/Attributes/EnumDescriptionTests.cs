using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WitsWay.Utilities.Attributes;

namespace WitsWay.Utlities.Tests.Utilities.Attributes
{

    [EnumFieldAttribute("性别枚举")]
    public enum TestEnumSex
    {

        [EnumFieldAttribute("男")]
        Male,
        [EnumFieldAttribute("女")]
        Female
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

    [TestClass]
    public class EnumDescriptionTests : Attribute
    {


        [TestMethod]
        public void GetEnumTextTest()
        {
            var txt = EnumFieldAttribute.GetEnumText(typeof(TestEnumSex));
            Assert.AreEqual(txt, "性别枚举");
        }


        [TestMethod]
        public void GetFlagShowTest()
        {
            var flags = EnumFieldAttribute.GetFlagShow(TestEnumSupports.Login | TestEnumSupports.Logout, "|");
            Assert.AreEqual(flags, "登录|登出");
        }


    }
}