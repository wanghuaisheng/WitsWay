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

namespace WitsWay.Utilities.Patterns
{
    /// <summary>
    /// 在继承关系的基类中使用该模式
    /// </summary>
    public class MsDispose : IDisposable
    {
        private bool _disposed;
        /// <summary>
        /// 手动调用显示终结
        /// </summary>
        public void Dispose()
        {
            Close();
        }
        /// <summary>
        /// 释放非托管资源
        /// 向GC标示托管资源可回收
        /// </summary>
        public void Close()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 系统回收
        /// </summary>
        ~MsDispose()
        {
            Dispose(false);
        }
        /// <summary>
        /// 清理非托管资源
        /// </summary>
        /// <param name="disposing">Should be true when calling from Dispose().</param>
        public void Dispose(bool disposing)
        {
            // 允许多次调用Dispose方法
            //但不多次处理 
            if (_disposed) return;
            lock (this)
            {
                if (disposing)
                {
                    // 这里表示程序正在显示地调用Dispose方法
                    // 可以使用引用了其他对象的域
                    // 因为它们所引用的对象的Finalize方法还没有被调用
                    ReleaseUnManagedResource();
                }
            }
            _disposed = true;
        }

        /// <summary>
        /// 在子类中重写
        /// 以释放非托管资源
        /// </summary>
        public virtual void ReleaseUnManagedResource() { }

    }
}
