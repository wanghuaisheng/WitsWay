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
namespace WitsWay.Utilities.Entitys
{
    /// <summary>
    /// 批量插入结果
    /// </summary>
    public struct SqlBulkResult
    {
        /// <summary>
        /// 最大自增Id
        /// </summary>
        public int MaxIdentity { get; set; }
        /// <summary>
        /// 行数
        /// </summary>
        public int RowCount { get; set; }
        /// <summary>
        /// 取得对应索引的Id，从0开始
        /// </summary>
        /// <param name="idx">索引序号</param>
        /// <returns>对应索引的Id，从0开始，不存在则返回-1</returns>
        public int this[int idx] => idx < RowCount ? MaxIdentity - RowCount + 1 + idx : -1;
    }
}