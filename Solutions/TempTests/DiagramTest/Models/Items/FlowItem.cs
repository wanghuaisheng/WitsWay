using System.Collections.Generic;
using WitsWay.TempTests.DiagramTest.Models.Configs;
using WitsWay.TempTests.DiagramTest.Models.Lines;
using WitsWay.TempTests.DiagramTest.Models.Nodes;

namespace WitsWay.TempTests.DiagramTest.Models.Items
{

    /// <summary>
    /// 一个流程
    /// </summary>
    public class FlowItem
    {
        /// <summary>
        /// 节点键
        /// </summary>
        public string FlowKey { get; set; }
        /// <summary>
        /// 流程类型
        /// </summary>
        public FlowItemKinds FlowKind { get; set; }
        /// <summary>
        /// 流程编码
        /// </summary>
        public string FlowCode { get; set; }
        /// <summary>
        /// 流程名称
        /// </summary>
        public  string FlowName { get; set; }
        /// <summary>
        /// 流程概要
        /// </summary>
        public string FlowSummary { get; set; }
        /// <summary>
        /// 流程备注
        /// </summary>
        public string FlowRemark { get; set; }
        /// <summary>
        /// 最后完成处理的节点
        /// </summary>
        public string LastHandledNodes { get; set; }
        /// <summary>
        /// 等待处理的节点
        /// </summary>
        public string WaitHandleNodes { get; set; }
        /// <summary>
        /// 流程节点
        /// </summary>
        public List<FlowNode> Nodes { get; set; }
        /// <summary>
        /// 连接线
        /// </summary>
        public List<FlowLine> Lines { get; set; } 
        /// <summary>
        /// 流程模板
        /// </summary>
        public byte[] FlowTemplate { get; set; }
        /// <summary>
        /// 流程预览图
        /// </summary>
        public byte[] FlowPreviewImage { get; set; }
        /// <summary>
        /// 流程配置
        /// </summary>
        public FlowItemConfig FlowConfig { get; set; }
        /// <summary>
        /// 节点状态
        /// </summary>
        public FlowItemStates FlowState { get; set; }

    }



}
