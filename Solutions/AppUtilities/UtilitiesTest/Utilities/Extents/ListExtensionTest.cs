using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WitsWay.Utilities.Extends;

namespace WitsWay.Utlities.Tests.Utilities.Extents
{
    [TestClass]
    public class ListExtensionTest
    {
        [TestMethod]
        public void Test_MoveRight()
        {
            var list = new List<int> { 1, 2, 3, 4 };
            list.Move(x => x == 2, 2);
            Assert.AreEqual(2, list[2]);
        }

        [TestMethod]
        public void Test_MoveLeft()
        {
            var list = new List<int> { 1, 2, 3, 4 };
            list.Move(x => x == 2, 1);
            Assert.AreEqual(2, list[1]);
        }

        [TestMethod]
        public void Test_MoveBeginning()
        {
            var list = new List<int> { 1, 2, 3, 4 };
            list.MoveToBeginning(x => x == 4);
            Assert.AreEqual(4, list[0]);
        }

        [TestMethod]
        public void Test_MoveEnd()
        {
            var list = new List<int> { 1, 2, 3, 4 };
            list.MoveToEnd(x => x == 1);
            Assert.AreEqual(1, list[3]);
        }
    }
}
