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
using System.Collections.Generic;

namespace WitsWay.Utilities.Supports.GridSupport
{

    /// <summary>
    /// Grid表格支持
    /// </summary>
    public static class GridSupportExtends
    {
        /// <summary>
        /// 初始化行号
        /// </summary>
        /// <param name="dataList">数据列表</param>
        public static List<T> InitRowNo<T>(this List<T> dataList) where T : GridSupport<T>
        {
            if (dataList == null || dataList.Count <= 0) return new List<T>();
            var rowNo = 1;
            dataList.ForEach(data => ((IGridSupport)data).GridRowNo = rowNo++);
            return dataList;
        }

        /// <summary>
        /// 初始化序号
        /// </summary>
        /// <param name="dataList">数据列表</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">页大小</param>
        public static List<T> InitDataNo<T>(List<T> dataList, int pageIndex, int pageSize) where T : GridSupport<T>
        {
            if (dataList == null || dataList.Count <= 0) return new List<T>();
            var rowNo = (pageIndex - 1) * pageSize + 1;
            dataList.ForEach(data => ((IGridSupport)data).GridDataNo = rowNo++);
            return dataList;
        }

    }
}

