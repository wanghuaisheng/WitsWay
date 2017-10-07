using System;
using System.Windows.Forms;

namespace WitsWay.TempTests.ControlsTest.Desktops.Widgets {
    public partial class Clock : UserControl {
        private readonly Timer _timer = new Timer();
        public Clock() {
            InitializeComponent();
            _timer.Interval = 1000;
            _timer.Tick += OnTick;
            _timer.Start();
            OnTick(null, null);
        }

        private void OnTick(object sender, EventArgs e) {
            var currentDate = DateTime.Now;
            labelControl1.Text = string.Format("<b>{0}</b><br><size=10>{1}", string.Format("{0:T}", currentDate), currentDate.ToString("D"));
        }
    }
}
