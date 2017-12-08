#region License(Apache Version 2.0)
/******************************************
 * Copyright ®2017-Now WangHuaiSheng.
 * Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file
 * except in compliance with the License. You may obtain a copy of the License at
 * http://www.apache.org/licenses/LICENSE-2.0
 * Unless required by applicable law or agreed to in writing, software distributed under the
 * License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
 * either express or implied. See the License for the specific language governing permissions
 * and limitations under the License.
 * Detail: https://github.com/WangHuaiSheng/WitsWay/LICENSE
 * ***************************************/
#endregion 
#region ChangeLog
/******************************************
 * 2017-10-7 OutMan Create
 * 
 * ***************************************/
#endregion
using System.Runtime.Serialization;

namespace WitsWay.Utilities.Errors
{
    /// <summary>
    /// 通用错误
    /// </summary>
    [DataContract]
    [ErrorDomain(ErrorDomains.Utility)]
    public enum UtilityErrors
    {
        /// <summary>
        /// 未处理程序异常
        /// </summary>
        [EnumMember]
        [ErrorItem("未处理程序异常")]
        UnHandleProgramError = 1,
        /// <summary>
        /// 内部程序错误
        /// </summary>
        [EnumMember]
        [ErrorItem("内部程序错误")]
        InternalProgramError,
        /// <summary>
        /// 程序未实现。
        /// </summary>
        [EnumMember]
        [ErrorItem("程序未实现。")]
        ProgramNotImplement,

        /// <summary>
        /// 类型不是从指定类型继承
        /// </summary>
        [EnumMember]
        [ErrorItem("类型继承错误。")]
        TypeIsAssignableException,
        /// <summary>
        /// 类型实例化错误
        /// </summary>
        [EnumMember]
        [ErrorItem("类型实例化错误。")]
        TypeInstanceException,
        /// <summary>
        /// 程序集加载错误。
        /// </summary>
        [EnumMember]
        [ErrorItem("程序集加载错误。")]
        AssemblyLoadError,
        /// <summary>
        /// 对象序列化错误
        /// </summary>
        [EnumMember]
        [ErrorItem("对象序列化错误。")]
        ObjectSerilizeError,
        /// <summary>
        /// 对象反序列化错误
        /// </summary>
        [EnumMember]
        [ErrorItem("对象反序列化错误。")]
        ObjectDeserilizeError,
        /// <summary>
        /// 未考虑到程序分支。
        /// </summary>
        [EnumMember]
        [ErrorItem("未考虑到程序分支。")]
        ProgramBatchNotHandleError,

        /// <summary>
        /// 参数为空
        /// </summary>
        [EnumMember]
        [ErrorItem("参数为空。")]
        ArgumentNullException,
        /// <summary>
        /// 参数错误
        /// </summary>
        [EnumMember]
        [ErrorItem("参数错误。")]
        ArgumentErrorException,
        /// <summary>
        /// 数据库访问错误
        /// </summary>
        [EnumMember]
        [ErrorItem("数据库访问错误")]
        DatabaseAccessError,
        /// <summary>
        /// 数据库连接错误
        /// </summary>
        [EnumMember]
        [ErrorItem("数据库连接错误")]
        DatabaseConnectionError,
        /// <summary>
        /// 文件、目录或流访问错误
        /// </summary>
        [EnumMember]
        [ErrorItem("文件、目录或流访问错误。")]
        FileOrDirectoryOrStreamAccessError,
        /// <summary>
        /// 消息队列访问错误
        /// </summary>
        [EnumMember]
        [ErrorItem("消息队列访问错误。")]
        MsmqQueueAccessError,

        /// <summary>
        /// 数据库初始化数据错误
        /// </summary>
        [EnumMember]
        [ErrorItem("数据库初始化数据错误。")]
        DatabaseInitDataError,

        /// <summary>
        /// 数据库数据错误（废弃）
        /// </summary>
        [EnumMember]
        [ErrorItem("数据库数据错误。")]
        DatabaseDataError,
        /// <summary>
        /// 服务访问错误。
        /// </summary>
        [EnumMember]
        [ErrorItem("服务访问错误。")]
        ServiceAccessError,
        /// <summary>
        /// 服务内部程序错误。
        /// </summary>
        [EnumMember]
        [ErrorItem("服务内部程序错误。")]
        ServiceProgramError,

        /// <summary>
        /// 服务等待超时。
        /// </summary>
        [EnumMember]
        [ErrorItem("服务等待超时。")]
        ServerWaitTimeoutError,

        /// <summary>
        /// configuration→appSettings→serverHost不是有效的IP地址。
        /// </summary>
        [EnumMember]
        [ErrorItem("configuration→appSettings→serverHost不是有效的IP地址。")]
        ConfigFileErrorServerIpNotIp,

        /// <summary>
        /// configuration→appSettings→serverPort不是有效的端口值。
        /// </summary>
        [EnumMember]
        [ErrorItem("configuration→appSettings→serverPort不是有效的端口值。")]
        ConfigFileErrorServerPortNotPort,

        /// <summary>
        /// 子服务器通讯信息未找到或者已经删除。
        /// </summary>
        [EnumMember]
        [ErrorItem("子服务器通讯信息未找到或者已经删除。")]
        BaseCommunicationSubServerNotFound,
        /// <summary>
        /// 输入数据不符合数据约束
        /// </summary>
        [EnumMember]
        [ErrorItem("输入数据不符合数据约束。")]
        ErpValidationDataInputError,
        /// <summary>
        /// 输入数据不符合业务逻辑约束
        /// </summary>
        [EnumMember]
        [ErrorItem("输入数据不符合业务逻辑约束。")]
        ErpValidationDataLogicError,

        /// <summary>
        /// ERP中不存在对应的子系统
        /// </summary>
        [EnumMember]
        [ErrorItem("ERP中不存在对应的子系统。")]
        NotExistSubSystem,
        /// <summary>
        /// 序列已达到上限。
        /// </summary>
        [EnumMember]
        [ErrorItem("序列已达到上限。")]
        SequenceNoOverMaxValue,

        /// <summary>
        /// 支持序列还未实现。
        /// </summary>
        [EnumMember]
        [ErrorItem("支持序列还未实现。")]
        SequenceNotImplement,

        /// <summary>
        /// 路径码格式错误。
        /// </summary>
        [EnumMember]
        [ErrorItem("路径码格式错误。")]
        PathCodeFormatError,

        /// <summary>
        /// 系统全局数据已经变更。
        /// </summary>
        [EnumMember]
        [ErrorItem("系统全局数据已经变更。")]
        SystemGlobalDataHaveChanged,

        /// <summary>
        /// 区域内已排在最后一位，不能向下移动。
        /// </summary>
        [EnumMember]
        [ErrorItem("区域内已排在最后一位，不能向下移动。")]
        NotAllowMoveDown,
        /// <summary>
        /// 区域内已排在第一位，不能向上移动。
        /// </summary>
        [EnumMember]
        [ErrorItem("区域内已排在第一位，不能向上移动。")]
        NotAllowMoveUp,
        /// <summary>
        /// 数据实现DLL文件{0}不存在
        /// </summary>
        [EnumMember]
        [ErrorItem("数据实现DLL文件{0}不存在")]
        DaoDllFileNotExist,
        /// <summary>
        /// 数据实现DLL文件{0}载入失败
        /// </summary>
        [EnumMember]
        [ErrorItem("数据实现DLL文件{0}载入失败")]
        DaoDllFileLoadFail,
        /// <summary>
        /// 数据访问对象创建失败
        /// </summary>
        [EnumMember]
        [ErrorItem("数据访问对象创建失败")]
        DaoCreateError,
        /// <summary>
        /// 数据访问对象{0}创建失败
        /// </summary>
        [EnumMember]
        [ErrorItem("数据访问对象{0}创建失败")]
        DaoCreateErrorFormat,
        /// <summary>
        /// 不存在对应接口{0}的数据访问对象
        /// </summary>
        [EnumMember]
        [ErrorItem("不存在对应接口{0}的数据访问对象")]
        DaoNotExist,
        /// <summary>
        /// 数据填充键“{0}（{1}）”重复
        /// </summary>
        [EnumMember]
        [ErrorItem("数据填充键“{0}（{1}）”重复")]
        FillKeyDuplicated,
        /// <summary>
        /// 数据填充目标“{0}（{1}）”重复
        /// </summary>
        [EnumMember]
        [ErrorItem("数据填充目标“{0}（{1}）”重复")]
        FillTargetDuplicated,
        /// <summary>
        /// 数据填充目标“{0}（{1}）”无对应的填充键
        /// </summary>
        [EnumMember]
        [ErrorItem("数据填充目标“{0}（{1}）”无对应的填充键")]
        FillTargetMissingKey,
        /// <summary>
        /// 数据填充键“{0}（{1}）”无对应的填充目标
        /// </summary>
        [EnumMember]
        [ErrorItem("数据填充键“{0}（{1}）”无对应的填充目标")]
        FillKeyMissingTarget,
        /// <summary>
        /// 缺少附加参数
        /// </summary>
        [EnumMember]
        [ErrorItem("缺少附加参数")]
        FillAttachParaLess,
        /// <summary>
        /// 附加参数类型错误
        /// </summary>
        [EnumMember]
        [ErrorItem("附加参数类型错误")]
        FillAttachParaTypeError,
        /// <summary>
        /// 程序配置文件中appSettings中缺少配置{0}
        /// </summary>
        [EnumMember]
        [ErrorItem("程序配置文件中appSettings中缺少配置{0}")]
        AppConfigAppSettingsMiss,
        /// <summary>
        /// 不存在对应Id：{0}的{1}数据
        /// </summary>
        [EnumMember]
        [ErrorItem("不存在对应Id：{0}的{1}数据")]
        NoDataWithId,
        /// <summary>
        /// 筛选状态包含“0”
        /// </summary>
        [EnumMember]
        [ErrorItem("筛选状态包含“0”")]
        StatesInStatesContainsZero,

        /// <summary>
        /// 自定义验证器程序集{0}载入失败
        /// </summary>
        [EnumMember]
        [ErrorItem("自定义验证器程序集{0}载入失败")]
        CustomValidatorDllFileLoadFail,

        /// <summary>
        /// 自定义验证器有重复的键{0}
        /// </summary>
        [EnumMember]
        [ErrorItem("自定义验证器有重复的键{0}")]
        CustomValidatorHaveDuplicateKey,

        /// <summary>
        /// 不存在主键为{0}的自定义验证器
        /// </summary>
        [EnumMember]
        [ErrorItem("不存在主键为{0}的自定义验证器")]
        NotExistCustomValidatorWithKey,

        /// <summary>
        /// 无权登录{0}
        /// </summary>
        [EnumMember]
        [ErrorItem("无权登录{0}")]
        NoRightToLogin,

        /// <summary>
        /// 不支持解析提供器“{0}”"
        /// </summary>
        [EnumMember]
        [ErrorItem("不支持解析提供器“{0}”")]
        NotSupportParseProvider,

        /// <summary>
        /// 登录系统『{0}』系统配置信息不存在
        /// </summary>
        [EnumMember]
        [ErrorItem("登录系统『{0}』系统配置信息不存在")]
        LoginSubSystemConfigNotExist,
        /// <summary>
        /// 用户『{0}』不存在
        /// </summary>
        [EnumMember]
        [ErrorItem("用户『{0}』不存在")]
        UserWithKeyNotExist,
        /// <summary>
        /// 资源『{0}』请求失败
        /// </summary>
        [EnumMember]
        [ErrorItem("资源『{0}』请求失败")]
        ResourceRequestFail,
        /// <summary>
        /// 程序配置文件中appSettings中配置{0}获取失败
        /// </summary>
        [EnumMember]
        [ErrorItem("程序配置文件中appSettings中配置{0}获取失败")]
        AppConfigAppSettingError,
        /// <summary>
        /// 对象转换错误：{0}
        /// </summary>
        [EnumMember]
        [ErrorItem("对象转换错误：{0}")]
        ObjectCastError,
    }
}
