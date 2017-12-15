using WitsWay.Utilities.Dap.LambdaSqlBuilder.Entities;

namespace WitsWay.Utilities.Dap.LambdaSqlBuilder.Adapters
{
   
    /// <summary>
    /// 支持Sqlserver 2005及以上
    /// </summary>
    
    class SqlserverCEAdapter : AdapterBase, ISqlAdapter
    {
        public override string AutoIncrementDefinition { get; } = "IDENTITY(1,1)";
 
        public override string ParamStringPrefix { get; } = "@";

        public override string PrimaryKeyDefinition { get; } = " Primary Key";
        public override string SelectIdentitySql { get; set; } = "SELECT SCOPE_IDENTITY()";

        public SqlserverCEAdapter()
            : base(SqlConsts.LeftTokens[0], SqlConsts.RightTokens[0], SqlConsts.ParamPrefixs[0])
        {
             
        }

        public override string Field(string filedName)
        {
            return $"{_leftToken}{filedName}{_rightToken}";
        }

        public override string Field(string tableName, string fieldName)
        {
            return $"{Table(tableName, "")}.{Field(fieldName)}"; //fieldName;
        }

        public override string Table(string tableName, string schema)
        {
            var tmpTablename = tableName;
            if (tableName.StartsWith(_leftToken) && tableName.EndsWith(_rightToken))
            {
                tmpTablename = tableName;
            }
            else
            {
                tmpTablename= $"{_leftToken}{tableName}{_rightToken}";
            }
 
            if (!string.IsNullOrEmpty(schema))
            {
                return _leftToken + schema + _rightToken + "." + tmpTablename;
            }
            return tmpTablename;
        }

        public override string QueryPage(SqlEntity entity)
        {
            var pageSize = entity.PageSize;
            var pageNumber = entity.PageNumber - 1;
            if (pageNumber < 1)
            {
                return string.Format("SELECT TOP({4}) {0} FROM {1} {2} {3}", entity.Selection, entity.TableName, entity.Conditions, entity.OrderBy, pageSize);
            }
            
            var innerQuery =
                $"SELECT {entity.Selection},ROW_NUMBER() OVER ({entity.OrderBy}) AS RN FROM {entity.TableName} {entity.Conditions}";
            return
                $"SELECT TOP {pageSize} * FROM ({innerQuery}) InnerQuery WHERE RN > {pageSize * pageNumber} ORDER BY RN";
        }

        public override string TableExistSql(string tableName, string tableSchema)
        {
            if (string.IsNullOrEmpty(tableSchema))
            {
                tableSchema = "dbo";
            }
            return base.TableExistSql(tableName, tableSchema);
        }

        protected override string DbTypeGuid(string fieldLength)
        {
            return "uniqueidentifier";
        }
        /// <summary>
        /// DbType.DateTime
        /// A type representing a date and time value.
        /// </summary>
        /// <returns></returns>
        protected override string DbTypeDateTime(string fieldLength)
        {
            return $"DATETIME";
        }

        /// <summary>
        /// DbType.DateTime2
        /// Date and time data. Date value range is from January 1,1 AD through December 31, 9999 AD. Time value range is 00:00:00 through 23:59:59.9999999 with an accuracy of 100 nanoseconds.
        /// </summary>
        /// <returns></returns>
        protected virtual string DbTypeDateTime2(string fieldLength)
        {
            return $"DATETIME";
        }
    }
}
