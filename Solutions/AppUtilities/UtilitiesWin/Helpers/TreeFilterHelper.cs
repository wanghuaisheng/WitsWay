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
////using System.Drawing;
////using DevExpress.XtraEditors.Drawing;
////using DevExpress.XtraEditors.ViewInfo;
////using DevExpress.XtraTreeList;
////using DevExpress.XtraTreeList.Columns;
////using DevExpress.XtraTreeList.Nodes;
////using DevExpress.XtraEditors;
////using System;
////using DotNetSoft.Utilities.Extends;

////namespace DotNetSoft.Utilities.Win.Helpers
////{
////    /// <summary>
////    /// 添加入：王怀生
////    /// 添加日期：2012年8月22日
////    /// 说明：实现TreeList的筛选+高亮显示
////    /// </summary>
////    public class TreeFilterHelper
////    {

////        #region [Field]

////        TreeList _tree;
////        TextEdit _edit;
////        string _searchText = string.Empty;

////        #endregion

////        #region [Public]
////        /// <summary>
////        /// 构造函数
////        /// </summary>
////        /// <param name="tree">要实现筛选功能的TreeList控件</param>
////        /// <param name="edit"></param>
////        /// <param name="immediate"></param>
////        public TreeFilterHelper(TreeList tree, TextEdit edit, bool immediate)
////        {
////            if (tree == null) { return; }
////            if (edit == null) { return; }
////            _tree = tree;
////            _edit = edit;
////            InitTreeList();
////            if (immediate)
////            {
////                _edit.TextChanged += (object sender, EventArgs e) => 
////                { 
////                    FilterText(_edit.Text.Trim());
////                };
////            }
////        }
////        /// <summary>
////        /// 筛选文字
////        /// </summary>
////        /// <param name="text">要筛选的文字</param>
////        public void FilterText(string text)
////        {
////            _searchText = text;
////            _tree.FilterNodes();
////            _tree.InvalidateNodes();
////        }
////        /// <summary>
////        /// 清除筛选
////        /// </summary>
////        public void ClearFilter()
////        {
////            _searchText = string.Empty;
////            _tree.FilterNodes();
////            _tree.InvalidateNodes();
////        }

////        #endregion


////        #region [Filter]

////        private void InitTreeList()
////        {
////            _tree.OptionsBehavior.EnableFiltering = true;
////            _tree.FilterNode += OnFilterNode;
////            _tree.CustomDrawNodeCell += OnCustomDrawNodeCell;
////        }


////        private void OnCustomDrawNodeCell(object sender, CustomDrawNodeCellEventArgs e)
////        {
////            if (!string.IsNullOrEmpty(_searchText))
////            {
////                int index = e.CellText.ToLower().IndexOf(_searchText.ToLower());
////                if (index >= 0)
////                {
////                    TextEditViewInfo viewInfo = e.EditViewInfo as TextEditViewInfo;
////                    if (viewInfo == null) return;
////                    e.Appearance.FillRectangle(e.Cache, e.Bounds);
////                    e.Cache.Paint.DrawMultiColorString(e.Cache, viewInfo.MaskBoxRect, e.CellText, _searchText,
////                        e.Appearance, Color.Black, Color.FromArgb(255, 210, 0), false, index);
////                    DrawButtons(e);
////                    e.Handled = true;
////                }
////            }
////        }

////        private void DrawButtons(CustomDrawNodeCellEventArgs e)
////        {
////            ButtonEditViewInfo viewInfo = e.EditViewInfo as ButtonEditViewInfo;
////            if (viewInfo != null)
////            {
////                foreach (EditorButtonObjectInfoArgs args in viewInfo.LeftButtons)
////                {
////                    args.Cache = e.Cache;
////                    viewInfo.EditorButtonPainter.DrawObject(args);
////                }
////                foreach (EditorButtonObjectInfoArgs args in viewInfo.RightButtons)
////                {
////                    args.Cache = e.Cache;
////                    viewInfo.EditorButtonPainter.DrawObject(args);
////                }
////            }
////        }

////        private void OnFilterNode(object sender, FilterNodeEventArgs e)
////        {
////            if (!Find(e.Node))
////            {
////                e.Node.Visible = false;
////                e.Handled = true;
////            }
////            else
////            {
////                SetNodeShow(e.Node);
////                e.Handled = true;
////            }
////        }

////        private void SetNodeShow(TreeListNode node)
////        {
////            node.Visible = true;
////            if (node.ParentNode != null)
////            {
////                SetNodeShow(node.ParentNode);
////            }
////        }

////        private bool Find(TreeListNode node)
////        {
////            if (_searchText.Equals(string.Empty)) return true;
////            foreach (TreeListColumn column in _tree.VisibleColumns)
////            {
////                if (ContainsSearchText(column, node))
////                {
////                    return true;
////                }
////            }
////            return false;
////        }

////        private bool ContainsSearchText(TreeListColumn column, TreeListNode node)
////        {
////            if (column == null) return false;
////            string txt = node.GetDisplayText(column).ToLower();
////            //string pinYin=txt.GetChineseInitial().ToLower();
////            return txt.Contains(_searchText.ToLower());//||pinYin.Contains(_searchText.ToLower());
////        }

////        #endregion
////    }
////}




























////using System.Drawing;
////using DevExpress.XtraEditors.Drawing;
////using DevExpress.XtraEditors.ViewInfo;
////using DevExpress.XtraTreeList;
////using DevExpress.XtraTreeList.Columns;
////using DevExpress.XtraTreeList.Nodes;
////using DevExpress.XtraEditors;
////using System;
////using DotNetSoft.Utilities.Extends;
////using DevExpress.XtraTreeList.Nodes.Operations;
////using System.Collections.Generic;
////using System.Linq;

////namespace DotNetSoft.Utilities.Win.Helpers
////{
////    /// <summary>
////    /// 添加入：王怀生
////    /// 添加日期：2013年11月19日
////    /// 说明：处理13.1控件引入后TreeList筛选问题
////    /// </summary>
////    public class TreeFilterHelper
////    {

////        #region [Field]

////        TreeList _tree;
////        TextEdit _edit;

////        #endregion

////        #region [Public]
////        /// <summary>
////        /// 构造函数
////        /// </summary>
////        /// <param name="tree">要实现筛选功能的TreeList控件</param>
////        /// <param name="edit"></param>
////        /// <param name="immediate"></param>
////        public TreeFilterHelper(TreeList tree, TextEdit edit, bool immediate)
////        {
////            if (tree == null) { return; }
////            if (edit == null) { return; }
////            _tree = tree;
////            _edit = edit;
////            InitTreeList();
////            if (immediate)
////            {
////                _edit.TextChanged += (object sender, EventArgs e) =>
////                {
////                    _tree.SuspendLayout();
////                    FilterNodeOperation operation = new FilterNodeOperation(_edit.EditValue != null ? _edit.EditValue.ToString() : "");
////                    _tree.NodesIterator.DoOperation(operation);
////                    _tree.ResumeLayout();
////                    //FilterText(_edit.Text.Trim());
////                };
////            }
////            //_tree.FilterNode += OnFilterNode;
////        }



////        class FilterNodeOperation : TreeListOperation
////        {
////            string pattern;

////            public FilterNodeOperation(string _pattern)
////            { pattern = _pattern; }

////            public override void Execute(TreeListNode node)
////            {
////                if (NodeContainsPattern(node, pattern))
////                {
////                    node.Visible = true;
////                    if (node.ParentNode != null)
////                        node.ParentNode.Visible = true;
////                }
////                else
////                    node.Visible = false;
////            }

////            bool NodeContainsPattern(TreeListNode node, string pattern)
////            {
////                foreach (TreeListColumn col in node.TreeList.Columns)
////                    if (node.GetValue(col).ToString().Contains(pattern))
////                        return true;
////                return false;
////            }
////        }

////        //private void OnFilterNode(object sender, FilterNodeEventArgs e)
////        //{
////        //    List<TreeListColumn> filteredColumns = e.Node.TreeList.Columns.Cast<TreeListColumn>(
////        //        ).Where(c => c.FilterInfo.AutoFilterRowValue != null).ToList();
////        //    if (filteredColumns.Count == 0) return;
////        //    e.Handled = true;
////        //    e.Node.Visible = filteredColumns.Any(c => IsNodeMatchFilter(e.Node, c));
////        //}

////        //static bool IsNodeMatchFilter(TreeListNode node, TreeListColumn column)
////        //{
////        //    string filterValue = column.FilterInfo.AutoFilterRowValue.ToString();
////        //    if (node.GetDisplayText(column).StartsWith(filterValue)) return true;
////        //    foreach (TreeListNode n in node.Nodes)
////        //        if (IsNodeMatchFilter(n, column)) return true;
////        //    return false;
////        //}



////        ////private void applyFilterButton_Click(object sender, EventArgs e)
////        ////{
////        ////    FilterNodeOperation operation = new FilterNodeOperation(textEdit1.EditValue != null ? textEdit1.EditValue.ToString() : "");
////        ////    treeList1.NodesIterator.DoOperation(operation);
////        ////}

////        ////class FilterNodeOperation : TreeListOperation
////        ////{
////        ////    string pattern;

////        ////    public FilterNodeOperation(string _pattern)
////        ////    { pattern = _pattern; }

////        ////    public override void Execute(TreeListNode node)
////        ////    {
////        ////        if (NodeContainsPattern(node, pattern))
////        ////        {
////        ////            node.Visible = true;
////        ////            if (node.ParentNode != null)
////        ////                node.ParentNode.Visible = true;
////        ////        }
////        ////        else
////        ////            node.Visible = false;
////        ////    }

////        ////    bool NodeContainsPattern(TreeListNode node, string pattern)
////        ////    {
////        ////        foreach (TreeListColumn col in node.TreeList.Columns)
////        ////            if (node.GetValue(col).ToString().Contains(pattern))
////        ////                return true;
////        ////        return false;
////        ////    }
////        ////}


////        private void InitTreeList()
////        {
////            _tree.OptionsBehavior.EnableFiltering = true;
////            _tree.OptionsFilter.FilterMode = FilterMode.Smart;
////            _tree.OptionsFilter.AllowColumnMRUFilterList = true;
////            _tree.OptionsFilter.AllowFilterEditor = true;
////            _tree.OptionsFilter.AllowMRUFilterList = true;
////            _tree.OptionsFilter.ShowAllValuesInFilterPopup = true;
////            _tree.HideFindPanel();
////        }

////        /// <summary>
////        /// 筛选文字
////        /// </summary>
////        /// <param name="text">要筛选的文字</param>
////        public void FilterText(string text)
////        {
////            _tree.ApplyFindFilter(text);
////        }

////        /// <summary>
////        /// 清除筛选
////        /// </summary>
////        public void ClearFilter()
////        {
////            _tree.ApplyFindFilter(string.Empty);
////        }

////        #endregion

////    }
////}
