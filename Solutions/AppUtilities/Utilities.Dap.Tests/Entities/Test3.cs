using WitsWay.Utilities.Dap.LambdaSqlBuilder.Attributes;

namespace Utilities.Dap.Tests.Entities
{
    [DbTable("o_test3")]
    public class Test3
    {
        [DbKey(true)]
        [DbColumn("id")]
        public int Id { get; set; }

        [DbColumn("v_name")]
        public string VName { get; set; }
    }
}
