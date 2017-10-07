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
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("SqlBulkTools.UnitTests")]
[assembly: InternalsVisibleTo("SqlBulkTools.IntegrationTests")]
namespace WitsWay.Utilities.SqlBulks
{
    /// <summary>
    /// 批量操作辅助类
    /// </summary>
    internal class BulkOperationsHelpers
    {
        /// <summary>
        /// 精度类型
        /// </summary>
        internal struct PrecisionType
        {
            /// <summary>
            /// 数字精度
            /// </summary>
            public string NumericPrecision { get; set; }
            /// <summary>
            /// 数字总长
            /// </summary>
            public string NumericScale { get; set; }
        }

        /// <summary>
        /// 创建临时表
        /// </summary>
        internal string BuildCreateTempTable(HashSet<string> columns, DataTable schema, bool? outputIdentity = null)
        {
            var actualColumns = new Dictionary<string, string>();
            var actualColumnsMaxCharLength = new Dictionary<string, string>();
            var actualColumnsPrecision = new Dictionary<string, PrecisionType>();


            foreach (DataRow row in schema.Rows)
            {
                var columnType = row["DATA_TYPE"].ToString();
                var columnName = row["COLUMN_NAME"].ToString();

                actualColumns.Add(row["COLUMN_NAME"].ToString(), row["DATA_TYPE"].ToString());

                if (columnType == "varchar" || columnType == "nvarchar" ||
                    columnType == "char" || columnType == "binary" ||
                    columnType == "varbinary")
                {
                    actualColumnsMaxCharLength.Add(row["COLUMN_NAME"].ToString(),
                        row["CHARACTER_MAXIMUM_LENGTH"].ToString());
                }

                if (columnType == "numeric" || columnType == "decimal")
                {
                    var p = new PrecisionType
                    {
                        NumericPrecision = row["NUMERIC_PRECISION"].ToString(),
                        NumericScale = row["NUMERIC_SCALE"].ToString()
                    };
                    actualColumnsPrecision.Add(columnName, p);
                }

            }

            var command = new StringBuilder();

            command.Append("CREATE TABLE #TmpTable(");

            var paramList = new List<string>();

            foreach (var column in columns.ToList())
            {
                if (column == "InternalId") continue;
                string columnType;
                if (actualColumns.TryGetValue(column, out columnType))
                {
                    columnType = GetVariableCharType(column, columnType, actualColumnsMaxCharLength);
                    columnType = GetDecimalPrecisionAndScaleType(column, columnType, actualColumnsPrecision);
                }
                paramList.Add("[" + column + "]" + " " + columnType);
            }

            var paramListConcatenated = string.Join(", ", paramList);

            command.Append(paramListConcatenated);

            if (outputIdentity.HasValue && outputIdentity.Value)
            {
                command.Append(", [InternalId] int");
            }
            command.Append(");");

            return command.ToString();
        }

        private string GetVariableCharType(string column, string columnType, Dictionary<string, string> actualColumnsMaxCharLength)
        {
            if (columnType == "varchar" || columnType == "nvarchar")
            {
                string maxCharLength;
                if (actualColumnsMaxCharLength.TryGetValue(column, out maxCharLength))
                {
                    if (maxCharLength == "-1")
                        maxCharLength = "max";

                    columnType = columnType + "(" + maxCharLength + ")";
                }
            }

            return columnType;
        }

        private string GetDecimalPrecisionAndScaleType(string column, string columnType, Dictionary<string, PrecisionType> actualColumnsPrecision)
        {
            if (columnType == "decimal" || columnType == "numeric")
            {
                PrecisionType p;

                if (actualColumnsPrecision.TryGetValue(column, out p))
                {
                    columnType = columnType + "(" + p.NumericPrecision + ", " + p.NumericScale + ")";
                }
            }

            return columnType;
        }

        internal string BuildJoinConditionsForUpdateOrInsert(string[] updateOn, string sourceAlias, string targetAlias)
        {
            var command = new StringBuilder();

            command.Append("ON " + "[" + targetAlias + "]" + "." + "[" + updateOn[0] + "]" + " = " + "[" + sourceAlias + "]" + "." + "[" + updateOn[0] + "]" + " ");

            if (updateOn.Length > 1)
            {
                // Start from index 1 to just append "AND" conditions
                for (var i = 1; i < updateOn.Length; i++)
                {
                    command.Append("AND " + "[" + targetAlias + "]" + "." + "[" + updateOn[i] + "]" + " = " + "[" + sourceAlias + "]" + "." + "[" + updateOn[i] + "]" + " ");
                }
            }

            return command.ToString();
        }

        internal string BuildUpdateSet(HashSet<string> columns, string sourceAlias, string targetAlias, string identityColumn)
        {
            var command = new StringBuilder();
            var paramsSeparated = new List<string>();

            command.Append("UPDATE SET ");

            foreach (var column in columns.ToList())
            {
                if (identityColumn != null && column != identityColumn || identityColumn == null)
                {
                    if (column != "InternalId")
                        paramsSeparated.Add("[" + targetAlias + "]" + "." + "[" + column + "]" + " = " + "[" + sourceAlias + "]" + "." + "[" + column + "]");
                }
            }

            command.Append(string.Join(", ", paramsSeparated) + " ");

            return command.ToString();
        }

        internal string BuildInsertSet(HashSet<string> columns, string sourceAlias, string identityColumn)
        {
            var command = new StringBuilder();
            var insertColumns = new List<string>();
            var values = new List<string>();

            command.Append("INSERT (");

            foreach (var column in columns.ToList())
            {
                if (identityColumn != null && column != identityColumn || identityColumn == null)
                {
                    if (column != "InternalId")
                    {
                        insertColumns.Add("[" + column + "]");
                        values.Add("[" + sourceAlias + "]" + "." + "[" + column + "]");
                    }
                }
            }

            command.Append(string.Join(", ", insertColumns));
            command.Append(") values (");
            command.Append(string.Join(", ", values));
            command.Append(")");

            return command.ToString();
        }

        internal string GetPropertyName(Expression method)
        {
            var lambda = method as LambdaExpression;
            if (lambda == null)
                throw new ArgumentNullException(nameof(method));

            MemberExpression memberExpr = null;

            if (lambda.Body.NodeType == ExpressionType.Convert)
            {
                memberExpr =
                    ((UnaryExpression)lambda.Body).Operand as MemberExpression;
            }
            else if (lambda.Body.NodeType == ExpressionType.MemberAccess)
            {
                memberExpr = lambda.Body as MemberExpression;
            }

            if (memberExpr == null)
                throw new ArgumentException("method");

            return memberExpr.Member.Name;
        }

        /// <summary>
        /// 转换DataTable
        /// </summary>
        internal DataTable ToDataTable<T>(IEnumerable<T> items, HashSet<string> columns, Dictionary<string, string> columnMappings, List<string> matchOnColumns = null, bool? outputIdentity = null, Dictionary<int, T> outputIdentityDic = null)
        {
            var dataTable = new DataTable(typeof(T).Name);

            if (matchOnColumns != null)
            {
                columns = CheckForAdditionalColumns(columns, matchOnColumns);
            }

            if (outputIdentity.HasValue && outputIdentity.Value)
            {
                columns.Add("InternalId");
            }

            //Get all the properties
            var props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var column in columns.ToList())
            {
                if (columnMappings.ContainsKey(column))
                {
                    dataTable.Columns.Add(columnMappings[column]);
                }

                else
                    dataTable.Columns.Add(column);
            }

            AssignTypes(props, columns, dataTable, outputIdentity);

            var counter = 0;

            foreach (var item in items)
            {

                var values = new List<object>();

                foreach (var column in columns.ToList())
                {
                    if (column == "InternalId")
                    {
                        values.Add(counter);
                        outputIdentityDic.Add(counter, item);
                    }
                    else
                        for (var i = 0; i < props.Length; i++)
                        {
                            if (props[i].Name == column && item != null)
                                values.Add(props[i].GetValue(item, null));
                        }

                }
                counter++;
                dataTable.Rows.Add(values.ToArray());

            }
            return dataTable;
        }

        private void AssignTypes(PropertyInfo[] props, HashSet<string> columns, DataTable dataTable, bool? outputIdentity = null)
        {
            var count = 0;

            foreach (var column in columns.ToList())
            {
                if (column == "InternalId")
                {
                    dataTable.Columns[count].DataType = typeof(int);
                }
                else
                    for (var i = 0; i < props.Length; i++)
                    {
                        if (props[i].Name == column)
                        {
                            dataTable.Columns[count].DataType = Nullable.GetUnderlyingType(props[i].PropertyType) ??
                                                                props[i].PropertyType;
                        }
                    }
                count++;
            }
        }

        internal SqlConnection GetSqlConnection(string connectionName, SqlCredential credentials, SqlConnection connection)
        {
            SqlConnection conn = null;

            if (connection != null)
            {
                conn = connection;
                return conn;
            }

            if (connectionName != null)
            {
                conn = new SqlConnection(ConfigurationManager
                    .ConnectionStrings[connectionName].ConnectionString, credentials);
                return conn;
            }

            throw new InvalidOperationException("Could not create SQL Connection");
        }

        /// <summary>
        /// 获取表全名【数据库】.【架构】.【表名】
        /// </summary>
        internal string GetFullQualifyingTableName(string databaseName, string schemaName, string tableName)
        {
            var sb = new StringBuilder();
            sb.Append("[");
            sb.Append(databaseName);
            sb.Append("].[");
            sb.Append(schemaName);
            sb.Append("].[");
            sb.Append(tableName);
            sb.Append("]");

            return sb.ToString();
        }


        /// <summary>
        /// If there are MatchOnColumns that don't exist in columns, add to columns.
        /// </summary>
        /// <param name="columns"></param>
        /// <param name="matchOnColumns"></param>
        /// <returns></returns>
        internal HashSet<string> CheckForAdditionalColumns(HashSet<string> columns, List<string> matchOnColumns)
        {
            foreach (var col in matchOnColumns)
            {
                if (!columns.Contains(col))
                {
                    columns.Add(col);
                }
            }

            return columns;
        }
        /// <summary>
        /// 确保在ToDataTable后调用DoColumnMappings
        /// </summary>
        internal void DoColumnMappings(Dictionary<string, string> columnMappings, HashSet<string> columns, List<string> updateOnList)
        {
            if (columnMappings.Count <= 0) return;
            foreach (var column in columnMappings)
            {
                if (columns.Contains(column.Key))
                {
                    columns.Remove(column.Key);
                    columns.Add(column.Value);
                }
                for (var i = 0; i < updateOnList.ToArray().Length; i++)
                {
                    if (updateOnList[i] == column.Key)
                    {
                        updateOnList[i] = column.Value;
                    }
                }
            }
        }
        /// <summary>
        /// 确保在ToDataTable后调用DoColumnMappings
        /// </summary>
        internal void DoColumnMappings(Dictionary<string, string> columnMappings, HashSet<string> columns)
        {
            if (columnMappings.Count <= 0) return;
            foreach (var column in columnMappings)
            {
                if (columns.Contains(column.Key))
                {
                    columns.Remove(column.Key);
                    columns.Add(column.Value);
                }
            }
        }

        /// <summary>
        /// Advanced Settings for SQLBulkCopy class. 
        /// </summary>
        /// <param name="bulkcopy"></param>
        /// <param name="bulkCopyEnableStreaming"></param>
        /// <param name="bulkCopyBatchSize"></param>
        /// <param name="bulkCopyNotifyAfter"></param>
        /// <param name="bulkCopyTimeout"></param>
        internal void SetSqlBulkCopySettings(SqlBulkCopy bulkcopy, bool bulkCopyEnableStreaming, int? bulkCopyBatchSize, int? bulkCopyNotifyAfter, int bulkCopyTimeout)
        {
            bulkcopy.EnableStreaming = bulkCopyEnableStreaming;

            if (bulkCopyBatchSize.HasValue)
            {
                bulkcopy.BatchSize = bulkCopyBatchSize.Value;
            }

            if (bulkCopyNotifyAfter.HasValue)
            {
                bulkcopy.NotifyAfter = bulkCopyNotifyAfter.Value;
            }

            bulkcopy.BulkCopyTimeout = bulkCopyTimeout;
        }


        /// <summary>
        /// This is used only for the BulkInsert method at this time.  
        /// </summary>
        /// <param name="bulkCopy"></param>
        /// <param name="columns"></param>
        /// <param name="customColumnMappings"></param>
        internal void MapColumns(SqlBulkCopy bulkCopy, HashSet<string> columns, Dictionary<string, string> customColumnMappings)
        {

            foreach (var column in columns.ToList())
            {
                string mapping;

                if (customColumnMappings.TryGetValue(column, out mapping))
                {
                    bulkCopy.ColumnMappings.Add(mapping, mapping);
                }

                else
                    bulkCopy.ColumnMappings.Add(column, column);
            }

        }

        internal HashSet<string> GetAllValueTypeAndStringColumns(Type type)
        {
            var columns = new HashSet<string>();

            //Get all the properties
            var props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            for (var i = 0; i < props.Length; i++)
            {
                var type2 = props[i].GetType();
                if (props[i].PropertyType.IsValueType || props[i].PropertyType == typeof(string))
                {
                    columns.Add(props[i].Name);
                }
            }

            return columns;

        }

        internal string GetOutputIdentityCmd(string identityColumn, bool outputIdentity, string tmpTableName, OperationType operation)
        {

            var sb = new StringBuilder();
            if (identityColumn == null || !outputIdentity)
            {
                return ("; ");
            }

            sb.Append("OUTPUT Source.InternalId, INSERTED." + identityColumn + " INTO " + tmpTableName + "(InternalId, " + identityColumn + "); ");


            return sb.ToString();
        }

        internal string GetOutputCreateTableCmd(bool outputIdentity, string tmpTablename, OperationType operation)
        {
            if (operation == OperationType.Insert)
                return (outputIdentity ? "CREATE TABLE " + tmpTablename + "(InternalId int, Id int); " : "");

            return string.Empty;
        }

        internal string GetIndexManagementCmd(string action, string table, HashSet<string> disableIndexList, bool disableAllIndexes = false)
        {
            //AND sys.objects.name = 'Books' AND sys.indexes.name = 'IX_Title'
            var sb = new StringBuilder();

            if (disableIndexList != null && disableIndexList.Any())
            {
                foreach (var index in disableIndexList)
                {
                    sb.Append(" AND sys.indexes.name = \'");
                    sb.Append(index);
                    sb.Append("\'");
                }
            }

            var cmd = "DECLARE @sql AS VARCHAR(MAX)=''; " +
                                "SELECT @sql = @sql + " +
                                "'ALTER INDEX ' + sys.indexes.name + ' ON ' + sys.objects.name + ' " + action + ";'" +
                                "FROM sys.indexes JOIN sys.objects ON sys.indexes.object_id = sys.objects.object_id " +
                                "WHERE sys.indexes.type_desc = 'NONCLUSTERED' " +
                                "AND sys.objects.type_desc = 'USER_TABLE'" +
                                " AND sys.objects.name = '" + table + "'" + (sb.Length > 0 ? sb.ToString() : "") + "; EXEC(@sql);";

            return cmd;
        }

        /// <summary>
        /// Gets schema information for a table. Used to get SQL type of property. 
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="schema"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        internal DataTable GetDatabaseSchema(SqlConnection conn, string schema, string tableName)
        {
            var restrictions = new string[4];
            restrictions[0] = conn.Database;
            restrictions[1] = schema;
            restrictions[2] = tableName;
            var dtCols = conn.GetSchema("Columns", restrictions);

            if (dtCols.Rows.Count == 0 && schema != null) throw new InvalidOperationException("Table name '" + tableName + "\' with schema name \'" + schema + "\' not found. Check your setup and try again.");
            if (dtCols.Rows.Count == 0) throw new InvalidOperationException("Table name \'" + tableName + "\' not found. Check your setup and try again.");
            return dtCols;
        }
        /// <summary>
        /// 插入临时表
        /// </summary>
        internal void InsertToTmpTable(SqlConnection conn, SqlTransaction transaction, DataTable dt, bool bulkCopyEnableStreaming, int? bulkCopyBatchSize, int? bulkCopyNotifyAfter, int bulkCopyTimeout, SqlBulkCopyOptions sqlBulkCopyOptions)
        {
            using (var bulkcopy = new SqlBulkCopy(conn, sqlBulkCopyOptions, transaction))
            {
                bulkcopy.DestinationTableName = "#TmpTable";

                SetSqlBulkCopySettings(bulkcopy, bulkCopyEnableStreaming,
                    bulkCopyBatchSize,
                    bulkCopyNotifyAfter, bulkCopyTimeout);

                bulkcopy.WriteToServer(dt);
            }
        }
        /// <summary>
        /// 异步插入临时表
        /// </summary>
        internal async Task InsertToTmpTableAsync(SqlConnection conn, SqlTransaction transaction, DataTable dt, bool bulkCopyEnableStreaming, int? bulkCopyBatchSize, int? bulkCopyNotifyAfter, int bulkCopyTimeout, SqlBulkCopyOptions sqlBulkCopyOptions)
        {
            using (var bulkcopy = new SqlBulkCopy(conn, sqlBulkCopyOptions, transaction))
            {
                bulkcopy.DestinationTableName = "#TmpTable";

                SetSqlBulkCopySettings(bulkcopy, bulkCopyEnableStreaming,
                    bulkCopyBatchSize,
                    bulkCopyNotifyAfter, bulkCopyTimeout);

                await bulkcopy.WriteToServerAsync(dt);
            }
        }
    }

    /// <summary>
    /// 索引操作
    /// </summary>
    internal static class IndexOperation
    {
        /// <summary>
        /// 重建
        /// </summary>
        public const string Rebuild = "REBUILD";
        /// <summary>
        /// 禁用
        /// </summary>
        public const string Disable = "DISABLE";
    }

    /// <summary>
    /// 静态常量
    /// </summary>
    internal static class Constants
    {
        /// <summary>
        /// 默认架构名称
        /// </summary>
        public const string DefaultSchemaName = "dbo";
    }

    /// <summary>
    /// 操作类型
    /// </summary>
    internal enum OperationType
    {
        /// <summary>
        /// 插入
        /// </summary>
        Insert,
        /// <summary>
        /// 插入或更新
        /// </summary>
        InsertOrUpdate
    }

}