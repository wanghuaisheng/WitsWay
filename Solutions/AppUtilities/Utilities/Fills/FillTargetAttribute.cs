using System;

namespace WitsWay.Utilities.Fills
{

    /// <summary>
    /// 填充目标特性
    /// </summary>

    [AttributeUsage(AttributeTargets.Property)]
    public class FillTargetAttribute : Attribute
    {

        /// <summary>
        /// 填充类型
        /// </summary>
        public FillKind Kind { get; private set; }
        /// <summary>
        /// 填充组
        /// </summary>
        public int Group { get; private set; }
        /// <summary>
        /// 填充目标特性
        /// </summary>
        public FillTargetAttribute(FillKind kind) : this(kind, 0) { }

        /// <summary>
        /// 填充目标特性
        /// </summary>
        /// <param name="kind">填充类型</param>
        /// <param name="group">填充组，当出现相同类型多个填充属性时需要设置组</param>
        public FillTargetAttribute(FillKind kind, int group)
        {
            Kind = kind;
            Group = group;
        }

    }

}

