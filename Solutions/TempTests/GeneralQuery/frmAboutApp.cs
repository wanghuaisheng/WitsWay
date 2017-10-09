using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.Utils.Drawing;
using DevExpress.Utils.Frames;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Localization;
using WitsWay.TempTests.GeneralQuery.Properties;

namespace WitsWay.TempTests.GeneralQuery
{
    public partial class FrmAboutApp : XtraForm
    {
        private bool _blnMoving;
        private int _mouseDownX;
        private int _mouseDownY;
        private static readonly string FontName = "微软雅黑";
        private readonly LabelInfo _labelInfo = new LabelInfo();

        private static readonly Color Color1 = Color.FromArgb(210, 196, 196);

        private static readonly Color Color2 = Color.FromArgb(143, 133, 127);

        private static readonly AppearanceDefault VersionAppearance = new AppearanceDefault(Color1, Color.Empty, HorzAlignment.Near, VertAlignment.Top, new Font(FontName, 9.25f));

        private static readonly AppearanceDefault DescriptionAppearance = new AppearanceDefault(Color1, Color.Empty, HorzAlignment.Near, VertAlignment.Top, new Font(FontName, 7.75f));

        private static readonly AppearanceDefault CopyrightAppearance = new AppearanceDefault(Color2, Color.Empty, HorzAlignment.Center, VertAlignment.Top, new Font(FontName, 7.75f));

        private static readonly Rectangle VersionBounds = new Rectangle(210, 94, 260, 20);

        private static readonly Rectangle DescriptionBounds = new Rectangle(210, 124, 270, 100);

        private static readonly Rectangle CopyrightBounds = new Rectangle(20, 280, 485, 20);

        public FrmAboutApp()
        {
            InitializeComponent();
            Image bgImage = Resources.About;
            BackgroundImage = bgImage;
            Size = bgImage.Size;
            CreateLinks();
        }

        public sealed override Image BackgroundImage
        {
            get { return base.BackgroundImage; }
            set { base.BackgroundImage = value; }
        }

        private void CreateLinks()
        {
            _labelInfo.Font = new Font(FontName, 8.75f);
            _labelInfo.BackColor = Color.Transparent;
            _labelInfo.Bounds = LocalizationHelper.IsJapanese ? new Rectangle(155, 260, 430, 20) : new Rectangle(55, 260, 430, 20);
            _labelInfo.Parent = this;
            _labelInfo.ItemClick += OnLabelClick;
            _labelInfo.Texts.Add("官网", Color1, true);
            if (!LocalizationHelper.IsJapanese)
            {
                _labelInfo.Texts.Add(@"◈", Color2);
                _labelInfo.Texts.Add("关于", Color1, true);
            }
            _labelInfo.Texts.Add(@"◈", Color2);
            _labelInfo.Texts.Add("帮助", Color1, true);
        }

        private void OnLabelClick(object sender, LabelInfoItemClickEventArgs e)
        {
            var name = GetProcessName(e);
            if (name != null)
                ObjectHelper.ShowWebSite(name);
        }
        private string GetProcessName(LabelInfoItemClickEventArgs e)
        {
            if (e.InfoText.Text.Equals("官网")) return "yitusoft.com";
            if (e.InfoText.Text.Equals("关于")) return "about.yitusoft.com";
            if (e.InfoText.Text.Equals("帮助")) return "help.yitusoft.com";
            return null;
        }
        public static void ShowAbout(Form parent)
        {
            var about = new FrmAboutApp { Opacity = 0 };
            var tmr = new Timer
            {
                Tag = about,
                Interval = 20
            };
            tmr.Tick += tmr_Tick;
            tmr.Start();
            about.ShowDialog(parent);
            about.Dispose();
        }

        private static void tmr_Tick(object sender, EventArgs e)
        {
            var tmr = sender as Timer;
            var frm = tmr.Tag as Form;
            if (frm == null)
            {
                tmr.Stop();
                return;
            }
            try
            {
                frm.Opacity += 0.07;
                if (frm.Opacity >= 0.99) tmr.Tag = null;
            }
            catch (Exception)
            {
                // ignored
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                e.Handled = true;
                Close();
            }
            base.OnKeyDown(e);
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Y < 250)
                Close();
            else
            {
                if (e.Button == MouseButtons.Left)
                {
                    _blnMoving = true;
                    _mouseDownX = e.X;
                    _mouseDownY = e.Y;
                }
            }
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (_blnMoving)
                Location = new Point(
                    Location.X + (e.X - _mouseDownX),
                    Location.Y + (e.Y - _mouseDownY));
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (e.Button == MouseButtons.Left)
                _blnMoving = false;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            using (var cache = new GraphicsCache(e))
            {
                cache.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                DrawVersion(cache);
                DrawDescription(cache);
                DrawCopyright(cache);
            }
        }

        private void DrawVersion(GraphicsCache cache)
        {
            var app = new AppearanceObject(VersionAppearance);
            app.DrawString(cache, string.Format("AboutFormVersion" + AssemblyInfo.MarketingVersion), VersionBounds);
        }

        private void DrawDescription(GraphicsCache cache)
        {
            var app = new AppearanceObject(DescriptionAppearance);
            app.TextOptions.WordWrap = WordWrap.Wrap;
            app.DrawString(cache, "关于描述", DescriptionBounds);
        }

        private void DrawCopyright(GraphicsCache cache)
        {
            var app = new AppearanceObject(CopyrightAppearance);
            app.DrawString(cache, string.Format(@"©" + DateTime.Now.Year), CopyrightBounds);
        }
    }


    public class ObjectHelper
    {
        public static void ShowWebSite(string url)
        {
            if (url == null) return;
            var processName = url.Replace(" ", string.Empty);
            if (processName.Length == 0) return;
            const string protocol = "http://";
            const string protocol2 = "https://";
            if (processName.IndexOf(protocol, StringComparison.Ordinal) != 0
                && processName.IndexOf(protocol2, StringComparison.Ordinal) != 0)
                processName = protocol + processName;
            StartProcess(processName);
        }
        public static void StartProcess(string processName)
        {
            try
            {
                Process.Start(processName);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void SetFormContainerSize(Form form, Control control)
        {
            form.StartPosition = FormStartPosition.Manual;
            form.Size = control.Size;
            form.Location = control.FindForm().PointToScreen(control.Location);
        }
        public static void ShowFormDialog(Form form, Form parent)
        {
            try
            {
                parent.Enabled = false;
                form.ShowDialog(parent);
            }
            finally
            {
                parent.Enabled = true;
            }
        }
        public static string GetPossibleFileName(string name) { return name.Replace("/", ""); }
        public static string GetFileName(string extension, string filter) { return GetFileName(extension, filter, string.Empty); }
        public static string GetFileName(string extension, string filter, string fileName)
        {
            using (var dialog = new SaveFileDialog())
            {
                dialog.Filter = filter;
                dialog.FileName = fileName;
                dialog.DefaultExt = extension;
                if (dialog.ShowDialog() == DialogResult.OK)
                    return dialog.FileName;
            }
            return string.Empty;
        }
        public static void RemoveCustomizationItemsFromColumnMenu(DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Column)
                for (var i = e.Menu.Items.Count - 1; i >= 0; i--)
                    if (GridStringId.MenuColumnColumnCustomization.Equals(e.Menu.Items[i].Tag) ||
                        GridStringId.MenuColumnRemoveColumn.Equals(e.Menu.Items[i].Tag))
                        e.Menu.Items.RemoveAt(i);
        }

        internal static string GetArticleByWord(string word)
        {
            if (string.IsNullOrEmpty(word)) return string.Empty;
            var firstLetter = word.Substring(0, 1).ToLower();
            return firstLetter == "a" ? "an" : "a";
        }
    }

}
