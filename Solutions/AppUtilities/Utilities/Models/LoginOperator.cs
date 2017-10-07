using System;
using WitsWay.Utilities.Enums;

namespace WitsWay.Utilities.Models
{

    /// <summary>
    /// 登录操作人员
    /// </summary>
    [Serializable]
    public class LoginOperator
    {

        /// <summary>
        /// 企业ID
        /// </summary>
        public int CorpId { get; set; }

        /// <summary>
        /// 企业编码
        /// </summary>
        public string CorpCode { get; set; }

        /// <summary>
        /// 企业简称
        /// </summary>
        public string CorpShortName { get; set; }

        /// <summary>
        /// 企业名称
        /// </summary>
        public string CorpName { get; set; }

        /// <summary>
        /// 操作员ID
        /// </summary>
        public int OperatorId { get; set; }

        /// <summary>
        /// 操作员编码
        /// </summary>
        public string OperatorCode { get; set; }

        /// <summary>
        /// 操作员名称
        /// </summary>
        public string OperatorName { get; set; }

        /// <summary>
        /// 系统标识
        /// </summary>
        public SubSystems SystemIdentify { get; set; }

        /// <summary>
        /// 登陆IP
        /// </summary>
        public string LoginIP { get; set; }

        /// <summary>
        /// 工位机ID(工位机程序使用)
        /// </summary>
        public int ComputerId { get; set; }

        /// <summary>
        /// 机器物理地址(工位机程序使用)
        /// </summary>
        public string PhysicalAddress { get; set; }

        /// <summary>
        /// 授权令牌
        /// </summary>
        public string Tocken { get; set; }

    }
}