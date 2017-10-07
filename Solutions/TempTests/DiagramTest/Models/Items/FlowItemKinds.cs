namespace WitsWay.TempTests.DiagramTest.Models.Items
{
    /// <summary>
    /// 流程类型
    /// </summary>
    public enum FlowItemKinds
    {
        /// <summary>
        /// 状态流程
        /// <para>只记录和呈现流程状态变更</para>
        /// </summary>
        StateFlow,
        /// <summary>
        /// 表单流程
        /// <para>流程中不断完成表单填写审核</para>
        /// </summary>
        FormFlow,
        /// <summary>
        /// 操作流程
        /// <para>流程中执行很多功能操作，不同流程节点可以实现操作窗体激活</para>
        /// </summary>
        OperationFlow, 
        /// <summary>
        /// 导航流程
        /// <para>操作界面导航</para>
        /// </summary>
        NavigationFlow
        
    }
}
