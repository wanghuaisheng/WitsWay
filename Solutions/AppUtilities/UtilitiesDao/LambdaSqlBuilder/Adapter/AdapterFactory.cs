using System;

namespace WitsWay.Utilities.Dap.LambdaSqlBuilder.Adapter
{
    public static class AdapterFactory
    {
        public static ISqlAdapter GetAdapterInstance(SqlAdapterKinds adapter)
        {
            switch (adapter)
            {
                case SqlAdapterKinds.SqlServer:
                    return new SqlserverAdapter();
                case SqlAdapterKinds.Sqlite:
                    return new Sqlite3Adapter();
                case SqlAdapterKinds.Oracle:
                    return new OracleAdapter();
                case SqlAdapterKinds.MySql:
                    return new MySqlAdapter();
                case SqlAdapterKinds.Postgres:
                    return new PostgresAdapter();
                case SqlAdapterKinds.SqlAnyWhere:
                    return new SqlAnyWhereAdapter();
                    case SqlAdapterKinds.SqlServerCE:
                        return new SqlserverCEAdapter();
                default:
                    throw new ArgumentException("The specified Sql Adapter was not recognized");
            }
        }
    }
}
