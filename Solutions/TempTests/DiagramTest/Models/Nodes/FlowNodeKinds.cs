namespace WitsWay.TempTests.DiagramTest.Models.Nodes
{
    /// <summary>
    /// 流程节点类型
    /// </summary>
    public enum FlowNodeKinds
    {
        /// <summary>
        /// 开始节点
        /// <para>每个流程都有且只有一个开始节点</para>
        /// </summary>
        StartNode,
        /// <summary>
        /// 终止节点
        /// <para>每个流程可以有0个、1个或多个终止节点</para>
        /// </summary>
        AbortNode,
        /// <summary>
        /// 成功节点
        /// <para>每个流程都有且只有一个成功节点</para>
        /// </summary>
        SuccessNode,
        
    }
}
