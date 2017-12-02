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
using DevExpress.Utils.Drawing;
using DevExpress.XtraSplashScreen;

namespace WitsWay.Utilities.Win.Helpers.StartScreen
{
    /// <summary>
    /// 加载中文字 图片绘制器
    /// </summary>
    public class StartScreenTextPainter : ICustomImagePainter
    {
        /// <summary>
        /// 绘制计数器
        /// </summary>
        internal static int Counter = 0;
        /// <summary>
        /// 默认字体
        /// </summary>
        private static readonly Font DefaultFont = new Font("Segoe UI", 6.75f, FontStyle.Bold);
        /// <summary>
        /// 字体刷
        /// </summary>
        private static readonly SolidBrush FontBrush = new SolidBrush(SkinAppearance.LabelAndCaptionInLayoutColor);

        /// <summary>
        /// 绘制加载文字
        /// </summary>
        void ICustomImagePainter.Draw(GraphicsCache cache, Rectangle bounds)
        {
            var text = "加载中";
            for (var i = 0; i < Counter % 4; i++)
            {
                text += '.';
            }
            cache.Graphics.DrawString(text, DefaultFont, FontBrush, 62f, 45f);
        }

    }
}