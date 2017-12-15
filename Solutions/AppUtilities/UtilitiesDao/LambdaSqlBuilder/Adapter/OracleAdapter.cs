using System;
using WitsWay.Utilities.Dap.LambdaSqlBuilder.Entity;

namespace WitsWay.Utilities.Dap.LambdaSqlBuilder.Adapter
{

    sealed class OracleAdapter : AdapterBase
    {
        public new string AutoIncrementDefinition { get; } = string.Empty;


        public new string ParamStringPrefix { get; } = ":";

        public new string PrimaryKeyDefinition { get; } = " Primary Key";


        public OracleAdapter() : base(SqlConsts.LeftTokens[2], SqlConsts.RightTokens[2], SqlConsts.ParamPrefixs[1])
        {

        }

        public override string QueryPage(SqlEntity entity)
        {
            var pageSize = entity.PageSize;
            var begin = (entity.PageNumber - 1) * pageSize;
            var end = entity.PageNumber * pageSize;
            return string.Format(@"SELECT * FROM (SELECT A.*, ROWNUM RN FROM (SELECT {0} FROM {1} {2} {3}) A WHERE ROWNUM <= {5})WHERE RN >{4}",
                entity.Selection, entity.TableName, entity.Conditions, entity.OrderBy, begin, end);
        }

        public override string TableExistSql(string tableName, string tableSchema)
        {
            tableName = RemoveSchema(tableName);

            var sql = $"SELECT count(*) FROM USER_TABLES WHERE TABLE_NAME = '{tableName}'";

            if (!string.IsNullOrEmpty(tableSchema))
            {
                sql += $" AND OWNER = '{tableSchema}'";
            }


            return sql;
        }

        private string RemoveSchema(string tableName)
        {
            var indexOfPeriod = tableName.IndexOf(".", StringComparison.Ordinal);
            return indexOfPeriod < 0 ? tableName : tableName.Substring(indexOfPeriod + 1);
        }

        protected override string DbTypeBoolean(string fieldLength)
        {
            return "BOOL";
        }

        protected override string DbTypeString(string fieldLength)
        {

            if (int.Parse(fieldLength) > 8000)
            {
                return "BLOB";
            }
            return $"CHARACTER VARYING({fieldLength})";
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
                fieldLength = length.ToString();
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
    }
}
