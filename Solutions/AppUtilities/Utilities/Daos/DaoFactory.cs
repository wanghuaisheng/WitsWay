/*******************************
 * 2017年3月31日 王怀生 添加
 * ****************************/

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
