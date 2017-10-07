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

namespace WitsWay.Utilities.Supports
{
    /// <summary>
    /// IKey接口对象相等比较器
    /// </summary>
    /// <typeparam name="T">实现IKey的类型</typeparam>
    public class KeyEqualityComparer<T> : EqualityComparer<T> where T : IKey
    {

        /// <summary>
        /// 相等比较
        /// </summary>
        public override bool Equals(T x, T y)
        {
            var xKey = x as IKey;
            var yKey = y as IKey;
            return xKey != null && yKey != null && !string.IsNullOrEmpty(xKey.Key) && !string.IsNullOrEmpty(yKey.Key) && xKey.Key.Equals(yKey);
        }

        /// <summary>
        /// 取得对象HashCode
        /// </summary>
        public override int GetHashCode(T obj)
        {
            return obj.GetHashCode();
        }
    }

    /// <summary>
    /// Key相等比较器
    /// </summary>
    public class KeyEqualityComparer : IEqualityComparer<IKey>
    {
        /// <summary>
        /// 默认比较器实例
        /// </summary>
        public static readonly KeyEqualityComparer Default = new KeyEqualityComparer();

        /// <summary>
        /// 确定指定的对象是否相等
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool Equals(IKey x, IKey y)
        {
            if (x == null && y == null)
                return true;

            return x != null && y != null && x.Key == y.Key;
        }

        /// <summary>
        /// 返回指定对象的哈希代码
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int GetHashCode(IKey obj)
        {
            if (obj == null || obj.Key == null)
                return 0;
            return obj.Key.GetHashCode();
        }
    }

}
