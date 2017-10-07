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
namespace WitsWay.Utilities.Validate
{
    /// <summary>
    /// 验证结果
    /// </summary>
    public class ValidateResult
    {

        /// <summary>
        /// 完全构造函数
        /// </summary>
        /// <param name="errorMessage">验证错误消息</param>
        /// <param name="fieldName">验证字段</param>
        /// <param name="result">验证结果</param>
        /// <param name="errorCode">失败错误码</param>
        public ValidateResult(string errorMessage, string fieldName, bool result, long errorCode)
        {
            ErrorMessage = errorMessage;
            FieldName = fieldName;
            Pass = result;
            ErrorCode = errorCode;
        }

        /// <summary>
        /// 错误消息
        /// </summary>
        public string ErrorMessage { get; private set; }

        /// <summary>
        /// 验证字段
        /// </summary>
        public string FieldName { get; private set; }

        /// <summary>
        /// 是否通过验证
        /// </summary>
        public bool Pass { get; private set; }

        /// <summary>
        /// 验证错误码(暂不使用)
        /// </summary>
        public long ErrorCode { get; private set; }

    }
}
