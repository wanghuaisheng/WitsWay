////#region License(Apache Version 2.0)
/////******************************************
//// * Copyright ®2017-Now WangHuaiSheng.
//// * Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file
//// * except in compliance with the License. You may obtain a copy of the License at
//// * http://www.apache.org/licenses/LICENSE-2.0
//// * Unless required by applicable law or agreed to in writing, software distributed under the
//// * License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
//// * either express or implied. See the License for the specific language governing permissions
//// * and limitations under the License.
//// * Detail: https://github.com/WangHuaiSheng/WitsWay/LICENSE
//// * ***************************************/
////#endregion 
////#region ChangeLog
/////******************************************
//// * 2017-10-7 OutMan Create
//// * 
//// * ***************************************/
////#endregion
////using System;
////using System.ComponentModel;
////using System.Drawing;
////using System.Threading;
////using System.Windows.Forms;
////using Timer = System.Windows.Forms.Timer;

////namespace WitsWay.Utilities.Win.Controls
////{
////    /// <summary>
////    /// 浮动消息层
////    /// </summary>
////    public class FlyingForm : Form
////    {
////        /// <summary>
////        /// 图标和文本之间的间距（像素）
////        /// </summary>
////        private const int IconTextSpacing = 3;

////        /// <summary>
////        /// 基准点。用于指导本窗体显示位置
////        /// </summary>
////        public Point BasePoint { get; set; }

////        private string _tipText;
////        /// <summary>
////        /// 提示图标
////        /// </summary>
////        public Image TipIcon { get; set; }

////        /// <summary>
////        /// 提示文本
////        /// </summary>
////        public string TipText
////        {
////            get { return _tipText ?? string.Empty; }
////            set { _tipText = value; }
////        }

////        /// <summary>
////        /// 停留时长（毫秒）
////        /// </summary>
////        [DefaultValue(500)]
////        public int Delay { get; set; }

////        /// <summary>
////        /// 是否允许浮动
////        /// </summary>
////        [DefaultValue(true)]
////        public bool Floating { get; set; }

////        public Point SourcePoint { get; set; }

////        public Point TargetPoint { get; set; }

////        public Size SourceSize { get; set; }

////        public Size TargetSize { get; set; }

////        public Image Image { get; set; }

////        [DefaultValue(200)]
////        public int Speed { get; set; }

////        //显示后不激活，即不抢焦点
////        protected override bool ShowWithoutActivation
////        {
////            get { return true; }
////        }

////        public FlyingForm()
////        {
////            //双缓冲。有必要
////            SetStyle(ControlStyles.UserPaint, true);
////            DoubleBuffered = true;

////            InitializeComponent();
////            Delay = 500;
////            Floating = true;
////            TopMost = true;

////            _timer.Tick += timer_Tick;
////            Load += FlyingForm_Load;
////            Shown += FlyingForm_Shown;
////            FormClosing += FlyingForm_FormClosing;
////        }

////        private void FlyingForm_Load(object sender, EventArgs e)
////        {
////            Size = SourceSize;
////            Location = SourcePoint;

////            var deltaX = SourcePoint.X - TargetPoint.X;
////            var deltaY = SourcePoint.Y - TargetPoint.Y;

////            var totalDistence = Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
////            Delay = (int)(totalDistence * 1000 / Speed);

////            //上浮窗体动画。采用异步，以不阻塞透明渐变动画的进行
////            ThreadPool.QueueUserWorkItem(obj =>
////            {
////                var startTime = DateTime.Now;
////                var percentageFinished = 0d;

////                while (this.IsHandleCreated && percentageFinished < 1)
////                {
////                    this.BeginInvoke(new Action<object>(arg =>
////                    {
////                        percentageFinished = Speed * (DateTime.Now - startTime).TotalMilliseconds / 1000 / totalDistence;

////                        Size = SourceSize + ScaleSize(TargetSize - SourceSize, percentageFinished);

////                        Location = new Point(SourcePoint.X + (int)(percentageFinished * (TargetPoint.X - SourcePoint.X)), (int)(SourcePoint.Y + percentageFinished * (TargetPoint.Y - SourcePoint.Y)));
////                        Opacity = 1 - percentageFinished;
////                    }), (object)null);


////                    System.Threading.Thread.Sleep(30);
////                }
////            });
////        }

////        private Size ScaleSize(Size size, double ratio)
////        {
////            return new Size((int)(size.Width * ratio), (int)(size.Height * ratio));
////        }

////        private void FlyingForm_Shown(object sender, EventArgs e)
////        {
////            _timer.Interval = 100;
////            //因为timer.Interval不能为0
////            if (Delay > 0)
////            {
////                _timer.Interval = Delay;
////                _timer.Start();
////            }
////            else
////            {
////                Close();
////            }
////        }

////        private void timer_Tick(object sender, EventArgs e)
////        {
////            _timer.Stop();
////            Close();
////        }

////        private void FlyingForm_FormClosing(object sender, FormClosingEventArgs e)
////        {
////            //透明渐隐动画
////            while (Opacity > 0)
////            {
////                Opacity -= 0.1;
////                Application.DoEvents();
////                System.Threading.Thread.Sleep(20);
////            }
////        }

////        protected override void OnPaint(PaintEventArgs e)
////        {
////            base.OnPaint(e);

////            var clip = GetPaddedRectangle();//得到作图区域
////            var g = e.Graphics;
////            //g.DrawRectangle(Pens.Red, clip);//debug

////            //画图标
////            if (TipIcon != null)
////            {
////                g.DrawImageUnscaled(TipIcon, clip.Location);
////            }
////            //画文本
////            if (TipText.Length != 0)
////            {
////                if (TipIcon != null)
////                {
////                    clip.X += TipIcon.Width + IconTextSpacing;
////                }
////                TextRenderer.DrawText(g, TipText, this.Font, clip, this.ForeColor, TextFormatFlags.VerticalCenter);
////            }
////        }

////        protected override void OnPaintBackground(PaintEventArgs e)
////        {
////            base.OnPaintBackground(e);
////            if (Image != null)
////                e.Graphics.DrawImage(Image, ClientRectangle);
////            //画边框
////            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, SystemColors.ControlDark, ButtonBorderStyle.Solid);
////        }

////        /// <summary>
////        /// 获取刨去Padding的内容区
////        /// </summary>
////        private Rectangle GetPaddedRectangle()
////        {
////            var r = this.ClientRectangle;
////            r.X += this.Padding.Left;
////            r.Y += this.Padding.Top;
////            r.Width -= this.Padding.Horizontal;
////            r.Height -= this.Padding.Vertical;
////            return r;
////        }

////        #region 设计器内容

////        protected override void Dispose(bool disposing)
////        {
////            if (disposing)
////            {
////                _timer.Dispose();//这货必须显示释放
////            }
////            base.Dispose(disposing);
////        }

////        private void InitializeComponent()
////        {
////            _timer = new Timer();
////            this.SuspendLayout();

////            this.AutoScaleMode = AutoScaleMode.None;
////            //this.ClientSize = new System.Drawing.Size(100, 100);
////            BackColor = Color.White;
////            this.Font = new Font(SystemFonts.MessageBoxFont.FontFamily, 12);
////            FormBorderStyle = FormBorderStyle.None;
////            this.Padding = new Padding(20, 10, 20, 10);
////            this.Name = "FlyingForm";
////            ShowInTaskbar = false;

////            this.ResumeLayout(false);
////        }

////        private Timer _timer;

////        #endregion

////        /// <summary>
////        /// 
////        /// </summary>
////        /// <param name="sourcePoint"></param>
////        /// <param name="targetPoint"></param>
////        /// <param name="sourceSize"></param>
////        /// <param name="targetSize"></param>
////        /// <param name="image"></param>
////        /// <param name="speed"></param>
////        public static void Fly(Point sourcePoint, Point targetPoint, Size sourceSize, Size targetSize, Image image, int speed = 200)
////        {
////            new FlyingForm
////            {
////                SourcePoint = sourcePoint,
////                TargetPoint = targetPoint,
////                SourceSize = sourceSize,
////                TargetSize = targetSize,
////                Image = image,
////                Speed = 1000
////            }.Show();
////        }

////    }
////}