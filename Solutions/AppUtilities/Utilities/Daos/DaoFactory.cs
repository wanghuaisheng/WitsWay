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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using WitsWay.Utilities.Errors;
using WitsWay.Utilities.Extends;
using WitsWay.Utilities.Helpers;
using WitsWay.Utilities.Thread;

namespace WitsWay.Utilities.Daos
{
    /// <summary>
    /// 数据访问对象工厂
    /// </summary>
    public class DaoFactory
    {
        /// <summary>
        /// IDao->Dao
        /// </summary>
        private static readonly Dictionary<string, Dictionary<Type, Type>> DaoTypeDic = new Dictionary<string, Dictionary<Type, Type>>();
        /// <summary>
        /// 锁对象
        /// </summary>
        private static readonly LockObject Locker = new LockObject();

        /// <summary>
        /// 取得数据访问对象
        /// </summary>
        /// <typeparam name="T">数据访问对象接口类型</typeparam>
        /// <returns>接口实例</returns>
        public static T GetDao<T>()
        {
            var daoFiles = AppSettingHelper.GetValue(UtilityConsts.DaoAppSettingKey);
            if (string.IsNullOrWhiteSpace(daoFiles.Trim()))
            {
                ExceptionHelper.ThrowProgramException(UtilityErrors.AppConfigAppSettingsMiss, UtilityConsts.DaoAppSettingKey);
            }
            return GetDao<T>(daoFiles);
        }

        /// <summary>
        /// 取得数据访问对象
        /// </summary>
        /// <typeparam name="T">数据访问对象接口类型</typeparam>
        /// <param name="dll">数据访问层实例DLL名称</param>
        /// <returns>接口实例</returns>
        public static T GetDao<T>(string dll)
        {
            if (string.IsNullOrWhiteSpace(dll)) return default(T);
            if (!DaoTypeDic.ContainsKey(dll))
            {
                Locker.LockExecute(() => InitDlls(dll));
            }
            var dic = DaoTypeDic[dll];
            var t = typeof(T);
            if (!dic.ContainsKey(t))
            {
                ExceptionHelper.ThrowProgramException(UtilityErrors.DaoNotExist, t.FullName);
            }
            try
            {
                return (T)dic[t].GetInstance();
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                ExceptionHelper.ThrowProgramException(UtilityErrors.DaoCreateErrorFormat, t.FullName);
            }
            return default(T);
        }

        /// <summary>
        /// 数据访问对象工厂
        /// </summary>
        private static void InitDlls(string dlls)
        {
            var dllArray = dlls.SplitToList<string>();
            var dic = new Dictionary<Type, Type>();
            dllArray.SafeForEach(dll => InitDll(dll, dic));
            DaoTypeDic[dlls] = dic;
        }

        /// <summary>
        /// 数据访问对象工厂
        /// </summary>
        private static void InitDll(string dll, IDictionary<Type, Type> dic)
        {
            Type[] types = null;
            try
            {
                types = Assembly.Load(dll).GetTypes();
            }
            catch
            {
                ExceptionHelper.ThrowProgramException(UtilityErrors.DaoDllFileLoadFail, dll);
            }
            if (types == null || !types.Any()) return;
            types.SafeForEach(type =>
            {
                var attr = type.GetAttribute<DaoAttribute>();
                if (attr == null) return;
                var idaoType =
                    type.GetInterfaces().FirstOrDefault(face => face.GetAttribute<IDaoAttribute>() != null);
                if (idaoType == null) return;
                dic[idaoType] = type;
            });
        }
    }
}
