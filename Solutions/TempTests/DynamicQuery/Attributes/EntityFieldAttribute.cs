using System;

namespace WitsWay.TempTests.DynamicQuery.Attributes
{
    /// <summary>
    /// 把枚举值按照指定的文本显示
    /// <example>
    /// EnumField.GetEnumText(typeof(MyEnum));
    /// EnumField.GetFieldText(MyEnum.EnumField);
    /// EnumField.GetFieldInfos(typeof(MyEnum));  
    /// </example>
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class EntityFieldAttribute : Attribute
    {

        public EntityFieldAttribute(string title)
        {
            Title = title;
        }

        /// <summary>
        /// 字段描述标题
        /// </summary>
        public string Title { get; set; }

    }
}
