using System;

namespace Dapper.LambdaExtension.LambdaSqlBuilder.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ZPKeyAttribute : Attribute
    {
        public ZPKeyAttribute(bool increment)
        {
            this.Increment = increment;
        }

        public ZPKeyAttribute()
            : this(false)
        {

        }
        /// <summary>
        /// 是否是自增
        /// </summary>
        public bool Increment { get; set; }
    }
}
