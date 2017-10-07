namespace GeneralQuery.Editors
{
    public interface IInputEditor
    {
        /// <summary>
        /// 绑定值
        /// </summary>
        /// <param name="val"></param>
        void BindValue(object val);
        /// <summary>
        /// 获取值
        /// </summary>
        /// <returns></returns>
        object GetValue();
    }
}
