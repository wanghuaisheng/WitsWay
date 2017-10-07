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
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using WitsWay.Utilities.Guards;

namespace WitsWay.Utilities.Helpers
{
    /// <summary>
    /// XML序列化辅助类
    /// </summary>
    public class SerilizeHelper
    {
        /// <summary>
        /// 转换为实体
        /// </summary>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        public static T DeserilizeJson<T>(string jsonString)
        {
            if (string.IsNullOrEmpty(jsonString)) 
                return default(T);

            return JsonConvert.DeserializeObject<T>(jsonString);
        }

        /// <summary>
        /// 转换为实体
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string SerilizeToJson<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string SerilizeToJson<T>(IList<T> obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        /// <summary>
        /// 序列化为内存流MemoryStream
        /// </summary>
        /// <param name="objectToSerilize">要序列化的对象实例</param>
        /// <returns>内存流MemoryStream</returns>
        public static string SerilizeToXML<T>(T objectToSerilize)
        {
            return SerilizeToXML(objectToSerilize, Encoding.UTF8);
        }

        /// <summary>
        /// 序列化为内存流MemoryStream
        /// </summary>
        /// <param name="objectToSerilize">要序列化的对象实例</param>
        /// <param name="encoding">编码</param>
        /// <returns>内存流MemoryStream</returns>
        public static string SerilizeToXML<T>(T objectToSerilize, Encoding encoding)
        {
            ArgumentGuard.ArgumentNotNull("objectToSerilize", objectToSerilize);
            ArgumentGuard.ArgumentNotNull("encoding", encoding);

            var mySerializer = new XmlSerializer(objectToSerilize.GetType());

            var output = new MemoryStream();
            var x = new XmlTextWriter(output, encoding);

            mySerializer.Serialize(x, objectToSerilize);
            var returnString = StreamToString(output, encoding);
            return returnString;
        }

        /// <summary>
        /// MemoryStream反序列化为对象
        /// </summary>
        /// <param name="input">输入流</param>
        /// <returns>对象实例</returns>
        public static T DeserilizeXML<T>(string input)
        {
            return DeserilizeXML<T>(input, Encoding.UTF8);
        }

        /// <summary>
        /// MemoryStream反序列化为对象
        /// </summary>
        /// <param name="encoding">编码</param>
        /// <param name="input">输入流</param>
        /// <returns>对象实例</returns>
        public static T DeserilizeXML<T>(string input, Encoding encoding)
        {
            if (string.IsNullOrEmpty(input))
                return default(T);
            var mySerializer = new XmlSerializer(typeof(T));
            var ms = StringToStream(input, encoding);
            ms.Position = 0;
            var data = (T)mySerializer.Deserialize(ms);
            ms.Close();
            return data;
        }

        /// <summary>
        /// 序列化到XML文件
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="objectToSerilize">要序列化的对象实例</param>
        /// <param name="fileName">文件名</param>
        public static void SerilizeToFile<T>(T objectToSerilize, string fileName)
        {
            try
            {
                var mySerializer = new XmlSerializer(typeof(T));
                var myWriter = new StreamWriter(fileName);
                mySerializer.Serialize(myWriter, objectToSerilize);
                myWriter.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 反序列化文件
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="fileName">反序列化要读取的文件名</param>
        /// <returns>对象实例</returns>
        public static T DeserilizeFile<T>(string fileName)
        {
            try
            {
                using (var myReader = new StreamReader(fileName))
                {
                    var mySerializer = new XmlSerializer(typeof(T));
                    return (T)mySerializer.Deserialize(myReader);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// BinaryFormatter序列化
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="objectToSerilize">要序列化的对象实例</param>
        /// <returns>MemoryStream对象</returns>
        public static string SerilizeToStreamBinary<T>(T objectToSerilize)
        {
            return SerilizeToStreamBinary(objectToSerilize, Encoding.Default);
        }
        /// <summary>
        /// BinaryFormatter序列化
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="objectToSerilize">要序列化的对象实例</param>
        /// <param name="encoding">编码</param>
        /// <returns>MemoryStream对象</returns>
        public static string SerilizeToStreamBinary<T>(T objectToSerilize, Encoding encoding)
        {

            try
            {
                var output = new MemoryStream();
                var binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(output, objectToSerilize);
                output.Position = 0;
                return StreamToString(output, encoding);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 序列化为byte数组
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="objectToSerilize">要序列化的对象实例</param>
        /// <returns>序列化后的byte数组</returns>
        public static byte[] SerilizeToBytes<T>(T objectToSerilize)
        {

            try
            {
                var output = new MemoryStream();
                var binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(output, objectToSerilize);
                output.Position = 0;
                return output.ToArray();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <returns></returns>
        public static T DeserilizeFromBytes<T>(byte[] input)
        {
            try
            {
                var binaryFormatter = new BinaryFormatter();

                var ms = new MemoryStream(input);
                ms.Position = 0;
                var result = (T)binaryFormatter.Deserialize(ms);
                ms.Close();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// BinaryFormatter反序列化
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="input">用于反序列化的MemoryStream流</param>
        /// <returns>对象实例</returns>
        public static T DeserilizeStreamBinary<T>(string input)
        {
            return DeserilizeStreamBinary<T>(input, Encoding.Default);
        }

        /// <summary>
        /// BinaryFormatter反序列化
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="encoding">编码</param>
        /// <param name="input">用于反序列化的MemoryStream流</param>
        /// <returns>对象实例</returns>
        public static T DeserilizeStreamBinary<T>(string input, Encoding encoding)
        {
            try
            {
                var binaryFormatter = new BinaryFormatter();
                var ms = StringToStream(input, encoding);
                ms.Position = 0;
                var result = (T)binaryFormatter.Deserialize(ms);
                ms.Close();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// MemoryStream转换为String
        /// </summary>
        /// <param name="ms">需要转换的MemoryStream</param>
        /// <param name="encoding">编码</param>
        /// <returns>转换后的String</returns>
        public static string StreamToString(MemoryStream ms, Encoding encoding)
        {
            if (ms == null) return "";
            var bytelist = ms.ToArray();
            var returnString = (encoding ?? Encoding.Default).GetString(bytelist);
            return returnString;
        }

        /// <summary>
        /// String转换为Stream
        /// </summary>
        /// <param name="s">要转换的String</param>
        /// <param name="encoding">编码</param>
        /// <returns>转换后的MemoryStream</returns>
        public static MemoryStream StringToStream(string s, Encoding encoding)
        {
            if (string.IsNullOrEmpty(s)) return null;
            var bytelist = (encoding ?? Encoding.Default).GetBytes(s);
            var ms = new MemoryStream(bytelist);
            return ms;
        }
    }
}
