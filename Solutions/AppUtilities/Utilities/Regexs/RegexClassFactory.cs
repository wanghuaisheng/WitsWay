using System;
using System.Collections.Generic;
using System.Reflection;

namespace WitsWay.Utilities.Regexs
{
    /// <summary>
    /// ����������Ĺ���
    /// <remarks>
    /// ͨ�������Type����������
    /// </remarks>
    /// </summary>
    public static class RegexClassFactory
    {
        /// <summary>
        /// ���ڴ���Ѿ�ƥ�����������
        /// </summary>
        private static readonly Dictionary<Type, RegexClassInfo> TypeDic = new Dictionary<Type, RegexClassInfo>();
        /// <summary>
        /// ȡ��������
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static RegexClassInfo GetRegexClass(object obj)
        {
            return obj == null ? null : GetRegexClass(obj.GetType());
        }

        /// <summary>
        /// ȡ��������
        /// </summary>
        /// <param name="type">����Type</param>
        /// <returns></returns>
        public static RegexClassInfo GetRegexClass(Type type)
        {
            RegexClassInfo info;
            if (TypeDic.TryGetValue(type, out info) == false)
            {
                //ȡ���Զ�������ParseClassAttribute
                var attribs = type.GetCustomAttributes(typeof(ParseClassAttribute), true);
                if (attribs.Length <= 0) return null;
                info = CreateRegexClassInfo(type, attribs[0] as ParseClassAttribute);
                if (info != null)
                {
                    TypeDic[type] = info;
                }
            }
            else
            {
                info = TypeDic[type];
            }
            return info;
        }

        /// <summary>
        /// ����RegexClassInfo��
        /// </summary>
        /// <param name="type">Ҫ������������Ϣ��Type</param>
        /// <param name="customAttribute">�Զ�������ParseClassAttribute</param>
        /// <returns>��������Ϣ</returns>
        private static RegexClassInfo CreateRegexClassInfo(Type type, ParseClassAttribute customAttribute)
        {
            var result = new RegexClassInfo
            {
                CustomClassInfo = customAttribute
            };
            result.CreateRegex(customAttribute.RegexString);

            var properties = type.GetProperties(BindingFlags.Instance | BindingFlags.SetProperty | BindingFlags.Public);
            foreach (var property in properties)
            {
                var objs = property.GetCustomAttributes(typeof(ParsePropertyAttribute), true);
                if (objs.Length > 0)
                {
                    var atrrib = objs[0] as ParsePropertyAttribute;
                    if (atrrib != null)
                    {
                        atrrib.PropertyInfo = property;
                        result.PropertyMap[atrrib.RegexGroupName] = atrrib;
                    }
                }
            }
            return result.Available() ? result : null;
        }

    }
}
