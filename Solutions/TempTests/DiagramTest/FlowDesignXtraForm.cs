using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Diagram.Core;
using DevExpress.Diagram.Core.Native;
using DevExpress.Diagram.Core.Themes;
using DevExpress.XtraDiagram;
using DevExpress.XtraDiagram.Designer;
using DevExpress.XtraDiagram.Native;
using DevExpress.XtraDiagram.Utils;
using WitsWay.Utilities.Extends;
using WitsWay.Utilities.Win;

namespace WitsWay.TempTests.DiagramTest
{
    public partial class FlowDesignXtraForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FlowDesignXtraForm()
        {
            InitializeComponent();
        }

        private void XtraForm1_Load(object sender, EventArgs e)
        {
            diagramControl.SelectionChanged += DiagramControl_SelectionChanged;
            diagramControl.BackgroundImageChanged += DiagramControl_BackgroundImageChanged;
            diagramControl.CustomDrawBackground += DiagramControl_CustomDrawBackground;

            //PageSize
            diagramControl.OptionsView.PageSize = new SizeF(550, 400);
            diagramControl.FitToPage();
            //GridSize
            diagramControl.OptionsView.GridSize = new SizeF(50, 50);
            //Draw Grid and Rulers
            diagramControl.OptionsView.ShowGrid = false;
            diagramControl.OptionsView.ShowRulers = false;
            //////Select Items
            ////diagramControl.SelectItems(diagramControl.Items[0], diagramControl.Items[1]);
            diagramControl.MouseClick += DiagramControl_MouseClick;
        }

        private void DiagramControl_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                //var item= diagramControl.CalcHitItem(diagramControl.PointToControl(new PointFloat(MousePosition)));
                var item = diagramControl.CalcHitItem(e.Location);
                if (item == null) return;
                if (item.IsType<DiagramConnector>())
                {
                    var connector = (DiagramConnector)item;
                    _popupMenuConnector.ShowPopup(MousePosition);
                }
                else if (item.IsType<DiagramShape>())
                {
                    var shape = (DiagramShape)item;
                    _popupMenuItem.ShowPopup(MousePosition);
                }
            }
        }



        //diagramControl.MouseHover += DiagramControl_MouseHover;
        //diagramControl.MouseMove += DiagramControl_MouseMove;
        //private void DiagramControl_MouseMove(object sender, MouseEventArgs e)
        //{
        //    var item = diagramControl.CalcHitItem(diagramControl.PointToControl(new PointFloat(MousePosition)));
        //    if (item == null) return;
        //    var shape = item as DiagramShape;
        //    UtilityHelper.ShowInfoMessage(shape.Shape.Name);
        //}

        //private void DiagramControl_MouseHover(object sender, EventArgs e)
        //{
        //    var item = diagramControl.CalcHitItem(MousePosition);//diagramControl.PointToControl(new PointFloat(MousePosition)));
        //    if (item != null)
        //    {

        //    }
        //}

        #region [Selection]

        private bool _isSelectionLocked;
        const int DefaultStrokeThickness = 2;
        const int SelectedStrokeThickness = 4;
        //void TreeListControlFocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        //{
        //    //DoLockedSelectionAction(() => {
        //    //    Employee selectedEmployee = treeListControl1.GetDataRecordByNode(e.Node) as Employee;
        //    //    DiagramItem diagramItem = null;
        //    //    if (selectedEmployee != null)
        //    //        diagramItem = diagramControl.Items.FirstOrDefault(x => x.DataContext == selectedEmployee);
        //    //    if (diagramItem != null)
        //    //    {
        //    //        diagramControl.SelectItem(diagramItem);
        //    //        diagramControl.BringItemsIntoView(new[] { diagramItem });
        //    //    }
        //    //    else
        //    //    {
        //    //        diagramControl.ClearSelection();
        //    //    }
        //    //});
        //}
        private void DiagramControl_SelectionChanged(object sender, DiagramSelectionChangedEventArgs e)
        {

            DoLockedSelectionAction(() =>
            {
                foreach (var diagramConnector in diagramControl.Items.OfType<DiagramConnector>())
                {
                    var isSelectionRelatedConnector = diagramControl.SelectedItems.Contains((DiagramItem)diagramConnector.BeginItem) || diagramControl.SelectedItems.Contains((DiagramItem)diagramConnector.EndItem);
                    diagramConnector.Appearance.BorderSize = isSelectionRelatedConnector ? SelectedStrokeThickness : DefaultStrokeThickness;
                }
                if (diagramControl.PrimarySelection == null) return;
                var connector = diagramControl.PrimarySelection as DiagramConnector;
                if (connector != null)
                {
                    var selectConnector = connector;
                    _propertyGrid.SelectedObject = selectConnector;
                    if (selectConnector.Tag == null) selectConnector.Tag = DateTime.Now;
                    //UtilityHelper.ShowInfoMessage(selectConnector.Tag.ToString());
                    //selectPersonLabel.Visibility = LayoutVisibility.Always;
                    //personInfoGroup.Visibility = LayoutVisibility.Never;
                }
                else
                {

                    var selectItem = diagramControl.PrimarySelection;
                    _propertyGrid.SelectedObject = selectItem;
                }

                //else
                //{
                //    selectPersonLabel.Visibility = LayoutVisibility.Never;
                //    personInfoGroup.Visibility = LayoutVisibility.Always;

                //    var container = diagramControl.PrimarySelection as DiagramContainer;
                //    var employee = diagramControl.PrimarySelection.DataContext as Employee;
                //    if (container != null && employee != null)
                //    {
                //        pictureEdit.EditValue = employee.ImageData;
                //        labelName.Text = employee.FullName;
                //        labelPhoneNumber.Text = employee.Phone;
                //        labelBirthDate.Text = employee.BirthDate.ToString("MMMM dd, yyyy");
                //        labelAddressLine.Text = employee.AddressLine1;
                //        labelFriends.Text = GetRelationsText(employee, EmployeeRelationship.Friends);
                //        labelKnowEachOther.Text = GetRelationsText(employee, EmployeeRelationship.KnowEachOther);
                //    }
                //}



                //Employee selectedEmployee = null;
                //if (diagramControl.PrimarySelection != null && diagramControl.PrimarySelection.DataContext is Employee)
                //    selectedEmployee = (Employee)diagramControl.PrimarySelection.DataContext;
                //if (selectedEmployee != null)
                //    treeListControl1.FocusedNode = treeListControl1.FindNodeByKeyID(selectedEmployee.Id);
                //else
                //    treeListControl1.FocusedNode = null;
            });
        }
        void DoLockedSelectionAction(Action action)
        {
            if (_isSelectionLocked)
                return;
            _isSelectionLocked = true;
            action();
            _isSelectionLocked = false;
        }

        #endregion

        private void _btnZoomIn_Click(object sender, EventArgs e) => diagramControl.OptionsView.ZoomFactor += 0.1f;

        private void _btnZoomOut_Click(object sender, EventArgs e) => diagramControl.OptionsView.ZoomFactor -= 0.1f;

        private void _btnClear_Click(object sender, EventArgs e) => diagramControl.Items.Clear();

        private void _btnDesign_Click(object sender, EventArgs e)
        {
            var designerForm = new DiagramDesignerForm() { ShowInTaskbar = false, WindowState = FormWindowState.Maximized };
            DiagramDesignerUtils.RunDesigner(diagramControl, designerForm);
        }

        private void _btnCopyItems_Click(object sender, EventArgs e) => diagramControl.CopySelectedItems();

        private void _btnPasteItems_Click(object sender, EventArgs e) => diagramControl.Paste();

        private void _btnCreateObject_Click(object sender, EventArgs e)
        {
            diagramControl.Items.Add(new DiagramShape(BasicShapes.Rectangle, 50, 10, 200, 100));
            diagramControl.Items.Add(new DiagramShape(BasicFlowchartShapes.Subprocess, new Rectangle(50, 50, 150, 100)));
            diagramControl.Items.Add(new DiagramShape(BasicShapes.Decagon, new Rectangle(250, 50, 150, 100)));
            diagramControl.Items.Add(new DiagramShape(ArrowShapes.CurvedLeftArrow, new Rectangle(50, 170, 150, 100)));
            diagramControl.Items.Add(new DiagramShape(DecorativeShapes.Cloud, new Rectangle(250, 170, 150, 100)));
            // 图形模板（Diagram Stencil）
            var descriptions = new List<ShapeDescription>();
            foreach (var a in DiagramToolboxRegistrator.Stencils)
            {
                descriptions.AddRange(a.Shapes.ToList());
            };
            var description = descriptions.First();

            var shape = new DiagramShape(BasicShapes.Rectangle, new Rectangle(200, 100, 200, 150));
            diagramControl.Items.Add(shape);

            //Timer myTimer = new Timer();
            //myTimer.Tick += (sender, e) => {
            //    if (diagramControl.Page == null)
            //    {
            //        myTimer.Stop();
            //        return;
            //    }
            //    shape.Shape = description;
            //    shape.Content = description.Id;
            //    int index = descriptions.IndexOf(description) + 1;
            //    if (index == descriptions.Count)
            //        index = 0;
            //    description = descriptions[index];
            //};
            //myTimer.Interval = 500;
            //myTimer.Start();

        }

        private void _btnDeleteSelected_Click(object sender, EventArgs e)
        {
            diagramControl.DeleteSelectedItems();
        }

        private readonly MemoryStream _memoryStream = new MemoryStream();

        private void _btnSaveToStream_Click(object sender, EventArgs e)
        {
            diagramControl.SaveDocument(_memoryStream);
        }

        private void _btnRestoreFromStream_Click(object sender, EventArgs e)
        {
            if (_memoryStream.Length == 0) { UtilityHelper.ShowInfoMessage("先保存"); return; }
            _memoryStream.Seek(0, SeekOrigin.Begin);
            diagramControl.LoadDocument(_memoryStream);

        }

        private void _btnSaveFile_Click(object sender, EventArgs e)
        {
            diagramControl.SaveFile();
        }

        private void _btnOpenFile_Click(object sender, EventArgs e)
        {
            diagramControl.OpenFile();
        }

        private void _btnDiagramAppearance_Click(object sender, EventArgs e)
        {
            var diagramItem1 = new DiagramShape(BasicShapes.Rectangle, 10, 10, 200, 100) { Content = "Text" };
            diagramControl.Appearance.Shape.Font = new Font("Times New Roman", 40);
            diagramControl.Appearance.Shape.BackColor = Color.Yellow;
            diagramControl.Appearance.Shape.ForeColor = Color.Red;
            diagramControl.Appearance.Shape.BorderColor = Color.Orange;
            diagramControl.Appearance.Shape.BorderSize = 5;

            diagramControl.Items.Add(diagramItem1);
            diagramControl.Items.Add(new DiagramShape(BasicShapes.Rectangle, 10, 150, 200, 100));
            //改变样式

            var diagramShape1 = new DiagramShape(BasicShapes.Rectangle, 10, 150, 200, 100);
            var diagramShape2 = new DiagramShape(BasicShapes.Rectangle, 250, 10, 200, 100);

            diagramShape1.Content = "Text1";
            diagramShape2.Content = "Text2";

            diagramShape1.Appearance.BackColor = Color.Green;
            diagramShape1.Appearance.BorderColor = Color.Orange;
            diagramShape2.Appearance.BorderColor = diagramShape1.Appearance.GetBackColor();
            diagramShape1.Appearance.BorderSize = 5;
            diagramShape2.Appearance.BorderSize = 12;
            diagramShape2.Appearance.Font = new Font("Times New Roman", 20);

            diagramControl.Items.AddRange(diagramShape1, diagramShape2);

            //改变Connector样式
            diagramControl.Appearance.Connector.ForeColor = Color.Red;
            diagramControl.Appearance.Connector.BackColor = Color.Green;

            var diagramShape11 = new DiagramShape(BasicShapes.Rectangle, 50, 50, 50, 50);
            var diagramShape12 = new DiagramShape(BasicShapes.Rectangle, 50, 150, 50, 50);
            var diagramShape13 = new DiagramShape(BasicShapes.Rectangle, 300, 50, 50, 50);
            var diagramShape14 = new DiagramShape(BasicShapes.Rectangle, 300, 150, 50, 50);

            var connector1 = new DiagramConnector(diagramShape11, diagramShape13)
            {
                Content = "Text1",
                CanSelect = true,
                CanDragBeginPoint = false,
                CanDragEndPoint = false
            };


            connector1.Appearance.BackColor = Color.Orange;
            connector1.Appearance.ForeColor = Color.Blue;
            connector1.EndArrow = ArrowDescriptions.Open90;

            var connector2 = new DiagramConnector(diagramShape12, diagramShape14)
            {
                Content = "Text2",
                EndArrow = ArrowDescriptions.Open90
            };

            diagramControl.Items.AddRange(diagramShape11, diagramShape12, diagramShape13, diagramShape14, connector1, connector2);


        }

        private void _btnCheckConnector_Click(object sender, EventArgs e)
        {
            var shapes = diagramControl.Items.OfType<DiagramShape>();
            var diagramShapes = shapes as IList<DiagramShape> ?? shapes.ToList();
            //if (diagramShapes.Any())
            //{
            //    diagramShapes.SafeForEach(shape =>
            //    {

            //    });
            //}
            var connectors = diagramControl.Items.OfType<DiagramConnector>();
            var diagramConnectors = connectors as IList<DiagramConnector> ?? connectors.ToList();
            if (diagramConnectors.Any())
            {
                diagramConnectors.SafeForEach(connector =>
                {
                    if (connector.BeginItem == null || connector.EndItem == null) UtilityHelper.ShowInfoMessage("error");
                });

            }

            if (diagramShapes.Count != diagramConnectors.Count + 1) UtilityHelper.ShowInfoMessage("图形数量比连接数量多1不成立");
        }

        private void _btnExport_Click(object sender, EventArgs e)
        {
            diagramControl.ExportDiagram(DiagramExportFormat.JPEG);
            diagramControl.ExportDiagram(@"D:\流程.jpg", 300, 4);
        }

        private void _bbiPropertyPanelVisiable_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _sidePanelProperty.Visible = !_sidePanelProperty.Visible;
        }

        private DiagramItemStyle _copyStyle;
        private void _bbiCopyConnectorStyle_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var connector = diagramControl.PrimarySelection;
            var appearance = connector?.Appearance;
            if (appearance == null) return;
            var style = new DiagramItemStyle(
                new DiagramItemBrush(appearance.ForeColor, appearance.BackColor, appearance.BorderColor),
                new DiagramFontSettings(appearance.Font.Size, new FontFamilyInfo(appearance.Font.FontFamily.Name),
                     new DiagramFontEffects(appearance.Font.Bold, appearance.Font.Italic, appearance.Font.Underline, appearance.Font.Strikeout)),
                new DiagramItemLineSettings(connector.Weight, connector.Appearance.BorderDashPattern));
            _copyStyle = style;
        }

        private void _bbiApplyConnectorStyle_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_copyStyle == null) return;
            var connector = diagramControl.PrimarySelection;
            var appearance = connector?.Appearance;
            if (appearance == null) return;
            appearance.ForeColor = _copyStyle.Brush.Foreground;
            appearance.BackColor = _copyStyle.Brush.Background;
            appearance.BorderColor = _copyStyle.Brush.Stroke;
            //Font样式
            var fontStyle = FontStyle.Regular;
            var fontEffect = _copyStyle.FontSettings.FontEffects;
            if (fontEffect.IsFontBold) fontStyle |= FontStyle.Bold;
            if (fontEffect.IsFontItalic) fontStyle |= FontStyle.Italic;
            if (fontEffect.IsFontStrikethrough) fontStyle |= FontStyle.Strikeout;
            if (fontEffect.IsFontUnderline) fontStyle |= FontStyle.Underline;
            appearance.Font = new Font(new FontFamily(_copyStyle.FontSettings.FontFamily.Name), (float)_copyStyle.FontSettings.FontSize, fontStyle);
            appearance.BorderDashPattern = _copyStyle.LineSettings.StrokeDashArray;
            connector.Weight = (float)_copyStyle.LineSettings.StrokeThickness;

        }

        private void _btnCommandDrag_Click(object sender, EventArgs e)
        {
            diagramControl.DragOver += DiagramControl_DragOver;
            //DiagramHandler.OnToolboxDragItemStart(e);
            var diagramShape1 = new DiagramShape(BasicShapes.Rectangle, 10, 150, 200, 100);
            //diagramControl.Commands().Execute(DiagramCommandsBase.SelectHexagonToolCommand,  new ShapeTool(BasicShapes.Hexagon));
        }

        private void DiagramControl_DragOver(object sender, DragEventArgs e)
        {
            var handler = new DiagramControlHandler(diagramControl);
            DiagramController controller = new DiagramController(diagramControl);


            diagramControl.Commands().Execute(DiagramCommandsBase.StartDragToolCommand, new ShapeTool(BasicShapes.Hexagon));
        }

        private void _btnSetBackground_Click(object sender, EventArgs e)
        {
            FileDialog dialog = new OpenFileDialog();
            var dr = dialog.ShowDialog(this);
            if (dr != DialogResult.OK) return;
            var fileName = dialog.FileName;
            var img = Image.FromFile(fileName);
            diagramControl.BackgroundImage = img;
            //diagramControl.BackgroundImageLayout = ImageLayout.Stretch;
            //diagramControl.Refresh();
        }

        private void DiagramControl_BackgroundImageChanged(object sender, EventArgs e)
        {
            diagramControl.OptionsView.PageMargin=new Padding(0);
            var width = diagramControl.BackgroundImage.Width;
            var height = diagramControl.BackgroundImage.Height;
            diagramControl.OptionsView.PageSize =new SizeF(width,height); ;
            //var g = diagramControl.CreateGraphics();
            //var graphicsState = g.Save();
            //try
            //{
            //    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            //    g.TranslateTransform(diagramControl.OptionsView.PageMargin.Left, diagramControl.OptionsView.PageMargin.Top);
            //    g.DrawImage(diagramControl.BackgroundImage, new Point(0, 0));
            //}
            //finally
            //{
            //    g.Restore(graphicsState);
            //}
        }


        private void DiagramControl_CustomDrawBackground(object sender, CustomDrawBackgroundEventArgs e)
        {
            if (diagramControl.BackgroundImage == null) return;
            var g = e.Graphics;// diagramControl.CreateGraphics();
            var graphicsState = g.Save();
            try
            {
                //g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                //g.TranslateTransform(diagramControl.OptionsView.PageMargin.Left, diagramControl.OptionsView.PageMargin.Top);
                g.DrawImage(diagramControl.BackgroundImage,new Rectangle(0,0,diagramControl.Width,diagramControl.Height));
            }
            finally
            {
                g.Restore(graphicsState);
            }
        }
    }
}