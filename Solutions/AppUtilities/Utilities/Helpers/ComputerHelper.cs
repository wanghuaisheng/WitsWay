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
using System.Collections.Generic;
using System.Management;
using System.Net;

namespace WitsWay.Utilities.Helpers
{
    /// <summary>
    /// 计算机等设备帮助类
    /// </summary>
    public class ComputerHelper
    {
        /// <summary>
        /// 获取物理地址列表
        /// </summary>
        /// <returns>返回物理地址列表</returns>
        public static List<string> GetMacAddress()
        {
            var mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            var moc = mc.GetInstances();
            if (moc.Count == 0) return new List<string>();
            var listMacAddress = new List<string>();
            var eor = moc.GetEnumerator();
            while (eor.MoveNext())
            {
                var mo = eor.Current;
                if (mo["IPEnabled"].ToString() == "True")
                {
                    listMacAddress.Add(mo["MacAddress"].ToString().Replace(":", "-"));
                }
            }
            return listMacAddress;
        }


        /// <summary>
        /// 获取本机IP地址
        /// </summary>
        /// <returns>本机IP地址</returns>
        public static string GetLocalAddress()
        {
            //获取本机IP地址
            var iPHost = Dns.GetHostEntry(Environment.MachineName);
            var hostIp = string.Empty;
            foreach (var address in iPHost.AddressList)
            {
                if (address.IsIPv6LinkLocal || address.IsIPv6Teredo ||
                    address.AddressFamily != System.Net.Sockets.AddressFamily.InterNetwork) continue;
                hostIp = address.ToString();
                break;
            }
            return hostIp;
        } 
    }
}
