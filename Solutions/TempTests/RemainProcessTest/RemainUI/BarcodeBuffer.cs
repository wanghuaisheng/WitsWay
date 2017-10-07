using System.Text;

namespace WitsWay.TempTests.RemainProcessTest.RemainUI
{
    /// <summary>
    /// 条码缓冲区
    /// </summary>
    public class BarcodeBuffer
    {
        /// <summary>
        /// 扫描条码字符
        /// </summary>
        /// <param name="keyValue">字符</param>
        /// <returns>已处理返回true，否则false</returns>
        public static bool HandleInput(int keyValue)
        {
            switch (keyValue)
            {
                case 32:
                    return true;
                case 48: //扫描条码0
                case 49: //扫描条码1
                case 50: //扫描条码2
                case 51: //扫描条码3
                case 52: //扫描条码4
                case 53: //扫描条码5
                case 54: //扫描条码6
                case 55: //扫描条码7
                case 56: //扫描条码8
                case 57: //扫描条码9
                    {
                        _sb.Append((char)keyValue);
                        return true;
                    }
                //case SystemConst.CN_KeyValueEnter:
                //    {
                //        //此时外部应该执行获取扫描条码，然后由外部清除条码Buffer
                //        return false;
                //    }
                //case SystemConst.CN_KeyValueEsc:
                //case SystemConst.CN_KeyValueNum0:
                //case SystemConst.CN_KeyValueNum1:
                //case SystemConst.CN_KeyValueNum2:
                //case SystemConst.CN_KeyValueNum3:
                //case SystemConst.CN_KeyValueNum4:
                //case SystemConst.CN_KeyValueNum5:
                //case SystemConst.CN_KeyValueNum6:
                //case SystemConst.CN_KeyValueNum7:
                //case SystemConst.CN_KeyValueNum8:
                //case SystemConst.CN_KeyValueNum9:
                //    {
                //        //其它功能键，会清除条码Buffer
                //        ClearBuffer();
                //        return false;
                //    }
                default:
                    {
                        //0-9，和所有支持功能键之外的值 不处理
                        return false;
                    }
            }
        }

        static StringBuilder _sb = new StringBuilder();

        /// <summary>
        /// 获取条码
        /// </summary>
        /// <returns>输入条码字符串</returns>
        public static string GetBarcode()
        {
            return _sb.ToString();
        }

        /// <summary>
        /// 清除条码缓冲区
        /// </summary>
        public static void ClearBuffer()
        {
            _sb.Clear();
        }

    }
}
