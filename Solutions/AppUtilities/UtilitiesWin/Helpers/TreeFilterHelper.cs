﻿#region License(Apache Version 2.0)
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
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;

namespace WitsWay.Utilities.Win.Helpers
{
    /// <summary>
    /// 添加入：王怀生
    /// 添加日期：2013年11月19日
    /// 说明：处理13.1控件引入后TreeList筛选问题
    /// </summary>
    public class TreeFilterHelper
    {

        #region [Field]

        private readonly TreeList _tree;
        private readonly TextEdit _edit;
        private readonly List<TreeListNode> _collapseNodes = new List<TreeListNode>();

        #endregion

        #region [Public]

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="tree">要实现筛选功能的TreeList控件</param>
        /// <param name="edit"></param>
        /// <param name="immediate"></param>
        public TreeFilterHelper(TreeList tree, TextEdit edit, bool immediate)
        {
            if (tree == null||edit == null) { return; }
            _tree = tree;
            _edit = edit;
            InitTreeList();
            if (immediate)
            {
                _edit.TextChanged += (sender, e) =>
                {
                    FilterText(_edit.Text.Trim());
                };
            }
        }

        private void InitTreeList()
        {
            _tree.OptionsBehavior.EnableFiltering = true;
            _tree.OptionsFilter.FilterMode = FilterMode.Extended;
            _tree.HideFindPanel();
        }

        /// <summary>
        /// 筛选文字
        /// </summary>
        /// <param name="text">要筛选的文字</param>
        public void FilterText(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                ClearFilter();
            }
            else
            {
                if (_collapseNodes.Count == 0)
                {
                    if (_tree.HasChildren)
                    {
                        AppendCollapseNodes(_tree.Nodes);
                    }
                }
                _tree.SuspendLayout();
                _tree.ExpandAll();
                _tree.ApplyFindFilter(text);
                _tree.ResumeLayout();
            }
        }

        private void AppendCollapseNodes(TreeListNodes nodes)
        {
            var eor = nodes.GetEnumerator();
            while (eor.MoveNext())
            {
                var node = eor.Current as TreeListNode;
                if (node == null) { continue; }
                if (!node.Expanded)
                {
                    _collapseNodes.Add(node);
                }
                if (node.HasChildren)
                {
                    AppendCollapseNodes(node.Nodes);
                }
            }
        }
       
        /// <summary>
        /// 清除筛选
        /// </summary>
        public void ClearFilter()
        {
            _tree.ApplyFindFilter(string.Empty);
            if (_collapseNodes == null) return;
            _tree.SuspendLayout();
            _collapseNodes.ForEach(one => one.Expanded = false);
            _collapseNodes.Clear();
            _tree.ResumeLayout();
        }

        #endregion

    }
}
