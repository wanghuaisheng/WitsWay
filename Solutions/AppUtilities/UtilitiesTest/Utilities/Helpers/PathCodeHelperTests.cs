/******************************************
 * 2012年5月3日 王怀生 添加
 * 
 * ***************************************/

using Microsoft.VisualStudio.TestTools.UnitTesting;
using WitsWay.Utilities.Helpers;

namespace WitsWay.Utlities.Tests.Utilities.Helpers
{
    /// <summary>
    /// 路径码辅助类
    /// </summary>

    [TestClass]
    public class PathCodeHelperTests
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
        ///PathCodeAddOne 的测试
        ///</summary>
        [TestMethod]
        public void PathCodeAddOneTest()
        {
            Assert.AreEqual("BA", PathCodeHelper.PathCodeAddOne("AZ"));
            Assert.AreEqual("BABB", PathCodeHelper.PathCodeAddOne("BABA"));
            Assert.AreEqual("CAAAA", PathCodeHelper.PathCodeAddOne("BZZZZ"));
            Assert.AreEqual("BZBZCA", PathCodeHelper.PathCodeAddOne("BZBZBZ"));
        }

    }
}
