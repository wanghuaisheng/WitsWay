using System;
using System.Drawing;
using System.Windows;
using System.Windows.Interop;
using DevExpress.NoteHint;

namespace DevExpress.Description.Controls
{
    // Token: 0x02000054 RID: 84
    public class GuideFormAlt : IGuideForm
    {
        // Token: 0x06000337 RID: 823 RVA: 0x0001034E File Offset: 0x0000E54E
        void IGuideForm.Dispose()
        {
            this.formClosed = null;
            this.note.Hide();
        }

        // Token: 0x0600033E RID: 830 RVA: 0x00010500 File Offset: 0x0000E700
        bool IGuideForm.IsHandle(IntPtr hwnd)
        {
            if (this.note == null || hwnd == IntPtr.Zero)
            {
                return false;
            }
            HwndSource hwndSource = HwndSource.FromHwnd(hwnd);
            if (hwndSource == null)
            {
                return false;
            }
            Window window = (Window)hwndSource.RootVisual;
            return window == this.note;
        }

        // Token: 0x06000339 RID: 825 RVA: 0x000103A4 File Offset: 0x0000E5A4
        void IGuideForm.Show(GuideControl owner, GuideControlDescription description)
        {
            this.note = new NoteWindow();
            WindowInteropHelper windowInteropHelper = new WindowInteropHelper(this.note);
            windowInteropHelper.Owner = owner.Window.Handle;
            this.note.IsVisibleChanged += delegate(object s, DependencyPropertyChangedEventArgs e)
            {
                if (!this.note.IsVisible && this.formClosed != null)
                {
                    this.formClosed(this, EventArgs.Empty);
                }
            };
            string text = "";
            if (!string.IsNullOrEmpty(description.Description))
            {
                text = description.Description;
            }
            else
            {
                text = string.Format("<b>{0}</b><br>", description.GetTypeName()) + text;
            }
            this.note.ShowHtmlCloseButton = true;
            this.note.SetHtmlContent(text, description);
            Rectangle screenBounds = description.ScreenBounds;
            this.note.HintPosition = NoteHintPosition.Down;
            this.note.Show(new Rect((double)screenBounds.X, (double)screenBounds.Y, (double)screenBounds.Width, (double)screenBounds.Height));
        }

        // Token: 0x170000AC RID: 172
        bool IGuideForm.Visible
        {
            // Token: 0x06000338 RID: 824 RVA: 0x00010362 File Offset: 0x0000E562
            get
            {
                return this.note != null && this.note.IsVisible;
            }
        }

        event// Token: 0x1400000E RID: 14
        EventHandler IGuideForm.FormClosed
        {
            // Token: 0x0600033C RID: 828 RVA: 0x000104ED File Offset: 0x0000E6ED
            add
            {
                this.formClosed += value;
            }
            // Token: 0x0600033D RID: 829 RVA: 0x000104F6 File Offset: 0x0000E6F6
            remove
            {
                this.formClosed -= value;
            }
        }

        // Token: 0x1400000D RID: 13
        // Token: 0x0600033A RID: 826 RVA: 0x00010480 File Offset: 0x0000E680
        // Token: 0x0600033B RID: 827 RVA: 0x000104B8 File Offset: 0x0000E6B8
        private event EventHandler formClosed;

        // Token: 0x0400013D RID: 317
        private NoteWindow note;
    }
}
