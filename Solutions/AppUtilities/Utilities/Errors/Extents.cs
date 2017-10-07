////using System;
////using System.Collections.Generic;

////namespace SmartSolution.Utilities.Errors
////{
////    /// <summary>
////    /// 字符串扩展
////    /// </summary>
////    internal static class EnumExtends
////    {

////        /// <summary>
////        /// 获取“枚举值”描述信息
////        /// </summary>
////        /// <param name="enumValue">枚举值</param>
////        /// <returns>枚举值描述</returns>
////        public static string GetDescription2(this Enum enumValue)
////        {
////            return ErrorItemAttribute.GetFieldText(enumValue);
////        }


////        /// <summary>
////        /// 获取“枚举”描述信息
////        /// </summary>
////        /// <param name="enumValue">枚举值</param>
////        /// <returns>枚举描述</returns>
////        public static string GetEnumDescription2(this Enum enumValue)
////        {
////            return ErrorItemAttribute.GetEnumText(enumValue.GetType());
////        }

////        /// <summary>
////        /// 获取“枚举”字段信息
////        /// </summary>
////        /// <param name="enumValue">枚举值</param>
////        /// <returns>枚举字段信息</returns>
////        public static ErrorItemAttribute GetFieldInfo2(this Enum enumValue)
////        {
////            return ErrorItemAttribute.GetFieldInfo(enumValue);
////        }

////        /// <summary>
////        /// 取得枚举值
////        /// </summary>
////        /// <param name="enumValue">枚举</param>
////        /// <returns>枚举值</returns>
////        public static int GetValue2(this Enum enumValue)
////        {
////            return enumValue.GetFieldInfo2().ErrorValue;
////        }

////        /// <summary>
////        /// 获取“枚举”所有字段信息
////        /// </summary>
////        /// <param name="enumValue">枚举值</param>
////        /// <returns>枚举所有字段信息</returns>
////        public static List<ErrorItemAttribute> GetFieldInfos2(this Enum enumValue)
////        {
////            return ErrorItemAttribute.GetFieldInfos(enumValue.GetType());
////        }


////    }
////}