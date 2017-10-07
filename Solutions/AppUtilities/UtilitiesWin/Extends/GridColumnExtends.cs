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
using DevExpress.Utils;
using DevExpress.XtraGrid.Columns;

namespace WitsWay.Utilities.Win.Extends
{
    /// <summary>
    /// XtraGrid辅助类
    /// </summary>
    public static class GridColumnExtends
    {

        /// <summary>
        /// 固定列宽
        /// </summary>
        /// <param name="column">列</param>
        /// <param name="width">宽度</param>
        public static void FixColumnWidth(this GridColumn column, int width)
        {
            column.MaxWidth = column.MinWidth = column.Width = width;
        }

        /// <summary>
        /// 固定列宽
        /// </summary>
        /// <param name="column">列</param>
        /// <param name="width">宽度</param>
        public static void AutoColumnWidth(this GridColumn column, int width)
        {
            column.MaxWidth = 0;
            column.MinWidth = 0;
            column.Width = width;
        }

        /// <summary>
        /// 居中文字
        /// </summary>
        /// <param name="column">列</param>
        /// <param name="centerHeader">列头居中否</param>
        /// <param name="centerCell">列单元格居中否</param>
        public static void CenterText(this GridColumn column, bool centerHeader, bool centerCell)
        {
            if (centerCell)
            {
                column.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            }
            if (centerHeader)
            {
                column.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            }
        }

    }
}
