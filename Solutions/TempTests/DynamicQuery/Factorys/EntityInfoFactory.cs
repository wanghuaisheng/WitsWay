using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using WitsWay.TempTests.DynamicQuery.Attributes;
using WitsWay.TempTests.DynamicQuery.Entities;

namespace WitsWay.TempTests.DynamicQuery.Factorys
{
    public class EntityInfoFactory
    {

        //        public static List<EntityDataSource> DsList=new List<EntityDataSource>()
        //        {
        //            new EntityDataSource()
        //            {
        //                Key=""
        //            }
        //        };

        private static EntityDataInfo GetDataInfo(Type t)
        {
            EntityDataInfo data = new EntityDataInfo();
            var attrs = t.GetCustomAttributes(typeof(EntityDataAttribute));
            var attr = (EntityDataAttribute)attrs.First();
            data.Title = attr.Title;
            data.Name = t.Name;
            data.EntityType = t.FullName;
            data.EntityAssembly = t.Assembly.ManifestModule.Name;
            data.Fields = new List<EntityFieldInfo>();

            var ps = t.GetProperties();
            foreach (var p in ps)
            {
                object[] attrs2 = p.GetCustomAttributes(typeof(EntityFieldAttribute), false);
                if (attrs2.Any())
                {
                    var ed = (EntityFieldAttribute) attrs2[0];

                    EntityFieldInfo fi = new EntityFieldInfo()
                    {
                        Name = p.Name,
                        Title = ed.Title,
                        FieldType = p.PropertyType.ToString()
                    };
                    data.Fields.Add(fi);
                }
            }

            var fs = t.GetFields();
            foreach (var f in fs)
            {
                object[] attrs2 = f.GetCustomAttributes(typeof(EntityFieldAttribute), false);
                if (attrs2.Any())
                {
                    var ed = (EntityFieldAttribute)attrs2[0];

                    EntityFieldInfo fi = new EntityFieldInfo()
                    {
                        Name = f.Name,
                        Title = ed.Title,
                        FieldType = f.FieldType.ToString()
                    };
                    data.Fields.Add(fi);
                }
            }

            return data;
        }

        /// <summary>
        /// 简单类型
        /// sbyte-System.SByte
        /// byte-System.Byte
        /// short-System.Int16
        /// ushort-System.UInt16
        /// int-System.Int32
        /// uint-System.UInt32
        /// long-System.Int64
        /// ulong-System.UInt64
        /// char-System.Char
        /// float-System.Single
        /// double-System.Double
        /// bool-System.Boolean
        /// decimal-System.Decimal
        /// 整型            ： C# 支持 9 种整型：sbyte、byte、short、ushort、int、uint、long、ulong 和 char
        /// 浮点型          ： C# 支持两种浮点型：float 和 double。
        /// decimal 类型    ： decimal 类型是 128 位的数据类型
        /// bool 类型       ： bool 类型表示布尔逻辑量
        /// 枚举类型        ： 枚举类型是具有命名常量的独特的类型
        /// 可空类型        ： 可以为 null 的类型可以表示其基础类型 (underlying type) 的所有值和一个额外的 null 值
        /// 
        /// 引用类型        ： 引用类型是类类型、接口类型、数组类型或委托类型。
        /// System.Object   ： 所有其他类型的最终基类。
        /// System.String   ： C# 语言的字符串类型。
        /// System.ValueType： 所有值类型的基类。
        /// System.Enum     ： 所有枚举类型的基类。
        /// System.Array    ： 所有数组类型的基类。
        /// System.Delegate ： 所有委托类型的基类。
        /// System.Exception： 所有异常类型的基类。
        /// System.DateTime :  时间类型，是结构体。


        /// </summary>
        /// <returns></returns>
        public static List<EntityDataInfo> GetSupportEntities()
        {
            var types = Assembly.GetExecutingAssembly().GetTypes().ToList();
            var dataTypes = types.FindAll(t => t.GetCustomAttributes(typeof(EntityDataAttribute)).Any());
            //var dataTypes = types.TakeWhile(type => type.GetCustomAttributes(typeof(EntityDataAttribute)).Any()).ToList();
            return !dataTypes.Any() ? new List<EntityDataInfo>() : dataTypes.Select(GetDataInfo).ToList();
        }

    }
}
