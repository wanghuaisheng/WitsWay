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
using DevExpress.XtraEditors;

namespace WitsWay.Utilities.Win.Helpers
{
    /// <summary>
    /// SpinEdit控件辅助类
    /// </summary>
    public static class SpinEditHelper
    {
        /// <summary>
        /// 设置SpinEdit样式
        /// </summary>
        /// <param name="spin">spin控件</param>
        /// <param name="minValue">最小值</param>
        /// <param name="maxValue">最大值</param>
        public static void SetSpinEditStyle(SpinEdit spin, bool isFloat, decimal minValue = 0, decimal maxValue = 0)
        {
            spin.Properties.MinValue = minValue;
            spin.Properties.IsFloatValue = false;
            spin.Properties.MaxValue = maxValue;
        }

        /// <summary>
        /// 设置SpinEdit样式
        /// </summary>
        /// <param name="spin">spin控件</param>
        /// <param name="decimalDigits">小数位数</param>
        /// <param name="minValue">最小值</param>
        /// <param name="maxValue">最大值</param>
        public static void SetSpinEditStyle(SpinEdit spin, int decimalDigits, decimal minValue = 0, decimal maxValue = 0)
        {
            spin.Properties.MinValue = minValue;
            spin.Properties.MaxValue = maxValue;
            spin.Properties.IsFloatValue = true;
            spin.Properties.Mask.EditMask = ("f" + decimalDigits);
            spin.Properties.Mask.UseMaskAsDisplayFormat = true;
        }

    }
}