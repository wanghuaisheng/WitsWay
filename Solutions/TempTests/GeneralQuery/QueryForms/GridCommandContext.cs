using System.Collections.Generic;

namespace WitsWay.TempTests.GeneralQuery.QueryForms
{
    /// <summary>
    /// Grid操作上下文
    /// </summary>
    public class GridCommandContext<T>
    {
        public T FocusRow { get; set; }

        public IEnumerable<T> SelectedRows { get; set; }
 

    }
}
