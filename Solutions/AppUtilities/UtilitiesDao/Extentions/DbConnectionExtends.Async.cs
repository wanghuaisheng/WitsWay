using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using WitsWay.Utilities.Dap.Helpers;
using WitsWay.Utilities.Dap.LambdaSqlBuilder.Adapters;
using WitsWay.Utilities.Dap.LambdaSqlBuilder.Entities;

namespace WitsWay.Utilities.Dap.Extentions
{
    public static partial class DbConnectionExtends
    {
        public static Task CreateTableAsync<T>(this IDbConnection db, IDbTransaction transaction = null)
        {
            //return Task.Run(() => { db.CreateTable<T>(transaction); });
            var dbAdapter = AdapterFactory.GetAdapterInstance(db.GetAdapterKind());

            var entityDef = EntityHelper.GetEntityDefine<T>();

            var createTableSql = dbAdapter.CreateTableSql(entityDef.Item1, entityDef.Item2);

            return db.ExecuteSqlAsync( transaction, createTableSql);

        }

        public static Task CreateTableIfNotExistAsync<T>(this IDbConnection db, IDbTransaction transaction = null)
        {
           return db.TableExistAsync<T>(transaction).ContinueWith((async task =>
            {
                if (!task.Result)
                {
                    var dbAdapter = AdapterFactory.GetAdapterInstance(db.GetAdapterKind());

                    var entityDef = EntityHelper.GetEntityDefine<T>();

                    var createTableSql = dbAdapter.CreateTableSql(entityDef.Item1, entityDef.Item2);

                   await db.ExecuteSqlAsync(transaction, createTableSql);
                }
                
            }));
        }

        public static Task CreateTableAsync(this IDbConnection db, SqlTableDefine tableDefine,
            List<SqlColumnDefine> columnList, IDbTransaction transaction = null)
        {
            var dbAdapter = AdapterFactory.GetAdapterInstance(db.GetAdapterKind());

            var createTableSql = dbAdapter.CreateTableSql(tableDefine, columnList);

            return db.ExecuteSqlAsync(transaction, createTableSql);
        }

        public static Task CreateTableIfNotExistAsync(this IDbConnection db, SqlTableDefine tableDefine,
            List<SqlColumnDefine> columnList, IDbTransaction transaction = null)
        {
            return db.TableExistAsync(tableDefine,transaction).ContinueWith((async task =>
            {
                if (!task.Result)
                {
                    var dbAdapter = AdapterFactory.GetAdapterInstance(db.GetAdapterKind());
 

                    var createTableSql = dbAdapter.CreateTableSql(tableDefine, columnList);

                    await db.ExecuteSqlAsync(transaction, createTableSql);
                }

            }));
        }

        public static Task<bool> TableExistAsync<T>(this IDbConnection db, IDbTransaction transaction = null)
        {
            var entityDef = EntityHelper.GetEntityDefine<T>();


            return db.TableExistAsync(tableDefine:entityDef.Item1, transaction:transaction);
        }

        public static Task<bool> TableExistAsync(this IDbConnection db, SqlTableDefine tableDefine,
            IDbTransaction transaction = null)
        {
            var tableName = tableDefine.Name;
            var tableSchema = "";

            if (!string.IsNullOrEmpty(tableDefine.TableAttribute?.Name))
            {
                tableName = tableDefine.TableAttribute.Name;
                tableSchema = tableDefine.TableAttribute.Schema;
            }
            return db.TableExistAsync(tableName, tableSchema, transaction);
        }

        public static async Task<bool> TableExistAsync(this IDbConnection db, string tableName, string tableSchema = null,
            IDbTransaction transaction = null)
        {
 
            var dbAdapter = AdapterFactory.GetAdapterInstance(db.GetAdapterKind());

            var tableExistSql = dbAdapter.TableExistSql(tableName, tableSchema);

            var result= await db.ExecuteScalarAsync<int>(tableExistSql, transaction: transaction);

            return result > 0;
        }

        public static Task<int> DropTableAsync<T>(this IDbConnection db, IDbTransaction transaction = null)
        {
            var tableDefine = EntityHelper.GetEntityDefine<T>().Item1;

            return  db.DropTableAsync(tableDefine, transaction);
        }

        public static Task<int> DropTableAsync(this IDbConnection db, SqlTableDefine tableDefine,
            IDbTransaction transaction = null)
        {
            var tableSchema = string.Empty;
            var tableName = tableDefine.Name;

            if (!string.IsNullOrEmpty(tableDefine.TableAttribute?.Name))
            {
                tableName = tableDefine.TableAttribute.Name;
                tableSchema = tableDefine.TableAttribute.Schema;
            }

            return db.DropTableAsync(tableName, tableSchema, transaction);
        }

        public static Task<int> DropTableAsync(this IDbConnection db, string tableName, string tableSchema,
            IDbTransaction transaction = null)
        {
            var dbAdapter = AdapterFactory.GetAdapterInstance(db.GetAdapterKind());

            var sql = dbAdapter.DropTableSql(tableName, tableSchema);

            return db.ExecuteAsync(sql, transaction: transaction);
        }

        public static Task<int> TruncateTableAsync<T>(this IDbConnection db, IDbTransaction transaction = null)
        {
            var tableDefine = EntityHelper.GetEntityDefine<T>().Item1;

            return db.TruncateTableAsync(tableDefine, transaction);
        }

        public static Task<int> TruncateTableAsync(this IDbConnection db, SqlTableDefine tableDefine,
            IDbTransaction transaction = null)
        {
            var tableSchema = string.Empty;
            var tableName = tableDefine.Name;

            if (!string.IsNullOrEmpty(tableDefine.TableAttribute?.Name))
            {
                tableName = tableDefine.TableAttribute.Name;
                tableSchema = tableDefine.TableAttribute.Schema;
            }
           return db.TruncateTableAsync(tableName, tableSchema, transaction);
        }

        public static Task<int> TruncateTableAsync(this IDbConnection db, string tableName, string tableSchema,
            IDbTransaction transaction = null)
        {
            var dbAdapter = AdapterFactory.GetAdapterInstance(db.GetAdapterKind());

            var sql = dbAdapter.TruncateTableSql(tableName, tableSchema);

            return db.ExecuteAsync(sql, transaction: transaction);
        }
    }
}