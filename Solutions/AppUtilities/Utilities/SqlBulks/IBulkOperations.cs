using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace WitsWay.Utilities.SqlBulks
{
    /// <summary>
    /// 批量操作接口
    /// </summary>
    public interface IBulkOperations
    {
        /// <summary>
        /// 提交事务
        /// </summary>
        /// <param name="connection">连接</param>
        void CommitTransaction(SqlConnection connection);
        /// <summary>
        /// 异步提交事务
        /// </summary>
        /// <param name="connection">连接</param>
        /// <returns>异步Task</returns>
        Task CommitTransactionAsync(SqlConnection connection);
        /// <summary>
        /// 提交事务
        /// </summary>
        /// <param name="connectionName">连接名</param>
        /// <param name="credentials">安全证书</param>
        void CommitTransaction(string connectionName, SqlCredential credentials = null);
        /// <summary>
        /// 异步提交事务
        /// </summary>
        /// <param name="connectionName">连接名</param>
        /// <param name="credentials">安全证书</param>
        /// <returns>异步Task</returns>
        Task CommitTransactionAsync(string connectionName, SqlCredential credentials = null);

        /// <summary>
        /// 操作装配
        /// </summary>
        /// <param name="list">列表映射Func委托</param>
        /// <typeparam name="T">实体类型</typeparam>
        /// <returns>集合选择器</returns>
        CollectionSelect<T> Setup<T>(Func<Setup<T>, CollectionSelect<T>> list);
    }
}