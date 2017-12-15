using System.Linq.Expressions;

namespace WitsWay.Utilities.Dap.LambdaSqlBuilder.Resolver.ExpressionTree
{
    class SingleOperationNode : Node
    {
        public ExpressionType Operator { get; set; }
        public Node Child { get; set; }
    }
}
