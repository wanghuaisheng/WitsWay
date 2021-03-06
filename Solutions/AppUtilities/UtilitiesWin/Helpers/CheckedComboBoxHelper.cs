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
using System.Linq;
using System.Windows.Forms;
using DevExpress.Utils.Win;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using WitsWay.Utilities.Attributes;
using WitsWay.Utilities.Extends;
using ItemCheckEventHandler = DevExpress.XtraEditors.Controls.ItemCheckEventHandler;

namespace WitsWay.Utilities.Win.Helpers
{
    /// <summary>
    /// 下拉复选控件辅助类
    /// </summary>
    public class CheckedComboBoxHelper
    {

        /// <summary>
        /// 绑定对象列表到下拉复选框
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="ctr">下拉控件</param>
        /// <param name="datas">数据列表</param>
        /// <param name="displayFunc">取得显示文字方法</param>
        public static void BindListToCombo<T>(CheckedComboBoxEdit ctr, List<T> datas, Func<T, string> displayFunc)
        {
            if (datas != null && datas.Count > 0)
            {
                var bindDatas = datas.Select(old => new IdTextData { Data = old, Text = displayFunc(old) }).ToList();
                foreach (var item in bindDatas)
                {
                    ctr.Properties.Items.Add(item, false);
                }
            }
            ctr.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
        }

        /// <summary>
        /// 绑定枚举到下拉复选框
        /// </summary>
        /// <param name="ctr">控件</param>
        /// <param name="header">请选择等文字</param>
        /// <param name="except">不绑定项</param>
        /// <typeparam name="T">枚举类型</typeparam>
        public static void BindEnumToCombo<T>(CheckedComboBoxEdit ctr, string header = null, List<T> except = null) where T : struct
        {
            var t = typeof(T);
            if (!t.IsEnum)
            {
                throw new ArgumentException(t.FullName + "不是枚举类型");
            }
            if (!string.IsNullOrEmpty(header))
            {
                ctr.Properties.Items.Add(header);
            }
            var eds = EnumFieldAttribute.GetFieldInfos(typeof(T));

            var exceptValue = new List<int>();
            if (except != null && except.Count > 0)
                exceptValue = except.Select(old => old.CastTo<int>()).ToList();

            if (eds != null && eds.Count > 0)
                foreach (var ed in eds)
                    if (!exceptValue.Contains(ed.EnumValue))
                        ctr.Properties.Items.Add(ed, false);

            ctr.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
        }

        /// <summary>
        /// 设置选中的枚举
        /// </summary>
        /// <typeparam name="T">枚举类型</typeparam>
        /// <param name="ctr">控件</param>
        /// <param name="data">选中的枚举列表</param>
        public static void SetSelectEnum<T>(CheckedComboBoxEdit ctr, List<T> data) where T : struct
        {
            var t = typeof(T);
            if (!t.IsEnum)
            {
                throw new ArgumentException(t.FullName + "不是枚举类型");
            }

            var enumValues = data.Cast<int>();
            var checkedListBoxItemList = ctr.Properties.Items.OfType<CheckedListBoxItem>().ToList();
            // 先将所有项设置为为选中
            checkedListBoxItemList.ForEach(item => { item.CheckState = CheckState.Unchecked; });

            // 设置应该选中的项
            checkedListBoxItemList.Where(item => item.Value is EnumFieldAttribute &&
                    enumValues.Contains(((EnumFieldAttribute)item.Value).EnumValue))
            .ToList()
            .ForEach(item => { item.CheckState = CheckState.Checked; });
        }

        /// <summary>
        /// 设置选中项
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="ctr">控件</param>
        /// <param name="data">数据</param>
        /// <param name="displayFunc"></param>
        public static void SetSelectData<T>(CheckedComboBoxEdit ctr, List<T> data, Func<T, string> displayFunc)
        {
            foreach (var item in ctr.Properties.Items)
            {
                var boxItem = item as CheckedListBoxItem;
                var itd = boxItem.Value as IdTextData;
                var chkDatas = data.Select(old => new IdTextData { Data = old, Text = displayFunc(old) }).ToList();
                var itnew = chkDatas.Find(old => ReferenceEquals(old.Data, itd.Data));
                boxItem.CheckState = itnew != null ? CheckState.Checked : CheckState.Unchecked;
            }
        }

        /// <summary>
        /// 获取选中项
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="ctr">CheckedComboBoxEdit控件</param>
        /// <returns>选中数据</returns>
        public static List<T> GetSelectData<T>(CheckedComboBoxEdit ctr) where T : class
        {
            return GetSelectedDataFromItems<T>(ctr.Properties.Items);
        }

        /// <summary>
        /// 获取选中项
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="ctr">CheckedListBoxControl控件</param>
        /// <returns>选中数据</returns>
        public static List<T> GetSelectData<T>(CheckedListBoxControl ctr) where T : class
        {
            return GetSelectedDataFromItems<T>(ctr.Items);
        }

        private static List<T> GetSelectedDataFromItems<T>(CheckedListBoxItemCollection items) where T : class
        {
            var datas = new List<T>();
            foreach (var item in items)
            {
                var boxItem = item as CheckedListBoxItem;

                if (boxItem.CheckState == CheckState.Checked)
                {
                    var data = boxItem.Value as IdTextData;
                    if (data != null)
                        datas.Add(data.GetData<T>());
                }
            }
            return datas;
        }

        /// <summary>
        /// 获取选中枚举项
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="ctr">控件</param>
        /// <returns>选中数据</returns>
        public static List<T> GetSelectEnum<T>(CheckedComboBoxEdit ctr) where T : struct
        {
            var t = typeof(T);
            if (!t.IsEnum)
            {
                throw new ArgumentException(t.FullName + "不是枚举类型");
            }

            return GetSelectEnum<T>(ctr.Properties.Items);
        }

        /// <summary>
        /// 获取选中枚举项
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="ctr">控件</param>
        /// <returns>选中数据</returns>
        public static List<T> GetSelectEnum<T>(CheckedListBoxControl ctr) where T : struct
        {
            var t = typeof(T);
            if (!t.IsEnum)
            {
                throw new ArgumentException(t.FullName + "不是枚举类型");
            }

            return GetSelectEnum<T>(ctr.Items);
        }

        private static List<T> GetSelectEnum<T>(CheckedListBoxItemCollection items) where T : struct
        {
            return items.OfType<CheckedListBoxItem>()
                            .Where(item => item.CheckState == CheckState.Checked)
                            .Select(item => item.Value)
                            .OfType<EnumFieldAttribute>()
                            .Select(ed => ed.EnumValue)
                            .Cast<T>()
                            .ToList();
        }

        /// <summary>
        /// 注册CheckedComboBoxEdit的ItemChecked事件
        /// </summary>
        /// <param name="comboBox">CheckedComboBoxEdit</param>
        /// <param name="itemCheckCallback">ItemChecked事件回调</param>
        public static void RegisterItemCheckCallback(CheckedComboBoxEdit comboBox, ItemCheckEventHandler itemCheckCallback)
        {
            comboBox.Properties.Popup += (sender, e) =>
                {
                    var popupControl = GetCheckedListBoxControl(sender as IPopupControl);
                    if (popupControl == null)
                        return;

                    popupControl.ItemCheck -= itemCheckCallback;
                    popupControl.ItemCheck += itemCheckCallback;
                };
        }

        private static CheckedListBoxControl GetCheckedListBoxControl(IPopupControl popup)
        {
            if (popup == null)
                return null;

            var popupControl = popup.PopupWindow.Controls[3].Controls[0] as CheckedListBoxControl;
            if (popupControl == null)
                return null;
            return popupControl;
        }

        /// <summary>
        /// 设置CheckedBoxEdit中包含的CheckedListBoxControl
        /// </summary>
        /// <param name="checkedComboBoxEdit"></param>
        /// <param name="configAction"></param>
        public static void ConfigListControl(CheckedComboBoxEdit checkedComboBoxEdit, Action<CheckedListBoxControl> configAction)
        {
            checkedComboBoxEdit.Properties.Popup += (sender, e) =>
            {
                var popupControl = GetCheckedListBoxControl(sender as IPopupControl);

                if (popupControl != null)
                {
                    configAction(popupControl);
                }
            };
        }
    }
}