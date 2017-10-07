using System;

namespace WitsWay.Utilities.Layouts
{
    /// <summary>
    /// 用于区分实体是否要实现FormLayout布局
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class FormLayoutModelAttribute : Attribute { }
}
