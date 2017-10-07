using System;
using UserControl = System.Windows.Forms.UserControl;

namespace WitsWay.TempTests.GeneralQuery.Selectors
{

    /// <summary>
    /// 值选择器
    /// </summary>
    public interface IValueSelector
    {
        /// <summary>
        /// 键
        /// </summary>
        string SelectorKey { get; }
        /// <summary>
        /// 名称
        /// </summary>
        string SelectorName { get; }
        /// <summary>
        /// 选择方式
        /// </summary>
        SelectWays SelectWay { get; set; }
        /// <summary>
        /// 绑定值
        /// </summary>
        /// <param name="value"></param>
        void BindValues(string value);
        /// <summary>
        /// 取得控件
        /// </summary>
        /// <returns></returns>
        UserControl GetControl();
        /// <summary>
        /// 初始化选择器
        /// </summary>
        /// <param name="successAction">成功操作</param>
        /// <param name="cancelAction">取消操作</param>
        void InitSelector(ColumnDefinitionRow data, Action<ColumnDefinitionRow> successAction, Action cancelAction);

    }
}
