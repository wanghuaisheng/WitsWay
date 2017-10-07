#region License(Apache Version 2.0)
/******************************************
 * Copyright ®2017-Now WangHuaiSheng.
 * Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file
 * except in compliance with the License. You may obtain a copy of the License at
 * http://www.apache.org/licenses/LICENSE-2.0
 * Unless required by applicable law or agreed to in writing, software distributed under the
 * License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
 * either express or implied. See the License for the specific language governing permissions
 * and limitations under the License.
 * Detail: https://github.com/WangHuaiSheng/WitsWay/LICENSE
 * ***************************************/
#endregion 
#region ChangeLog
/******************************************
 * 2017-10-7 OutMan Create
 * 
 * ***************************************/
#endregion
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
