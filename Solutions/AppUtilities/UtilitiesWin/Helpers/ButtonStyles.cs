/******************************************
 * 2012年7月21日 王怀生 添加
 * 
 * ***************************************/

using WitsWay.Utilities.Attributes;

namespace WitsWay.Utilities.Win.Helpers
{
    /// <summary>
    /// 按钮样式
    /// </summary>
    public enum ButtonStyles
    {

        /// <summary>
        /// 搜索
        /// </summary>
        [EnumDescription("搜索")]
        Search,

        /// <summary>
        /// 刷新
        /// </summary>
        [EnumDescription("刷新")]
        Refresh,
        /// <summary>
        /// 确定
        /// </summary>
        [EnumDescription("确定")]
        Confirm,

        /// <summary>
        /// 关闭
        /// </summary>
        [EnumDescription("关闭")]
        Close,
        /// <summary>
        /// 选择
        /// </summary>
        [EnumDescription("选择")]
        Select,
        /// <summary>
        /// 分组
        /// </summary>
        [EnumDescription("分组")]
        Group,
        /// <summary>
        /// 查看方式
        /// </summary>
        [EnumDescription("查看")]
        ViewWay,
        /// <summary>
        /// 查看
        /// </summary>
        [EnumDescription("查看")]
        View,
        /// <summary>
        /// 修改
        /// </summary>
        [EnumDescription("修改")]
        Edit,
        /// <summary>
        /// 清除
        /// </summary>
        [EnumDescription("清除")]
        ClearSearch,
        /// <summary>
        /// 预览
        /// </summary>
        [EnumDescription("预览")]
        Preview,
        /// <summary>
        /// 生成参数
        /// </summary>
        [EnumDescription("生成参数")]
        GenerateParameter,
        /// <summary>
        /// 有无批次
        /// </summary>
        [EnumDescription("有无批次")]
        BatchAll,
        /// <summary>
        /// 有批次
        /// </summary>
        [EnumDescription("有批次")]
        Batched,
        /// <summary>
        /// 无批次
        /// </summary>
        [EnumDescription("无批次")]
        BatchNot,
        /// <summary>
        /// 设置
        /// </summary>
        [EnumDescription("设置")]
        Set,
        /// <summary>
        /// 添加
        /// </summary>
        [EnumDescription("添加")]
        Add,
        /// <summary>
        /// 删除
        /// </summary>
        [EnumDescription("删除")]
        Delete,
        /// <summary>
        /// 回退
        /// </summary>
        [EnumDescription("回退")]
        Backward,
        /// <summary>
        /// 前进
        /// </summary>
        [EnumDescription("前进")]
        Foreward,
        /// <summary>
        /// 保存
        /// </summary>
        [EnumDescription("保存")]
        Save,
        /// <summary>
        /// 打印
        /// </summary>
        [EnumDescription("打印")]
        Print,
        /// <summary>
        /// 新增2
        /// </summary>
        AddNew2,
        /// <summary>
        /// 移除2
        /// </summary>
        Delete2,
        /// <summary>
        /// 发货
        /// </summary>
        [EnumDescription("发货")]
        SendGoods,
        /// <summary>
        /// 完成
        /// </summary>
        [EnumDescription("完成")]
        Accept,
        /// <summary>
        /// 发货延迟
        /// </summary>
        [EnumDescription("发货延迟")]
        SendDefer,

        /// <summary>
        /// 全部展开
        /// </summary>
        [EnumDescription("全部展开")]
        ExpandAll,

        /// <summary>
        /// 全部折叠
        /// </summary>
        [EnumDescription("全部折叠")]
        CollapseAll,

        /// <summary>
        /// 登录按钮
        /// </summary>
        [EnumDescription("登录按钮")]
        Login_Button,

        /// <summary>
        /// 上移
        /// </summary>
        [EnumDescription("上移")]
        MoveUp,

        /// <summary>
        /// 下移
        /// </summary>
        [EnumDescription("下移")]
        MoveDown

    }
}
