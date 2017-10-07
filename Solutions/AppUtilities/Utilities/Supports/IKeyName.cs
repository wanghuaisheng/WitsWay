namespace SmartSolution.Utilities.Supports
{

    /// <summary>
    /// 主键名称支持
    /// <remarks>
    /// 此接口用于实体，对应主键的名称
    /// </remarks>
    /// </summary>
    public interface IKeyName
    {
        /// <summary>
        /// 主键对应的名称
        /// </summary>
        string KeyName { get; }
    }

}
