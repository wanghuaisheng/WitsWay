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
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WitsWay.Utilities.Validate.Annotations;

namespace WitsWay.Utlities.Tests.Utilities.Validates
{

    /// <summary>
    /// 使用SharpZipLib来完成打包解包
    /// </summary>
    [TestClass]
    public class ValidateTests
    {

        /// <summary>
        /// 打包压缩文件夹测试
        /// </summary>
        [TestMethod]
        public void ValidateTest()
        {
            var model = new ValidateModel
            {
                AdminInitPassword = "123",
                IntTest = 100,
                Password1 = "12345",
                Password2 = "123451",
                RegexValue = "1235",
                Nest = new NestModel { String1 = "string1" }
            };
            // 获取验证结果列表
            var results = model.GetValidateResults();

            Assert.IsTrue(results.Count == 6);
            ////////// 验证模型是否有效
            ////////bool valid = model.ValidateValid();
            ////////// 抛出验证结果集中的 第一条验证不通过信息
            ////////model.ThrowValidateResult();
            ////////// 抛出验证结果集中的 所有验证不通过信息
            ////////model.ThrowValidateResults();
        }

        [CustomValidation(typeof(ValidateModel), "ValidateNestModel")]
        public class NestModel
        {
            public string String1 { get; set; }
        }

        public class ValidateModel : IValidateModel
        {
            [Range(1000, 6000, ErrorMessage = "值要在1000-6000")]
            public int IntTest { get; set; }
            [MinLength(5, ErrorMessage = "至少五个字符")]
            public string Password1 { get; set; }
            [Compare("Password1", ErrorMessage = "两次密码不同")]
            public string Password2 { get; set; }
            [EmailAddress(ErrorMessage = "错误的邮件地址")]
            public string Email { get; set; }
            [RegularExpression(@"^\d{4}$", ErrorMessage = "格式错误")]
            public string RegexValue { get; set; }
            /// <summary>
            /// 管理员初始密码
            /// </summary>
            //[Required(ErrorMessage = "请输入密码")]
            //[CustomValidation(typeof(ValidateModel), "ValidateAdminInitPassword")]
            [CustomValidator(CustomValidatorKeys.TestCustomValidator)]
            //[StringLength(60, MinimumLength = 20, ErrorMessage = "20-60个字符")]
            public string AdminInitPassword { get; set; }

            //[Required(ErrorMessage = "对象为空")]
            //[CustomValidation(typeof(ValidateModel), "ValidateNestModel")]
            public NestModel Nest { get; set; }

            public static ValidationResult ValidateAdminInitPassword(string pwd, ValidationContext context)
            {
                var isValid = pwd == "123456";
                if (isValid) return ValidationResult.Success;
                return new ValidationResult("2密码不是123456");
            }

            public static ValidationResult ValidateNestModel(NestModel model, ValidationContext context)
            {
                var isValid = model.String1 == "string2";
                if (isValid) return ValidationResult.Success;
                return new ValidationResult("嵌套对象自定义验证不通过");
            }

        }
    }
}
