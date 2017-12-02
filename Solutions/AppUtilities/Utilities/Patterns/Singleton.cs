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
namespace WitsWay.Utilities.Patterns
{
        /// <summary>
        /// 
        /// 线程安全的 Singleton 模式最佳实践
        /// 
        /// 例子:
        /// 
        /// public class Demo
        /// {
        ///		public static Form1 Instance1
        ///		{
        ///			get
        ///			{
        ///				return Singleton＜Form1＞.Instance;
        ///			}
        ///		}
        ///	}
        /// </summary>
        public sealed class Singleton<T> where T : new()
        {
            private Singleton()
            {
            }
            /// <summary>
            /// 
            /// </summary>
            public static T Instance => Nested.instance;

            private class Nested
            {
                static Nested(){}
                internal static readonly T instance = new T();
            }
        }
}
