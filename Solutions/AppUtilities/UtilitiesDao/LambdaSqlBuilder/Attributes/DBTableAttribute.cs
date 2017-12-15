using System;

namespace WitsWay.Utilities.Dap.LambdaSqlBuilder.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class DbTableAttribute : Attribute
    {
        public DbTableAttribute(string name,string schema=null)
        {
            Name = name;
            Schema = schema;
        }

        public string Name { get; set; }

        public string Schema { get; set; }

    }
}
