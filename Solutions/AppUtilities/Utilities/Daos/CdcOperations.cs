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
using System.Data;
using System.Linq;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

namespace WitsWay.Utilities.Daos
{
    /// <summary>
    /// CDCOperations
    /// </summary>
    public class CdcOperations
    {
        private readonly Database _db;
        /// <summary>
        /// 构造
        /// </summary>
        public CdcOperations(string connectionStr)
        {
            _db = new SqlDatabase(connectionStr);
        }

        #region cdc操作
        /// <summary>
        /// 对数据库开启CDC
        /// </summary>
        public void EnableDb()
        {
            var cmd = _db.GetSqlStringCommand("EXECUTE sys.sp_cdc_enable_db");
            _db.ExecuteNonQuery(cmd);
        }
        /// <summary>
        /// 关闭数据库CDC
        /// </summary>
        public void DisableDb()
        {
            var cmd = _db.GetSqlStringCommand("EXECUTE sys.sp_cdc_disable_db");
            _db.ExecuteNonQuery(cmd);
        }
        /// <summary>
        /// 检查数据库是否已经开启CDC
        /// </summary>
        public bool IsEnableDb(string dbName)
        {
            var cmd = _db.GetSqlStringCommand($"SELECT is_cdc_enabled  FROM SYS.databases WHERE name='{dbName}'");
            return _db.ExecuteScalar(cmd).ToString().Equals("True");
        }
        /// <summary>
        /// 对表开启CDC
        /// </summary>
        public void EnableTable(string schema, string tableName, List<string> columns)
        {
            var sql = $@"EXECUTE sys.sp_cdc_enable_table
                            @source_schema = N'{schema}'
                           ,@source_name = N'{tableName}'
                           ,@captured_column_list ='{string.Join(",", columns)}'
                           , @role_name = null;";
            var cmd = _db.GetSqlStringCommand(sql);
            _db.ExecuteNonQuery(cmd);
        }
        /// <summary>
        /// 关闭表的CDC
        /// </summary>
        public void DisableTable(string schema, string tableName)
        {
            var sql =
                $@"EXECUTE sys.sp_cdc_disable_table
                       @source_schema = N'{schema}'
                      ,@source_name = N'{tableName}'
                      ,@capture_instance = '{schema}_{tableName}';";
            var cmd = _db.GetSqlStringCommand(sql);
            _db.ExecuteNonQuery(cmd);
        }
        /// <summary>
        /// 检查表是否开启CDC
        /// </summary>
        public bool IsEnableTable(string schema, string tableName)
        {
            var cmd = _db.GetSqlStringCommand($"SELECT  is_tracked_by_cdc FROM    sys.tables WHERE   OBJECT_ID = OBJECT_ID('{schema}.{tableName}')");
            return _db.ExecuteScalar(cmd).ToString().Equals("True");
        }
        #endregion

        /// <summary>
        /// 取数据库信息
        /// </summary>
        public string GetDbName()
        {
            return
                _db.ConnectionString.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries)
                    .FirstOrDefault(s => s.Contains("Database"))?
                    .Split(new[] { "=" }, StringSplitOptions.RemoveEmptyEntries)[1];
        }

        /// <summary>
        /// 取数据库里面所有的表
        /// </summary>
        public DataTable GetTables()
        {
            using (var conn = _db.CreateConnection())
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                var dv = conn.GetSchema("Tables").DefaultView;
                dv.RowFilter = "TABLE_SCHEMA<>'cdc' and TABLE_TYPE='BASE TABLE'";
                return dv.ToTable();
            }
        }
        /// <summary>
        /// 取表的所有列
        /// </summary>
        public DataTable GetColumnsByTable(string schema, string tableName)
        {
            return _db.ExecuteDataSet(CommandType.Text, $"SELECT [ID],[Name] FROM SYSCOLUMNS WHERE ID=OBJECT_ID('{schema}.{tableName}' )").Tables[0];
        }

        /// <summary>
        /// 取已经开启CDC的表
        /// </summary>
        public DataTable GetCdcTables()
        {
            return _db.ExecuteDataSet(CommandType.Text, "select [object_id],capture_instance from cdc.change_tables").Tables[0];
        }
        /// <summary>
        /// 取所有开启CDC的列
        /// </summary>
        public DataTable GetCdcColumns()
        {
            return _db.ExecuteDataSet(CommandType.Text, "SELECT [object_id],[column_name] FROM [cdc].[captured_columns]").Tables[0];
        }
    }

}