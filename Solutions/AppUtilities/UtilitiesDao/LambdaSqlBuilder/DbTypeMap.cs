using System;
using System.Collections.Generic;
using System.Data;

namespace WitsWay.Utilities.Dap.LambdaSqlBuilder
{
    /// <summary>
    /// DbType映射
    /// </summary>
    public class DbTypeMap
    {
        public Dictionary<Type, string> ColumnTypeMap = new Dictionary<Type, string>();
        public Dictionary<Type, DbType> ColumnDbTypeMap = new Dictionary<Type, DbType>();

        public void Set<T>(DbType dbtype, string columnDefine)
        {
            ColumnTypeMap[typeof(T)] = columnDefine;
            ColumnDbTypeMap[typeof(T)] = dbtype;
        }

        public void Set<T>(DbType dbtype)
        {
            ColumnDbTypeMap[typeof(T)] = dbtype;
        }
    }
}
