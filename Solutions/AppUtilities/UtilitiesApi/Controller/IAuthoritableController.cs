using WitsWay.Utilities.Models;

namespace WitsWay.Utilities.Apis.Controller
{
    /// <summary>
    /// 可验证的控制器
    /// </summary>
    public interface IAuthoritableController
    {
        /// <summary>
        /// 用户票据信息
        /// </summary>
        LoginResult UserLoginTicket { get; }

        /// <summary>
        /// 是否拥有所有指定权限
        /// </summary>
        /// <param name="permissions"></param>
        /// <returns></returns>
        bool HasAllPermission(int[] permissions);


        /// <summary>
        /// 是否拥有指定权限的一个或多个
        /// </summary>
        /// <param name="permissions"></param>
        /// <returns></returns>
        bool HasAnyPermission(int[] permissions);
        /// <summary>
        /// 是否拥有权限
        /// </summary>
        /// <param name="permission"></param>
        /// <returns></returns>
        bool HasPermission(int permission);
    }
}
