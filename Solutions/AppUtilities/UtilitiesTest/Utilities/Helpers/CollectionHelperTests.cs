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
