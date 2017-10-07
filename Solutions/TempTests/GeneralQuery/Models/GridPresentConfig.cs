using System.Collections.Generic;

namespace WitsWay.TempTests.GeneralQuery.Models
{
    public class GridPresentConfig
    {
        /// <summary>
        /// 支持操作权限
        /// </summary>
        public List<OperationRights> Commands { get; set; }
        /// <summary>
        /// Grid支持功能集 </summary>
        public List<GridFunctions> Functions { get; set; }
        /// <summary>
        /// Grid模式
        /// </summary>
        public GridModes GridMode { get; set; }
 
    }
}
