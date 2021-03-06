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
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WitsWay.Utilities.Attributes;
using WitsWay.Utilities.Extends;

namespace WitsWay.Utlities.Tests.Utilities.Extents
{
    [TestClass]
    public class EnumExtensionTest
    {
        [TestMethod]
        public void GetDescriptionTest()
        {
            var sex = Sex.Female;
            var fieldDescription = sex.GetDescription();
            var enumDescription = sex.GetEnumDescription();
            var field = sex.GetFieldInfo();
            var fields = sex.GetFieldInfos();
            Assert.AreEqual("女", fieldDescription);
            Assert.AreEqual("性别", enumDescription);
            Assert.IsTrue(field != null && field.FieldName == "Female" && field.DisplayText == "女");
            Assert.IsTrue(fields != null && fields.Count == 2);
        }

        [TestMethod]
        public void TempTest20170324()
        {

            //var eCode = ErrorInfoFactory.GetErrorCode(SubSystem.ERPWeb, ConContractErrors.ContractInfoNotExist);

            //var errCode = ConContractErrors.ContractInfoNotExist.GetErrorCode(SubSystem.ERPWeb);
            //var errText = ConContractErrors.ContractInfoNotExist.GetErrorText();

            //var bEx = ExceptionHelper.GetBusinessException(errCode, errText);
            //var pEx = ExceptionHelper.GetProgramException(errCode, errText);

            ////ExceptionHelper.ThrowBusinessException(errCode, errText);
            ////ExceptionHelper.ThrowBusinessException(SubSystem.ERPWeb, ConContractErrors.ContractSelfNoCanNotEmpty);
            ////ExceptionHelper.ThrowProgramException(SubSystem.ERPWeb, ConContractErrors.ContractSelfNoExisted, new ArgumentNullException("错误信息"));

            ////ExceptionHelper.ThrowProgramException(errCode, errText, new ArgumentException("参数错误"));

            var a = 1;
            var aString = a.ToString("00");
            Assert.AreEqual("01", aString);

            var list = new List<Person>
            {
                new Person {Name="Name1",Sex=Sex.Male}
            };

            var list2 = list.Where(one => one.Sex == Sex.Female).ToList();

            var list3 = list.FindAll(one => one.Sex == Sex.Female);

            Assert.IsNotNull(list2);
            Assert.IsNotNull(list3);
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public Sex Sex { get; set; }
    }

    [EnumField("性别")]
    public enum Sex
    {
        [EnumField("男")] Male = 0,
        [EnumField("女")] Female = 1
    }
}
