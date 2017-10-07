using System;

namespace WitsWay.Utilities.Models
{
    /// <summary>
    /// 操作日志
    /// </summary>
    [Serializable]
    public class OperationLog
    {
        /// <summary>
        /// 唯一标识
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// CorpID.
        /// </summary>
        public int? CorpID { get; set; }

        /// <summary>
        /// UserID.
        /// </summary>
        public int? EmployeeID { get; set; }

        /// <summary>
        /// Service (class/interface) name.
        /// </summary>
        public string ServiceName { get; set; }

        /// <summary>
        /// Executed method name.
        /// </summary>
        public string MethodName { get; set; }

        /// <summary>
        /// Calling parameters.
        /// </summary>
        public string Parameters { get; set; }

        /// <summary>
        /// Start time of the method execution.
        /// </summary>
        public DateTime ExecutionTime { get; set; }

        /// <summary>
        /// Total duration of the method call.
        /// </summary>
        public int ExecutionDuration { get; set; }

        /// <summary>
        /// IP address of the client.
        /// </summary>
        public string ClientIpAddress { get; set; }

        /// <summary>
        /// Name (generally computer name) of the client.
        /// </summary>
        public string ClientName { get; set; }

        /// <summary>
        /// Browser information if this method is called in a web request.
        /// </summary>
        public string BrowserInfo { get; set; }

        /// <summary>
        /// Optional custom data that can be filled and used.
        /// </summary>
        public string CustomData { get; set; }

        /// <summary>
        /// Exception object, if an exception occured during execution of the method.
        /// </summary>
        public string ExceptionInfo { get; set; }

        public override string ToString()
        {
            return
                $"AUDIT LOG: {ServiceName}.{MethodName} is executed by user {EmployeeID} in {ExecutionDuration} ms from {ClientIpAddress} IP address.";
        }
    }
}