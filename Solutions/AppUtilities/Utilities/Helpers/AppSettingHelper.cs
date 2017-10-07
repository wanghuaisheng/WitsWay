using System;
using System.Configuration;
using System.IO;
using System.Xml;
using WitsWay.Utilities.Errors;

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
            return ConfigurationManager.AppSettings[key].Trim();
        }

        /// <summary>
        /// 根据Key修改Value
        /// </summary>
        /// <param name="key">要修改的Key</param>
        /// <param name="value">要修改为的值</param>
        public static void SetValue(string key, string value)
        {
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Xml\\appSettings.config");
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
