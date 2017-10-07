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
