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
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CollectionSelect<T>
    {
        private readonly IEnumerable<T> _list;
        private readonly string _sourceAlias;
        private readonly string _targetAlias;
        private readonly BulkOperations _bop;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <param name="sourceAlias"></param>
        /// <param name="targetAlias"></param>
        /// <param name="bop"></param>
        public CollectionSelect(IEnumerable<T> list, string sourceAlias, string targetAlias, BulkOperations bop)
        {
            _list = list;
            _sourceAlias = sourceAlias;
            _targetAlias = targetAlias;
            _bop = bop;
        }

        /// <summary>
        /// Set the name of table for operation to take place. Registering a table is Required.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <returns></returns>
        public Table<T> WithTable(string tableName)
        {
            return new Table<T>(_list, tableName, _sourceAlias, _targetAlias, _bop);
        }
    }
}
