using System;
using System.Data;
using System.Data.SQLite;

namespace Utilities.Dap.Tests.Common
{
    public class SqliteBase
    {
        protected string Connstr = "data source=192.168.1.21;Database=test;Password=;User ID=root;";

        public SqliteBase()
        {
 
            // base(connstr);
        }

        public SqliteBase(string connstr)
        {
            Connstr = connstr;
        }

        public IDbConnection GetConnection()
        {
            var conn = new SQLiteConnection(Connstr); //or  Microsoft.Data.Sqlite.SqliteConnection
            conn.Open();
            return conn;
        }


        public IDbConnection GetConnection(string strConn)
        {
             
            var conn = new SQLiteConnection(strConn);//or  Microsoft.Data.Sqlite.SqliteConnection
            conn.Open();
            return conn;
        }


        public Tuple<bool, string> TestConn(string connstring)
        {
            bool isopen = false;
            string msg = string.Empty;

            try
            {
                var conn = GetConnection(connstring);
                if (conn.State == ConnectionState.Open)
                {
                    isopen = true;
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }


            return new Tuple<bool, string>(isopen, msg);
        }
        public Tuple<bool, string> TestConn()
        {
            bool isopen = false;
            string msg = string.Empty;

            try
            {
                var conn = GetConnection(Connstr);
                if (conn.State == ConnectionState.Open)
                {
                    isopen = true;
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }


            return new Tuple<bool, string>(isopen, msg);
        }
    }
}
