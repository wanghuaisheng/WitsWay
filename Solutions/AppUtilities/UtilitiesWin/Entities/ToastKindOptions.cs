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
using WitsWay.Utilities.Win.Enums;
using WitsWay.Utilities.Win.Properties;

namespace WitsWay.Utilities.Win.Entities
{
    /// <summary>
    /// 提醒信息类型选项
    /// </summary>
    public class ToastKindOptions
    {
        /// <summary>
        /// 提醒信息类型选项
        /// </summary>
        public ToastKindOptions()
        {
            FontColor = Color.Black;
            BackColor = Color.LightGray;
        }
        /// <summary>
        /// 提醒信息类型选项
        /// </summary>
        /// <param name="kind"></param>
        public ToastKindOptions(ToastKinds kind)
        {
            switch (kind)
            {
                case ToastKinds.Success:
                {
                    FontColor = Color.SeaGreen;
                    BackColor = Color.PaleGreen;
                    IconImage = Resources.LightGreen;
                    break;
                }
                case ToastKinds.Error:
                {
                    FontColor = Color.DarkRed;
                    BackColor = Color.LightCoral;
                    IconImage = Resources.LightRed;
                    break;
                }
                case ToastKinds.Info:
                {
                    FontColor = Color.DodgerBlue;
                    BackColor = Color.Aqua;
                    IconImage = Resources.LightBlue;
                    break;
                }
                case ToastKinds.Warning:
                {
                    FontColor = Color.Coral;
                    BackColor = Color.Gold;
                    IconImage = Resources.LightYellow;
                    break;
                }
                default:
                {
                    FontColor = Color.Black;
                    BackColor = Color.LightGray;
                    break;
                }
            }
        }
        /// <summary>
        /// 文字颜色
        /// </summary>
        public Color FontColor { get; set; }
        /// <summary>
        /// 背景色
        /// </summary>
        public Color BackColor { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        public Bitmap IconImage { get; set; }
        
    }
}
