using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using WitsWay.Utilities.Dap.Helpers;
using WitsWay.Utilities.Dap.LambdaSqlBuilder.Adapter;
using WitsWay.Utilities.Dap.LambdaSqlBuilder.Entity;

namespace WitsWay.Utilities.Dap.Extentions
{
    /// <summary>
    /// Db连接扩展
    /// </summary>
    public static partial class DbConnectionExtends
    {
        private static bool _typeRegistered;
        /// <summary>
        /// 获取适配器类型
        /// </summary>
        /// <param name="conn"></param>
        /// <returns></returns>
        public static SqlAdapterKinds GetAdapterKind(this IDbConnection conn)
        {
            if (!_typeRegistered)
            {
                PreApplicationStart.RegisterTypeMaps();
                _typeRegistered = true;
            }

            var typeName = conn.GetType().Name;
            if (typeName.Contains("MySqlConnection"))
            {
                return SqlAdapterKinds.MySql;
            }

            if (typeName.Contains("SqlConnection"))
            {
                return SqlAdapterKinds.SqlServer;
            }
            if (typeName.Contains("SQLiteConnection"))
            {
                return SqlAdapterKinds.Sqlite;
            }
            if (typeName.Contains("SqliteConnection"))
            {
                return SqlAdapterKinds.Sqlite;
            }
            if (typeName.Contains("OracleConnection"))
            {
                return SqlAdapterKinds.Oracle;
            }

            if (typeName.Contains("NpgsqlConnection"))
            {
                return SqlAdapterKinds.Postgres;
            }
            if (typeName.Contains("SAConnection"))
            {
                return SqlAdapterKinds.SqlAnyWhere;
            }
            if (typeName.Contains("SqlCeConnection"))
            {
                return SqlAdapterKinds.SqlServerCE;
            }
            return SqlAdapterKinds.SqlServer;
        }


        /// <summary>
        /// 根据实体类创建数据库表
        /// </summary>
        /// <typeparam name="T">实体类类型</typeparam>
        /// <param name="db"></param>
        /// <param name="transaction"></param>
        public static void CreateTable<T>(this IDbConnection db, IDbTransaction transaction = null)
        {
            var dbAdapter = AdapterFactory.GetAdapterInstance(db.GetAdapterKind());

            var entityDef = EntityHelper.GetEntityDefine<T>();

            var createTableSql = dbAdapter.CreateTableSql(entityDef.Item1, entityDef.Item2);

            ExecuteSql(db, transaction, createTableSql);
        }


        /// <summary>
        /// 根据实体类创建数据库表
        /// </summary>
        /// <typeparam name="T">实体类类型</typeparam>
        /// <param name="db"></param>
        /// <param name="transaction"></param>
        public static void CreateTableIfNotExist<T>(this IDbConnection db, IDbTransaction transaction = null)
        {
            if (!db.TableExist<T>(transaction))
            {
                var dbAdapter = AdapterFactory.GetAdapterInstance(db.GetAdapterKind());

                var entityDef = EntityHelper.GetEntityDefine<T>();

                var createTableSql = dbAdapter.CreateTableSql(entityDef.Item1, entityDef.Item2);

                ExecuteSql(db, transaction, createTableSql);
            }
        }


        public static void CreateTable(this IDbConnection db, SqlTableDefine tableDefine, List<SqlColumnDefine> columnList, IDbTransaction transaction = null)
        {
            var dbAdapter = AdapterFactory.GetAdapterInstance(db.GetAdapterKind());

            var createTableSql = dbAdapter.CreateTableSql(tableDefine, columnList);

             

            ExecuteSql(db, transaction, createTableSql);
        }

        public static void CreateTableIfNotExist(this IDbConnection db, SqlTableDefine tableDefine, List<SqlColumnDefine> columnList, IDbTransaction transaction = null)
        {
            if (!db.TableExist(tableDefine, transaction))
            {
                var dbAdapter = AdapterFactory.GetAdapterInstance(db.GetAdapterKind());

                var createTableSql = dbAdapter.CreateTableSql(tableDefine, columnList);



                db.ExecuteSql(transaction, createTableSql);
            }
        }


      

        public static bool TableExist<T>(this IDbConnection db, IDbTransaction transaction = null)
        {
            var entityDef = EntityHelper.GetEntityDefine<T>();

            return db.TableExist(entityDef.Item1, transaction);
        }

        public static bool TableExist(this IDbConnection db, SqlTableDefine tableDefine, IDbTransaction transaction = null)
        {
            var tableName = tableDefine.Name;
            var tableSchema = "";

            if (!string.IsNullOrEmpty(tableDefine.TableAttribute?.Name))
            {
                tableName = tableDefine.TableAttribute.Name;
                tableSchema = tableDefine.TableAttribute.Schema;
            }
            return db.TableExist(tableName, tableSchema, transaction);
        }

        public static bool TableExist(this IDbConnection db, string tableName, string tableSchema = null, IDbTransaction transaction = null)
        {
            var dbAdapter = AdapterFactory.GetAdapterInstance(db.GetAdapterKind());

            var tableExistSql = dbAdapter.TableExistSql(tableName, tableSchema);

            return db.ExecuteScalar<int>(tableExistSql, transaction: transaction) > 0;
        }

        /// <summary>
        /// 根据实体类删除数据表
        /// </summary>
        /// <typeparam name="T">实体类类型</typeparam>
        /// <param name="db"></param>
        public static void DropTable<T>(this IDbConnection db, IDbTransaction transaction = null)
        {

            var tableDefine = EntityHelper.GetEntityDefine<T>().Item1;

            db.DropTable(tableDefine, transaction);

        }

        public static void DropTable(this IDbConnection db, SqlTableDefine tableDefine, IDbTransaction transaction = null)
        {
            var tableSchema = string.Empty;
            var tableName = tableDefine.Name;

            if (!string.IsNullOrEmpty(tableDefine.TableAttribute?.Name))
            {
                tableName = tableDefine.TableAttribute.Name;
                tableSchema = tableDefine.TableAttribute.Schema;
            }
            db.DropTable(tableName, tableSchema, transaction);
        }

        public static void DropTable(this IDbConnection db, string tableName, string tableSchema, IDbTransaction transaction = null)
        {
            var dbAdapter = AdapterFactory.GetAdapterInstance(db.GetAdapterKind());

            var sql = dbAdapter.DropTableSql(tableName, tableSchema);

            db.Execute(sql, transaction: transaction);
        }

        /// <summary>
        /// 根据实体类删除数据表
        /// </summary>
        /// <typeparam name="T">实体类类型</typeparam>
        /// <param name="db"></param>
        /// <param name="transaction"></param>
        public static void TruncateTable<T>(this IDbConnection db, IDbTransaction transaction = null)
        {

            var tableDefine = EntityHelper.GetEntityDefine<T>().Item1;

            db.TruncateTable(tableDefine, transaction);

        }

        public static void TruncateTable(this IDbConnection db, SqlTableDefine tableDefine, IDbTransaction transaction = null)
        {
            var tableSchema = string.Empty;
            var tableName = tableDefine.Name;

            if (!string.IsNullOrEmpty(tableDefine.TableAttribute?.Name))
            {
                tableName = tableDefine.TableAttribute.Name;
                tableSchema = tableDefine.TableAttribute.Schema;
            }
            db.TruncateTable(tableName, tableSchema, transaction);
        }

        public static void TruncateTable(this IDbConnection db, string tableName, string tableSchema, IDbTransaction transaction = null)
        {
            var dbAdapter = AdapterFactory.GetAdapterInstance(db.GetAdapterKind());

            var sql = dbAdapter.TruncateTableSql(tableName, tableSchema);

            db.Execute(sql, transaction: transaction);
        }

        private static void ExecuteSql(this IDbConnection db, IDbTransaction transaction, string createTableSql)
        {
            DapperLambdaExtends.DebuggingSqlString(createTableSql);

            if (transaction == null)
            {
                var trans = db.BeginTransaction();
                try
                {
                    db.Execute(createTableSql, transaction: trans);

                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();

                    DapperLambdaExtends.DebuggingException(ex, createTableSql);
                    throw new DapperLambdaException(ex.Message, ex, createTableSql);
                }
            }
            else
            {
                try
                {
                    db.Execute(createTableSql, transaction: transaction);
                }
                catch (Exception ex)
                {
                    DapperLambdaExtends.DebuggingException(ex, createTableSql);
                    throw new DapperLambdaException(ex.Message, ex, createTableSql);
                }
            }
        }

        private static async Task<int> ExecuteSqlAsync(this IDbConnection db, IDbTransaction transaction, string createTableSql)
        {
            DapperLambdaExtends.DebuggingSqlString(createTableSql);

            if (transaction == null)
            {
                var trans = db.BeginTransaction();
                try
                {
                  var ret=  await db.ExecuteAsync(createTableSql, transaction: trans);

                    trans.Commit();

                    return ret;
                }
                catch (Exception ex)
                {
                    trans.Rollback();

                    DapperLambdaExtends.DebuggingException(ex, createTableSql);
                    throw new DapperLambdaException(ex.Message, ex, createTableSql);
                }
            }
            else
            {
                try
                {
                    return  await db.ExecuteAsync(createTableSql, transaction: transaction);
                }
                catch (Exception ex)
                {
                    DapperLambdaExtends.DebuggingException(ex, createTableSql);
                    throw new DapperLambdaException(ex.Message, ex, createTableSql);
                }
            }
        }
    }
}
