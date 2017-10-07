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
using System.Linq;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;

namespace WitsWay.Utilities.Win.Helpers
{
    /// <summary>
    /// RepositoryComboBox辅助类
    /// </summary>
    public class RepositoryImageComboBoxHelper
    {
        /// <summary>
        /// 绑定对象列表到下拉框
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="ctr">下拉控件</param>
        /// <param name="datas">数据列表</param>
        /// <param name="displayFunc">取得显示文字方法</param>
        /// <param name="header">请选择等文字</param>
        /// <param name="idFunc"></param>
        public static void BindListToRepositoryCombo<T>(RepositoryItemImageComboBox ctr, List<T> datas, Func<T, string> displayFunc, Func<T, string> idFunc, string header = null) where T : class, new()
        {
            if (!string.IsNullOrEmpty(header))
            {
                ctr.Items.Add(header);
            }
            if (datas != null && datas.Count > 0)
            {
                var bindDatas = datas.Select(old => new IdTextData { Data = old, Text = displayFunc(old), Id = idFunc(old) }).ToList();
                ctr.Items.AddRange(bindDatas.Select(data => new ImageComboBoxItem(data.Text, data.Id)).ToArray());
            }
            ctr.TextEditStyle = TextEditStyles.DisableTextEditor;
        }
    }
}
