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
    /// 自定义启动图绘制器
    /// </summary>
    public class StartScreenImagePainter : ICustomImagePainter
    {
        /// <summary>
        /// 默认字体
        /// </summary>
        private static readonly Font DefaultFont = new Font("Segoe UI", 8.25f);
        /// <summary>
        /// 字体笔刷
        /// </summary>
        private static readonly SolidBrush FontBrush = new SolidBrush(Color.FromArgb(242, 242, 242));
        /// <summary>
        /// 绘制信息
        /// </summary>
        public void Draw(GraphicsCache cache, Rectangle bounds)
        {
            cache.Graphics.DrawString("®版本", DefaultFont, FontBrush, 97f, 400f);
            cache.Graphics.DrawString("Copyright ® 2000-2017 WitsWay Inc.", DefaultFont, FontBrush, 97f, 430f);
        }

    }
}
