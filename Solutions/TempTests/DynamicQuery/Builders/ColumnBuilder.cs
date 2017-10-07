using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using WitsWay.TempTests.DynamicQuery.Entities;
using WitsWay.TempTests.DynamicQuery.Extends;

namespace WitsWay.TempTests.DynamicQuery.Builders
{

    /// <summary>
    /// 为jQuery Query Builder构建列定义
    /// </summary>
    public static class ColumnBuilder
    {

        /// <summary>
        /// 获取给定类型的默认列定义
        /// </summary>
        /// <param name="dataType">要获取列定义的数据类型</param>
        /// <param name="camelCase">设置为<c>true</c>则转换属性名为驼峰拼写法</param>
        /// <returns>列定义集合</returns>
        public static List<ColumnDefinition> GetDefaultColumnDefinitions(this Type dataType, bool camelCase = false)
        {
            var itemBankColumnDefinitions = new List<ColumnDefinition>();
            var id = 1;
            foreach (var prop in dataType.GetProperties())
            {
                if (prop.GetCustomAttribute(typeof(IgnoreDataMemberAttribute)) != null) continue;

                var name = camelCase ? prop.Name.ToCamelCase() : prop.Name;

                var displays = prop.GetCustomAttributes(typeof(DisplayNameAttribute));
                var attributes = displays as Attribute[] ?? displays.ToArray();
                var title = attributes.Any()
                    ? ((DisplayNameAttribute)attributes[0]).DisplayName
                    : prop.Name.ToSpacedString();

                var type = string.Empty;

                if (prop.PropertyType == typeof(double) || prop.PropertyType == typeof(double?)
                    || prop.PropertyType == typeof(float) || prop.PropertyType == typeof(float?)
                    || prop.PropertyType == typeof(decimal) || prop.PropertyType == typeof(decimal?))
                {
                    type = "double";
                }
                else if (prop.PropertyType == typeof(int) || prop.PropertyType == typeof(int?))
                {
                    type = "integer";
                }
                else if ((prop.PropertyType == typeof(DateTime)) || (prop.PropertyType == typeof(DateTime?)))
                {
                    type = "date";
                }
                else if ((prop.PropertyType == typeof(string)))
                {
                    type = "string";
                }

                switch (type)
                {
                    case "double":
                        itemBankColumnDefinitions.Add(new ColumnDefinition()
                        {
                            Label = title,
                            Field = name,
                            ValueType = type,
                            Id = id.ToString()
                        });
                        break;
                    case "integer":
                        itemBankColumnDefinitions.Add(new ColumnDefinition()
                        {
                            Label = title,
                            Field = name,
                            ValueType = type,
                            Id = id.ToString(),
                            
                            
                        });
                        break;
                    case "string":
                        itemBankColumnDefinitions.Add(new ColumnDefinition()
                        {
                            Label = title,
                            Field = name,
                            ValueType = type,
                            Id = id.ToString()
                        });
                        break;
                    case "date":
                        itemBankColumnDefinitions.Add(new ColumnDefinition()
                        {
                            Label = title,
                            Field = name,
                            ValueType = type,
                            Id = id.ToString()
                        });
                        break;
                }

                id++;
            }
            return itemBankColumnDefinitions;
        }

    }
}
