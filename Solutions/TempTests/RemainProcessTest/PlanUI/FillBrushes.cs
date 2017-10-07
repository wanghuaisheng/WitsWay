using System.Drawing;
using System.Drawing.Drawing2D;
using WitsWay.TempTests.RemainProcessTest.PlanUI.Enums;

namespace WitsWay.TempTests.RemainProcessTest.PlanUI
{
    public class FillBrushes
    {

        /// <summary>
        /// 通过绘制板件类型 获取笔刷
        /// </summary>
        /// <param name="bType">笔刷类型</param>
        /// <returns>笔刷实例</returns>
        public static Brush GetBrush(DrawUnitKind bType)
        {
            Brush b;
            switch (bType)
            {
                case DrawUnitKind.UnitNotProcess:
                    b = new HatchBrush(HatchStyle.Divot, Color.Gray, Color.Gainsboro);
                    break;
                case DrawUnitKind.UnitProcessing:
                    b = new HatchBrush(HatchStyle.Divot, Color.LightGreen, Color.Gainsboro);
                    break;
                case DrawUnitKind.UnitProcessed:
                    b = new HatchBrush(HatchStyle.Divot, Color.Green, Color.Gainsboro);
                    break;
                case DrawUnitKind.RemainUnit:
                    b = new HatchBrush(HatchStyle.ForwardDiagonal, Color.Orange, Color.Yellow);
                    break;
                case DrawUnitKind.DropUnit:
                    b = new HatchBrush(HatchStyle.LargeConfetti, Color.LightCoral, Color.White);
                    break;
                case DrawUnitKind.SawNotProcess:
                    b = new SolidBrush(Color.Gray);
                    break;
                case DrawUnitKind.SawProcessing:
                    b = new SolidBrush(Color.LightGreen);
                    break;
                case DrawUnitKind.SawProcessed:
                    b = new SolidBrush(Color.Green);
                    break;
                default:
                    b = new SolidBrush(Color.Black);
                    break;
            }
            return b;
        }

    }
}