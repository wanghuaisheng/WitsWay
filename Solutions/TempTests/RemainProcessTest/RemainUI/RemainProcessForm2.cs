using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WitsWay.TempTests.RemainProcessTest.RemainUI
{
    public partial class RemainProcessForm2 : Form
    {
        public RemainProcessForm2()
        {
            InitializeComponent();
        }

        private void RemainProcessForm2_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.White);

            //设置画刷的前景色为黑色，背景色为白色  
            Color foreColor = Color.Black;
            Color backColor = Color.White;

            //定义填充区域矩形的宽度和高度  
            int WIDTH = 140;
            int HEIGHT = 40;

            //定义输出文本信息  
            SolidBrush redBrush = new SolidBrush(Color.Red);
            Font myfont = new Font("Arial", 10);

            //column_count 表明在每一行能够绘制矩形的个数  
            int column_count = this.Width/WIDTH;
            int rol = 0;
            int column = 0;

            //在当前窗口使用所有的影线画刷风格填充矩形  
            Pen p = new Pen(Color.Green, 1);
            foreach (HatchStyle style in Enum.GetValues(typeof (HatchStyle)))
            {
                //如果一行已经绘制完毕则换行  
                if (rol > column_count - 1)
                {
                    column += 2;
                    rol = 0;
                }

                //创建临时画刷  
                HatchBrush tempBrush = new HatchBrush(style, foreColor, backColor);

                //填充矩形：设置宽度为 WIDTH - 20 的目的为让矩形之间留出间隔  
                g.FillRectangle(tempBrush, rol*WIDTH, column*HEIGHT, WIDTH - 20, HEIGHT);
                //绘制矩形边框  
                g.DrawRectangle(p, rol*WIDTH, column*HEIGHT, WIDTH - 20, HEIGHT);

                //显示每种画刷的风格  
                //计算文本输出区域  
                Rectangle layoutRect = new Rectangle(rol*WIDTH, (column - 1)*HEIGHT, WIDTH, HEIGHT);
                StringFormat format = new StringFormat();
                //设置文本输出格式：水平、垂直居中  
                format.Alignment = StringAlignment.Near;
                format.LineAlignment = StringAlignment.Center;
                //在矩形区域输出枚举风格名称  
                g.DrawString(tempBrush.HatchStyle.ToString(), myfont, redBrush, layoutRect, format);

                rol += 1;
            }
        }
    }
}