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
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using WitsWay.Utilities.Errors;
using WitsWay.Utilities.Helpers;

namespace WitsWay.Utilities.Guards
{

    /// <summary>
    /// 参数检查
    /// </summary>
    public static class ArgumentGuard
    {

        /// <summary>
        /// 参数非空
        /// </summary>
        public static void ArgumentNotNull(string argumentName, object argumentValue)
        {
            if (argumentValue != null) return;
            ThrowArgumentError(argumentName);
        }

        /// <summary>
        /// 参数非空
        /// </summary>
        public static void ArgumentNotNullOrEmpty(string argumentName, object argumentValue)
        {
            if (argumentValue != null && argumentValue.ToString().Length > 0) return;
            ThrowArgumentError(argumentName);
        }

        /// <summary>
        /// 参数大于0
        /// </summary>
        public static void ArgumentGreaterThanZero(string argumentName, int argumentValue)
        {
            if (argumentValue > 0) return;
            ThrowArgumentError(argumentName);
        }

        /// <summary>
        /// 检查参数类型从指定的类型继承或实现
        /// </summary>
        public static void TypeIsAssignable(Type assignmentTargetType, Type assignmentValueType, string methodName, string argumentName)
        {
            if (string.IsNullOrEmpty(methodName)) { throw new ArgumentNullException(nameof(methodName)); }
            if (string.IsNullOrEmpty(argumentName)) { throw new ArgumentNullException(nameof(argumentName)); }
            if (assignmentTargetType == null) { throw new ArgumentNullException(nameof(assignmentTargetType)); }
            if (assignmentValueType == null) { throw new ArgumentNullException(nameof(assignmentValueType)); }
            if (assignmentTargetType.IsAssignableFrom(assignmentValueType)) return;
            ThrowArgumentError(argumentName);
        }

        /// <summary>
        /// 检查参数实例从指定的类型继承或实现
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification =
            "GetType() invoked for diagnostics purposes")]
        public static void InstanceIsAssignable(Type assignmentTargetType, object assignmentInstance, string methodName, string argumentName)
        {
            if (string.IsNullOrEmpty(methodName)) { throw new ArgumentNullException(nameof(methodName)); }
            if (string.IsNullOrEmpty(argumentName)) { throw new ArgumentNullException(nameof(argumentName)); }
            if (assignmentTargetType == null) throw new ArgumentNullException(nameof(assignmentTargetType));
            if (assignmentInstance == null) throw new ArgumentNullException(nameof(assignmentInstance));
            if (assignmentTargetType.IsInstanceOfType(assignmentInstance)) return;
            ThrowArgumentError(argumentName);
        }

        /// <summary>
        /// 抛出参数错误
        /// </summary>
        /// <param name="argumentName">参数名</param>
        private static void ThrowArgumentError(string argumentName)
        {
            if (string.IsNullOrEmpty(argumentName))
            {
                throw new ArgumentNullException(nameof(argumentName));
            }
            var stackInfo = GetStackTraceInfo();
            stackInfo += ($"参数名{argumentName}");
            Logger.Write(stackInfo);
            ExceptionHelper.ThrowProgramException(UtilityErrors.ArgumentErrorException);
        }

        /// <summary>
        /// 获取堆栈跟踪信息
        /// </summary>
        private static string GetStackTraceInfo()
        {
            var sb = new StringBuilder();
            var st = new StackTrace(2, true);
            var sf = st.GetFrame(0);
            sb.Append($" 文件: {sf.GetFileName()}\r\n");
            sb.Append($" 方法: {sf.GetMethod().Name}\r\n");
            sb.Append($" 行数: {sf.GetFileLineNumber()}\r\n");
            //sb.Append(string.Format(" 列数: {0}\r\n", sf.GetFileColumnNumber()));
            return sb.ToString();
        }

    }
}
