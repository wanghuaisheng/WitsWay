using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Runtime.Serialization;
using System.Windows.Forms;
using WitsWay.TempTests.RemainProcessTest.PlanUI.Enums;

namespace WitsWay.TempTests.RemainProcessTest.PlanUI.DrawObjects
{
    /// <summary>
    /// 绘制对象基类
    /// </summary>
    [Serializable]
    public abstract class DrawObject : IComparable
    {
        #region Members
        // Object properties
        private bool _selected;
        private Color _color;
        private Color _fillColor;
        private bool _filled;
        private int _penWidth;
        private Pen _drawpen;
        private Brush _drawBrush;
        private DrawingPens.PenType _penType;
        private DrawUnitKind _brushType;
        private string _tipText;

        // Last used property values (may be kept in the Registry)
        private static Color _lastUsedColor = Color.Black;
        private static int _lastUsedPenWidth = 1;

        // Entry names for serialization
        private const string EntryColor = "Color";
        private const string EntryPenWidth = "PenWidth";
        private const string EntryPen = "DrawPen";
        private const string EntryBrush = "DrawBrush";
        private const string EntryFillColor = "FillColor";
        private const string EntryFilled = "Filled";
        private const string EntryZOrder = "ZOrder";
        private const string EntryRotation = "Rotation";
        private const string EntryTipText = "TipText";

        private bool _dirty;
        private int _id;
        private int _zOrder;
        private int _rotation = 0;
        private Point _center;
        #endregion Members

        #region Properties
        /// <summary>
        /// Center of the object being drawn.
        /// </summary>
        public Point Center
        {
            get => _center;
            set => _center = value;
        }

        /// <summary>
        /// Rotation of the object in degrees. Negative is Left, Positive is Right.
        /// </summary>
        public int Rotation
        {
            get => _rotation;
            set
            {
                if (value > 360)
                    _rotation = value - 360;
                else if (value < -360)
                    _rotation = value + 360;
                else
                    _rotation = value;
            }
        }

        /// <summary>
        /// ZOrder is the order the objects will be drawn in - lower the ZOrder, the closer the to top the object is.
        /// </summary>
        public int ZOrder
        {
            get => _zOrder;
            set => _zOrder = value;
        }

        /// <summary>
        /// Object ID used for Undo Redo functions
        /// </summary>
        public int Id
        {
            get => _id;
            set => _id = value;
        }

        /// <summary>
        /// Set to true whenever the object changes
        /// </summary>
        public bool Dirty
        {
            get => _dirty;
            set => _dirty = value;
        }

        /// <summary>
        /// Draw object filled?
        /// </summary>
        public bool Filled
        {
            get => _filled;
            set => _filled = value;
        }

        /// <summary>
        /// Selection flag
        /// </summary>
        public bool Selected
        {
            get => _selected;
            set => _selected = value;
        }

        /// <summary>
        /// Fill Color
        /// </summary>
        public Color FillColor
        {
            get => _fillColor;
            set => _fillColor = value;
        }

        /// <summary>
        /// Border (line) Color
        /// </summary>
        public Color Color
        {
            get => _color;
            set => _color = value;
        }

        /// <summary>
        /// Pen width
        /// </summary>
        public int PenWidth
        {
            get => _penWidth;
            set => _penWidth = value;
        }

        public DrawUnitKind BrushType
        {
            get => _brushType;
            set => _brushType = value;
        }

        /// <summary>
        /// Brush used to paint object
        /// </summary>
        public Brush DrawBrush
        {
            get => _drawBrush;
            set => _drawBrush = value;
        }

        public DrawingPens.PenType PenType
        {
            get => _penType;
            set => _penType = value;
        }

        /// <summary>
        /// Pen used to draw object
        /// </summary>
        public Pen DrawPen
        {
            get => _drawpen;
            set => _drawpen = value;
        }

        /// <summary>
        /// Number of handles
        /// </summary>
        public virtual int HandleCount => 0;

        /// <summary>
        /// Number of Connection Points
        /// </summary>
        public virtual int ConnectionCount => 0;

        /// <summary>
        /// Last used color
        /// </summary>
        public static Color LastUsedColor
        {
            get => _lastUsedColor;
            set => _lastUsedColor = value;
        }

        /// <summary>
        /// Last used pen width
        /// </summary>
        public static int LastUsedPenWidth
        {
            get => _lastUsedPenWidth;
            set => _lastUsedPenWidth = value;
        }

        /// <summary>
        /// Text to display when mouse is over an object
        /// </summary>
        public string TipText
        {
            get => _tipText;
            set => _tipText = value;
        }

        #endregion Properties
        #region Constructor

        protected DrawObject()
        {
            // ReSharper disable DoNotCallOverridableMethodsInConstructor
            Id = GetHashCode();
            // ReSharper restore DoNotCallOverridableMethodsInConstructor
        }
        #endregion

        #region Virtual Functions
        /// <summary>
        /// Clone this instance.
        /// </summary>
        public abstract DrawObject Clone();

        /// <summary>
        /// Draw object
        /// </summary>
        /// <param name="g">Graphics object will be drawn on</param>
        public virtual void Draw(Graphics g)
        {
        }

        #region Selection handle methods
        /// <summary>
        /// Get handle point by 1-based number
        /// </summary>
        /// <param name="handleNumber">1-based handle number to return</param>
        /// <returns>Point where handle is located, if found</returns>
        public virtual Point GetHandle(int handleNumber)
        {
            return new Point(0, 0);
        }

        /// <summary>
        /// Get handle rectangle by 1-based number
        /// </summary>
        /// <param name="handleNumber"></param>
        /// <returns>Rectangle structure to draw the handle</returns>
        public virtual Rectangle GetHandleRectangle(int handleNumber)
        {
            Point point = GetHandle(handleNumber);
            // Take into account width of pen
            return new Rectangle(point.X - (_penWidth + 3), point.Y - (_penWidth + 3), 7 + _penWidth, 7 + _penWidth);
        }

        /// <summary>
        /// Draw tracker for selected object
        /// </summary>
        /// <param name="g">Graphics to draw on</param>
        public virtual void DrawTracker(Graphics g)
        {
            if (!Selected)
                return;
            SolidBrush brush = new SolidBrush(Color.Black);

            for (int i = 1; i <= HandleCount; i++)
            {
                g.FillRectangle(brush, GetHandleRectangle(i));
            }
            brush.Dispose();
        }
        #endregion Selection handle methods
        #region Connection Point methods
        /// <summary>
        /// Get connection point by 0-based number
        /// </summary>
        /// <param name="connectionNumber">0-based connection number to return</param>
        /// <returns>Point where connection is located, if found</returns>
        public virtual Point GetConnection(int connectionNumber)
        {
            return new Point(0, 0);
        }
        /// <summary>
        /// Get connectionPoint rectangle that defines the ellipse for the requested connection
        /// </summary>
        /// <param name="connectionNumber">0-based connection number</param>
        /// <returns>Rectangle structure to draw the connection</returns>
        public virtual Rectangle GetConnectionEllipse(int connectionNumber)
        {
            Point p = GetConnection(connectionNumber);
            // Take into account width of pen
            return new Rectangle(p.X - (_penWidth + 3), p.Y - (_penWidth + 3), 7 + _penWidth, 7 + _penWidth);
        }
        public virtual void DrawConnection(Graphics g, int connectionNumber)
        {
            SolidBrush b = new SolidBrush(System.Drawing.Color.Red);
            Pen p = new Pen(System.Drawing.Color.Red, -1.0f);
            g.DrawEllipse(p, GetConnectionEllipse(connectionNumber));
            g.FillEllipse(b, GetConnectionEllipse(connectionNumber));
            p.Dispose();
            b.Dispose();
        }
        /// <summary>
        /// Draws the ellipse for the connection handles on the object
        /// </summary>
        /// <param name="g">Graphics to draw on</param>
        public virtual void DrawConnections(Graphics g)
        {
            if (!Selected)
                return;
            SolidBrush b = new SolidBrush(System.Drawing.Color.White);
            Pen p = new Pen(System.Drawing.Color.Black, -1.0f);
            for (int i = 0; i < ConnectionCount; i++)
            {
                g.DrawEllipse(p, GetConnectionEllipse(i));
                g.FillEllipse(b, GetConnectionEllipse(i));
            }
            p.Dispose();
            b.Dispose();
        }
        #endregion Connection Point methods
        /// <summary>
        /// 点击测试
        /// </summary>
        /// <param name="point">测试点</param>
        /// <returns>			(-1)		未点击
        ///						(0)		    点击任意位置
        ///						(1 to n)	特殊返回</returns>
        public virtual int HitTest(Point point)
        {
            return -1;
        }


        /// <summary>
        /// Test whether point is inside of the object
        /// </summary>
        /// <param name="point">Point to test</param>
        /// <returns>true if in object, false if not</returns>
        protected virtual bool PointInObject(Point point)
        {
            return false;
        }


        /// <summary>
        /// Get cursor for the handle
        /// </summary>
        /// <param name="handleNumber">handle number to return cursor for</param>
        /// <returns>Cursor object</returns>
        public virtual Cursor GetHandleCursor(int handleNumber)
        {
            return Cursors.Default;
        }

        /// <summary>
        /// Test whether object intersects with rectangle
        /// </summary>
        /// <param name="rectangle">Rectangle structure to test</param>
        /// <returns>true if intersect, false if not</returns>
        public virtual bool IntersectsWith(Rectangle rectangle)
        {
            return false;
        }

        /// <summary>
        /// Move object
        /// </summary>
        /// <param name="deltaX">Distance along X-axis: (+)=Right, (-)=Left</param>
        /// <param name="deltaY">Distance along Y axis: (+)=Down, (-)=Up</param>
        public virtual void Move(int deltaX, int deltaY)
        {
        }

        /// <summary>
        /// Move handle to the point
        /// </summary>
        /// <param name="point">Point to Move Handle to</param>
        /// <param name="handleNumber">Handle number to move</param>
        public virtual void MoveHandleTo(Point point, int handleNumber)
        {
        }

        /// <summary>
        /// Dump (for debugging)
        /// </summary>
        public virtual void Dump()
        {
            Trace.WriteLine("");
            Trace.WriteLine(GetType().Name);
            Trace.WriteLine("Selected = " + _selected.ToString(CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Normalize object.
        /// Call this function in the end of object resizing.
        /// </summary>
        public virtual void Normalize()
        {
        }

        #region Save / Load methods
        /// <summary>
        /// Save object to serialization stream
        /// </summary>
        /// <param name="info">The data being written to disk</param>
        /// <param name="orderNumber">Index of the Layer being saved</param>
        /// <param name="objectIndex">Index of the object on the Layer</param>
        public virtual void SaveToStream(SerializationInfo info, int orderNumber, int objectIndex)
        {
            info.AddValue(
                String.Format(CultureInfo.InvariantCulture,
                              "{0}{1}-{2}",
                              EntryColor, orderNumber, objectIndex),
                Color.ToArgb());

            info.AddValue(
                String.Format(CultureInfo.InvariantCulture,
                              "{0}{1}-{2}",
                              EntryPenWidth, orderNumber, objectIndex),
                PenWidth);

            info.AddValue(
                string.Format(CultureInfo.InvariantCulture,
                              "{0}{1}-{2}",
                              EntryPen, orderNumber, objectIndex),
                PenType);

            info.AddValue(
                string.Format(CultureInfo.InvariantCulture,
                              "{0}{1}-{2}",
                              EntryBrush, orderNumber, objectIndex),
                BrushType);

            info.AddValue(
                String.Format(CultureInfo.InvariantCulture,
                              "{0}{1}-{2}",
                              EntryFillColor, orderNumber, objectIndex),
                FillColor.ToArgb());

            info.AddValue(
                String.Format(CultureInfo.InvariantCulture,
                              "{0}{1}-{2}",
                              EntryFilled, orderNumber, objectIndex),
                Filled);

            info.AddValue(
                String.Format(CultureInfo.InvariantCulture,
                              "{0}{1}-{2}",
                              EntryZOrder, orderNumber, objectIndex),
                ZOrder);

            info.AddValue(
                String.Format(CultureInfo.InvariantCulture,
                              "{0}{1}-{2}",
                              EntryRotation, orderNumber, objectIndex),
                Rotation);

            info.AddValue(
                String.Format(CultureInfo.InvariantCulture,
                              "{0}{1}-{2}",
                              EntryTipText, orderNumber, objectIndex),
                _tipText);
        }

        /// <summary>
        /// Load object from serialization stream
        /// </summary>
        /// <param name="info">Data from disk to parse into an object</param>
        /// <param name="orderNumber">Index of the layer object resides on</param>
        /// <param name="objectData">Index of the object on the layer</param>
        public virtual void LoadFromStream(SerializationInfo info, int orderNumber, int objectData)
        {
            int n = info.GetInt32(
                String.Format(CultureInfo.InvariantCulture,
                              "{0}{1}-{2}",
                              EntryColor, orderNumber, objectData));

            Color = Color.FromArgb(n);

            PenWidth = info.GetInt32(
                String.Format(CultureInfo.InvariantCulture,
                              "{0}{1}-{2}",
                              EntryPenWidth, orderNumber, objectData));

            PenType = (DrawingPens.PenType)info.GetValue(
                                            String.Format(CultureInfo.InvariantCulture,
                                                          "{0}{1}-{2}",
                                                          EntryPen, orderNumber, objectData),
                                            typeof(DrawingPens.PenType));

            BrushType = (DrawUnitKind)info.GetValue(
                                                string.Format(CultureInfo.InvariantCulture,
                                                              "{0}{1}-{2}",
                                                              EntryBrush, orderNumber, objectData),
                                                typeof(DrawUnitKind));

            n = info.GetInt32(
                String.Format(CultureInfo.InvariantCulture,
                              "{0}{1}-{2}",
                              EntryFillColor, orderNumber, objectData));

            FillColor = Color.FromArgb(n);

            Filled = info.GetBoolean(
                String.Format(CultureInfo.InvariantCulture,
                              "{0}{1}-{2}",
                              EntryFilled, orderNumber, objectData));

            ZOrder = info.GetInt32(
                String.Format(CultureInfo.InvariantCulture,
                              "{0}{1}-{2}",
                              EntryZOrder, orderNumber, objectData));

            Rotation = info.GetInt32(
                String.Format(CultureInfo.InvariantCulture,
                              "{0}{1}-{2}",
                              EntryRotation, orderNumber, objectData));

            _tipText = info.GetString(String.Format(CultureInfo.InvariantCulture,
                              "{0}{1}-{2}",
                              EntryTipText, orderNumber, objectData));

            // Set the Pen and the Brush, if defined
            if (PenType != DrawingPens.PenType.Generic)
                DrawPen = DrawingPens.SetCurrentPen(PenType);
            if (BrushType != DrawUnitKind.SawNotProcess)
                DrawBrush = FillBrushes.GetBrush(BrushType);
        }
        #endregion Save/Load methods
        #endregion Virtual Functions

        #region Other functions
        /// <summary>
        /// Initialization
        /// </summary>
        protected void Initialize()
        {
        }

        //		private 
        /// <summary>
        /// Copy fields from this instance to cloned instance drawObject.
        /// Called from Clone functions of derived classes.
        /// </summary>
        /// <param name="drawObject">Object being cloned</param>
        protected void FillDrawObjectFields(DrawObject drawObject)
        {
            drawObject._selected = _selected;
            drawObject._color = _color;
            drawObject._penWidth = _penWidth;
            drawObject.Id = Id;
            drawObject._brushType = _brushType;
            drawObject._penType = _penType;
            drawObject._drawBrush = _drawBrush;
            drawObject._drawpen = _drawpen;
            drawObject._fillColor = _fillColor;
            drawObject._rotation = _rotation;
            drawObject._center = _center;
        }
        #endregion Other functions

        #region IComparable Members
        /// <summary>
        /// Returns (-1), (0), (+1) to represent the relative Z-order of the object being compared with this object
        /// </summary>
        /// <param name="obj">DrawObject that is compared to this object</param>
        /// <returns>	(-1)	if the object is less (further back) than this object.
        ///				(0)	if the object is equal to this object (same level graphically).
        ///				(1)	if the object is greater (closer to the front) than this object.</returns>
        public int CompareTo(object obj)
        {
            DrawObject d = obj as DrawObject;
            int x = 0;
            if (d != null)
                if (d.ZOrder == ZOrder)
                    x = 0;
                else if (d.ZOrder > ZOrder)
                    x = -1;
                else
                    x = 1;

            return x;
        }
        #endregion IComparable Members
    }
}