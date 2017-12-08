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
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using WitsWay.Utilities.Entitys;
using WitsWay.Utilities.Extends;

namespace WitsWay.Utilities.Daos
{
    /// <summary>
    /// 数据批量操作
    /// </summary>
    public class BulkOperations<T>
    {

        /// <summary>
        /// 批量插入(主键重复会报错)
        /// </summary>
        public static List<BulkInsertResult> BulkInsert(string connection, IList<T> datas, string schema, string targetTableName, string primaryKey, SqlTransaction tran)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings[connection].ConnectionString))
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                var command = new SqlCommand() { Connection = conn, CommandType = CommandType.Text, CommandTimeout = 30 };
                BulkToServer(command, EntitiesToTable(command, datas, schema, targetTableName), $"{schema}.{targetTableName}", tran);
                return (from T t in datas
                    select new BulkInsertResult()
                    {
                        Action = "INSERT",
                        DeletedId = "",
                        InsertedId = t.GetPropertyValue(primaryKey)?.ToString()
                    }).ToList();
            }
        }
        /// <summary>
        /// 批量更新
        /// </summary>
        public static List<BulkInsertResult> BulkUpdate(string connection, IList<T> datas, string schema, string targetTableName, string primaryKey, SqlTransaction tran)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings[connection].ConnectionString))
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                var command = new SqlCommand() { Connection = conn, CommandType = CommandType.Text, CommandTimeout = 30 };

                string tempTableName = $"#{typeof(T).Name}TempTable";
                //创建临时表
                CreateTempTable(command, tempTableName, schema, targetTableName);
                //把数据写入临时表
                BulkToServer(command, EntitiesToTable(command, datas, schema, targetTableName), tempTableName, tran);
                //把临时表的数据写到目标表
                var resulTable = MergeUpdate(command, schema, targetTableName, tempTableName, primaryKey);
                //删除临时表
                DropTempTable(command, tempTableName);
                return ResultToEntity(resulTable);
            }
        }
        /// <summary>
        /// 批量同步（插入或更新或删除）
        /// </summary>
        public static List<BulkInsertResult> BulkSync(string connection, IList<T> datas, string schema, string targetTableName, string primaryKey, SqlTransaction tran)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings[connection].ConnectionString))
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                var command = new SqlCommand() { Connection = conn, CommandType = CommandType.Text, CommandTimeout = 30 };

                string tempTableName = $"#{typeof(T).Name}TempTable";
                //创建临时表
                CreateTempTable(command, tempTableName, schema, targetTableName);
                //把数据写入临时表
                BulkToServer(command, EntitiesToTable(command, datas, schema, targetTableName), tempTableName, tran);
                //把临时表的数据写到目标表
                var resulTable = MergeUpdateOrInsert(command, schema, targetTableName, tempTableName, primaryKey);
                //删除临时表
                DropTempTable(command, tempTableName);
                return ResultToEntity(resulTable);
            }
        }
        /// <summary>
        /// 批量更新更新或插入
        /// </summary>
        private static DataTable MergeUpdateOrInsert(SqlCommand command, string schema, string targetTableName, string sourceTableName, string primaryKey)
        {
            var fileds = CreateInsertSql(command, schema, targetTableName);
            string sql = $@"MERGE INTO {schema}.{targetTableName} AS T           
                            USING {sourceTableName} AS S
                               ON T.{primaryKey} = S.{primaryKey} 
                            WHEN MATCHED
                               THEN UPDATE SET {CreateUpdateSql(command, schema, targetTableName)}
                            WHEN NOT MATCHED BY TARGET
                               THEN INSERT ({fileds.Replace("[S].", "")}) VALUES({fileds})
                            --WHEN NOT MATCHED BY SOURCE
                            --   THEN DELETE
                            OUTPUT $ACTION AS[Action],
                               Deleted.{primaryKey} AS 'DeletedId',
                               Inserted.{primaryKey} AS 'InsertedId'; ";
            command.CommandText = sql;
            var da = new SqlDataAdapter { SelectCommand = command };
            var ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }
        /// <summary>
        /// 批量更新
        /// </summary>
        private static DataTable MergeUpdate(SqlCommand command, string schema, string targetTableName, string sourceTableName, string primaryKey)
        {
            string sql = $@"MERGE INTO {schema}.{targetTableName} AS T           
                            USING {sourceTableName} AS S
                               ON T.{primaryKey} = S.{primaryKey} 
                            WHEN MATCHED
                               THEN UPDATE SET {CreateUpdateSql(command, schema, targetTableName)}
                            --WHEN NOT MATCHED BY TARGET
                            --   THEN INSERT VALUES(S.ID, S.DSPT)
                            --WHEN NOT MATCHED BY SOURCE
                            --   THEN DELETE
                            OUTPUT $ACTION AS[ACTION],
                               Deleted.{primaryKey} AS 'DeletedID',
                               Inserted.{primaryKey} AS 'InsertedID'; ";
            command.CommandText = sql;
            var da = new SqlDataAdapter { SelectCommand = command };
            var ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }
        /// <summary>
        /// 创建更新的sql
        /// </summary>
        private static string CreateUpdateSql(SqlCommand command, string schema, string targetTableName)
        {
            var table = GetTableColumnInfo(command, schema, targetTableName);
            var list = (from DataRow row in table.Rows select $"[T].[{row["COLUMN_NAME"]}]=[S].[{row["COLUMN_NAME"]}]").ToList();
            return string.Join(",", list);
        }
        /// <summary>
        /// 创建插入sql
        /// </summary>
        private static string CreateInsertSql(SqlCommand command, string schema, string targetTableName)
        {
            var table = GetTableColumnInfo(command, schema, targetTableName);
            var list = (from DataRow row in table.Rows select $"[S].[{row["COLUMN_NAME"]}]").ToList();
            return string.Join(",", list);
        }
        /// <summary>
        /// 把数据集合转成table
        /// </summary>
        private static DataTable EntitiesToTable(SqlCommand command, IList<T> datas, string schema, string targetTableName)
        {
            var table = CreateTable(command, schema, targetTableName);
            foreach (var item in datas)
            {
                var dr = table.NewRow();
                foreach (DataColumn col in table.Columns)
                {
                    dr[col.ColumnName] = item.GetPropertyValue(col.ColumnName);
                }
                table.Rows.Add(dr);
            }
            return table;
        }
        /// <summary>
        /// 把数据批量写到数据库
        /// </summary>
        private static void BulkToServer(SqlCommand command, DataTable table, string targetTableName, SqlTransaction tran)
        {
            var sqlbulkcopy = new SqlBulkCopy(command.Connection, SqlBulkCopyOptions.UseInternalTransaction, tran);
            sqlbulkcopy.DestinationTableName = targetTableName;
            sqlbulkcopy.BatchSize = 1000;
            sqlbulkcopy.BulkCopyTimeout = 30;
            sqlbulkcopy.WriteToServer(table);
        }
        /// <summary>
        /// 创建临时表
        /// </summary>
        private static void CreateTempTable(SqlCommand command, string tempTableName, string schema, string targetTableName)
        {
            var tableColumnInfo = GetTableColumnInfo(command, schema, targetTableName);
            var table = CreateTable(command, schema, targetTableName);
            var builder = new StringBuilder();
            builder.Append($"if object_id('Tempdb.dbo.{tempTableName}') is not null drop table {tempTableName}; ");
            builder.Append($"create table {tempTableName} (");
            //foreach (DataRow row in table.Rows)
            //{
            //    builder.Append(row["COLUMN_NAME"]);
            //    builder.Append(" ");
            //    builder.Append(row["DATA_TYPE"]);
            //    if (row["DATA_TYPE"].ToString().Equals("nvarchar") || row["DATA_TYPE"].ToString().Equals("varchar"))
            //    {
            //        builder.Append("-1".Equals(row["CHARACTER_MAXIMUM_LENGTH"].ToString()) ? " (max)" : $" ({row["CHARACTER_MAXIMUM_LENGTH"]})");
            //    }
            //    builder.Append(",");
            //}
            foreach (DataColumn col in table.Columns)
            {
                DataRow[] dr = tableColumnInfo.Select($@"COLUMN_NAME='{col.ColumnName}'");
                builder.Append(dr[0]["COLUMN_NAME"]);
                builder.Append(" ");
                builder.Append(dr[0]["DATA_TYPE"]);
                if (dr[0]["DATA_TYPE"].ToString().Equals("nvarchar") || dr[0]["DATA_TYPE"].ToString().Equals("varchar"))
                {
                    builder.Append("-1".Equals(dr[0]["CHARACTER_MAXIMUM_LENGTH"].ToString()) ? " (max)" : $" ({dr[0]["CHARACTER_MAXIMUM_LENGTH"]})");
                }
                builder.Append(",");
            }
            builder.Append(");");
            command.CommandText = builder.ToString();
            command.ExecuteNonQuery();
        }
        /// <summary>
        /// 删除临时表
        /// </summary>
        private static void DropTempTable(SqlCommand command, string tempTableName)
        {
            string sql = $"if object_id('Tempdb.dbo.{tempTableName}') is not null drop table {tempTableName}; ";
            command.CommandText = sql;
            command.ExecuteNonQuery();
        }
        /// <summary>
        /// 创建表结构
        /// </summary>
        private static DataTable CreateTable(SqlCommand command, string schema, string targetTableName)
        {
            //var table = GetTableColumnInfo(command, schema, targetTableName);
            //var newTable = new DataTable();
            //foreach (DataRow row in table.Rows)
            //{
            //    newTable.Columns.Add(new DataColumn(row["COLUMN_NAME"].ToString(), row["DATA_TYPE"].GetType()));
            //}
            command.CommandText = $@"select * from {schema}.{targetTableName} where 1<0";
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = command;
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }
        /// <summary>
        /// 目标表的列信息
        /// </summary>
        private static DataTable GetTableColumnInfo(SqlCommand command, string schema, string targetTableName)
        {
            var restrictions = new string[4];
            restrictions[0] = command.Connection.Database;
            restrictions[1] = schema;
            restrictions[2] = targetTableName;
            return command.Connection.GetSchema("Columns", restrictions);
        }
        /// <summary>
        /// 把结果集转化为实体集
        /// </summary>
        private static List<BulkInsertResult> ResultToEntity(DataTable tablle)
        {
            return (from DataRow row in tablle.Rows
                select new BulkInsertResult
                {
                    Action = row["Action"].ToString(),
                    DeletedId = row["DeletedId"]?.ToString(),
                    InsertedId = row["InsertedId"]?.ToString()
                }).ToList();
        }
    }

}