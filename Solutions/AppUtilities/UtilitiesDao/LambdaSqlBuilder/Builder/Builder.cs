using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using WitsWay.Utilities.Dap.Helpers;
using WitsWay.Utilities.Dap.LambdaSqlBuilder.Adapters;
using WitsWay.Utilities.Dap.LambdaSqlBuilder.Entities;

namespace WitsWay.Utilities.Dap.LambdaSqlBuilder.Builder
{
    
    public partial class Builder
    {
        internal Builder(SqlType type, Type entityType, ISqlAdapter adapter)
        {
            _paramIndex = 0;
           
            _adapter = adapter;
            _type = type;
            _useField = true;
            _entityType = entityType;
            var tabDef = _entityType.GetEntityDefines();

            var tname = tabDef.Item1.TableAttribute?.Name;
            if (string.IsNullOrEmpty(tname))
            {
                tname = tabDef.Item1.Name;
            }

            _tableNames.Add(tname);
            _schema = tabDef.Item1.TableAttribute?.Schema;
            _tableDefine = tabDef.Item1;
            _columnDefines = tabDef.Item2;
            _parameterDic = new Dictionary<string, object>(); //new ExpandoObject();
        }

        internal Builder(SqlType type, SqlTableDefine tableDefine ,List<SqlColumnDefine> columnDefines,ISqlAdapter adapter)
        {
            _paramIndex = 0;

            _adapter = adapter;
            _type = type;
            _useField = true;
             
            var tabDef = tableDefine;

            var tname = tabDef.TableAttribute?.Name;
            if (string.IsNullOrEmpty(tname))
            {
                tname = tabDef.Name;
            }

            _tableNames.Add(tname);
            _schema = tabDef.TableAttribute?.Schema;
            _tableDefine = tableDefine;
            _columnDefines = columnDefines;
            _parameterDic = new Dictionary<string, object>(); //new ExpandoObject();
        }

        private ISqlAdapter _adapter;
        private SqlType _type;
        private bool _useField;
        private bool _userKey;

        internal bool _isSubQuery;

        private Type _entityType;

        private SqlTableDefine _tableDefine;
        private List<SqlColumnDefine> _columnDefines;

        internal ISqlAdapter Adapter { get { return _adapter; } set { _adapter = value; } }

        //private const string PARAMETER_PREFIX = "Param";
        private readonly string PARAMETER_PREFIX = "P_" + DateTime.Now.Ticks.ToString();

        private readonly List<string> _tableNames = new List<string>();
        private readonly string _schema = string.Empty;
        private readonly List<string> _joinExpressions = new List<string>();
        private readonly List<string> _selectionList = new List<string>();
        private readonly List<string> _conditions = new List<string>();
        private readonly List<string> _sortList = new List<string>();
        private readonly List<string> _groupingList = new List<string>();
        private readonly List<string> _havingConditions = new List<string>();
        private readonly List<string> _splitColumns = new List<string>();
        private readonly List<string> _parameters = new List<string>();
        private int _paramIndex;
        private IDictionary<string, object> _parameterDic;

        public List<string> SplitColumns { get { return _splitColumns; } }
        public IDictionary<string, object> Parameters { get { return _parameterDic; } }

        public string SqlString()
        {
            var sql = string.Empty;
            var entity = GetSqlEntity();
            switch (_type)
            {
                case SqlType.Query:
                    sql = _adapter.Query(entity);
                    break;
                case SqlType.Insert:
                    sql = _adapter.Insert(_userKey, entity);
                    break;
                case SqlType.Update:
                    sql = _adapter.Update(entity);
                    break;
                case SqlType.Delete:
                    sql = _adapter.Delete(entity);
                    break;
                default:
                    break;
            }
            return sql;
        }

        //public bool NeedOrderBy()
        //{
        //    if (_sortList.Count == 0 && _adapter is SqlserverAdapter)
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        public string QueryPage(int pageSize, int? pageNumber = null)
        {
            var entity = GetSqlEntity();
            entity.PageSize = pageSize;
            if (pageNumber.HasValue)
            {
                if (_sortList.Count == 0 && _adapter is SqlserverAdapter)
                {
                    var key=_columnDefines.FirstOrDefault(p => p.KeyAttribute != null);
                    if (key == null)
                    {
                        key = _columnDefines.FirstOrDefault(p => p.Name.ToUpper() == "ID" || p.AliasName == "ID");
                    }
                    if (key != null)
                    {
                        var orderbyname = string.IsNullOrEmpty(key.AliasName) ? key.Name : key.AliasName;

                        OrderBy(entity.TableName, orderbyname);

                        entity.OrderBy= GetForamtList(", ", "ORDER BY ", _sortList);
                    }
                    else
                    {
                        throw new Exception("Pagination requires the ORDER BY statement to be specified");
                    }
                }
                 
                entity.PageNumber = pageNumber.Value;
            }
            return _adapter.QueryPage(entity);
        }

        public string QuerySubPage(int pageSize,string aliasTable, int? pageNumber = null)
        {
            var entity = GetSqlEntity();
            entity.PageSize = pageSize;
            if (pageNumber.HasValue)
            {
                if (_sortList.Count == 0 && _adapter is SqlserverAdapter)
                {
                    var key = _columnDefines.FirstOrDefault(p => p.KeyAttribute != null);
                    if (key == null)
                    {
                        key = _columnDefines.FirstOrDefault(p => p.Name.ToUpper() == "ID" || p.AliasName == "ID");
                    }
                    if (key != null)
                    {
                        var orderbyname = string.IsNullOrEmpty(key.AliasName) ? key.Name : key.AliasName;

                        OrderBy(aliasTable, orderbyname);

                        entity.OrderBy = GetForamtList(", ", "ORDER BY ", _sortList);
                    }
                    else
                    {
                        throw new Exception("Pagination requires the ORDER BY statement to be specified");
                    }
                }

                entity.PageNumber = pageNumber.Value;
            }
            return _adapter.QueryPage(entity);
        }

        public void Clear()
        {
            if (_joinExpressions.Count > 0)
            {
                var tableName = _tableNames[0];
                _tableNames.Clear();
                _joinExpressions.Clear();
                _tableNames.Add(tableName);
            }
            _selectionList.Clear();
            _conditions.Clear();
            _sortList.Clear();
            _groupingList.Clear();
            _havingConditions.Clear();
            _splitColumns.Clear();
            _parameters.Clear();
            _paramIndex = 0;
            _parameterDic = new ExpandoObject();
            _type = SqlType.Query;
        }

        public void UpdateSqlType(SqlType type)
        {
            _type = type;
        }

        public void UpdateUseEntityProperty(bool use)
        {
            _useField = use;
        }

        public void UpdateInsertKey(bool key)
        {
            _userKey = key;
        }

        #region Private

        private string GetTableName()
        {
            if (_isSubQuery)
            {
                return _tableNames.First();
            }
            var joinExpression = string.Join(" ", _joinExpressions);
            return $"{_adapter.Table(_tableNames.First(), _schema)} {joinExpression}";
        }
        private string GetSelection()
        {
            if (_selectionList.Count == 0)
            {
                //var columnList = new List<string>();

                SelectAll();

                return string.Join(",", _selectionList);
            }
            //return string.Format("{0}.*", _adapter.Table(_tableNames.First()));
            else
                return string.Join(", ", _selectionList);
        }

        public void SelectAll()
        {
            var entityDef = _entityType.GetEntityDefines();

            foreach (var cdef in entityDef.Item2)
            {
                var s = _adapter.Field(cdef.AliasName);

                if (!string.IsNullOrEmpty(cdef.AliasName))
                {
                    //s += " as " + _adapter.Field(cdef.Name);
                }
                else
                {
                    s = _adapter.Field(cdef.Name);
                }
                _selectionList.Add(s);
            }
        }

        public void SelectSub()
        {
            
        }

        private string GetForamtList(string join, string head, List<string> list)
        {
            if (list.Count == 0) return "";
            return head + string.Join(join, list);
        }

        private SqlEntity GetSqlEntity()
        {
            var entity = new SqlEntity();
            entity.Having = GetForamtList(" ", "HAVING ", _havingConditions);
            entity.Grouping = GetForamtList(", ", "GROUP BY ", _groupingList);
            entity.OrderBy = GetForamtList(", ", "ORDER BY ", _sortList);
            entity.Conditions = GetForamtList("", "WHERE ", GetConditions());
            entity.Parameter = GetForamtList(", ", "", _parameters);
            entity.TableName = GetTableName();
            entity.Selection = GetSelection();
            return entity;
        }

        //private SqlEntity GetSqlEntity()
        //{
        //    SqlEntity entity = new SqlEntity();
        //    entity.Having = GetForamtList(" ", "HAVING ", _havingConditions);
        //    entity.Grouping = GetForamtList(", ", "GROUP BY ", _groupingList);
        //    entity.OrderBy = GetForamtList(", ", "ORDER BY ", _sortList);
        //    entity.Conditions = GetForamtList("", "WHERE ", _conditions);
        //    entity.Parameter = GetForamtList(", ", "", _parameters);
        //    entity.TableName = GetTableName();
        //    entity.Selection = GetSelection();
        //    return entity;
        //}

        private string GetParamId()
        {
            _paramIndex++;
            return PARAMETER_PREFIX + _paramIndex.ToString(CultureInfo.InvariantCulture);
        }

        private string GetParamId(string fieldName)
        {
            if (_useField)
            {
                if (_type == SqlType.Query)
                {
                    _paramIndex++;
                    return PARAMETER_PREFIX + "_" + _paramIndex.ToString(CultureInfo.InvariantCulture) + "_" + fieldName;
                }

                return fieldName;
            }
            return GetParamId();
        }

        private string GetCondition(string tableName, string fieldName, string op, object fieldValue)
        {
            var paramId = GetParamId(fieldName);
            var key = _adapter.Field(tableName, fieldName);
 
            var value = _adapter.Parameter(paramId);

            if (_parameterDic.ContainsKey(value))
            {
                value = value + Guid.NewGuid().ToString("n");
            }

            if (_isSubQuery)
            {
                key = _adapter.Field(JoinSubAliasTableName, fieldName);
                //value = JoinSubAliasTableName + value;
            }

            AddParameter(value, fieldValue);

            return $"{key} {op} {value}";
        }

        private string GetCondition(string tableName, string fieldName, string aliasName, string op, object fieldValue)
        {
            var paramId = GetParamId(fieldName);
            var key = _adapter.Field(aliasName);
             
            var value = _adapter.Parameter(paramId);
            if (_parameterDic.ContainsKey(value))
            {
                value = value + Guid.NewGuid().ToString("n");
            }

            if (_isSubQuery)
            {
                key = _adapter.Field(JoinSubAliasTableName, fieldName);
                value = JoinSubAliasTableName + value;
            }

            AddParameter(value, fieldValue);
            return $"{key} {op} {value}";
        }

        public List<string> GetConditions()
        {
            if (_type == SqlType.Update||_type==SqlType.Delete)
            {
                if (_conditions.Count == 0)
                {
                    var tabDef = _entityType.GetEntityDefines();

                    var keyField = tabDef.Item2.FirstOrDefault(p => p.KeyAttribute != null);

                    if (keyField == null)
                    {
                        throw new Exception("Must to define LamKey attribute to entity");
                    }

                    var paramId = keyField.AliasName ?? keyField.Name;
                    var key = _adapter.Field(paramId);
                    var value = _adapter.Parameter(paramId);

                    var condition = $"{key} = {value}";


                    return new List<string>() { condition };

                }
            }

            return _conditions;
        }

        private void AddParameter(string key, object value)
        {
            if (!_parameterDic.ContainsKey(key))
                _parameterDic.Add(key, value);
        }

        #endregion

    }
}
