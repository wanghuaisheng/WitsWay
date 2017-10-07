using System;

namespace WitsWay.Utilities.Entitys
{
    /// <summary>
    /// 时间戳数据
    /// </summary>
    [Serializable]
    public class TimestampData<T>
    {

        /// <summary>
        /// 数据
        /// </summary>
        public T Data { get; set; }
        /// <summary>
        /// 时间戳
        /// </summary>
        public DateTime Timestamp { get; set; }
    }
}
