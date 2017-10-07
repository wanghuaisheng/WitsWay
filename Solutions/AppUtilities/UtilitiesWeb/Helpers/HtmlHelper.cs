using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WitsWay.Utilities.Attributes;

namespace WitsWay.Utilities.Web.Helpers
{
    /// <summary>
    /// Html帮助类
    /// </summary>
    public class HtmlHelper
    {
        /// <summary>
        /// 构造一个枚举类型的选择控件
        /// </summary>
        /// <param name="type">枚举类型</param>
        /// <param name="id">控件id</param>
        /// <param name="name">控件名称</param>
        /// <param name="cssClass">css样式</param>
        /// <param name="itemCssClass">项css样式</param>
        /// <param name="ignoreList">忽略列表</param>
        /// <param name="showAll">显示“所有”选项</param>
        /// <param name="allCaption">“所有”选项的标题</param>
        /// <param name="allValue">“所有”选项的值</param>
        /// <returns></returns>
        public static string EnumSelect(Type type, string id, string name = "", string cssClass = "", string itemCssClass = "", IEnumerable<int> ignoreList = null, bool showAll = false, string allCaption = "全部", int allValue = 0)
        {
            var sb = new StringBuilder();
            sb.Append("<select ");
            if (!string.IsNullOrWhiteSpace(name))
                sb.AppendFormat(" name='{0}'", name);
            if (!string.IsNullOrWhiteSpace(id))
                sb.AppendFormat(" id='{0}'", id);
            if (!string.IsNullOrWhiteSpace(cssClass))
                sb.AppendFormat(" class='{0}'", cssClass);
            sb.AppendLine(">");

            if (showAll)
                AppendItem(sb, allCaption, allValue, itemCssClass);

            foreach (var fieldDescription in EnumDescription.GetFieldInfos(type))
            {
                if (ignoreList != null && ignoreList.Contains(fieldDescription.EnumValue))
                    continue;

                AppendItem(sb, fieldDescription.EnumDisplayText, fieldDescription.EnumValue, itemCssClass);
            }
            sb.AppendLine("</select>");

            return sb.ToString();
        }

        private static void AppendItem(StringBuilder sb, string text, int value, string itemCssClass)
        {
            if (string.IsNullOrWhiteSpace(itemCssClass))
                sb.AppendFormat("<option value='{0}'>{1}</option>\r\n", value, text);
            else
                sb.AppendFormat("<option class ='{2}' value='{0}'>{1}</option>\r\n", value, text, itemCssClass);
        }
    }
}
