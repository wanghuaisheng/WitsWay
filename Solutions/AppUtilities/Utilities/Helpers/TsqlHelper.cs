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
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace WitsWay.Utilities.Helpers
{
    /// <summary>
    /// TSQL辅助类
    /// </summary>
    public class TsqlHelper
    {
        private const string EmptyRootNode = "<Root />";
        /// <summary>
        /// 取得数据集合对应的Xml序列化结果
        /// <example>
        /// declare @xmldata XML
        /// set @xmldata=N'XML数据'
        /// SELECT T.c.query('RegionID').value('.[1]', 'int') as id,
        /// T.c.query('RegionName').value('.[1]', 'varchar(50)') as name,
        /// T.c.query('LevelType').value('.[1]', 'int') as company
        /// FROM @xmldata.nodes('/Root/Item') AS T(c)
        /// 
        /// 或者
        /// declare @xml int
        /// EXEC sp_xml_preparedocument @xml OUTPUT, @xmldoc
        /// SELECT *
        /// FROM  OPENXML (@hdoc, '/Root/Item',2)
        /// WITH (ResourceID int,
        /// ContractNo nvarchar(50),
        /// CurrentFlowID int,
        ///	CreateTime datetimeoffset,
        ///	ContractMoney decimal(10,4))
        ///	
        /// exec sp_xml_removedocument @xml
        /// </example>
        /// <para>xml的编码格式均为UTF-16</para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="datas"></param>
        /// <returns></returns>
        public static string SerilizeListToXml<T>(List<T> datas)
        {
            if (datas != null && datas.Count > 0)
            {
                if (datas[0] is int||datas[0] is double||datas[0] is float||datas[0] is decimal||datas[0] is bool)
                {
                    var infos = datas.Select(data => new OnlyId<T> { Id = data }).ToList();
                    return SerilizeListToXml(infos);
                }
                if (datas[0] is string)
                {
                    var infos = datas.Select(data => new OnlyId<T> { Id = data }).ToList();
                    return SerilizeListToXml(infos);
                }
                return SerilizeObjectListToXml(datas);
            }
            return EmptyRootNode;
        }

        private static string SerilizeObjectListToXml<T>(List<T> datas)
        {
            if (datas == null || datas.Count <= 0) return EmptyRootNode;
            var wrapper = new SerilizeInfo<T> {Infos = datas};
            var result = SerilizeHelper.SerilizeToXML(wrapper, Encoding.Unicode);
            //正则替换
            result = Regex.Replace(result, @"<[^>]+ xsi:nil=[^/>]*/>", "");
            var startIndex = result.IndexOf("<Root>", StringComparison.Ordinal);
            var endIndex = result.LastIndexOf("</Root>", StringComparison.Ordinal);
            if (startIndex >= 0 && endIndex >= 0 && endIndex > startIndex)
            {
                return result.Substring(startIndex, endIndex - startIndex + "</Root>".Length);
            }
            return EmptyRootNode;
        }

        /// <summary>
        /// 序列化对象到XML
        /// </summary>
        /// <typeparam name="T">序列化对象类型</typeparam>
        /// <param name="obj">要序列化得对象</param>
        /// <returns>序列化结果</returns>
        public static string SerilizeObjectToXml<T>(T obj)
        {
            return obj != null ? SerilizeHelper.SerilizeToXML(obj, Encoding.Unicode) : EmptyRootNode;
        }

        /// <summary>
        /// 解析TSQL语句参数
        /// </summary>
        /// <param name="tsqlString">TSQL语句字符串</param>
        /// <returns>返回参数列表</returns>
        public static List<string> AnalyseTsqlParameters(string tsqlString)
        {
            var result = new List<string>();
            //Regex paramReg = new Regex(@"@\w*");
            //Sql中包括@@rowcount之类的变量的情况，不应该算作参数
            var paramReg = new Regex(@"[^@@](?<p>@\w+)");
            var matches = paramReg.Matches(string.Concat(tsqlString, " "));
            foreach (Match m in matches)
            {
                var willAddItem = m.Groups["p"].Value;
                var isExist = false;
                foreach (var item in result)
                {
                    if (string.Equals(willAddItem.ToLower(), item.ToLower()))
                    {
                        isExist = true;
                        break;
                    }
                }
                if (isExist) { continue; }

                result.Add(willAddItem);
            }
            return result;

        }
        /// <summary>
        /// SQLType转换为对应的DbType
        /// </summary>
        /// <param name="sqlTypeWithPrecision">SQLType字符（包含长度信息）</param>
        /// <returns>返回DbType枚举</returns>
        public static DbType SqlTypeStringToDbType(string sqlTypeWithPrecision)
        {
            var dbType = DbType.Object;//默认为Object
            //去掉长度信息
            var startIndex = sqlTypeWithPrecision.IndexOf("(", StringComparison.Ordinal);
            var sqlTypeString = startIndex != -1 ? sqlTypeWithPrecision.Remove(startIndex) : sqlTypeWithPrecision;
            switch (sqlTypeString)
            {
                case "int":
                    dbType = DbType.Int32;
                    break;
                case "varchar":
                    dbType = DbType.String;
                    break;
                case "bit":
                    dbType = DbType.Boolean;
                    break;
                case "datetime":
                    dbType = DbType.DateTime;
                    break;
                case "decimal":
                    dbType = DbType.Decimal;
                    break;
                case "float":
                    dbType = DbType.Double;
                    break;
                case "image":
                    dbType = DbType.Binary;
                    break;
                case "money":
                    dbType = DbType.Currency;
                    break;
                case "ntext":
                    dbType = DbType.String;
                    break;
                case "nvarchar":
                    dbType = DbType.String;
                    break;
                case "smalldatetime":
                    dbType = DbType.DateTime;
                    break;
                case "smallint":
                    dbType = DbType.Int16;
                    break;
                case "text":
                    dbType = DbType.String;
                    break;
                case "bigint":
                    dbType = DbType.Int64;
                    break;
                case "binary":
                    dbType = DbType.Binary;
                    break;
                case "char":
                    dbType = DbType.String;
                    break;
                case "nchar":
                    dbType = DbType.String;
                    break;
                case "numeric":
                    dbType = DbType.Decimal;
                    break;
                case "real":
                    dbType = DbType.Double;
                    break;
                case "smallmoney":
                    dbType = DbType.Currency;
                    break;
                case "sql_variant":
                    dbType = DbType.String;
                    break;
                case "timestamp":
                    dbType = DbType.Int32;
                    break;
                case "tinyint":
                    dbType = DbType.Int16;
                    break;
                case "uniqueidentifier":
                    dbType = DbType.Guid;
                    break;
                case "varbinary":
                    dbType = DbType.Binary;
                    break;
                case "xml":
                    dbType = DbType.Xml;
                    break;
            }
            return dbType;
        }

        /// <summary>
        /// 序列化使用类
        /// </summary>
        [Serializable]
        [XmlRoot(ElementName = "RootInfo")]
        public class SerilizeInfo<T>
        {
            /// <summary>
            /// Infos
            /// </summary>
            [XmlArray("Root")]
            [XmlArrayItem("Item")]
            public List<T> Infos
            {
                get;
                set;
            }
        }

        /// <summary>
        /// 序列化使用类
        /// </summary>
        [Serializable]
        public class OnlyId<T>
        {
            /// <summary>
            /// ID
            /// </summary>
            public T Id { get; set; }
        }

    }
}
