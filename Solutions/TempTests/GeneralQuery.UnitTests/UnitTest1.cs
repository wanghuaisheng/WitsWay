using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WitsWay.TempTests.DynamicQuery.Enums;

namespace WitsWay.TempTests.GeneralQuery.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.IsTrue((int) SupportRelations.NotIn == (int)Math.Pow(2,19));
        }

    }
}
