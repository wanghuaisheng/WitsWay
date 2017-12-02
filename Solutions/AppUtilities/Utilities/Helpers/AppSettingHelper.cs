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
using System.Configuration;
using System.IO;
using System.Xml;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using WitsWay.Utilities.Errors;
using WitsWay.Utilities.Extends;

namespace WitsWay.Utilities.Helpers
{
    /// <summary>
    /// Config文件操作
    /// </summary>
    public class AppSettingHelper
    {

        /// <summary>
        /// 根据Key取Value值
        /// </summary>
        /// <param name="key"></param>
        public static string GetValue(string key)
        {
            try
            {
                return ConfigurationManager.AppSettings[key]?.Trim();
            }
            catch (Exception e)
            {
                Logger.Write(e);
                throw ExceptionHelper.GetProgramException(UtilityErrors.AppConfigAppSettingError, key);
            }
        }

        /// <summary>
        /// 根据Key取Value值
        /// </summary>
        /// <typeparam name="T">值类型</typeparam>
        /// <param name="key">AppSetting键</param>
        /// <returns></returns>
        public static T GetValue<T>(string key)
        {
            try
            {
                var val = GetValue(key);
                return string.IsNullOrWhiteSpace(val) ? default(T) : val.CastTo<T>();
            }
            catch (Exception e)
            {
                Logger.Write(e);
                throw ExceptionHelper.GetProgramException(UtilityErrors.AppConfigAppSettingError, key);
            }
        }

        /// <summary>
        /// 根据Key修改Value
        /// </summary>
        /// <param name="key">要修改的Key</param>
        /// <param name="value">要修改为的值</param>
        /// <param name="xmlFileRelativePath">xml文件相对位置
        /// <para>例如：<![CDATA[Xml\\appSettings.config]]></para>
        /// </param>
        public static void SetValue(string key, string value, string xmlFileRelativePath)
        {
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, xmlFileRelativePath);
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"配置文件{filePath}不存在");
            }
            var doc = new XmlDocument();
            doc.Load(filePath);
            var node = doc.SelectSingleNode("//appSettings");//??xDoc.CreateNode();
            if (node == null)
            {
                //配置节不存在
                ExceptionHelper.ThrowProgramException(UtilityErrors.ConfigFileErrorServerIpNotIp);
            }
            var elem1 = (XmlElement)node.SelectSingleNode("//add[@key='" + key + "']");

            if (elem1 != null) elem1.SetAttribute("value", value);
            else
            {
                var elem2 = doc.CreateElement("add");
                elem2.SetAttribute("key", key);
                elem2.SetAttribute("value", value);
                node.AppendChild(elem2);
            }
            doc.Save(filePath);
        }
    }
}
