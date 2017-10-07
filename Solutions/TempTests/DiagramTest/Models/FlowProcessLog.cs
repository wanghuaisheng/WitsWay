using WitsWay.TempTests.DiagramTest.Models.Nodes;

namespace WitsWay.TempTests.DiagramTest.Models
{

    /// <summary>
    /// 流程处理日志
    /// <remarks>
    /// 记录每次流程变更信息
    /// </remarks>
    /// </summary>
    public class FlowProcessLog
    {

        /// <summary>
        /// 日志键
        /// </summary>
        public string LogKey { get; set; }
        /// <summary>
        /// 节点类型
        /// </summary>
        public FlowNodeKinds NodeKind { get; set; }
        
        /// <summary>
        /// 流程键
        /// </summary>
        public string FlowKey{ get; set; }

        public FlowNodeStates Status { get; set; }

    }



}
