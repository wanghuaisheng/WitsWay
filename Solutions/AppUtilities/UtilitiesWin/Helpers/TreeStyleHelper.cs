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
using System.Linq;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;

namespace WitsWay.Utilities.Win.Helpers
{

    /// <summary>
    /// XtraTree样式辅助类
    /// </summary>
    public class TreeStyleHelper
    {
        /// <summary>
        /// 设置TreeList样式
        /// </summary>
        /// <param name="tree">TreeList控件</param>
        public static void SetXtraTreeStyle(TreeList tree)
        {
            SetXtraTreeStyle(tree, false);
        }
        /// <summary>
        /// 设置TreeList样式
        /// </summary>
        /// <param name="tree">TreeList控件</param>
        /// <param name="editable"></param>
        public static void SetXtraTreeStyle(TreeList tree, bool editable)
        {
            tree.OptionsBehavior.AllowExpandOnDblClick = true;
            tree.OptionsBehavior.Editable = editable;
        }

        /// <summary>
        /// 设置TreeList样式
        /// </summary>
        /// <param name="tree">TreeList控件</param>
        /// <param name="allowEditColumn">允许编辑列</param>
        public static void SetXtraTreeStyle(TreeList tree, params TreeListColumn[] allowEditColumn)
        {
            tree.OptionsBehavior.AllowExpandOnDblClick = true; tree.OptionsBehavior.Editable = false;
            if (allowEditColumn != null && allowEditColumn.Length > 0)
            {
                tree.OptionsBehavior.Editable = true;
                foreach (TreeListColumn col in tree.Columns)
                {
                    if (allowEditColumn.Contains(col))
                    {
                        col.OptionsColumn.AllowEdit = true;
                    }
                    else
                    {
                        col.OptionsColumn.AllowEdit = false;
                    }
                }
            }
        }

        /// <summary>
        /// 设置树为只读树，只允许选择行，不允许选择单元格
        /// </summary>
        /// <param name="tree">TreeList控件</param>
        public static void SetAsReadOnly(TreeList tree)
        {
            tree.OptionsBehavior.Editable = false;
            tree.OptionsSelection.EnableAppearanceFocusedCell = false;
            tree.OptionsView.FocusRectStyle=DrawFocusRectStyle.None;
        }

    }
}