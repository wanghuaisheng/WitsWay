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
using WitsWay.Utilities.Layouts;

namespace WitsWay.Utilities.Win.Layouts
{
    /// <summary>
    /// LookUpEdit
    /// </summary>
    /// <typeparam name="TAdapter"></typeparam>
    public abstract class LookUpEditBase<TAdapter> : LookUpEdit, ICustomerUC
         where TAdapter : class, ISelectorAdapter
    {
        /// <summary>
        /// Adapter
        /// </summary>
        public ISelectorAdapter AdapterInstance { get; set; }
        /// <summary>
        /// 模型
        /// </summary>
        public TAdapter Adapter { get { return AdapterInstance as TAdapter; } }
        /// <summary>
        /// 控件名称
        /// </summary>

        public abstract string CustomerControlName { get; }
        /// <summary>
        /// 取控件里面的结果
        /// </summary>
        /// <param name="customerControlIndex"></param>

        public abstract void GetResult(int customerControlIndex = 0);
        /// <summary>
        /// 显示控件里的数据
        /// </summary>
        /// <param name="customerControlIndex"></param>

        public abstract void BindUC(int customerControlIndex = 0);

    }
}
