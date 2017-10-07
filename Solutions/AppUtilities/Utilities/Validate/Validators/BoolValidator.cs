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
