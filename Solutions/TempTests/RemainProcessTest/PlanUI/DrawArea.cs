using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using WitsWay.TempTests.RemainProcessTest.PlanUI.DrawObjects;

namespace WitsWay.TempTests.RemainProcessTest.PlanUI
{

    /// <summary>
    /// 绘制区域 ,处理鼠标输入和图形对象绘制
    /// </summary>
    internal partial class DrawArea : UserControl
    {

        /// <summary>
        /// 余料尺寸
        /// </summary>
        public Size RemainSize { get; set; }

        /// <summary>
        /// 工作区尺寸
        /// </summary>
        public Size AreaSize => ClientSize;

        ///// <summary>
        ///// 缩放因子
        ///// </summary>
        //public decimal ZoomFactor {
        //    get
        //    {
        //        var RemainSize.Width/RemainSize.Height
        //    }
        //}

        #region Constructor, Dispose
        public DrawArea()
        {
            // create list of Layers, with one default active visible layer
            _panning = false;
            _panX = 0;
            _panY = 0;
            this.MouseWheel += DrawArea_MouseWheel;
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();
            //DrawImage o = new DrawImage(0, 0);
            //DrawTools.ToolObject.AddNewObject(this, new DrawImage(0, 0));

        }
        #endregion Constructor, Dispose

        #region Enumerations
        public enum DrawToolType
        {
            Pointer,
            Rectangle,
            Ellipse,
            Line,
            PolyLine,
            Polygon,
            Text,
            Image,
            Connector,
            NumberOfDrawTools
        } ;
        #endregion Enumerations

        #region Members
        private float _zoom = 1.0f;
        private float _rotation = 0f;
        private int _panX = 0;
        private int _panY;
        private int _originalPanY;
        private bool _panning = false;
        private Point _lastPoint;
        private Color _lineColor = Color.Black;
        private Color _fillColor = Color.White;
        private bool _drawFilled = false;
        private int _lineWidth = -1;
        private Pen _currentPen;
        private DrawingPens.PenType _penType;
        private Brush _currentBrush;

        // Define the Layers collection
        private Layers _layers;

        private DrawToolType _activeTool; // active drawing tool

        // Information about owner form
        private PlanControl _owner;

        // group selection rectangle
        private Rectangle _netRectangle;
        private bool _drawNetRectangle = false;

        private Form _myparent;

        public Form MyParent
        {
            get => _myparent;
            set => _myparent = value;
        }

        #endregion Members

        #region Properties
        ///// <summary>
        ///// Allow tools and objects to see the type of brush set
        ///// </summary>
        //public FillBrushes.DrawUnitKind BrushType
        //{
        //    get { return _brushType; }
        //    set { _brushType = value; }
        //}

        public Brush CurrentBrush
        {
            get => _currentBrush;
            set => _currentBrush = value;
        }

        /// <summary>
        /// Allow tools and objects to see the type of pen set
        /// </summary>
        public DrawingPens.PenType PenType
        {
            get => _penType;
            set => _penType = value;
        }

        /// <summary>
        /// Current Drawing Pen
        /// </summary>
        public Pen CurrentPen
        {
            get => _currentPen;
            set => _currentPen = value;
        }

        /// <summary>
        /// Current Line Width
        /// </summary>
        public int LineWidth
        {
            get => _lineWidth;
            set => _lineWidth = value;
        }

        /// <summary>
        /// Flag determines if objects will be drawn filled or not
        /// </summary>
        public bool DrawFilled
        {
            get => _drawFilled;
            set => _drawFilled = value;
        }

        /// <summary>
        /// Color to draw filled objects with
        /// </summary>
        public Color FillColor
        {
            get => _fillColor;
            set => _fillColor = value;
        }

        /// <summary>
        /// Color for drawing lines
        /// </summary>
        public Color LineColor
        {
            get => _lineColor;
            set => _lineColor = value;
        }

        /// <summary>
        /// Original Y position - used when panning
        /// </summary>
        public int OriginalPanY
        {
            get => _originalPanY;
            set => _originalPanY = value;
        }

        /// <summary>
        /// Flag is true if panning active
        /// </summary>
        public bool Panning
        {
            get => _panning;
            set => _panning = value;
        }

        /// <summary>
        /// Current pan offset along X-axis
        /// </summary>
        public int PanX
        {
            get => _panX;
            set => _panX = value;
        }

        /// <summary>
        /// Current pan offset along Y-axis
        /// </summary>
        public int PanY
        {
            get => _panY;
            set => _panY = value;
        }

        /// <summary>
        /// Degrees of rotation of the drawing
        /// </summary>
        public float Rotation
        {
            get => _rotation;
            set => _rotation = value;
        }

        /// <summary>
        /// Current Zoom factor
        /// </summary>
        public float Zoom
        {
            get => _zoom;
            set => _zoom = value;
        }

        /// <summary>
        /// Group selection rectangle. Used for drawing.
        /// </summary>
        public Rectangle NetRectangle
        {
            get => _netRectangle;
            set => _netRectangle = value;
        }

        /// <summary>
        /// Flag is set to true if group selection rectangle should be drawn.
        /// </summary>
        public bool DrawNetRectangle
        {
            get => _drawNetRectangle;
            set => _drawNetRectangle = value;
        }

        /// <summary>
        /// Reference to the owner form
        /// </summary>
        public PlanControl Owner
        {
            get => _owner;
            set => _owner = value;
        }

        /// <summary>
        /// Active drawing tool.
        /// </summary>
        public DrawToolType ActiveTool
        {
            get => _activeTool;
            set => _activeTool = value;
        }

        /// <summary>
        /// List of Layers in the drawing
        /// </summary>
        public Layers DrawLayers
        {
            get
            {
                if (_layers != null) return _layers;
                _layers = new Layers();
                _layers.CreateNewLayer("Default");
                return _layers;
            }
        }
        #endregion

        #region Event Handlers
        /// <summary>
        /// Draw graphic objects and group selection rectangle (optionally)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawArea_Paint(object sender, PaintEventArgs e)
        {
            Matrix mx = new Matrix();
            mx.Translate(-ClientSize.Width / 2f, -ClientSize.Height / 2f, MatrixOrder.Append);
            mx.Rotate(_rotation, MatrixOrder.Append);
            mx.Translate(ClientSize.Width / 2f + _panX, ClientSize.Height / 2f + _panY, MatrixOrder.Append);
            mx.Scale(_zoom, _zoom, MatrixOrder.Append);
            e.Graphics.Transform = mx;
            // Determine center of ClientRectangle
            Point centerRectangle = new Point();
            centerRectangle.X = ClientRectangle.Left + ClientRectangle.Width / 2;
            centerRectangle.Y = ClientRectangle.Top + ClientRectangle.Height / 2;
            // Get true center point
            centerRectangle = BackTrackMouse(centerRectangle);
            // Determine offset from current mouse position

            SolidBrush brush = new SolidBrush(Color.FromArgb(255, 255, 255));
            e.Graphics.FillRectangle(brush,
                         ClientRectangle);
            // Draw objects on each layer, in succession so we get the correct layering. Only draw layers that are visible
            if (_layers != null)
            {
                int lc = _layers.Count;
                for (int i = 0; i < lc; i++)
                {
                    Console.WriteLine(String.Format("Layer {0} is Visible: {1}", i.ToString(), _layers[i].IsVisible.ToString()));
                    if (_layers[i].IsVisible)
                    {
                        if (_layers[i].Graphics != null)
                            _layers[i].Graphics.Draw(e.Graphics);
                    }
                }
            }

            DrawNetSelection(e.Graphics);

            brush.Dispose();
        }

        /// <summary>
        /// Back Track the Mouse to return accurate coordinates regardless of zoom or pan effects.
        /// Courtesy of BobPowell.net <seealso cref="http://www.bobpowell.net/backtrack.htm"/>
        /// </summary>
        /// <param name="p">Point to backtrack</param>
        /// <returns>Backtracked point</returns>
        public Point BackTrackMouse(Point p)
        {
            // Backtrack the mouse...
            Point[] pts = new Point[] { p };
            Matrix mx = new Matrix();
            mx.Translate(-ClientSize.Width / 2f, -ClientSize.Height / 2f, MatrixOrder.Append);
            mx.Rotate(_rotation, MatrixOrder.Append);
            mx.Translate(ClientSize.Width / 2f + _panX, ClientSize.Height / 2f + _panY, MatrixOrder.Append);
            mx.Scale(_zoom, _zoom, MatrixOrder.Append);
            mx.Invert();
            mx.TransformPoints(pts);
            return pts[0];
        }

        /// <summary>
        /// Mouse down.
        /// Left button down event is passed to active tool.
        /// Right button down event is handled in this class.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawArea_MouseDown(object sender, MouseEventArgs e)
        {
            _lastPoint = BackTrackMouse(e.Location);
            if (e.Button == MouseButtons.Left)
            {
                OnContextMenu(e, false);
                //_tools[(int)_activeTool].OnMouseDown(this, e);
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (_panning)
                    _panning = false;
                //if (_activeTool == DrawToolType.PolyLine || _activeTool == DrawToolType.Connector)
                //    _tools[(int)_activeTool].OnMouseDown(this, e);
                ActiveTool = DrawToolType.Pointer;
                OnContextMenu(e, true);
            }
        }

        //        else if (e.Button == MouseButtons.Right)
        //{
        //if (_panning == true)
        //_panning = false; 

        //if (activeTool == DrawToolType.PolyLine)
        //tools[(int)activeTool].OnMouseDown(this, e);

        //ActiveTool = TETemplateDrawArea.DrawToolType.Pointer;
        //}

        /// <summary>
        /// Mouse move.
        /// Moving without button pressed or with left button pressed
        /// is passed to active tool.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawArea_MouseMove(object sender, MouseEventArgs e)
        {
            Point curLoc = BackTrackMouse(e.Location);
            if (e.Button == MouseButtons.Left ||
              e.Button == MouseButtons.None)
                if (e.Button == MouseButtons.Left && _panning)
                {
                    if (curLoc.X !=
                      _lastPoint.X)
                        _panX += curLoc.X - _lastPoint.X;
                    if (curLoc.Y !=
                      _lastPoint.Y)
                        _panY += curLoc.Y - _lastPoint.Y;
                    Invalidate();
                }
                //else
                //    _tools[(int)_activeTool].OnMouseMove(this, e);
                else
                    Cursor = Cursors.Default;
            _lastPoint = BackTrackMouse(e.Location);
        }

        /// <summary>
        /// Mouse up event.
        /// Left button up event is passed to active tool.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawArea_MouseUp(object sender, MouseEventArgs e)
        {
            //lastPoint = BackTrackMouse(e.Location);
            if (e.Button ==
              MouseButtons.Left)
            {
                ////this.AddCommandToHistory(new CommandAdd(this.TheLayers[al].Graphics[0]));
                //_tools[(int)_activeTool].OnMouseUp(this, e);
            }
        }
        #endregion

        #region Other Functions
        /// <summary>
        /// Initialization
        /// </summary>
        /// <param name="owner">Reference to the owner form</param>
        public void Initialize(PlanControl owner)
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                 ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            Invalidate();

            // Keep reference to owner form
            Owner = owner;
            // set default tool
            _activeTool = DrawToolType.Pointer;

            LineColor = Color.Black;
            FillColor = Color.White;
            LineWidth = -1;
        }

        /// <summary>
        ///  Draw group selection rectangle
        /// </summary>
        /// <param name="g"></param>
        public void DrawNetSelection(Graphics g)
        {
            if (!DrawNetRectangle) return;
            ControlPaint.DrawFocusRectangle(g, NetRectangle, Color.Black, Color.Transparent);
        }

        /// <summary>
        /// Right-click handler
        /// </summary>
        /// <param name="e"></param>
        /// <param name="showPopup"></param>
        private void OnContextMenu(MouseEventArgs e, bool showPopup)
        {
            //改变选中对象
            var point = BackTrackMouse(new Point(e.X, e.Y));
            var al = _layers.ActiveLayerIndex;
            var n = _layers[al].Graphics.Count;
            DrawObject o = null;
            for (var i = 0; i < n; i++)
            {
                if (_layers[al].Graphics[i].HitTest(point) != 0) continue;
                o = _layers[al].Graphics[i];
                break;
            }
            if (o != null)
            {
                if (!o.Selected) { _layers[al].Graphics.UnselectAll(); }
                // 选中点击对象
                o.Selected = true;
            }
            else
            {
                _layers[al].Graphics.UnselectAll();
            }
            Refresh();
            if (showPopup)
            {
                Owner.ContextPopup.ShowPopup(Owner.BarManager, MousePosition);
            }
        }

        #endregion

        public void CutObject()
        {
            MessageBox.Show("Cut (from drawarea)");
        }

        public void CopyObject()
        {
            MessageBox.Show("Copy");
        }

        private void DrawArea_MouseWheel(object sender, MouseEventArgs e)
        {
        }

    }
}