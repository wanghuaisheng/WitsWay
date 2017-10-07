////using System;
////using System.Drawing;
////using System.Web;

////namespace DotNetSoft.Utilities.Web.Handlers
////{
////    /// <summary>
////    /// 验证码处理程序
////    /// </summary>
////    public class VerificationCodeHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
////    {
////        private string charSet = "2,3,4,5,6,8,9,A,B,C,D,E,F,G,H,J,K,M,N,P,R,S,U,W,X,Y";
////        /// <summary>
////        /// 处理请求
////        /// </summary>
////        /// <param name="context">Http请求上下文</param>
////        public void ProcessRequest(HttpContext context)
////        {
////            string validateCode = CreateRandomCode(5);
////            context.Session["ValidateCode"] = validateCode;
////            CreateImage2(validateCode, context);
////        }
////        /// <summary>
////        /// 是否可重用
////        /// </summary>
////        public bool IsReusable
////        {
////            get
////            {
////                return false;
////            }
////        }

////        /// <summary>
////        /// 生成验证码
////        /// </summary>
////        /// <param name="n">位数</param>
////        /// <returns>验证码字符串</returns>
////        private string CreateRandomCode(int n)
////        {
////            string[] CharArray = charSet.Split(',');
////            string randomCode = "";
////            int temp = -1;
////            Random rand = new Random();
////            for (int i = 0; i < n; i++)
////            {
////                if (temp != -1)
////                {
////                    rand = new Random(i * temp * ((int)DateTime.Now.Ticks));
////                }
////                int t = rand.Next(CharArray.Length - 1);
////                if (temp == t)
////                {
////                    return CreateRandomCode(n);
////                }
////                temp = t;
////                randomCode += CharArray[t];
////            }
////            return randomCode;
////        }

////        private void CreateImage(string checkCode, HttpContext context)
////        {
////            int iwidth = (int)(checkCode.Length * 13);
////            System.Drawing.Bitmap image = new System.Drawing.Bitmap(iwidth, 23);
////            Graphics g = Graphics.FromImage(image);

////            Font f = new System.Drawing.Font("Arial", 12, (System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Bold));        // 前景色       
////            Brush b = new System.Drawing.SolidBrush(Color.Black);        // 背景色      
////            g.Clear(Color.White);        // 填充文字       

////            g.DrawString(checkCode, f, b, 0, 1);        // 随机线条

////            Pen linePen = new Pen(Color.Gray, 0);
////            Random rand = new Random();
////            for (int i = 0; i < 5; i++)
////            {
////                int x1 = rand.Next(image.Width);
////                int y1 = rand.Next(image.Height);
////                int x2 = rand.Next(image.Width);
////                int y2 = rand.Next(image.Height);
////                g.DrawLine(linePen, x1, y1, x2, y2);
////            }
////            // 随机点       
////            for (int i = 0; i < 30; i++)
////            {
////                int x = rand.Next(image.Width);
////                int y = rand.Next(image.Height);
////                image.SetPixel(x, y, Color.Gray);
////            }
////            // 边框      
////            g.DrawRectangle(new Pen(Color.Gray), 0, 0, image.Width - 1, image.Height - 1);        // 输出图片 
////            System.IO.MemoryStream ms = new System.IO.MemoryStream();
////            image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
////            context.Response.ClearContent();
////            context.Response.ContentType = "image/Jpeg";
////            context.Response.BinaryWrite(ms.ToArray());
////            g.Dispose();
////            image.Dispose();
////        }

////        private void CreateImage2(string chkCode, HttpContext context)
////        {

////            //颜色列表，用于验证码、噪线、噪点
////            Color[] color = { Color.Black, Color.Red, Color.Blue, Color.Green, Color.Orange, Color.Brown, Color.Brown, Color.DarkBlue };

////            //字体列表，用于验证码
////            string[] font = { "Times New Roman", "MS Mincho", "Book Antiqua", "Gungsuh", "PMingLiU", "Impact" };

////            //验证码的字符集，去掉了一些容易混淆的字符
////            char[] character = { '2', '3', '4', '5', '6', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'J', 'K', 'L', 'M', 'N', 'P', 'R', 'S', 'T', 'W', 'X', 'Y' };


////            Bitmap bmp = new Bitmap(100, 40);
////            Graphics g = Graphics.FromImage(bmp);
////            g.Clear(Color.White);

////            Random rnd = new Random();
////            //画噪线
////            for (int i = 0; i < 10; i++)
////            {
////                int x1 = rnd.Next(100);
////                int y1 = rnd.Next(40);
////                int x2 = rnd.Next(100);
////                int y2 = rnd.Next(40);
////                Color clr = color[rnd.Next(color.Length)];
////                g.DrawLine(new Pen(clr), x1, y1, x2, y2);
////            }

////            //画验证码字符串
////            for (int i = 0; i < chkCode.Length; i++)
////            {
////                string fnt = font[rnd.Next(font.Length)];
////                Font ft = new Font(fnt, 18);
////                Color clr = color[rnd.Next(color.Length)];
////                g.DrawString(chkCode[i].ToString(), ft, new SolidBrush(clr), (float)i * 20 + 8, (float)8);
////            }

////            //画噪点
////            for (int i = 0; i < 100; i++)
////            {
////                int x = rnd.Next(bmp.Width);
////                int y = rnd.Next(bmp.Height);
////                Color clr = color[rnd.Next(color.Length)];
////                bmp.SetPixel(x, y, clr);
////            }

////            //清除该页输出缓存，设置该页无缓存
////            //context.Response.Buffer = true;
////            //context.Response.ExpiresAbsolute = System.DateTime.Now.AddMilliseconds(0);
////            //context.Response.Expires = 0;
////            //context.Response.CacheControl = "no-cache";
////            //context.Response.AppendHeader("Pragma", "No-Cache");
////            //context.Response.ClearContent();

////            context.Response.ContentType = "image/Png";
////            //Response.BinaryWrite(ms.ToArray());   

////            //将验证码图片写入内存流，并将其以 "image/Png" 格式输出
////            //MemoryStream ms = new MemoryStream();
////            try
////            {
////                bmp.Save(context.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Png);
////                //bmp.Save(context.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
////            }
////            finally
////            {
////                //显式释放资源
////                bmp.Dispose();
////                g.Dispose();
////            }
////        }

////        private void CreateImage3(string chkCode, HttpContext context)
////        {
////            //创建一图像对象
////            Bitmap bmp = new Bitmap(60, 25);
////            //创建画笔
////            Graphics g = Graphics.FromImage(bmp);
////            SolidBrush brush = new SolidBrush(Color.Black);
////            //清空画布
////            g.Clear(Color.White);
////            Random r = new Random();
////            Font f = new Font("黑体", 20);
////            g.DrawString(chkCode, f, brush, 0, 0);

////            Pen p = new Pen(brush, 3);

////            for (int i = 0; i < 100; i++)
////            {
////                int x = r.Next(150);
////                int y = r.Next(50);
////                int offset = r.Next(-3, 3);
////                int off2 = r.Next(-3, 3);
////                g.DrawLine(p, x, y, x + offset, y + off2);
////            }
////            //bmp.Save("a.jpg");

////            //设置输出流的Http MIME类型
////            context.Response.ContentType = "image/jpeg";
////            bmp.Save(context.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);

////            //context.Response.ContentType = "text/plain";
////            //context.Response.Write("Hello World");
////        }

////    }
////}



//////using System;
//////using System.Drawing;
//////using System.Drawing.Imaging;
//////using System.Web.UI;
//////using System.Drawing.Drawing2D;
//////using System.IO;

//////public class ValidateNumber
//////{
//////    public ValidateNumber()
//////    {
//////    }
//////    /// <summary>
//////    /// 验证码的最大长度
//////    /// </summary>
//////    public int MaxLength
//////    {
//////        get { return 10; }
//////    }
//////    /// <summary>
//////    /// 验证码的最小长度
//////    /// </summary>
//////    public int MinLength
//////    {
//////        get { return 1; }
//////    }
//////    /// <summary>
//////    /// 生成验证码
//////    /// </summary>
//////    /// <param name="length">指定验证码的长度</param>
//////    /// <returns></returns>
//////    public string CreateValidateNumber(int length)
//////    {
//////        int[] randMembers = new int[length];
//////        int[] validateNums = new int[length];
//////        string validateNumberStr = "";
//////        //生成起始序列值
//////        int seekSeek = unchecked((int)DateTime.Now.Ticks);
//////        Random seekRand = new Random(seekSeek);
//////        int beginSeek = (int)seekRand.Next(0, Int32.MaxValue - length * 10000);
//////        int[] seeks = new int[length];
//////        for (int i = 0; i < length; i++)
//////        {
//////            beginSeek += 10000;
//////            seeks[i] = beginSeek;
//////        }
//////        //生成随机数字
//////        for (int i = 0; i < length; i++)
//////        {
//////            Random rand = new Random(seeks[i]);
//////            int pownum = 1 * (int)Math.Pow(10, length);
//////            randMembers[i] = rand.Next(pownum, Int32.MaxValue);
//////        }
//////        //抽取随机数字
//////        for (int i = 0; i < length; i++)
//////        {
//////            string numStr = randMembers[i].ToString();
//////            int numLength = numStr.Length;
//////            Random rand = new Random();
//////            int numPosition = rand.Next(0, numLength - 1);
//////            validateNums[i] = Int32.Parse(numStr.Substring(numPosition, 1));
//////        }
//////        //生成验证码
//////        for (int i = 0; i < length; i++)
//////        {
//////            validateNumberStr += validateNums[i].ToString();
//////        }
//////        return validateNumberStr;
//////    }
//////    /// <summary>
//////    /// 创建验证码的图片
//////    /// </summary>
//////    /// <param name="containsPage">要输出到的page对象</param>
//////    /// <param name="validateNum">验证码</param>
//////    public void CreateValidateGraphic(Page containsPage, string validateNum)
//////    {
//////        Bitmap image = new Bitmap((int)Math.Ceiling(validateNum.Length * 12.5), 22);
//////        Graphics g = Graphics.FromImage(image);
//////        try
//////        {
//////            //生成随机生成器
//////            Random random = new Random();
//////            //清空图片背景色
//////            g.Clear(Color.White);
//////            //画图片的干扰线
//////            for (int i = 0; i < 25; i++)
//////            {
//////                int x1 = random.Next(image.Width);
//////                int x2 = random.Next(image.Width);
//////                int y1 = random.Next(image.Height);
//////                int y2 = random.Next(image.Height);
//////                g.DrawLine(new Pen(Color.White), x1, y1, x2, y2);
//////            }
//////            Font font = new Font("Blue", 12, (FontStyle.Bold | FontStyle.Italic));
//////            LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height),
//////             Color.Green, Color.MediumBlue, 1.2f, true);
//////            g.DrawString(validateNum, font, brush, 3, 2);
//////            //画图片的前景干扰点
//////            for (int i = 0; i < 100; i++)
//////            {
//////                int x = random.Next(image.Width);
//////                int y = random.Next(image.Height);
//////                image.SetPixel(x, y, Color.FromArgb(random.Next()));
//////            }
//////            //画图片的边框线
//////            g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);
//////            //保存图片数据
//////            MemoryStream stream = new MemoryStream();
//////            image.Save(stream, ImageFormat.Jpeg);
//////            //输出图片
//////            containsPage.Response.Clear();
//////            containsPage.Response.ContentType = "image/jpeg";
//////            containsPage.Response.BinaryWrite(stream.ToArray());
//////        }
//////        finally
//////        {
//////            g.Dispose();
//////            image.Dispose();
//////        }
//////    }
//////    /// <summary>
//////    /// 得到验证码图片的长度
//////    /// </summary>
//////    /// <param name="validateNumLength">验证码的长度</param>
//////    /// <returns></returns>
//////    public static int GetImageWidth(int validateNumLength)
//////    {
//////        return (int)(validateNumLength * 12.5);
//////    }
//////    /// <summary>
//////    /// 得到验证码的高度
//////    /// </summary>
//////    /// <returns></returns>
//////    public static double GetImageHeight()
//////    {
//////        return 22.5;
//////    }
//////}



////using System;
////using System.Collections.Specialized;
////using System.ComponentModel;
////using System.Drawing;
////using System.Globalization;
////using System.Text;
////using System.Web;
////using System.Web.Caching;
////using System.Web.UI;
////using System.Web.UI.WebControls;
////using DotNetSoft.Utilities.Properties;

////namespace DotNetSoft.Utilities.Web.Captcha
////{

////    /// <summary>
////    /// 验证码控件
////    /// </summary>
////    [ToolboxData("<{0}:CaptchaControl runat=\"server\" />")]
////    public class CaptchaControl : CompositeControl, INamingContainer, IPostBackDataHandler, IValidator
////    {
////        //// INamingContainer - any control that implements this interface creates a new namespace in which all child control ID attributes are guaranteed to be unique within an entire application (marker interface only).

////        #region Fields

////        private readonly string captchaInputID;

////        private string errorMessage;
////        private bool userValidated;
////        private string optionalUICulture;
////        private Layout layoutStyle;
////        private CacheType cacheStrategy;
////        private int timeoutSecondsMin;
////        private int timeoutSecondsMax;
////        private string font;

////        private CaptchaImage captcha;
////        private string previousGuid;

////        #endregion

////        /// <summary>
////        /// 验证码控件
////        /// </summary>
////        public CaptchaControl()
////        {
////            this.errorMessage = string.Empty;
////            this.userValidated = true;
////            this.optionalUICulture = string.Empty;
////            Resources.Culture = null;

////            this.layoutStyle = Layout.Horizontal;
////            this.cacheStrategy = CacheType.HttpRuntime;

////            this.timeoutSecondsMin = 3;
////            this.timeoutSecondsMax = 90;
////            this.font = string.Empty;

////            this.captchaInputID = "CaptchaInput";

////            this.captcha = new CaptchaImage();
////        }

////        #region Enums

////        /// <summary>
////        /// Defines orientation of image and text input.
////        /// </summary>
////        public enum Layout
////        {
////            /// <summary>
////            /// Image and text input on single line.
////            /// </summary>
////            Horizontal,

////            /// <summary>
////            /// Image above, text input below.
////            /// </summary>
////            Vertical
////        }

////        /// <summary>
////        /// Defines type of cache.
////        /// </summary>
////        public enum CacheType
////        {
////            /// <summary>
////            /// Use HttpRuntime.Cache.
////            /// </summary>
////            HttpRuntime,

////            /// <summary>
////            /// Use HttpContext.Session (session state must be enabled).
////            /// </summary>
////            Session
////        }

////        #endregion

////        #region Properties
////        /// <summary>
////        /// 控件是否可用
////        /// </summary>
////        public override bool Enabled
////        {
////            get
////            {
////                return base.Enabled;
////            }

////            set
////            {
////                base.Enabled = value;
////                if (value == false)
////                {
////                    this.userValidated = true; // when a validator is disabled, generally, the intent is not to make the page invalid for that round trip
////                }
////            }
////        }

////        /// <summary>
////        /// Gets or sets message to display in a Validation Summary when the CAPTCHA fails to validate (IValidator member).
////        /// </summary>
////        [Browsable(false)]
////        [Bindable(true)]
////        public string ErrorMessage
////        {
////            get
////            {
////                if (this.userValidated == true)
////                {
////                    return string.Empty;
////                }
////                else
////                {
////                    return this.errorMessage;
////                }
////            }

////            set
////            {
////                this.errorMessage = value;
////            }
////        }

////        /// <summary>
////        /// Gets or sets a value indicating whether the user was CAPTCHA validated after a postback (IValidator member).
////        /// </summary>
////        [Browsable(false)]
////        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
////        public bool IsValid
////        {
////            get
////            {
////                return this.userValidated;
////            }

////            set
////            {
////                // must be like that, because it is IValidator member
////            }
////        }

////        /// <summary>
////        /// Gets or sets ResourceManager's culture. If you want use other language - simply add Resources.[two letter language code].resx file to Properties. Resources.resx file is used if ResourceManager can't find appropriate file.
////        /// </summary>
////        [DefaultValue("")]
////        [Description("Optional UICulture (only language: 'de', 'pl',...). If empty - the same effect as Thread.CurrentThread.CurrentUICulture.ToString().")]
////        [Category("Appearance")]
////        public string OptionalUICulture
////        {
////            get
////            {
////                return this.optionalUICulture;
////            }

////            set
////            {
////                this.optionalUICulture = value;

////                if ((this.IsDesignMode == false) && (string.IsNullOrEmpty(this.optionalUICulture) == false))
////                {
////                    Resources.Culture = CultureInfo.GetCultureInfo(this.optionalUICulture);
////                }
////            }
////        }
////        /// <summary>
////        /// 输出样式
////        /// </summary>
////        [DefaultValue(Layout.Horizontal)]
////        [Description("Determines if image and input area are displayed horizontally, or vertically.")]
////        [Category("Captcha")]
////        public Layout LayoutStyle
////        {
////            get
////            {
////                return this.layoutStyle;
////            }

////            set
////            {
////                this.layoutStyle = value;
////            }
////        }
////        /// <summary>
////        /// 缓存策略
////        /// </summary>
////        [DefaultValue(CacheType.HttpRuntime)]
////        [Description("Determines if CAPTCHA codes are stored in HttpRuntime (fast, but local to current server) or Session (more portable across web farms).")]
////        [Category("Captcha")]
////        public CacheType CacheStrategy
////        {
////            get
////            {
////                return this.cacheStrategy;
////            }

////            set
////            {
////                this.cacheStrategy = value;
////            }
////        }
////        /// <summary>
////        /// 验证码请求最小时间间隔，防止恶意请求
////        /// </summary>
////        [DefaultValue(3)]
////        [Description("Minimum number of seconds CAPTCHA must be displayed before it is valid. If you're too fast, you must be a robot. Set to zero to disable.")]
////        [Category("Captcha")]
////        public int CaptchaMinTimeout
////        {
////            get
////            {
////                return this.timeoutSecondsMin;
////            }

////            set
////            {
////                if (value > 15)
////                {
////                    throw new ArgumentOutOfRangeException("CaptchaMinTimeout", "Timeout must be less than 15 seconds. Humans aren't that slow!");
////                }
////                else
////                {
////                    this.timeoutSecondsMin = value;
////                }
////            }
////        }
////        /// <summary>
////        /// 验证码超时秒数
////        /// </summary>
////        [DefaultValue(90)]
////        [Description("Maximum number of seconds CAPTCHA will be cached and valid. If you're too slow, you may be a CAPTCHA hack attempt. Set to zero to disable.")]
////        [Category("Captcha")]
////        public int CaptchaMaxTimeout
////        {
////            get
////            {
////                return this.timeoutSecondsMax;
////            }

////            set
////            {
////                if ((value < 15) && (value != 0))
////                {
////                    throw new ArgumentOutOfRangeException("CaptchaMaxTimeout", "Timeout must be greater than 15 seconds. Humans can't type that fast!");
////                }
////                else
////                {
////                    this.timeoutSecondsMax = value;
////                }
////            }
////        }
////        /// <summary>
////        /// 验证码字体
////        /// </summary>
////        [DefaultValue("")]
////        [Description("Font used to render CAPTCHA text. If font name is blank, a random font will be chosen.")]
////        [Category("Captcha")]
////        public string CaptchaFont
////        {
////            get
////            {
////                return this.font;
////            }

////            set
////            {
////                this.font = value;
////                this.captcha.FontFamilyName = value;
////            }
////        }
////        /// <summary>
////        /// 字符个数
////        /// </summary>
////        [DefaultValue("ACDEFGHJKLMNPQRTUVWXY34679")]
////        [Description("Characters used to render CAPTCHA text. A character will be picked randomly from the string.")]
////        [Category("Captcha")]
////        public string CaptchaChars
////        {
////            get
////            {
////                return this.captcha.TextChars;
////            }

////            set
////            {
////                this.captcha.TextChars = value;
////            }
////        }
////        /// <summary>
////        /// 验证码字符数
////        /// </summary>
////        [DefaultValue(5)]
////        [Description("Number of CaptchaChars used in the CAPTCHA text")]
////        [Category("Captcha")]
////        public int CaptchaLength
////        {
////            get
////            {
////                return this.captcha.TextLength;
////            }

////            set
////            {
////                this.captcha.TextLength = value;
////            }
////        }
////        /// <summary>
////        /// 验证码图片高度
////        /// </summary>
////        [DefaultValue(50)]
////        [Description("Height of generated CAPTCHA image.")]
////        [Category("Captcha")]
////        public int CaptchaHeight
////        {
////            get
////            {
////                return this.captcha.Height;
////            }

////            set
////            {
////                this.captcha.Height = value;
////            }
////        }
////        /// <summary>
////        /// 验证码图片宽度
////        /// </summary>
////        [DefaultValue(180)]
////        [Description("Width of generated CAPTCHA image.")]
////        [Category("Captcha")]
////        public int CaptchaWidth
////        {
////            get
////            {
////                return this.captcha.Width;
////            }

////            set
////            {
////                this.captcha.Width = value;
////            }
////        }
////        /// <summary>
////        /// 字体变形程度
////        /// </summary>
////        [DefaultValue(CaptchaImage.FontWarpFactor.Low)]
////        [Description("Amount of random font warping used on the CAPTCHA text")]
////        [Category("Captcha")]
////        public CaptchaImage.FontWarpFactor CaptchaFontWarping
////        {
////            get
////            {
////                return this.captcha.FontWarp;
////            }

////            set
////            {
////                this.captcha.FontWarp = value;
////            }
////        }
////        /// <summary>
////        /// 噪点程度
////        /// </summary>
////        [DefaultValue(CaptchaImage.BackgroundNoiseLevel.Low)]
////        [Description("Amount of background noise to generate in the CAPTCHA image")]
////        [Category("Captcha")]
////        public CaptchaImage.BackgroundNoiseLevel CaptchaBackgroundNoise
////        {
////            get
////            {
////                return this.captcha.BackgroundNoise;
////            }

////            set
////            {
////                this.captcha.BackgroundNoise = value;
////            }
////        }
////        /// <summary>
////        /// 噪点线程度
////        /// </summary>
////        [DefaultValue(CaptchaImage.LineNoiseLevel.None)]
////        [Description("Add line noise to the CAPTCHA image")]
////        [Category("Captcha")]
////        public CaptchaImage.LineNoiseLevel CaptchaLineNoise
////        {
////            get
////            {
////                return this.captcha.LineNoise;
////            }

////            set
////            {
////                this.captcha.LineNoise = value;
////            }
////        }
////        /// <summary>
////        /// 子控件集
////        /// </summary>
////        public override ControlCollection Controls
////        {
////            get
////            {
////                this.EnsureChildControls();
////                return base.Controls;
////            }
////        }
////        /// <summary>
////        /// Html标签键
////        /// </summary>
////        protected override HtmlTextWriterTag TagKey
////        {
////            get
////            {
////                return HtmlTextWriterTag.Div; // otherwise control is enclosed in span
////            }
////        }

////        private bool IsDesignMode
////        {
////            get
////            {
////                return (HttpContext.Current == null);
////            }
////        }

////        #endregion
////        /// <summary>
////        /// 验证
////        /// </summary>
////        public void Validate() // IValidator - empty (validation in LoadPostData)
////        {
////        }
////        /// <summary>
////        /// 载入回传数据
////        /// </summary>
////        public bool LoadPostData(string postDataKey, NameValueCollection postCollection) // IPostBackDataHandler
////        {
////            string userEntry = postCollection[UniqueID + "$" + this.captchaInputID];
////            // ((TextBox)this.FindControl(this.captchaInputID)).Text = string.Empty; // can't remove previously entered text, because of validator
////            this.ValidateCaptcha(userEntry);
////            return false;
////        }
////        /// <summary>
////        /// 激发回传数据改变事件
////        /// </summary>
////        public void RaisePostDataChangedEvent() // IPostBackDataHandler - empty
////        {
////        }
////        /// <summary>
////        /// 载入控件状态
////        /// </summary>
////        protected override void LoadControlState(object savedState)
////        {
////            if (savedState != null)
////            {
////                this.previousGuid = (string)savedState;
////            }
////        }
////        /// <summary>
////        /// 保存控件状态
////        /// </summary>
////        protected override object SaveControlState()
////        {
////            return (object)this.captcha.UniqueId;
////        }
////        /// <summary>
////        /// OnInit初始化
////        /// </summary>
////        protected override void OnInit(EventArgs e)
////        {
////            base.OnInit(e);
////            Page.RegisterRequiresControlState(this);
////            Page.Validators.Add(this);
////        }
////        /// <summary>
////        /// 预呈现
////        /// </summary>
////        protected override void OnPreRender(EventArgs e)
////        {
////            if (this.Visible == true)
////            {
////                if (this.IsDesignMode == false)
////                {
////                    if (this.cacheStrategy == CacheType.HttpRuntime)
////                    {
////                        HttpRuntime.Cache.Add(this.captcha.UniqueId, this.captcha, null, DateTime.Now.AddSeconds((double)(this.CaptchaMaxTimeout == 0 ? 90 : this.CaptchaMaxTimeout)), TimeSpan.Zero, CacheItemPriority.NotRemovable, null);
////                    }
////                    else
////                    {
////                        HttpContext.Current.Session.Add(this.captcha.UniqueId, this.captcha);
////                    }
////                }
////            }

////            base.OnPreRender(e);

////            if (Page != null)
////            {
////                Page.RegisterRequiresPostBack(this);
////            }
////        }
////        /// <summary>
////        /// 创建子控件集
////        /// </summary>
////        protected override void CreateChildControls()
////        {
////            this.Controls.Clear();

////            //// master DIV
////            Literal openingDivs = new Literal();
////            openingDivs.Text = "<div";
////            if (string.IsNullOrEmpty(CssClass) == false)
////            {
////                openingDivs.Text += " class='" + CssClass + "'";
////            }

////            openingDivs.Text += this.GenerateCssStyle();
////            openingDivs.Text += ">";

////            //// image DIV/SPAN
////            if (this.LayoutStyle == Layout.Vertical)
////            {
////                openingDivs.Text += "<div style='text-align:center;margin:5px;'>";
////            }
////            else
////            {
////                openingDivs.Text += "<span style='margin:5px;float:left;'>";
////            }

////            this.Controls.Add(openingDivs);

////            //// image - its URL triggers the CaptchaImageHandler
////            Literal image = new Literal();

////            image.Text = "<img src=\"CaptchaImage.aspx";
////            if (this.IsDesignMode == false)
////            {
////                image.Text += "?guid=" + this.captcha.UniqueId;
////            }

////            if (this.CacheStrategy == CacheType.Session)
////            {
////                image.Text += "&useSession=1";
////            }

////            image.Text += "\" border=\"0\"";

////            if (ToolTip.Length > 0)
////            {
////                image.Text += " alt=\"" + ToolTip + "\"";
////            }

////            image.Text += " width=\"" + this.captcha.Width + "\"";
////            image.Text += " height=\"" + this.captcha.Height + "\"";
////            image.Text += "/>";

////            this.Controls.Add(image);

////            Literal divsContinue = new Literal();

////            if (this.LayoutStyle == Layout.Vertical)
////            {
////                divsContinue.Text = "</div>";
////            }
////            else
////            {
////                divsContinue.Text = "</span>";
////            }

////            //// text input and submit button DIV/SPAN
////            if (this.LayoutStyle == Layout.Vertical)
////            {
////                divsContinue.Text += "<div style='text-align:center;margin:5px;'>";
////            }
////            else
////            {
////                divsContinue.Text += "<span style='margin:5px;float:left;'>";
////            }

////            divsContinue.Text += Resources.enterCode;
////            divsContinue.Text += "<br/>";

////            this.Controls.Add(divsContinue);

////            TextBox input = new TextBox();
////            input.ID = this.captchaInputID;

////            input.Attributes.Add("size", this.captcha.TextLength.ToString());
////            input.MaxLength = this.captcha.TextLength;

////            input.AccessKey = AccessKey;
////            input.Enabled = this.Enabled;
////            input.TabIndex = TabIndex;
////            input.Text = string.Empty;

////            input.EnableViewState = false;

////            this.Controls.Add(input);

////            RequiredFieldValidator reqField = new RequiredFieldValidator();
////            reqField.ID = "CaptchaInputValidator";
////            reqField.ControlToValidate = this.captchaInputID;
////            reqField.Text = "*";
////            reqField.ErrorMessage = Resources.textInputFieldRequired;
////            reqField.Display = ValidatorDisplay.Dynamic;
////            this.Controls.Add(reqField);

////            Literal closingDivs = new Literal();

////            if (this.LayoutStyle == Layout.Vertical)
////            {
////                closingDivs.Text = "</div>";
////            }
////            else
////            {
////                closingDivs.Text = "</span>";
////                closingDivs.Text += "<br clear='all'/>";
////            }

////            //// closing tag for master DIV
////            closingDivs.Text += "</div>";

////            this.Controls.Add(closingDivs);
////        }
////        /// <summary>
////        /// 卸载控件
////        /// </summary>
////        protected override void OnUnload(EventArgs e)
////        {
////            if (Page != null)
////            {
////                Page.Validators.Remove(this);
////            }

////            base.OnUnload(e);
////        }

////        private CaptchaImage GetCachedCaptcha(string guid)
////        {
////            if (this.cacheStrategy == CacheType.HttpRuntime)
////            {
////                return (CaptchaImage)HttpRuntime.Cache.Get(guid);
////            }
////            else
////            {
////                return (CaptchaImage)HttpContext.Current.Session[guid];
////            }
////        }

////        private void RemoveCachedCaptcha(string guid)
////        {
////            if (this.cacheStrategy == CacheType.HttpRuntime)
////            {
////                HttpRuntime.Cache.Remove(guid);
////            }
////            else
////            {
////                HttpContext.Current.Session.Remove(guid);
////            }
////        }

////        private void ValidateCaptcha(string userEntry)
////        {
////            if ((this.Visible == false) || (this.Enabled == false))
////            {
////                this.userValidated = true;
////                return;
////            }

////            //// retrieve the previous captcha from the cache to inspect its properties
////            CaptchaImage ci = this.GetCachedCaptcha(this.previousGuid);
////            if (ci == null)
////            {
////                this.ErrorMessage = string.Format(Resources.codeExpired, this.CaptchaMaxTimeout);
////                this.userValidated = false;

////                return;
////            }

////            //// was it entered too quickly?
////            if (this.CaptchaMinTimeout > 0)
////            {
////                if (ci.RenderedAt.AddSeconds(this.CaptchaMinTimeout) > DateTime.Now)
////                {
////                    this.userValidated = false;
////                    this.ErrorMessage = string.Format(Resources.codeTypedTooQuickly, this.CaptchaMinTimeout);
////                    this.RemoveCachedCaptcha(this.previousGuid);

////                    return;
////                }
////            }

////            if (String.Compare(userEntry, ci.Text, true, CultureInfo.CurrentCulture) != 0)
////            {
////                this.ErrorMessage = Resources.textDoesNotMatch;
////                this.userValidated = false;
////            }
////            else
////            {
////                this.userValidated = true;
////            }

////            this.RemoveCachedCaptcha(this.previousGuid);
////        }

////        private string GenerateCssStyle()
////        {
////            StringBuilder cssStyle = new StringBuilder();
////            string color;

////            cssStyle.Append(" style='");

////            if (BorderWidth.ToString().Length > 0)
////            {
////                cssStyle.Append("border-width:");
////                cssStyle.Append(BorderWidth.ToString());
////                cssStyle.Append(";");
////            }

////            if (BorderStyle != BorderStyle.NotSet)
////            {
////                cssStyle.Append("border-style:");
////                cssStyle.Append(BorderStyle.ToString());
////                cssStyle.Append(";");
////            }

////            color = this.GetHtmlColor(BorderColor);
////            if (color.Length > 0)
////            {
////                cssStyle.Append("border-color:");
////                cssStyle.Append(color);
////                cssStyle.Append(";");
////            }

////            color = this.GetHtmlColor(BackColor);
////            if (color.Length > 0)
////            {
////                cssStyle.Append("background-color:" + color + ";");
////            }

////            color = this.GetHtmlColor(ForeColor);
////            if (color.Length > 0)
////            {
////                cssStyle.Append("color:" + color + ";");
////            }

////            if (this.Font.Bold == true)
////            {
////                cssStyle.Append("font-weight:bold;");
////            }

////            if (Font.Italic == true)
////            {
////                cssStyle.Append("font-style:italic;");
////            }

////            if (Font.Underline == true)
////            {
////                cssStyle.Append("text-decoration:underline;");
////            }

////            if (Font.Strikeout == true)
////            {
////                cssStyle.Append("text-decoration:line-through;");
////            }

////            if (Font.Overline == true)
////            {
////                cssStyle.Append("text-decoration:overline;");
////            }

////            if (Font.Size.ToString().Length > 0)
////            {
////                cssStyle.Append("font-size:" + Font.Size.ToString() + ";");
////            }

////            if (Font.Names.Length > 0)
////            {
////                cssStyle.Append("font-family:");
////                foreach (string fontFamily in Font.Names)
////                {
////                    cssStyle.Append(fontFamily);
////                    cssStyle.Append(",");
////                }

////                cssStyle.Length = cssStyle.Length - 1;
////                cssStyle.Append(";");
////            }

////            if (string.IsNullOrEmpty(Height.ToString()) == false)
////            {
////                cssStyle.Append("height:" + Height.ToString() + ";");
////            }

////            if (string.IsNullOrEmpty(Width.ToString()) == false)
////            {
////                cssStyle.Append("width:" + Width.ToString() + ";");
////            }

////            cssStyle.Append("'");

////            if (cssStyle.ToString() == " style=''")
////            {
////                return string.Empty;
////            }
////            else
////            {
////                return cssStyle.ToString();
////            }
////        }

////        private string GetHtmlColor(Color color)
////        {
////            if (color.IsEmpty == true)
////            {
////                return string.Empty;
////            }

////            if (color.IsNamedColor == true)
////            {
////                return color.ToKnownColor().ToString();
////            }

////            if (color.IsSystemColor == true)
////            {
////                return color.ToString();
////            }

////            return "#" + color.ToArgb().ToString("x").Substring(2);
////        }
////    }
////}