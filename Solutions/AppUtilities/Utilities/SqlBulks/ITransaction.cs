using System.Data.SqlClient;
using System.Threading.Tasks;

namespace WitsWay.Utilities.SqlBulks
{
    /// <summary>
    /// 事务支持接口
    /// </summary>
    internal interface ITransaction
    {
        /// <summary>
        /// 提交事务
        /// </summary>
        /// <param name="connectionName">连接名称</param>
        /// <param name="credentials">安全证书</param>
        /// <param name="connection">连接</param>
        void CommitTransaction(string connectionName = null, SqlCredential credentials = null, SqlConnection connection = null);
        /// <summary>
        /// 异步提交事务
        /// </summary>
        /// <param name="connectionName">连接名称</param>
        /// <param name="credentials">安全证书</param>
        /// <param name="connection">连接</param>
        /// <returns>异步任务</returns>
        Task CommitTransactionAsync(string connectionName = null, SqlCredential credentials = null, SqlConnection connection = null);
    }
}
