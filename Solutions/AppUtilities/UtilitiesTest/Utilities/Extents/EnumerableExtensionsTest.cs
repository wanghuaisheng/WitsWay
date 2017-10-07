using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WitsWay.Utilities.Extends;

namespace WitsWay.Utlities.Tests.Utilities.Extents
{


    /// <summary>
    ///这是 EnumerableExtensionsTest 的测试类，旨在
    ///包含所有 EnumerableExtensionsTest 单元测试
    ///</summary>
    [TestClass]
    public class EnumerableExtensionsTest
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

        [TestMethod]
        public void SafeForEachTest()
        {
            var datas = new List<string>
            {
                "123",
                "234",
                "345"
            };
            datas.SafeForEach(one => { if (one == "123") { datas.Remove(one); } }, one => one.Equals("123"), true);
        }

        [TestMethod]
        public void TestStringListJoin()
        {
            var list = new List<string> { "1", "2", "3" };
            Assert.AreEqual("1;2;3", list.Join());
        }

        [TestMethod]
        public void TestIntListJoin()
        {
            var list = new List<int> { 1, 2, 3 };
            Assert.AreEqual("1;2;3", list.Join());
        }

        [TestMethod]
        public void TestIntArrayJoin()
        {
            var list = new[] { 1, 2, 3 };
            Assert.AreEqual("1;2;3", list.Join());
        }

        [TestMethod]
        public void TestCustomObjectListJoin()
        {
            var list = new List<TestClass> { new TestClass(1), new TestClass(2), new TestClass(3) };
            Assert.AreEqual("1;2;3", list.Join());
        }

        public class TestClass
        {
            public TestClass(int @i)
            {
                Int = @i;
            }
            public int Int { get; set; }

            public override string ToString()
            {
                return Int.ToString();
            }
        }
    }
}
