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
    /// 分页存储过程要用的参数
    /// </summary>
    public class PageParameterModel
    {
        /// <summary>
        /// 表名
        /// </summary>
        public string TableName { get; set; }
        /// <summary>
        /// 要返回的字段
        /// </summary>
        public string Fields { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public string OrderFields { get; set; }
        /// <summary>
        /// 页大小
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 当前页
        /// </summary>
        public int PageIndex { get; set; }
        /// <summary>
        /// 条件
        /// </summary>
        public string Where { get; set; }
    }
}