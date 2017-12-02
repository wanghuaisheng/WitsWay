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

namespace WitsWay.Utilities.Entitys
{
    /// <summary>
    /// ID-Text-Data，用于Combo绑定
    /// </summary>
    public class IdTextData
    {

        /// <summary>
        /// ID
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 显示文字
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <returns></returns>
        public T GetData<T>() where T : class
        {
            return Data as T;
        }

        /// <summary>
        /// ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Text;
        }

        /// <summary>
        /// GetTypeCode
        /// </summary>
        /// <returns><see cref="TypeCode"/></returns>
        public TypeCode GetTypeCode()
        {
            return TypeCode.String;
        }

    }
}
