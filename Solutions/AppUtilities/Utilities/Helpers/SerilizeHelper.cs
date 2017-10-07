/******************************************
 * 2012��5��3�� ������ ���
 * 
 * ***************************************/

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
    /// XML���л�������
    /// </summary>
    public class SerilizeHelper
    {
        /// <summary>
        /// ת��Ϊʵ��
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
        /// ת��Ϊʵ��
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
        /// ���л�Ϊ�ڴ���MemoryStream
        /// </summary>
        /// <param name="objectToSerilize">Ҫ���л��Ķ���ʵ��</param>
        /// <returns>�ڴ���MemoryStream</returns>
        public static string SerilizeToXML<T>(T objectToSerilize)
        {
            return SerilizeToXML(objectToSerilize, Encoding.UTF8);
        }

        /// <summary>
        /// ���л�Ϊ�ڴ���MemoryStream
        /// </summary>
        /// <param name="objectToSerilize">Ҫ���л��Ķ���ʵ��</param>
        /// <param name="encoding">����</param>
        /// <returns>�ڴ���MemoryStream</returns>
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
        /// MemoryStream�����л�Ϊ����
        /// </summary>
        /// <param name="input">������</param>
        /// <returns>����ʵ��</returns>
        public static T DeserilizeXML<T>(string input)
        {
            return DeserilizeXML<T>(input, Encoding.UTF8);
        }

        /// <summary>
        /// MemoryStream�����л�Ϊ����
        /// </summary>
        /// <param name="encoding">����</param>
        /// <param name="input">������</param>
        /// <returns>����ʵ��</returns>
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
        /// ���л���XML�ļ�
        /// </summary>
        /// <typeparam name="T">��������</typeparam>
        /// <param name="objectToSerilize">Ҫ���л��Ķ���ʵ��</param>
        /// <param name="fileName">�ļ���</param>
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
        /// �����л��ļ�
        /// </summary>
        /// <typeparam name="T">��������</typeparam>
        /// <param name="fileName">�����л�Ҫ��ȡ���ļ���</param>
        /// <returns>����ʵ��</returns>
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
        /// BinaryFormatter���л�
        /// </summary>
        /// <typeparam name="T">��������</typeparam>
        /// <param name="objectToSerilize">Ҫ���л��Ķ���ʵ��</param>
        /// <returns>MemoryStream����</returns>
        public static string SerilizeToStreamBinary<T>(T objectToSerilize)
        {
            return SerilizeToStreamBinary(objectToSerilize, Encoding.Default);
        }
        /// <summary>
        /// BinaryFormatter���л�
        /// </summary>
        /// <typeparam name="T">��������</typeparam>
        /// <param name="objectToSerilize">Ҫ���л��Ķ���ʵ��</param>
        /// <param name="encoding">����</param>
        /// <returns>MemoryStream����</returns>
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
        /// ���л�Ϊbyte����
        /// </summary>
        /// <typeparam name="T">��������</typeparam>
        /// <param name="objectToSerilize">Ҫ���л��Ķ���ʵ��</param>
        /// <returns>���л����byte����</returns>
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
        /// BinaryFormatter�����л�
        /// </summary>
        /// <typeparam name="T">��������</typeparam>
        /// <param name="input">���ڷ����л���MemoryStream��</param>
        /// <returns>����ʵ��</returns>
        public static T DeserilizeStreamBinary<T>(string input)
        {
            return DeserilizeStreamBinary<T>(input, Encoding.Default);
        }

        /// <summary>
        /// BinaryFormatter�����л�
        /// </summary>
        /// <typeparam name="T">��������</typeparam>
        /// <param name="encoding">����</param>
        /// <param name="input">���ڷ����л���MemoryStream��</param>
        /// <returns>����ʵ��</returns>
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
        /// MemoryStreamת��ΪString
        /// </summary>
        /// <param name="ms">��Ҫת����MemoryStream</param>
        /// <param name="encoding">����</param>
        /// <returns>ת�����String</returns>
        public static string StreamToString(MemoryStream ms, Encoding encoding)
        {
            if (ms == null) return "";
            var bytelist = ms.ToArray();
            var returnString = (encoding ?? Encoding.Default).GetString(bytelist);
            return returnString;
        }

        /// <summary>
        /// Stringת��ΪStream
        /// </summary>
        /// <param name="s">Ҫת����String</param>
        /// <param name="encoding">����</param>
        /// <returns>ת�����MemoryStream</returns>
        public static MemoryStream StringToStream(string s, Encoding encoding)
        {
            if (string.IsNullOrEmpty(s)) return null;
            var bytelist = (encoding ?? Encoding.Default).GetBytes(s);
            var ms = new MemoryStream(bytelist);
            return ms;
        }
    }
}
