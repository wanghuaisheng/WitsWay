﻿//using System;
//using System.IO;
//using System.Net;
//using System.Text;
//using System.Windows.Forms;

//namespace SmartSolution.Utilities.Win.Helpers
//{

//    public class MyWebRequest3
//    {


//        public void DoIt()
//        {
//            try
//            {
//                String url = "https://iothook.com/api/v1.2/datas/";



//                CookieContainer cookies = new CookieContainer();
//                var webRequest = (HttpWebRequest)WebRequest.Create(url);
//                webRequest.Method = "POST";

//                cookies.Add(new Cookie("name","value","path","domain"));

//                webRequest.CookieContainer = cookies;
//                webRequest.ContentType = "application/json";
//                webRequest.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.9.0.1) Gecko/2008070208 Firefox/3.0.1";
//                webRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
//                string autorization = kuladi.Text + ":" + kulsifre.Text;
//                byte[] binaryAuthorization = System.Text.Encoding.UTF8.GetBytes(autorization);
//                autorization = Convert.ToBase64String(binaryAuthorization);
//                autorization = "Basic " + autorization;
//                webRequest.Headers.Add("AUTHORIZATION", autorization);
//                webRequest.SendChunked = true;

//                using (var streamWriter = new StreamWriter(webRequest.GetRequestStream()))
//                {
//                    var json = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(new
//                    {
//                        api_key = apikey.Text,
//                        value_1 = v1.Text,
//                        value_2 = v2.Text,
//                        value_3 = v3.Text,
//                        value_4 = v4.Text,
//                        value_5 = v5.Text,

//                    });

//                    streamWriter.Write(json);

//                    Console.Write(json);
//                    MessageBox.Show("Değerler başarılı bir şekilde yüklendi.");
//                    streamWriter.Flush();
//                    streamWriter.Close();
//                    webRequest.Abort();

//                }
//            }
//            catch (Exception)
//            {
//                MessageBox.Show("kullanıcı adı , şifre , api key yanlış veya bağlantınızda sorun olabilir.");
//                timer1.Stop();
//            }
//        }

//    }
//}