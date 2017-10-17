using System.Collections.Generic;

namespace Touch.Enums.Posts
{

    /// <summary>
    /// Pad订单Post对象
    /// </summary>
    public class PadOrderPost
    {
        ///<sumary>
        /// 项目标识
        ///</sumary>
        public string ProjectIC { get; set; }
        ///<sumary>
        /// 终端标识
        ///</sumary>
        public string UUID { get; set; }
        ///<sumary>
        /// 登录用户名
        ///</sumary>
        public string Username { get; set; }
        ///// <summary>
        ///// 终端类型，大屏1，IPad2
        ///// </summary>
        //public int TerminalKind { get; set; }
        /// <summary>
        /// 下单产品列表
        /// </summary>
        public List<PadOrderPostItem> Items { get; set; }
    }



}
