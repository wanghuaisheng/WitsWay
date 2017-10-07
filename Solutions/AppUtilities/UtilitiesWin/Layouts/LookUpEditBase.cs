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
