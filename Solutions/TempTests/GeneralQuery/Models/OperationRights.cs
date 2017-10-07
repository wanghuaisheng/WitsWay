using WitsWay.Utilities.Attributes;

namespace WitsWay.TempTests.GeneralQuery.Models
{
    /// <summary>
    /// 操作权限
    /// </summary>
    public enum OperationRights
    {
        [EnumField("查看")]
        View,
        [EnumField("添加2")]
        Add,
        [EnumField("修改")]
        Edit,
        [EnumField("删除")]
        Delete,
        [EnumField("移除")]
        Remove,
        [EnumField("审核")]
        Audit,
        [EnumField("发布")]
        Publish,
        [EnumField("搜索")]
        Search,
        //……
    }
}
