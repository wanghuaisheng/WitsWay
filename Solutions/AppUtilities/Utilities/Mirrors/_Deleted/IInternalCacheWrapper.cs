//using System;
//using System.Collections.Generic;
//using SmartSolution.Utilities.Supports;

//namespace SmartSolution.Utilities.Mirrors
//{

//    /// <summary>
//    /// 内部缓存包装
//    /// </summary>
//    public interface IInternalCacheMethodWrapper
//    {
     
//        /// <summary>
//        /// 执行服务端方法，有返回值
//        /// </summary>
//        /// <typeparam name="TResult">返回类型</typeparam>
//        /// <param name="url">方法URL</param>
//        /// <param name="parameters">参数列表</param>
//        /// <returns>方法返回对象</returns>
//        TResult ExecuteMethod<TResult>(string url, params object[] parameters);

//        /// <summary>
//        /// 执行服务端方法，无返回值
//        /// </summary>
//        /// <param name="url">方法URL</param>
//        /// <param name="parameters"></param>
//        void ExecuteAction(string url, params object[] parameters);

//    }

//    /// <summary>
//    /// 内部缓存包装
//    /// </summary>
//    public interface IInternalCacheWrapper
//    {
//        /// <summary>
//        /// 部分过期
//        /// </summary>
//        /// <param name="id">要过期的数据Id</param>
//        void PartyExpire(string id);

//        /// <summary>
//        /// 过期缓存
//        /// <para>过期后不一定重建缓存，取决于缓存项自身设置</para>
//        /// </summary>
//        void Expire();

//        /// <summary>
//        /// 重建缓存项
//        /// </summary>
//        void Rebuild();

//        /// <summary>
//        /// 获取缓存项最后修改时间
//        /// </summary>
//        /// <returns>缓存项最后修改时间</returns>
//        DateTime GetLastModifyTime();

//        /// <summary>
//        /// 删除数据
//        /// </summary>
//        /// <param name="id">编号</param>
//        void Delete(string id);

//        /// <summary>
//        /// 是否存在数据
//        /// </summary>
//        /// <param name="id">键</param>
//        bool Exist(string id);

//    }

//    /// <summary>
//    /// 内部缓存包装
//    /// </summary>
//    public interface IInternalCacheWrapper<TEntity> : IInternalCacheWrapper
//        where TEntity : IKey
//    {

//        /// <summary>
//        /// 获取数据泛型列表
//        /// </summary>
//        /// <returns>数据泛型列表</returns>
//        List<TEntity> GetList();
//        /// <summary>
//        /// 获取一个数据
//        /// </summary>
//        /// <returns>数据</returns>
//        TEntity GetOne(string id);

//        /// <summary>
//        /// 添加数据
//        /// </summary>
//        /// <param name="data">要添加的数据</param>
//        void Add(TEntity data);

//        /// <summary>
//        /// 修改数据
//        /// </summary>
//        /// <param name="data">要修改的数据</param>
//        void Edit(TEntity data);

//    }

//}
