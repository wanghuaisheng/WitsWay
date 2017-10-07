using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Web;
using WitsWay.Utilities.Thread;
using WitsWay.Utilities.Web.Properties;

namespace WitsWay.Utilities.Web.Captcha
{

    /// <summary>
    /// 验证码图片
    /// </summary>
    [Serializable]
    public class CaptchaImage
    {
        #region [Fields]

        private Random random;

        private FontWarpFactor fontWarp;
        private BackgroundNoiseLevel backgroundNoise;
        private LineNoiseLevel lineNoise;
        private int width;
        private int height;

        private string fontWhitelist;
        private int randomTextLength;
        private string randomTextChars;
        private string fontFamilyName;
        private string randomText;

        private DateTime generatedAt;
        private string guid;

        #endregion

        #region [Class]

        /// <summary>
        /// 验证码图片
        /// </summary>
        private CaptchaImage()
        {
            random = new Random();

            FontWarp = FontWarpFactor.Low;
            BackgroundNoise = BackgroundNoiseLevel.Low;
            LineNoise = LineNoiseLevel.None;
            Width = 180;
            Height = 50;

            //// XP和2003中常见字体
            FontWhitelist = "arial;arial black;comic sans ms;courier new;estrangelo edessa;franklin gothic medium;" +
                "georgia;lucida console;lucida sans unicode;mangal;microsoft sans serif;palatino linotype;" +
                "sylfaen;tahoma;times new roman;trebuchet ms;verdana";
            randomTextLength = 5; //字符长度
            randomTextChars = "ACDEFGHJKLMNPQRTUVWXY34679"; // 排除了相似字符: 1 - l, B - 8, Z - 2, S - 5; 
            fontFamilyName = string.Empty;
            randomText = GenerateRandomText();

            generatedAt = DateTime.Now;
            guid = Guid.NewGuid().ToString();
        }

        #endregion

        #region [Properties]

        /// <summary>
        /// 验证码图片唯一标识
        /// </summary>
        public string UniqueId
        {
            get
            {
                return guid;
            }
        }

        /// <summary>
        /// 图片最后呈现时间
        /// </summary>
        public DateTime RenderedAt
        {
            get
            {
                return generatedAt;
            }
        }

        /// <summary>
        /// 用于绘制验证码的FontFamily，为空则从字体白名单中为每个字符随机取字体
        /// </summary>
        public string FontFamilyName
        {
            get
            {
                return fontFamilyName;
            }

            set
            {
                var font = new Font(value, 12); // 检查字体是否安装，如果未安装该类型字体，用Microsoft Sans Serif字体替换
                font.Dispose();

                if (font.Name == FontFamily.GenericSansSerif.Name)
                {
                    fontFamilyName = font.Name;
                }
                else
                {
                    fontFamilyName = value;
                }
            }
        }

        /// <summary>
        /// 验证码字体弯曲程度
        /// </summary>
        public FontWarpFactor FontWarp
        {
            get
            {
                return fontWarp;
            }

            set
            {
                fontWarp = value;
            }
        }

        /// <summary>
        /// 背景噪点程度
        /// </summary>
        public BackgroundNoiseLevel BackgroundNoise
        {
            get
            {
                return backgroundNoise;
            }

            set
            {
                backgroundNoise = value;
            }
        }

        /// <summary>
        /// 背景噪点线程度
        /// </summary>
        public LineNoiseLevel LineNoise
        {
            get
            {
                return lineNoise;
            }

            set
            {
                lineNoise = value;
            }
        }

        /// <summary>
        /// 验证码有效字符集
        /// </summary>
        public string TextChars
        {
            get
            {
                return randomTextChars;
            }

            set
            {
                randomTextChars = value;
                randomText = GenerateRandomText();
            }
        }

        /// <summary>
        /// 验证字符长度
        /// </summary>
        public int TextLength
        {
            get
            {
                return randomTextLength;
            }

            set
            {
                randomTextLength = value;
                randomText = GenerateRandomText();
            }
        }

        /// <summary>
        /// Get验证字符
        /// </summary>
        public string Text
        {
            get
            {
                return randomText;
            }
        }

        /// <summary>
        /// 验证码图片宽度
        /// </summary>
        public int Width
        {
            get
            {
                return width;
            }

            set
            {
                if (value <= 60)
                {
                    throw new ArgumentOutOfRangeException("宽度", value, "宽度需要大于60像素");
                }
                width = value;
            }
        }

        /// <summary>
        /// 验证码图片高度
        /// </summary>
        public int Height
        {
            get
            {
                return height;
            }

            set
            {
                if (value <= 30)
                {
                    throw new ArgumentOutOfRangeException("高度", value, "高度需要大于30像素");
                }
                height = value;
            }
        }

        /// <summary>
        /// 字体白名单
        /// </summary>
        public string FontWhitelist
        {
            get
            {
                return fontWhitelist;
            }

            set
            {
                fontWhitelist = value;
            }
        }

        /// <summary>
        /// 是否通过Session存储
        /// </summary>
        public bool UseSession
        {
            get;
            private set;
        }

        private LockObject _lock = new LockObject();
        private bool handlerCopyed;
        /// <summary>
        /// Handler名称
        /// </summary>
        public string HandlerName
        {
            get
            {
                if (!handlerCopyed)
                {
                    _lock.LockExecute(() =>
                    {
                        if (!handlerCopyed)
                        {
                            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CaptchaHandler.ashx");
                            if (!File.Exists(path))
                            {
                                using (var f = File.Create(path))
                                {
                                    var fileBytes = (byte[])Resources.ResourceManager.GetObject("CaptchaHandler");
                                    f.Write(fileBytes, 0, fileBytes.Length);
                                    f.Flush();
                                }
                            }
                            handlerCopyed = true;
                        }
                    });
                }
                return "CaptchaHandler.ashx";
            }
        }

        /// <summary>
        /// 获取验证码Img标签内容
        /// </summary>
        /// <returns>Img标签内容</returns>
        public string GetCaptchaImgTag()
        {
            if (UseSession)
            {
                HttpContext.Current.Session[guid] = this;
            }
            else
            {
                HttpRuntime.Cache.Insert(guid, this);
            }
            return string.Format("<img id='{1}' src='{0}?guid={1}{2}{3}' style='cursor:pointer;' onclick='this.setAttribute(\"src\", (this.getAttribute(\"src\")+\"1\"));' />", HandlerName, UniqueId, (UseSession ? "&useSession=1" : ""), "&rnd=1");
        }

        /// <summary>
        /// 获取验证图片
        /// </summary>
        /// <returns></returns>
        public static CaptchaImage GetCaptchaImage(bool useSession)
        {
            var captcha = new CaptchaImage
            {
                    BackgroundNoise = BackgroundNoiseLevel.Extreme,
                    LineNoise = LineNoiseLevel.Medium,
                    FontWarp = FontWarpFactor.High,
                    UseSession = true
                };
            return captcha;
        }

        /// <summary>
        /// 获取验证码
        /// </summary>
        public static string GetCaptchaCode(HttpContext context, string guid, bool useSession)
        {
            if (context == null || string.IsNullOrEmpty(guid)) { return string.Empty; }
            HttpApplication application = context.ApplicationInstance;
            var captchaImage = useSession ? (CaptchaImage)HttpContext.Current.Session[guid] : (CaptchaImage)HttpRuntime.Cache.Get(guid);
            return captchaImage == null ? string.Empty : captchaImage.Text;
        }

        #endregion



        /// <summary>
        /// 强制重新生成验证码图片
        /// </summary>
        /// <returns>验证码图片</returns>
        public Bitmap GenerateImage()
        {
            randomText = GenerateRandomText();
            Font font = null;
            Rectangle rectangle;
            Brush brush = null;

            Bitmap bitmap = null;
            Graphics graphics = null;

            GraphicsPath pathWithChar = null;
            StringFormat stringFormat = null;

            try
            {
                bitmap = new Bitmap(Width, Height, PixelFormat.Format32bppArgb);
                graphics = Graphics.FromImage(bitmap);
                graphics.SmoothingMode = SmoothingMode.AntiAlias;

                //// 填充白色空白矩形区域
                rectangle = new Rectangle(0, 0, Width, Height);
                brush = new SolidBrush(Color.White);
                graphics.FillRectangle(brush, rectangle);

                var charOffset = 0;
                double charWidth = Width / TextLength;
                Rectangle charRectangle;

                foreach (var c in Text.ToCharArray())
                {
                    //// 建立字体 & 绘制区域
                    font = GetFont();
                    charRectangle = new Rectangle((int)(charOffset * charWidth), 0, (int)charWidth, Height);

                    //// 扭曲字符
                    pathWithChar = new GraphicsPath();

                    stringFormat = new StringFormat();
                    stringFormat.Alignment = StringAlignment.Near;
                    stringFormat.LineAlignment = StringAlignment.Near;

                    pathWithChar.AddString(c.ToString(), font.FontFamily, (int)font.Style, font.Size, charRectangle, stringFormat);

                    WarpChar(pathWithChar, charRectangle);

                    //// 绘制字符
                    brush = new SolidBrush(Color.Black);
                    graphics.FillPath(brush, pathWithChar);

                    charOffset += 1;
                }

                AddNoise(graphics, rectangle);
                AddLines(graphics, rectangle);
            }
            finally
            {
                if (stringFormat != null)
                {
                    stringFormat.Dispose();
                }

                if (pathWithChar != null)
                {
                    pathWithChar.Dispose();
                }

                if (font != null)
                {
                    font.Dispose();
                }

                if (brush != null)
                {
                    brush.Dispose();
                }

                if (graphics != null)
                {
                    graphics.Dispose();
                }
            }

            return bitmap;
        }

        /// <summary>
        /// 生成随机验证码
        /// </summary>
        /// <returns>验证码</returns>
        private string GenerateRandomText()
        {
            var randomTextBuilder = new StringBuilder(TextLength);

            for (var i = 0; i < TextLength; i++)
            {
                randomTextBuilder.Append(TextChars.Substring(random.Next(TextChars.Length), 1));
            }

            return randomTextBuilder.ToString();
        }

        /// <summary>
        /// 生成x、y范围内的随机点
        /// </summary>
        private PointF GenerateRandomPoint(int xmin, int xmax, int ymin, int ymax)
        {
            return new PointF(random.Next(xmin, xmax), random.Next(ymin, ymax));
        }

        /// <summary>
        /// 取得合适尺寸的验证码字体 
        /// </summary>
        /// <returns>验证码字体</returns>
        private Font GetFont()
        {
            int fontSize;
            var fontName = FontFamilyName;

            if (string.IsNullOrEmpty(fontName))
            {
                var fontFamilies = FontWhitelist.Split(';');
                fontName = fontFamilies[random.Next(0, fontFamilies.Length)];
            }

            switch (FontWarp)
            {
                case FontWarpFactor.None:
                    fontSize = (int)(Height * 0.7);
                    break;
                case FontWarpFactor.Low:
                    fontSize = (int)(Height * 0.8);
                    break;
                case FontWarpFactor.Medium:
                    fontSize = (int)(Height * 0.85);
                    break;
                case FontWarpFactor.High:
                    fontSize = (int)(Height * 0.9);
                    break;
                case FontWarpFactor.Extreme:
                    fontSize = (int)(Height * 0.95);
                    break;
                default:
                    throw new ArgumentException("未知字体扭曲级别枚举", "字体扭曲");
            }

            return new Font(fontName, fontSize, FontStyle.Bold);
        }

        /// <summary>
        /// 扭曲字符
        /// </summary>
        /// <param name="pathWithText">包含文字的路径</param>
        /// <param name="textRectangle">文字区域</param>
        private void WarpChar(GraphicsPath pathWithText, Rectangle textRectangle)
        {
            float warpDivisor, rangeModifier;

            switch (FontWarp)
            {
                case FontWarpFactor.None:
                    return;
                case FontWarpFactor.Low:
                    warpDivisor = 6;
                    rangeModifier = 1;
                    break;
                case FontWarpFactor.Medium:
                    warpDivisor = 5;
                    rangeModifier = 1.3f;
                    break;
                case FontWarpFactor.High:
                    warpDivisor = 4.5f;
                    rangeModifier = 1.4f;
                    break;
                case FontWarpFactor.Extreme:
                    warpDivisor = 4;
                    rangeModifier = 1.5f;
                    break;
                default:
                    throw new ArgumentException("未知字体扭曲级别枚举", "字体扭曲");
            }

            var textRectangleFloat = new RectangleF(textRectangle.Left, textRectangle.Top, textRectangle.Width, textRectangle.Height);

            var heightRatio = Convert.ToInt32(textRectangle.Height / warpDivisor);
            var widthRatio = Convert.ToInt32(textRectangle.Width / warpDivisor);

            var leftTextRectangle = textRectangle.Left - (int)(widthRatio * rangeModifier);
            var topTextRectangle = textRectangle.Top - (int)(heightRatio * rangeModifier);
            var widthTextRectangle = textRectangle.Left + textRectangle.Width + (int)(widthRatio * rangeModifier);
            var heightTextRectangle = textRectangle.Top + textRectangle.Height + (int)(heightRatio * rangeModifier);

            if (leftTextRectangle < 0)
            {
                leftTextRectangle = 0;
            }

            if (topTextRectangle < 0)
            {
                topTextRectangle = 0;
            }

            if (widthTextRectangle > Width)
            {
                widthTextRectangle = Width;
            }

            if (heightTextRectangle > Height)
            {
                heightTextRectangle = Height;
            }

            var leftTop = GenerateRandomPoint(leftTextRectangle, leftTextRectangle + widthRatio, topTextRectangle, topTextRectangle + heightRatio);
            var rightTop = GenerateRandomPoint(widthTextRectangle - widthRatio, widthTextRectangle, topTextRectangle, topTextRectangle + heightRatio);
            var leftBottom = GenerateRandomPoint(leftTextRectangle, leftTextRectangle + widthRatio, heightTextRectangle - heightRatio, heightTextRectangle);
            var rightBottom = GenerateRandomPoint(widthTextRectangle - widthRatio, widthTextRectangle, heightTextRectangle - heightRatio, heightTextRectangle);
            var points = new[] { leftTop, rightTop, leftBottom, rightBottom };

            var matrix = new Matrix();
            matrix.Translate(0, 0);
            pathWithText.Warp(points, textRectangleFloat, matrix, WarpMode.Perspective, 0);
            matrix.Dispose();
        }

        /// <summary>
        /// 根据级别添加图片噪点
        /// </summary>
        /// <param name="graphics">绘制图片</param>
        /// <param name="rectangle">图片区域</param>
        private void AddNoise(Graphics graphics, Rectangle rectangle)
        {
            int density, size;

            switch (BackgroundNoise)
            {
                case BackgroundNoiseLevel.None:
                    return;
                case BackgroundNoiseLevel.Low:
                    density = 30;
                    size = 40;
                    break;
                case BackgroundNoiseLevel.Medium:
                    density = 18;
                    size = 40;
                    break;
                case BackgroundNoiseLevel.High:
                    density = 16;
                    size = 39;
                    break;
                case BackgroundNoiseLevel.Extreme:
                    density = 12;
                    size = 38;
                    break;
                default:
                    throw new ArgumentException("未知背景噪点级别枚举", "背景噪点");
            }

            var brush = new SolidBrush(Color.Black);
            var max = Math.Max(rectangle.Width, rectangle.Height) / size;

            for (var i = 0; i < (rectangle.Width * rectangle.Height) / density; i++)
            {
                graphics.FillEllipse(brush, random.Next(rectangle.Width), random.Next(rectangle.Height), random.Next(max), random.Next(max));
            }

            brush.Dispose();
        }

        /// <summary>
        /// 根据级别添加图片噪点线
        /// </summary>
        /// <param name="graphics">绘制图片</param>
        /// <param name="rectangle">绘制区域</param>
        private void AddLines(Graphics graphics, Rectangle rectangle)
        {
            int pointsCount, lineCount;
            float lineWidth;

            switch (LineNoise)
            {
                case LineNoiseLevel.None:
                    return;
                case LineNoiseLevel.Low:
                    pointsCount = 4;
                    lineWidth = (float)(Height / 31.25);
                    lineCount = 1;
                    break;
                case LineNoiseLevel.Medium:
                    pointsCount = 5;
                    lineWidth = (float)(Height / 27.7777);
                    lineCount = 1;
                    break;
                case LineNoiseLevel.High:
                    pointsCount = 3;
                    lineWidth = Height / 25;
                    lineCount = 2;
                    break;
                case LineNoiseLevel.Extreme:
                    pointsCount = 3;
                    lineWidth = (float)(Height / 22.7272);
                    lineCount = 3;
                    break;
                default:
                    throw new ArgumentException("未知背景噪点线级别枚举", "背景噪点线");
            }

            var points = new PointF[pointsCount];
            var pen = new Pen(Color.Black, lineWidth);

            for (var i = 1; i <= lineCount; i++)
            {
                for (var j = 0; j < pointsCount; j++)
                {
                    points[j] = GenerateRandomPoint(rectangle.Left, rectangle.Width, rectangle.Top, rectangle.Bottom);
                }

                graphics.DrawCurve(pen, points, 1.75f);
            }

            pen.Dispose();
        }

    }

    #region [Enums]

    /// <summary>
    /// 字体弯曲程度
    /// </summary>
    public enum FontWarpFactor
    {
        /// <summary>
        /// 无弯曲
        /// </summary>
        None,
        /// <summary>
        /// 低
        /// </summary>
        Low,
        /// <summary>
        /// 中
        /// </summary>
        Medium,
        /// <summary>
        /// 高
        /// </summary>
        High,
        /// <summary>
        /// 极度
        /// </summary>
        Extreme
    }

    /// <summary>
    /// 背景噪点程度
    /// </summary>
    public enum BackgroundNoiseLevel
    {
        /// <summary>
        /// 无
        /// </summary>
        None,
        /// <summary>
        /// 低
        /// </summary>
        Low,
        /// <summary>
        /// 中
        /// </summary>
        Medium,
        /// <summary>
        /// 高
        /// </summary>
        High,
        /// <summary>
        /// 极度
        /// </summary>
        Extreme
    }

    /// <summary>
    /// 背景噪线程度
    /// </summary>
    public enum LineNoiseLevel
    {
        /// <summary>
        /// 无
        /// </summary>
        None,
        /// <summary>
        /// 低
        /// </summary>
        Low,
        /// <summary>
        /// 中
        /// </summary>
        Medium,
        /// <summary>
        /// 高
        /// </summary>
        High,
        /// <summary>
        /// 极度
        /// </summary>
        Extreme
    }

    #endregion

}
