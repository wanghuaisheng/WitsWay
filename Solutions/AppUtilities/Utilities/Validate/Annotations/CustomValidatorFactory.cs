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
using System.Configuration;
using System.Linq;
using System.Reflection;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using WitsWay.Utilities.Errors;
using WitsWay.Utilities.Extends;
using WitsWay.Utilities.Helpers;
using WitsWay.Utilities.Thread;

namespace WitsWay.Utilities.Validate.Annotations
{
    /// <summary>
    /// 自定义验证器工厂
    /// </summary>
    public class CustomValidatorFactory
    {
        /// <summary>
        /// 自定义验证器 键->类型
        /// </summary>
        private static readonly Dictionary<string, Type> ValidatorKeyTypeDic = new Dictionary<string, Type>();
        /// <summary>
        /// AppConfig中自定义验证器Dll名称配置
        /// </summary>
        private const string CustomValidatorDllsConfigKey = UtilityConsts.CustomValidatorDllKey;

        /// <summary>
        /// 锁对象
        /// </summary>
        private static readonly LockObject Locker = new LockObject();

        /// <summary>
        /// 取得自定义验证器对象
        /// </summary>
        /// <param name="key">验证器键</param>
        /// <returns>自定义验证器接口实例</returns>
        public static ICustomValidator GetCustomValidator(string key)
        {
            if (!ValidatorKeyTypeDic.Any())
            {
                Locker.LockExecute(InitDlls);
            }
            if(!ValidatorKeyTypeDic.ContainsKey(key))
                ExceptionHelper.ThrowProgramException(UtilityErrors.NotExistCustomValidatorWithKey,key);
            var t = ValidatorKeyTypeDic[key];
            try
            {
                return (ICustomValidator)t.GetInstance();
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                ExceptionHelper.ThrowProgramException(UtilityErrors.DaoCreateErrorFormat, t.FullName);
            }
            return null;
        }

        /// <summary>
        /// 读取Dll中的自定义验证器
        /// </summary>
        private static void InitDlls()
        {
            var validatorFiles = ConfigurationManager.AppSettings[CustomValidatorDllsConfigKey];
            if (string.IsNullOrWhiteSpace(validatorFiles.Trim()))
            {
                ExceptionHelper.ThrowProgramException(UtilityErrors.AppConfigAppSettingsMiss, CustomValidatorDllsConfigKey);
            }
            var dllArray = validatorFiles.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            dllArray.SafeForEach(InitDll);
        }

        /// <summary>
        /// 读取Dll中的自定义验证器
        /// </summary>
        private static void InitDll(string dll)
        {
            Type[] types = null;
            try
            {
                types = Assembly.Load(dll).GetTypes();
            }
            catch
            {
                ExceptionHelper.ThrowProgramException(UtilityErrors.CustomValidatorDllFileLoadFail, dll);
            }
            if (types == null || !types.Any()) return;
            types.SafeForEach(type =>
            {
                if (!typeof (ICustomValidator).IsAssignableFrom(type)) return;
                var validator = (ICustomValidator)type.GetInstance();
                if (validator == null) return;
                if(ValidatorKeyTypeDic.ContainsKey(validator.Key))
                    ExceptionHelper.ThrowProgramException(UtilityErrors.CustomValidatorHaveDuplicateKey,validator.Key);
                ValidatorKeyTypeDic[validator.Key] = type;
            });
        }
    }
}
