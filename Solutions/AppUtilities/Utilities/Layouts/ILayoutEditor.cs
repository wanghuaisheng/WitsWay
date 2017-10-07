namespace WitsWay.Utilities.Layouts
{
    /// <summary>
    /// IEditor
    /// </summary>
    public interface ILayoutEditor
    {
        /// <summary>
        /// 取值
        /// </summary>
        /// <returns></returns>
        object GetValue();
        /// <summary>
        /// 设值
        /// </summary>
        /// <param name="value"></param>
        void SetValue(object value);
    }
}
