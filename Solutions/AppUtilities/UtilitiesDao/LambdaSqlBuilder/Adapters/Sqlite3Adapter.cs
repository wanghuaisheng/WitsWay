using WitsWay.Utilities.Dap.LambdaSqlBuilder.Entities;

namespace WitsWay.Utilities.Dap.LambdaSqlBuilder.Adapters
{
    
    class Sqlite3Adapter : AdapterBase
    {
        public override string AutoIncrementDefinition { get; } = "AUTOINCREMENT";
 
        public override string ParamStringPrefix { get; } = "@";

        public override string PrimaryKeyDefinition { get; } = " Primary Key";

        public override string SelectIdentitySql { get; set; } = "select last_insert_rowid()";

        public override string CreateTablePrefix { get; } = "create table if not EXISTS ";

        public Sqlite3Adapter()
            : base(SqlConsts.LeftTokens[0], SqlConsts.RightTokens[0], SqlConsts.ParamPrefixs[0])
        {

        }

        public override string QueryPage(SqlEntity entity)
        {
            var limit = entity.PageSize;
            var offset = limit * (entity.PageNumber - 1);
            return
                $"SELECT {entity.Selection} FROM {entity.TableName} {entity.Conditions} {entity.OrderBy} LIMIT {limit} OFFSET {offset}";
        }

        public override string Field(string tableName, string fieldName)
        {
            return Field(fieldName);
        }

        public override string TableExistSql(string tableName, string tableSchema)
        {
            var table = Table(tableName, tableSchema);
            var sql = $"SELECT COUNT(*) FROM sqlite_master where type='table' and name='{table}'";

            return sql;
        }


        public override string Table(string tableName, string schema)
        {
            if (tableName.StartsWith(_leftToken) && tableName.EndsWith(_rightToken))
            {
                return tableName;
            }
            var tbname = $"{""}{tableName}{""}";
            if (!string.IsNullOrEmpty(schema))
            {
                return _leftToken + schema  + "_" + tbname + _rightToken;
            }
            return tbname;
        }

        protected override string DbTypeBoolean(string fieldLength)
        {
            return "boolean";
        }

        protected override string DbTypeGuid(string fieldLength)
        {
            if (string.IsNullOrEmpty(fieldLength))
            {
                fieldLength = "36";
            }
            return $"CHAR({fieldLength})";
        }

        
    }
}
