using System;

namespace WitsWay.TempTests.DynamicQuery.DataRights
{
    /// <summary>
    /// 支持权限上下文
    /// </summary>
    public class RightContextAttribute:Attribute
    {
        public RightContextKinds Kinds { get; set; }

        public RightContextAttribute(RightContextKinds kinds)
        {
            Kinds = kinds;
        }

    }
}
