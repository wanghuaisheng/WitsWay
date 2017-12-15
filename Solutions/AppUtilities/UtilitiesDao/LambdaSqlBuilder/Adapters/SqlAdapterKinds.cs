namespace WitsWay.Utilities.Dap.LambdaSqlBuilder.Adapters
{
    /// <summary>
    /// Sql适配器类型
    /// </summary>
    public enum SqlAdapterKinds
    {
        /// <summary>
        /// Note: the sqlserver adapter only support sqlserve 2005 or higher.
        /// </summary>
        SqlServer = 1,
        /// <summary>
        /// Note: the Sqlite adapter only support Sqlight 3 or higher.
        /// </summary>
        Sqlite = 2,
        Oracle = 3,
        MySql = 4,
        Postgres = 5,
        SqlAnyWhere=6,

        SqlServerCE=7
    }
}
