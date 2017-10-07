using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Description.Controls.Windows;
using DevExpress.Utils.Drawing.Helpers;

namespace DevExpress.Description.Controls
{
    // Token: 0x0200004B RID: 75
    public class GuideControlEx : GuideControl, IMessageFilter
    {
        // Token: 0x060002CE RID: 718 RVA: 0x0000E4F0 File Offset: 0x0000C6F0
        private void ActivateRootControl()
        {
            if (base.Root == null)
            {
                return;
            }
            Form form = base.Root.FindForm();
            if (form == null)
            {
                return;
            }
            form.Activate();
        }

        // Token: 0x060002D4 RID: 724 RVA: 0x0000E5A0 File Offset: 0x0000C7A0
        private bool CheckIsGuideFormMessage(ref Message m)
        {
            if (this.ActiveGuideForm == null || !this.ActiveGuideForm.Visible)
            {
                return false;
            }
            if (this.ActiveGuideForm.IsHandle(m.HWnd))
            {
                return true;
            }
            Control control = Control.FromHandle(m.HWnd);
            return control != null && control.FindForm() == this.ActiveGuideForm;
        }

        // Token: 0x060002EA RID: 746 RVA: 0x0000EB24 File Offset: 0x0000CD24
        private int CompareControls(GuideControlDescription x, GuideControlDescription y)
        {
            if (object.ReferenceEquals(x, y))
            {
                return 0;
            }
            if (x.AssociatedControl != null && y.AssociatedControl != null)
            {
                if (x.AssociatedControl.Contains(y.AssociatedControl))
                {
                    return -1;
                }
                if (y.AssociatedControl.Contains(x.AssociatedControl))
                {
                    return 1;
                }
                if (x.ControlBounds.Contains(y.ControlBounds))
                {
                    return -1;
                }
                if (y.ControlBounds.Contains(x.ControlBounds))
                {
                    return 1;
                }
            }
            return 0;
        }

        // Token: 0x060002DE RID: 734 RVA: 0x0000E8DC File Offset: 0x0000CADC
        protected virtual IGuideForm CreageGuideForm()
        {
            return new GuideFormAlt();
        }

        // Token: 0x060002E7 RID: 743 RVA: 0x0000EA69 File Offset: 0x0000CC69
        protected override DXGuideLayeredWindow CreateWindow()
        {
            return new DXGuideLayeredWindowEx(this);
        }

        // Token: 0x060002E8 RID: 744 RVA: 0x0000EA74 File Offset: 0x0000CC74
        protected GuideControlDescription FromPoint(Point point)
        {
            List<GuideControlDescription> list = null;
            GuideControlDescription guideControlDescription = null;
            foreach (GuideControlDescription current in base.Descriptions)
            {
                if (current.IsValidNow && current.ControlBounds.Contains(point))
                {
                    if (guideControlDescription == null)
                    {
                        guideControlDescription = current;
                    }
                    else
                    {
                        if (list == null)
                        {
                            list = new List<GuideControlDescription>();
                            list.Add(guideControlDescription);
                        }
                        list.Add(current);
                    }
                }
            }
            if (list == null)
            {
                return guideControlDescription;
            }
            return this.SelectControl(list);
        }

        // Token: 0x060002DA RID: 730 RVA: 0x0000E7EC File Offset: 0x0000C9EC
        private void GenerateMouseMove()
        {
            Point point = base.ConvertPoint(base.Root.PointToClient(Control.MousePosition));
            this.OnMouseMove(new MouseEventArgs(MouseButtons.None, 0, point.X, point.Y, 0));
        }

        // Token: 0x060002D6 RID: 726 RVA: 0x0000E640 File Offset: 0x0000C840
        protected MouseEventArgs GetMouseArgs(ref Message msg)
        {
            int num = msg.WParam.ToInt32();
            MouseButtons mouseButtons = MouseButtons.None;
            if ((num & 1) != 0)
            {
                mouseButtons |= MouseButtons.Left;
            }
            if ((num & 2) != 0)
            {
                mouseButtons |= MouseButtons.Right;
            }
            Point point = this.PointToFormBounds(msg.HWnd, msg.LParam);
            return new MouseEventArgs(mouseButtons, 1, point.X, point.Y, 0);
        }

        // Token: 0x060002D0 RID: 720 RVA: 0x0000E524 File Offset: 0x0000C724
        private void HookMouse()
        {
            if (this.hasMessageFilter)
            {
                return;
            }
            this.hasMessageFilter = true;
            Application.AddMessageFilter(this);
        }

        // Token: 0x060002E2 RID: 738 RVA: 0x0000E968 File Offset: 0x0000CB68
        private bool IsKeyboardMessage(ref Message m)
        {
            switch (m.Msg)
            {
                case 256:
                case 257:
                case 260:
                case 261:
                    return true;
            }
            return false;
        }

        // Token: 0x060002E3 RID: 739 RVA: 0x0000E9A8 File Offset: 0x0000CBA8
        private bool IsMouseMessage(ref Message m)
        {
            int msg = m.Msg;
            if (msg != 160)
            {
                switch (msg)
                {
                    case 512:
                    case 513:
                    case 514:
                    case 515:
                    case 516:
                    case 517:
                    case 518:
                    case 519:
                    case 520:
                    case 521:
                    case 522:
                    case 526:
                        return true;
                    case 523:
                    case 524:
                    case 525:
                        break;
                    default:
                        switch (msg)
                        {
                            case 673:
                            case 675:
                                return true;
                        }
                        break;
                }
                return false;
            }
            return true;
        }

        // Token: 0x060002E6 RID: 742 RVA: 0x0000EA53 File Offset: 0x0000CC53
        protected virtual void OnActiveControlChanged()
        {
            if (!this.IsVisible)
            {
                return;
            }
            base.Window.Invalidate();
        }

        // Token: 0x060002DF RID: 735 RVA: 0x0000E8E3 File Offset: 0x0000CAE3
        private void OnActiveGuideForm_FormClosed(object sender, EventArgs e)
        {
            this.ActiveGuideForm = null;
        }

        // Token: 0x060002D1 RID: 721 RVA: 0x0000E53C File Offset: 0x0000C73C
        protected override void OnHide()
        {
            base.OnHide();
            this.ActiveGuideForm = null;
            this.UnHookMouse();
        }

        // Token: 0x060002DD RID: 733 RVA: 0x0000E840 File Offset: 0x0000CA40
        private bool OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.Hide();
                return true;
            }
            if (e.Button == MouseButtons.Left)
            {
                GuideControlDescription guideControlDescription = this.FromPoint(e.Location);
                if (guideControlDescription != null && guideControlDescription != this.ActiveControl)
                {
                    this.ActiveGuideForm = null;
                    this.ActiveControl = guideControlDescription;
                }
                if (this.ActiveControl != null && this.ActiveGuideForm == null)
                {
                    this.ActiveGuideForm = this.CreageGuideForm();
                    this.ActiveGuideForm.Show(this, this.ActiveControl);
                    this.ActiveGuideForm.FormClosed += new EventHandler(this.OnActiveGuideForm_FormClosed);
                }
            }
            return true;
        }

        // Token: 0x060002DB RID: 731 RVA: 0x0000E82D File Offset: 0x0000CA2D
        private void OnMouseLeave(ref Message m)
        {
            this.trackMouse = false;
            this.GenerateMouseMove();
        }

        // Token: 0x060002E0 RID: 736 RVA: 0x0000E8EC File Offset: 0x0000CAEC
        private bool OnMouseMove(MouseEventArgs e)
        {
            GuideControlDescription guideControlDescription = this.FromPoint(e.Location);
            if (this.ActiveGuideForm == null)
            {
                Cursor.Current = ((guideControlDescription == null) ? Cursors.Arrow : Cursors.Help);
            }
            this.ActiveControl = guideControlDescription;
            return true;
        }

        // Token: 0x060002DC RID: 732 RVA: 0x0000E83C File Offset: 0x0000CA3C
        private bool OnMouseUp(MouseEventArgs e)
        {
            return true;
        }

        // Token: 0x060002CF RID: 719 RVA: 0x0000E51C File Offset: 0x0000C71C
        protected override void OnShowing()
        {
            this.HookMouse();
        }

        // Token: 0x060002D7 RID: 727 RVA: 0x0000E6A4 File Offset: 0x0000C8A4
        protected virtual Point PointToFormBounds(IntPtr hwnd, Point pt)
        {
            NativeMethods.POINT pOINT = new NativeMethods.POINT(pt);
            NativeMethods.ClientToScreen(hwnd, ref pOINT);
            return base.ConvertPoint(base.Root.PointToClient(new Point(pOINT.X, pOINT.Y)));
        }

        // Token: 0x060002D8 RID: 728 RVA: 0x0000E6EC File Offset: 0x0000C8EC
        public Point PointToFormBounds(IntPtr hwnd, IntPtr ptr)
        {
            Point pt = Point.Empty;
            try
            {
                pt = new Point((int)ptr);
            }
            catch (Exception)
            {
                pt = Point.Empty;
            }
            return this.PointToFormBounds(hwnd, pt);
        }

        // Token: 0x060002D5 RID: 725 RVA: 0x0000E5FC File Offset: 0x0000C7FC
        protected virtual bool ProcessKeyboard(ref Message m)
        {
            if (m.Msg == 256 && m.WParam.ToInt32() == 27)
            {
                if (this.ActiveGuideForm != null)
                {
                    this.ActiveGuideForm = null;
                    return true;
                }
                this.Hide();
            }
            return true;
        }

        // Token: 0x060002D9 RID: 729 RVA: 0x0000E730 File Offset: 0x0000C930
        protected virtual bool ProcessMouse(ref Message m)
        {
            int msg = m.Msg;
            if (msg != 160)
            {
                switch (msg)
                {
                    case 512:
                        this.TrackMouseLeaveMessage(m.HWnd);
                        return this.OnMouseMove(this.GetMouseArgs(ref m));
                    case 513:
                    case 516:
                        return this.OnMouseDown(this.GetMouseArgs(ref m));
                    case 514:
                    case 517:
                        return this.OnMouseUp(this.GetMouseArgs(ref m));
                    case 515:
                    case 518:
                        return true;
                    case 519:
                    case 520:
                    case 521:
                    case 523:
                    case 524:
                    case 525:
                        break;
                    case 522:
                    case 526:
                        return true;
                    default:
                        if (msg == 675)
                        {
                            this.OnMouseLeave(ref m);
                            return true;
                        }
                        break;
                }
                return false;
            }
            this.GenerateMouseMove();
            return true;
        }

        // Token: 0x060002E9 RID: 745 RVA: 0x0000EB08 File Offset: 0x0000CD08
        private GuideControlDescription SelectControl(List<GuideControlDescription> controls)
        {
            controls.Sort(new Comparison<GuideControlDescription>(this.CompareControls));
            return controls.Last<GuideControlDescription>();
        }

        // Token: 0x060002D3 RID: 723 RVA: 0x0000E570 File Offset: 0x0000C770
        bool IMessageFilter.PreFilterMessage(ref Message m)
        {
            if (this.IsKeyboardMessage(ref m))
            {
                return this.ProcessKeyboard(ref m);
            }
            return !this.CheckIsGuideFormMessage(ref m) && this.IsMouseMessage(ref m) && this.ProcessMouse(ref m);
        }

        // Token: 0x060002E1 RID: 737 RVA: 0x0000E92C File Offset: 0x0000CB2C
        private void TrackMouseLeaveMessage(IntPtr hwnd)
        {
            if (this.trackMouse)
            {
                return;
            }
            if (!NativeMethods.TrackMouseEvent(new NativeMethods.TRACKMOUSEEVENTStruct
            {
                dwFlags = 3,
                hwndTrack = hwnd
            }))
            {
                return;
            }
            this.trackMouse = true;
        }

        // Token: 0x060002D2 RID: 722 RVA: 0x0000E551 File Offset: 0x0000C751
        private void UnHookMouse()
        {
            if (!this.hasMessageFilter)
            {
                return;
            }
            this.trackMouse = false;
            this.hasMessageFilter = false;
            Application.RemoveMessageFilter(this);
        }

        // Token: 0x1700009C RID: 156
        public GuideControlDescription ActiveControl
        {
            // Token: 0x060002E4 RID: 740 RVA: 0x0000EA29 File Offset: 0x0000CC29
            get
            {
                return this.activeControl;
            }
            // Token: 0x060002E5 RID: 741 RVA: 0x0000EA31 File Offset: 0x0000CC31
            set
            {
                if (this.ActiveControl == value)
                {
                    return;
                }
                if (this.ActiveGuideForm != null)
                {
                    return;
                }
                this.activeControl = value;
                this.OnActiveControlChanged();
            }
        }

        // Token: 0x1700009B RID: 155
        protected IGuideForm ActiveGuideForm
        {
            // Token: 0x060002CC RID: 716 RVA: 0x0000E4BC File Offset: 0x0000C6BC
            get
            {
                return this.activeGuideForm;
            }
            // Token: 0x060002CD RID: 717 RVA: 0x0000E4C4 File Offset: 0x0000C6C4
            set
            {
                if (this.ActiveGuideForm == value)
                {
                    return;
                }
                if (this.activeGuideForm != null)
                {
                    this.activeGuideForm.Dispose();
                    this.ActivateRootControl();
                }
                this.activeGuideForm = value;
            }
        }

        // Token: 0x04000126 RID: 294
        private GuideControlDescription activeControl;

        // Token: 0x04000124 RID: 292
        private IGuideForm activeGuideForm;

        // Token: 0x04000123 RID: 291
        private bool hasMessageFilter;

        // Token: 0x04000125 RID: 293
        private bool trackMouse;
    }
}
