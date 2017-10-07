using WitsWay.TempTests.DiagramTest.Models.Configs;

namespace WitsWay.TempTests.DiagramTest.Models.Nodes
{

    /// <summary>
    /// 流程节点
    /// </summary>
    public class FlowNode
    {
        /// <summary>
        /// 节点键
        /// </summary>
        public string NodeKey { get; set; }
        /// <summary>
        /// 节点类型
        /// </summary>
        public FlowNodeKinds NodeKind { get; set; }

        public string NodeName { get; set; }

        public string NodeCode { get; set; }
        
        public string NodeSummary { get; set; }

        public  string NodeRemark { get; set; }

        public FlowNodeConfig NodeConfig { get; set; }

        /// <summary>
        /// 流程键
        /// </summary>
        public string FlowKey{ get; set; }
        /// <summary>
        /// 节点状态
        /// </summary>
        public FlowNodeStates Status { get; set; }

    }



}
