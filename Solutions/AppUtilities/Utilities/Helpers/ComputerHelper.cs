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
