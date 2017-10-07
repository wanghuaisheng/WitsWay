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
using WitsWay.Utilities.Patterns;
using WitsWay.Utilities.Services;

namespace WitsWay.Utilities.Win
{
    /// <summary>
    /// 服务调用者
    /// <para>
    /// 调用方式<![CDATA[ var pages = ServiceCaller.GetService<IPageItemService>().Call(s => s.GetAll());]]>
    /// </para>
    /// </summary>
    public class ServiceCaller : MsDispose
    {
        /// <summary>
        /// 获取服务
        /// </summary>
        /// <typeparam name="TService">服务类型</typeparam>
        /// <returns>服务接口实例</returns>
        public static ServiceAdapter<TService> GetService<TService>() where TService : class, IService
        {
            var caller = new ServiceAdapter<TService>();
            return caller;
        }
    }

}