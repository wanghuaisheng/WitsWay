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
    public class EnumFieldAttributeTests : Attribute
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