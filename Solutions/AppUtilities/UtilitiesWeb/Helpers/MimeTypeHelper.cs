/*2012年6月1日 王怀生 新增
 * 
 * */

namespace WitsWay.Utilities.Web.Helpers
{
    /// <summary>
    /// 包含Mimi类型的列表
    /// </summary>
    public static class MimeTypeHelper
    {

        /// <summary>
        /// 获取Mime类型
        /// </summary>
        public static string GetMimeType(MimeTypeEnum mime)
        {
            switch (mime)
            {
                case MimeTypeEnum.JPG:
                case MimeTypeEnum.JPEG:
                case MimeTypeEnum.JPE:
                    return @"image/jpeg";
                case MimeTypeEnum.GIF:
                    return @"image/gif";
                case MimeTypeEnum.PNG:
                    return @"image/png";
                case MimeTypeEnum.BMP:
                    return @"image/bmp";
                case MimeTypeEnum.TIF:
                case MimeTypeEnum.TIFF:
                    return @"image/tiff";
                case MimeTypeEnum.SVG:
                    return @"image/svg+xml";
                case MimeTypeEnum.ICO:
                    return @"image/x-icon";
                case MimeTypeEnum.TXT:
                    return @"text/plain";
                case MimeTypeEnum.HTM:
                case MimeTypeEnum.HTML:
                    return @"text/html";
                case MimeTypeEnum.XHTML:
                    return @"text/xhtml";
                case MimeTypeEnum.XML:
                    return @"text/xml";
                case MimeTypeEnum.XSL:
                    return @"text/xsl";
                case MimeTypeEnum.DTD:
                    return @"application/xml-dtd";
                case MimeTypeEnum.CSS:
                    return @"text/css";
                case MimeTypeEnum.RTF:
                    return @"text/rtf";
                case MimeTypeEnum.ZIP:
                    return @"application/zip";
                case MimeTypeEnum.TAR:
                    return @"application/x-tar";
                case MimeTypeEnum.PDF:
                    return @"application/pdf";
                case MimeTypeEnum.DOC:
                    return @"application/msword";
                case MimeTypeEnum.AI:
                case MimeTypeEnum.PS:
                case MimeTypeEnum.EPS:
                    return @"application/postscript";
                case MimeTypeEnum.OGG:
                    return @"application/ogg";
                case MimeTypeEnum.SWF:
                    return @"application/x-shockwave-flash";
                case MimeTypeEnum.MPGA:
                case MimeTypeEnum.MP2:
                case MimeTypeEnum.MP3:
                    return @"audio/mpeg";
                case MimeTypeEnum.MPG:
                case MimeTypeEnum.MPEG:
                case MimeTypeEnum.MPE:
                    return @"video/mpeg";
                case MimeTypeEnum.M3U:
                    return @"audio/x-mpegurl";
                case MimeTypeEnum.RAM:
                    return @"audio/x-pn-realaudio";
                case MimeTypeEnum.RA:
                    return @"audio/x-pn-realaudio";
                case MimeTypeEnum.RM:
                    return @"application/vnd.rn-realmedia";
                case MimeTypeEnum.WAV:
                    return @"application/x-wav";
                case MimeTypeEnum.MOV:
                case MimeTypeEnum.QT:
                    return @"video/quicktime";
                case MimeTypeEnum.AVI:
                    return @"video/x-msvideo";
                case MimeTypeEnum.JS:
                    return @"text/javascript";
                case MimeTypeEnum.Json:
                    return @"application/json";
                default:
                    return MimeTypeEnum.Unknown.ToString();
            }
        }
    }
}
