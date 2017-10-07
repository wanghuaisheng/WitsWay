using WitsWay.Utilities.Models;

namespace WitsWay.Utilities.Apis.Controller
{
    /// <summary>
    /// 支持审计功能的WebApiController
    /// </summary>
    public interface IAuditableController
    {
        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="log"></param>
        void Log(OperationLog log);
    }
}
