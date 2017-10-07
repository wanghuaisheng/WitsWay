using System.Collections.Generic;
using DevExpress.XtraTreeList.Nodes;
using WitsWay.Utilities.Extends;

namespace WitsWay.Utilities.Win.Extends
{
    /// <summary>
    /// TreeListNode扩展类
    /// </summary>
    public static class TreeListNodeExtends
    {
        /// <summary>
        /// 设置控件Tag
        /// </summary>
        public static void SetTag(this TreeListNode ctr, string tagKey, object tag)
        {
            var tagDic = ctr.Tag as Dictionary<string, object>;
            if (tagDic == null)
            {
                tagDic = new Dictionary<string, object>();
                ctr.Tag = tagDic;
            }
            tagDic[tagKey] = tag;
        }
        /// <summary>
        /// 获取控件Tag
        /// </summary>
        /// <param name="ctr">控件</param>
        /// <param name="tagKey">数据键</param>
        public static object GetTag(this TreeListNode ctr, string tagKey)
        {
            var tagDic = ctr.Tag as Dictionary<string, object>;
            if (tagDic == null) return null;
            return tagDic.ContainsKey(tagKey) ? tagDic[tagKey] : null;
        }
        /// <summary>
        /// 获取控件Tag
        /// </summary>
        /// <param name="ctr">控件</param>
        /// <param name="tagKey">数据键</param>
        /// <typeparam name="T">Tag数据类型</typeparam>
        public static T GetTag<T>(this TreeListNode ctr, string tagKey)
        {
            var tagData = GetTag(ctr, tagKey);
            return tagData.CastTo<T>();
        }
        /// <summary>
        /// 获取控件Tag
        /// </summary>
        /// <param name="ctr">控件</param>
        /// <param name="tagKey">数据键</param>
        public static void RemoveTag(this TreeListNode ctr, string tagKey)
        {
            var tagDic = ctr.Tag as Dictionary<string, object>;
            if (tagDic == null) return;
            if (!tagDic.ContainsKey(tagKey)) return;
            tagDic.Remove(tagKey);
        }
    }
}
