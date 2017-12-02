using SmartSolution.Utilities.Extends;

namespace SmartSolution.Utilities.Mirrors
{
    /// <summary>
    /// 缓存管理器
    /// </summary>
    public static class CacheMirrorExtends
    {
        /// <summary>
        /// 修改则克隆数据
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="data">源数据</param>
        /// <param name="readOnly">返回的数据是否只读</param>
        /// <returns>处理后的数据，readOnly=true则返回源数据，readOnly=false则返回克隆数据</returns>
        public static T EditClone<T>(this T data, bool readOnly) where T : new()
        {
            return readOnly ? data : data.Clone();
        }

    }
}