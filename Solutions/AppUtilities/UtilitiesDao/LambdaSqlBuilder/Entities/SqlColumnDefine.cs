using System;
using WitsWay.Utilities.Dap.LambdaSqlBuilder.Attributes;

namespace WitsWay.Utilities.Dap.LambdaSqlBuilder.Entities
{
    
    public class SqlColumnDefine
    {
        [Obsolete]
        public object Value { get; set; }

        public Type ValueType { get; set; }

        public string AliasName { get; set; }

        public string Name { get; set; }

        public bool NullAble { get; set; }

        public DbColumnAttribute ColumnAttribute { get; set; }

        public DbKeyAttribute KeyAttribute { get; set; }
        [Obsolete]
        public DbCustomeDataTypeAttribute DataTypeAttribute { get; set; }

        public DbIndexAttribute IndexAttribute { get; set; }

        public DbIgnoreAttribute IgnoreAttribute { get; set; }

        public SqlColumnDefine(string name, string aliasName, object value,Type valueType, bool nullAble, DbColumnAttribute columnAttr, DbKeyAttribute keyAttr, DbCustomeDataTypeAttribute customeDataTypeAttr, DbIgnoreAttribute ignoreAttr=null, DbIndexAttribute indexAttr = null)
        {
            Name = name;
            AliasName = aliasName;
            Value = value;
            ColumnAttribute = columnAttr;
            KeyAttribute = keyAttr;
            DataTypeAttribute = customeDataTypeAttr;
            IgnoreAttribute = ignoreAttr;
            ValueType = valueType;
            NullAble = nullAble;
            IndexAttribute = indexAttr;
        }

        public SqlColumnDefine( DbColumnAttribute columnAttribute, DbKeyAttribute keyAttribute = null, DbIndexAttribute indexAttr = null)
        {
            Name = columnAttribute.Name;
            AliasName = columnAttribute.Name;
            ColumnAttribute = columnAttribute;
            KeyAttribute = keyAttribute;
            IndexAttribute = indexAttr;
        }
    }
}
