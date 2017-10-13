using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using Touch.Enums.Posts;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;
using ZXing.QrCode.Internal;


namespace TestPostPay
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }


        string _orderNo = "";

        private void _btnCommitOrder_Click(object sender, EventArgs e)
        {
            ScreenOrder();
        }

        private void _btnQueryOrder_Click(object sender, EventArgs e)
        {
            ScreenQueryOrder();
        }

        #region [Screen]
        
        private void ScreenOrder()
        {
            var url = "http://localhost:6211/api/dealer/screenorder";
            var data = new ScreenOrderPost()
            {
                ProjectIC = "1C1CA9F82E713EED2F91010D315029E9",
                TerminalKind = 1,
                Username = "fuwanglxh",
                UUID = "303BE24C-ECC4-464F-885B-082C5156A7BA",
                CustomerName = "CustomerName",
                CustomerPhone = "CustomerPhone",
                Items = new List<ScreenOrderPostItem>()
                {
                    new ScreenOrderPostItem(){OrderNum=1,ProductIC="AFF05484FCCB46498E3917A99E3E2EF3"}
                }
            };

            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            var dataString = jsonSerializer.Serialize(data);

            var result = HttpPost(url, dataString);
            var response = jsonSerializer.Deserialize<ScreenOrderResult>(result);
            var qrCode = response.QrCode;
            _orderNo = response.OrderNo;

            var bitmap = CreateBarcodeBitmap(qrCode, pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bitmap;
        }

        private void ScreenQueryOrder()
        {
            bool goon = true;
            while (goon)
            {
                Thread.Sleep(2000);
                var url = "http://localhost:6211/api/dealer/screenorderstatus";
                PadOrderQueryPost data = new PadOrderQueryPost()
                {
                    OrderNo = _orderNo
                };

                JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                var dataString = jsonSerializer.Serialize(data);

                var result = HttpPost(url, dataString);
                var response = jsonSerializer.Deserialize<PadOrderQueryResult>(result);
                if (response.Status == 1)
                {
                    goon = false;
                }
                else
                {
                    Debug.Print(result);
                }
            }
        }

        #endregion

        #region [Pad]

        private void PadOrder()
        {
            var url = "http://localhost:6211/api/dealer/padorder";
            var data = new PadOrderPost()
            {
                ProjectIC = "1C1CA9F82E713EED2F91010D315029E9",
                Username = "fuwanglxh",
                UUID = "303BE24C-ECC4-464F-885B-082C5156A7BA",
                Items = new List<PadOrderPostItem>()
                {
                    new PadOrderPostItem(){OrderNum=1,ProductIC="AFF05484FCCB46498E3917A99E3E2EF3"}
                }
            };

            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            var dataString = jsonSerializer.Serialize(data);

            var result = HttpPost(url, dataString);
            var response = jsonSerializer.Deserialize<PadOrderResult>(result);
            var qrCode = response.QrCode;
            _orderNo = response.OrderNo;

            var bitmap = CreateBarcodeBitmap(qrCode, pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bitmap;
        }

        private void PadQueryOrder()
        {
            bool goon = true;
            while (goon)
            {
                Thread.Sleep(2000);
                var url = "http://localhost:6211/api/dealer/padorderstatus";
                PadOrderQueryPost data = new PadOrderQueryPost()
                {
                    OrderNo = _orderNo
                };

                JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                var dataString = jsonSerializer.Serialize(data);

                var result = HttpPost(url, dataString);
                var response = jsonSerializer.Deserialize<PadOrderQueryResult>(result);
                if (response.Status == 1)
                {
                    goon = false;
                }
                else
                {
                    Debug.Print(result);
                }
            }
        }

        #endregion

        #region [Supports]


        /// <summary>
        /// 创建二维码图片
        /// </summary>
        /// <param name="content">内容</param>
        /// <param name="width">宽度</param>
        /// <param name="height"></param>
        /// <returns></returns>
        private Bitmap CreateBarcodeBitmap(string content, int width, int height)
        {
            EncodingOptions options = new QrCodeEncodingOptions
            {
                DisableECI = true,
                CharacterSet = "UTF-8",
                ErrorCorrection = ErrorCorrectionLevel.H,
                Margin = 0,
                PureBarcode = false,
                Width = width,
                Height = height
            };
            BarcodeWriter writer = new BarcodeWriter();
            writer.Format = BarcodeFormat.QR_CODE;
            writer.Options = options;
            Bitmap bitmap = writer.Write(content);
            return bitmap;
        }

        /// <summary>
        /// 通过HttpClient提交Post数据
        /// </summary>
        /// <param name="baseUrl">基地址，例如【http://192.168.0.250】</param>
        /// <param name="apiUrl">api地址，例如【/api/dealer/screenorder】</param>
        /// <param name="postData">json字符串</param>
        /// <returns>响应结果字符串</returns>
        private string HttpClientPost(string baseUrl, string apiUrl, string postData)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpContent contentPost = new StringContent(postData, Encoding.UTF8, "application/json");
                var result = client.PostAsync(apiUrl, contentPost).Result;
                string resultContent = result.Content.ReadAsStringAsync().Result;
                Console.WriteLine(resultContent);
                return resultContent;
            }
        }


        private string HttpPost(string Url, string postDataStr)
        {
            CookieContainer cookie = new CookieContainer();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Method = "POST";
            request.ContentType = "application/json;charset=UTF-8";
            request.ContentLength = Encoding.UTF8.GetByteCount(postDataStr);
            request.CookieContainer = cookie;
            Stream myRequestStream = request.GetRequestStream();
            StreamWriter myStreamWriter = new StreamWriter(myRequestStream, Encoding.GetEncoding("gb2312"));
            myStreamWriter.Write(postDataStr);
            myStreamWriter.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            response.Cookies = cookie.GetCookies(response.ResponseUri);
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();

            return retString;

        }

        public string HttpGet(string Url, string postDataStr)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url + (postDataStr == "" ? "" : "?") + postDataStr);
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();

            return retString;
        }

        #endregion


        public class LoginInfo
        {
            public string Username { get; set; }

            public string Password { get; set; }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var url = "http://test.rjgzs.net/login/loginzwm";
            var data = new LoginInfo()
            {
                Username="zwm",
                Password="123"
            };

            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            var dataString = jsonSerializer.Serialize(data);

            var result = HttpPost(url, dataString);
            var response = result;// jsonSerializer.Deserialize<PadOrderQueryResult>(result);
            if (response == "1")
            {
                MessageBox.Show("登录成功");
            }
            else
            {
                Debug.Print(result);
            }
        }
    }

}
