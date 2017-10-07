using System;

namespace WitsWay.Utilities.Validate.Validators
{
    /// <summary>
    /// ��֤������
    /// </summary>
    /// <typeparam name="TValidator">��֤��</typeparam>
    /// <typeparam name="TValue">��ֵ֤����</typeparam>
    public abstract class ValidatorBase<TValidator, TValue> where TValidator : ValidatorBase<TValidator, TValue>
    {

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="value">ֵ</param>
        /// <param name="fieldName">��֤�ֶ�</param>
        /// <param name="validatorObj">��֤��</param>
        protected ValidatorBase( string fieldName, TValue value,Validator validatorObj)
        {
            Value = value;
            FieldName = fieldName;
            ValidatorObj = validatorObj;
        }

        /// <summary>
        /// ��ֵ֤
        /// </summary>
        public TValue Value { get; set; }

        /// <summary>
        /// ��֤�ֶ�
        /// </summary>
        public string FieldName { get; private set; }

        /// <summary>
        /// ��֤��
        /// </summary>
        protected Validator ValidatorObj { get; set; }

        /// <summary>
        /// ������֤���
        /// </summary>
        /// <param name="pass"></param>
        /// <param name="errorMsg"></param>
        /// <param name="errorCode"></param>
        public void SetResult(bool pass, string errorMsg, long errorCode)
        {
            ValidatorObj.AddValidationResult(FieldName, pass,errorMsg,  errorCode);
        }

        /// <summary>
        /// �Զ�����֤
        /// </summary>
        /// <param name="predicate">Predicate��TValue��ί�У�����TValue���ͣ�����bool</param>
        /// <param name="errorMsg">��֤������Ϣ</param>
        /// <returns></returns>
        public TValidator Is(Predicate<TValue> predicate, string errorMsg)
        {
            SetResult(!predicate(Value), errorMsg,ValidationErrorCode.CustomErrorCode);
            return (TValidator)this;
        }
    }
}
