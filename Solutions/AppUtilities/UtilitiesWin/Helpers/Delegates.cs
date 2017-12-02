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
using System.Drawing;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Base.ViewInfo;
using WitsWay.Utilities.Supports;

namespace WitsWay.Utilities.Win.Helpers
{

    /// <summary>
    /// 有 HitInfo 和 模型两个参数的谓词委托
    /// </summary>
    /// <typeparam name="T">模型类型</typeparam>
    /// <param name="model">模型</param>
    /// <param name="columnView"><see cref="ColumnView"/>当前View</param>
    /// <param name="hitInfo"><see cref="BaseHitInfo"/>信息</param>
    /// <returns>是否通过</returns>
    public delegate bool BaseHitInfoModelPredicate<T>(ColumnView columnView, BaseHitInfo hitInfo, T model) where T : class, IKey;

}
