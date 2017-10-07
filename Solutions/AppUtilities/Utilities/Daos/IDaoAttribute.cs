/*******************************
 * 2017年3月31日 王怀生 添加
 * ****************************/

using System;

namespace WitsWay.Utilities.Daos
{
    /// <summary>
    /// 数据访问接口标记
    /// </summary>
    [AttributeUsage(AttributeTargets.Interface)]
    public class IDaoAttribute : Attribute { }
}