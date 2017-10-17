using System;
using System.IO;
//using System.Linq;

/// <summary>
/// Summary description for Config
/// </summary>
namespace TestPostPay
{
    public class Config
    {

        public static string alipay_public_key =AppDomain.CurrentDomain.BaseDirectory + "Demo\\alipay_rsa_public_key_dev.pem";
        //这里要配置没有经过PKCS8转换的原始私钥
        public static string merchant_private_key = AppDomain.CurrentDomain.BaseDirectory + "Demo\\rsa_private_key_dev.pem";
        public static string merchant_public_key = AppDomain.CurrentDomain.BaseDirectory + "Demo\\rsa_public_key_dev.pem";
        public static string appId = "2015111600806792";//当面付(含CRM)V4
        public static string serverUrl = "https://openapi.alipay.com/gateway.do";
        public static string mapiUrl = "https://mapi.alipay.com/gateway.do";
        public static string pid = "2088121116760986";//Touch即时到账PID（合作者ID）



        public static string charset = "utf-8";//"utf-8";
        public static string sign_type = "RSA";
        public static string version = "1.0";


        public Config()
        {
            //
        }

        public static string getMerchantPublicKeyStr()
        {
            StreamReader sr = new StreamReader(merchant_public_key);
            string pubkey = sr.ReadToEnd();
            sr.Close();
            if (pubkey != null)
            {
                pubkey = pubkey.Replace("-----BEGIN PUBLIC KEY-----", "");
                pubkey = pubkey.Replace("-----END PUBLIC KEY-----", "");
                pubkey = pubkey.Replace("\r", "");
                pubkey = pubkey.Replace("\n", "");
            }
            return pubkey;
        }

        public static string getMerchantPriveteKeyStr()
        {
            StreamReader sr = new StreamReader(merchant_private_key);
            string pubkey = sr.ReadToEnd();
            sr.Close();
            if (pubkey != null)
            {
                pubkey = pubkey.Replace("-----BEGIN PUBLIC KEY-----", "");
                pubkey = pubkey.Replace("-----END PUBLIC KEY-----", "");
                pubkey = pubkey.Replace("\r", "");
                pubkey = pubkey.Replace("\n", "");
            }
            return pubkey;
        }

    }
}