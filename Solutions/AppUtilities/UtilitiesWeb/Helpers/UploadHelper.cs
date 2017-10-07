/******************************************
 * 2012年5月31日 王怀生 添加
 * 
 * ***************************************/

using System;
using System.IO;
using System.Web;

namespace WitsWay.Utilities.Web.Helpers
{

    /// <summary>
    /// 上传文件辅助类
    /// </summary>
    public class UploadHelper
    {

        #region [CheckFileExtension]

        /// <summary>
        /// 检查文件扩展名
        /// 检查是否是伪装文件
        /// </summary>
        /// <param name="file">上传文件</param>
        /// <returns>通过返回true，不通过false</returns>
        public static bool CheckFileExtension(HttpPostedFile file)
        {
            FileExtensionValidateEnum[] fe = { FileExtensionValidateEnum.GIF, FileExtensionValidateEnum.JPG, FileExtensionValidateEnum.PNG };
            return IsAllowedExtension(file, fe);
        }

        private static bool IsAllowedExtension(HttpPostedFile file, FileExtensionValidateEnum[] fileEx)
        {
            var fileLen = file.ContentLength;
            var imgArray = new byte[fileLen];
            file.InputStream.Read(imgArray, 0, fileLen);
            var ms = new MemoryStream(imgArray);
            var br = new BinaryReader(ms);
            var fileclass = "";
            byte buffer;
            try
            {
                buffer = br.ReadByte();
                fileclass = buffer.ToString();
                buffer = br.ReadByte();
                fileclass += buffer.ToString();
            }
            catch
            {

            }
            br.Close();
            ms.Close();
            foreach (var fe in fileEx)
            {
                if (Int32.Parse(fileclass) == (int)fe)
                {
                    return true;
                }
            }
            return false;
        }

        private enum FileExtensionValidateEnum
        {
            JPG = 255216,
            GIF = 7173,
            PNG = 13780,
            BMP=6677,
            SWF = 6787,
            RAR = 8297,
            ZIP = 8075,
            _7Z = 55122,
            XML=6063,
            HTML=6033,
            TXT=102100
            // 7790 exe dll,   
            // 239187 aspx
            // 117115 cs
            // 119105 js 
            // 255254 sql
        }

        #endregion

    }
}
