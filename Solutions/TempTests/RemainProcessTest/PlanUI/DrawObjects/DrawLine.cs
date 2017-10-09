using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Runtime.Serialization;
using System.Windows.Forms;

namespace WitsWay.TempTests.RemainProcessTest.PlanUI.DrawObjects
{
    /// <summary>
    /// Line graphic object
    /// </summary>
    //[Serializable]
    public class DrawLine : DrawObject
    {
        private Point _startPoint;
        private Point _endPoint;

        private const string EntryStart = "Start";
        private const string EntryEnd = "End";

        /// <summary>
        ///  Graphic objects for hit test
        /// </summary>
        private GraphicsPath _areaPath = null;

        private Pen _areaPen = null;
        private Region _areaRegion = null;


        public DrawLine()
        {
            _startPoint.X = 0;
            _startPoint.Y = 0;
            _endPoint.X = 1;
            _endPoint.Y = 1;
            ZOrder = 0;

            Initialize();
        }

        public DrawLine(int x1, int y1, int x2, int y2)
        {
            _startPoint.X = x1;
            _startPoint.Y = y1;
            _endPoint.X = x2;
            _endPoint.Y = y2;
            ZOrder = 0;
            TipText = String.Format("Line Start @ {0}-{1}, End @ {2}-{3}", x1, y1, x2, y2);
            Initialize();
        }

        public DrawLine(int x1, int y1, int x2, int y2, DrawingPens.PenType p)
        {
            _startPoint.X = x1;
            _startPoint.Y = y1;
            _endPoint.X = x2;
            _endPoint.Y = y2;
            DrawPen = DrawingPens.SetCurrentPen(p);
            PenType = p;
            ZOrder = 0;
            TipText = String.Format("Line Start @ {0}-{1}, End @ {2}-{3}", x1, y1, x2, y2);
            Initialize();
        }

        public DrawLine(int x1, int y1, int x2, int y2, Color lineColor, int lineWidth)
        {
            _startPoint.X = x1;
            _startPoint.Y = y1;
            _endPoint.X = x2;
            _endPoint.Y = y2;
            Color = lineColor;
            PenWidth = lineWidth;
            ZOrder = 0;
            TipText = String.Format("Line Start @ {0}-{1}, End @ {2}-{3}", x1, y1, x2, y2);

            Initialize();
        }


        public override void Draw(Graphics g)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Pen pen;
            if (DrawPen == null)
                pen = new Pen(Color, PenWidth);
            else
                pen = (Pen)DrawPen.Clone();
            //pen.Alignment = PenAlignment.Inset;
            GraphicsPath gp = new GraphicsPath();
            gp.AddLine(_startPoint, _endPoint);
            // Rotate the path about it's center if necessary
            if (Rotation != 0)
            {
                RectangleF pathBounds = gp.GetBounds();
                Matrix m = new Matrix();
                m.RotateAt(Rotation, new PointF(pathBounds.Left + (pathBounds.Width / 2), pathBounds.Top + (pathBounds.Height / 2)), MatrixOrder.Append);
                gp.Transform(m);
            }
            g.DrawPath(pen, gp);
            gp.Dispose();
            pen.Dispose();
        }

        /// <summary>
        /// Clone this instance
        /// </summary>
        public override DrawObject Clone()
        {
            DrawLine drawLine = new DrawLine();
            drawLine._startPoint = _startPoint;
            drawLine._endPoint = _endPoint;

            FillDrawObjectFields(drawLine);
            return drawLine;
        }

        public override int HandleCount => 2;

        /// <summary>
        /// Get handle point by 1-based number
        /// </summary>
        /// <param name="handleNumber"></param>
        /// <returns></returns>
        public override Point GetHandle(int handleNumber)
        {
            GraphicsPath gp = new GraphicsPath();
            Matrix m = new Matrix();
            gp.AddLine(_startPoint, _endPoint);
            RectangleF pathBounds = gp.GetBounds();
            m.RotateAt(Rotation, new PointF(pathBounds.Left + (pathBounds.Width / 2), pathBounds.Top + (pathBounds.Height / 2)), MatrixOrder.Append);
            gp.Transform(m);
            Point start, end;
            start = Point.Truncate(gp.PathPoints[0]);
            end = Point.Truncate(gp.PathPoints[1]);
            gp.Dispose();
            m.Dispose();
            if (handleNumber == 1)
                return start;
            else
                return end;
        }

        /// <summary>
        /// Hit test.
        /// Return value: -1 - no hit
        ///                0 - hit anywhere
        ///                > 1 - handle number
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public override int HitTest(Point point)
        {
            if (Selected)
                for (int i = 1; i <= HandleCount; i++)
                {
                    GraphicsPath gp = new GraphicsPath();
                    gp.AddRectangle(GetHandleRectangle(i));
                    bool vis = gp.IsVisible(point);
                    gp.Dispose();
                    if (vis)
                        return i;
                }
            // OK, so the point is not on a selection handle, is it anywhere else on the line?
            if (PointInObject(point))
                return 0;
            return -1;
        }

        protected override bool PointInObject(Point point)
        {
            CreateObjects();
            //return AreaPath.IsVisible(point);
            return AreaRegion.IsVisible(point);
        }

        public override bool IntersectsWith(Rectangle rectangle)
        {
            CreateObjects();

            return AreaRegion.IsVisible(rectangle);
        }

        public override Cursor GetHandleCursor(int handleNumber)
        {
            switch (handleNumber)
            {
                case 1:
                case 2:
                    return Cursors.SizeAll;
                default:
                    return Cursors.Default;
            }
        }

        public override void MoveHandleTo(Point point, int handleNumber)
        {
            //GraphicsPath gp = new GraphicsPath();
            //Matrix m = new Matrix();
            //if (handleNumber == 1)
            //    gp.AddLine(point, endPoint);
            //else
            //    gp.AddLine(startPoint, point);

            //RectangleF pathBounds = gp.GetBounds();
            //m.RotateAt(Rotation, new PointF(pathBounds.Left + (pathBounds.Width / 2), pathBounds.Top + (pathBounds.Height / 2)), MatrixOrder.Append);
            //gp.Transform(m);
            //Point start, end;
            //start = Point.Truncate(gp.PathPoints[0]);
            //end = Point.Truncate(gp.PathPoints[1]);
            //gp.Dispose();
            //m.Dispose();
            //if (handleNumber == 1)
            //    startPoint = start;
            //else
            //    endPoint = end;

            if (handleNumber == 1)
                _startPoint = point;
            else
                _endPoint = point;

            Dirty = true;
            Invalidate();
        }

        public override void Move(int deltaX, int deltaY)
        {
            _startPoint.X += deltaX;
            _startPoint.Y += deltaY;

            _endPoint.X += deltaX;
            _endPoint.Y += deltaY;
            Dirty = true;
            Invalidate();
        }

        public override void SaveToStream(SerializationInfo info, int orderNumber, int objectIndex)
        {
            info.AddValue(
                String.Format(CultureInfo.InvariantCulture,
                              "{0}{1}-{2}",
                              EntryStart, orderNumber, objectIndex),
                _startPoint);

            info.AddValue(
                String.Format(CultureInfo.InvariantCulture,
                              "{0}{1}-{2}",
                              EntryEnd, orderNumber, objectIndex),
                _endPoint);

            base.SaveToStream(info, orderNumber, objectIndex);
        }

        public override void LoadFromStream(SerializationInfo info, int orderNumber, int objectIndex)
        {
            _startPoint = (Point)info.GetValue(
                                    String.Format(CultureInfo.InvariantCulture,
                                                  "{0}{1}-{2}",
                                                  EntryStart, orderNumber, objectIndex),
                                    typeof(Point));

            _endPoint = (Point)info.GetValue(
                                String.Format(CultureInfo.InvariantCulture,
                                              "{0}{1}-{2}",
                                              EntryEnd, orderNumber, objectIndex),
                                typeof(Point));

            base.LoadFromStream(info, orderNumber, objectIndex);
        }

        /// <summary>
        /// Invalidate object.
        /// When object is invalidated, path used for hit test
        /// is released and should be created again.
        /// </summary>
        protected void Invalidate()
        {
            if (AreaPath != null)
            {
                AreaPath.Dispose();
                AreaPath = null;
            }

            if (AreaPen != null)
            {
                AreaPen.Dispose();
                AreaPen = null;
            }

            if (AreaRegion != null)
            {
                AreaRegion.Dispose();
                AreaRegion = null;
            }
        }

        /// <summary>
        /// Create graphic objects used for hit test.
        /// </summary>
        protected virtual void CreateObjects()
        {
            if (AreaPath != null)
                return;

            // Create path which contains wide line
            // for easy mouse selection
            AreaPath = new GraphicsPath();
            // Take into account the width of the pen used to draw the actual object
            AreaPen = new Pen(Color.Black, PenWidth < 7 ? 7 : PenWidth);
            // Prevent Out of Memory crash when startPoint == endPoint
            if (_startPoint.Equals((Point)_endPoint))
            {
                _endPoint.X++;
                _endPoint.Y++;
            }
            AreaPath.AddLine(_startPoint.X, _startPoint.Y, _endPoint.X, _endPoint.Y);
            AreaPath.Widen(AreaPen);
            // Rotate the path about it's center if necessary
            if (Rotation != 0)
            {
                RectangleF pathBounds = AreaPath.GetBounds();
                Matrix m = new Matrix();
                m.RotateAt(Rotation, new PointF(pathBounds.Left + (pathBounds.Width / 2), pathBounds.Top + (pathBounds.Height / 2)), MatrixOrder.Append);
                AreaPath.Transform(m);
                m.Dispose();
            }

            // Create region from the path
            AreaRegion = new Region(AreaPath);
        }

        protected GraphicsPath AreaPath
        {
            get { return _areaPath; }
            set { _areaPath = value; }
        }

        protected Pen AreaPen
        {
            get { return _areaPen; }
            set { _areaPen = value; }
        }

        protected Region AreaRegion
        {
            get {return _areaRegion; }
            set { _areaRegion = value; }
        }
    }
}