using System.Drawing;
using DevExpress.Utils.Win;

namespace WitsWay.TempTests.ControlsTest.ToastUC
{

    /// <summary>
    /// 提醒信息选项
    /// </summary>
    public class ToastMessageOptions
    {
        public ToastMessageOptions()
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
