#region License(Apache Version 2.0)
/******************************************
 * Copyright ®2017-Now WangHuaiSheng.
 * Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file
 * except in compliance with the License. You may obtain a copy of the License at
 * http://www.apache.org/licenses/LICENSE-2.0
 * Unless required by applicable law or agreed to in writing, software distributed under the
 * License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
 * either express or implied. See the License for the specific language governing permissions
 * and limitations under the License.
 * Detail: https://github.com/WangHuaiSheng/WitsWay/LICENSE
 * ***************************************/
#endregion 
#region ChangeLog
/******************************************
 * 2017-10-7 OutMan Create
 * 
 * ***************************************/
#endregion
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
