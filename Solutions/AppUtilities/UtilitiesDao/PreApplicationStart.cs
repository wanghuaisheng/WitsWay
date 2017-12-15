using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Dapper;
using WitsWay.Utilities.Dap.LambdaSqlBuilder.Attributes;

namespace WitsWay.Utilities.Dap
{

    public static class PreApplicationStart
    {
        private static readonly Func<Type, string, PropertyInfo> _fu = (type, columnName) => type.GetProperties().FirstOrDefault(prop => GetColumnAttribute(prop) == columnName);
        private static bool _initialized;

        public static void RegisterTypeMaps()
        {
            if (_initialized)
            {
                return;
            }

            _initialized = true;

            var aliasType = typeof(DbColumnAttribute);

            var mappedTypeList = new List<Type>();
            //TODO:Start
            var assemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();

            AppDomain.CurrentDomain.AssemblyLoad += (sender, args) =>
            {
                var aliasType2 = typeof(DbColumnAttribute);
                var mappedTypeList2 = new List<Type>();
                var assembly = args.LoadedAssembly;

                var mappedTypes = assembly.GetExportedTypes().Where(
                    f =>
                        f.GetProperties().Any(
                            p =>
                                p.GetCustomAttributes(false).Any(
                                    a => a.GetType().Name == aliasType2.Name)));

                mappedTypeList2.AddRange(mappedTypes);

                foreach (var mappedType in mappedTypeList2)
                {
                    SqlMapper.SetTypeMap(mappedType, new CustomPropertyTypeMap(mappedType, _fu));
                }
            }; //CurrentDomain_AssemblyLoad};
            foreach (var assembly in assemblies)
            {
                try
                {
                    var mappedTypes = assembly.GetExportedTypes().Where(
                        f =>
                            f.GetProperties().Any(
                                p =>
                                    p.GetCustomAttributes(false).Any(
                                        a => a.GetType().Name == aliasType.Name)));

                    mappedTypeList.AddRange(mappedTypes);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            //TODO:END
            foreach (var mappedType in mappedTypeList)
            {
                SqlMapper.SetTypeMap(mappedType, new CustomPropertyTypeMap(mappedType, _fu));
            }

        }


        static string GetColumnAttribute(MemberInfo member)
        {
            if (member == null) return null;
            var attr = member.GetCustomAttribute<DbColumnAttribute>(false);
            return attr == null ? member.Name : attr.Name;//未定义DBColumnAttribute使用字段名称
        }

    }
}
