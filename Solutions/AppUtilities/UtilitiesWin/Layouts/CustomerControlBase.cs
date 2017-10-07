using DevExpress.XtraEditors;
using WitsWay.Utilities.Layouts;

namespace WitsWay.Utilities.Win.Layouts
{
    /// <summary>
    /// 用户自定义控件基类
    /// </summary>
    /// <typeparam name="TAdapter"></typeparam>
    public abstract partial class CustomerControlBase<TAdapter> : XtraUserControl, ICustomerUC
        where TAdapter : class, ISelectorAdapter
    {
        /// <summary>
        /// CustomerControlBase
        /// </summary>
        public CustomerControlBase()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Adapter
        /// </summary>
        public ISelectorAdapter AdapterInstance { get; set; }
        /// <summary>
        /// Adapter
        /// </summary>
        public TAdapter Adapter { get { return AdapterInstance as TAdapter; } }
        /// <summary>
        /// 控件名称
        /// </summary>

        public abstract string CustomerControlName { get; }
        /// <summary>
        /// 用户控件的操作结果
        /// </summary>
        /// <param name="customerControlIndex"></param>

        public abstract void GetResult(int customerControlIndex = 0);
        /// <summary>
        /// 显示用户控件信息
        /// </summary>
        /// <param name="customerControlIndex"></param>

        public abstract void BindUC(int customerControlIndex = 0);

    }
}
