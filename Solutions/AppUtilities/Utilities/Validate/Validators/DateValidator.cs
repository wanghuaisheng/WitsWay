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
using System;
using WitsWay.Utilities.Extends;

namespace WitsWay.Utilities.Validate.Validators
{

    /// <summary>
    /// DateTime验证器
    /// </summary>
    public class DateValidator : ValidatorBase<DateValidator, DateTime>
    {
        /// <summary>
        /// 创建DateValidator实例
        /// </summary>
        /// <param name="value"></param>
        /// <param name="fieldName"></param>
        /// <param name="validatorObj"></param>
        public DateValidator( string fieldName,DateTime value, Validator validatorObj) : base(fieldName, value, validatorObj)
        {

        }

        /// <summary>
        /// 是日期最大值DateTime.MaxValue
        /// </summary>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public DateValidator IsMaxValue(string errorMsg)
        {
            SetResult(( Value == DateTime.MaxValue), errorMsg, ValidationErrorCode.DateIsNotMaxValue);
            return this;
        }

        /// <summary>
        /// 不是日期最大值DateTime.MaxValue
        /// </summary>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public DateValidator NotMaxValue(string errorMsg)
        {
            SetResult((Value != DateTime.MaxValue), errorMsg, ValidationErrorCode.DateIsNotMaxValue);
            return this;
        }

        /// <summary>
        /// 是日期最小值DateTime.MinValue
        /// </summary>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public DateValidator IsMinValue(string errorMsg)
        {
            SetResult(( Value == DateTime.MinValue), errorMsg, ValidationErrorCode.DateIsNotMinValue);
            return this;
        }

        /// <summary>
        /// 不是日期最小值DateTime.MinValue
        /// </summary>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public DateValidator NotMinValue(string errorMsg)
        {
            SetResult((Value != DateTime.MinValue), errorMsg, ValidationErrorCode.DateIsNotMinValue);
            return this;
        }

        /// <summary>
        /// Value早于compareValue
        /// </summary>
        /// <param name="compareValue"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public DateValidator IsEarlierThan(DateTime compareValue, string errorMsg)
        {
            SetResult(Value < compareValue, errorMsg, ValidationErrorCode.DateIsEarlierThan);
            return this;
        }

        /// <summary>
        /// Value早于或等于compareValue
        /// </summary>
        /// <param name="compareValue"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public DateValidator IsEarlierThanOrEqual(DateTime compareValue, string errorMsg)
        {
            SetResult(Value <= compareValue, errorMsg, ValidationErrorCode.DateIsEarlierThan);
            return this;
        }

        /// <summary>
        /// Value晚于compareValue
        /// </summary>
        /// <param name="compareValue"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public DateValidator IsLaterThan(DateTime compareValue, string errorMsg)
        {
            SetResult(Value > compareValue, errorMsg, ValidationErrorCode.DateIsLaterThan);
            return this;
        }

        /// <summary>
        /// Value晚于或等于compareValue
        /// </summary>
        /// <param name="compareValue"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public DateValidator IsLaterThanOrEqual(DateTime compareValue, string errorMsg)
        {
            SetResult(Value >= compareValue, errorMsg, ValidationErrorCode.DateIsLaterThan);
            return this;
        }

        /// <summary>
        /// Value在value1和value2之间
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public DateValidator IsBetween(DateTime value1, DateTime value2, string errorMsg)
        {
            SetResult(Value >= value1&&Value<=value2, errorMsg, ValidationErrorCode.DateBetween);
            return this;
        }

        /// <summary>
        /// 是否是有效的SQL时间
        /// </summary>
        /// <param name="errorMsg">错误信息</param>
        /// <returns>验证结果</returns>
        public DateValidator IsValidSqlServerDateTime(string errorMsg)
        {
            SetResult(Value.IsValidSqlServerDateTime(), errorMsg, ValidationErrorCode.DateValidSqlServerDateTime);
            return this;
        }
    }
}