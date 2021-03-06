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
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using WitsWay.Utilities.Supports;
using WitsWay.Utilities.Win.Extends;

namespace WitsWay.Utilities.Win.Helpers
{

    /// <summary>
    /// GridView鼠标双击辅助类
    /// </summary>
    public class GridControlDoubleClickHelper<T> where T : class, IKey
    {

        private readonly Dictionary<string, Action<T>> _actionDic = new Dictionary<string, Action<T>>();
        /// <summary>
        /// 获取Action
        /// </summary>
        /// <param name="key">GridView的Name作为存储键</param>
        /// <returns>Action实例</returns>
        public Action<T> GetAction(string key)
        {
            return _actionDic.ContainsKey(key) ? _actionDic[key] : null;
        }
        #region [BindPopup]

        /// <summary>
        /// 绑定Grid双击事件
        /// </summary>
        /// <param name="view">GridView</param>
        /// <param name="action">操作</param>
        public void BindDoubleClick(GridView view, Action<T> action)
        {
            if (view == null || action == null) return;
            var key = view.Name;
            if (_actionDic.ContainsKey(key)) return;
            _actionDic[key] = action;
            view.MouseDown += GridViewMouseDown;
        }

        private void GridViewMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Clicks < 2) return;
            if (e.Button != MouseButtons.Left) return;
            var gridView = sender as GridView;
            var hi = gridView?.CalcHitInfo(e.Location);
            if (hi == null || !hi.InRow) return;
            var data = gridView.GetFocusData<T>();
            if (data == null) return;
            //处理Action
            var helper = gridView.GetTag<GridControlDoubleClickHelper<T>>(WinUtilityConsts.GridViewDoubleClickHelperTagKey);
            if (helper == null) return;
            var action = helper.GetAction(gridView.Name);
            action(data);
        }

        /// <summary>
        /// 解绑行双击
        /// </summary>
        /// <param name="view">GridView控件</param>
        public void UnbindDoubleClick(GridView view)
        {
            if (view == null) return;
            var key = view.Name;
            if (!_actionDic.ContainsKey(key)) return;
            _actionDic.Remove(key);
            view.MouseDown -= GridViewMouseDown;
        }

        #endregion

    }
}