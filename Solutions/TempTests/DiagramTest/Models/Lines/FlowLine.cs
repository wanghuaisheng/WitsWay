namespace WitsWay.TempTests.DiagramTest.Models.Lines
{

    /// <summary>
    /// 流程连接线
    /// </summary>
    public class FlowLine
    {
        /// <summary>
        /// 连接线键
        /// </summary>
        public string LineKey { get; set; }
        /// <summary>
        /// 节点类型
        /// </summary>
        public FlowLineKinds LineKind { get; set; }
        /// <summary>
        /// 流程键
        /// </summary>
        public string FlowKey{ get; set; }
        /// <summary>
        /// 连接线编码
        /// </summary>
        public string LineCode { get; set; }
        /// <summary>
        /// 连接线名称
        /// </summary>
        public string  LineName { get; set; }
        /// <summary>
        /// 连接线概要
        /// </summary>
        public string  LineSummary { get; set; }
        /// <summary>
        /// 连接线备注
        /// </summary>
        public string LineRemark { get; set; }
        /// <summary>
        /// 前一节点键
        /// </summary>
        public string PrevNodeKey { get; set; }
        /// <summary>
        /// 下一节点键
        /// </summary>
        public string  NextNodeKey { get; set; }
        
        /// <summary>
        /// 节点状态
        /// </summary>
        public FlowLineStates State { get; set; }

    }



}
