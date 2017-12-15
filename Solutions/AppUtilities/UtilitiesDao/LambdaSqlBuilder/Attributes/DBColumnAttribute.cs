using System;
using System.Data;

namespace WitsWay.Utilities.Dap.LambdaSqlBuilder.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DbColumnAttribute : Attribute
    {
        public DbColumnAttribute(string name, bool nullable, string fieldLength = "")
        {
            Name = name;
            Nullable = nullable;
            FieldLength = fieldLength;
        }
        public DbColumnAttribute(string name, string fieldLength = "")
        {
            Name = name;
            FieldLength = fieldLength;
        }

        public DbColumnAttribute(string name, DbType dbType, string fieldLength = "")
        {
            Name = name;
            FieldLength = fieldLength;
            DbType = dbType;
        }

        public DbColumnAttribute(string name, bool nullable, DbType dbType, string fieldLength = "")
        {
            Name = name;
            FieldLength = fieldLength;
            DbType = dbType;
            Nullable = nullable;
        }

        public string Name { get; set; }

        public bool? Nullable { get; set; } = null;

        public string FieldLength { get; set; }

        public DbType? DbType { get; set; }
    }
}
