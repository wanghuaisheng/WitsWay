namespace WitsWay.TempTests.DiagramTest.Models.Lines
{
    /// <summary>
    /// 连接线类型
    /// </summary>
    public enum FlowLineKinds
    {
        /// <summary>
        /// 条件分支
        /// </summary>
        ConditionBranch,
        /// <summary>
        /// 直接递转
        /// </summary>
        DirectionNext,
        /// <summary>
        /// 回退前节点
        /// </summary>
        BackwardPrev
    }
}
