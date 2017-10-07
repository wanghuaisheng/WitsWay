namespace WitsWay.TempTests.ControlsTest.Desktops
{
    partial class DesktopUc
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraBars.Docking.CustomHeaderButtonImageOptions customHeaderButtonImageOptions1 = new DevExpress.XtraBars.Docking.CustomHeaderButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraBars.Docking2010.Views.Widget.WidgetDockingContainer widgetDockingContainer1 = new DevExpress.XtraBars.Docking2010.Views.Widget.WidgetDockingContainer();
            DevExpress.XtraBars.Docking2010.Views.Widget.WidgetDockingContainer widgetDockingContainer2 = new DevExpress.XtraBars.Docking2010.Views.Widget.WidgetDockingContainer();
            DevExpress.XtraBars.Docking2010.Views.Widget.WidgetDockingContainer widgetDockingContainer3 = new DevExpress.XtraBars.Docking2010.Views.Widget.WidgetDockingContainer();
            this._widgetToDoList = new DevExpress.XtraBars.Docking2010.Views.Widget.Document(this.components);
            this._widgetCalendar = new DevExpress.XtraBars.Docking2010.Views.Widget.Document(this.components);
            this._documentManager = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
            this._widgetView = new DevExpress.XtraBars.Docking2010.Views.Widget.WidgetView(this.components);
            ((System.ComponentModel.ISupportInitialize)(this._widgetToDoList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._widgetCalendar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._documentManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._widgetView)).BeginInit();
            this.SuspendLayout();
            // 
            // _widgetToDoList
            // 
            this._widgetToDoList.Caption = "ToDoList";
            this._widgetToDoList.ControlName = "ToDoList";
            this._widgetToDoList.ControlTypeName = "ControlsTest.Widgets.ToDoList";
            // 
            // _widgetCalendar
            // 
            this._widgetCalendar.Caption = "Calendar";
            this._widgetCalendar.ControlName = "Calendar";
            this._widgetCalendar.ControlTypeName = "ControlsTest.Widgets.Calendar";
            customHeaderButtonImageOptions1.SvgImage = global::WitsWay.TempTests.ControlsTest.Properties.Resources.settings;
            customHeaderButtonImageOptions1.SvgImageSize = new System.Drawing.Size(12, 12);
            this._widgetCalendar.CustomHeaderButtons.AddRange(new DevExpress.XtraBars.Docking2010.IButton[] {
            new DevExpress.XtraBars.Docking.CustomHeaderButton("设置", false, customHeaderButtonImageOptions1, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, serializableAppearanceObject1, 1, -1)});
            this._widgetCalendar.CustomButtonClick += new DevExpress.XtraBars.Docking2010.ButtonEventHandler(this._widgetCalendar_CustomButtonClick);
            // 
            // _documentManager
            // 
            this._documentManager.ContainerControl = this;
            this._documentManager.View = this._widgetView;
            this._documentManager.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this._widgetView});
            // 
            // _widgetView
            // 
            this._widgetView.Documents.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseDocument[] {
            this._widgetToDoList,
            this._widgetCalendar});
            this._widgetView.FreeLayoutProperties.FreeLayoutItems.AddRange(new DevExpress.XtraBars.Docking2010.Views.Widget.Document[] {
            this._widgetToDoList,
            this._widgetCalendar});
            this._widgetView.LayoutMode = DevExpress.XtraBars.Docking2010.Views.Widget.LayoutMode.FreeLayout;
            this._widgetView.RootContainer.Element = null;
            widgetDockingContainer1.Element = null;
            widgetDockingContainer2.Element = this._widgetToDoList;
            widgetDockingContainer3.Element = this._widgetCalendar;
            widgetDockingContainer1.Nodes.AddRange(new DevExpress.XtraBars.Docking2010.Views.Tabbed.DockingContainer[] {
            widgetDockingContainer2,
            widgetDockingContainer3});
            this._widgetView.RootContainer.Nodes.AddRange(new DevExpress.XtraBars.Docking2010.Views.Tabbed.DockingContainer[] {
            widgetDockingContainer1});
            this._widgetView.RootContainer.Orientation = System.Windows.Forms.Orientation.Vertical;
            // 
            // DesktopUc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "DesktopUc";
            this.Size = new System.Drawing.Size(776, 664);
            ((System.ComponentModel.ISupportInitialize)(this._widgetToDoList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._widgetCalendar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._documentManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._widgetView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Docking2010.DocumentManager _documentManager;
        private DevExpress.XtraBars.Docking2010.Views.Widget.WidgetView _widgetView;
        private DevExpress.XtraBars.Docking2010.Views.Widget.Document _widgetToDoList;
        private DevExpress.XtraBars.Docking2010.Views.Widget.Document _widgetCalendar;
    }
}