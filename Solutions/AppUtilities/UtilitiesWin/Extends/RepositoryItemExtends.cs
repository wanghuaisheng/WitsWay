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
using DevExpress.XtraEditors.Repository;

namespace WitsWay.Utilities.Win.Extends
{
    /// <summary>
    /// XtraGrid辅助类
    /// </summary>
    public static class RepositoryItemExtends
    {

        /// <summary>
        /// 自动高度
        /// </summary>
        /// <param name="memoItem">表格控件</param>
        /// <param name="autoHeight">是否自动行高度，默认true</param>
        public static void AutoHeight(this RepositoryItemMemoEdit memoItem, bool autoHeight = true)
        {
            memoItem.LinesCount = autoHeight ? 0 : 1;
        }

        /// <summary>
        /// 自动高度
        /// </summary>
        /// <param name="pictureItem">表格控件</param>
        public static void AutoHeight(this RepositoryItemPictureEdit pictureItem)
        {
            pictureItem.CustomHeight = 0;
        }

        /// <summary>
        /// 自动高度
        /// </summary>
        /// <param name="pictureItem">表格控件</param>
        /// <param name="height">图片高度</param>
        public static void PictureHeight(this RepositoryItemPictureEdit pictureItem,int height)
        {
            pictureItem.CustomHeight = height;
        }

    }
}
