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

namespace WitsWay.Utilities.SqlBulks
{
    /// <summary>
    /// 批量操作组装器
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    public class Setup<T>
    {
        private readonly string _sourceAlias;
        private readonly string _targetAlias;
        private readonly BulkOperations _bop;

        /// <summary>
        /// 批量操作组装器
        /// </summary>
        /// <param name="sourceAlias"></param>
        /// <param name="targetAlias"></param>
        /// <param name="bop"></param>
        public Setup(string sourceAlias, string targetAlias, BulkOperations bop)
        {
            _sourceAlias = sourceAlias;
            _targetAlias = targetAlias;
            _bop = bop;
        }

        /// <summary>
        /// Represents the collection of objects to be inserted/upserted/updated/deleted (configured in next steps). 
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public CollectionSelect<T> ForCollection(IEnumerable<T> list)
        {
            return new CollectionSelect<T>(list, _sourceAlias, _targetAlias, _bop);
        }
    }
}
