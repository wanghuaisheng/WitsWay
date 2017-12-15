using System;

namespace WitsWay.Utilities.Dap.LambdaSqlBuilder.Attributes
{

    [AttributeUsage(AttributeTargets.Property)]
    public class DbIndexAttribute:Attribute
    {
        /// <summary>
        /// 索引名称
        /// </summary>
        public string IndexName { get; set; }

        /// <summary>
        /// 是否唯一索引
        /// </summary>
        public bool Unique { get; set; }

        /// <summary>
        /// 索引排序
        /// </summary>
        public bool Asc { get; set; }

        public DbIndexAttribute(string indexName="",bool asc=true,bool unique=false)
        {
            IndexName = indexName;
            Unique = unique;
            Asc = asc;
        }
    }
}
