#region License(Apache Version 2.0)
/******************************************
 * Copyright ®2017-Now WangHuaiSheng.
 * Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file
 * except in compliance with the License. You may obtain a copy of the License at
 * http://www.apache.org/licenses/LICENSE-2.0
 * Unless required by applicable law or agreed to in writing, software distributed under the
 * License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
 * either express or implied. See the License for the specific language governing permissions
 * and limitations under the License.
 * Detail: https://github.com/WangHuaiSheng/WitsWay/LICENSE
 * ***************************************/
#endregion 
#region ChangeLog
/******************************************
 * 2017-10-7 OutMan Create
 * 
 * ***************************************/
#endregion
using System;

namespace WitsWay.Utilities.Helpers
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
