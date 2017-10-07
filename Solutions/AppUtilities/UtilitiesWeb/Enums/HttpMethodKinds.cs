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
namespace WitsWay.Utilities.Web.Enums
{
    /// <summary>
    /// HttpMethod类型
    /// </summary>
    public enum HttpMethodKinds
    {
        /// <summary>
        /// 从指定的url上获取内容
        /// </summary>
        GET,
        /// <summary>
        /// 提交body中的内容给服务器中指定的url中，属于非幂等的(non-idempotent)请求
        /// </summary>
        POST,
        /// <summary>
        /// 从指定的url上获取header内容(类似Get方式)
        /// </summary>
        HEAD,
        /// <summary>
        /// Allows a programmer to see how the client's message is modified as it passes through a series of proxy servers. The recipient of a TRACE method echoes the HTTP request headers back to the client
        /// </summary>
        TRACE,
        /// <summary>
        /// 将body上传至服务器指定url处
        /// </summary>
        PUT,
        /// <summary>
        /// 在指定url处删除资源
        /// </summary>
        DELETE,
        /// <summary>
        /// 获取指定url中能接收的请求方法
        /// </summary>
        OPTIONS,
        /// <summary>
        /// 连接指定频段。当客户端需要通过代理服务器连接HTTPS服务器是用到。
        /// </summary>
        CONNECT
    }
}
