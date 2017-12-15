using System;
using System.Data;
using Npgsql;

namespace Utilities.Dap.Tests.Common
{
    public class NpgsqlBase
    {
        //protected string Connstr = "server=192.168.1.21;User Id=postgres;password=;database=testdb;Encoding=UTF-8;";//"data source=192.168.1.21;Database=testdb;Password=plus123456;User ID=postgres;";

        protected string Connstr = "server=localhost;User Id=postgres;password=ZeroPlus2013;database=testdb;Encoding=UTF-8;";//"data source=192.168.1.21;Database=testdb;Password=plus123456;User ID=postgres;";

        public NpgsqlBase()
        {


            // base(connstr);
        }

        public NpgsqlBase(string connstr)
        {

            Connstr = connstr;
        }

        public IDbConnection GetConnection()
        {
            var conn = new NpgsqlConnection(Connstr);
            conn.Open();
            return conn;
        }


        public IDbConnection GetConnection(string strConn)
        {
            var conn = new NpgsqlConnection(strConn);
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
