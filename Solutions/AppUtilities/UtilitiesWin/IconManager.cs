/******************************************
 * 2012年7月21日 王怀生 添加
 * 
 * ***************************************/

using System.Drawing;
using WitsWay.Utilities.Win.Properties;

namespace WitsWay.Utilities.Win
{
    /// <summary>
    /// 图标管理
    /// </summary>
    public class IconManager
    {

        /// <summary>
        /// 取得Icon
        /// </summary>
        public static Image GetIcon(IconKey key)
        {
            var iconName = key.ToString();
            return Resources.ResourceManager.GetObject(iconName) as Image;
        }

        /// <summary>
        /// 取得Icon
        /// </summary>
        public static Image GetIcon(string key)
        {
            return Resources.ResourceManager.GetObject(key) as Image;
        }
        /// <summary>
        /// 取得Icon
        /// </summary>
        public static Image GetContractItemIcon(ContractItemIconKey key)
        {
            return GetIcon(key.ToString());
        }

    }
}
