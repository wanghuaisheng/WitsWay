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
