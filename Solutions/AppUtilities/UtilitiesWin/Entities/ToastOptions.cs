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
using DevExpress.Utils.Win;

namespace WitsWay.Utilities.Win.Entities
{
    /// <summary>
    /// 提醒信息选项
    /// </summary>
    public class ToastOptions
    {
        /// <summary>
        /// 提醒信息选项
        /// </summary>
        public ToastOptions()
        {
            Anchor = PopupToolWindowAnchor.Top;
            AnimationKind = PopupToolWindowAnimation.Slide;
            CloseOnOuterClick = false;
            PositionX = PositionY = 0;
        }
        /// <summary>
        /// 消息显示位置
        /// </summary>
        public PopupToolWindowAnchor Anchor { get; set; }
        /// <summary>
        /// 动画类型
        /// </summary>
        public PopupToolWindowAnimation AnimationKind { get; set; }
        /// <summary>
        /// 外部点击关闭
        /// </summary>
        public bool CloseOnOuterClick { get; set; }
        /// <summary>
        /// X坐标位置（左上角）
        /// </summary>
        public int PositionX { get; set; }
        /// <summary>
        ///  Y坐标位置（左上角）
        /// </summary>
        public int PositionY { get; set; }
        /// <summary>
        /// Anchor为Manual时是使用的自定义位置
        /// </summary>
        public Point CustomPosition => new Point(PositionX, PositionY);
    }
}
