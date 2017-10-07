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
using System.Linq;

namespace WitsWay.Utilities.Errors
{

    /// <summary>
    /// 错误信息工厂
    /// </summary>
    public class ErrorItemFactory
    {

        /// <summary>
        /// 所有错误
        /// </summary>
        private static readonly Dictionary<int, Dictionary<int, Dictionary<int, long>>> Errors = new Dictionary<int, Dictionary<int, Dictionary<int, long>>>();

        static ErrorItemFactory()
        {
            var sysList = ErrorItemAttribute.GetFieldInfos(typeof(ErrorSystems));
            var modelList = ErrorItemAttribute.GetFieldInfos(typeof(ErrorDomains));
            sysList.ForEach(sys =>
            {
                var enumVal = sys.ErrorValue;
                Errors[enumVal] = new Dictionary<int, Dictionary<int, long>>();
                modelList.ForEach(m =>
                {
                    Errors[enumVal][m.ErrorValue] = new Dictionary<int, long>();
                });
            });
        }

        /// <summary>
        /// 取错误码
        /// </summary>
        public static long GetErrorCode(ErrorSystems sys, Enum err)
        {
            var attrs = err.GetType().GetCustomAttributes(typeof(ErrorDomainAttribute), false);
            if (!attrs.Any()) return 0;
            var modelValue = (int)((ErrorDomainAttribute)attrs[0]).Domain;
            var errValue = ErrorItemAttribute.GetFieldInfo(err).ErrorValue;
            if (!Errors[(int)sys][modelValue].ContainsKey(errValue))
            {
                var errCode = long.Parse("1" + ((int)sys).ToString("00") + modelValue.ToString("0000") + errValue.ToString("0000"));
                Errors[(int)sys][modelValue][errValue] = errCode;
            }
            return Errors[(int)sys][modelValue][errValue];
        }

        /// <summary>
        /// 取错误描述
        /// </summary>
        public static string GetErrorText(Enum err)
        {
            return ErrorItemAttribute.GetFieldText(err);
        }

    }
}
