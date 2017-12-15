using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace Utilities.Dap.Tests.Common
{
    public class MsSqlCEBase
    {
        protected string Connstr = "data source=.\\test.sdf;Max Database Size=4090;Password=zeroplus2013;";

        public MsSqlCEBase()
        {


            // base(connstr);
        }

        public MsSqlCEBase(string connstr)
        {

            Connstr = connstr;
        }

        public IDbConnection GetConnection()
        {
            var conn = new SQLiteConnection(Connstr);
            conn.Open();
            return conn;
        }


        public IDbConnection GetConnection(string strConn)
        {
            var conn = new SqlConnection(strConn);
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
