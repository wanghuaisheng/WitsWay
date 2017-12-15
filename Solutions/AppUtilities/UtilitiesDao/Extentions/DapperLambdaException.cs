using System;
using System.Collections.Generic;

namespace WitsWay.Utilities.Dap.Extentions
{
    public class DapperLambdaException : Exception
    {
        public DapperLambdaException(string message,Exception innerException,string errorSqlString):base(message,innerException)
        {
            SqlString = errorSqlString;
        }
        public string SqlString { get; set; }

        public IDictionary<string,object> Parameters { get; set; }

        public override string StackTrace => InnerException?.StackTrace;
    }
}
