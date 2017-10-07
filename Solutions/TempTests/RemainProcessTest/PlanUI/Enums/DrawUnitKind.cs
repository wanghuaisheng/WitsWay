namespace WitsWay.TempTests.RemainProcessTest.PlanUI.Enums
{

    /// <summary>
    /// 绘制板件类型
    /// </summary>
    public enum DrawUnitKind
    {
        /// <summary>
        /// 未加工板件
        /// </summary>
        UnitNotProcess,
        /// <summary>
        /// 正在加工板件
        /// </summary>
        UnitProcessing,
        /// <summary>
        /// 已加工板件
        /// </summary>
        UnitProcessed,
        /// <summary>
        /// 余板
        /// </summary>
        RemainUnit,
        /// <summary>
        /// 废板
        /// </summary>
        DropUnit,
        /// <summary>
        /// 未加工锯缝
        /// </summary>
        SawNotProcess,
        /// <summary>
        /// 正在加工锯缝
        /// </summary>
        SawProcessing,
        /// <summary>
        /// 已加工锯缝
        /// </summary>
        SawProcessed
    } ;

}
