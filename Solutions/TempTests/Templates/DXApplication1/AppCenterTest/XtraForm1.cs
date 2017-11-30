using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraMap;

namespace AppCenterTest
{
    public partial class XtraForm1 : DevExpress.XtraEditors.XtraForm
    {
        public XtraForm1()
        {
            InitializeComponent();
        }

        private void XtraForm1_Load(object sender, EventArgs e)
        {

            SetFormPosition();

            //Uri baseUri = new Uri(System.Reflection.Assembly.GetExecutingAssembly().Location);
            mapControl1.Layers.Add(new VectorItemsLayer
            {
                Data = new SvgFileDataAdapter
                {
                    FileUri = new Uri(@"C:\Users\Public\Documents\DevExpress Demos 17.1\Components\WinForms\CS\MapMainDemo\中国地图.svg"),//new Uri(@"C:\Users\Public\Documents\DevExpress Demos 17.1\Components\Data\Countries.svg")
                },
                Colorizer = CreateColorizer()

            });

        }

        private MapColorizer CreateColorizer()
        {
            // Create a graph colorizer. 
            GraphColorizer colorizer = new GraphColorizer();

            // Specify colors for the colorizer. 
            colorizer.ColorItems.AddRange(new List<ColorizerColorItem> {
                new ColorizerColorItem(Color.FromArgb(0xF1, 0xC1, 0x49)),
                new ColorizerColorItem(Color.FromArgb(0xE5, 0xA8, 0x4D)),
                new ColorizerColorItem(Color.FromArgb(0xC5, 0x64, 0x50)),
                new ColorizerColorItem(Color.FromArgb(0xD6, 0x86, 0x4E)),
                new ColorizerColorItem(Color.FromArgb(0x79, 0x96, 0x89)),
                new ColorizerColorItem(Color.FromArgb(0xA2, 0xA8, 0x75))
            });
            return colorizer;
        }

        private void mapControl1_MapItemDoubleClick(object sender, MapItemClickEventArgs e)
        {
            var attrs = e.Item.Attributes.GetEnumerator();
            while (attrs.MoveNext())
            {
                MessageBox.Show($"{attrs.Current.Name}:{attrs.Current.Value}");
            }
        }

        private void XtraForm1_MouseCaptureChanged(object sender, EventArgs e)
        {

        }

        private void XtraForm1_Activated(object sender, EventArgs e)
        {

        }

        private void XtraForm1_Deactivate(object sender, EventArgs e)
        {
            this.Top = -this.Height*2;
            //this.WindowState = FormWindowState.Minimized;
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Normal;

            //SetFormPosition();

            //this.Activate();
        }

        private void SetFormPosition2()
        {
            Top = Screen.PrimaryScreen.WorkingArea.Bottom - Height;
            if (Top < 0)
            {
                Height = Screen.PrimaryScreen.WorkingArea.Bottom;
                Top = 0;
            }
            //Left = (Screen.PrimaryScreen.WorkingArea.Width - MousePosition.X < Width)
            //    ? Screen.PrimaryScreen.WorkingArea.Width - Width
            //    : MousePosition.X;

            Left = Screen.PrimaryScreen.WorkingArea.Width - Width;
        }
        private void SetFormPosition()
        {
            //Screen screen = Screen.FromControl(this);
            //Screen screen = Screen.FromPoint(new Point(Cursor.Position.X/2, Cursor.Position.Y/2));
            Screen screen=Screen.PrimaryScreen;
            Top = screen.WorkingArea.Bottom - Height;
            if (Top < 0)
            {
                Height = screen.WorkingArea.Bottom;
                Top = 0;
            }
            //Left = (Screen.PrimaryScreen.WorkingArea.Width - MousePosition.X < Width)
            //    ? Screen.PrimaryScreen.WorkingArea.Width - Width
            //    : MousePosition.X;

            Left = screen.WorkingArea.Width - Width;
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            //this.WindowState = FormWindowState.Normal;

            SetFormPosition();
            this.Activate();
        }
    }
}