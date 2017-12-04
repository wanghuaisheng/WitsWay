using System;
using System.Collections.Generic;

namespace SmartSolution.Utilities.Helpers
{

    /// <summary>
    /// 日期时间辅助类
    /// </summary>
    public class DateTimeHelper
    {

        /// <summary>
        /// 获得Unix时间戳（毫秒）
        /// </summary>
        /// <returns>毫秒</returns>
        public static long GetUnixTimestamp(DateTime time)
        {
            var startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            return (long)(time.ToLocalTime() - startTime).TotalMilliseconds;
        }
        /// <summary>
        /// 获得当前Unix时间戳（毫秒）
        /// </summary>
        /// <returns>毫秒</returns>
        public static long GetNowUnixTimestamp()
        {
            return GetUnixTimestamp(DateTime.Now);
        }
        /// <summary>
        /// 获得当前Unix时间戳（秒）
        /// </summary>
        /// <returns>秒</returns>
        public static long GetNowUnixTimeSeconds()
        {
           return GetNowUnixTimeSeconds(DateTime.Now);
        }   
        /// <summary>
        /// 获得当前Unix时间戳（秒）
        /// </summary>
        /// <returns>秒</returns>
        public static long GetNowUnixTimeSeconds(DateTime time)
        {
            var startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            return (long)(time.ToLocalTime() - startTime).TotalSeconds;
        }

    }
}
