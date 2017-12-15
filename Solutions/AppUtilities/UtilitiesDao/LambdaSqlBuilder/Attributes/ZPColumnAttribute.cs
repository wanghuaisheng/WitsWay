using System;
using System.Data;

namespace Dapper.LambdaExtension.LambdaSqlBuilder.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ZPColumnAttribute : Attribute
    {
        public ZPColumnAttribute(string name ,bool nullable, string fieldLength = "")
        {
            this.Name = name;
            this.Nullable = nullable;
            this.FieldLength = fieldLength;
        }
        public ZPColumnAttribute(string name, string fieldLength = "")
        {
            this.Name = name;
            this.FieldLength = fieldLength;
        }

        public ZPColumnAttribute(string name, DbType dbType, string fieldLength = "")
        {
            this.Name = name;
            this.FieldLength = fieldLength;
            this.DbType = dbType;
        }

        public ZPColumnAttribute(string name, bool nullable, DbType dbType, string fieldLength = "")
        {
            this.Name = name;
            this.FieldLength = fieldLength;
            this.DbType = dbType;
            this.Nullable = nullable;
        }

        public string Name { get; set; }

        public bool? Nullable { get; set; } = null;

        public string FieldLength { get; set; }

        public DbType? DbType { get; set; }
    }
}
