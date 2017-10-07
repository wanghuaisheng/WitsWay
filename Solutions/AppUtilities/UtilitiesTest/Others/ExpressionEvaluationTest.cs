using System;
using System.Linq;
using ExpressionEvaluator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WitsWay.Utilities.Extends;

namespace WitsWay.Utlities.Tests.Others
{
    [TestClass]
    public class ExpressionEvaluationTest
    {

        [TestMethod]
        public void TestInvokeMethodWithParams()
        {
            var methods = typeof(ExpressionEvaluationTest).GetMethods();
            var doIt = methods.First(m =>
            {
                if (m.Name != "DoIt") return false;
                var paras = m.GetParameters();
                return paras.Length == 1 && paras[0].ParameterType == typeof(string[]);
            });

            object args = new[] { "1", "2", "3" };
            var obj = typeof(ExpressionEvaluationTest).GetInstance();
            doIt.Invoke(obj, new[] { args });
            DoIt("1", "2", "4");
        }

        public void DoIt(string arg1, string arg2, string arg3)
        {

        }

        public void DoIt(params string[] args)
        {

        }



        [TestMethod]
        public void TestConst()
        {
            var exp = new CompiledExpression("1");
            exp.RegisterDefaultTypes();
            var expr = exp.Compile<Func<decimal>>();

            Assert.AreEqual(1m, expr());
        }

        [TestMethod]
        public void TestUnusedParameter()
        {
            var exp = new CompiledExpression("我_+1");
            exp.RegisterDefaultTypes();
            exp.RegisterParameter("我_", typeof(decimal));
            exp.RegisterParameter("_你", typeof(decimal));

            var expr = exp.Compile<Func<decimal, decimal, decimal>>();
            Assert.AreEqual(2m, expr(1, 1));
        }

        [TestMethod]
        public void TestChineseVariable()
        {
            var exp = new CompiledExpression("我_+1");
            exp.RegisterDefaultTypes();
            exp.RegisterParameter("我_", typeof(decimal));

            var expr = exp.Compile<Func<decimal, decimal>>();
            Assert.AreEqual(2m, expr(1));
        }
    }
}
