namespace WitsWay.TempTests.DiagramTest.Models.Items
{
    /// <summary>
    /// 流程状态
    /// </summary>
    public enum FlowItemStates
    {
        /// <summary>
        /// 未开始
        /// <para>每个流程都有且只有一个开始节点</para>
        /// </summary>
        NotStart,
        /// <summary>
        /// 等待处理
        /// <para>可能同时有多个等待处理的节点，多个同时处理节点任意处理或多个处理后 进入下一处理流程线</para>
        /// </summary>
        WaitHandle,
        /// <summary>
        /// 被忽略
        /// <para>有多条处理线时，会出现被忽略的执行节点</para>
        /// </summary>
        Ignored,
        /// <summary>
        /// 完成
        /// <para>每个流程都有且只有一个成功节点</para>
        /// </summary>
        Finished,
        
    }
}
