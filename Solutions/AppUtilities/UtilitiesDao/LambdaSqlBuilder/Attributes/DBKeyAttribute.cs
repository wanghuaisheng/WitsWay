using System;

namespace WitsWay.Utilities.Dap.LambdaSqlBuilder.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DbKeyAttribute : Attribute
    {
        public DbKeyAttribute(bool increment)
        {
            Increment = increment;
        }

        public DbKeyAttribute()
            : this(false)
        {

        }
        /// <summary>
        /// 是否是自增
        /// </summary>
        public bool Increment { get; set; }
    }
}
