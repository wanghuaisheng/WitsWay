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
using System.Collections.Generic;
using System.Threading;

namespace WitsWay.Utilities.FastReflection.Cache
{

    /// <summary>
    /// FastReflectionCache 缓存基类
    /// </summary>
    /// <typeparam name="TKey">MethodInfo、ConstructorInfo、PropertyInfo、 FieldInfo</typeparam>
    /// <typeparam name="TValue">Invoker 或 Accessor对象</typeparam>
    public abstract class FastReflectionCache<TKey, TValue> : IFastReflectionCache<TKey, TValue>
    {
        private Dictionary<TKey, TValue> cache = new Dictionary<TKey, TValue>();
        private ReaderWriterLockSlim rwLock = new ReaderWriterLockSlim();

        /// <summary>
        /// 获取缓存的Invoker 或 Accessor对象
        /// </summary>
        /// <param name="key">MethodInfo、ConstructorInfo、PropertyInfo、 FieldInfo</param>
        /// <returns>Invoker 或 Accessor对象</returns>
        public TValue Get(TKey key)
        {
            var value = default(TValue);
            try
            {
                rwLock.EnterUpgradeableReadLock();
                var cacheHit = cache.TryGetValue(key, out value);
                if (cacheHit) return value;
                rwLock.EnterWriteLock();
                if (!cache.TryGetValue(key, out value))
                {
                    value = Create(key);
                    cache[key] = value;
                }
            }
            finally
            {
                if (rwLock.IsUpgradeableReadLockHeld)
                {
                    rwLock.ExitUpgradeableReadLock();
                }
                if (rwLock.IsWriteLockHeld)
                {
                    rwLock.ExitWriteLock();
                }
            }
            return value;
        }

        /// <summary>
        /// 执行真正的 Invoker 或 Accessor对象创建
        /// 需在子类中实现具体创建逻辑
        /// </summary>
        /// <param name="key">MethodInfo、ConstructorInfo、PropertyInfo、 FieldInfo</param>
        /// <returns> Invoker 或 Accessor对象</returns>
        protected abstract TValue Create(TKey key);
    }
}
