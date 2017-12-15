using WitsWay.Utilities.Dap.LambdaSqlBuilder.Attributes;

namespace Utilities.Dap.Tests.Entities
{
     
    public class Test2
    {
        [DbKey(true)]
        
        public int Id { get; set; }

        [DbColumn("c_name")]
        public string Name { get; set; }
    }
}
