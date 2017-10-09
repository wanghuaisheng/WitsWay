using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Runtime.Serialization;
using System.Windows.Forms;

namespace WitsWay.TempTests.RemainProcessTest.PlanUI.DrawObjects
{
	/// <summary>
	/// Rectangle graphic object
	/// </summary>
	//[Serializable]
	public class DrawText : DrawObject
	{
		private Rectangle _rectangle;
		private string _theText;
		private Font _font;


		protected string TheText
		{
			get { return _theText; }
		    set
			{
				_theText = value;
				TipText = value;
			}
		}

		public Font TheFont
		{
			get { return _font; }
		    set { _font = value; }
		}

		private const string EntryRectangle = "Rect";
		private const string EntryText = "Text";
		private const string EntryFontName = "FontName";
		private const string EntryFontBold = "FontBold";
		private const string EntryFontItalic = "FontItalic";
		private const string EntryFontSize = "FontSize";
		private const string EntryFontStrikeout = "FontStrikeout";
		private const string EntryFontUnderline = "FontUnderline";


		protected Rectangle Rectangle
		{
			get { return _rectangle; }
		    set { _rectangle = value; }
		}

		public DrawText()
		{
			//SetRectangle(0, 0, 1,1);
			_theText = "";
			Initialize();
		}

		/// <summary>
		/// Clone this instance
		/// </summary>
		public override DrawObject Clone()
		{
			DrawText drawText = new DrawText();

			drawText._font = _font;
			drawText._theText = _theText;
			drawText._rectangle = _rectangle;

			FillDrawObjectFields(drawText);
			return drawText;
		}


		public DrawText(int x, int y, string textToDraw, Font textFont, Color textColor)
		{
			_rectangle.X = x;
			_rectangle.Y = y;
			_theText = textToDraw;
			_font = textFont;
			Color = textColor;
			Initialize();
		}


		/// <summary>
		/// Draw rectangle
		/// </summary>
		/// <param name="g"></param>
		public override void Draw(Graphics g)
		{
			Pen pen = new Pen(Color);
			//Brush b = new SolidBrush(Color);
			//g.DrawString(_theText, _font, b, new PointF(Rectangle.X, Rectangle.Y));
			GraphicsPath gp = new GraphicsPath();
			StringFormat format = StringFormat.GenericDefault;
			gp.AddString(_theText, _font.FontFamily, (int)_font.Style, _font.SizeInPoints,
						 new PointF(Rectangle.X, Rectangle.Y), format);
			// Rotate the path about it's center if necessary
			if (Rotation != 0)
			{
				RectangleF pathBounds = gp.GetBounds();
				Matrix m = new Matrix();
				m.RotateAt(Rotation, new PointF(pathBounds.Left + (pathBounds.Width / 2), pathBounds.Top + (pathBounds.Height / 2)),
						   MatrixOrder.Append);
				gp.Transform(m);
			}
			g.DrawPath(pen, gp);
			_rectangle.Size = g.MeasureString(_theText, _font).ToSize();
			pen.Dispose();
		}

		/// <summary>
		/// Get number of handles
		/// </summary>
		public override int HandleCount => 8;


	    /// <summary>
		/// Get handle point by 1-based number
		/// </summary>
		/// <param name="handleNumber"></param>
		/// <returns></returns>
		public override Point GetHandle(int handleNumber)
		{
			int x, y, xCenter, yCenter;

			xCenter = _rectangle.X + _rectangle.Width / 2;
			yCenter = _rectangle.Y + _rectangle.Height / 2;
			x = _rectangle.X;
			y = _rectangle.Y;

			switch (handleNumber)
			{
				case 1:
					x = _rectangle.X;
					y = _rectangle.Y;
					break;
				case 2:
					x = xCenter;
					y = _rectangle.Y;
					break;
				case 3:
					x = _rectangle.Right;
					y = _rectangle.Y;
					break;
				case 4:
					x = _rectangle.Right;
					y = yCenter;
					break;
				case 5:
					x = _rectangle.Right;
					y = _rectangle.Bottom;
					break;
				case 6:
					x = xCenter;
					y = _rectangle.Bottom;
					break;
				case 7:
					x = _rectangle.X;
					y = _rectangle.Bottom;
					break;
				case 8:
					x = _rectangle.X;
					y = yCenter;
					break;
			}

			return new Point(x, y);
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
			{
				for (int i = 1; i <= HandleCount; i++)
				{
					if (GetHandleRectangle(i).Contains(point))
						return i;
				}
			}

			if (PointInObject(point))
				return 0;

			return -1;
		}


		protected override bool PointInObject(Point point)
		{
			return _rectangle.Contains(point);
		}


		/// <summary>
		/// Get cursor for the handle
		/// </summary>
		/// <param name="handleNumber"></param>
		/// <returns></returns>
		public override Cursor GetHandleCursor(int handleNumber)
		{
			//switch ( handleNumber )
			//{
			//    case 1:
			//        return Cursors.SizeNWSE;
			//    case 2:
			//        return Cursors.SizeNS;
			//    case 3:
			//        return Cursors.SizeNESW;
			//    case 4:
			//        return Cursors.SizeWE;
			//    case 5:
			//        return Cursors.SizeNWSE;
			//    case 6:
			//        return Cursors.SizeNS;
			//    case 7:
			//        return Cursors.SizeNESW;
			//    case 8:
			//        return Cursors.SizeWE;
			//    default:
			return Cursors.Default;
			//}
		}

		/// <summary>
		/// Move handle to new point (resizing)
		/// </summary>
		/// <param name="point"></param>
		/// <param name="handleNumber"></param>
		public override void MoveHandleTo(Point point, int handleNumber)
		{
			//int left = Rectangle.Left;
			//int top = Rectangle.Top;
			//int right = Rectangle.Right;
			//int bottom = Rectangle.Bottom;

			//switch ( handleNumber )
			//{
			//    case 1:
			//        left = point.X;
			//        top = point.Y;
			//        break;
			//    case 2:
			//        top = point.Y;
			//        break;
			//    case 3:
			//        right = point.X;
			//        top = point.Y;
			//        break;
			//    case 4:
			//        right = point.X;
			//        break;
			//    case 5:
			//        right = point.X;
			//        bottom = point.Y;
			//        break;
			//    case 6:
			//        bottom = point.Y;
			//        break;
			//    case 7:
			//        left = point.X;
			//        bottom = point.Y;
			//        break;
			//    case 8:
			//        left = point.X;
			//        break;
			//}

			//SetRectangle(left, top, right - left, bottom - top);
		}


		public override bool IntersectsWith(Rectangle rectangle)
		{
			return Rectangle.IntersectsWith(rectangle);
		}

		/// <summary>
		/// Move object
		/// </summary>
		/// <param name="deltaX"></param>
		/// <param name="deltaY"></param>
		public override void Move(int deltaX, int deltaY)
		{
			_rectangle.X += deltaX;
			_rectangle.Y += deltaY;
			Dirty = true;
		}

		public override void Dump()
		{
			//base.Dump ();

			//Trace.WriteLine("rectangle.X = " + rectangle.X.ToString(CultureInfo.InvariantCulture));
			//Trace.WriteLine("rectangle.Y = " + rectangle.Y.ToString(CultureInfo.InvariantCulture));
			//Trace.WriteLine("rectangle.Width = " + rectangle.Width.ToString(CultureInfo.InvariantCulture));
			//Trace.WriteLine("rectangle.Height = " + rectangle.Height.ToString(CultureInfo.InvariantCulture));
		}

		/// <summary>
		/// Normalize rectangle
		/// </summary>
		public override void Normalize()
		{
			//rectangle = DrawRectangle.GetNormalizedRectangle(rectangle);
		}

		/// <summary>
		/// Save objevt to serialization stream
		/// </summary>
		/// <param name="info"></param>
		/// <param name="orderNumber">Index of the Layer being saved</param>
		/// <param name="objectIndex">Index of this object in the Layer</param>
		public override void SaveToStream(SerializationInfo info, int orderNumber, int objectIndex)
		{
			info.AddValue(
				String.Format(CultureInfo.InvariantCulture,
							  "{0}{1}-{2}",
							  EntryRectangle, orderNumber, objectIndex),
				_rectangle);
			info.AddValue(
				String.Format(CultureInfo.InvariantCulture,
							  "{0}{1}-{2}",
							  EntryText, orderNumber, objectIndex),
				_theText);
			info.AddValue(
				String.Format(CultureInfo.InvariantCulture,
							  "{0}{1}-{2}",
							  EntryFontName, orderNumber, objectIndex),
				_font.Name);
			info.AddValue(
				String.Format(CultureInfo.InvariantCulture,
							  "{0}{1}-{2}",
							  EntryFontBold, orderNumber, objectIndex),
				_font.Bold);
			info.AddValue(
				String.Format(CultureInfo.InvariantCulture,
							  "{0}{1}-{2}",
							  EntryFontItalic, orderNumber, objectIndex),
				_font.Italic);
			info.AddValue(
				String.Format(CultureInfo.InvariantCulture,
							  "{0}{1}-{2}",
							  EntryFontSize, orderNumber, objectIndex),
				_font.Size);
			info.AddValue(
				String.Format(CultureInfo.InvariantCulture,
							  "{0}{1}-{2}",
							  EntryFontStrikeout, orderNumber, objectIndex),
				_font.Strikeout);
			info.AddValue(
				String.Format(CultureInfo.InvariantCulture,
							  "{0}{1}-{2}",
							  EntryFontUnderline, orderNumber, objectIndex),
				_font.Underline);

			base.SaveToStream(info, orderNumber, objectIndex);
		}

		/// <summary>
		/// LOad object from serialization stream
		/// </summary>
		/// <param name="info"></param>
		/// <param name="orderNumber"></param>
		/// <param name="objectIndex"></param>
		public override void LoadFromStream(SerializationInfo info, int orderNumber, int objectIndex)
		{
			_rectangle = (Rectangle)info.GetValue(
									String.Format(CultureInfo.InvariantCulture,
												  "{0}{1}-{2}",
												  EntryRectangle, orderNumber, objectIndex),
									typeof(Rectangle));
			_theText = info.GetString(
				String.Format(CultureInfo.InvariantCulture,
							  "{0}{1}-{2}",
							  EntryText, orderNumber, objectIndex));
			string name = info.GetString(
				String.Format(CultureInfo.InvariantCulture,
							  "{0}{1}-{2}",
							  EntryFontName, orderNumber, objectIndex));
			bool bold = info.GetBoolean(
				String.Format(CultureInfo.InvariantCulture,
							  "{0}{1}-{2}",
							  EntryFontBold, orderNumber, objectIndex));
			bool italic = info.GetBoolean(
				String.Format(CultureInfo.InvariantCulture,
							  "{0}{1}-{2}",
							  EntryFontItalic, orderNumber, objectIndex));
			float size = (float)info.GetValue(
									String.Format(CultureInfo.InvariantCulture,
												  "{0}{1}-{2}",
												  EntryFontSize, orderNumber, objectIndex),
									typeof(float));
			bool strikeout = info.GetBoolean(
				String.Format(CultureInfo.InvariantCulture,
							  "{0}{1}-{2}",
							  EntryFontStrikeout, orderNumber, objectIndex));
			bool underline = info.GetBoolean(
				String.Format(CultureInfo.InvariantCulture,
							  "{0}{1}-{2}",
							  EntryFontUnderline, orderNumber, objectIndex));
			FontStyle fs = FontStyle.Regular;
			if (bold)
				fs |= FontStyle.Bold;
			if (italic)
				fs |= FontStyle.Italic;
			if (strikeout)
				fs |= FontStyle.Strikeout;
			if (underline)
				fs |= FontStyle.Underline;
			_font = new Font(name, size, fs);

			base.LoadFromStream(info, orderNumber, objectIndex);
		}

		#region Helper Functions
		//public static Rectangle GetNormalizedRectangle(int x1, int y1, int x2, int y2)
		//{
		//if ( x2 < x1 )
		//{
		//    int tmp = x2;
		//    x2 = x1;
		//    x1 = tmp;
		//}

		//if ( y2 < y1 )
		//{
		//    int tmp = y2;
		//    y2 = y1;
		//    y1 = tmp;
		//}

		//return new Rectangle(x1, y1, x2 - x1, y2 - y1);
		//}

		//public static Rectangle GetNormalizedRectangle(Point p1, Point p2)
		//{
		//return GetNormalizedRectangle(p1.X, p1.Y, p2.X, p2.Y);
		//}

		//public static Rectangle GetNormalizedRectangle(Rectangle r)
		//{
		//return GetNormalizedRectangle(r.X, r.Y, r.X + r.Width, r.Y + r.Height);
		//}
		#endregion
	}
}