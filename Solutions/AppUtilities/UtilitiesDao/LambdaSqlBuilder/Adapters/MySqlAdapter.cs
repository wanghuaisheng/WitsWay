using WitsWay.Utilities.Dap.LambdaSqlBuilder.Entities;

namespace WitsWay.Utilities.Dap.LambdaSqlBuilder.Adapters
{
    /// <summary>
    /// MySql适配器
    /// </summary>
    internal class MySqlAdapter : AdapterBase
    {
        public override string AutoIncrementDefinition { get; } = "AUTO_INCREMENT";

        public override string ParamStringPrefix { get; } = "@";

        public override string PrimaryKeyDefinition { get; } = " Primary Key";
        public override string SelectIdentitySql { get; set; } = "SELECT LAST_INSERT_ID()";

        public MySqlAdapter() : base(SqlConsts.LeftTokens[1], SqlConsts.RightTokens[1], SqlConsts.ParamPrefixs[0]) { }

        public override string QueryPage(SqlEntity entity)
        {
            var pageSize = entity.PageSize;
            var limit = pageSize * (entity.PageNumber - 1);

            return
                $"SELECT {entity.Selection} FROM {entity.TableName} {entity.Conditions} {entity.OrderBy} LIMIT {limit},{pageSize}";
        }

        public override string Field(string filedName)
        {
            return $"{_leftToken}{filedName}{_rightToken}";
        }

        public override string Field(string tableName, string fieldName)
        {
            return fieldName;
        }

        public override string CreateTablePrefix => "CREATE TABLE IF NOT EXISTS ";

        protected override string DbTypeBoolean(string fieldLength)
        {
            return "TINYINT(1)";
        }

        public override string DropTableSql(string tableName, string tableSchema)
        {
            var tablename = tableName;
            if (!string.IsNullOrEmpty(tableSchema))
            {
                tablename = $"{tableSchema}.{tablename}";
            }
            return $" DROP TABLE IF EXISTS {tablename}";
        }
    }
}
