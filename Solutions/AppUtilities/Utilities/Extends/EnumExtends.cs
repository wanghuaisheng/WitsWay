using System;
using System.Collections.Generic;
using WitsWay.Utilities.Attributes;

namespace WitsWay.Utilities.Extends
{
    /// <summary>
    /// 字符串扩展
    /// </summary>
    public static class EnumExtends
    {

        /// <summary>
        /// 获取“枚举值”描述信息
        /// </summary>
        /// <param name="enumValue">枚举值</param>
        /// <returns>枚举值描述</returns>
        public static string GetDescription(this Enum enumValue)
        {
            return EnumFieldAttribute.GetFieldText(enumValue);
        }
      
        
        /// <summary>
        /// 获取“枚举”描述信息
        /// </summary>
        /// <param name="enumValue">枚举值</param>
        /// <returns>枚举描述</returns>
        public static string GetEnumDescription(this Enum enumValue)
        {
            return EnumFieldAttribute.GetEnumText(enumValue.GetType());
        }

        /// <summary>
        /// 获取“枚举”字段信息
        /// </summary>
        /// <param name="enumValue">枚举值</param>
        /// <returns>枚举字段信息</returns>
        public static EnumFieldAttribute GetFieldInfo(this Enum enumValue)
        {
            return EnumFieldAttribute.GetFieldInfo(enumValue);
        }

        /// <summary>
        /// 取得枚举值
        /// </summary>
        /// <param name="enumValue">枚举</param>
        /// <returns>枚举值</returns>
        public static int GetValue(this Enum enumValue)
        {
            return enumValue.GetFieldInfo().EnumValue;
        }

        /// <summary>
        /// 获取“枚举”所有字段信息
        /// </summary>
        /// <param name="enumValue">枚举值</param>
        /// <returns>枚举所有字段信息</returns>
        public static List<EnumFieldAttribute> GetFieldInfos(this Enum enumValue)
        {
            return EnumFieldAttribute.GetFieldInfos(enumValue.GetType());
        }
        
        /// <summary>
        /// 转换为Int值
        /// </summary>
        /// <param name="enumValue">枚举值</param>
        /// <returns>Int值</returns>
        public static int ToInt(this Enum enumValue)
        {
            return enumValue.CastTo<int>();
        }

        /// <summary>
        /// 转换为对应Int值的String
        /// </summary>
        /// <param name="enumValue">枚举值</param>
        /// <returns>Int值对应的String</returns>
        public static string ToIntString(this Enum enumValue)
        {
            return enumValue.CastTo<int>().ToString();
        }


    }
}
