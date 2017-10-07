using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WitsWay.Utilities.Attributes;

namespace WitsWay.Utlities.Tests.Utilities.Attributes
{

    [EnumDescription("性别枚举")]
    public enum TestEnumSex
    {

        [EnumDescription("男")]
        Male,
        [EnumDescription("女")]
        Female
    }

    [EnumDescription("支持功能")]
    [Flags]
    public enum TestEnumSupports
    {

        [EnumDescription("登录")]
        Login = 1,
        [EnumDescription("登出")]
        Logout = 2,
        [EnumDescription("修改")]
        Modify = 4
    }

    [TestClass]
    public class EnumDescriptionTests : Attribute
    {


        [TestMethod]
        public void GetEnumTextTest()
        {
            var txt = EnumDescription.GetEnumText(typeof(TestEnumSex));
            Assert.AreEqual(txt, "性别枚举");
        }


        [TestMethod]
        public void GetFlagShowTest()
        {
            var flags = EnumDescription.GetFlagShow(TestEnumSupports.Login | TestEnumSupports.Logout, "|");
            Assert.AreEqual(flags, "登录|登出");
        }


    }
}