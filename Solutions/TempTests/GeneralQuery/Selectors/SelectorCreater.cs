using System;
using System.Collections.Generic;

namespace WitsWay.TempTests.GeneralQuery.Selectors
{

    /// <summary>
    /// 选择器创建者
    /// </summary>
    public class SelectorCreater
    {
        private static Dictionary<string, IValueSelector> _selectors = new Dictionary<string, IValueSelector>();

        /// <summary>
        /// 获取选择器
        ///  </summary>
        /// <param name="key">键</param>
        /// <param name="operate">操作</param>
        /// <returns></returns>
        public static IValueSelector GetSelector(ColumnDefinitionRow data, Action<ColumnDefinitionRow> successAction, Action cancelAction)
        {
            var key = data.Input;
            var operate = data.SelectedOperate;
            var cacheKey = string.Format("{0}{1}", key, operate);
            if (_selectors.ContainsKey(cacheKey))
            {
                var cacheSelector = _selectors[cacheKey];
                cacheSelector.InitSelector(data, successAction, cancelAction);
                return cacheSelector;
            }
            var selector = key == "spin" ? new SpinEditor() as IValueSelector : new UserSelector();
            selector.InitSelector(data, successAction, cancelAction);
            _selectors[cacheKey] = selector;
            return selector;
        }

    }
}
