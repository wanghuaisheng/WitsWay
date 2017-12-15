namespace WitsWay.Utilities.Dap.LambdaSqlBuilder
{
    /// <summary>
    /// 静态常量
    /// </summary>
    internal class SqlConsts
    {
        public static string[] LeftTokens = { "[", "`", "\"", "" };
        public static string[] RightTokens = { "]", "`", "\"", "" };
        public static string[] ParamPrefixs = { "@", ":", "?", "$" };

        public const string QuerySqlFormatString = @"SELECT {0} FROM {1} {2} {3} {4} {5}";

        public const string QuerySubSqlFormatString = @"SELECT {0} FROM {1} {2} {3} {4} {5}";

        public const string InsertSqlFormatString = @"INSERT INTO {0} ({1}) VALUES({2})";

        public const string UpdateSqlFormatString = @"UPDATE {0} SET {1} {2}";

        public const string DeleteSqlFormatString = @"DELETE FROM {0} {1}";

        public const string SqlserverAutoKeySqlString = "SELECT ISNULL(SCOPE_IDENTITY(),0) AS AutoID";

        //private const string SqliteAutoKeySQLString = "SELECT last_insert_rowid() AS AutoID;";

        public static string CreateTableSqlFormatString = @"CREATE TABLE";
    }
}
