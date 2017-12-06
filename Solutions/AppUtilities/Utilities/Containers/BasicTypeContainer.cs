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
using System.Collections.Concurrent;
using System.Configuration;
using System.Linq;
using System.Reflection;
using WitsWay.Utilities.Extends;
using WitsWay.Utilities.Thread;

namespace WitsWay.Utilities.Containers
{
    /// <summary>
    /// 基础类型容器
    /// </summary>
    public class BasicTypeContainer
    {

        /// <summary>
        /// 类型全名→类型
        /// </summary>
        protected static readonly ConcurrentDictionary<string, Type> FullNameTypeDic = new ConcurrentDictionary<string, Type>();
        /// <summary>
        /// 类型全名→类型
        /// </summary>
        protected static readonly ConcurrentDictionary<string, Type> FullNamePropertyTypeDic = new ConcurrentDictionary<string, Type>();

        /// <summary>
        /// AppConfig中数据访问Dll名称配置
        /// </summary>
        private const string DllConfigKey = UtilityConsts.LoadDllsAppSettingKey;
        /// <summary>
        /// 排除查找的DLL
        /// </summary>
        private static readonly string[] ExcludeDlls = { "mscorlib,", "mscorlib.", "System,", "System.", "Microsoft.", "vshost32,", "Newtonsoft.", "UIAutomationClient,", "SMDiagnostics,", "Anonymously Hosted DynamicMethods Assembly,", "", "ExpressMapper," };// "DevExpress."
        /// <summary>
        /// 锁对象
        /// </summary>
        private static readonly LockObject Locker = new LockObject();

        /// <summary>
        /// 获取类型
        /// </summary>
        /// <param name="fullName">类型全名</param>
        /// <returns>类型</returns>
        public static Type GetTypeByName(string fullName)
        {
            if (FullNameTypeDic.ContainsKey(fullName))
                return FullNameTypeDic[fullName];
            Locker.LockExecute(() =>
            {
                var daoFiles = ConfigurationManager.AppSettings[DllConfigKey];
                if (!string.IsNullOrWhiteSpace(daoFiles))
                {
                    var dllArray = daoFiles.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    dllArray.SafeForEach(dll => Assembly.Load(dll));
                }
                var assemblies = AppDomain.CurrentDomain.GetAssemblies();
                foreach (var ass in assemblies)
                {
                    var assName = ass.FullName;
                    if (!ExcludeDlls.Any(ex => assName.StartsWith(ex))) continue;
                    var t = ass.GetType(fullName);
                    if (t == null) continue;
                    FullNameTypeDic[fullName] = t;
                    break;
                }
            });
            return FullNameTypeDic.ContainsKey(fullName) ? FullNameTypeDic[fullName] : null;
        }
        /// <summary>
        /// 根据父类取type
        /// </summary>
        /// <param name="baseType">父类</param>
        /// <param name="propertyName">属性名称</param>
        /// <param name="propertyValue">属性值</param>
        /// <returns>类型</returns>
        public static Type GetTypeByBaseType(Type baseType, string propertyName, object propertyValue)
        {
            Type result = null;
            if (baseType == null || propertyValue == null || string.IsNullOrEmpty(propertyName)) return null;
            Locker.LockExecute(() =>
            {
                var daoFiles = ConfigurationManager.AppSettings[DllConfigKey];
                if (!string.IsNullOrWhiteSpace(daoFiles))
                {
                    var dllArray = daoFiles.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    dllArray.SafeForEach(dll => Assembly.Load(dll));
                }
                var assemblies = AppDomain.CurrentDomain.GetAssemblies();
                foreach (var ass in assemblies)
                {
                    var assName = ass.FullName;
                    if (!ExcludeDlls.Any(ex => assName.StartsWith(ex))) continue;
                    foreach (var type in ass.GetTypes())
                    {
                        if (string.IsNullOrEmpty(type.BaseType?.FullName) || !type.BaseType.FullName.Equals(baseType.FullName)) continue;
                        var propertyInfo = type.GetProperty(propertyName);
                        if (propertyInfo == null) continue;
                        if (propertyValue != propertyInfo.GetValue(type.GetInstance())) continue;
                        result = type;
                        break;
                    }
                    if (result != null)
                        break;
                }
            });
            return result;
        }
        /// <summary>
        /// 根据接口取type
        /// </summary>
        /// <param name="interfaceType">父类</param>
        /// <param name="propertyName">属性名称</param>
        /// <param name="propertyValue">属性值</param>
        /// <returns>类型</returns>
        public static Type GetTypeByInterfaceType(Type interfaceType, string propertyName, string propertyValue)
        {
            Type result = null;
            if (interfaceType == null || propertyValue == null || string.IsNullOrEmpty(propertyName)) return null;
            Locker.LockExecute(() =>
            {
                var daoFiles = ConfigurationManager.AppSettings[DllConfigKey];
                if (!string.IsNullOrWhiteSpace(daoFiles))
                {
                    var dllArray = daoFiles.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    dllArray.SafeForEach(dll => Assembly.Load(dll));
                }
                var assemblies = AppDomain.CurrentDomain.GetAssemblies();
                foreach (var ass in assemblies)
                {
                    var assName = ass.FullName;
                    if (!ExcludeDlls.Any(ex => assName.StartsWith(ex))) continue;
                    foreach (var type in ass.GetTypes())
                    {
                        var interf = type.GetInterface(interfaceType.Name);
                        if (interf == null) continue;
                        var propertyInfo = type.GetProperty(propertyName);
                        if (propertyInfo == null) continue;
                        if (!propertyValue.Equals(propertyInfo.GetValue(type.GetInstance()))) continue;
                        result = type;
                        break;
                    }
                    if (result != null)
                        break;
                }
            });
            return result;
        }
    }
}
