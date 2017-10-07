using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WitsWay.Utilities.Helpers;

namespace WitsWay.Utlities.Tests.Utilities.Helpers
{

    /// <summary>
    /// 集合辅助类
    /// </summary>
    [TestClass]
    public class CollectionHelperTests
    {
        /// <summary>
        /// 转换表为字典测试
        /// </summary>
        [TestMethod]
        public void CastListToDictionary()
        {
            var list = new List<string>();
            list.Add("1");
            list.Add("22");
            list.Add("333");
            list.Add("55555");
            list.Add("7777777");
            var obj = CollectionHelper.CastListToDictionary(list, a => a.Length);
            Assert.AreEqual(obj[2], "22");

        }

    }
}
