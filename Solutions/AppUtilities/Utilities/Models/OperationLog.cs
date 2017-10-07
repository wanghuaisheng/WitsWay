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