using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Description.Controls.Windows;
using DevExpress.Skins;
using DevExpress.Utils.Controls;

namespace DevExpress.Description.Controls
{
    // Token: 0x0200004A RID: 74
    public class GuideControl
    {
        // Token: 0x060002C3 RID: 707 RVA: 0x0000E180 File Offset: 0x0000C380
        private void AddDescription(GuideControlDescription description, Control c)
        {
            if (!c.Visible)
            {
                return;
            }
            IGuideDescription guideDescription = c as IGuideDescription;
            if (guideDescription != null)
            {
                description = this.LookupSubType(c, guideDescription, description);
            }
            GuideControlDescription guideControlDescription = description.Clone();
            guideControlDescription.AssociatedControl = c;
            guideControlDescription.ControlBounds = this.ConvertBounds(this.root.RectangleToClient(guideControlDescription.AssociatedControl.RectangleToScreen(guideControlDescription.AssociatedControl.ClientRectangle)));
            guideControlDescription.ScreenBounds = guideControlDescription.AssociatedControl.RectangleToScreen(guideControlDescription.AssociatedControl.ClientRectangle);
            guideControlDescription.ControlVisible = guideControlDescription.AssociatedControl.Visible;
            this.Descriptions.Add(guideControlDescription);
        }

        // Token: 0x060002C1 RID: 705 RVA: 0x0000DFF4 File Offset: 0x0000C1F4
        private int CompareByRect(GuideControlDescription x, GuideControlDescription y)
        {
            if (object.ReferenceEquals(x, y))
            {
                return 0;
            }
            Rectangle controlBounds = x.ControlBounds;
            Rectangle controlBounds2 = y.ControlBounds;
            Point arg_2E_0 = RectangleHelper.GetCenterBounds(controlBounds, new Size(1, 1)).Location;
            Point arg_45_0 = RectangleHelper.GetCenterBounds(controlBounds2, new Size(1, 1)).Location;
            if (controlBounds.Contains(controlBounds2))
            {
                return 1;
            }
            if (controlBounds2.Contains(controlBounds))
            {
                return -1;
            }
            controlBounds2.Offset(-controlBounds.X, -controlBounds.Y);
            controlBounds.Offset(-controlBounds.X, -controlBounds.Y);
            controlBounds.IntersectsWith(controlBounds2);
            int num = this.CompareHeight(controlBounds, controlBounds2);
            if (controlBounds.Right < controlBounds2.X || controlBounds.Right == controlBounds2.X)
            {
                if (num != 0)
                {
                    return -1;
                }
                if (controlBounds.Y < controlBounds2.Y)
                {
                    return -1;
                }
                return 1;
            }
            else if (controlBounds.X < controlBounds2.X || controlBounds.X == controlBounds2.X)
            {
                if (num != 0)
                {
                    return -1;
                }
                if (controlBounds.Y < controlBounds2.Y)
                {
                    return -1;
                }
                return 1;
            }
            else
            {
                if (num != 0)
                {
                    return num;
                }
                if (controlBounds.Y < controlBounds2.Y)
                {
                    return -1;
                }
                return 1;
            }
        }

        // Token: 0x060002C2 RID: 706 RVA: 0x0000E12C File Offset: 0x0000C32C
        private int CompareHeight(Rectangle b1, Rectangle b2)
        {
            if (Math.Abs(b1.Y - b2.Y) >= 25 || Math.Abs(b1.Height - b2.Height) <= 50)
            {
                return 0;
            }
            if (b1.Height < b2.Height)
            {
                return -1;
            }
            return 1;
        }

        // Token: 0x060002C5 RID: 709 RVA: 0x0000E2C5 File Offset: 0x0000C4C5
        protected Rectangle ConvertBounds(Rectangle rectangle)
        {
            if (this.UseClientRectangle)
            {
                return rectangle;
            }
            rectangle.Location = this.ConvertPoint(rectangle.Location);
            return rectangle;
        }

        // Token: 0x060002C6 RID: 710 RVA: 0x0000E2E8 File Offset: 0x0000C4E8
        protected Point ConvertPoint(Point point)
        {
            if (this.UseClientRectangle)
            {
                return point;
            }
            Point point2 = this.root.PointToClient(this.Root.Location);
            point.X -= point2.X;
            point.Y -= point2.Y;
            return point;
        }

        // Token: 0x060002BB RID: 699 RVA: 0x0000DE6C File Offset: 0x0000C06C
        protected virtual DXGuideLayeredWindow CreateWindow()
        {
            return new DXGuideLayeredWindow(this);
        }

        // Token: 0x060002BD RID: 701 RVA: 0x0000DE8C File Offset: 0x0000C08C
        public virtual void Hide()
        {
            if (!this.IsVisible)
            {
                return;
            }
            this.window.Hide();
            this.Root.LocationChanged -= new EventHandler(this.OnRootLocationChanged);
            this.Root.SizeChanged -= new EventHandler(this.OnRootLocationChanged);
            this.Root.Move -= new EventHandler(this.OnRootLocationChanged);
            this.OnHide();
        }

        // Token: 0x060002B5 RID: 693 RVA: 0x0000DD3E File Offset: 0x0000BF3E
        public virtual void Init(List<GuideControlDescription> descriptionTemplates, Control root)
        {
            this.descriptionTemplates = descriptionTemplates;
            this.root = root;
            this.InitControls();
        }

        // Token: 0x060002C0 RID: 704 RVA: 0x0000DF3C File Offset: 0x0000C13C
        private void InitControls()
        {
            List<Control> list = this.ParseAllControls();
            foreach (Control current in list)
            {
                foreach (GuideControlDescription current2 in this.DescriptionTemplates)
                {
                    if (this.IsMatch(current2, current))
                    {
                        this.AddDescription(current2, current);
                        break;
                    }
                }
            }
            this.Descriptions.Sort(new Comparison<GuideControlDescription>(this.CompareByRect));
        }

        // Token: 0x060002C8 RID: 712 RVA: 0x0000E39C File Offset: 0x0000C59C
        protected virtual bool IsMatch(GuideControlDescription description, Control c)
        {
            if (description.ControlType != null && !c.GetType().Equals(description.ControlType))
            {
                return false;
            }
            if (description.ControlTypeName != null)
            {
                string fullName = c.GetType().FullName;
                return fullName == description.ControlTypeName;
            }
            return string.IsNullOrEmpty(description.ControlName) || c.Name == description.ControlName;
        }

        // Token: 0x060002C7 RID: 711 RVA: 0x0000E344 File Offset: 0x0000C544
        protected GuideControlDescription Lookup(List<GuideControlDescription> collection, Control c)
        {
            foreach (GuideControlDescription current in collection)
            {
                if (this.IsMatch(current, c))
                {
                    return current;
                }
            }
            return null;
        }

        // Token: 0x060002C4 RID: 708 RVA: 0x0000E250 File Offset: 0x0000C450
        private GuideControlDescription LookupSubType(Control c, IGuideDescription gdc, GuideControlDescription description)
        {
            string typeName = (description.ControlTypeName == null) ? c.GetType().FullName : description.ControlTypeName;
            if (gdc == null || string.IsNullOrEmpty(gdc.SubType))
            {
                return description;
            }
            GuideControlDescription guideControlDescription = this.DescriptionTemplates.FirstOrDefault((GuideControlDescription q) => q.ControlTypeName == typeName + ":" + gdc.SubType);
            if (guideControlDescription != null)
            {
                return guideControlDescription;
            }
            return description;
        }

        // Token: 0x060002BE RID: 702 RVA: 0x0000DEF8 File Offset: 0x0000C0F8
        protected virtual void OnHide()
        {
        }

        // Token: 0x060002B8 RID: 696 RVA: 0x0000DE50 File Offset: 0x0000C050
        private void OnRootLocationChanged(object sender, EventArgs e)
        {
            this.Hide();
        }

        // Token: 0x060002BA RID: 698 RVA: 0x0000DE6A File Offset: 0x0000C06A
        protected virtual void OnShowing()
        {
        }

        // Token: 0x060002C9 RID: 713 RVA: 0x0000E414 File Offset: 0x0000C614
        private List<Control> ParseAllControls()
        {
            List<Control> list = new List<Control>();
            this.ParseAllControls(list, this.Root);
            return list;
        }

        // Token: 0x060002CA RID: 714 RVA: 0x0000E438 File Offset: 0x0000C638
        private void ParseAllControls(List<Control> res, Control parent)
        {
            res.Add(parent);
            GuideControlDescription guideControlDescription = this.Lookup(this.DescriptionTemplates, parent);
            if (guideControlDescription != null && !guideControlDescription.AllowParseChildren)
            {
                return;
            }
            if (parent.HasChildren)
            {
                foreach (Control parent2 in parent.Controls)
                {
                    this.ParseAllControls(res, parent2);
                }
            }
        }

        // Token: 0x060002B7 RID: 695 RVA: 0x0000DD5C File Offset: 0x0000BF5C
        public void Show()
        {
            if (!this.HasValidDescriptions)
            {
                return;
            }
            if (this.IsVisible || this.Root == null || !this.Root.Visible)
            {
                return;
            }
            this.OnShowing();
            this.window = this.CreateWindow();
            Rectangle bounds = this.root.RectangleToScreen(this.root.ClientRectangle);
            if (!this.UseClientRectangle)
            {
                bounds = this.root.RectangleToScreen(this.root.RectangleToClient(this.root.Bounds));
            }
            this.window.Bounds = bounds;
            this.window.Create(this.Root);
            this.window.Show();
            this.Root.LocationChanged += new EventHandler(this.OnRootLocationChanged);
            this.Root.SizeChanged += new EventHandler(this.OnRootLocationChanged);
            this.Root.Move += new EventHandler(this.OnRootLocationChanged);
        }

        // Token: 0x17000094 RID: 148
        public List<GuideControlDescription> Descriptions
        {
            // Token: 0x060002B2 RID: 690 RVA: 0x0000DD00 File Offset: 0x0000BF00
            get
            {
                if (this.descriptions == null)
                {
                    this.descriptions = new List<GuideControlDescription>();
                }
                return this.descriptions;
            }
        }

        // Token: 0x17000095 RID: 149
        public List<GuideControlDescription> DescriptionTemplates
        {
            // Token: 0x060002B3 RID: 691 RVA: 0x0000DD1B File Offset: 0x0000BF1B
            get
            {
                if (this.descriptionTemplates == null)
                {
                    this.descriptionTemplates = new List<GuideControlDescription>();
                }
                return this.descriptionTemplates;
            }
        }

        // Token: 0x1700009A RID: 154
        public bool HasValidDescriptions
        {
            // Token: 0x060002BF RID: 703 RVA: 0x0000DF0C File Offset: 0x0000C10C
            get
            {
                return this.Descriptions.Count((GuideControlDescription q) => q.AssociatedControl != null && q.ControlVisible) > 0;
            }
        }

        // Token: 0x17000099 RID: 153
        public virtual bool IsVisible
        {
            // Token: 0x060002BC RID: 700 RVA: 0x0000DE74 File Offset: 0x0000C074
            get
            {
                return this.window != null && this.window.Visible;
            }
        }

        // Token: 0x17000096 RID: 150
        public Control Root
        {
            // Token: 0x060002B4 RID: 692 RVA: 0x0000DD36 File Offset: 0x0000BF36
            get
            {
                return this.root;
            }
        }

        // Token: 0x17000098 RID: 152
        protected virtual bool UseClientRectangle
        {
            // Token: 0x060002B9 RID: 697 RVA: 0x0000DE58 File Offset: 0x0000C058
            get
            {
                return !(this.Root is Form);
            }
        }

        // Token: 0x17000097 RID: 151
        protected internal DXGuideLayeredWindow Window
        {
            // Token: 0x060002B6 RID: 694 RVA: 0x0000DD54 File Offset: 0x0000BF54
            get
            {
                return this.window;
            }
        }

        // Token: 0x0400011E RID: 286
        private List<GuideControlDescription> descriptions;

        // Token: 0x0400011F RID: 287
        private List<GuideControlDescription> descriptionTemplates;

        // Token: 0x04000120 RID: 288
        private Control root;

        // Token: 0x04000121 RID: 289
        private DXGuideLayeredWindow window;
    }
}
