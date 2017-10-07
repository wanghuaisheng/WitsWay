using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using DevExpress.Skins;
using DevExpress.Utils;
using DevExpress.Utils.Drawing;

namespace DevExpress.Description.Controls.Windows
{
    // Token: 0x02000057 RID: 87
    public class DXGuideLayeredWindowEx : DXGuideLayeredWindow
    {
        // Token: 0x06000354 RID: 852 RVA: 0x000108A3 File Offset: 0x0000EAA3
        public DXGuideLayeredWindowEx(GuideControl owner)
            : base(owner)
        {
        }

        // Token: 0x06000359 RID: 857 RVA: 0x00010BFC File Offset: 0x0000EDFC
        private Rectangle CalcInActiveInfoBounds(GraphicsCache cache, GuideControlDescription description)
        {
            Rectangle controlBounds = description.ControlBounds;
            int num = Math.Max(16, Math.Min(50, controlBounds.Height - 8));
            if (num > controlBounds.Height)
            {
                return Rectangle.Empty;
            }
            if (num > controlBounds.Width)
            {
                num = controlBounds.Width - 4;
            }
            if (num < 16)
            {
                return Rectangle.Empty;
            }
            return RectangleHelper.GetCenterBounds(controlBounds, new Size(num, num));
        }

        // Token: 0x0600035A RID: 858 RVA: 0x00010C64 File Offset: 0x0000EE64
        protected void DrawActiveControl(GraphicsCache cache, GuideControlDescription description)
        {
            if (description.AssociatedControl == null || !description.ControlVisible)
            {
                return;
            }
            this.DrawControlMarker(cache, description);
            Rectangle controlBounds = description.ControlBounds;
            this.DrawIntersectedInActiveControls(cache, description);
            Rectangle rect = Rectangle.Inflate(controlBounds, 4, 4);
            Rectangle rectangle = Rectangle.Inflate(controlBounds, 2, 2);
            if (description.HighlightUseInsideBounds)
            {
                rectangle = Rectangle.Inflate(controlBounds, -2, -2);
                rect = controlBounds;
            }
            cache.DrawRectangle(cache.GetPen(Color.Yellow, 3), rectangle);
            if (description.HighlightUseInsideBounds)
            {
                rectangle = Rectangle.Inflate(rectangle, 2, 2);
            }
            else
            {
                rectangle = Rectangle.Inflate(rectangle, 2, 2);
            }
            cache.DrawRectangle(cache.GetPen(Color.Black, 1), rectangle);
            Brush solidBrush = cache.GetSolidBrush(Color.FromArgb(100, Color.Black));
            Rectangle rectangle2 = new Rectangle(rectangle.Right, rectangle.Top + 4, 4, rectangle.Height);
            cache.Paint.FillRectangle(cache.Graphics, solidBrush, rectangle2);
            cache.Graphics.ExcludeClip(rectangle2);
            rectangle2 = new Rectangle(rectangle.X + 4, rectangle.Bottom, rectangle.Width, 4);
            cache.Paint.FillRectangle(cache.Graphics, solidBrush, rectangle2);
            cache.Graphics.ExcludeClip(rectangle2);
            cache.Graphics.ExcludeClip(rect);
        }

        // Token: 0x06000356 RID: 854 RVA: 0x000108BC File Offset: 0x0000EABC
        protected override void DrawBackgroundCore(Graphics g)
        {
            using (GraphicsCache graphicsCache = new GraphicsCache(g))
            {
                if (this.Owner.ActiveControl != null)
                {
                    this.DrawActiveControl(graphicsCache, this.Owner.ActiveControl);
                }
                using (SolidBrush solidBrush = new SolidBrush(Color.FromArgb(180, Color.Gray)))
                {
                    foreach (GuideControlDescription current in this.Owner.Descriptions)
                    {
                        if (current.IsValidNow && this.Owner.ActiveControl != current)
                        {
                            this.DrawInActiveControl(graphicsCache, current);
                        }
                    }
                    foreach (GuideControlDescription current2 in this.Owner.Descriptions)
                    {
                        if (current2.IsValidNow)
                        {
                            g.ExcludeClip(current2.ControlBounds);
                        }
                    }
                    g.FillRectangle(solidBrush, new Rectangle(Point.Empty, base.Bounds.Size));
                }
            }
        }

        // Token: 0x06000358 RID: 856 RVA: 0x00010A48 File Offset: 0x0000EC48
        private void DrawControlMarker(GraphicsCache cache, GuideControlDescription description)
        {
            Rectangle arg_06_0 = description.ControlBounds;
            Rectangle rect = this.CalcInActiveInfoBounds(cache, description);
            if (rect.IsEmpty)
            {
                return;
            }
            cache.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            cache.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
            cache.Graphics.FillEllipse(cache.GetSolidBrush(Color.FromArgb(150, Color.Orange)), rect);
            using (new Pen(Color.White, 1f))
            {
                cache.Graphics.DrawEllipse(Pens.White, rect);
                cache.Graphics.DrawEllipse(Pens.White, Rectangle.Inflate(rect, -1, -1));
            }
            rect.Inflate(-2, -2);
            FontFamily fontFamily = AppearanceObject.DefaultFont.FontFamily;
            int lineSpacing = fontFamily.GetLineSpacing(FontStyle.Regular);
            int emHeight = fontFamily.GetEmHeight(FontStyle.Regular);
            float emSize = (float)rect.Height * 0.7f / ((float)lineSpacing / (float)emHeight);
            using (Font font = new Font(fontFamily, emSize))
            {
                using (StringFormat stringFormat = StringFormat.GenericTypographic.Clone() as StringFormat)
                {
                    stringFormat.Alignment = StringAlignment.Center;
                    stringFormat.LineAlignment = StringAlignment.Center;
                    cache.Graphics.DrawString((this.Owner.Descriptions.IndexOf(description) + 1).ToString(), font, Brushes.White, new RectangleF((float)rect.X, (float)rect.Y, (float)rect.Width, (float)rect.Height), stringFormat);
                }
            }
            cache.Graphics.SmoothingMode = SmoothingMode.Default;
        }

        // Token: 0x06000357 RID: 855 RVA: 0x00010A0C File Offset: 0x0000EC0C
        private void DrawInActiveControl(GraphicsCache cache, GuideControlDescription description)
        {
            Rectangle controlBounds = description.ControlBounds;
            cache.Graphics.FillRectangle(cache.GetSolidBrush(Color.FromArgb(90, Color.Gray)), controlBounds);
            this.DrawControlMarker(cache, description);
        }

        // Token: 0x0600035B RID: 859 RVA: 0x00010DA4 File Offset: 0x0000EFA4
        private void DrawIntersectedInActiveControls(GraphicsCache cache, GuideControlDescription description)
        {
            foreach (GuideControlDescription current in this.Owner.Descriptions)
            {
                if (current != description && current.IsValidNow && current.ControlBounds.IntersectsWith(description.ControlBounds) && this.CalcInActiveInfoBounds(cache, current).IntersectsWith(description.ControlBounds))
                {
                    this.DrawControlMarker(cache, current);
                }
            }
        }

        // Token: 0x170000B2 RID: 178
        public new GuideControlEx Owner
        {
            // Token: 0x06000355 RID: 853 RVA: 0x000108AC File Offset: 0x0000EAAC
            get
            {
                return (GuideControlEx)base.Owner;
            }
        }

        // Token: 0x04000141 RID: 321
        private const int ShadowSize = 4;
    }
}