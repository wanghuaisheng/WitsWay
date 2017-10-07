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
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace WitsWay.Utilities.Helpers
{
    /// <summary>
    /// Json格式对象反序列化帮助类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class JsonDeserializeHelper<T>
    {
        /// <summary>
        /// 转换为实体
        /// </summary>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        public static T Deserialize(string jsonString)
        {
            var tempString = jsonString.Replace("*", "+").Replace("!", "/").Replace("~", "=");
            var gb2312Bytes = Convert.FromBase64String(tempString);

            var gb2312 = Encoding.GetEncoding("GB2312");

            var utf8 = Encoding.UTF8;
            var utf8Bytes = Encoding.Convert(gb2312, utf8, gb2312Bytes);

            tempString = utf8.GetString(utf8Bytes);

            var obj = JsonConvert.DeserializeObject<T>(tempString);
            
            return obj;

        }
        /// <summary>
        /// 转换为实体
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string Serialize(T obj)
        {
            return JsonConvert.SerializeObject(obj);
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string Serialize(IList<T> obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
