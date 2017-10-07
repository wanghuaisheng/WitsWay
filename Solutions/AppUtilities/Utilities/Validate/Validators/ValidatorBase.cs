using System;

namespace WitsWay.Utilities.Validate.Validators
{
    /// <summary>
    /// 验证器基类
    /// </summary>
    /// <typeparam name="TValidator">验证器</typeparam>
    /// <typeparam name="TValue">验证值类型</typeparam>
    public abstract class ValidatorBase<TValidator, TValue> where TValidator : ValidatorBase<TValidator, TValue>
    {

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="fieldName">验证字段</param>
        /// <param name="validatorObj">验证器</param>
        protected ValidatorBase( string fieldName, TValue value,Validator validatorObj)
        {
            Value = value;
            FieldName = fieldName;
            ValidatorObj = validatorObj;
        }

        /// <summary>
        /// 验证值
        /// </summary>
        public TValue Value { get; set; }

        /// <summary>
        /// 验证字段
        /// </summary>
        public string FieldName { get; private set; }

        /// <summary>
        /// 验证器
        /// </summary>
        protected Validator ValidatorObj { get; set; }

        /// <summary>
        /// 设置验证结果
        /// </summary>
        /// <param name="pass"></param>
        /// <param name="errorMsg"></param>
        /// <param name="errorCode"></param>
        public void SetResult(bool pass, string errorMsg, long errorCode)
        {
            ValidatorObj.AddValidationResult(FieldName, pass,errorMsg,  errorCode);
        }

        /// <summary>
        /// 自定义验证
        /// </summary>
        /// <param name="predicate">Predicate《TValue》委托，输入TValue类型，返回bool</param>
        /// <param name="errorMsg">验证错误消息</param>
        /// <returns></returns>
        public TValidator Is(Predicate<TValue> predicate, string errorMsg)
        {
            SetResult(!predicate(Value), errorMsg,ValidationErrorCode.CustomErrorCode);
            return (TValidator)this;
        }
    }
}
