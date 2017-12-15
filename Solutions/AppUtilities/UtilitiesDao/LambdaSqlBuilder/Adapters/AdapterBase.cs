using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using WitsWay.Utilities.Dap.LambdaSqlBuilder.Entities;

namespace WitsWay.Utilities.Dap.LambdaSqlBuilder.Adapters
{

    abstract class AdapterBase : ISqlAdapter
    {
        internal string _leftToken;
        internal string _rightToken;
        internal string _prefix;

        //SqlServer express limit
        public virtual string AutoIncrementDefinition { get; } = "IDENTITY(1,1)";
        public virtual string StringColumnDefinition { get; } = "VARCHAR(255)";
        public virtual string IntColumnDefinition { get; } = "INTEGER";
        public virtual string LongColumnDefinition { get; } = "BIGINT";
        public virtual string GuidColumnDefinition { get; } = "GUID";
        public virtual string BoolColumnDefinition { get; } = "BOOL";
        public virtual string RealColumnDefinition { get; } = "DOUBLE";
        public virtual string DecimalColumnDefinition { get; } = "DECIMAL";
        public virtual string BlobColumnDefinition { get; } = "BLOB";
        public virtual string DateTimeColumnDefinition { get; } = "DATETIME";
        public virtual string TimeColumnDefinition { get; } = "DATETIME";

        public virtual string StringLengthNonUnicodeColumnDefinitionFormat { get; } = "VARCHAR({0})";
        public virtual string StringLengthUnicodeColumnDefinitionFormat { get; } = "NVARCHAR({0})";

        public virtual string ParamStringPrefix { get; } = "@";

        public virtual string PrimaryKeyDefinition { get; } = " Primary Key";

        /// <summary>
        /// CREATE UNIQUE INDEX index_name ON table_name (column_name or column_names)
        /// </summary>
        public virtual string CreateIndexFormatter { get; } = "CREATE {0} INDEX {1} ON {2}({3});";

        public virtual string SelectIdentitySql { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="prefix"></param>
        protected AdapterBase(string left, string right, string prefix)
        {
            _leftToken = left;
            _rightToken = right;
            _prefix = prefix;
            InitColumnTypeMap();
        }

        public string Query(SqlEntity entity)
        {
            return string.Format(SqlConsts.QuerySqlFormatString, entity.Selection, entity.TableName, entity.Conditions, entity.Grouping, entity.Having, entity.OrderBy);
        }

        public virtual string QueryPage(SqlEntity entity)
        {
            var pageSize = entity.PageSize;
            if (entity.PageNumber < 1)
            {
                return string.Format("SELECT TOP({4}) {0} FROM {1} {2} {3}", entity.Selection, entity.TableName, entity.Conditions, entity.OrderBy, pageSize);
            }

            var innerQuery =
                $"SELECT {entity.Selection},ROW_NUMBER() OVER ({entity.OrderBy}) AS RN FROM {entity.TableName} {entity.Conditions}";
            return
                $"SELECT TOP {pageSize} * FROM ({innerQuery}) InnerQuery WHERE RN > {pageSize * entity.PageNumber} ORDER BY RN";
        }
        public string Insert(bool key, SqlEntity entity)
        {
            var sql = string.Format(SqlConsts.InsertSqlFormatString, entity.TableName, entity.Selection, entity.Parameter);
            if (key)
            {
                sql = $"{sql};{SqlConsts.SqlserverAutoKeySqlString}";
            }
            return sql;
        }
        public string Update(SqlEntity entity)
        {
            return string.Format(SqlConsts.UpdateSqlFormatString, entity.TableName, entity.Selection, entity.Conditions);
        }
        public string Delete(SqlEntity entity)
        {
            return string.Format(SqlConsts.DeleteSqlFormatString, entity.TableName, entity.Conditions);
        }

        public virtual bool SupportParameter => true;

        public virtual string Table(string tableName, string schema)
        {
            if (tableName.StartsWith(_leftToken) && tableName.EndsWith(_rightToken))
            {
                return tableName;
            }
            return $"{_leftToken}{tableName}{_rightToken}";
        }

        public virtual string Field(string filedName)
        {
            if (filedName.StartsWith(_leftToken) && filedName.EndsWith(_rightToken))
            {
                return filedName;
            }
            return $"{_leftToken}{filedName}{_rightToken}";
        }

        public virtual string Field(string tableName, string fieldName)
        {
            return $"{Table(tableName, "")}.{Field(fieldName)}";
        }

        public virtual string Parameter(string parameterId)
        {
            return $"{_prefix}{parameterId}";
        }

        public virtual string LikeStagement()
        {
            return "LIKE";
        }

        public virtual string LikeChars()
        {
            return "%";
        }

        public virtual string EqualChars()
        {
            return "=";
        }

        public virtual string GetIdentitySql(string incrementColumnName)
        {
            return SelectIdentitySql;
        }

        #region create table or schema


        public virtual string CreateTablePrefix
        {
            get { return "CREATE TABLE "; }
        }


        public virtual string FormatColumnDefineSql(string columName, string dataTypestr, string nullstr, string primaryStr, string incrementStr)
        {
            return $" {columName} {dataTypestr} {nullstr} {primaryStr} {incrementStr},";
        }

        public virtual string CreateTableSql(SqlTableDefine tableDefine, List<SqlColumnDefine> columnDefines)
        {
            var sql = CreateTablePrefix;

            var tableName = tableDefine.Name;

            var tempTableName = tableName;

            var tempSchemaName = string.Empty;

            if (tableDefine.TableAttribute != null)
            {
                if (!string.IsNullOrEmpty(tableDefine.TableAttribute.Name))
                {
                    tempTableName = tableDefine.TableAttribute.Name;// _leftToken + tableDefine.TableAttribute.Name + _rightToken;
                }

                tempSchemaName = tableDefine.TableAttribute.Schema;

                //if (!string.IsNullOrEmpty(tableDefine.TableAttribute.Schema))
                //{
                //    tableName = (_leftToken + tableDefine.TableAttribute.Schema + _rightToken + ".") + tableName;
                //}
                tableName = Table(tempTableName, tableDefine.TableAttribute.Schema);
            }



            sql += tableName;

            sql += " (";

            var indexList = new List<IndexStructure>();

            foreach (var c in columnDefines)
            {
                var tempCname = (c.AliasName ?? c.Name);

                var cname = _leftToken + tempCname + _rightToken;
                // edit by cheery, 2017/2/22 
                // change the datatype method.

                //var datatypestr = "varchar(255)";
                //if (c.DataTypeAttribute != null)
                //{
                //    datatypestr = c.DataTypeAttribute.DataType;
                //}
                //else
                //{
                //    datatypestr = GetColumnDefinition(c.ValueType);
                //}
                var datatypestr = GetColumnDefinition(c);


                var primary = "";
                var increment = "";

                var isprimary = false;
                var isincrement = false;

                if (c.KeyAttribute != null)
                {
                    primary = PrimaryKeyDefinition;
                    isprimary = true;
                    if (c.KeyAttribute.Increment)
                    {
                        increment = AutoIncrementDefinition;
                        isincrement = true;
                    }
                }

                var nullStr = "";
                if (!c.NullAble)
                {
                    nullStr = "not null";
                }

                if (isprimary || isincrement)
                {
                    nullStr = "not null";
                }


                if (c.IndexAttribute != null)
                {
                    if (string.IsNullOrEmpty(c.IndexAttribute.IndexName))
                    {
                        var schemaSuffix = tempSchemaName;
                        if (!string.IsNullOrEmpty(tempSchemaName))
                        {
                            schemaSuffix += "_";
                        }

                        c.IndexAttribute.IndexName = "lidx_" + schemaSuffix + tempTableName + "_" + tempCname;
                    }

                    if (indexList.Exists(p => p.IndexName == c.IndexAttribute.IndexName))
                    {
                        var ind = indexList.FirstOrDefault(v => v.IndexName == c.IndexAttribute.IndexName);
                        ind?.Columns.Add(new IndexColumnStructure() { ColumnName = cname, Asc = c.IndexAttribute.Asc });
                    }
                    else
                    {
                        indexList.Add(new IndexStructure()
                        {
                            IndexName = c.IndexAttribute.IndexName,
                            Unique = c.IndexAttribute.Unique,
                            TableName = tableName,
                            Columns = new List<IndexColumnStructure>() { new IndexColumnStructure() { ColumnName = cname, Asc = c.IndexAttribute.Asc } }
                        });
                    }
                }


                var columnDefStr = FormatColumnDefineSql(cname, datatypestr, nullStr, primary, increment);
                sql += columnDefStr;
            }

            sql = sql.TrimEnd(',');

            sql += " );";

            //process index create sql 

            foreach (var indexItem in indexList)
            {

                var uniqueStr = string.Empty;
                if (indexItem.Unique)
                {
                    uniqueStr = "UNIQUE";
                }

                var columnlist = new List<string>();

                foreach (var column in indexItem.Columns)
                {
                    columnlist.Add(column.ColumnName + " " + (column.Asc ? "ASC" : "DESC"));
                }

                var columnstr = string.Join(",", columnlist);

                var str = string.Format(CreateIndexFormatter, uniqueStr, indexItem.IndexName, indexItem.TableName, columnstr);

                sql += str;
            }

            return sql;
        }

        public virtual string TableExistSql(string tableName, string tableSchema)
        {
            var sql = $"SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = '{tableName}'";
            if (!string.IsNullOrEmpty(tableSchema))
            {
                sql += $" AND TABLE_SCHEMA = '{tableSchema}'";
            }
            return sql;
        }

        public virtual string DropTableSql(string tableName, string tableSchema)
        {
            var tablename = tableName;
            if (!string.IsNullOrEmpty(tableSchema))
            {
                tablename = $"{tableSchema}.{tablename}";
            }

            var sql = $" DROP TABLE {tablename}";

            return sql;
        }

        public virtual string TruncateTableSql(string tableName, string tableSchema)
        {
            var tablename = tableName;
            if (!string.IsNullOrEmpty(tableSchema))
            {
                tablename = $"{tableSchema}.{tablename}";
            }

            var sql = $" TRUNCATE TABLE {tablename}";

            return sql;
        }

        #endregion

        protected DbTypeMap DbTypeMap = new DbTypeMap();

        protected void InitColumnTypeMap()
        {
            DbTypeMap.Set<string>(DbType.String, StringColumnDefinition);
            DbTypeMap.Set<char>(DbType.StringFixedLength, StringColumnDefinition);
            DbTypeMap.Set<char?>(DbType.StringFixedLength, StringColumnDefinition);
            DbTypeMap.Set<char[]>(DbType.String, StringColumnDefinition);
            DbTypeMap.Set<bool>(DbType.Boolean, BoolColumnDefinition);
            DbTypeMap.Set<bool?>(DbType.Boolean, BoolColumnDefinition);
            DbTypeMap.Set<Guid>(DbType.Guid, GuidColumnDefinition);
            DbTypeMap.Set<Guid?>(DbType.Guid, GuidColumnDefinition);
            DbTypeMap.Set<DateTime>(DbType.DateTime, DateTimeColumnDefinition);
            DbTypeMap.Set<DateTime?>(DbType.DateTime, DateTimeColumnDefinition);
            DbTypeMap.Set<TimeSpan>(DbType.Time, TimeColumnDefinition);
            DbTypeMap.Set<TimeSpan?>(DbType.Time, TimeColumnDefinition);
            DbTypeMap.Set<DateTimeOffset>(DbType.Time, TimeColumnDefinition);
            DbTypeMap.Set<DateTimeOffset?>(DbType.Time, TimeColumnDefinition);

            DbTypeMap.Set<byte>(DbType.Byte, IntColumnDefinition);
            DbTypeMap.Set<byte?>(DbType.Byte, IntColumnDefinition);
            DbTypeMap.Set<sbyte>(DbType.SByte, IntColumnDefinition);
            DbTypeMap.Set<sbyte?>(DbType.SByte, IntColumnDefinition);
            DbTypeMap.Set<short>(DbType.Int16, IntColumnDefinition);
            DbTypeMap.Set<short?>(DbType.Int16, IntColumnDefinition);
            DbTypeMap.Set<ushort>(DbType.UInt16, IntColumnDefinition);
            DbTypeMap.Set<ushort?>(DbType.UInt16, IntColumnDefinition);
            DbTypeMap.Set<int>(DbType.Int32, IntColumnDefinition);
            DbTypeMap.Set<int?>(DbType.Int32, IntColumnDefinition);
            DbTypeMap.Set<uint>(DbType.UInt32, IntColumnDefinition);
            DbTypeMap.Set<uint?>(DbType.UInt32, IntColumnDefinition);

            DbTypeMap.Set<long>(DbType.Int64, LongColumnDefinition);
            DbTypeMap.Set<long?>(DbType.Int64, LongColumnDefinition);
            DbTypeMap.Set<ulong>(DbType.UInt64, LongColumnDefinition);
            DbTypeMap.Set<ulong?>(DbType.UInt64, LongColumnDefinition);

            DbTypeMap.Set<float>(DbType.Single, RealColumnDefinition);
            DbTypeMap.Set<float?>(DbType.Single, RealColumnDefinition);
            DbTypeMap.Set<double>(DbType.Double, RealColumnDefinition);
            DbTypeMap.Set<double?>(DbType.Double, RealColumnDefinition);

            DbTypeMap.Set<decimal>(DbType.Decimal, DecimalColumnDefinition);
            DbTypeMap.Set<decimal?>(DbType.Decimal, DecimalColumnDefinition);

            DbTypeMap.Set<byte[]>(DbType.Binary, BlobColumnDefinition);

            DbTypeMap.Set<object>(DbType.Object, StringColumnDefinition);
        }

        public DbType GetDbType(Type valueType)
        {
            return DbTypeMap.ColumnDbTypeMap[valueType];
        }

        public string GetColumnDefinition(Type valueType)
        {

            return DbTypeMap.ColumnTypeMap[valueType];
        }

        // edit by cheery,2017/2/22
        // 增加对filed length的解析
        public virtual string GetColumnDefinition(SqlColumnDefine columnDefinition)
        {
            DbType? dbType;
            if (columnDefinition.ColumnAttribute?.DbType != null)
            {
                dbType = columnDefinition.ColumnAttribute.DbType;
            }
            else
            {
                if (columnDefinition.ValueType != null)
                {

                    if (!DbTypeMap.ColumnDbTypeMap.ContainsKey(columnDefinition.ValueType))
                    {
                        var isEnum = columnDefinition.ValueType.GetTypeInfo().IsEnum;
                        dbType = isEnum ? DbType.Int32 : DbType.String;
                    }
                    else
                    {
                        dbType = DbTypeMap.ColumnDbTypeMap[columnDefinition.ValueType];
                    }
                }
                else
                {
                    dbType = DbType.String;
                }
            }
            var fieldLength = columnDefinition.ColumnAttribute?.FieldLength;
            var columnTypeString = "";

            switch (dbType)
            {
                case DbType.AnsiString:
                    fieldLength = string.IsNullOrEmpty(fieldLength) ? "255" : fieldLength;
                    columnTypeString = DbTypeAnsiString(fieldLength);
                    break;
                case DbType.AnsiStringFixedLength:
                    fieldLength = string.IsNullOrEmpty(fieldLength) ? "255" : fieldLength;
                    columnTypeString = DbTypeAnsiStringFixedLength(fieldLength);
                    break;
                case DbType.Binary:
                    columnTypeString = DbTypeBinary(fieldLength);
                    break;
                case DbType.Boolean:
                    columnTypeString = DbTypeBoolean(fieldLength);
                    break;
                case DbType.Byte:
                    columnTypeString = DbTypeByte(fieldLength);
                    break;
                case DbType.Currency:
                    columnTypeString = DbTypeCurrency(fieldLength);
                    break;
                case DbType.Date:
                    columnTypeString = DbTypeDate(fieldLength);
                    break;
                case DbType.DateTime:
                    fieldLength = string.IsNullOrEmpty(fieldLength) ? "3" : fieldLength;
                    columnTypeString = DbTypeDateTime(fieldLength);
                    break;
                case DbType.DateTime2:
                    fieldLength = string.IsNullOrEmpty(fieldLength) ? "3" : fieldLength;
                    columnTypeString = DbTypeDateTime2(fieldLength);
                    break;
                case DbType.DateTimeOffset:
                    fieldLength = string.IsNullOrEmpty(fieldLength) ? "3" : fieldLength;
                    columnTypeString = DbTypeDateTimeOffset(fieldLength);
                    break;
                case DbType.Decimal:
                    fieldLength = string.IsNullOrEmpty(fieldLength) ? "38,6" : fieldLength;
                    columnTypeString = DbTypeDecimal(fieldLength);
                    break;
                case DbType.Double:
                    columnTypeString = DbTypeDouble(fieldLength);
                    break;
                case DbType.Guid:
                    columnTypeString = DbTypeGuid(fieldLength);
                    break;
                case DbType.Int16:
                    columnTypeString = DbTypeInt16(fieldLength);
                    break;
                case DbType.Int32:
                    columnTypeString = DbTypeInt32(fieldLength);
                    break;
                case DbType.Int64:
                    columnTypeString = DbTypeInt64(fieldLength);
                    break;
                case DbType.Object:
                    columnTypeString = DbTypeObject(fieldLength);
                    break;
                case DbType.SByte:
                    columnTypeString = DbTypeSByte(fieldLength);
                    break;
                case DbType.Single:
                    columnTypeString = DbTypeSingle(fieldLength);
                    break;
                case DbType.String:
                    fieldLength = string.IsNullOrEmpty(fieldLength) ? "255" : fieldLength;
                    columnTypeString = DbTypeString(fieldLength);
                    break;
                case DbType.StringFixedLength:
                    fieldLength = string.IsNullOrEmpty(fieldLength) ? "255" : fieldLength;
                    columnTypeString = DbTypeStringFixedLength(fieldLength);
                    break;
                case DbType.Time:
                    columnTypeString = DbTypeTime(fieldLength);
                    break;
                case DbType.UInt16:
                    columnTypeString = DbTypeUInt16(fieldLength);
                    break;
                case DbType.UInt32:
                    columnTypeString = DbTypeUInt32(fieldLength);
                    break;
                case DbType.UInt64:
                    columnTypeString = DbTypeUInt64(fieldLength);
                    break;
                case DbType.VarNumeric:
                    fieldLength = string.IsNullOrEmpty(fieldLength) ? "38,6" : fieldLength;
                    columnTypeString = DbTypeVarNumeric(fieldLength);
                    break;
                case DbType.Xml:
                    columnTypeString = DbTypeXml(fieldLength);
                    break;
            }

            return columnTypeString;
        }

        #region DbType Mapping To DB Column Definition String ，see https://msdn.microsoft.com/en-us/library/system.data.dbtype(v=vs.110).aspx

        /// <summary>
        /// DbType.AnsiString
        /// A variable-length stream of non-Unicode characters ranging between 1 and 8,000 characters.
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        protected virtual string DbTypeAnsiString(string length)
        {
            return $"CHARACTER VARYING({length})";
        }
        /// <summary>
        /// DbType.AnsiStringFixedLength
        /// A fixed-length stream of non-Unicode characters.
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        protected virtual string DbTypeAnsiStringFixedLength(string length)
        {
            return $"CHARACTER({length})";
        }

        /// <summary>
        /// DbType.Binary
        /// A variable-length stream of binary data ranging between 1 and 8,000 bytes.
        /// </summary>
        /// <returns></returns>
        protected virtual string DbTypeBinary(string fieldLength)
        {
            return $"CHARACTER VARYING(8000)";
        }

        /// <summary>
        /// DbType.Boolean
        /// A simple type representing Boolean values of true or false.
        /// </summary>
        /// <returns></returns>
        protected virtual string DbTypeBoolean(string fieldLength)
        {
            return $"BIT";
        }

        /// <summary>
        /// DbType.Byte
        /// An 8-bit unsigned integer ranging in value from 0 to 255.
        /// </summary>
        /// <returns></returns>
        protected virtual string DbTypeByte(string fieldLength)
        {
            return $"SMALLINT";
        }

        /// <summary>
        /// DbType.Currency
        /// A currency value ranging from -2 63 (or -922,337,203,685,477.5808) to 2 63 -1 (or +922,337,203,685,477.5807) with an accuracy to a ten-thousandth of a currency unit.
        /// </summary>
        /// <returns></returns>
        protected virtual string DbTypeCurrency(string fieldLength)
        {
            return $"DECIMAL(38,4)";
        }

        /// <summary>
        /// DbType.Date
        /// A type representing a date value.
        /// </summary>
        /// <returns></returns>
        protected virtual string DbTypeDate(string fieldLength)
        {
            return $"DATE";
        }

        /// <summary>
        /// DbType.DateTime
        /// A type representing a date and time value.
        /// </summary>
        /// <returns></returns>
        protected virtual string DbTypeDateTime(string fieldLength)
        {
            return $"DATETIME({fieldLength})";
        }

        /// <summary>
        /// DbType.DateTime2
        /// Date and time data. Date value range is from January 1,1 AD through December 31, 9999 AD. Time value range is 00:00:00 through 23:59:59.9999999 with an accuracy of 100 nanoseconds.
        /// </summary>
        /// <returns></returns>
        protected virtual string DbTypeDateTime2(string fieldLength)
        {
            return $"DATETIME({fieldLength})";
        }

        /// <summary>
        /// DbType.DateTimeOffset
        /// Date and time data with time zone awareness. Date value range is from January 1,1 AD through December 31, 9999 AD. Time value range is 00:00:00 through 23:59:59.9999999 with an accuracy of 100 nanoseconds. Time zone value range is -14:00 through +14:00.
        /// </summary>
        /// <returns></returns>
        protected virtual string DbTypeDateTimeOffset(string fieldLength)
        {
            return $"DATETIME({fieldLength})";
        }

        /// <summary>
        /// DbType.Decimal
        /// A simple type representing values ranging from 1.0 x 10 -28 to approximately 7.9 x 10 28 with 28-29 significant digits.
        /// </summary>
        /// <returns></returns>
        protected virtual string DbTypeDecimal(string fieldLength)
        {
            return $"DECIMAL({fieldLength})";
        }

        /// <summary>
        /// DbType.Double
        /// A floating point type representing values ranging from approximately 5.0 x 10 -324 to 1.7 x 10 308 with a precision of 15-16 digits.
        /// </summary>
        /// <returns></returns>
        protected virtual string DbTypeDouble(string fieldLength)
        {
            return $"DOUBLE PRECISION";
        }
        /// <summary>
        /// DbType.Guid
        /// A globally unique identifier (or GUID).
        /// </summary>
        /// <returns></returns>
        protected virtual string DbTypeGuid(string fieldLength)
        {
            return $"CHARACTER(48)";
        }

        /// <summary>
        /// DbType.Int16
        /// An integral type representing signed 16-bit integers with values between -32768 and 32767.
        /// </summary>
        /// <returns></returns>
        protected virtual string DbTypeInt16(string fieldLength)
        {
            return $"SMALLINT";
        }

        /// <summary>
        /// DbType.Int32
        /// An integral type representing signed 32-bit integers with values between -2147483648 and 2147483647.
        /// </summary>
        /// <returns></returns>
        protected virtual string DbTypeInt32(string fieldLength)
        {
            return $"INTEGER";
        }

        /// <summary>
        /// DbType.Int64
        /// An integral type representing signed 64-bit integers with values between -9223372036854775808 and 9223372036854775807.
        /// </summary>
        /// <returns></returns>
        protected virtual string DbTypeInt64(string fieldLength)
        {
            return $"BIGINT";
        }

        /// <summary>
        /// DbType.Object
        /// A general type representing any reference or value type not explicitly represented by another DbType value.
        /// </summary>
        /// <returns></returns>
        protected virtual string DbTypeObject(string fieldLength)
        {
            throw new NotSupportedException("Type DbType.Object is not supported.");
        }

        /// <summary>
        /// DbType.SByte
        /// An integral type representing signed 8-bit integers with values between -128 and 127.
        /// </summary>
        /// <returns></returns>
        protected virtual string DbTypeSByte(string fieldLength)
        {
            return $"SMALLINT";
        }
        /// <summary>
        /// DbType.Single
        /// A floating point type representing values ranging from approximately 1.5 x 10 -45 to 3.4 x 10 38 with a precision of 7 digits.
        /// </summary>
        /// <returns></returns>
        protected virtual string DbTypeSingle(string fieldLength)
        {
            return $"FLOAT";
        }

        /// <summary>
        /// DbType.String
        /// A type representing Unicode character strings.
        /// </summary>
        /// <returns></returns>
        protected virtual string DbTypeString(string fieldLength)
        {
            if (int.Parse(fieldLength) > 8000)
            {
                return $"TEXT";
            }
            return $"CHARACTER VARYING({fieldLength})";
        }

        /// <summary>
        /// DbType.StringFixedLength
        /// A fixed-length string of Unicode characters.
        /// </summary>
        /// <returns></returns>
        protected virtual string DbTypeStringFixedLength(string fieldLength)
        {
            return $"CHARACTER({fieldLength})";
        }

        /// <summary>
        /// DbType.Time
        /// A fixed-length string of Unicode characters.
        /// </summary>
        /// <returns></returns>
        protected virtual string DbTypeTime(string fieldLength)
        {
            return $"TIME";
        }

        /// <summary>
        /// DbType.UInt16
        /// An integral type representing unsigned 16-bit integers with values between 0 and 65535.
        /// </summary>
        /// <returns></returns>
        protected virtual string DbTypeUInt16(string fieldLength)
        {
            return $"SMALLINT";
        }

        /// <summary>
        /// DbType.UInt32
        /// An integral type representing unsigned 32-bit integers with values between 0 and 4294967295.
        /// </summary>
        /// <returns></returns>
        protected virtual string DbTypeUInt32(string fieldLength)
        {
            return $"INTEGER";
        }
        /// <summary>
        /// DbType.UInt64
        /// An integral type representing unsigned 64-bit integers with values between 0 and 18446744073709551615.
        /// </summary>
        /// <returns></returns>
        protected virtual string DbTypeUInt64(string fieldLength)
        {
            return $"BIGINT";
        }

        /// <summary>
        /// DbType.VarNumeric
        /// A variable-length numeric value.
        /// </summary>
        /// <returns></returns>
        protected virtual string DbTypeVarNumeric(string fieldLength)
        {
            return $"NUMERIC({fieldLength})";
        }

        /// <summary>
        /// DbType.Xml
        /// A parsed representation of an XML document or fragment.
        /// </summary>
        /// <returns></returns>
        protected virtual string DbTypeXml(string fieldLength)
        {
            return $"XML";
        }
        #endregion
    }

    internal class IndexStructure
    {
        public bool Unique { get; set; }
        public string IndexName { get; set; }

        public string TableName { get; set; }

        public List<IndexColumnStructure> Columns { get; set; }
    }

    internal class IndexColumnStructure
    {
        public string ColumnName { get; set; }

        public bool Asc { get; set; }
    }
}
