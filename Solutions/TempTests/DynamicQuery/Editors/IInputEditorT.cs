namespace GeneralQuery.Editors
{
    public interface IInputEditor<T>
    {
        /// <summary>
        /// 绑定值
        /// </summary>
        /// <param name="val"></param>
        void BindValue(T val);
        /// <summary>
        /// 获取值
        /// </summary>
        /// <returns></returns>
        T GetValue();
    }
}
