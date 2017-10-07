/******************************************
 * 2012��4��25�� ������ ���
 * 
 * ***************************************/

using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using WitsWay.Utilities.Enums;

namespace WitsWay.Utilities.Helpers
{

    /// <summary>
    /// �ӽ��ܸ�����
    /// </summary>
    public static class EncryptDecryptHelper
    {

        //Ĭ����Կ����
        private static readonly byte[] Keys = { 0x34, 0x56, 0x78, 0xAB, 0xCD, 0x12, 0x90, 0xEF };

        /// <summary>
        /// DES�����ַ���
        /// </summary>
        /// <param name="encryptString">�����ܵ��ַ���</param>
        /// <param name="encryptKey">������Կ,Ҫ��Ϊ8λ</param>
        /// <returns>���ܳɹ����ؼ��ܺ���ַ�����ʧ�ܷ���Դ��</returns>
        public static string EncryptDES(string encryptString, string encryptKey)
        {
            try
            {
                var rgbKey = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 8));
                var rgbIV = Keys;
                var inputByteArray = Encoding.UTF8.GetBytes(encryptString);
                var dCSP = new DESCryptoServiceProvider();
                var mStream = new MemoryStream();
                var cStream = new CryptoStream(mStream, dCSP.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Convert.ToBase64String(mStream.ToArray());
            }
            catch
            {
                return encryptString;
            }
        }

        /// <summary>
        /// DES�����ַ���
        /// </summary>
        /// <param name="decryptString">�����ܵ��ַ���</param>
        /// <param name="decryptKey">������Կ,Ҫ��Ϊ8λ,�ͼ�����Կ��ͬ</param>
        /// <returns>���ܳɹ����ؽ��ܺ���ַ�����ʧ�ܷ�Դ��</returns>
        public static string DecryptDES(string decryptString, string decryptKey)
        {
            try
            {
                var rgbKey = Encoding.UTF8.GetBytes(decryptKey);
                var rgbIV = Keys;
                var inputByteArray = Convert.FromBase64String(decryptString);
                var DCSP = new DESCryptoServiceProvider();
                var mStream = new MemoryStream();
                var cStream = new CryptoStream(mStream, DCSP.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Encoding.UTF8.GetString(mStream.ToArray());
            }
            catch
            {
                return decryptString;
            }
        }

        /// <summary>
        /// MD5�����ַ���
        /// </summary>
        /// <param name="encryptString">��Ҫ���ܵ��ַ���</param>
        /// <returns></returns>
        public static string EncryptMD5(string encryptString)
        {
            if (string.IsNullOrEmpty(encryptString)) return string.Empty;
            var hashAlgorithm = HashAlgorithmKinds.Md5.GetHashAlgorithm();
            using (hashAlgorithm)
            {
                return BytesToHex(hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(encryptString)));
            }
        }

        /// <summary>
        /// Converts a byte array into its hexadecimal representation.
        /// </summary>
        /// <param name="data">The binary byte array.</param>
        /// <returns>The hexadecimal (uppercase) equivalent of the byte array.</returns>
        public static string BytesToHex(byte[] data)
        {
            if (data == null || data.Length == 0) return string.Empty;
            var hex = new char[checked(data.Length * 2)];
            for (var i = 0; i < data.Length; i++)
            {
                var thisByte = data[i];
                hex[2 * i] = NibbleToHex((byte)(thisByte >> 4)); // high nibble
                hex[2 * i + 1] = NibbleToHex((byte)(thisByte & 0xf)); // low nibble
            }
            return new string(hex);
        }

        private static char NibbleToHex(byte nibble)
        {
            // converts a nibble (4 bits) to its uppercase hexadecimal character representation [0-9, A-F]
            return (char)(nibble < 10 ? (nibble + '0') : (nibble - 10 + 'A'));
        }

    }
}
