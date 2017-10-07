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
