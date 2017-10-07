using System;
using System.Collections.Generic;

namespace WitsWay.Utilities.Validate.Validators
{

    /// <summary>
    /// Numeric验证器
    /// </summary>
    /// <typeparam name="TValue">
    /// </typeparam>
    public class NumericValidator<TValue> : ValidatorBase<NumericValidator<TValue>, TValue> where TValue : struct, IComparable<TValue>, IEquatable<TValue>
    {
        /// <summary>
        /// 创建NumericValidator实例
        /// </summary>
        /// <param name="value"></param>
        /// <param name="fieldName"></param>
        /// <param name="validatorObj"></param>
        public NumericValidator(string fieldName,TValue value,  Validator validatorObj)
            : base(fieldName, value, validatorObj)
        {
        }
        /// <summary>
        /// 小于等于
        /// </summary>
        /// <param name="lessThanValue"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public NumericValidator<TValue> IsLessThanOrEqual(TValue lessThanValue, string errorMsg)
        {
            SetResult(Value.CompareTo(lessThanValue) <= 0, errorMsg, ValidationErrorCode.NumericIsLessThanOrEqual);
            return this;
        }

        /// <summary>
        /// 大于等于
        /// </summary>
        /// <param name="greaterThanValue"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public NumericValidator<TValue> IsGreaterThanOrEqual(TValue greaterThanValue, string errorMsg)
        {
            SetResult(Value.CompareTo(greaterThanValue) >= 0, errorMsg, ValidationErrorCode.NumericIsGreaterThanOrEqual);
            return this;
        }

        /// <summary>
        /// 大于
        /// </summary>
        /// <param name="greaterThanValue"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public NumericValidator<TValue> IsGreaterThan(TValue greaterThanValue, string errorMsg)
        {
            SetResult(Value.CompareTo(greaterThanValue) > 0, errorMsg, ValidationErrorCode.NumericIsGreaterThan);
            return this;
        }
        /// <summary>
        /// 值在给定散列值中
        /// </summary>
        /// <param name="inValues"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public NumericValidator<TValue> IsIn(List<TValue> inValues,string errorMsg)
        {
            SetResult(inValues.Contains(Value),errorMsg,ValidationErrorCode.NumericNotInList);
            return this;
        }

        /// <summary>
        /// 小于
        /// </summary>
        /// <param name="lessThanValue"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public NumericValidator<TValue> IsLessThan(TValue lessThanValue, string errorMsg)
        {
            SetResult(Value.CompareTo(lessThanValue) < 0, errorMsg, ValidationErrorCode.NumericIsLessThan);
            return this;
        }

        /// <summary>
        /// 等于equalValue
        /// </summary>
        /// <param name="equalValue"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public NumericValidator<TValue> Equals(TValue equalValue, string errorMsg)
        {
            SetResult(Value.Equals(equalValue),errorMsg, ValidationErrorCode.NumericEquals);
            return this;
        }
        /// <summary>
        /// 大于等于minValue小于等于maxValue
        /// </summary>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public NumericValidator<TValue> Between(TValue minValue, TValue maxValue, string errorMsg)
        {
            SetResult((Value.CompareTo(minValue) >= 0 && Value.CompareTo(maxValue) <=0), errorMsg, ValidationErrorCode.NumericBetween);
            return this;
        }

        /// <summary>
        /// 等于默认值，Numeric一般都默认为0
        /// </summary>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public NumericValidator<TValue> IsDefault(string errorMsg)
        {
            SetResult(Value.Equals(new TValue()), errorMsg, ValidationErrorCode.NumericIsZero);
            return this;
        }
    }
}