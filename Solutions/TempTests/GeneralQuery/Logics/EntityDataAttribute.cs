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
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class EntityDataAttribute : Attribute
    {

        public EntityDataAttribute(string title)
        {
            Title = title;
        }

        public string Title { get; set; }
    }
}
