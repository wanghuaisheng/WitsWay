using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace Utilities.Dap.Tests.Common
{
    public class OraBase
    {
        protected string Connstr = "data source=192.168.1.21;Database=test;Password=;User ID=root;";

        public OraBase()
        {


            // base(connstr);
        }

        public OraBase(string connstr)
        {

            Connstr = connstr;
        }

        public IDbConnection GetConnection()
        {
            var conn = new OracleConnection(Connstr);
            conn.Open();
            return conn;
        }


        public IDbConnection GetConnection(string strConn)
        {
            var conn = new OracleConnection(strConn);
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
