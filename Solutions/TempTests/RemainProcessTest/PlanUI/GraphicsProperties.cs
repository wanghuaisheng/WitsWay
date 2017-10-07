using System.Drawing;

namespace WitsWay.TempTests.RemainProcessTest.PlanUI
{
    /// <summary>
    /// Helper class used to show properties
    /// for one or more graphic objects
    /// </summary>
    internal class GraphicsProperties
    {
        private Color? _color;
        private int? _penWidth;

        public GraphicsProperties()
        {
            _color = null;
            _penWidth = null;
        }

        public Color? Color
        {
            get => _color;
            set => _color = value;
        }

        public int? PenWidth
        {
            get => _penWidth;
            set => _penWidth = value;
        }
    }
}