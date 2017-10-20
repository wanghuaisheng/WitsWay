using System;
using System.Collections;
using System.Reflection;
using MSRegex = System.Text.RegularExpressions;

namespace WitsWay.Utilities.Regexs
{

    /// <summary>
    /// Ҫ����������
    /// ���Ա�ʾ
    /// <remarks>
    /// ÿ��RegexClassInfo�д洢��ParseClassAttribute��ParsePropertyAttribute�ֵ�
    /// ���ฺ�����Եĸ�ֵ����һ��RegexClassInfoʵ����ʱ����ʵ��������
    /// </remarks>
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class ParsePropertyAttribute : Attribute
    {

        #region [Field]
        ///// <summary>
        /////��־
        ///// </summary>
        /// <summary>
        /// Ĭ��ת�������࣬Ĭ��ΪDataConverHelper
        /// </summary>
        private readonly Type _converHelperClass = typeof(DefaultDataConverHelper);

        // ת��������
        private readonly string _converFun;
        // ����
        /// <summary>
        /// ƥ������
        /// </summary>
        public string RegexGroupName { get; }

        /// <summary>
        /// ������Ϣ
        /// </summary>
        public PropertyInfo PropertyInfo { get; set; }

        private MethodInfo _converMethod;

        /// <summary>
        /// ת�������� 
        /// </summary>
        public Type CreateType { get; private set; }

        #endregion

        #region [Construction]

        /// <summary>
        /// ����ƥ������
        /// </summary>
        /// <param name="groupName">������ʽ�е�GroupName</param>
        public ParsePropertyAttribute(string groupName)
        {
            RegexGroupName = groupName;
        }
        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="groupName">ƥ������</param>
        /// <param name="converFun">ת��������</param>
        public ParsePropertyAttribute(string groupName, string converFun)
        {
            RegexGroupName = groupName;
            _converFun = converFun;
        }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="groupName">ƥ������</param>
        /// <param name="converClass">����ת������</param>
        /// <param name="converFun">ת������</param>
        public ParsePropertyAttribute(string groupName, Type converClass, string converFun)
        {
            RegexGroupName = groupName;
            _converFun = converFun;
            _converHelperClass = converClass;
        }


        #endregion

        #region [SetPropertyValue]

        /// <summary>
        /// �������Ե�ֵ
        /// </summary>
        /// <param name="matchObject"></param>
        /// <param name="group"></param>
        /// <returns>���óɹ�����true</returns>
        internal bool SetPropertyValue(object matchObject, MSRegex.Group group)
        {
            try
            {
                var proType = PropertyInfo.PropertyType;
                //����֧��
                if (proType.IsGenericType)
                {
                    if (proType.IsArray == false)
                    {
                        if (PropertyInfo.CanWrite)
                        {
                            //�����ֱ�Ӵ���
                            if (PropertyInfo.PropertyType.IsAssignableFrom(proType))
                            {
                                try
                                {
                                    IList list;
                                    list = Activator.CreateInstance(proType) as IList;
                                    //��ȡ�����ڲ���Ա
                                    var parameters = proType.GetGenericArguments();

                                    if (parameters.Length != 1)
                                    {
                                        throw new Exception("�޷����������Ա���Σ�");
                                    }
                                    var valueType = parameters[0];
                                    //�����жϸ������ǲ��ǿ��Լ���ƥ�����������ǵĻ��ͼ���ƥ��
                                    if (IsRegexMatchClass(parameters[0]))
                                    {
                                        //
                                        foreach (MSRegex.Capture c in @group.Captures)
                                        {
                                            var str = c.Value;
                                            var retObj = Activator.CreateInstance(valueType);
                                            if (RegexHelper.Match(retObj, ref str, false))
                                            {

                                                list.Add(retObj);
                                            }
                                        }
                                        PropertyInfo.SetValue(matchObject, list, null);
                                        return true;
                                    }

                                    object retObj2 = null;
                                    //��ͨ����
                                    foreach (MSRegex.Capture c in @group.Captures)
                                    {
                                        if (ChangeType(matchObject, c.Value, ref retObj2))
                                        {
                                            var obj2 = retObj2 as IList;
                                            if (obj2 != null)
                                            {
                                                list = obj2;
                                                break;
                                            }
                                            list.Add(retObj2);
                                        }

                                    }
                                    PropertyInfo.SetValue(matchObject, list, null);
                                    return true;
                                }
                                catch (Exception ee)
                                {
                                    throw new Exception("�޷�����ʵ����", ee);
                                }
                            }
                        }
                        else
                        {
                            throw new Exception("�ó�Աֻ����");
                        }
                    }
                    else
                    {
                        throw new Exception("��֧�ַ�������");
                    }
                }
                else
                {
                    object retObj = null;
                    var value = group.Value;
                    //�Ƿ���֧��
                    if (ChangeType(matchObject, value, ref retObj))
                    {
                        PropertyInfo.SetValue(matchObject, retObj, null);
                        return true;
                    }
                }

            }
            catch (Exception)
            {
                throw new Exception("�����������");
            }
            return false;
        }
        /// <summary>
        /// �ж��ǲ��ǰ���������ʽ����
        /// </summary>
        bool IsRegexMatchClass(Type type)
        {
            var info = RegexClassFactory.GetRegexClass(type);
            if (info == null)
            {
                return false;
            }
            return true;
        }

        bool ChangeType(object setValue, string value, ref object retObj)
        {

            if (string.IsNullOrEmpty(_converFun))
            {
                //û���Լ�����ת������
                if (CreateType == null)
                {
                    CreateType = PropertyInfo.PropertyType;
                }
                retObj = Convert.ChangeType(value, CreateType, null);
                return true;
            }
            //�Լ�������ת������
            if (_converMethod == null)
            {
                //����ת����������
                var type = setValue.GetType();
                while (_converMethod == null)
                {
                    _converMethod = type.GetMethod(_converFun);
                    type = type.BaseType;
                    if (type == null)
                    {
                        break;
                    }
                }
                if (_converMethod == null)
                {
                    //��ȡ��׼����ת������
                    if (_converHelperClass != null)
                    {
                        var tempType = _converHelperClass;
                        while (_converMethod == null)
                        {
                            _converMethod = tempType.GetMethod(_converFun);
                            tempType = tempType.BaseType;
                            if (type == null)
                            {
                                break;
                            }
                        }
                    }
                }

            }
            if (_converMethod != null)
            {
                try
                {
                    retObj = _converMethod.Invoke(setValue, new object[] { value });
                    return true;
                }
                catch (Exception e1)
                {
                    throw new Exception("������ʽ��������ת���쳣", e1);

                }
            }
            throw new Exception($"δ�ҵ�ָ����ת������{_converFun}");
        }

        #endregion

        #region [DefaultConvertClass]
        
        /// <summary>
        /// ����ת��������
        /// </summary>
        private static class DefaultDataConverHelper
        {
            /// <summary>
            /// ���ַ���ת����Int����
            /// </summary>
            public static int StringToHexInt(string value)
            {
                return value.HexToInt();
            }
        }

        #endregion

        #region [Deleted]

        ///// <summary>
        ///// ����ƥ������
        ///// </summary>
        ///// <param name="groupName">������ʽ�е�GroupName</param>
        ///// <param name="createType">�趨������������ֵ</param>
        //public ParsePropertyAttribute(string groupName, Type createType)
        //{
        //    _groupName = groupName;
        //    _createType = createType;
        //}

        #endregion

    }

    public static class HexExtends{

        /// <summary>
        /// 16�����ַ���ת��ΪInt
        /// </summary>
        public static int HexToInt(this string hex)
        {
            if (string.IsNullOrWhiteSpace(hex)) { return 0; }

            var i = Convert.ToInt32(hex, 16);

            if (i >= 0x8000000)
                i = ~(i - 1);

            return i;
        }
    }


}
