using WitsWay.Utilities.Dap.LambdaSqlBuilder.Attributes;

namespace WitsWay.Utilities.Dap.LambdaSqlBuilder.Entities
{
    
    public class SqlTableDefine
    {
        public DbTableAttribute TableAttribute { get; set; }

        public string Name { get; set; }
 

        public SqlTableDefine(DbTableAttribute tableAttr,string name )
        {
            TableAttribute = tableAttr;
            if (tableAttr != null)
            {
                Name = tableAttr.Name;
                if (string.IsNullOrEmpty(tableAttr.Name))
                {
                    Name = name;
                }
            }
            else
            {
                Name = name;
            }
        }

        public SqlTableDefine(DbTableAttribute tableAttr)
        {
            TableAttribute = tableAttr;
        }
    }
}
