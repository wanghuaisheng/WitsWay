
using System.Collections.Generic;

namespace WitsWay.Utilities.Compare
{
    /// <summary>
    /// 比较设置
    /// </summary>
    public class CompareSettings
    {
        /// <summary>
        /// 忽略元素
        /// </summary>
        public static List<string> ElementsToIgnore = new List<string>();
        /// <summary>
        /// 忽略标签
        /// </summary>
        public static List<string> AttributesToIgnore = new List<string>();
        /// <summary>
        /// 是否比较静态字段
        /// </summary>
        public static bool CompareStaticFields = true;
        /// <summary>
        /// 是否比较静态属性
        /// </summary>
        public static bool CompareStaticProperties = true;
        /// <summary>
        /// 是否比较私有属性
        /// </summary>
        public static bool ComparePrivateProperties = false;
        /// <summary>
        /// 是否比较私有字段
        /// </summary>
        public static bool ComparePrivateFields = false;
        /// <summary>
        /// 是否比较子对象
        /// </summary>
        public static bool CompareChildren = true;
        /// <summary>
        /// 是否比较只读属性
        /// </summary>
        public static bool CompareReadOnly = true;
        /// <summary>
        /// 是否比较字段
        /// </summary>
        public static bool CompareFields = true;
        /// <summary>
        /// 是否比较属性
        /// </summary>
        public static bool CompareProperties = true;
        /// <summary>
        /// 是否启用缓存
        /// </summary>
        public static bool Caching = true;
        /// <summary>
        /// 是否自动清理缓存
        /// </summary>
        public static bool AutoClearCache = true;
        /// <summary>
        /// 最大允许不同数量
        /// </summary>
        public static int MaxDifferences = 1;
        /// <summary>
        /// 是否忽略集合顺序
        /// </summary>
        public static bool IgnoreCollectionOrder = true;

    }
}
