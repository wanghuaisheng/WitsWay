using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using DevExpress.Utils.Drawing.Helpers;
using DevExpress.Utils.Internal;

namespace DevExpress.Description.Controls.Windows
{
    // Token: 0x02000055 RID: 85
    public class DXLayeredWindowAlt : DXLayeredWindow
    {
        // Token: 0x06000341 RID: 833 RVA: 0x00010550 File Offset: 0x0000E750
        public DXLayeredWindowAlt()
        {
            base.TransparencyKey = Color.Empty;
            base.Alpha = 255;
        }

        // Token: 0x06000346 RID: 838 RVA: 0x0001064C File Offset: 0x0000E84C
        private Bitmap CheckBuffer(int width, int height)
        {
            if (width < 1 || height < 1)
            {
                return null;
            }
            if (this.buffer == null)
            {
                return new Bitmap(width, height);
            }
            if (this.buffer.Width < width || this.buffer.Height < height)
            {
                this.buffer.Dispose();
                this.buffer = new Bitmap(width, height);
            }
            return this.buffer;
        }

        // Token: 0x0600034A RID: 842 RVA: 0x0001072A File Offset: 0x0000E92A
        private bool CheckVisible(Control control)
        {
            return control.FindForm() != null && (control.Parent == null || (control.Parent.Visible && this.CheckVisible(control.Parent)));
        }

        // Token: 0x06000343 RID: 835 RVA: 0x00010571 File Offset: 0x0000E771
        public void CleanUp()
        {
            if (base.IsCreated)
            {
                this.DestroyHandle();
            }
            if (this.buffer != null)
            {
                this.buffer.Dispose();
            }
            this.buffer = null;
        }

        // Token: 0x06000345 RID: 837 RVA: 0x000105AC File Offset: 0x0000E7AC
        protected virtual void Draw()
        {
            if (this.Size.Width < 1 || this.Size.Height < 1)
            {
                return;
            }
            using (Bitmap bitmap = this.CheckBuffer(this.Size.Width, this.Size.Height))
            {
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    this.DrawBackgroundCore(graphics);
                    this.UpdateLayered(bitmap);
                }
            }
        }

        // Token: 0x0600034C RID: 844 RVA: 0x0001075D File Offset: 0x0000E95D
        protected override void DrawBackground(Graphics g)
        {
        }

        // Token: 0x06000348 RID: 840 RVA: 0x000106B8 File Offset: 0x0000E8B8
        protected virtual void DrawBackgroundCore(Graphics g)
        {
            g.Clear(Color.Transparent);
            using (SolidBrush solidBrush = new SolidBrush(Color.FromArgb(1, Color.LightGray)))
            {
                g.FillRectangle(solidBrush, new Rectangle(Point.Empty, this.Size));
            }
            PaintEventArgs e = new PaintEventArgs(g, Rectangle.Empty);
            this.ProcessPaint(e);
        }

        // Token: 0x0600034B RID: 843 RVA: 0x0001075B File Offset: 0x0000E95B
        protected override void DrawForeground(Graphics g)
        {
        }

        // Token: 0x06000344 RID: 836 RVA: 0x0001059B File Offset: 0x0000E79B
        public override void Invalidate()
        {
            if (base.Visible)
            {
                this.Draw();
            }
        }

        // Token: 0x06000349 RID: 841 RVA: 0x00010728 File Offset: 0x0000E928
        protected virtual void ProcessPaint(PaintEventArgs e)
        {
        }

        // Token: 0x0600034E RID: 846 RVA: 0x00010764 File Offset: 0x0000E964
        private void UpdateLayered(Bitmap bmp)
        {
            if (bmp.PixelFormat != PixelFormat.Format32bppArgb)
            {
                return;
            }
            Rectangle rectangle = this.ValidateBounds(base.Bounds);
            if (rectangle.IsEmpty)
            {
                return;
            }
            IntPtr intPtr = NativeMethods.GetDC(IntPtr.Zero);
            IntPtr intPtr2 = NativeMethods.CreateCompatibleDC(intPtr);
            IntPtr hbitmap = bmp.GetHbitmap(Color.FromArgb(0));
            IntPtr obj = NativeMethods.SelectObject(intPtr2, hbitmap);
            NativeMethods.BLENDFUNCTION bLENDFUNCTION = new NativeMethods.BLENDFUNCTION
            {
                BlendOp = 0,
                BlendFlags = 0,
                SourceConstantAlpha = 255,
                AlphaFormat = 1
            };
            NativeMethods.POINT pOINT = new NativeMethods.POINT(rectangle.Left, rectangle.Top);
            NativeMethods.SIZE sIZE = new NativeMethods.SIZE(rectangle.Width, rectangle.Height);
            NativeMethods.POINT pOINT2 = new NativeMethods.POINT(0, 0);
            NativeMethods.UpdateLayeredWindow(base.Handle, intPtr, ref pOINT, ref sIZE, intPtr2, ref pOINT2, 0, ref bLENDFUNCTION, 2);
            NativeMethods.SelectObject(intPtr2, obj);
            NativeMethods.DeleteObject(hbitmap);
            NativeMethods.DeleteDC(intPtr2);
            NativeMethods.ReleaseDC(IntPtr.Zero, intPtr);
        }

        // Token: 0x06000347 RID: 839 RVA: 0x000106AD File Offset: 0x0000E8AD
        protected override void UpdateLayeredWindow()
        {
            this.Draw();
        }

        // Token: 0x170000AD RID: 173
        public override bool IsTransparent
        {
            // Token: 0x06000342 RID: 834 RVA: 0x0001056E File Offset: 0x0000E76E
            get
            {
                return false;
            }
        }

        // Token: 0x170000AE RID: 174
        protected override bool UseDoubleBuffer
        {
            // Token: 0x0600034D RID: 845 RVA: 0x0001075F File Offset: 0x0000E95F
            get
            {
                return true;
            }
        }

        // Token: 0x0400013F RID: 319
        private Bitmap buffer;
    }
}
