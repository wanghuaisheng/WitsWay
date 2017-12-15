using WitsWay.Utilities.Dap.LambdaSqlBuilder.Attributes;

namespace Utilities.Dap.Tests.Entities
{
    [DbTable("tbn1")]
    public class Tbn
    {
        [DbKey]
        public int id { get; set; }

        public string name { get; set; }

        public string valpsin { get; set; }
    }
}
