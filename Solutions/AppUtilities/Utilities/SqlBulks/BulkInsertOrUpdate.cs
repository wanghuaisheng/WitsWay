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
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WitsWay.Utilities.SqlBulks
{
    /// <summary>
    /// 批量插入或更新
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    public class BulkInsertOrUpdate<T> : ITransaction
    {
        private readonly IEnumerable<T> _list;
        private readonly string _tableName;
        private readonly string _schema;
        private readonly HashSet<string> _columns;
        private readonly List<string> _matchTargetOn;
        private readonly string _sourceAlias;
        private readonly string _targetAlias;
        private string _identityColumn;
        private bool _outputIdentity;
        private readonly Dictionary<string, string> _customColumnMappings;
        private readonly int _sqlTimeout;
        private readonly int _bulkCopyTimeout;
        private readonly bool _bulkCopyEnableStreaming;
        private readonly int? _bulkCopyNotifyAfter;
        private readonly int? _bulkCopyBatchSize;
        private readonly bool _disableAllIndexes;
        private readonly BulkOperationsHelpers _helper;
        private bool _deleteWhenNotMatchedFlag;
        private readonly HashSet<string> _disableIndexList;
        private readonly SqlBulkCopyOptions _sqlBulkCopyOptions;
        private readonly Dictionary<int, T> _outputIdentityDic;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <param name="tableName"></param>
        /// <param name="schema"></param>
        /// <param name="columns"></param>
        /// <param name="disableIndexList"></param>
        /// <param name="disableAllIndexes"></param>
        /// <param name="sourceAlias"></param>
        /// <param name="targetAlias"></param>
        /// <param name="customColumnMappings"></param>
        /// <param name="sqlTimeout"></param>
        /// <param name="bulkCopyTimeout"></param>
        /// <param name="bulkCopyEnableStreaming"></param>
        /// <param name="bulkCopyNotifyAfter"></param>
        /// <param name="bulkCopyBatchSize"></param>
        /// <param name="sqlBulkCopyOptions"></param>
        /// <param name="ext"></param>
        public BulkInsertOrUpdate(IEnumerable<T> list, string tableName, string schema, HashSet<string> columns, HashSet<string> disableIndexList,
            bool disableAllIndexes, string sourceAlias, string targetAlias, Dictionary<string, string> customColumnMappings, int sqlTimeout, int bulkCopyTimeout,
            bool bulkCopyEnableStreaming, int? bulkCopyNotifyAfter, int? bulkCopyBatchSize, SqlBulkCopyOptions sqlBulkCopyOptions, BulkOperations ext)
        {
            _list = list;
            _tableName = tableName;
            _schema = schema;
            _columns = columns;
            _sourceAlias = sourceAlias;
            _targetAlias = targetAlias;
            _customColumnMappings = customColumnMappings;
            _sqlTimeout = sqlTimeout;
            _bulkCopyTimeout = bulkCopyTimeout;
            _bulkCopyEnableStreaming = bulkCopyEnableStreaming;
            _bulkCopyNotifyAfter = bulkCopyNotifyAfter;
            _bulkCopyBatchSize = bulkCopyBatchSize;
            _outputIdentity = false;
            _deleteWhenNotMatchedFlag = false;
            _helper = new BulkOperationsHelpers();
            _outputIdentityDic = new Dictionary<int, T>();
            _disableIndexList = disableIndexList;
            _matchTargetOn = new List<string>();
            _disableAllIndexes = disableAllIndexes;
            _sqlBulkCopyOptions = sqlBulkCopyOptions;
            ext.SetBulkExt(this);
        }

        /// <summary>
        /// 至少需要正确配置一个MatchTargetOn，用于确定Table中每一行的匹配Clause，通常使用唯一标识作为MatchTargetOn，也允许使用多列匹配复杂的关系
        /// </summary>
        public BulkInsertOrUpdate<T> MatchTargetOn(Expression<Func<T, object>> columnName)
        {
            var propertyName = _helper.GetPropertyName(columnName);
            if (propertyName == null) throw new InvalidOperationException("匹配ON对应的列名必须设置");
            _matchTargetOn.Add(propertyName);
            return this;
        }

        /// <summary>
        /// Sets the identity column for the table. Required if an Identity column exists in table and one of the two 
        /// following conditions is met: (1) MatchTargetOn list contains an identity column (2) AddAllColumns is used in setup. 
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public BulkInsertOrUpdate<T> SetIdentityColumn(Expression<Func<T, object>> columnName)
        {

            var propertyName = _helper.GetPropertyName(columnName);

            if (propertyName == null)
                throw new InvalidOperationException("SetIdentityColumn column name can't be null");

            if (_identityColumn == null)
            {
                _identityColumn = propertyName;
            }
            else
            {
                throw new InvalidOperationException("Can't have more than one identity column");
            }
            return this;
        }

        /// <summary>
        /// Sets the identity column for the table. Required if an Identity column exists in table and one of the two 
        /// following conditions is met: (1) MatchTargetOn list contains an identity column (2) AddAllColumns is used in setup. 
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="outputIdentity"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public BulkInsertOrUpdate<T> SetIdentityColumn(Expression<Func<T, object>> columnName, bool outputIdentity)
        {
            _outputIdentity = outputIdentity;

            var propertyName = _helper.GetPropertyName(columnName);

            if (propertyName == null)
                throw new InvalidOperationException("SetIdentityColumn column name can't be null");

            if (_identityColumn == null)
                _identityColumn = propertyName;

            else
            {
                throw new InvalidOperationException("Can't have more than one identity column");
            }

            return this;
        }

        /// <summary>
        /// If a target record can't be matched to a source record, it's deleted. Notes: (1) This is false by default. (2) Use at your own risk.
        /// </summary>
        /// <param name="flag"></param>
        /// <returns></returns>
        public BulkInsertOrUpdate<T> DeleteWhenNotMatched(bool flag)
        {
            _deleteWhenNotMatchedFlag = flag;
            return this;
        }

        void ITransaction.CommitTransaction(string connectionName, SqlCredential credentials, SqlConnection connection)
        {
            if (!_list.Any())
            {
                return;
            }

            if (_disableAllIndexes && (_disableIndexList != null && _disableIndexList.Any()))
            {
                throw new InvalidOperationException("Invalid setup. If \'TmpDisableAllNonClusteredIndexes\' is invoked, you can not use the \'AddTmpDisableNonClusteredIndex\' method.");
            }

            if (_matchTargetOn.Count == 0)
            {
                throw new InvalidOperationException("MatchTargetOn list is empty when it's required for this operation. " +
                                                    "This is usually the primary key of your table but can also be more than one column depending on your business rules.");
            }

            var dt = _helper.ToDataTable(_list, _columns, _customColumnMappings, _matchTargetOn, _outputIdentity, _outputIdentityDic);

            // Must be after ToDataTable is called. 
            _helper.DoColumnMappings(_customColumnMappings, _columns, _matchTargetOn);

            using (var conn = _helper.GetSqlConnection(connectionName, credentials, connection))
            {
                conn.Open();
                var dtCols = _helper.GetDatabaseSchema(conn, _schema, _tableName);

                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        var command = conn.CreateCommand();
                        command.Connection = conn;
                        command.Transaction = transaction;
                        command.CommandTimeout = _sqlTimeout;

                        //Creating temp table on database
                        command.CommandText = _helper.BuildCreateTempTable(_columns, dtCols, _outputIdentity);
                        command.ExecuteNonQuery();

                        _helper.InsertToTmpTable(conn, transaction, dt, _bulkCopyEnableStreaming, _bulkCopyBatchSize,
                            _bulkCopyNotifyAfter, _bulkCopyTimeout, _sqlBulkCopyOptions);

                        if (_disableIndexList != null && _disableIndexList.Any())
                        {
                            command.CommandText = _helper.GetIndexManagementCmd(IndexOperation.Disable, _tableName, _disableIndexList, _disableAllIndexes);
                            command.ExecuteNonQuery();
                        }

                        //if (_outputIdentity)
                        //{
                        //    command.CommandText = _helper.GetOutputCreateTableCmd(_outputIdentity, "#TmpOutput",
                        //        OperationType.Insert);
                        //    command.ExecuteNonQuery();
                        //}

                        var comm =
                            _helper.GetOutputCreateTableCmd(_outputIdentity, "#TmpOutput", OperationType.Insert) +
                            "MERGE INTO " + _helper.GetFullQualifyingTableName(conn.Database, _schema, _tableName) +
                            " WITH (HOLDLOCK) AS Target " +
                            "USING #TmpTable AS Source " +
                            _helper.BuildJoinConditionsForUpdateOrInsert(_matchTargetOn.ToArray(),
                                _sourceAlias, _targetAlias) +
                            "WHEN MATCHED THEN " +
                            _helper.BuildUpdateSet(_columns, _sourceAlias, _targetAlias, _identityColumn) +
                            "WHEN NOT MATCHED BY TARGET THEN " +
                            _helper.BuildInsertSet(_columns, _sourceAlias, _identityColumn) +
                            (_deleteWhenNotMatchedFlag ? " WHEN NOT MATCHED BY SOURCE THEN DELETE " : " ") +
                            _helper.GetOutputIdentityCmd(_identityColumn, _outputIdentity, "#TmpOutput",
                                OperationType.Insert) +
                            "DROP TABLE #TmpTable;";
                        command.CommandText = comm;
                        command.ExecuteNonQuery();

                        if (_disableIndexList != null && _disableIndexList.Any())
                        {
                            command.CommandText = _helper.GetIndexManagementCmd(IndexOperation.Rebuild, _tableName, _disableIndexList);
                            command.ExecuteNonQuery();
                        }

                        if (_outputIdentity)
                        {
                            command.CommandText = "SELECT InternalId, Id FROM #TmpOutput;";

                            using (var reader = command.ExecuteReader())
                            {
                                //var list = _list.ToList();
                                while (reader.Read())
                                {
                                    //var test = reader[0];
                                    //var test2 = reader[1];
                                    T item;
                                    if (_outputIdentityDic.TryGetValue((int)reader[0], out item))
                                    {
                                        var type = item.GetType();

                                        var prop = type.GetProperty(_identityColumn);

                                        prop.SetValue(item, reader[1], null);
                                    }
                                }
                            }
                        }
                        transaction.Commit();
                    }

                    catch (SqlException e)
                    {
                        for (var i = 0; i < e.Errors.Count; i++)
                        {
                            // Error 8102 is identity error. 
                            if (e.Errors[i].Number == 8102)
                            {
                                // Expensive call but neccessary to inform user of an important configuration setup. 
                                throw new IdentityException(e.Errors[i].Message);
                            }
                        }

                        transaction.Rollback();
                        throw;
                    }

                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }

        async Task ITransaction.CommitTransactionAsync(string connectionName, SqlCredential credentials, SqlConnection connection)
        {
            if (!_list.Any())
            {
                return;
            }

            if (_disableAllIndexes && (_disableIndexList != null && _disableIndexList.Any()))
            {
                throw new InvalidOperationException("Invalid setup. If \'TmpDisableAllNonClusteredIndexes\' is invoked, you can not use the \'AddTmpDisableNonClusteredIndex\' method.");
            }

            if (_matchTargetOn.Count == 0)
            {
                throw new InvalidOperationException("MatchTargetOn list is empty when it's required for this operation. " +
                                                    "This is usually the primary key of your table but can also be more than one column depending on your business rules.");
            }

            var dt = _helper.ToDataTable(_list, _columns, _customColumnMappings, _matchTargetOn, _outputIdentity, _outputIdentityDic);

            //确保在ToDataTable后调用DoColumnMappings
            _helper.DoColumnMappings(_customColumnMappings, _columns, _matchTargetOn);

            using (var conn = _helper.GetSqlConnection(connectionName, credentials, connection))
            {
                conn.Open();
                var dtCols = _helper.GetDatabaseSchema(conn, _schema, _tableName);
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        var command = conn.CreateCommand();
                        command.Connection = conn;
                        command.Transaction = transaction;
                        command.CommandTimeout = _sqlTimeout;

                        //在数据库中创建临时表
                        command.CommandText = _helper.BuildCreateTempTable(_columns, dtCols);
                        await command.ExecuteNonQueryAsync();

                        await _helper.InsertToTmpTableAsync(conn, transaction, dt, _bulkCopyEnableStreaming, _bulkCopyBatchSize,
                            _bulkCopyNotifyAfter, _bulkCopyTimeout, _sqlBulkCopyOptions);

                        if (_disableIndexList != null && _disableIndexList.Any())
                        {
                            command.CommandText = _helper.GetIndexManagementCmd(IndexOperation.Disable, _tableName, _disableIndexList, _disableAllIndexes);
                            await command.ExecuteNonQueryAsync();
                        }

                        //更新目标表，删除临时表
                        var comm = "MERGE INTO " + _helper.GetFullQualifyingTableName(conn.Database, _schema, _tableName) + " WITH (HOLDLOCK) AS Target " +
                                      "USING #TmpTable AS Source " +
                                      _helper.BuildJoinConditionsForUpdateOrInsert(_matchTargetOn.ToArray(),
                                          _sourceAlias, _targetAlias) +
                                      "WHEN MATCHED THEN " +
                                      _helper.BuildUpdateSet(_columns, _sourceAlias, _targetAlias, _identityColumn) +
                                      "WHEN NOT MATCHED BY TARGET THEN " +
                                      _helper.BuildInsertSet(_columns, _sourceAlias, _identityColumn) +
                                      (_deleteWhenNotMatchedFlag ? " WHEN NOT MATCHED BY SOURCE THEN DELETE; " : "; ") +
                                      "DROP TABLE #TmpTable;";
                        command.CommandText = comm;
                        await command.ExecuteNonQueryAsync();

                        if (_disableIndexList != null && _disableIndexList.Any())
                        {
                            command.CommandText = _helper.GetIndexManagementCmd(IndexOperation.Rebuild, _tableName, _disableIndexList);
                            await command.ExecuteNonQueryAsync();
                        }

                        transaction.Commit();

                    }

                    catch (SqlException e)
                    {
                        for (var i = 0; i < e.Errors.Count; i++)
                        {
                            // 标识错误8102
                            if (e.Errors[i].Number == 8102)
                            {
                                // Expensive call but neccessary to inform user of an important configuration setup. 
                                throw new IdentityException(e.Errors[i].Message);
                            }
                        }
                        transaction.Rollback();
                        throw;
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }
    }
}
