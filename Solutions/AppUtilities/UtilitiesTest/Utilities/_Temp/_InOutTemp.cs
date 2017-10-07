//using System;
//using System.Collections.Generic;
//using SmartSolution.Utilities.Daos;
//using SmartSolution.Utilities.Entitys;

//namespace SmartSolution.Utilities.Daos
//{
//    /// <summary>
//    /// 数据存储通用接口
//    /// </summary>
//    /// <typeparam name="TKey">主键类型</typeparam>
//    public interface IRepository1<out TKey>
//    {

//        /// <summary>
//        /// 逻辑移除
//        /// </summary>
//        /// <param name="id">主键</param>
//        TKey Remove(int id);

//    }
//}


//public interface animal
//{
//    void abc();
//}
//public abstract class A : animal
//{

//    public abstract void abc();
//}

//public class B : A
//{

//    public override void abc()
//    {
//        Console.WriteLine("B");
//    }
//}

//public class C : A
//{

//    public override void abc()
//    {
//        throw new NotImplementedException();
//    }
//}

///// <summary>
///// 数据存储通用接口
///// </summary>
///// <typeparam name="TKey">主键类型</typeparam>
///// <typeparam name="TData">要存取的实例对象</typeparam>
//public interface IRepositoryBulk2<out TKey, in TData> : IRepository1<TKey>
//{
//    /// <summary>
//    /// 批量插入
//    /// </summary>
//    /// <param name="datas">实体列表</param>
//    /// <returns>批量插入结果</returns>
//    BulkInsertResult BulkInsert(IEnumerable<TData> datas);
//}

//public class AnimalRepository : IRepositoryBulk2<B, A>
//{

//    public BulkInsertResult BulkInsert(IEnumerable<A> datas)
//    {
//        throw new NotImplementedException();
//    }

//    public B Remove(int id)
//    {
//        throw new NotImplementedException();
//    }
//}
//public class TestTestInOut
//{
//    public void TestTest()
//    {
//        IRepositoryBulk2<A, B> res = new AnimalRepository();
//        res.BulkInsert(new List<B>());

//        var dd = res.Remove(1);
//    }
//}