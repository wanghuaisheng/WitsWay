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
namespace WitsWay.Utilities.Supports.GridSupport
{
    /// <summary>
    /// 行号/序号
    /// </summary>
    public interface IGridSupport
    {
        /// <summary>
        /// 行ID
        /// </summary>
        string GridRowId { get; }
        /// <summary>
        /// 行号
        /// </summary>
        int GridRowNo { get; set; }
        /// <summary>
        /// 序号
        /// </summary>
        int GridDataNo { get; set; }
    }
}
