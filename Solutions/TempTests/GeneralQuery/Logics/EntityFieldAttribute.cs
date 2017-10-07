using System;

namespace GeneralQuery.Logics
{
    /// <summary>
    /// 把枚举值按照指定的文本显示
    /// <example>
    /// EnumDescription.GetEnumText(typeof(MyEnum));
    /// EnumDescription.GetFieldText(MyEnum.EnumField);
    /// EnumDescription.GetFieldInfos(typeof(MyEnum));  
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
