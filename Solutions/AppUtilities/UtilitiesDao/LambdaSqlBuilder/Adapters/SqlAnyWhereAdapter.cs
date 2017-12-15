using WitsWay.Utilities.Dap.LambdaSqlBuilder.Entities;

namespace WitsWay.Utilities.Dap.LambdaSqlBuilder.Adapters
{
    
    class SqlAnyWhereAdapter : AdapterBase
    {
        public override string AutoIncrementDefinition { get; } = "AUTOINCREMENT";
 

        public override string ParamStringPrefix { get; } = "@";

        public override string PrimaryKeyDefinition { get; } = " Primary Key";
        public override string SelectIdentitySql { get; set; } = "select @@identity ";
        public SqlAnyWhereAdapter()
            : base(SqlConsts.LeftTokens[2], SqlConsts.RightTokens[2], SqlConsts.ParamPrefixs[0])
        {
           // AUTOINCREMENT
        }

        public override string QueryPage(SqlEntity entity)
        {
            var pageSize = entity.PageSize;
            var limit = pageSize * (entity.PageNumber - 1);
           // select top 30 start at (N - 1) * 30 + 1 * from customer
            return string.Format("SELECT TOP {4} start at {5} {0} FROM {1} {2} {3} ", entity.Selection, entity.TableName, entity.Conditions, entity.OrderBy, pageSize,limit+1 );
        }

        public override string TableExistSql(string tableName, string tableSchema)
        {
            var sql = $"SELECT COUNT(*) FROM SYSTAB  JOIN SYSDBSPACE  n ON n.dbspace_id = SYSTAB.dbspace_id WHERE table_name = '{tableName}' ";

            if (!string.IsNullOrEmpty(tableSchema))
            {
                sql += $"AND n.dbspace_name = '{tableSchema}'";
            }

            //todo: this do not test. use it carefully.
            return sql;
        }


        protected override string DbTypeSingle(string fieldLength)
        {
            return "real";
        }

        protected override string DbTypeString(string fieldLength)
        {
            if (int.Parse(fieldLength) > 8000)
            {
                return $"long binary";
            }
            return $"CHARACTER VARYING({fieldLength})";
        }
    }
}
