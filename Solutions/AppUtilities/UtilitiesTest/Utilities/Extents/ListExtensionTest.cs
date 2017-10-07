﻿#region License(Apache Version 2.0)
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
