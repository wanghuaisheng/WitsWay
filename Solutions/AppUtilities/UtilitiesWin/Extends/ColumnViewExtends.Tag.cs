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

using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.Utils.Controls;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using WitsWay.Utilities.Extends;

namespace WitsWay.Utilities.Win.Extends
{
    /// <summary>
    /// ColumnView辅助类
    /// </summary>
    public static partial class ColumnViewExtends
    {

        /// <summary>
        /// 设置控件Tag
        /// </summary>
        public static void SetTag(this ColumnView ctr, string tagKey, object tag)
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
        public static object GetTag(this ColumnView ctr, string tagKey)
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
        public static T GetTag<T>(this ColumnView ctr, string tagKey)
        {
            var tagData = GetTag(ctr, tagKey);
            return tagData.CastTo<T>();
        }

        /// <summary>
        /// 获取控件Tag
        /// </summary>
        /// <param name="ctr">控件</param>
        /// <param name="tagKey">数据键</param>
        public static void RemoveTag(this ColumnView ctr, string tagKey)
        {
            var tagDic = ctr.Tag as Dictionary<string, object>;
            if (tagDic == null) return;
            if (!tagDic.ContainsKey(tagKey)) return;
            tagDic.Remove(tagKey);
        }

    }
}
