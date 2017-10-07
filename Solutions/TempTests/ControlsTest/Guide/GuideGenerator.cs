using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Interop;
using DevExpress.Demos.XmlSerialization;
using DevExpress.NoteHint;
using DevExpress.Tutorials.Description.Hint;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Ribbon.ViewInfo;

namespace DevExpress.Description.Controls
{
    // Token: 0x0200004E RID: 78
    public class GuideGenerator
    {
        // Token: 0x060002F2 RID: 754 RVA: 0x0000EBE4 File Offset: 0x0000CDE4
        public virtual void CreateWhatsThisItem(RibbonControl ribbon, GuideGetCurrentModuleDelegate getCurrentModule)
        {
            this.getCurrentModule = getCurrentModule;
            BarButtonItem item = new BarButtonItem
            {
                Caption = "What's this"
            };
            ribbon.Items.Add(item);
            item.ItemClick += new ItemClickEventHandler(this.OnWhatsThis);
            ribbon.ToolbarLocation = RibbonQuickAccessToolbarLocation.Above;
            ribbon.Toolbar.ItemLinks.Add(item);
            item.Hint = "That's super hint";
            item.SuperTip = new SuperToolTip();
            item.SuperTip.AllowHtmlText = DefaultBoolean.True;
            item.SuperTip.Items.AddTitle("What's this");
            item.SuperTip.Items.Add("Click here if you want learn more on controls used in demo");
            if (ribbon.FindForm() != null)
            {
                ribbon.FindForm().Load += delegate(object sender, EventArgs e)
                {
                    if (item.Links.Count > 0)
                    {
                        item.Links[0].ShowHint();
                    }
                };
            }
        }

        // Token: 0x060002F3 RID: 755 RVA: 0x0000ED24 File Offset: 0x0000CF24
        public virtual void CreateWhatsThisItemAlt(RibbonControl ribbon, GuideGetCurrentModuleDelegate getCurrentModule)
        {
            this.getCurrentModule = getCurrentModule;
            GuideGenerator.BarWhatsThisItem item = new GuideGenerator.BarWhatsThisItem
            {
                Caption = "What's this",
                Hint = ""
            };
            item.SuperTip = new SuperToolTip();
            ribbon.Items.Add(item);
            item.ItemClick += new ItemClickEventHandler(this.OnWhatsThis);
            ribbon.ToolbarLocation = RibbonQuickAccessToolbarLocation.Above;
            ribbon.Toolbar.ItemLinks.Add(item);
            if (ribbon.FindForm() != null)
            {
                ribbon.FindForm().Load += delegate(object sender, EventArgs e)
                {
                    if (item.Links.Count == 0)
                    {
                        return;
                    }
                    BarItemLink barItemLink = item.Links[0];
                    barItemLink.ShowHint();
                };
            }
        }

        // Token: 0x060002F4 RID: 756 RVA: 0x0000EDD7 File Offset: 0x0000CFD7
        private void DoHide(RibbonControl ribbon, NoteWindow window, ItemClickEventHandler handler)
        {
            ribbon.ItemClick -= handler;
            window.Hide();
        }

        // Token: 0x060002F7 RID: 759 RVA: 0x0000EE78 File Offset: 0x0000D078
        private void GenerateByCode(List<GuideControlDescription> list)
        {
            list.Add(new GuideControlDescription
            {
                ControlTypeName = "DevExpress.XtraGrid.Controls.FindControl",
                AllowParseChildren = false,
                Description = "<b>Find Panel</b>\r\nEnables MS Outlook style search in the Grid Control. <href=https://www.devexpress.com/Products/NET/Controls/WinForms/Grid/>Learn more.</href>\r\n\r\nToolbox Item: <b>GridControl</b>\r\nIncluded in subscriptions: <href=https://www.devexpress.com/Subscriptions/>WinForms, DXperience, Universal</href>\r\n"
            });
            list.Add(new GuideControlDescription
            {
                ControlTypeName = "DevExpress.XtraGrid.GridControl:GridView",
                Description = "\r\n<b>Grid View</b>\r\nEmulates MS Outlook Mail view or MS Access Data Table view.  <href=https://www.devexpress.com/Products/NET/Controls/WinForms/Grid/>Learn more.</href>\r\n\r\nToolbox Item: <b>GridControl</b>\r\nIncluded in subscriptions: <href=https://www.devexpress.com/Subscriptions/>WinForms, DXperience, Universal</href>\r\n"
            });
            list.Add(new GuideControlDescription
            {
                ControlTypeName = "DevExpress.XtraGrid.GridControl:CardView",
                Description = "\r\n<b>Card View</b>\r\nEmulates MS Outlook Contacts view. <href=https://www.devexpress.com/Products/NET/Controls/WinForms/Grid/>Learn more.</href>\r\n\r\nToolbox Item: <b>GridControl</b>\r\nIncluded in subscriptions: <href=https://www.devexpress.com/Subscriptions/>WinForms, DXperience, Universal</href>\r\n"
            });
            list.Add(new GuideControlDescription
            {
                ControlTypeName = "DevExpress.XtraGrid.GridControl:CardView",
                Description = "\r\n<b>Layout View</b>\r\nEmulates MS Outlook Contacts view. <href=https://www.devexpress.com/Products/NET/Controls/WinForms/Grid/>Learn more.</href>\r\n\r\nToolbox Item: <b>GridControl</b>\r\nIncluded in subscriptions: <href=https://www.devexpress.com/Subscriptions/>WinForms, DXperience, Universal</href>\r\n"
            });
            list.Add(new GuideControlDescription
            {
                ControlTypeName = "DevExpress.XtraGrid.GridControl",
                Description = "\r\n<b>Grid View</b>\r\nEmulates MS Outlook Mail view or MS Access Data Table view.  <href=https://www.devexpress.com/Products/NET/Controls/WinForms/Grid/>Learn more.</href>\r\n\r\nToolbox Item: <b>GridControl</b>\r\nIncluded in subscriptions: <href=https://www.devexpress.com/Subscriptions/>WinForms, DXperience, Universal</href>\r\n"
            });
            list.Add(new GuideControlDescription
            {
                ControlTypeName = "DevExpress.XtraBars.Ribbon.RibbonControl",
                HighlightUseInsideBounds = true
            });
            list.Add(new GuideControlDescription
            {
                ControlTypeName = "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
                HighlightUseInsideBounds = true
            });
            list.Add(new GuideControlDescription
            {
                ControlTypeName = "DevExpress.XtraNavBar.NavBarControl"
            });
            list.Add(new GuideControlDescription
            {
                ControlTypeName = "DevExpress.XtraSpreadsheet.SpreadsheetControl"
            });
            list.Add(new GuideControlDescription
            {
                ControlTypeName = "DevExpress.XtraScheduler.SchedulerControl"
            });
            list.Add(new GuideControlDescription
            {
                ControlTypeName = "DevExpress.XtraScheduler.DateNavigator"
            });
            list.Add(new GuideControlDescription
            {
                ControlTypeName = "DevExpress.XtraTreeList.TreeList"
            });
            list.Add(new GuideControlDescription
            {
                ControlTypeName = "DevExpress.XtraEditors.RangeControl"
            });
            list.Add(new GuideControlDescription
            {
                ControlTypeName = "DevExpress.XtraCharts.ChartControl"
            });
            list.Add(new GuideControlDescription
            {
                ControlTypeName = "DevExpress.ProductsDemo.Win.PivotTileControl"
            });
            list.Add(new GuideControlDescription
            {
                ControlTypeName = "DevExpress.XtraPivotGrid.PivotGridControl"
            });
            list.Add(new GuideControlDescription
            {
                ControlTypeName = "DevExpress.XtraMap.MapControl"
            });
            list.Add(new GuideControlDescription
            {
                ControlTypeName = "DevExpress.XtraPdfViewer.PdfViewer",
                AllowParseChildren = false
            });
            list.Add(new GuideControlDescription
            {
                ControlTypeName = "DevExpress.DocumentView.Controls.ViewControl"
            });
            list.Add(new GuideControlDescription
            {
                ControlTypeName = "DevExpress.XtraPrinting.Native.WinControls.BookmarkTreeView"
            });
            list.Add(new GuideControlDescription
            {
                ControlTypeName = "DevExpress.XtraGauges.Win.GaugeControl"
            });
            list.Add(new GuideControlDescription
            {
                ControlTypeName = "DevExpress.Snap.SnapControl"
            });
            list.Add(new GuideControlDescription
            {
                ControlTypeName = "DevExpress.Snap.Extensions.UI.FieldListDockPanel"
            });
            list.Add(new GuideControlDescription
            {
                ControlTypeName = "DevExpress.Snap.Extensions.UI.ReportExplorerDockPanel"
            });
            list.Add(new GuideControlDescription
            {
                ControlTypeName = "DevExpress.XtraRichEdit.RichEditControl"
            });
            list.Add(new GuideControlDescription
            {
                ControlTypeName = "DevExpress.XtraTreeMap.TreeMapControl"
            });
            if (this.AllowEditorDescriptions)
            {
                this.GenerateEditors(list);
            }
        }

        // Token: 0x060002F8 RID: 760 RVA: 0x0000F1A0 File Offset: 0x0000D3A0
        protected virtual void GenerateEditors(List<GuideControlDescription> list)
        {
            list.Add(new GuideControlDescription
            {
                ControlTypeName = "DevExpress.XtraEditors.LabelControl"
            });
            list.Add(new GuideControlDescription
            {
                ControlTypeName = "DevExpress.XtraEditors.SimpleButton"
            });
            list.Add(new GuideControlDescription
            {
                ControlTypeName = "DevExpress.XtraEditors.TextEdit"
            });
            list.Add(new GuideControlDescription
            {
                ControlTypeName = "DevExpress.XtraEditors.ComboBoxEdit"
            });
            list.Add(new GuideControlDescription
            {
                ControlTypeName = "DevExpress.XtraEditors.PictureEdit"
            });
        }

        // Token: 0x060002F6 RID: 758 RVA: 0x0000EE48 File Offset: 0x0000D048
        protected virtual List<GuideControlDescription> GenerateTemplateDescriptions()
        {
            List<GuideControlDescription> list = new List<GuideControlDescription>();
            return XMLSerializer<List<GuideControlDescription>>.LoadXmlFromResources(typeof(GuideGenerator).Assembly, "DevExpress.Tutorials.Description.Guide.xml", null);
        }

        // Token: 0x060002F5 RID: 757 RVA: 0x0000EDE8 File Offset: 0x0000CFE8
        private void OnWhatsThis(object sender, ItemClickEventArgs e)
        {
            if (this.getCurrentModule == null)
            {
                return;
            }
            Control control = this.getCurrentModule();
            IGuideDescriptionProvider guideDescriptionProvider = control as IGuideDescriptionProvider;
            if (control == null || (guideDescriptionProvider != null && !guideDescriptionProvider.Enabled))
            {
                return;
            }
            GuideControl guideControl = new GuideControlEx();
            List<GuideControlDescription> list = this.GenerateTemplateDescriptions();
            if (guideDescriptionProvider != null)
            {
                guideDescriptionProvider.UpdateDescriptions(list);
            }
            guideControl.Init(list, control);
            guideControl.Show();
        }

        // Token: 0x04000128 RID: 296
        public bool AllowEditorDescriptions;

        // Token: 0x04000127 RID: 295
        private GuideGetCurrentModuleDelegate getCurrentModule;

        // Token: 0x0200004F RID: 79
        private class BarWhatsThisItem : BarButtonItem
        {
            // Token: 0x060002FA RID: 762 RVA: 0x0000F230 File Offset: 0x0000D430
            protected override BarItemLink CreateLinkCore(BarItemLinkReadOnlyCollection ALinks, BarItem AItem, object ALinkedObject)
            {
                return new GuideGenerator.BarWhatsThisItemLink(ALinks, AItem, ALinkedObject);
            }
        }

        // Token: 0x02000050 RID: 80
        private class BarWhatsThisItemLink : BarButtonItemLink
        {
            // Token: 0x060002FC RID: 764 RVA: 0x0000F242 File Offset: 0x0000D442
            public BarWhatsThisItemLink(BarItemLinkReadOnlyCollection ALinks, BarItem AItem, object ALinkedObject)
                : base(ALinks, AItem, ALinkedObject)
            {
            }

            // Token: 0x060002FF RID: 767 RVA: 0x0000F481 File Offset: 0x0000D681
            private void DoHide(RibbonControl ribbon, NoteWindow window, ItemClickEventHandler handler)
            {
                this.hintVisible = false;
                ribbon.ItemClick -= handler;
                window.Hide();
                if (this.hintTimer != null)
                {
                    this.hintTimer.Dispose();
                }
                this.hintTimer = null;
            }

            // Token: 0x060002FD RID: 765 RVA: 0x0000F250 File Offset: 0x0000D450
            protected override ToolTipControlInfo GetToolTipInfo(RibbonHitInfo hi, System.Drawing.Point point)
            {
                ToolTipControlInfo toolTipInfo = base.GetToolTipInfo(hi, point);
                toolTipInfo.ImmediateToolTip = true;
                return toolTipInfo;
            }

            // Token: 0x060002FE RID: 766 RVA: 0x0000F33C File Offset: 0x0000D53C
            protected override void OnBeforeShowHint(ToolTipControllerShowEventArgs e)
            {
                e.Show = false;
                if (base.ScreenBounds.IsEmpty || this.hintVisible)
                {
                    return;
                }
                this.hintVisible = true;
                RibbonControl ribbon = base.Ribbon;
                NoteWindow nw = new NoteWindow
                {
                    HintPosition = NoteHintPosition.Down,
                    HintContent = new GuideDescription()
                };
                new WindowInteropHelper(nw).Owner = ribbon.FindForm().Handle;
                nw.ShowHtmlCloseButton = true;
                Rectangle display = this.ScreenBounds;
                nw.ShowActivated = false;
                nw.Show(display);
                ItemClickEventHandler click = null;
                click = delegate(object s1, ItemClickEventArgs e1)
                {
                    this.DoHide(ribbon, nw, click);
                };
                nw.IsVisibleChanged += delegate(object s2, DependencyPropertyChangedEventArgs e2)
                {
                    if (!((Window)s2).IsVisible)
                    {
                        this.DoHide(ribbon, nw, click);
                    }
                };
                ribbon.ItemClick += click;
                this.hintTimer = new Timer();
                int ticks = 0;
                this.hintTimer.Interval = 100;
                this.hintTimer.Tick += delegate(object s3, EventArgs e3)
                {
                    if (ticks++ == 70)
                    {
                        this.DoHide(ribbon, nw, click);
                        return;
                    }
                    if (this.ScreenBounds != display)
                    {
                        this.DoHide(ribbon, nw, click);
                    }
                };
                this.hintTimer.Start();
            }

            // Token: 0x0400012A RID: 298
            private Timer hintTimer;

            // Token: 0x04000129 RID: 297
            private bool hintVisible;
        }
    }
}