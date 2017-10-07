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
using System.Drawing;
using DevExpress.XtraBars;

namespace WitsWay.Utilities.Win.Helpers
{
    /// <summary>
    /// Bar辅助类
    /// </summary>
    public class BarHelper
    {
        /// <summary>
        /// 设置Toolbar的样式
        /// </summary>
        /// <param name="toolBar"></param>
        public static void SetToolBarStyle(Bar toolBar)
        {
            if (toolBar == null) return;
            toolBar.OptionsBar.AllowQuickCustomization = false;
            toolBar.OptionsBar.UseWholeRow = true;
            toolBar.OptionsBar.DrawDragBorder = false;
            if (toolBar.Manager != null) toolBar.Manager.AllowShowToolbarsPopup = false;
        }

        /// <summary>
        /// 设置用于填充空白的静态文本条的长度
        /// </summary>
        /// <param name="barStaticItem">静态文本条</param>
        /// <param name="length">长度</param>
        public static void SetBarStaticButtonLength(BarStaticItem barStaticItem, int length)
        {
            if (barStaticItem == null) return;
            if (length < 0) length = 0;
            barStaticItem.Appearance.Font = new Font("Tahoma", 1F, FontStyle.Regular, GraphicsUnit.Pixel);
            barStaticItem.Appearance.Options.UseFont = true;
            barStaticItem.Caption = new string(' ', length);
        }
    }
}
