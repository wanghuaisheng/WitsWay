using System.Collections.Generic;
using WitsWay.Utilities.Dap.LambdaSqlBuilder.Entity;

namespace WitsWay.Utilities.Dap.LambdaSqlBuilder.Adapter
{
    /// <summary>
    /// Sql适配器
    /// </summary>
    public interface ISqlAdapter
    {
        //string LeftToken { get; }
        //string RightToken { get; }
        //string ParamPrefix { get; }
        bool SupportParameter { get; }

        string Query(SqlEntity entity);
        string QueryPage(SqlEntity entity);
        string Insert(bool key, SqlEntity entity);
        string Update(SqlEntity entity);
        string Delete(SqlEntity entity);

        string Table(string tableName, string schema);
        string Field(string filedName);
        string Field(string tableName, string fieldName);
        string Parameter(string parameterId);

        string LikeStagement();

        string LikeChars();

        string EqualChars();

        string CreateTableSql(SqlTableDefine tableDefine, List<SqlColumnDefine> columnDefines);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        string TableExistSql(string tableName, string tableSchema);

        string DropTableSql(string tableName, string tableSchema);

        string TruncateTableSql(string tableName, string tableSchema);
    }
}
