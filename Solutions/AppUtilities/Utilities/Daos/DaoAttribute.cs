/*******************************
 * 2017年3月31日 王怀生 添加
 * ****************************/

using System;

namespace WitsWay.Utilities.Daos
{
    /// <summary>
    /// 数据访问对象标记
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class DaoAttribute : Attribute { }
}