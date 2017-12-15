using WitsWay.Utilities.Dap.LambdaSqlBuilder.Entities;

namespace WitsWay.Utilities.Dap.LambdaSqlBuilder.Adapters
{
    
    class PostgresAdapter : AdapterBase
    {
        public override string AutoIncrementDefinition { get; } = "serial";
 
        public override string ParamStringPrefix { get; } = ":";

        public override string PrimaryKeyDefinition { get; } = " Primary Key";
        public override string SelectIdentitySql { get; set; } = "RETURNING";

        public PostgresAdapter()
            : base(SqlConsts.LeftTokens[2], SqlConsts.RightTokens[2], SqlConsts.ParamPrefixs[0])
        {

        }

        public override string QueryPage(SqlEntity entity)
        {
            var pageSize = entity.PageSize;
            var limit = pageSize * (entity.PageNumber - 1);

            return
                $"SELECT {entity.Selection} FROM {entity.TableName} {entity.Conditions} {entity.OrderBy} LIMIT {pageSize} offset {limit}";
        }
        public override string Field(string filedName)
        {
            return $"{_leftToken}{filedName}{_rightToken}";
        }

        public override string Field(string tableName, string fieldName)
        {
            return $"{Table(tableName, "")}.{Field(fieldName)}"; //fieldName;
        }

        public override string Table(string tableName,string schema)
        {
            var tbname = $"{""}{tableName}{""}";
            if (!string.IsNullOrEmpty(schema))
            {
                return _leftToken + schema + _rightToken + "."+tbname;
            }
            return tbname;
        }

        public override string LikeStagement()
        {
            return "~*";
        }

        public override string LikeChars()
        {
            return ".*";
        }

        public override string CreateTablePrefix
        {
            get { return "CREATE TABLE if not EXISTS "; }
        }

        /// <summary>
        /// 同样,获取最后一条插入数据的id,在postgresql中也有点特殊.
        /// </summary>
        /// <param name="incrementColumnName"></param>
        /// <returns></returns>
        public override string GetIdentitySql(string incrementColumnName)
        {
            if (!string.IsNullOrEmpty(incrementColumnName))
            {
                return SelectIdentitySql + " " + incrementColumnName + ";";
            }

            return string.Empty;
        }

        public override string FormatColumnDefineSql(string columName, string dataTypestr, string nullstr, string primaryStr, string incrementStr)
        {
            //postgres 的自增字段比较特殊,是用一个特定的数据类型来标识的.
            if (!string.IsNullOrEmpty(incrementStr))
            {
                dataTypestr = incrementStr;
            }

            return $" {columName} {dataTypestr} {nullstr} {primaryStr},";
        }

        public override string TableExistSql(string tableName, string tableSchema)
        {
            if (string.IsNullOrEmpty(tableSchema))
            {
                tableSchema = "public";
            }
            //var sql = "SELECT COUNT(*) FROM pg_class WHERE relname = {0}" //this is return all of schemas table count.
            var sql =
                $"SELECT COUNT(*) FROM pg_class JOIN pg_catalog.pg_namespace n ON n.oid = pg_class.relnamespace WHERE relname = '{tableName}' AND nspname = '{tableSchema}'";
            return sql;
        }


        protected override string DbTypeDateTime(string fieldLength)
        {
            if (string.IsNullOrEmpty(fieldLength))
            {
                fieldLength = "3";
            }
            else
            {
                var length = 3;

                if (!int.TryParse(fieldLength, out length))
                {
                    length = 3;
                }
                if (length > 6)
                {
                    length = 6;
                }
                fieldLength=length.ToString();
            }
            return $"TIMESTAMP({fieldLength})";
        }

        protected override string DbTypeDateTime2(string fieldLength)
        {
            if (string.IsNullOrEmpty(fieldLength))
            {
                fieldLength = "6";
            }
            else
            {
                var length = 6;

                if (!int.TryParse(fieldLength, out length))
                {
                    length = 6;
                }
                if (length > 6)
                {
                    length = 6;
                }
                fieldLength = length.ToString();
            }
            return $"TIMESTAMP({fieldLength})";
        }

        protected override string DbTypeTime(string fieldLength)
        {
            if (string.IsNullOrEmpty(fieldLength))
            {
                fieldLength = "3";
            }
            else
            {
                var length = 3;

                if (!int.TryParse(fieldLength, out length))
                {
                    length = 3;
                }
                if (length > 6)
                {
                    length = 6;
                }
                fieldLength = length.ToString();
            }
            return $"TIME({fieldLength})";
        }

        protected override string DbTypeBinary(string fieldLength)
        {
            return "BYTEA";//bytea
        }

        protected override string DbTypeDecimal(string fieldLength)
        {
            return DbTypeVarNumeric(fieldLength);
        }

        protected override string DbTypeGuid(string fieldLength)
        {
            return "uuid";
        }

        protected override string DbTypeBoolean(string fieldLength)
        {
            return "boolean";
        }
    }
}
