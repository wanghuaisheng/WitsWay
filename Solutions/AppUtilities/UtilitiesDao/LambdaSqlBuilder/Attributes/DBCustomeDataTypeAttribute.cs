using System;

namespace WitsWay.Utilities.Dap.LambdaSqlBuilder.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DbCustomeDataTypeAttribute : Attribute
    {
        public string DataType { get; set; }

        /// <summary>
        /// define custome filed type for column.
        /// </summary>
        /// <param name="dataType">like : varchar(50)</param>
        public DbCustomeDataTypeAttribute(string dataType)
        {
            DataType = dataType;
        }
    }
}
