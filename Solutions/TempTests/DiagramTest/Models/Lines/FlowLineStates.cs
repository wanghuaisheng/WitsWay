namespace WitsWay.TempTests.DiagramTest.Models.Lines
{
    /// <summary>
    /// 流程状态
    /// </summary>
    public enum FlowLineStates
    {
        /// <summary>
        /// 未到达
        /// </summary>
        NotArrive,
        /// <summary>
        /// 条件不匹配
        /// </summary>
        NotMatch,
        /// <summary>
        /// 被忽略
        /// <para>有多条处理线时，会出现被忽略的流程线</para>
        /// </summary>
        Ignored,
        /// <summary>
        /// 已通过
        /// </summary>
        Passed
        
    }
}
