namespace WitsWay.Utilities.Layouts
{
    /// <summary>
    /// 用户自定义控件公用接口
    /// </summary>
    public interface ICustomerUC
    {
        /// <summary>
        /// Adapter
        /// </summary>
        ISelectorAdapter AdapterInstance { get; set; }

        /// <summary>
        /// 控件名称
        /// </summary>
        string CustomerControlName { get; }
        /// <summary>
        /// 取用户控件的操作结果
        /// </summary>
        /// <returns></returns>
        void GetResult(int customerControlIndex = 0);
        /// <summary>
        /// 显示用户控件信息
        /// </summary>
        void BindUC(int customerControlIndex = 0);
    }
}
