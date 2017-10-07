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
using System.Data;

namespace WitsWay.Utilities.Extends
{
    /// <summary>
    /// DataRow扩展方法
    /// </summary>
    public static class DataRowExtends
    {
        /// <summary>
        /// 字段是否为空或者不存在
        /// </summary>
        /// <param name="dr">数据源</param>
        /// <param name="fieldName">字段名称</param>
        /// <returns>不存在或者为Null返回true。</returns>
        public static bool FieldIsNullOrNotExist(this DataRow dr, string fieldName)
        {
            if (dr.Table.Columns.Contains(fieldName) && dr[fieldName] != DBNull.Value)
                return false;
            return true;
        }
    }
}
