//using System;
//using System.IO;
//using System.Net;
//using System.Text;

//namespace SmartSolution.Utilities.Win.Helpers
//{
//    public class MyWebRequest1
//    {
//        private WebRequest request;
//        private Stream dataStream;

//        private string status;

//        public String Status
//        {
//            get
//            {
//                return status;
//            }
//            set
//            {
//                status = value;
//            }
//        }

//        public MyWebRequest1(string url)
//        {
//            // Create a request using a URL that can receive a post.

//            request = WebRequest.Create(url);
//        }

//        public MyWebRequest1(string url, string method)
//            : this(url)
//        {

//            if (method.Equals("GET") || method.Equals("POST"))
//            {
//                // Set the Method property of the request to POST.
//                request.Method = method;
//            }
//            else
//            {
//                throw new Exception("Invalid Method Type");
//            }
//        }

//        public MyWebRequest1(string url, string method, string data)
//            : this(url, method)
//        {

//            // Create POST data and convert it to a byte array.
//            string postData = data;
//            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

//            // Set the ContentType property of the WebRequest.
//            request.ContentType = "application/x-www-form-urlencoded";

//            // Set the ContentLength property of the WebRequest.
//            request.ContentLength = byteArray.Length;

//            // Get the request stream.
//            dataStream = request.GetRequestStream();

//            // Write the data to the request stream.
//            dataStream.Write(byteArray, 0, byteArray.Length);

//            // Close the Stream object.
//            dataStream.Close();

//        }

//        public string GetResponse()
//        {
//            // Get the original response.
//            WebResponse response = request.GetResponse();

//            this.Status = ((HttpWebResponse)response).StatusDescription;

//            // Get the stream containing all content returned by the requested server.
//            dataStream = response.GetResponseStream();

//            // Open the stream using a StreamReader for easy access.
//            StreamReader reader = new StreamReader(dataStream);

//            // Read the content fully up to the end.
//            string responseFromServer = reader.ReadToEnd();

//            // Clean up the streams.
//            reader.Close();
//            dataStream.Close();
//            response.Close();

//            return responseFromServer;
//        }

//    }


//    //HttpWebRequest wReq = (HttpWebRequest)WebRequest.Create("http://localhost:37831/api/Values");
//    //wReq.Method = "Post";
//    //        //wReq.ContentType = "application/json";
//    //        //wReq.ContentType = "application/x-www-form-urlencoded";
//    //        wReq.ContentType = "application/json";

//    //        //byte[] data = Encoding.Default.GetBytes(HttpUtility.UrlEncode("key=rfwreewr2332322232&261=3&261=4"));
//    //        byte[] data = Encoding.Default.GetBytes("{\"id\":\"test1\",\"name\":\"value\"}");
//    //wReq.ContentLength = data.Length;
//    //        Stream reqStream = wReq.GetRequestStream();
//    //reqStream.Write(data, 0, data.Length);
//    //        reqStream.Close();
//    //        using (StreamReader sr = new StreamReader(wReq.GetResponse().GetResponseStream()))
//    //        {
//    //            string result = sr.ReadToEnd();


//}