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
using System.Collections.Generic;

namespace WitsWay.Utilities.Validate.Validators
{
    /// <summary>
    /// 验证器
    /// </summary>
    public class Validator
    {

        #region [Construction]

        #endregion

        #region [Properties]

        /// <summary>
        /// 验证错误信息集合
        /// </summary>
        private readonly List<ValidateResult> validatorResults = new List<ValidateResult>();


        /// <summary>
        /// 验证结果集合
        /// </summary>
        public List<ValidateResult> ValidatorResults
        {
            get { return validatorResults; }
        }

        /// <summary>
        /// 验证错误集合
        /// </summary>
        public List<ValidateResult> ValidatorErrors
        {
            get
            {
                if (ValidatorResults == null || ValidatorResults.Count == 0) { return null; }
                return ValidatorResults.FindAll(info => { return !info.Pass; });
            }
        }

        /// <summary>
        /// 是否通过验证
        /// </summary>
        public bool Pass
        {
            get
            {
                return ValidatorErrors == null||ValidatorErrors.Count==0;
            }
        }

        #endregion

        #region [Check]{Numeric}

        /// <summary>
        /// 验证int
        /// </summary>
        /// <param name="value"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public NumericValidator<int> Check( string fieldName,int value)
        {
            return new NumericValidator<int>(fieldName,value, this);
        }


        /// <summary>
        /// 验证uint
        /// </summary>
        /// <param name="value"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public NumericValidator<uint> Check( string fieldName,uint value)
        {
            return new NumericValidator<uint>(fieldName,value, this);
        }

        /// <summary>
        /// 验证short
        /// </summary>
        /// <param name="value"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public NumericValidator<short> Check( string fieldName,short value)
        {
            return new NumericValidator<short>(fieldName,value, this);
        }


        /// <summary>
        /// 验证ushort
        /// </summary>
        /// <param name="value"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public NumericValidator<ushort> Check(string fieldName,ushort value)
        {
            return new NumericValidator<ushort>(fieldName,value, this);
        }

        /// <summary>
        /// 验证long
        /// </summary>
        /// <param name="value"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public NumericValidator<long> Check(string fieldName,long value)
        {
            return new NumericValidator<long>(fieldName,value, this);
        }

        /// <summary>
        /// 验证ulong
        /// </summary>
        /// <param name="value"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public NumericValidator<ulong> Check(string fieldName,ulong value)
        {
            return new NumericValidator<ulong>(fieldName,value, this);
        }

        /// <summary>
        /// 验证byte
        /// </summary>
        /// <param name="value"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public NumericValidator<byte> Check(string fieldName,byte value)
        {
            return new NumericValidator<byte>(fieldName,value, this);
        }


        /// <summary>
        /// 验证sbyte
        /// </summary>
        /// <param name="value"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public NumericValidator<sbyte> Check(string fieldName,sbyte value)
        {
            return new NumericValidator<sbyte>(fieldName,value, this);
        }


        /// <summary>
        /// 验证decimal
        /// </summary>
        /// <param name="value"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public NumericValidator<decimal> Check(string fieldName,decimal value)
        {
            return new NumericValidator<decimal>(fieldName,value, this);
        }


        /// <summary>
        /// 验证float
        /// </summary>
        /// <param name="value"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public NumericValidator<float> Check(string fieldName,float value)
        {
            return new NumericValidator<float>(fieldName,value, this);
        }

        /// <summary>
        /// 验证double
        /// </summary>
        /// <param name="value"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public NumericValidator<double> Check( string fieldName,double value)
        {
            return new NumericValidator<double>(fieldName,value, this);
        }

        #endregion

        #region [Check]{Bool}

        /// <summary>
        /// 验证bool
        /// </summary>
        /// <param name="value"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public BoolValidator Check(string fieldName, bool value)
        {
            return new BoolValidator(fieldName,value, this);
        }

        #endregion

        #region [Check]{String}

        /// <summary>
        /// 验证字符串
        /// </summary>
        /// <param name="value"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public StringValidator Check(string fieldName,string value)
        {
            return new StringValidator(fieldName,value, this);
        }

        #endregion

        #region [Check]{DateTime}

        /// <summary>
        /// 验证日期
        /// </summary>
        /// <param name="value"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public DateValidator Check(string fieldName,DateTime value)
        {
            return new DateValidator(fieldName,value, this);
        }

        #endregion

        #region [Method]

        /// <summary>
        /// 清空所有验证结果
        /// </summary>
        public void Clear()
        {
            ValidatorResults.Clear();
        }
        /// <summary>
        /// 添加一个验证结果
        /// </summary>
        /// <param name="errorMsg"></param>
        /// <param name="fieldName"></param>
        /// <param name="pass"></param>
        /// <param name="errorCode"></param>
        public void AddValidationResult(string fieldName ,bool pass,string errorMsg, long errorCode)
        {
            ValidatorResults.Add(new ValidateResult(errorMsg, fieldName, pass, errorCode));
        }

        /// <summary>
        /// 添加一个验证结果,ErrorCode默认为CustomErrorCode
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="pass"></param>
        /// <param name="errorMsg">错误信息</param>
        public void AddValidationResult(string fieldName, bool pass, string errorMsg)
        {
            ValidatorResults.Add(new ValidateResult(errorMsg, fieldName, pass, ValidationErrorCode.CustomErrorCode));
        }

        #endregion

    }
}
