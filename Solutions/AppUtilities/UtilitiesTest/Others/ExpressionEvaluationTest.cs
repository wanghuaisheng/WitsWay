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
