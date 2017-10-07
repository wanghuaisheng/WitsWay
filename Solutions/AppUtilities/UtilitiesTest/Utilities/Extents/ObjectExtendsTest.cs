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
using WitsWay.Utilities.Extends;

namespace WitsWay.Utlities.Tests.Utilities.Extents
{


    /// <summary>
    ///这是 ObjectExtendsTest 的测试类，旨在
    ///包含所有 ObjectExtendsTest 单元测试
    ///</summary>
    [TestClass]
    public class ObjectExtendsTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///获取或设置测试上下文，上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region 附加测试特性
        // 
        //编写测试时，还可使用以下特性:
        //
        //使用 ClassInitialize 在运行类中的第一个测试前先运行代码
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //使用 ClassCleanup 在运行完类中的所有测试后再运行代码
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //使用 TestInitialize 在运行每个测试前先运行代码
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //使用 TestCleanup 在运行完每个测试后运行代码
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///CanConvertTo 的测试
        ///</summary>
        [TestMethod]
        public void CanConvertToTest()
        {
            var value = "aaa";
            var targetType = typeof(int);
            var actual = value.CanConvertTo(targetType);
            Assert.IsFalse(actual);

            value = "123";
            actual = value.CanConvertTo(targetType);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void CastToTest()
        {
            var dbNull = DBNull.Value;
            var result = dbNull.CastTo<DateTime?>();
            Assert.IsNull(result);
        }

        [TestMethod]
        public void CastIntToTest()
        {
            var d1 = "1.3".CastTo<decimal>();
            var i1 = d1.CastTo<int>();
            Assert.AreEqual(1, i1);

            var d2 = "2.5".CastTo<decimal>();
            var i2 = d2.CastTo<int>();
            Assert.AreEqual(2, i2);

            var d3 = "4".CastTo<decimal>();
            var i3 = d3.CastTo<int>();
            Assert.AreEqual(4, i3);

            var d4 = "2.6".CastTo<decimal>();
            var i4 = d4.CastTo<int>();
            Assert.AreEqual(3, i4);

        }
    }
}
