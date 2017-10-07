///*修改日志
// * 2012年7月21日   王怀生     添加
// * 2013年5月14日   邓千军     修改   增加enable选项
// * */

//using System.Drawing;
//using System.Windows.Forms;
//using DevExpress.Utils;
//using DevExpress.XtraEditors;
//using DevExpress.XtraEditors.Controls;
//using DevExpress.XtraEditors.Repository;

//namespace SmartSolution.Utilities.Win.Helpers
//{
//    public partial class XtraGridHelper
//    {
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="caption"></param>
//        /// <param name="tooltip"></param>
//        /// <param name="ctrName"></param>
//        /// <param name="icon"></param>
//        /// <returns></returns>
//        public static RepositoryItemButtonEdit GetRepositoryButton(string caption, string tooltip, string ctrName, Image icon)
//        {
//            return GetRepositoryButton(caption, tooltip, ctrName, icon, true);
//        }
//        /// <summary>
//        /// 获取XtraGrid按钮
//        /// </summary>
//        /// <param name="caption">标题</param>
//        /// <param name="tooltip">提示</param>
//        /// <param name="ctrName">控件名</param>
//        /// <param name="icon">控件图标</param>
//        /// <param name="enable">控件是否可用</param>
//        /// <returns></returns>
//        public static RepositoryItemButtonEdit GetRepositoryButton(string caption, string tooltip, string ctrName, Image icon, bool enable)
//        {
//            var editor = new RepositoryItemButtonEdit();
//            editor.Buttons.Clear();
//            editor.AutoHeight = false;
//            var apperenceObj = new SerializableAppearanceObject();
//            apperenceObj.Options.UseTextOptions = true;
//            apperenceObj.TextOptions.HAlignment = HorzAlignment.Center;
//            editor.Buttons.AddRange(new[] {
//                    new EditorButton(ButtonPredefines.Glyph, caption, -1, enable, true, false, ImageLocation.MiddleLeft,icon, new KeyShortcut(Keys.None), apperenceObj, tooltip, null, null, true)});
//            editor.Name = ctrName;
//            editor.TextEditStyle = TextEditStyles.HideTextEditor;
//            return editor;
//        }
//    }
//}