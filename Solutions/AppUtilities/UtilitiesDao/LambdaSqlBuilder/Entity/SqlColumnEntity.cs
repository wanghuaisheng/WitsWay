namespace WitsWay.Utilities.Dap.LambdaSqlBuilder.Entity
{
    
    public class SqlColumnEntity
    {
        public object Value { get; set; }

        public string AliasName { get; set; }

        public SqlColumnEntity(string name , object value)
        {
            AliasName = name;
            Value = value;
        }
    }
}
