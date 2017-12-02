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
using System;
using System.Collections.Generic;
using System.Drawing;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.Utils;

namespace WitsWay.Utilities.Win.Helpers.StartScreen
{
    /// <summary>
    /// SkinAppearance
    /// </summary>
    public static class SkinAppearance
    {

        /// <summary>
        /// 字体缓存字典
        /// </summary>
        public static Dictionary<string, Font> fontDictionary = new Dictionary<string, Font>();

        /// <summary>
        /// FontFamily
        /// </summary>
        public const string FontFamily = "Segoe UI";

        /// <summary>
        /// Skin中的Label、Caption颜色
        /// </summary>
        public static readonly Color LabelAndCaptionInLayoutColor = CommonSkins.GetSkin(UserLookAndFeel.Default).Colors.GetColor(CommonColors.InfoText);

        /// <summary>
        /// 应用字体
        /// </summary>
        /// <param name="appearanceObject"></param>
        public static void ApplyFont(AppearanceObject appearanceObject)
        {
            ApplyFont(appearanceObject, false);
        }

        /// <summary>
        /// 应用字体
        /// </summary>
        public static void ApplyFont(AppearanceObject appearanceObject, bool changeFontStyle)
        {
            var font = appearanceObject.Font;
            var skinFont = GetSkinFont(font, changeFontStyle);
            appearanceObject.BeginUpdate();
            appearanceObject.Font = skinFont;
            appearanceObject.Options.UseFont = true;
            appearanceObject.EndUpdate();
        }

        /// <summary>
        /// 取得字体字典键
        /// </summary>
        private static string GetFontKey(this Font font)
        {
            return font + font.Style.ToString();
        }

        /// <summary>
        /// 取得FontFamily字体键
        /// </summary>
        private static string GetFontKeyForFontFamily(Font font, bool changeFontStyle)
        {
            var text = font.GetFontKey();
            if (changeFontStyle && !font.Bold)
            {
                text = text.Replace(Enum.GetName(typeof(FontStyle), FontStyle.Regular), Enum.GetName(typeof(FontStyle), FontStyle.Bold));
            }
            return text.Replace(font.Name, "Segoe UI");
        }

        /// <summary>
        /// 取得皮肤字体
        /// </summary>
        public static Font GetSkinFont(Font font)
        {
            return GetSkinFont(font, false);
        }

        /// <summary>
        /// 取得皮肤字体
        /// </summary>
        public static Font GetSkinFont(Font font, bool changeFontStyle)
        {
            var fontKeyForFontFamily = GetFontKeyForFontFamily(font, changeFontStyle);
            Font font2;
            if (!fontDictionary.TryGetValue(fontKeyForFontFamily, out font2))
            {
                var style = changeFontStyle ? FontStyle.Bold : font.Style;
                font2 = new Font("Segoe UI", font.Size, style, font.Unit, font.GdiCharSet, font.GdiVerticalFont);
                fontDictionary.Add(font2.GetFontKey(), font2);
            }
            return font2;
        }

    }
}
