using Microsoft.VisualStudio.TestTools.UnitTesting;
using WitsWay.Utilities.Builders;

namespace WitsWay.Utlities.Tests.Utilities.Builders
{
    [TestClass]
    public class PageParameterBuilderTest
    {
        /// <summary>
        /// 取得错误描述信息测试
        /// </summary>
        [TestMethod]
        public void BuilderTest()
        {
            var para = PageParameterBuilder.NewBuilder()
                 .PageIndex(1)
                 .PageSize(2)
                 .SortColumn("A", true)
                 .SortColumn("B", false)
                 .Result;
            Assert.IsTrue(
                para.PageSize == 2
                && para.PageIndex == 1
                && para.SortColumns[0].SortField == "A"
                && para.SortColumns[0].Ascend
                && para.SortColumns[1].SortField == "B"
                && !para.SortColumns[1].Ascend);
        }

    }
}
