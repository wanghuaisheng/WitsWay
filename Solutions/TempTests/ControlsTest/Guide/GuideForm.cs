using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Skins;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace DevExpress.Description.Controls
{
    // Token: 0x02000053 RID: 83
    public class GuideForm : XtraForm, IGuideForm
    {
        // Token: 0x06000324 RID: 804 RVA: 0x0000F75F File Offset: 0x0000D95F
        public GuideForm()
        {
            this.InitializeComponent();
        }

        // Token: 0x0600032B RID: 811 RVA: 0x0000FB34 File Offset: 0x0000DD34
        private Rectangle ApplyCenterbounds(Rectangle workingArea, Rectangle controlBounds, Rectangle formBounds, bool horz)
        {
            Point empty = Point.Empty;
            Rectangle result = formBounds;
            if (formBounds.Width <= controlBounds.Width)
            {
                empty.X = controlBounds.X + (controlBounds.Width - formBounds.Width) / 2;
            }
            else
            {
                empty.X = controlBounds.X + (controlBounds.Width - formBounds.Width) / 2;
            }
            if (formBounds.Height <= controlBounds.Height)
            {
                empty.Y = controlBounds.Y + (controlBounds.Height - formBounds.Height) / 2;
            }
            else
            {
                empty.Y = controlBounds.Y + (controlBounds.Height - formBounds.Height) / 2;
            }
            if (horz)
            {
                formBounds.X = empty.X;
            }
            else
            {
                formBounds.Y = empty.Y;
            }
            if (workingArea.Contains(formBounds))
            {
                return formBounds;
            }
            return result;
        }

        // Token: 0x06000325 RID: 805 RVA: 0x0000F76D File Offset: 0x0000D96D
        private void btHide_Click(object sender, EventArgs e)
        {
            base.Close();
            base.Disposed += new EventHandler(this.GuideForm_Disposed);
        }

        // Token: 0x06000332 RID: 818 RVA: 0x0000FE8F File Offset: 0x0000E08F
        bool IGuideForm.IsHandle(IntPtr hwnd)
        {
            return false;
        }

        // Token: 0x06000334 RID: 820 RVA: 0x0000FEB4 File Offset: 0x0000E0B4
        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        // Token: 0x06000329 RID: 809 RVA: 0x0000F828 File Offset: 0x0000DA28
        private Rectangle GetDisplayBounds(GuideControlDescription description)
        {
            Rectangle screenBounds = description.ScreenBounds;
            Rectangle workingArea = Screen.FromRectangle(screenBounds).WorkingArea;
            Rectangle result = this.TryAllBounds(workingArea, screenBounds, (float)screenBounds.Width / (float)screenBounds.Height > 2.5f);
            if (!result.IsEmpty)
            {
                Point point = new Point(Math.Abs(Control.MousePosition.X - result.X), Math.Abs(Control.MousePosition.Y - result.Y));
                Point point2 = new Point(Math.Abs(Control.MousePosition.X - result.Right), Math.Abs(Control.MousePosition.Y - result.Bottom));
                point.X = Math.Min(point.X, point2.X);
                point.Y = Math.Min(point.Y, point2.Y);
                if (point.X > 300 || point.Y > 300)
                {
                    result = Rectangle.Empty;
                }
            }
            if (result.IsEmpty)
            {
                result = this.TryAllBounds(workingArea, new Rectangle(Control.MousePosition, new Size(16, 16)), true);
            }
            if (result.IsEmpty)
            {
                result = RectangleHelper.GetCenterBounds(workingArea, base.Size);
            }
            return result;
        }

        // Token: 0x06000326 RID: 806 RVA: 0x0000F787 File Offset: 0x0000D987
        private void GuideForm_Disposed(object sender, EventArgs e)
        {
            this.formClosed = null;
        }

        // Token: 0x06000335 RID: 821 RVA: 0x0000FED4 File Offset: 0x0000E0D4
        private void InitializeComponent()
        {
            this.panelControl1 = new PanelControl();
            this.btHide = new SimpleButton();
            this.groupControl1 = new GroupControl();
            this.lbDescription = new LabelControl();
            this.labelControl1 = new LabelControl();
            ((ISupportInitialize)this.panelControl1).BeginInit();
            this.panelControl1.SuspendLayout();
            ((ISupportInitialize)this.groupControl1).BeginInit();
            this.groupControl1.SuspendLayout();
            base.SuspendLayout();
            this.panelControl1.BorderStyle = BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.btHide);
            this.panelControl1.Dock = DockStyle.Bottom;
            this.panelControl1.Location = new Point(0, 163);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new Size(543, 10);
            this.panelControl1.TabIndex = 0;
            this.panelControl1.Visible = false;
            this.btHide.DialogResult = DialogResult.Cancel;
            this.btHide.Location = new Point(440, 11);
            this.btHide.Name = "btHide";
            this.btHide.Size = new Size(75, 23);
            this.btHide.TabIndex = 0;
            this.btHide.Text = "Hide";
            this.btHide.Click += new EventHandler(this.btHide_Click);
            this.groupControl1.BorderStyle = BorderStyles.NoBorder;
            this.groupControl1.Controls.Add(this.lbDescription);
            this.groupControl1.Dock = DockStyle.Fill;
            this.groupControl1.Location = new Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Padding = new Padding(3);
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new Size(543, 153);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "Description";
            this.lbDescription.AllowHtmlString = true;
            this.lbDescription.Appearance.Font = new Font("Segoe UI", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
            this.lbDescription.Appearance.TextOptions.VAlignment = VertAlignment.Top;
            this.lbDescription.Appearance.TextOptions.WordWrap = WordWrap.Wrap;
            this.lbDescription.AutoSizeMode = LabelAutoSizeMode.None;
            this.lbDescription.BorderStyle = BorderStyles.NoBorder;
            this.lbDescription.Cursor = Cursors.Default;
            this.lbDescription.Dock = DockStyle.Fill;
            this.lbDescription.Location = new Point(3, 3);
            this.lbDescription.Name = "lbDescription";
            this.lbDescription.Size = new Size(537, 147);
            this.lbDescription.TabIndex = 0;
            this.lbDescription.Text = "Grid\r\n\r\nTo get more information visit <href=https://www.devexpress.com/Products/NET/Controls/WinForms/Grid/>Learn more</href>\r\n";
            this.lbDescription.HyperlinkClick += new HyperlinkClickEventHandler(this.lbDescription_HyperlinkClick);
            this.labelControl1.AutoSizeMode = LabelAutoSizeMode.None;
            this.labelControl1.Dock = DockStyle.Bottom;
            this.labelControl1.Location = new Point(0, 153);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new Size(543, 10);
            this.labelControl1.TabIndex = 0;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.CancelButton = this.btHide;
            base.ClientSize = new Size(543, 173);
            base.Controls.Add(this.groupControl1);
            base.Controls.Add(this.labelControl1);
            base.Controls.Add(this.panelControl1);
            base.FormBorderStyle = FormBorderStyle.SizableToolWindow;
            base.LookAndFeel.SkinName = "Office 2016 Colorful";
            base.LookAndFeel.UseDefaultLookAndFeel = false;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "GuideForm";
            base.ShowInTaskbar = false;
            this.Text = "Description";
            base.TopMost = true;
            ((ISupportInitialize)this.panelControl1).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((ISupportInitialize)this.groupControl1).EndInit();
            this.groupControl1.ResumeLayout(false);
            base.ResumeLayout(false);
        }

        // Token: 0x0600032D RID: 813 RVA: 0x0000FDC8 File Offset: 0x0000DFC8
        private void lbDescription_HyperlinkClick(object sender, HyperlinkClickEventArgs e)
        {
            using (Process process = new Process())
            {
                process.StartInfo = new ProcessStartInfo(e.Link);
                process.Start();
            }
        }

        // Token: 0x06000333 RID: 819 RVA: 0x0000FE92 File Offset: 0x0000E092
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            if (this.formClosed != null)
            {
                this.formClosed(this, EventArgs.Empty);
            }
        }

        // Token: 0x06000328 RID: 808 RVA: 0x0000F814 File Offset: 0x0000DA14
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                base.Close();
            }
            return base.ProcessDialogKey(keyData);
        }

        // Token: 0x06000327 RID: 807 RVA: 0x0000F790 File Offset: 0x0000D990
        public virtual void Show(GuideControl owner, GuideControlDescription description)
        {
            string text = this.lbDescription.Text;
            if (!string.IsNullOrEmpty(description.Description))
            {
                text = description.Description;
            }
            else
            {
                text = string.Format("<b>{0}</b><br>", description.GetTypeName()) + text;
            }
            this.lbDescription.Text = text;
            Rectangle displayBounds = this.GetDisplayBounds(description);
            if (!displayBounds.IsEmpty)
            {
                base.StartPosition = FormStartPosition.Manual;
                base.Bounds = displayBounds;
            }
            base.TopMost = false;
            base.Show(owner.Window);
        }

        // Token: 0x0600032A RID: 810 RVA: 0x0000F984 File Offset: 0x0000DB84
        private Rectangle TryAllBounds(Rectangle workingArea, Rectangle bounds, bool bottomFirst)
        {
            Rectangle result;
            if (this.TryBounds(workingArea, bounds, new Rectangle(bounds.X, bounds.Bottom + 8, base.Size.Width, base.Size.Height), true, out result))
            {
                return result;
            }
            if (bottomFirst && this.TryBounds(workingArea, bounds, new Rectangle(bounds.X, bounds.Y - base.Size.Height - 8, base.Size.Width, base.Size.Height), true, out result))
            {
                return result;
            }
            if (this.TryBounds(workingArea, bounds, new Rectangle(bounds.X - base.Size.Width - 8, bounds.Y - base.Size.Height, base.Size.Width, base.Size.Height), false, out result))
            {
                return result;
            }
            if (this.TryBounds(workingArea, bounds, new Rectangle(bounds.Right + 8, bounds.Y - base.Size.Height, base.Size.Width, base.Size.Height), false, out result))
            {
                return result;
            }
            if (!bottomFirst && this.TryBounds(workingArea, bounds, new Rectangle(bounds.X, bounds.Y - base.Size.Height, base.Size.Width, base.Size.Height), true, out result))
            {
                return result;
            }
            return Rectangle.Empty;
        }

        // Token: 0x0600032C RID: 812 RVA: 0x0000FC1C File Offset: 0x0000DE1C
        private bool TryBounds(Rectangle workingArea, Rectangle controlBounds, Rectangle formBounds, bool horz, out Rectangle bounds)
        {
            bounds = formBounds;
            if (workingArea.Contains(formBounds))
            {
                bounds = this.ApplyCenterbounds(workingArea, controlBounds, formBounds, horz);
                return true;
            }
            if (workingArea.Y <= formBounds.Y && workingArea.Bottom >= formBounds.Bottom)
            {
                if (workingArea.X > formBounds.X)
                {
                    formBounds.X += workingArea.X - formBounds.X;
                }
                if (workingArea.Right < formBounds.Right)
                {
                    formBounds.X -= formBounds.Right - workingArea.Right;
                }
                bounds = formBounds;
                if (!formBounds.IntersectsWith(controlBounds))
                {
                    bounds = this.ApplyCenterbounds(workingArea, controlBounds, formBounds, horz);
                    if (!controlBounds.IntersectsWith(bounds))
                    {
                        return true;
                    }
                }
            }
            if (workingArea.X <= formBounds.X && workingArea.Right >= formBounds.Right)
            {
                if (workingArea.Y > formBounds.Y)
                {
                    formBounds.Y += workingArea.Y - formBounds.Y;
                }
                if (workingArea.Bottom < formBounds.Bottom)
                {
                    formBounds.Y -= formBounds.Bottom - workingArea.Bottom;
                }
                bounds = formBounds;
                if (!formBounds.IntersectsWith(controlBounds))
                {
                    bounds = this.ApplyCenterbounds(workingArea, controlBounds, formBounds, horz);
                    if (!controlBounds.IntersectsWith(bounds))
                    {
                        return true;
                    }
                }
            }
            bounds = Rectangle.Empty;
            return false;
        }

        event// Token: 0x1400000C RID: 12
        EventHandler IGuideForm.FormClosed
        {
            // Token: 0x06000330 RID: 816 RVA: 0x0000FE7D File Offset: 0x0000E07D
            add
            {
                this.formClosed += value;
            }
            // Token: 0x06000331 RID: 817 RVA: 0x0000FE86 File Offset: 0x0000E086
            remove
            {
                this.formClosed -= value;
            }
        }

        // Token: 0x1400000B RID: 11
        // Token: 0x0600032E RID: 814 RVA: 0x0000FE10 File Offset: 0x0000E010
        // Token: 0x0600032F RID: 815 RVA: 0x0000FE48 File Offset: 0x0000E048
        private event EventHandler formClosed;

        // Token: 0x0400013A RID: 314
        private SimpleButton btHide;

        // Token: 0x04000137 RID: 311
        private IContainer components;

        // Token: 0x04000139 RID: 313
        private GroupControl groupControl1;

        // Token: 0x0400013B RID: 315
        private LabelControl labelControl1;

        // Token: 0x0400013C RID: 316
        private LabelControl lbDescription;

        // Token: 0x04000138 RID: 312
        private PanelControl panelControl1;
    }
}
