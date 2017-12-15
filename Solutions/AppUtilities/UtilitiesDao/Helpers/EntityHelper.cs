using System;
using System.Collections.Generic;
using System.Reflection;
using WitsWay.Utilities.Dap.LambdaSqlBuilder.Attributes;
using WitsWay.Utilities.Dap.LambdaSqlBuilder.Entities;

namespace WitsWay.Utilities.Dap.Helpers
{
    public static class EntityHelper
    {
        public static Tuple<SqlTableDefine, List<SqlColumnDefine>> GetEntityDefine<T>()
        {
            var type = typeof(T);

            return GetEntityDefine(type);
        }

        private static Tuple<SqlTableDefine, List<SqlColumnDefine>> GetEntityDefine(Type type)
        {
            //处理表定义
            var name = type.Name;

            var tableAttr = type.GetTypeInfo().GetCustomAttribute<DbTableAttribute>();

            var sqlTableDef = new SqlTableDefine(tableAttr, name);

            //处理列定义
            var colDeflist = new List<SqlColumnDefine>();

            var columns = type.GetProperties();

            foreach (var cp in columns)
            {
                var ignore = cp.GetCustomAttribute<DbIgnoreAttribute>();

                if (ignore == null)
                {
                    var keyAttr = cp.GetCustomAttribute<DbKeyAttribute>();
                    var columnAttr = cp.GetCustomAttribute<DbColumnAttribute>();
                    var dataTypeAttr = cp.GetCustomAttribute<DbCustomeDataTypeAttribute>();

                    var indexAttr = cp.GetCustomAttribute<DbIndexAttribute>();

                    var cname = cp.Name;

                    var alias = cname;
                    if (columnAttr != null)
                    {
                        alias = columnAttr.Name;
                    }

                    // edit by cheery 2017-2-21
                    bool nullable;
                    // 如果是Key 不允许空
                    if (keyAttr != null)
                    {
                        nullable = false;
                    }
                    // 如果字段定义上有是否允许空标记 则依赖该标记
                    else if (columnAttr?.Nullable != null)
                    {
                        nullable = columnAttr.Nullable.Value;
                    }
                    // 否则 根据类型判断
                    else
                    {
                        nullable = cp.PropertyType.IsNullableType();
                    }
                    var cd = new SqlColumnDefine(cname, alias, null, cp.PropertyType, nullable, columnAttr, keyAttr, dataTypeAttr, null, indexAttr);

                    colDeflist.Add(cd);
                }
            }

            return new Tuple<SqlTableDefine, List<SqlColumnDefine>>(sqlTableDef, colDeflist);
        }

        public static Tuple<SqlTableDefine, List<SqlColumnDefine>> GetEntityDefines(this Type t)
        {
            return GetEntityDefine(t);
        }

        public static bool IsNullableType(this Type theType)
        {
            // 如果是引用类型，默认允许空
            var  isValueType = theType.GetTypeInfo().IsValueType;
            if (!isValueType) return true;
            var isgenericType = theType.GetTypeInfo().IsGenericType;
            return isgenericType && theType.GetGenericTypeDefinition() == typeof(Nullable<>);
        }
    }
}
