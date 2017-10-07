using System;
using WitsWay.Utilities.Extends;

namespace WitsWay.Utilities.Validate.Validators
{

    /// <summary>
    /// DateTime��֤��
    /// </summary>
    public class DateValidator : ValidatorBase<DateValidator, DateTime>
    {
        /// <summary>
        /// ����DateValidatorʵ��
        /// </summary>
        /// <param name="value"></param>
        /// <param name="fieldName"></param>
        /// <param name="validatorObj"></param>
        public DateValidator( string fieldName,DateTime value, Validator validatorObj) : base(fieldName, value, validatorObj)
        {

        }

        /// <summary>
        /// ���������ֵDateTime.MaxValue
        /// </summary>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public DateValidator IsMaxValue(string errorMsg)
        {
            SetResult(( Value == DateTime.MaxValue), errorMsg, ValidationErrorCode.DateIsNotMaxValue);
            return this;
        }

        /// <summary>
        /// �����������ֵDateTime.MaxValue
        /// </summary>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public DateValidator NotMaxValue(string errorMsg)
        {
            SetResult((Value != DateTime.MaxValue), errorMsg, ValidationErrorCode.DateIsNotMaxValue);
            return this;
        }

        /// <summary>
        /// ��������СֵDateTime.MinValue
        /// </summary>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public DateValidator IsMinValue(string errorMsg)
        {
            SetResult(( Value == DateTime.MinValue), errorMsg, ValidationErrorCode.DateIsNotMinValue);
            return this;
        }

        /// <summary>
        /// ����������СֵDateTime.MinValue
        /// </summary>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public DateValidator NotMinValue(string errorMsg)
        {
            SetResult((Value != DateTime.MinValue), errorMsg, ValidationErrorCode.DateIsNotMinValue);
            return this;
        }

        /// <summary>
        /// Value����compareValue
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
        /// Value���ڻ����compareValue
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
        /// Value����compareValue
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
        /// Value���ڻ����compareValue
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
        /// Value��value1��value2֮��
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
        /// �Ƿ�����Ч��SQLʱ��
        /// </summary>
        /// <param name="errorMsg">������Ϣ</param>
        /// <returns>��֤���</returns>
        public DateValidator IsValidSqlServerDateTime(string errorMsg)
        {
            SetResult(Value.IsValidSqlServerDateTime(), errorMsg, ValidationErrorCode.DateValidSqlServerDateTime);
            return this;
        }
    }
}