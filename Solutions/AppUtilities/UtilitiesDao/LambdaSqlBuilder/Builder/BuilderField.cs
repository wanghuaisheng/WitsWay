using System.Collections.Generic;
using System.Linq;

namespace WitsWay.Utilities.Dap.LambdaSqlBuilder.Builder
{
    partial class Builder
    {
        public void AddCondition(string tableName, string fieldName, string op, object fieldValue)
        {
            var condition = GetCondition(tableName, fieldName, op, fieldValue);
            _conditions.Add(condition);
        }

        public void AddCondition(string fieldName, string op, object fieldValue)
        {
            var newCondition = $"{fieldName} {op} {fieldValue}";
            _conditions.Add(newCondition);
        }

        public void AddLikeCondition(string tableName, string fieldName, string fieldValue)
        {
            AddCondition(tableName, fieldName, Adapter.LikeStagement(), fieldValue);
        }

        public void AddCondition(bool isnull, string tableName, string fieldName)
        {
            var s = isnull ? "IS NULL" : "IS NOT NULL";

             
            var key = _adapter.Field(tableName, fieldName);

         
            if (_isSubQuery)
            {
                key = _adapter.Field(JoinSubAliasTableName, fieldName);
 
            }
 
            _conditions.Add($"{key} {s}");
        }

        public void AddCondition(string leftTableName, string leftFieldName, string op,
            string rightTableName, string rightFieldName)
        {
            var newCondition =
                $"{_adapter.Field(leftTableName, leftFieldName)} {op} {_adapter.Field(rightTableName, rightFieldName)}";
            _conditions.Add(newCondition);
        }

        public void AddCondition(bool notIn, string tableName, string fieldName, IEnumerable<object> values)
        {
            var paramIds = values.Select(x =>
            {
                var paramId = GetParamId();
                paramId = _adapter.Parameter(paramId);
                AddParameter(paramId, x);
                return paramId;
            });
            var op = notIn ? "NOT IN" : "IN";

            var key = _adapter.Field(tableName, fieldName);


            if (_isSubQuery)
            {
                key = _adapter.Field(JoinSubAliasTableName, fieldName);

            }

            var newCondition = string.Format("{0} {2} ({1})", key, string.Join(",", paramIds), op);
            _conditions.Add(newCondition);
        }

        public void AddCondition(bool notIn, string tableName, string fieldName, SqlExpBase sqlQuery)
        {
            var innerQuery = sqlQuery.SqlString;
            foreach (var name in sqlQuery.Parameters)
            {
                //var param = name.Key;
                //var innerParamKey = "Inner" + param;
                //innerQuery = Regex.Replace(innerQuery, param, innerParamKey);
                //AddParameter(innerParamKey, name.Value);
                AddParameter(name.Key, name.Value);
            }
            var op = notIn ? "NOT IN" : "IN";

            var key = _adapter.Field(tableName, fieldName);


            //if (_isSubQuery)
            //{
            //    key = _adapter.Field(JoinSubAliasTableName, fieldName);

            //}
            var newCondition = string.Format("{0} {2} ({1})", key, innerQuery, op);
            _conditions.Add(newCondition);
        }

        public void AddSection(string tableName, string fieldName, string aliasName, string op, object fieldValue)
        {
            var condition = GetCondition(tableName, fieldName, aliasName, op, fieldValue);
            _selectionList.Add(condition);
        }

        //public void AddSection(string tableName, string fieldName, object fieldValue)
        //{
        //    var paramId = _adapter.Parameter(fieldName);
        //    _selectionList.Add(_adapter.Field(tableName, fieldName));
        //    _parameters.Add(paramId);
        //    AddParameter(paramId, fieldValue);
        //}

        public void AddSection(string tableName, string fieldName, string aliasName, object fieldValue)
        {
            var paramId = _adapter.Parameter(fieldName);
            _selectionList.Add(_adapter.Field(aliasName));
            _parameters.Add(paramId);
            AddParameter(paramId, fieldValue);
        }
    }
}
