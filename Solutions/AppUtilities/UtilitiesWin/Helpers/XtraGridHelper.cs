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
using System.Linq;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;

namespace WitsWay.Utilities.Win.Helpers
{
    /// <summary>
    /// XtraGrid辅助类
    /// </summary>
    public class XtraGridHelper
    {

        /// <summary>
        /// 预处理Filter字符串，这里主要是因为Grid控件本身的Bug导致的
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string PreHandleFiterText(string text)
        {
            if (string.IsNullOrEmpty(text)) return string.Empty;
            text = text.Trim();
            if (!text.Contains('-') && !text.Contains('+')) return text;
            text = text.Replace("-", "");
            text = text.Replace("+", "");
            return text;
        }

        /// <summary>
        /// 获取XtraGrid按钮
        /// </summary>
        /// <param name="caption">文字</param>
        /// <param name="tooltip">提示</param>
        /// <param name="ctrName">控件名</param>
        /// <param name="icon">图标</param>
        /// <returns><see cref="RepositoryItemButtonEdit"/>控件</returns>
        public static RepositoryItemButtonEdit GetRepositoryButton(string caption, string tooltip, string ctrName, Image icon)
        {
            return GetRepositoryButton(caption, tooltip, ctrName, icon, true);
        }

        /// <summary>
        /// 获取XtraGrid按钮
        /// </summary>
        /// <param name="caption">标题</param>
        /// <param name="tooltip">提示</param>
        /// <param name="ctrName">控件名</param>
        /// <param name="icon">控件图标</param>
        /// <param name="enable">控件是否可用</param>
        /// <returns><see cref="RepositoryItemButtonEdit"/>控件</returns>
        public static RepositoryItemButtonEdit GetRepositoryButton(string caption, string tooltip, string ctrName, Image icon, bool enable)
        {
            var editor = new RepositoryItemButtonEdit();
            editor.Buttons.Clear();
            editor.AutoHeight = false;
            var apperenceObj = new SerializableAppearanceObject();
            apperenceObj.Options.UseTextOptions = true;
            apperenceObj.TextOptions.HAlignment = HorzAlignment.Center;
            editor.Buttons.AddRange(new[] {
                    new EditorButton(ButtonPredefines.Glyph, caption, -1, enable, true, false, ImageLocation.MiddleLeft,icon, new KeyShortcut(Keys.None), apperenceObj, tooltip, null, null, true)});
            editor.Name = ctrName;
            editor.TextEditStyle = TextEditStyles.HideTextEditor;
            return editor;
        }

    }
}