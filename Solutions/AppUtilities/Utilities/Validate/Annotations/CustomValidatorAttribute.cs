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
using System.ComponentModel.DataAnnotations;

namespace WitsWay.Utilities.Validate.Annotations
{
    /// <summary>
    /// 自定义验证器
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Method | AttributeTargets.Parameter, AllowMultiple = true)]
    public sealed class CustomValidatorAttribute : ValidationAttribute
    {
        /// <summary>
        /// 验证键
        /// </summary>
        public string ValidatorKey { get; private set; }

        /// <summary>
        /// 自定义验证器
        /// </summary>
        public CustomValidatorAttribute(string validatorKey)
        {
            ValidatorKey = validatorKey;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var validator = CustomValidatorFactory.GetCustomValidator(ValidatorKey);
            var result = validator.Validate(value, validationContext);
            if (result != null) ErrorMessage = result.ErrorMessage;
            return result;
        }

    }
}