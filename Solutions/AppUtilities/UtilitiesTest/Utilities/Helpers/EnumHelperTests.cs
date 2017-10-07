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
