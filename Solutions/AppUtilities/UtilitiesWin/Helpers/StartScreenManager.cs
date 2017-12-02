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
using System.Timers;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraWaitForm;
using WitsWay.Utilities.Win.Helpers.StartScreen;

namespace WitsWay.Utilities.Win.Helpers
{
    /// <summary>
    /// 启动画面管理器
    /// </summary>
    public class StartScreenManager
    {

        /// <summary>
        /// 关闭等待图
        /// </summary>
        public static void CloseWaitImage()
        {
            WaitTimer.Elapsed -= WaitTimerElapsed;
            WaitTimer.Stop();
            StartScreenTextPainter.Counter = 0;
            if (SplashScreenManager.Default != null)
            {
                SplashScreenManager.HideImage();
            }
        }

        /// <summary>
        /// 显示等待窗体
        /// </summary>
        public static void ShowWaitForm()
        {
            ShowWaitForm(null);
        }

        /// <summary>
        /// 显示等待窗体
        /// </summary>
        public static void ShowWaitForm(Form parentForm)
        {
            SplashScreenManager.ShowForm(parentForm, typeof(DemoWaitForm), true, false, true);
            SplashScreenManager.Default.SetWaitFormCaption(string.Empty);
            SplashScreenManager.Default.SetWaitFormDescription(string.Empty);
        }

        /// <summary>
        /// 显示加载中
        /// </summary>
        public static void ShowLoadingImage(Image img)
        {
            if (SplashScreenManager.Default != null) return;
            SplashScreenManager.ShowImage(img, true, true, new StartScreenTextPainter());
            WaitTimer.Elapsed += WaitTimerElapsed;
            WaitTimer.Start();
        }

        /// <summary>
        /// 显示启动图
        /// </summary>
        public static void ShowStartupImage(Image img)
        {
            SplashScreenManager.ShowImage(img, true, true, new StartScreenImagePainter());
        }

        /// <summary>
        /// 计时器
        /// </summary>
        private static readonly System.Timers.Timer WaitTimer = new System.Timers.Timer(500.0);
        private static void WaitTimerElapsed(object sender, ElapsedEventArgs e)
        {
            StartScreenTextPainter.Counter++;
            SplashScreenManager.Default.Invalidate();
        }

    }

}
