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
namespace WitsWay.Utilities.Validate.Validators
{
    /// <summary>
    /// 系统目前支持的最大额度
    /// </summary>
    public class ValidatorMaxPrice
    {
        /// <summary>
        /// 最大额度
        /// </summary>
        public const decimal MaxPrice = 1000000000;

        /// <summary>
        /// 账户维护支持的最大金额
        /// </summary>
        public const decimal Fin_MaxPrice = 99999999;

        /// <summary>
        /// 验证金额是否超过1000000000
        /// </summary>
        /// <param name="price">总金额</param>
        public static bool ValidatorPrice(decimal price)
        {
            if (price > MaxPrice)
                return false;
            return true;
        }
    }
}
