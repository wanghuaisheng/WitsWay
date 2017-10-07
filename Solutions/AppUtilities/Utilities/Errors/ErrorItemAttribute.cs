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

namespace WitsWay.Utilities.Errors
{
    /// <summary>
    /// 把枚举值按照指定的文本显示
    /// <example>
    /// EnumField.GetEnumText(typeof(MyEnum));
    /// EnumField.GetFieldText(MyEnum.EnumField);
    /// EnumField.GetFieldInfos(typeof(MyEnum));  
    /// </example>
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Enum)]
    public partial class ErrorItemAttribute : Attribute
    {

        /// <summary>
        /// 描述枚举值
        /// </summary>
        /// <param name="enumText">描述内容</param>
        public ErrorItemAttribute(string enumText)
        {
            ErrorText = enumText;
        }

        /// <summary>
        /// 错误文字
        /// </summary>
        public string ErrorText { get; }

        /// <summary>
        /// 枚举值(对应枚举值）
        /// </summary>
        public int ErrorValue { get; private set; }
        /// <summary>
        /// 字段名称（对应代码中的枚举实现）
        /// </summary>
        public string FieldName { get; private set; }


        /// <summary>
        ///  重写ToString
        /// </summary>
        /// <returns>EnumDisplayText</returns>
        public override string ToString()
        {
            return ErrorText;
        }

    }
}