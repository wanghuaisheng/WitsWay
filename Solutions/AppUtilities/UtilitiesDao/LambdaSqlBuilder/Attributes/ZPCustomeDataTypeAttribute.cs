using System;

namespace Dapper.LambdaExtension.LambdaSqlBuilder.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ZPCustomeDataTypeAttribute : Attribute
    {
        public string DataType { get; set; }

        /// <summary>
        /// define custome filed type for column.
        /// </summary>
        /// <param name="dataType">like : varchar(50)</param>
        public ZPCustomeDataTypeAttribute(string dataType)
        {
            DataType = dataType;
        }
    }
}
