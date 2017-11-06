namespace WitsWay.TempTests.WorkflowTest.Entities
{

    /// <summary>
    /// 工作流信息
    /// </summary>
    public class WorkflowInfo
    {
        /// <summary>
        /// 工作流Id
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 表单Id
        /// </summary>
        public string FormId { get; set; }
        /// <summary>
        /// 数据源Id
        /// </summary>
        public string DataId { get; set; }
        /// <summary>
        /// 工作流类型
        /// </summary>
        public int WorkflowKind { get; set; }
        
        /// <summary>
        /// 创建者
        /// </summary>
        public string Creator { get; set; }
        
        /// <summary>
        /// 操作人
        /// </summary>
        public string Operators { get; set; }
        /// <summary>
        /// 发起人
        /// </summary>
        public string Initiators { get; set; }

        /// <summary>
        /// 流程节点
        /// </summary>
        public string FlowNodes { get; set; }



    }
}
