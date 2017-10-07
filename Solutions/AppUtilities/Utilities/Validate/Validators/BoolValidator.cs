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
namespace WitsWay.Utilities.Validate.Validators
{
    /// <summary>
    /// bool验证器
    /// </summary>
    public class BoolValidator : ValidatorBase<BoolValidator, bool>
    {

        /// <summary>
        /// 创建BoolValidator实例
        /// </summary>
        /// <param name="value"></param>
        /// <param name="fieldName"></param>
        /// <param name="validatorObj"></param>
        public BoolValidator(string fieldName, bool value, Validator validatorObj)
            : base( fieldName,value, validatorObj)
        {
        }


        /// <summary>
        /// 验证值是否为true
        /// </summary>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public BoolValidator IsTrue(string errorMsg)
        {
            SetResult(Value, errorMsg, ValidationErrorCode.BoolIsNotTrue);
            return this;
        }


        /// <summary>
        /// 验证值是否为false
        /// </summary>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public BoolValidator IsFalse(string errorMsg)
        {
            SetResult(!Value, errorMsg, ValidationErrorCode.BoolIsNotFalse);
            return this;
        }

    }
}
