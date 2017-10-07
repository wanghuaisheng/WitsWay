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
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;

namespace WitsWay.Utilities.Win.Controls
{
    /// <summary>
    /// 地区信息导出模型
    /// </summary>
    public class BasicExportModel<T> where T:class
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string TextTitle { get; set; }
        /// <summary>
        /// 数据表头
        /// </summary>
        public Dictionary<string, string> DataHead
        {
            get;
            set;
        }
        /// <summary>
        /// 数据
        /// </summary>
        public List<T> Data { get; set; }
        /// <summary>
        /// 页脚
        /// </summary>
        public string TextFoot { get; set; }
        /// <summary>
        /// 页眉
        /// </summary>
        public string TextHead { get; set; }

        /// <summary>
        /// 设置数据源标头
        /// </summary>
        /// <param name="gridView"></param>
        public void SetDataHead(GridView gridView)
        {
            DataHead = new Dictionary<string, string>();
            foreach (GridColumn item in gridView.VisibleColumns)
            {
                DataHead.Add(item.FieldName, item.Caption);
            }
        }
    }
}
