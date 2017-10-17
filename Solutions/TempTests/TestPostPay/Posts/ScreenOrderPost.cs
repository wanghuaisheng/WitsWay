using System.Collections.Generic;

namespace Touch.Enums.Posts
{

    /// <summary>
    /// 大屏订单提交对象
    /// </summary>
    public class ScreenOrderPost
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
        /// <summary>
        /// 终端类型，大屏1，IPad2
        /// </summary>
        public int TerminalKind { get; set; }
        /// <summary>
        /// 客户姓名
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// 客户手机号
        /// </summary>
        public string CustomerPhone { get; set; }
        /// <summary>
        /// 下单产品列表
        /// </summary>
        public List<ScreenOrderPostItem> Items { get; set; }
    }



}
