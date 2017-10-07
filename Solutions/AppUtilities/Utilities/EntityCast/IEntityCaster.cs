using System.Collections.Generic;
using WitsWay.Utilities.Entitys;

namespace WitsWay.Utilities.EntityCast
{
    /// <summary>
    /// 实体转换器
    /// </summary>
    /// <typeparam name="A">原类型</typeparam>
    /// <typeparam name="B">新类型</typeparam>
    public interface IEntityCaster<A, B>
        where A : new()
        where B : new()
    {

        /// <summary>
        /// 转换实体
        /// </summary>
        /// <param name="a">原实体</param>
        /// <returns>新实体</returns>
        B CastEntity(A a);

        /// <summary>
        /// 转换列表
        /// </summary>
        /// <param name="aList">A对象列表</param>
        /// <returns>B对象列表</returns>
        List<B> CastList(IList<A> aList);

        /// <summary>
        /// 转换页
        /// </summary>
        /// <param name="aPage">A分页信息</param>
        /// <returns>B分页信息</returns>
        PageResult<B> CastPage(PageResult<A> aPage);

    }
}
